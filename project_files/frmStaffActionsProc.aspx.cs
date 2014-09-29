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
	public partial class frmStaffActionsProc: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
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
			if (Session["SA"].ToString() =="frmOrgLocMgrs")
			{
				DataGrid1.Columns[5].Visible=false;
				btnCancel.Text="OK";
			}
			else
			{
				DataGrid1.Columns[9].Visible=false;
			}
			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveStaffActionsProc";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffActions");
			if (ds.Tables["StaffActions"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.Text="There are no individuals who are identified"
					+ " as being part of your organization."
					+ " Click on 'Add' to identify such individuals.";
			}
			else
			{
				lblContents1.Text="Listed below are staff or consultant appointments to which"
					+ " you may assign this task by clicking on 'Select'."
					+ " The column 'Appointing Organizations' indicates the organization that is "
					+ " managing the contract or agreement.  'Appointment Type'"
					+ " indicates the type of contract between the individual and the organization.  Note that"
					+ " you may find an individual identified more than once in the list below.  This"
					+ " would indicate that there is more than one contract under which the individual"
					+ " works, and you should thus make sure you are assigning the individual under the "
					+ " right contract.  If the individual you"
					+ " need to add is not in the list below, then that individual needs to be"
					+ " appointed before you can proceed.";

				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (Session["SA"].ToString() == "frmOrgLocMgrs")
			{
				refreshGrid();
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[9].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from OrgLocMgrs"
					+ " Where OrgLocId = " + Session["OrgLocId"].ToString()
					+ " and StaffActionsId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
					cb.Enabled = false;
				}
				cmd.Connection.Close();
			}
		}

		private void Exit()
		{
			Session["btnAction1"] = null;
			Response.Redirect (strURL + Session["SA"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (Session["SA"].ToString() =="frmOrgLocMgrs")
			{
				updateGrid();
			}
			else
			{
				Session["StaffActionProc"] = "Cancel";
			}
			Exit();

		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[9].FindControl("cbxSel"));
				if ((cb.Checked) & (cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_UpdateOrgLocMgrs";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@OrgLocId", SqlDbType.Int);
					cmd.Parameters ["@OrgLocId"].Value=Session["OrgLocId"].ToString();
					cmd.Parameters.Add("@StaffActionsId", SqlDbType.Int);
					cmd.Parameters ["@StaffActionsId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				Session["StaffActionId"] = e.Item.Cells[0].Text;
				Session["TypeIdSA"] = e.Item.Cells[10].Text;
				
				Exit();
			}

			else if (e.CommandName == "Update")
			{
				Session["CSA"]="frmStaffActionsproc";
				Session["btnAction1"]="Update";
				Session["OrgIdSA"]=e.Item.Cells[7].Text;
				Session["Id"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdStaffAction.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="hrs_DeleteStaffAction";
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
	}
}

