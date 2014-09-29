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
	public partial class frmOrgFlags : System.Web.UI.Page
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

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				//lblOrg.Text=Session["OrgNameC"].ToString();
				lblContents1.Text="License No: " + Session["ClientLicenseId"].ToString();
				lblContents2.Text=Session["OrgNameC"].ToString();
				lblContents3.Text="Profile: " + Session["ProfileNameC"].ToString();
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveFlagTypes";
			cmd.Parameters.Add("@Type", SqlDbType.Int);
			cmd.Parameters ["@Type"].Value=1;//1 = Organization FlagType
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServProviders");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void updateGrid()
		{
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Delete from OrgFlags"
					+ " Where OrgId= " 
					+ Session["OrgIdC"].ToString();
				cmd.Connection=this.epsDbConn;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="ams_UpdateOrgFlags";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@OrgIdC", SqlDbType.Int);
					cmd.Parameters ["@OrgIdC"].Value=Session["OrgIdC"].ToString();
					cmd.Parameters.Add("@FlagTypesId", SqlDbType.Int);
					cmd.Parameters ["@FlagTypesId"].Value=i.Cells[0].Text;
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
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from OrgFlags"
					+ " Where OrgId = " + Session["OrgIdC"].ToString()
					+ " and FlagTypesId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
				}
				cmd.Connection.Close();
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CF"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}

}