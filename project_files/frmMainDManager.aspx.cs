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
	public partial class MainDManager : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button lblResME;
		protected System.Web.UI.WebControls.Button btnContactsReport;
		protected System.Web.UI.WebControls.Label lblContents1;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Load_RegionName();
				getPeopleId();
				loadPDomainName();
				Load_Main();
				lblReports.Text="You may generate the following reports:";
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
		private void loadPDomainName()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "Select Profiles.Id, Profiles.Name, Profiles.Households from Profiles"
				+ " Where Profiles.PeopleId = " + Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PDomains");
			Session["PDomainId"] = ds.Tables["PDomains"].Rows[0][0];
			Session["PDomainName"] = ds.Tables["PDomains"].Rows[0][1];
			/*if (ds.Tables["PDomains"].Rows[0][2].ToString() == "1")
			{
				btnProfile.Text="Start (Organizations)";
			}*/
			lblTitle.Text="Domain Profiles System:  Domain Manager's Workbench";
			lblContent1.Text="Domain: " + Session["PDomainName"].ToString();
		}
		private void Load_Main()
		{
			
			lblName.Text="Manager: " + Session["Fname"].ToString() + " " + Session["Lname"].ToString();
			lblUser.Text="";
			lblContent2.Text="Greetings. As Domain Manager," 
				+ " you are responsible for identifying the types of services, operating procedures and "
				+ " types of resources required to carry out this work for the domain (i.e. industry"
				+ " or profession) '"
				+ Session["PDomainName"].ToString()				
				+ "'.  This provides the framework within which "
				+ " individual organizations in this domain develop and implement their work programs."
				+ " Click on 'Start (Producers)' to continue.";
			lblContent3.Text= "You are also responsible for adding household characteristics that are peculiar to your"
								+ " region.   Click on 'Start (Households)' to continue."; 
		}
		private void Load_RegionName()
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
			lblContent4.Text="Geographical Scope: " + Session["DomainName"].ToString();

		}
		protected void btnProfile_Click(object sender, System.EventArgs e)
		{
			Session["ProfileType"]="Producer";
			Session["CPSTypes"]="frmMainDManager";
			Session["ProfilesId"]=Session["PDomainId"].ToString();
			Session["ProfilesName"]=Session["PDomainName"].ToString();
			Response.Redirect (strURL + "frmProfileServiceTypes.aspx?");
		}


		private void btnrptHouseholdPlan_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmReportsPers.aspx?");
		}
		protected void btnSignOff_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}
		private void getPeopleId()
		{
			Object tmp = new object();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "ams_RetrieveUserIdName";
			cmd.Parameters.Add ("@UserId",SqlDbType.NVarChar);
			cmd.Parameters["@UserId"].Value=Session["UserId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"UserPerson");
			/*tmp = cmd.ExecuteScalar();*/
			Session["PeopleId"] = ds.Tables["UserPerson"].Rows[0][0];
			Session["LName"] = ds.Tables["UserPerson"].Rows[0][1];
			Session["Fname"] = ds.Tables["UserPerson"].Rows[0][2];
			Session["CellPhone"] = ds.Tables["UserPerson"].Rows[0][3];
			Session["HomePhone"] = ds.Tables["UserPerson"].Rows[0][4];
			Session["WorkPhone"] = ds.Tables["UserPerson"].Rows[0][5];
			Session["Address"] = ds.Tables["UserPerson"].Rows[0][6];
			Session["Email"] = ds.Tables["UserPerson"].Rows[0][7];
		}
		private void btnPlanReport_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptHouseholdRes.rpt";
			rpts();
		}

		private void btnContactsReport_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptHouseholdContacts.rpt";
			rpts();
		}
		private void rpts()
		{
			Session["cRG"]="frmMainEPS";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}

		protected void btnBudgetNeeds_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptResourceNeeds.rpt";
			rpts();
		}
		protected void btnProcs_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptEmerProcs.rpt";
			rpts();
		
		}

		protected void btnTaskPeople_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptTaskTeams.rpt";
			rpts();	
		}
		private void setProfile()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveOrgProfile";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"OrgProfile");
			Session["ProfileId"]=ds.Tables["OrgProfile"].Rows[0][0].ToString();
			Session["ProfileName"]=ds.Tables["OrgProfile"].Rows[0][1].ToString();
		}

		protected void btnBIA_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptDProfile.rpt";
			rpts();	
		}

		protected void btnSignOff_Click_1(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmEnd.aspx?");
		}

		protected void btnhouseholds_Click(object sender, System.EventArgs e)
		{
			Session["ProfileType"]="Consumer";
			Session["Mode"]="Profiles";
			Response.Redirect (strURL + "frmProfiles.aspx?");		
		}
	}
	}

