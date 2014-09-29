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

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmProcClient : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProcClient";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();		
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcClient");
			if (ds.Tables["ProcClient"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.ForeColor=System.Drawing.Color.Maroon;
				lblContents1.Text="Note:  There are no types of clients identified for this process, i.e. '"
					+ Session["ProcName"].ToString()
					+ "'. Please contact your system administrator if you need to be able to identify clients for this process.";
			}
			else
			{
				lblContents1.Text="Listed below are the types of clients served through this process, i.e, '"
				+ Session["ProcName"].ToString() 
					+ "'.  The button to the right indicates whether a given type of clients consist of individual people"
					+ " or of organizations of some kind.  Click on this button to the right"
					+ " to add clients for this process.";

				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bt = (Button) (i.Cells[3].FindControl("btnClient"));
				if (i.Cells[4].Text == "1")
				{
					bt.Text="Organizations";
					bt.CommandName = "Orgs";
				}
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPClient"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["PSEPCID"]=e.Item.Cells[0].Text;
			if (e.CommandName == "People")
			{
				if (Session["CPClient"].ToString() == "frmOrgLocSEProcs")
				{
					Session["COLPSEPCP"]="frmProcClient";
					Response.Redirect (strURL + "frmOLPSEPCPeople.aspx?");
				}
				else if (Session["CPClient"].ToString() == "frmOLPProjects")
				{
					Session["CPCP"]="frmProcClient";
					Response.Redirect (strURL + "frmProjCPeople.aspx?");
				}
			}
			else if (e.CommandName == "Orgs")
			{
				if (Session["CPClient"].ToString() == "frmOrgLocSEProcs")
				{
					Session["COLPSEPCO"]="frmProcClient";
					Response.Redirect (strURL + "frmOLPSEPCOrgs.aspx?");
				}
				else if (Session["CPClient"].ToString() == "frmOLPProjects")
				{
					Session["CPCO"]="frmProcClient";
					Response.Redirect (strURL + "frmProjCOrgs.aspx?");
				}
			}
		}
	}

}