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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmStaffProjects: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		//private int I;
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
				lblContents1.Text="Project Assignments for: "
					+ Session["FName"].ToString()
					+ " "
					+ Session["LName"].ToString();
				loadData();	
			}
		}
		
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveStaffTasks";		
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"RoleStaff");
			if (ds.Tables["RoleStaff"].Rows.Count == 0)
			{
				lblContents2.Text="There are no projects to which you are currently assigned.  Click on 'Add' to add staff.";
			}
			else 
			{
				lblContents2.Text="Given below is a list of time-sensitive tasks"
					+ " to which you are asssigned."
					+ " Please check the appropriate box after"
					+ " each task to indicate"
					+ " if you have started and/or completed your assignment"
					+ " on that task";

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
				CheckBox cbs = (CheckBox)(i.Cells[8].FindControl("cbxStart"));
				CheckBox cbe = (CheckBox)(i.Cells[9].FindControl("cbxEnd"));

				if (i.Cells[6].Text == "1")
				{
					cbs.Checked=true;
				}
				else
				{
					cbs.Checked=false;
				}
				if (i.Cells[7].Text == "1")
				{
					cbe.Checked=true;
				}
				else
				{
					cbe.Checked=false;
				}
				if (i.Cells[5].Text == "1")
				{
					i.Cells[4].Text = i.Cells[10].Text + " (Backup)";
				}
				else
				{
					i.Cells[4].Text = i.Cells[10].Text;
				}
			}
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cbs = (CheckBox)(i.Cells[8].FindControl("cbxStart"));
				CheckBox cbe = (CheckBox)(i.Cells[9].FindControl("cbxEnd"));				
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;					
				if (cbs.Checked)
				{
					cmd.CommandText="Update OLPPPeople"
						+ " Set StartStatus=1" 
						+ " Where Id = " + i.Cells[0].Text;
				}
				else
				{
					cmd.CommandText="Update OLPPPeople"
						+ " Set StartStatus=0" 
						+ " Where Id = " + i.Cells[0].Text;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				if (cbe.Checked)
				{
					cmd.CommandText="Update OLPPPeople"
						+ " Set EndStatus=1" 
						+ " Where Id = " + i.Cells[0].Text;
				}
				else
				{
					cmd.CommandText="Update OLPPPeople"
						+ " Set EndStatus=0" 
						+ " Where Id = " + i.Cells[0].Text;
				}
				
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CSP"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

	}

}

