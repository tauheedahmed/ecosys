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
	/// Summary description for frmOrgResTypes1.
	/// </summary>
	public partial class frmSCLocs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadForm();
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
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblPerson.Text=
					Session["FName"].ToString() + " " + Session["LName"].ToString();
				lblContents.Text="The list below shows the location(s) to which you"
					+ " are currently assigned to perform tasks as "
					+ Session["StaffType"].ToString()
					+ ". To report time spent performing a specific task (i.e. a task whose progress "
					+ " is reported using a timetable), click on 'Task-Related'."
					+ " To report time at the more general level of an  on-going process (i.e. where progress "
					+ " is not reported using a timetable), click on 'Process-Related'.";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveSCLocs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@StaffActionsId",SqlDbType.Int);
			cmd.Parameters["@StaffActionsId"].Value=Session["StaffActionsId"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SAs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			/*if (ds.Tables["SAs"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="There are no tasks in your work program."
					+ " Please contact your System Administrator.";								
			}
			else if (ds.Tables["SAs"].Rows.Count == 2)
			{
				Session["SALocsId"]=ds.Tables["STasks"].Rows[0][0].ToString();
				Session["CTS"]="frmTimePeriods";
				redirectTimesheets();								
			}*/
		}
	
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Process")
			{
				Session["LocId"]=e.Item.Cells[0].Text;
				Session["CTSProcess"]="frmSCLocs";
				Response.Redirect(strURL + "frmTSProcess.aspx?");
			}
			else if (e.CommandName == "Task")
			{
				Session["LocId"]=e.Item.Cells[0].Text;
				Session["CTSProject"]="frmSCLocs";
				Response.Redirect(strURL + "frmTSProject.aspx?");
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CSCLocs"].ToString() + ".aspx?");
		}


	}
}
