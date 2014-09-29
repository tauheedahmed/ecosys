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
	public partial class MainPersReps : System.Web.UI.Page
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
			lblOrg.Text=Session["OrgName"].ToString();
		}
		private void btnSupplies_Click (object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "ProfileOrg.rpt";
			rpts();
			}

		private void btnReports_Click(object sender, System.EventArgs e)
		{
		Response.Redirect (strURL + "frmReports.aspx?");
		}

		private void rpts()
		{
			Session["Caller2"]="frmReportsPers";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}
		protected void btnPhoneTree_Click(object sender, System.EventArgs e)
		{
			
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "LicenseId";
			discreteval.Value = Session["LicenseId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptPhoneTree.rpt";
			rpts();
		}

		protected void btnEmergencyTeams_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "EmergencyGroups.rpt";
			rpts();
		}


		protected void btnEmergencyProcedures_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			ParameterField paramField2 = new ParameterField();
			ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
			paramField2.ParameterFieldName = "Test";
			discreteval2.Value = Session["Caller1"];
			paramField2.CurrentValues.Add (discreteval2);
			paramFields.Add (paramField2);

			Session["ReportParameters"] = paramFields;

			Session["ReportName"] = "EmergencyProcedures.rpt";
			rpts();

		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "Caller1" + ".aspx?");
		}

		protected void btnEmergencyResources_Click(object sender, System.EventArgs e)
		{
				ParameterFields paramFields = new ParameterFields();
				ParameterField paramField = new ParameterField();
				ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
				paramField.ParameterFieldName = "OrgId";
				discreteval.Value = Session["OrgId"];
				paramField.CurrentValues.Add (discreteval);
				paramFields.Add (paramField);

				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptEmergencyResources.rpt";
				rpts();
			}

		protected void btnEmergencyGroups_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "EmergencyTeams.rpt";
			rpts();
		}

		private void btnOwnResources_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptOwnResources.rpt";
			rpts();
		}

		protected void btnProcedureSteps_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptProcedureSteps.rpt";
			rpts();
		}

		protected void btnAssess_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "LicenseId";
			discreteval.Value = Session["LicenseId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptAssessOrgs.rpt";
			rpts();
		}

		protected void btnServInputs_Click(object sender, System.EventArgs e)
			{
				ParameterFields paramFields = new ParameterFields();
				ParameterField paramField = new ParameterField();
				ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
				paramField.ParameterFieldName = "LicenseId";
				discreteval.Value = Session["LicenseId"];
				paramField.CurrentValues.Add (discreteval);
				paramFields.Add (paramField);

				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptServInputs.rpt";
				rpts();
			}

		protected void btnRisks_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptRisk.rpt";
			rpts();
		}

		protected void btnPrep_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"];
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptPreparationList.rpt";
			rpts();
		
		}

		}
	}

