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
	public partial class frmTaskSteps : System.Web.UI.Page
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
			Load_Form();
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
		private void Load_Form()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents1.Text="Task: " + Session["TaskName"].ToString();
			lblContents2.Text="Task Plan";
			
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTaskSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
			cmd.Parameters["@TaskId"].Value=Session["TaskId"].ToString();
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="Task";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServSteps");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (Session["CallerTaskSteps"].ToString() != "frmTasks")
			{
				refreshGrid();
			}
		}
		private void processCommand (object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteTaskSteps";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Update")
			{
				Session["CallerUpdStep"] = "frmTaskSteps";
				Session["StepDesc"] = e.Item.Cells[3].Text;
				Response.Redirect (strURL + "frmUpdStep.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[6].Text
					+ "&Name=" + e.Item.Cells[2].Text
					+ "&Desc=" + e.Item.Cells[7].Text
					+ "&Vis=" + e.Item.Cells[8].Text);
			}
			else if (e.CommandName == "Resources")
			{
				Session["StepId"]=e.Item.Cells[6].Text;
				Session["StepName"]=e.Item.Cells[2].Text;
				Session["CallerStepResourceTypes"]="frmTaskSteps";
				Response.Redirect (strURL + "frmStepResourceTypes.aspx?");
			}
			else if (e.CommandName == "Roles")
			{
				Session["StepId"]=e.Item.Cells[6].Text;
				Session["StepName"]=e.Item.Cells[2].Text;
				Session["CallerStepRoles"]="frmTaskSteps";
				Session["RoleType"]="Role";
				Response.Redirect (strURL + "frmStepRoles.aspx?");
			}
        }
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (Session["CallerTaskSteps"].ToString() == "frmServices")
			{
				Response.Redirect (strURL + Session["CallerTaskSteps"].ToString() + ".aspx?");
			}
			else 
			{
				updateGrid();
				Response.Redirect (strURL + Session["CallerTaskSteps"].ToString() + ".aspx?");
			}
		}
		private void updateGrid()
		{   
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[5].FindControl("cbxSel"));
				
				{
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					if (cb.Checked == true)
					{
						cmd.CommandText="Update TaskSteps"
							+ " Set Status='Actual'"
							+ " Where Id = " + i.Cells[0].Text;
					}
					else
					{
						cmd.CommandText="Update TaskSteps"
							+ " Set Status='Plan'"
							+ " Where Id = " + i.Cells[0].Text;
					}
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
			
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[5].FindControl("cbxSel"));
				cb.Visible=true;
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Status from TaskSteps"
					+ " Where Id = " + i.Cells[0].Text
					+ " and Status = 'Actual'";
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}
		}

		/*private void btnNewStep_Click(object sender, System.EventArgs e)
		{
			Session["CallerUpdStep"]="frmTaskSteps";
			Response.Redirect (strURL + "frmUpdStep.aspx?"
				+ "&btnAction=" + "Add");
		}*/
		protected void btnExisting_Click(object sender, System.EventArgs e)
		{
			Session["CallerTSNum"]="frmTaskSteps";
			Response.Redirect (strURL + "frmTaskStepsNum.aspx?");
		}

		protected void btnPlan_Click(object sender, System.EventArgs e)
		{
			Session["CEventsAll"]="frmTaskSteps";
			Response.Redirect (strURL + "frmEventsAll.aspx?");
		}
	}

}
	