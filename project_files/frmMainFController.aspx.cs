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
	public partial class MainFController : System.Web.UI.Page
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
            lblTitle.Text="EcoSys: Financial Controls";	
			lblContent1.Text="Greetings.  This menu enables you to maintain the financial accounts"
				+ " of your organization.";
			
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
			Session["CSProfilesAll"]="frmMainEPS";
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
		
		
		private void rpts()
		{
			Session["cRG"]="frmMainEPS";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}
		protected void btnFiscalYears_Click(object sender, System.EventArgs e)
		{
			Session["COrgLocs"]="frmMainEPS";
			Response.Redirect (strURL + "frmFiscalYears.aspx?");
		}
		
		
		
		protected void btnProcurements_Click(object sender, System.EventArgs e)
		{
			Session["CContracts"]="frmMainFController";
			Session["Mode"]="Write";
			Response.Redirect (strURL + "frmContracts.aspx?");
		
		}

		protected void bnInventory_Click(object sender, System.EventArgs e)
		{
			Session["CInv"]="frmMainFController";
			Session["Mode"]="Write";
			Response.Redirect (strURL + "frmInventory.aspx?");
		}

		
		protected void btnFunds_Click(object sender, System.EventArgs e)
		{
			Session["ActLedgersId"]=1;
			//Session["ActhartsId"]=1;
			Session["CFunds"]="frmMainFController";
			Response.Redirect (strURL + "frmFunds.aspx?");
		}
    }
}

