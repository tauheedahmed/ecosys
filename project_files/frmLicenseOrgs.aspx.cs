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
	public partial class frmLicenseOrgs : System.Web.UI.Page
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
				lblContents1.Text="License No and Name: " + Session["ClientLicenseId"].ToString()
                    + " - " + Session["ClientLicenseName"].ToString();
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveLicenseOrgs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Int32.Parse(Session["ClientLicenseId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServProviders");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
				Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CLO"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["btnAction"]="Update";
				Session["CUO"]="frmLicenseOrgs";
				Response.Redirect (strURL + "frmUpdLicOrg.aspx?"
				+ "&Id= " + e.Item.Cells[0].Text);	
			}
			else if (e.CommandName == "Services")
			{
				Session["CallerOS"]="frmLicenseOrgs";
				Session["OrgIdC"]=e.Item.Cells[0].Text;
				Session["OrgNameC"]=e.Item.Cells[1].Text;
				Session["ProfileIdC"]=e.Item.Cells[4].Text;
				Session["ProfileNameC"]=e.Item.Cells[5].Text;
				Response.Redirect (strURL + "frmOrgServices.aspx?");
			}
			else if (e.CommandName == "Flags")
			{
				Session["CF"]="frmLicenseOrgs";
				Session["OrgIdC"]=e.Item.Cells[0].Text;
				Session["OrgNameC"]=e.Item.Cells[1].Text;
				Session["ProfileIdC"]=e.Item.Cells[4].Text;
				Session["ProfileNameC"]=e.Item.Cells[5].Text;
				Response.Redirect (strURL + "frmOrgFlags.aspx?");
			}
			else if (e.CommandName == "Locations")
			{
				Session["CLocsAll"]="frmLicenseOrgs";
				Session["OrgIdC"]=e.Item.Cells[0].Text;
				Session["OrgNameC"]=e.Item.Cells[1].Text;
				Session["OrgIdPC"]=e.Item.Cells[6].Text;
				Session["LicenseIdC"]=e.Item.Cells[7].Text;
				Session["DomainIdC"]=e.Item.Cells[8].Text;
				Response.Redirect (strURL + "frmLocsAll.aspx?");
			}
			else if (e.CommandName == "Vis")
			{
			}
			else if (e.CommandName == "Households")
			{
				lblContents1.Text="To be Added";
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["btnAction"]="Add";
			Session["CUO"]="frmLicenseOrgs";
			Response.Redirect (strURL + "frmUpdLicOrg.aspx?");		
		}
	}

}