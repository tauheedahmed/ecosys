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
	public partial class frmMainWP: System.Web.UI.Page
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
            Session["MgrOption"] = "Plan";
            Session["HHFlag"] = null;

			lblOrg.Text=Session["OrgName"].ToString();
			getProfile();
			getBRS();
			getWPS();
			getEPS();
			Session["PRS"] = "0";

			if (Session["EPS"].ToString() == "1")
			{
            
            
            lblBMReports.Text="This set of reports together describes the various types of" 
			+ " emergency procedures in place in this organization, and related staffing and other requirements.";
            
            lblContent3.Text = "After you click on the button below, you may be asked to identify the budget"
                    + " and/or location for which you are preparing the plan.  Having done that, you will then"
                    + " proceed to assign staff responsible and the resources provided for various emergency procedures.";
            lblWPReports.Text = "This set of reports together describes" 
			+ " the staff and other resources assigned to perform various emergency procedures above at various locations and the"
		    + " related budget implications";
            /*lblContent1.Visible = false;
            lblBMReports.Visible = false;
            btnEProcs.Visible = false;
            btnSP.Visible = false;
            btnStfTOR.Visible = false;
            btnBIA.Visible = false;
            lblContent2.Visible = false;
            btnLocServices.Visible = false;
            lblContent3.Visible = false;
            lblWP1.Visible = false;
            lblWPReports.Visible = false;
            btnBud.Visible = false;
            btnBudGS.Visible = false;
            btnTT.Visible = false;*/

            }
            else
            {
                lblContent.Text = "You may now prepare work plans and automatically determine"
                + " the budgeted amounts required to deliver these work plans by completing the three steps below.";
                lblBMReports.Text = "This set of reports together describes the various types of"
                + " procedures in place in this organization, and related staffing and other requirements.";
                lblContent2.Text = "Step II. Prepare Work Plans and Budgets"; 
                lblContent3.Text = "After you click on the button below, you may be asked to identify the budget"
                    + " and/or location for which you are preparing the plan.  Having done that, you will then"
                    + " proceed to assign staff responsible and the resources provided for various procedures.";
                lblWPReports.Text = "This set of reports together describes"
            + " the staff and other resources assigned to perform various procedures above at various locations and the"
            + " related budget implications";
            
            }
            /*if (Session["WPS"].ToString() == "1")
			{
				if (Session["EPS"].ToString() == "0")
				{
					lblTitle.Text="Work Planning System:  Work Planner's Workbench";
					lblContent2.Text="Work Plans and Budget.";
					
				}
				else
				{
					lblTitle.Text="EcoSys:  Work Planner's Workbench";
				}
			}
			else
			{
				if (Session["EPS"].ToString() == "0")
				{
					lblTitle.Text="Standard Procedures";
					lblContent1.Text="Greetings. Provided below are a set of reports that provide"
						+ " the framework of services and procedures for your organization.";
				}
				else
				{
					lblTitle.Text="Standard Emergency Response Procedures";
					lblContent1.Text="Greetings. Provided below are a set of reports that provide"
						+ " the framework of emergency services and procedures for preparing and responding to"
						+ " various emergency situations.";		
				}
				lblContent2.Visible=false;
				lblWP.Visible=false;
				btnLocServices.Visible=false;
				btnBudGS.Visible=false;
				btnBud.Visible=false;
				lblWP1.Visible=false;
				lblWP2.Visible=false;
			}*/
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
				//setProfile();
				lblOrg.Text="Warning:  System Error - No Profile.  "
					+ " Please Exit and Report the following"
					+ " information to System Administrator:  "
					+ Session["OrgName"].ToString()
					+ "Org Id="+ Session["OrgId"].ToString()+"." ;
			}
			else
			{
				Session["ProfilesId"]=ds.Tables["OrgProfile"].Rows[0][0].ToString();
				Session["ProfilesName"]=ds.Tables["OrgProfile"].Rows[0][1].ToString();
			}
		}
		private void getBRS()
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
		
		private void getWPS()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsWPS";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"WPS");
			if (ds.Tables["WPS"].Rows[0][0].ToString() == "0")
			{
				Session["WPS"]= 0;
			}
			else
			{
				Session["WPS"]= 1;
			}
		}
		private void getEPS()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsEPS";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"EPS");
			if (ds.Tables["EPS"].Rows[0][0].ToString() == "0")
			{
				Session["EPS"]= 0;
			}
			else
			{
				Session["EPS"]= 1;
			}
		}
		private void setProfile()
		{
			Session["CSProfilesAll"]="frmMainWP";
			Session["Type"]="Producer";
			Response.Redirect (strURL + "frmProfilesAll.aspx?");
		}

		protected void btnLocServices_Click(object sender, System.EventArgs e)
		{
			Session["CBudOrgs"]="frmMainWP";
			Response.Redirect (strURL + "frmBudOrgsWP.aspx?");
		}

		protected void btnSP_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptProcsOrg.rpt";
			rpts();	
		}

		protected void btnStfTOR_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptTOR.rpt";
			rpts();	
		}

		protected void btnBIA_Click(object sender, System.EventArgs e)
		{
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Int32.Parse(Session["ProfilesId"].ToString());
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptBIA.rpt";
			rpts();	
		}
		private void rpts()
		{
			Session["cRG"]="frmMainWP";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}

		protected void btnBud_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "startForm";
            discreteval1.Value = Session["startForm"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptWP2.rpt";
			rpts();	
		}

		protected void btnBudGS_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "startForm";
            discreteval1.Value = Session["startForm"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);
            /*if (Session["startForm"].ToString() != "frmMainWP")
            {
                ParameterField paramField2 = new ParameterField();
                ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
                paramField2.ParameterFieldName = "OrgLocId";
                discreteval2.Value = "0";
                paramField2.CurrentValues.Add(discreteval2);
                paramFields.Add(paramField2);
                ParameterField paramField3 = new ParameterField();
                ParameterDiscreteValue discreteval3 = new ParameterDiscreteValue();
                paramField3.ParameterFieldName = "ProjectId";
                discreteval3.Value = "0";
                paramField3.CurrentValues.Add(discreteval3);
                paramFields.Add(paramField3);
                ParameterField paramField4 = new ParameterField();
                ParameterDiscreteValue discreteval4 = new ParameterDiscreteValue();
                paramField4.ParameterFieldName = "BudgetsId";
                discreteval4.Value = "0";
                paramField4.CurrentValues.Add(discreteval4);
                paramFields.Add(paramField4);
            }
            else
            {
                ParameterField paramField5 = new ParameterField();
                ParameterDiscreteValue discreteval5 = new ParameterDiscreteValue();
                paramField5.ParameterFieldName = "BudgetsId";
                discreteval5.Value = Session["BudgetsId"].ToString();
                paramField5.CurrentValues.Add(discreteval5);
                paramFields.Add(paramField5);
            }*/
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptWP1.rpt";
			rpts();
		}

		protected void btnEProcs_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptEventProcs.rpt";
			rpts();
		
		}
        protected void btnTT_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "OrgId";
            discreteval.Value = Session["OrgId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptTTInd.rpt";
            rpts();
        }
        protected void btnHH_Click(object sender, EventArgs e)
        {
            Session["CM"]="1";
            Response.Redirect(strURL + "frmProfilesCon.aspx?");
        }
       
        /*protected void btnWP_Click(object sender, EventArgs e)
        {
            lblContent1.Visible = true;
            lblBMReports.Visible = true;
            btnEProcs.Visible = true;
            btnSP.Visible = true;
            btnStfTOR.Visible = true;
            btnBIA.Visible = true;
            lblContent2.Visible = true;
            btnLocServices.Visible = true;
            lblContent3.Visible = true;
            lblWP1.Visible = true;
            lblWPReports.Visible = true;
            btnBud.Visible = true;
            btnBudGS.Visible = true;
            btnTT.Visible = true;
            lblContent1a.Visible = false;
            btnWP.Visible = false;

        }*/
}
	}

