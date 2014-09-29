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
	public partial class frmStaffActionsInd : System.Web.UI.Page
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
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrieveSCs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SAs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (ds.Tables["SAs"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="You have not been appointed to any position in this organization."
					+ " Please contact your supervisor.";								
			}
			else if (ds.Tables["SAs"].Rows.Count == 1) 
			{
				if ((ds.Tables["SAs"].Rows[0][3].ToString()) == "Appointed")
				{
					Session["StaffActionsId"]=ds.Tables["SAs"].Rows[0][0].ToString();
					Session["StaffType"]=ds.Tables["SAs"].Rows[0][1].ToString();
					Session["CAP"]=Session["frmStaffActionsInd"];
					redirectTimesheets();
				}
			}
			else
			{
				refreshGrid();
			}
		}
		private void refreshGrid()
		{			
			int I = 0;
			int J = 0;
			int K = 0;
			int L = 0;
			foreach (DataGridItem i in DataGrid1.Items)
			{
				L = ++L;
				Button bt = (Button)(i.Cells[4].FindControl("btnTimesheets"));
				if (i.Cells[3].Text.Trim() == "Active")
				{
					bt.Enabled=true;
					I = ++I;
				}
				else if (i.Cells[3].Text.Trim() == "Closed")
				{
					bt.Enabled=true;
					J = ++J;
				}
				
				else
				{
					bt.Enabled=false;
					K = ++K;
				}
			}
			if (L == 1)
			{
				if (J == 1)
					lblContents.Text="Warning:  This Staff Action has now been closed.";						
			}
			else

			{
				if (K == 0)
					{
						lblContents.Text="You have more than one Staff Action with this"
							+ " organizations, as shown below.  Click on 'Timesheets'"
							+ " to submit timesheets for each Staff Action as appropriate.";
					}
				else
				{
					lblContents.Text="You have more than one Staff Action with this"
						+ " organizations, as shown below.  Click on 'Timesheets'"
						+ " to submit timesheets for each Staff Action as appropriate."
						+ " Note that there are some Staff Actions below where you"
						+ " cannot enter timesheets until the current status"
						+ " of the Staff Action is changed by your organization.";
				}
			}
		}
		
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Timesheets")
			{

                Session["StaffActionsId"]=e.Item.Cells[0].Text;
				Session["AptOrgName"]=e.Item.Cells[1].Text;
				Session["AptOrgId"]=e.Item.Cells[5].Text;
				Session["StaffType"]=e.Item.Cells[2].Text;
                redirectTimesheets();
			}
		}
		private void redirectTimesheets()
		{
			/*Session["CAP"]="frmStaffActionsInd";
			Response.Redirect (strURL + "frmActperiods.aspx?");*/
                Session["CTS"] = "frmStaffActionsInd";
                Response.Redirect(strURL + "frmTS.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CSAI"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CTPAll"]="frmStaffTasks";
			Response.Redirect (strURL + "frmTaskProjectsAll.aspx?");
		}


	}
}
