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
	public partial class MainCoopbkup : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button lblResME;
		protected System.Web.UI.WebControls.Label lblContents1;
		protected System.Web.UI.WebControls.Button btnContacts;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			Load_DomainName();
			Session["OrgIdt"]=Session["OrgId"];
			Session["OrgNamet"]=Session["OrgName"];
			lblContents.Text="Control Menu for Region: " + Session["DomainName"].ToString();
			lblLicense.Text="License Id: " + Session["LicenseId"].ToString();
			lblOrg.Text=Session["OrgName"].ToString();
			Load_Main();
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
		
		private void Load_DomainName()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "eps_RetrieveDomainName";
			cmd.Parameters.Add ("@DomainId",SqlDbType.NVarChar);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"DomainName");
			Session["DomainName"] = ds.Tables["DomainName"].Rows[0][0];

		}
		private void Load_Main()
		{	
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
		}	
		protected void btnAssess_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmAssessOrg.aspx?");	
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}
		protected void btnReports_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmReportsAdm.aspx?");
		
		}

		protected void btnProfilesB_Click(object sender, System.EventArgs e)
		{
			Session["ProfileType"]="Producer";
			Session["Mode"]="Profiles";
			Response.Redirect (strURL + "frmProfiles.aspx?");		
		}

		protected void btnProcs_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmProcs.aspx?");
		}
		
		protected void btnEvents_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmEvents.aspx?");
		}

		protected void btnResTypes_Click(object sender, System.EventArgs e)
		{
			Session["Mode"]="Write";
			Response.Redirect (strURL + "frmResourceTypes.aspx?");
		}

		protected void btnProfilesH_Click(object sender, System.EventArgs e)
		{
			Session["ProfileType"]="Consumer";
			Session["Mode"]="Profiles";
			Response.Redirect (strURL + "frmProfiles.aspx?");
		
		}

		protected void btnRoles_Click(object sender, System.EventArgs e)
		{
			Session["CallerRoles"]="frmMainCoop";
			Response.Redirect (strURL + "frmRoles.aspx?");
		}

		private void btnContacts_Click(object sender, System.EventArgs e)
		{
			Session["CallerCTA"]="frmMainCoop";
			Response.Redirect (strURL + "frmContactTypesAll.aspx?");
		
		}

		protected void btnSteps_Click(object sender, System.EventArgs e)
		{
			Session["CallerRoles"]="frmMainCoop";
			Response.Redirect (strURL + "frmSteps.aspx?");
		
		}

	}
}

