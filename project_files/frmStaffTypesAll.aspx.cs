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
	public partial class frmStaffTypesAll: System.Web.UI.Page
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
			loadApts();
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
		private void loadApts()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text="Please identify the appointment types"
					+ " for this organization.";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrieveStaffTypesAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"AptTypesAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				Button btDelete = (Button) (i.Cells[3].FindControl("btnDelete"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from OrgStaffTypes"
					+ " Where OrgStaffTypes.OrgId = " + Session["OrgId"].ToString()
					+ " and StaffTypesId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
					cb.Enabled = false;
				}
				cmd.CommandText="Select Id from OrgStaffTypes"
					+ " Where StaffTypesId = " + i.Cells[0].Text;
				if (cmd.ExecuteScalar() != null) 
				{
					btDelete.Enabled=false;
					btDelete.Text="In Use";
				}
				cmd.CommandText="Select OrgId from StaffTypes"
					+ " Where Id = " + i.Cells[0].Text;
				if (cmd.ExecuteScalar() != null)
				{
					if (cmd.ExecuteScalar().ToString() != Session["OrgId"].ToString())
					{
						btDelete.Visible=false;
						i.Cells[3].Text="Externally Created";
					}
				}
				cmd.Connection.Close();
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
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					if ((cb.Checked) & (cb.Enabled))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="hrs_UpdateOrgStaffTypes";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@OrgId", SqlDbType.Int);
						cmd.Parameters ["@OrgId"].Value=Session["OrgId"].ToString();
						cmd.Parameters.Add("@StaffTypesId", SqlDbType.Int);
						cmd.Parameters ["@StaffTypesId"].Value=i.Cells[0].Text;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CStaffTypesAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdStaffType"]="frmStaffTypesAll";
			Response.Redirect (strURL + "frmUpdStaffType.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdStaffType"]="frmStaffTypesAll";
				Response.Redirect (strURL + "frmUpdStaffType.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Vis=" + e.Item.Cells[4].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_DeleteStaffType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
	}

}

