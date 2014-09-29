using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmOwnResourcesAll: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string S;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Resources();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
		private void Load_Resources()
		{			
			if (!IsPostBack)
			{	
				S="Yes";
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent.Text="Type of Resource: " + Session["ResTypeName"].ToString();
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveResAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();			
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
			cmd.Parameters["@ResTypeId"].Value=Session["ResTypeId"].ToString();
			cmd.Parameters.Add ("@AllResTypesFlag",SqlDbType.NVarChar);
			cmd.Parameters["@AllResTypesFlag"].Value=S;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ResourcesAll");
			Session["ds"] = ds;
			if (ds.Tables["ResourcesAll"].Rows.Count ==0)
			{
				if (S=="Yes")
				{
					lblContent.Text = "There are no resources of type '"
						+ Session["ResTypeName"].ToString() 
						+ "' identified for the above organization.  "
						+ " You may extend your search to available resources"
						+ " of all types by clicking on the button titled"
						+ " 'Display All Available Resources'.  Or you may "
						+ " initiate a procurement request by clicking on the button"
						+ " titled 'Enter Procurement Request'"; 
				}
				else
				{
					lblContent.Text = "There are no resources of type"
						+ " available to this organization. Would you like to "
						+ " initiate a procurement request now?";
				}
				btnOK.Text="Exit";
				btnCancel.Visible=false;
				btnResAll.Visible=true;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
			}
			else
			{
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
			}			
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[5].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateTaskResource";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@TaskResId", SqlDbType.Int);
					cmd.Parameters ["@TaskResId"].Value=Session["TaskResId"].ToString();
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text;
					cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
					cmd.Parameters ["@Type"].Value=i.Cells[4].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		private void refreshGrid()
		{
			/*foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[8].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from ResourceOrg"
					+ " Where ResourceId=" + i.Cells[0].Text 
					+ " and OrgId=" + Session["OrgId"];
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}*/
		}

		private void Exit()
		{
		  Response.Redirect (strURL + Session["CResAll"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void btnCancel1_Click(object sender, System.EventArgs e)
		{
			Exit();		
		}

		protected void btnResAll_Click(object sender, System.EventArgs e)
		{
			S="No";
			lblContent.Text="Type of Resource: All Available Types";
			btnOK.Visible=true;
			btnCancel.Visible=true;
			loadData();
		}

		protected void btnProcurementReq_Click(object sender, System.EventArgs e)
		{
			Session["CallerUpdProcure"]="frmTaskResources";
			Session["btnAction"]="Add";
			Session["Id"]="0";
			Response.Redirect (strURL + "frmUpdProcurement.aspx?");
		
		}



	}

}


