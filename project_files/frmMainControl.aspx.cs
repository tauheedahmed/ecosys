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
	public partial class MainControl : System.Web.UI.Page
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
          
				Load_DomainName();

				lblTitle.Text="Domain Profiles System:  Domain Coordinator's Workbench";
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
			//lblContent1.Text=Session["DomainName"].ToString();

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
			cmd.CommandText = "eps_RetrieveUserIdName";
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
		private void btnBIA_Click(object sender, System.EventArgs e)
		{
		}
		private void rpts()
		{
			Session["cRG"]="frmMainControl";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}


		private void btnTaskPeople_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptUserIds.rpt";
			rpts();	
		}
		protected void btnProfile_Click(object sender, System.EventArgs e)
		{
            Session["CProfiles"] = "frmMainControl";
			Session["ProfileType"]="Producer";
			Session["Mode"]="Profiles";
			Response.Redirect (strURL + "frmProfiles.aspx?");
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
		private void btnSignOff_Click_1(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmEnd.aspx?");
		}

		protected void btnHouseholds_Click(object sender, System.EventArgs e)
		{
            Session["CProfiles"] = "frmMainControl";
			Session["ProfileType"]="Consumer";
			Session["Mode"]="Profiles";
			Response.Redirect (strURL + "frmProfiles.aspx?");		
		}

		protected void btnSer_Click(object sender, System.EventArgs e)
		{
            Session["CServiceTypes"]="frmMainControl";
            Session["ProfileType"] = "Producer";
			Response.Redirect (strURL + "frmServiceTypes.aspx?");
		}

		protected void btnCurr_Click(object sender, System.EventArgs e)
		{
			Session["CCurr"]="frmMainControl";
			Response.Redirect (strURL + "frmCurrencies.aspx?");
		}
        protected void btnProfileMgrs_Click(object sender, EventArgs e)
        {
            Session["CallerPeople"] = "frmMainControl";
            Response.Redirect(strURL + "frmPeople.aspx?");
        }
        protected void btnHHSuppliers_Click(object sender, EventArgs e)
        {
            Session["CContracts"] = "frmMainControl";
            Session["MgrOption"] = "Supply";
            Session["HHFlag"] = "1";
            Session["PRC"] = "0";
            Response.Redirect(strURL + "frmContractsS.aspx?");
        }
    }
}

