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
	public partial class frmTSApprove : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblPerson;
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

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();	
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
					+ Session["CurrName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				if (Session["PAY"].ToString() == "0")
				{
					DataGrid1.Columns[5].Visible=false;
				}
				if (Session["CBudOrgs"].ToString() == "frmTasks")
				{
					lblDel.Text="Deliverable: " + Session["EventName"].ToString();
					lblTask.Text=Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Task: " + Session["ProcName"].ToString() + ")";
				}
				else if (Session["CBudOrgs"].ToString() == "frmMainWP")
				{
					lblDel.Text="Task: " + Session["ProcName"].ToString();
				}
				lblRole.Text="Time charged by: " + Session["PeopleName"].ToString()
				+ " (Role: " + Session["PSEPSName"].ToString() + ")";
				lblContents.Text="Please click on 'Select' to approve time charged";
				loadData();
			}
		}
		
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveTSApprove";
				cmd.Connection=this.epsDbConn;				
				cmd.Parameters.Add ("@ProcProcuresId",SqlDbType.Int);
				cmd.Parameters["@ProcProcuresId"].Value=Session["ProcProcuresId"].ToString();
			DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"updTS");
				Session["ds"] = ds;
			if (ds.Tables["updTS"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="No Timesheets submitted.";
			}
			else
			{
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				assignValues();
			}

		}
		private void assignValues()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));
				if (i.Cells[5].Text == "1")
				{
					cb.Checked=true;
				}
				else
				{
					cb.Checked=false;
				}
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateTSA";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add("@Id", SqlDbType.Int);
				cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text);
				cmd.Parameters.Add("@Status", SqlDbType.Int);
				if (cb.Checked)
				{
					
					cmd.Parameters ["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters ["@Status"].Value=2;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CTSA"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}
}
