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
	public partial class MainPers : System.Web.UI.Page
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
			Session["Caller1"]="frmMainPers";
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
			lblTitle.Text="Emergency Preparedeness System:  Home Page";
			lblOrg.Text="User Name: " + Session["OrgName"].ToString();
			getCorg();
			lblUser.Text="Note:  This web page is made available to the "
				+ Session["Orgname"].ToString()
				+ " household courtesy of "
				+ 	Session["CorgName"].ToString() 
				+ ", and is meant for noncommercial use in this household only."
				+ " In accessing and/or using services and other contents of this website,"
				+ " you agree to consider yourself, and no one else, wholly responsible for any"
				+ " and all financial or"
				+ " any other kind of costs or liabilities"
				+ " that you or anyone else may incur due to your access of this service.";
			lblStep1a.Text="Step 1.  Identify Household Characteristics";
			lblStep1b.Text="Step 2.  Generate a print-friendly checklist of emergency"
				+ " preparedness measures";
			lblStep2a.Text= "Step 1.  Enter/Revise Contact Data";
			lblStep2b.Text= "Step 2.  Generate a print-friendly contact list";

			//"Note:  The User Id to access this menu has been issued by " +  Session["OrgName"].ToString();
			lblContent3.Text="Greetings.  Congratulations on taking the time to help"
				+ " ensure emergency preparedness in your household.";
			
		}

		protected void btnHseHold_Click(object sender, System.EventArgs e)
		{
			Session["CProfileOrgs"]="frmMainPers";
			Response.Redirect (strURL + "frmProfileOrgs.aspx?");	
		}
		private void btnrptHouseholdPlan_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmReportsPers.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}
		protected void btnContacts_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmContacts.aspx?");	
		}

		protected void btnEvents_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmEvents.aspx?");
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
		private void getCorg()
		{
			Object tmp = new object();
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "ams_RetrieveCorg";
			cmd.Parameters.Add ("@COrgId",SqlDbType.Int);
			cmd.Parameters["@COrgId"].Value=Int32.Parse(Session["COrg"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Coorg");
			/*tmp = cmd.ExecuteScalar();*/
			Session["CorgName"] = ds.Tables["Coorg"].Rows[0][0];
		}
		
		protected void btnHHRes_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptHHResNeeds.rpt";
			rpts();
		}

		protected void btnContactsReport_Click(object sender, System.EventArgs e)
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
			Session["cRG"]="frmMainPers";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}

		protected void btnHHSer(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptHHSerNeeds.rpt";
			rpts();
		}



	}
	}

