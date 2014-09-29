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
	public partial class frmBudSer : System.Web.UI.Page
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
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text=Session["LocationName"].ToString() 
					+ ": " 
					+ Session["GS"].ToString()
					+ " Budget";
				lblBudName.Text=Session["BOrgName"].ToString()
					+ ": " + Session["BudName"].ToString()
					+ " (Budget Currency: " + Session["Curr"].ToString() +  ")";
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			if (Session["SGFlag"].ToString() == "0")
			{
				cmd.CommandText="fms_RetrieveBudSer";
			}
			else if (Session["SGFlag"].ToString() == "1")
			{
				cmd.CommandText="fms_RetrieveBudRes";
			}
			else
			{
				cmd.CommandText="fms_RetrieveBudStaff";
			}
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add("@BOId",SqlDbType.Int);
			cmd.Parameters["@BOId"].Value=Session["BOId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BudSr");
			if (ds.Tables["BudSr"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="No budget requests have been prepared as yet.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "WorkSheet")
			{
				Session["CBudSerWS"]="frmBudSer";
				Session["SerId"]=e.Item.Cells[0].Text;
				Session["SerName"]=e.Item.Cells[1].Text;
				if (e.Item.Cells[4].Text.StartsWith("&") == false)
				{
					Session["Price"]=e.Item.Cells[4].Text;
				}
				else
				{
					Session["Price"]="0";
				}
				Response.Redirect (strURL + "frmBudSerWorkSheet.aspx?");
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CBudSer"].ToString() + ".aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}

}
	