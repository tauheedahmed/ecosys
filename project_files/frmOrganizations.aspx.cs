
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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmOrganizations : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Procedures();
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
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents1.Text="";
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveOrganizations";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
            if (Session["CO"].ToString() == "frmUpdContractS")
            {
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
                cmd.Parameters["@Type"].Value = "1";
            }
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServProviders");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button btU = (Button) (i.Cells[2].FindControl("btnUpdate"));
				Button btD = (Button) (i.Cells[2].FindControl("btnDelete"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.Connection.Open();
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from Contracts"
					+ " Where OrgId = " + i.Cells[0].Text;
				if (cmd.ExecuteScalar() != null) 
				{
					btD.Visible=false;
					i.Cells[3].Text="In Use";
				}
				cmd.CommandText="Select Id from StaffActions"
					+ " Where OrgId = " + i.Cells[0].Text;
				if (cmd.ExecuteScalar() != null) 
				{
					btD.Visible=false;
					i.Cells[3].Text="In Use";
				}
				cmd.CommandText="Select Organizations.Id from Organizations"
					+ " Where Id = " + i.Cells[0].Text
					+ " And CreatorOrg =" +  Session["OrgId"].ToString();
				if (cmd.ExecuteScalar() == null)
				{
					btD.Visible=false;
					btU.Visible=false;
					i.Cells[3].Text="Externally Created";
				}
				if (i.Cells[0].Text == Session["OrgId"].ToString())
				{
					btD.Visible=false;
					btU.Visible=false;
				}
				cmd.Connection.Close();
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
				Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CO"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				Session["SelType"]="Org";
				Session["SelOrgId"]=e.Item.Cells[0].Text;
				Session["SelOrgName"]=e.Item.Cells[1].Text;
				Exit();
			}
			else if (e.CommandName == "Update")
			{
				Session["btnAction"]="Update";
				Session["CUO"]="frmOrganizations";
				Response.Redirect (strURL + "frmUpdOrganization.aspx?"
				+ "&Id= " + e.Item.Cells[0].Text);	
			}
			else if (e.CommandName == "Delete")
			{
				btnExit.Visible=false;
				btnAdd.Visible=false;
				btnDeleteOrg.Visible=true;
				btnNoDelete.Visible=true;
				btnDeleteOrg.Text="Delete";
				btnNoDelete.Text="Cancel";
				lblContents1.Text="This will delete all data regarding this organization.  Click 'Cancel'"
					+ " if you are not sure, or 'Delete' if you wish to delete this organization.";
				lblContents1.ForeColor=Color.Maroon;
				Session["DelId"]=e.Item.Cells[0].Text;
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["btnAction"]="Add";
			Session["CUO"]="frmOrganizations";
			Response.Redirect (strURL + "frmUpdOrganization.aspx?");		
		}

		protected void btnDeleteOrg_Click(object sender, System.EventArgs e)
		{
			
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_DeleteOrg";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse(Session["DelId"].ToString());
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			resetForm();
		}
		private void resetForm()
		{
			btnExit.Visible=true;
			btnAdd.Visible=true;
			btnDeleteOrg.Visible=false;
			btnNoDelete.Visible=false;
			lblContents1.Text="This will delete all data regarding this organization.  Click 'Cancel'"
				+ " if you are not sure, or 'Delete' if you wish to delete this organization.";
			lblContents1.ForeColor=Color.Navy;
			Session["DelId"]=null;
			lblContents1.Text="";
			loadData();
		}

		protected void btnNoDelete_Click(object sender, System.EventArgs e)
		{
			resetForm();
		}
	}

}