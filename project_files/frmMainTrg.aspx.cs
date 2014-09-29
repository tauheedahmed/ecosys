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
	public partial class MainTrg : System.Web.UI.Page
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
			Session["OrgIdt"]=Session["OrgId"];
			lblTitle.Text="Human Resources System:  HR Specialist's Workbench";
			lblLic.Text="License No.  " + Session["LicenseId"].ToString();
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
			lblContents2.Text="Greetings.  As the Human Resources Specialist, you"
				+ " identify different kinds of organizational roles in your type of organization; the "
				+ " skills required by an individual to carry out that role; and finally to identify"
				+ " different types of training courses that are available to develop those skills."
				+ " To identify the various roles in your organization, and from there to identify skills"
				+ " required, click on 'Roles'";
			lblContents3.Text="To identify different types of skills directly,"
				+ " and from there to identify appropriate training courses, click on 'Skills'";
			lblContents4.Text="To generate a set of reports for easy"
				+ " review of the information entered above, click on 'Reports'"; 

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
		
		private void Load_Main()
		{	
			lblOrg.Text=Session["OrgName"].ToString();//+ " O: " + Session["OrgId"].ToString() + " P : "  +Session["OrgIdP"].ToString();
			if (Session["OrgId"].ToString() == Session["OrgIdP"].ToString())
			{
				
				lblOrgP.Visible=false;
			}
			else	
			{
				lblOrgP.Text=Session["OrgNameP"].ToString();// + Session["OrgId"].ToString()
					//+ " Parent: " + Session["OrgIdP"].ToString();
			}	
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}
		private void btnReports_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmReportsAdm.aspx?");
		
		}
		protected void btnCourses_Click(object sender, System.EventArgs e)
		{	
				Session["OrgIdt"]=Session["OrgId"];
				Session["OrgNamet"]=Session["OrgName"];
				Session["CallerServices"]="frmMainTrg";
				Response.Redirect (strURL + "frmServices.aspx?");
		}


		protected void btnSkills_Click(object sender, System.EventArgs e)
		{
			Session["CallerRoles"]="frmMainTrg";
			Response.Redirect (strURL + "frmSkills.aspx?");
		}

		protected void btnRoles_Click(object sender, System.EventArgs e)
		{
			Session["CallerRolesAll"]="frmMainTrg";
			Response.Redirect (strURL + "frmRolesAll.aspx?");
		}

		private void btnContactData_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveOrgs";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
			cmd.Parameters["@OrgType"].Value="";
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="Main";
			cmd.Connection=this.epsDbConn;	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Orgs");
			Session["CallerUpdOrg"]="frmMainPers";
			Session["btnAction"] = "Review";
			Response.Redirect (strURL + "frmUpdOrgRead.aspx?"
				+ "&btnAction=" + "Update"
				+ "&Id=" + ds.Tables["Orgs"].Rows[0][0].ToString()
				+ "&Name=" + ds.Tables["Orgs"].Rows[0][1].ToString()				
				+ "&Desc=" + ds.Tables["Orgs"].Rows[0][2].ToString()
				+ "&Phone=" + ds.Tables["Orgs"].Rows[0][3].ToString()
				+ "&Email=" + ds.Tables["Orgs"].Rows[0][4].ToString()
				+ "&Addr=" + ds.Tables["Orgs"].Rows[0][5].ToString()
				+ "&PeopleId=" + ds.Tables["Orgs"].Rows[0][6].ToString()
				+ "&Vis=" + ds.Tables["Orgs"].Rows[0][10].ToString());
		
		}


	}
}

