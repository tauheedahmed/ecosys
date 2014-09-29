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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmBORevisions : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Procedures();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				lblMgr1.Text="Budget Manager: " + Session["BDOrgName"].ToString();
				lblBudget.Text="Budget: " + Session["BudName"].ToString();
				lblContents.Text="Listed below are the various increments"
					+ " to this budget resulting from past budget transfers."
					+ " Click on 'Add' to provide additional amounts.  Click"
					+ " on 'Update' to update the description of existing items"
					+ " on the list below.";
				lblBud.Text="Current Budget: " + Session["CurrBAmt"].ToString();
				lblReq.Text="Budget Requested: " + Session["ReqBAmt"].ToString();
				loadData();
			}
		}

		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveBORevisions";
			cmd.Parameters.Add("@BDOId",SqlDbType.Int);
			cmd.Parameters["@BDOId"].Value=Session["BDOId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BO");
			if (ds.Tables["BO"].Rows.Count == 0)
			{	
				DataGrid1.Visible=false;
				lblContents.Text="There is no audit trail for revisions to the budget for this"
					+ " organization. Press 'OK' to continue.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUBOR"] = "frmBORevisions";
				Response.Redirect (strURL + "frmUpdBOJournals.aspx?"
					+ "&btnAction=" + "Update"
					+ "&BOJournalsId=" + e.Item.Cells[5].Text
					+ "&UDate=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text);
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CBORevs"].ToString() + ".aspx?");
		}
	}

}
	