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
	/// Summary description for frmProceduresProcedures.
	/// </summary>
	public partial class frmServices : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Plans();
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
		private void Load_Plans()
		{
			if (!IsPostBack) 
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveOrgServices";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Services");
			if (ds.Tables["Services"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.Text="There are no Services identified for this organization."
						+ " Please contact System Administrator for help.";
			}
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select ServicesId from ProfileServiceTypes"
						+ " Where ProfilesId=" +  Session["ProfilesId"].ToString();
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
					cb.Enabled= false;
					lblContents1.Text="Note:  1.  Services with shaded checkmarks have already been identified"
						+ " for this location.  Therefore they will not be added again."
						+ " 2.  Services below are as identified in Step 2 above for organizations in this industry.";
				}
				cmd.Connection.Close();
			}
		}
		private void updateDataGrid()
		{
			update();
		}
		private void update()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				if ((cb.Checked) & (cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_AddOrgLocServices";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@OrgLocationsId", SqlDbType.Int);
					cmd.Parameters ["@OrgLocationsId"].Value=Session["OrgLocationsId"].ToString();
					cmd.Parameters.Add("@ServicesId", SqlDbType.Int);
					cmd.Parameters ["@ServicesId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (btnExit.Text=="OK")
			{
				updateDataGrid();
			}
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CorgServices"].ToString() + ".aspx?");
		}

	}

}
	