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
	public class junkfrmTimetables : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblContents;
		protected System.Web.UI.WebControls.Label lblOrg;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button btnExit;
		protected System.Web.UI.WebControls.Label lblPerson;
		protected System.Web.UI.WebControls.Label lblFY;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		private void Page_Load(object sender, System.EventArgs e)
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblPerson.Text=
					Session["FName"].ToString() + " " + Session["LName"].ToString();
				//setFY();
				lblContents.Text="Please select the task for this"
					+ " project for which you wish to update the timetable. ";
				loadData();
			}
		}
	
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTimetables";
			cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Timetables");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void itemCommand (object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			if (e.CommandName == "Update")
			{
				
			}
		}
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CTTS"].ToString() + ".aspx?");
		}
	}
}
