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
	public partial class MainBMgr : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button lblResME;
		protected System.Web.UI.WebControls.Button btnContactsReport;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Main();
            Session["MgrOption"] = "Budget";
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
			lblContent1.Text="Greetings.  This menu enables you to establish and distribute budgets."
				+ " Click on 'Start' to continue.";
			getProfile();
			getBDS();
            lblOrg.Text = Session["OrgName"].ToString();
		}
		private void getBDS()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsBDS";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"BDS");
			if (ds.Tables["BDS"].Rows[0][0].ToString() == "0")
			{
				Session["BDS"]= 0;
			}
			else
			{
				Session["BDS"]= 1;
			}
		}
		private void getProfile()
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
			if (ds.Tables["OrgProfile"].Rows.Count == 0)
			{
				setProfile();
			}
			else
			{
				Session["ProfilesId"]=ds.Tables["OrgProfile"].Rows[0][0].ToString();
				Session["ProfilesName"]=ds.Tables["OrgProfile"].Rows[0][1].ToString();
			}
		}
		private void setProfile()
		{
			Session["CSProfilesAll"]="frmMainBMgr";
			Session["Type"]="Producer";
			Response.Redirect (strURL + "frmProfilesAll.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
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
			Session["cRG"]="frmMainBMgr";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}
		/*private void getServiceId()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveServiceId";
			cmd.Parameters.Add("@OrgId",SqlDbType.NVarChar);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ServiceId");
			if (ds.Tables["ServiceId"].Rows.Count != 0)
			{
				Session["ServiceId"]=ds.Tables["ServiceId"].Rows[0][0].ToString();
				Session["ServiceName"]="Emergency Management";
			}
			else
			{
				issueServiceId();
			}	
		}
		private void issueServiceId()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_AddServiceId";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
			cmd.Parameters["@Name"].Value= "Emergency Management";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value= Session["OrgId"];
			cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
			cmd.Parameters["@ResTypeId"].Value= 51;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

			SqlCommand cmd1=new SqlCommand();
			cmd1.Connection=this.epsDbConn;
			cmd1.CommandType=CommandType.StoredProcedure;
			cmd1.CommandText="eps_RetrieveServiceId";
			cmd1.Parameters.Add("@OrgId",SqlDbType.NVarChar);
			cmd1.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd1);
			da.Fill(ds,"ServiceId");
			if (ds.Tables["ServiceId"].Rows.Count != 0)
			{
				Session["ServiceId"]=ds.Tables["ServiceId"].Rows[0][0].ToString();
				Session["ServiceName"]="Emergency Management";
			}	
			else
			{
				lblOrg.Text="Unable to complete request.  Please contact IT Support.";
			}
		}*/

		protected void btnFYBudgets_Click(object sender, System.EventArgs e)
		{
			getBRSFlag();
			Session["CBudgets"]="frmMainBMgr";
			Response.Redirect (strURL + "frmBudgets.aspx?");
		}
		private void getBRSFlag()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsBRS";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"BRS");
			if (ds.Tables["BRS"].Rows[0][0].ToString() == "0")
			{
				Session["BRS"]= 0;
			}
			else
			{
				Session["BRS"]= 1;
			}
		}
	}
	}

