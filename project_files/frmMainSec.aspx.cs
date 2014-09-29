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
using CrystalDecisions.Shared;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for Main.
	/// </summary>
	public partial class MainSec : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button lblResME;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Session["Caller1"]="frmMainSec";
			lblTitle.Text="Security Officer's Workbench";
			lblContent1.Text="Click on 'Start' to continue.";
			
			if (Session["Email"]!=null)
			{
				lblUser.Text="Note:  The User Id to access this menu has been issued to " +  Session["PName"].ToString()
					+ " whose email address is: " + Session["Email"].ToString();
			}
			else
			{
				lblUser.Text=
					"Note:  The User Id to access this menu has been issued to " +  Session["PName"].ToString()
					+ " who does not have an email address listed on this system.";
			}
			if (!IsPostBack)
			{
				Load_Main();
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

		}
		#endregion
		
		private void Load_Main()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}
		protected void btnReports_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmReportsAdm.aspx?");	
		}

		protected void btnUsers_Click(object sender, System.EventArgs e)
		{
            Session["CSec"] = "frmMainSec";
            
			Response.Redirect (strURL + "frmLicenseUsers.aspx?");

		}
		protected void lblOrganizations_Click(object sender, System.EventArgs e)
		{
			Session["CallerOrgs"]="frmMainSec";
			Session["OrgType"]="All";
			Response.Redirect (strURL + "frmOrgs.aspx?");
		}

	}
}

