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
	public partial class frmLocTypesAll: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				lblOrg.Text=Session["OrgName"].ToString();
				if (Session["CLocTypesAll"].ToString() == "frmProfileSEPStepTypes")
				{
					lblContent1.Text="Select location for step '"
					+ Session["frmProfileSEPStepTypes"].ToString() + "'";
					lblContent2.Text="";
					DataGrid1.Columns[2].Visible=false;
					btnOK.Visible=false;
				}
				else
				{
					lblContent1.Text=Session["ProfileName"].ToString();
					lblContent2.Text="";
					DataGrid1.Columns[3].Visible=false;
				}
				loadData();
			}
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_RetrieveLocTypesAll";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
				cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
				cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
				cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
				cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
				cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"LocTypes");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			if (Session["CLocTypesAll"].ToString() != "frmProfileSEPStepTypes")
			{
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
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					if ((cb.Checked) & (cb.Enabled == true))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="wms_UpdateProfileSL";//eps_UpdateServiceProcs
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@ProfileServicesId",SqlDbType.Int);
						cmd.Parameters["@ProfileServicesId"].Value=Session["ProfileServicesId"].ToString();
						cmd.Parameters.Add("@LocTypeId", SqlDbType.Int);
						cmd.Parameters ["@LocTypeId"].Value=i.Cells[0].Text;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from ProfileServiceLocs"
					+ " Where ProfileServicesId = " + Session["ProfileServicesId"].ToString()
					+ " and LocTypeId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
					cb.Enabled = false;
				}
				cmd.Connection.Close();
			}
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CLocTypesAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CLocTypesAll"].ToString() + ".aspx?");
		}

		protected void btnAddLocTypes_Click(object sender, System.EventArgs e)
		{
			Session["CUpdLocTypes"] = "frmLocTypesAll";	
			Response.Redirect (strURL + "frmUpdLocType.aspx?"
				+ "&btnAction=" + "Add");
		
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (Session["CLocTypesAll"].ToString() == "frmProfileSEPStepTypes")
			{
				if (e.CommandName == "Select")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_UpdateStepTypesLoc";
					cmd.Parameters.Add("@LocTypesId", SqlDbType.Int);
					cmd.Parameters ["@LocTypesId"].Value=e.Item.Cells[0].Text;
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=Session["ProfileSEPStepTypesId"].ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
				else if (e.CommandName == "Update")
				{
					Session["CUpdLocTypes"] = "frmLocTypesAll";	
					Response.Redirect (strURL + "frmUpdLocType.aspx?"
						+ "&btnAction=" + "Update"
						+ "&Id=" + e.Item.Cells[0].Text
						+ "&Name=" + e.Item.Cells[1].Text
						+ "&Vis=" + e.Item.Cells[5].Text
						+ "&Desc=" + e.Item.Cells[6].Text);
				}
				else if (e.CommandName == "Delete")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_StepTypesLoc";
					cmd.Parameters.Add("@LocTypesId", SqlDbType.Int);
					cmd.Parameters ["@LocTypesId"].Value=e.Item.Cells[0].Text;
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=Session["ProfileSEPStepTypesId"].ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}

			}
		}
	}

}

