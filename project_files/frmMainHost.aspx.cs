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
	public partial class MainHost : System.Web.UI.Page
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
			lblTitle.Text="Access Management System:  License Manager's Workbench";
			lblLic.Text="License Id: " + Session["LicenseId"].ToString();
			Session["OrgNamet"]=Session["OrgName"];
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
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + "frmStart.aspx?");
		}
		private void btnReports_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmReportsAdm.aspx?");
		}
		protected void btnLicenses_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmLicenses.aspx?");
		}
		private void lblDetails_Click(object sender, System.EventArgs e)
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
				Session["CallerUpdOrg"]="frmMainHost";
				Session["btnAction"]="Update";
				Response.Redirect (strURL + "frmUpdOrg.aspx?"
					+ "&Id=" + ds.Tables["Orgs"].Rows[0][0].ToString()
					+ "&Name=" + ds.Tables["Orgs"].Rows[0][1].ToString()				
					+ "&Desc=" + ds.Tables["Orgs"].Rows[0][2].ToString()
					+ "&Phone=" + ds.Tables["Orgs"].Rows[0][3].ToString()
					+ "&Email=" + ds.Tables["Orgs"].Rows[0][4].ToString()
					+ "&Addr=" + ds.Tables["Orgs"].Rows[0][5].ToString()
					+ "&PeopleId=" + ds.Tables["Orgs"].Rows[0][6].ToString()
					+ "&LocId=" + ds.Tables["Orgs"].Rows[0][7].ToString());
		}
		protected void lblNew_Click(object sender, System.EventArgs e)
		{
			Session["CallerOrgs"]="frmMainHost";
			Session["OrgType"]="Team";
			Response.Redirect (strURL + "frmOrgs.aspx?");
		}

		protected void btnMsg_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmUpdMenuMsg.aspx?");
		
		}

		protected void btnControlReport_Click(object sender, System.EventArgs e)
		{
			/*ParameterFields paramFields = new ParameterFields();
			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "OrgId";
			discreteval.Value = Session["OrgId"].ToString();
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			Session["ReportParameters"] = paramFields;*/
			Session["ReportName"] = "rptUserIds.rpt";
			rpts();
		}
		private void rpts()
		{
			Session["cRG"]="frmMainHost";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}

	}
}

