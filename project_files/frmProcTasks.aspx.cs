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
	public partial class frmProcTasks : System.Web.UI.Page
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
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.deleteRow);

		}
		#endregion
		private void Load_Procedures()
		{	
			//if (Convert.IsDBNull(Session["OrgNamet"]) == false)
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgNamet"].ToString();			
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProcTasks";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value=Session["CallerTasks"].ToString();
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Tasks");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		private void deleteRow(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteTask";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CallerUpdTask"]="frmTasks";
				Response.Redirect (strURL + "frmUpdTask.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Status=" + e.Item.Cells[3].Text
					+ "&StartTime=" + e.Item.Cells[4].Text
					+ "&EndTime=" + e.Item.Cells[5].Text
					+ "&LocId=" + e.Item.Cells[9].Text
					+ "&ProcId=" + e.Item.Cells[13].Text);
			}
			else if (e.CommandName == "Plan")
			{
				Session["CallerTaskSteps"]="frmTasks";
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["ServiceName"]=e.Item.Cells[7].Text;
				Session["TaskId"]=e.Item.Cells[0].Text;
				Session["LocId"]=e.Item.Cells[9].Text;
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
				Session["CallerTaskPeople"]="frmTasks";
				Session["ServiceName"]=e.Item.Cells[7].Text;
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["Type"]="Client";
				Session["TaskId"]=e.Item.Cells[0].Text;
				//["ParentRoleId"]=12;//12=Roles.ParentId for Students

				Response.Redirect (strURL + "frmTaskPeople.aspx?"
					+ "&LocName=" + e.Item.Cells[6].Text
					+ "&StartTime=" + e.Item.Cells[4].Text);

			}
			else if (e.CommandName == "Staff")
			{
				Session["CallerTaskPeople"]="frmTasks";
				Session["ServiceName"]=e.Item.Cells[7].Text;
				Session["TaskName"]=e.Item.Cells[1].Text;
				Session["Type"]="Staff";
				Session["TaskId"]=e.Item.Cells[0].Text;
				//["ParentRoleId"]=12;//12=Roles.ParentId for Students
				Response.Redirect (strURL + "frmTaskPeople.aspx?"
					+ "&LocName=" + e.Item.Cells[6].Text
					+ "&StartTime=" + e.Item.Cells[4].Text);

			}
			else if (e.CommandName == "Details")
				{
					Session["CallerTaskDetail"]="frmTasks";
					Response.Redirect (strURL + "frmTaskDetail.aspx?"
						//+ "&ServiceName=" + e.Item.Cells[1].Text
						//+ "&Start=" + e.Item.Cells[2].Text
						//+ "&End=" + e.Item.Cells[3].Text
						//+ "&RegStatus=" + e.Item.Cells[4].Text
						+ "&Desc=" + e.Item.Cells[2].Text
						//+ "&StaffClient=" + e.Item.Cells[8].Text
						//+ "&TaskName=" +  e.Item.Cells[10].Text
						//+ "&EventName=" +  e.Item.Cells[11].Text
						//+ "&LicOrg=" +  e.Item.Cells[12].Text
						//+ "&MgrOrg=" +  e.Item.Cells[13].Text
						//+ "&LicId=" +  e.Item.Cells[14].Text					
						//+ "&Status=" + e.Item.Cells[15].Text	//				
						//+ "&Loc=" + e.Item.Cells[16].Text
						//+ "&LocAddress=" +  e.Item.Cells[17].Text
						//+ "&Comment=" +  e.Item.Cells[18].Text
						);
				}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CallerUpdTask"]="frmTasks";	
			Response.Redirect (strURL + "frmUpdTask.aspx?"
				+ "&btnAction=" + "Add");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerProcTasks"].ToString() + ".aspx?");
		}

	}

}
	