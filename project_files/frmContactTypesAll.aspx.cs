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
	public partial class frmContactTypesAll: System.Web.UI.Page
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
			loadForm();
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
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				if (Session["CallerCTA"].ToString() == "frmProfileSPC")
				{
					lblContent1.Text=Session["ProfileName"].ToString() + ": " + Session["ProcName"].ToString();
					lblContent2.Text="Please Select Types of Contacts Related to this Profile";
					DataGrid1.Columns[4].Visible=false;
					btnAdd.Visible=false;
				}
				else
				{
					DataGrid1.Columns[3].Visible=false;
					lblContent2.Text="List of Contact Types";
				}
				loadData();
			}
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_RetrieveContactTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Function",SqlDbType.NVarChar);
				cmd.Parameters["@Function"].Value="Update";
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"CTypes");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			if (Session["CallerCTA"].ToString() == "frmProfileSPC")
			{
				updateGrid();
				Exit();
			}
			else
			{
				Exit();
			}
		
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox) (i.Cells[3].FindControl("cbxSel"));
				if ((cb.Checked) & (cb.Enabled))
				{
					if (Session["CallerCTA"].ToString() == "frmProfileSPC")
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateProfileSPC";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@Caller", SqlDbType.NVarChar);
						cmd.Parameters ["@Caller"].Value="frmContactTypesAll";
						cmd.Parameters.Add("@ContactTypeId", SqlDbType.Int);
						cmd.Parameters ["@ContactTypeId"].Value=i.Cells[0].Text;
						cmd.Parameters.Add("@ProfileServiceProcId", SqlDbType.Int);
						cmd.Parameters ["@ProfileServiceProcId"].Value=Session["ProfileSPId"].ToString();
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}
		}
		private void refreshGrid()
		{
			if (Session["CallerCTA"].ToString() == "frmfrmProfileSPC")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					cmd.CommandText="Select Id from ProfileSPC"
						+ " Where ContactTypeId = " + i.Cells[0].Text
						+ " and ProfileServiceProcId = " + Session["ProfileSPId"].ToString();
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) cb.Checked = true;
					cmd.Connection.Close();
				}
			}
		}


		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerCTA"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Response.Redirect (strURL + "frmUpdContactType.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[5].Text);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteContactType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdCTS"]="frmContactTypesAll";
			Response.Redirect (strURL + "frmUpdContactType.aspx?"
				+ "&btnAction=" + "Add");
		
		}
	}

}

