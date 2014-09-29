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
	public class junkfrmTasks : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblOrg;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnExit;
		protected System.Web.UI.WebControls.Button btnAddTemp;
		protected System.Web.UI.WebControls.Label lblContents1;
		protected System.Web.UI.WebControls.Label lblContents2;
		protected System.Web.UI.WebControls.Label lblPerson;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblPerson.Text=
					Session["FName"].ToString() + " " + Session["LName"].ToString();
				lblContents1.Text="";
				lblContents2.Text="";
				//string HT=Session["TaskType"].ToString();
				//DataGrid1.Columns[1].HeaderText=HT.ToString().Trim() + " Tasks";
				loadData();
			}
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
			this.btnAddTemp.Click += new System.EventHandler(this.btnAddTemp_Click);
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTasks";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProjectTypesId",SqlDbType.Int);
			cmd.Parameters["@ProjectTypesId"].Value=Int32.Parse(Session["ProjectTypesId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Tasks");
			if (ds.Tables["Tasks"].Rows.Count == 0)
			{
				lblContents1.Text="Sorry, tasks could not be created.  Contact the system administrator.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			gridRefresh();
		}
		private void gridRefresh()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bt = (Button)(i.Cells[6].FindControl("btnProjects"));
				if (i.Cells[4].Text == "1")
				{
					bt.Text="";
					bt.Enabled=false;
				}
				else
				{
					bt.Text=i.Cells[5].Text;
				}
			}
		}
		/*private void addTasks()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateTasksfromProfiles";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ServiceTypesId",SqlDbType.Int);
			cmd.Parameters["@ServiceTypesId"].Value=Session["ServiceTypesId"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			cmd.Parameters.Add ("@EventsId",SqlDbType.Int);
			cmd.Parameters["@EventsId"].Value=Session["EventsId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}*/
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CallerUpdTask"]="frmTasks";
				Response.Redirect (strURL + "frmUpdTask.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Status=" + e.Item.Cells[2].Text);
			}
			else if (e.CommandName == "Timetable")
			{
				Session["CallerTaskSteps"]="frmTasks";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Session["StepType"]="na";
				Response.Redirect (strURL + "frmTaskSteps.aspx?");

			}
			else if (e.CommandName == "Register")
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateTaskPeople";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@PeopleId", SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
				cmd.Parameters.Add ("@TaskId", SqlDbType.Int);
				cmd.Parameters["@TaskId"].Value=e.Item.Cells[0].Text;
				cmd.Parameters.Add ("@Type", SqlDbType.NVarChar);
				if (Session["startForm"].ToString() == "frmMainStaff")
				{
					cmd.Parameters["@Type"].Value="Client";
				}
				else
				{
					cmd.Parameters["@Type"].Value="Staff";
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				if (Session["startForm"].ToString() == "frmMainOrgs")
				{
					Response.Redirect (strURL + Session["CallerServices"].ToString() + ".aspx?");
				}
				else if ((Session["startForm"].ToString() == "frmMainStaff")
					|| (Session["startForm"].ToString() == "frmMainTrg"))
				{
					Response.Redirect (strURL + Session["CallerTasks"].ToString() + ".aspx?");
				}

				}
				else if (e.CommandName == "Clients")
			{
				Session["CallerTaskStaffing"]="frmTasks";
				Session["StaffingType"]="Clients";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmTaskStaffing.aspx?");

			}
			else if (e.CommandName == "Staff")
			{
				Session["CallerTaskStaffing"]="frmTasks";
				Session["StaffingType"]="Staff";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmTaskStaffing.aspx?");

			}
			else if (e.CommandName == "Goods")
			{
				Session["CallerTaskResources"]="frmTasks";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmTaskResources.aspx?");
			}
			else if (e.CommandName == "Services")
			{
				Session["CallerTaskServices"]="frmTasks";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmTaskServices.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteTask";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Projects")
			{
				Session["CallerTaskProjects"]="frmTasks";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmTaskProjects.aspx?");
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CallerUpdTask"]="frmTasks";	
			Response.Redirect (strURL + "frmUpdTask.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CT"].ToString() + ".aspx?");
		}

		private void btnAddTemp_Click(object sender, System.EventArgs e)
		{

		}
	}

}
	