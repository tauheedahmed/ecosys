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
	public partial class frmStaffProcsAll: System.Web.UI.Page
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
			loadEvents();
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
		private void loadEvents()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text="Below is a list of tasks within your organizational unit"
					+ " and/or in other units to which you have indicated this Staff Action"
					+ " should also be visible, to which no staff have been assigned.";
				//loadContents1();
				loadData();
			}
		}
		/*private void loadContents1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveMain";
			cmd.Parameters.Add("@OrgId",SqlDbType.NVarChar);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Dom");
			lblContents1.Text="Domain: " + ds.Tables["Dom"].Rows[0][0].ToString();
		}*/
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveProcSARAll";
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
			da.Fill(ds,"PPsAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			//refreshGrid();
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
					CheckBox cb = (CheckBox)(i.Cells[7].FindControl("cbxSel"));
					if ((cb.Checked) & (cb.Enabled))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="fms_UpdateProcSARAll";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@ContractId", SqlDbType.Int);
						cmd.Parameters ["@ContractId"].Value=Session["StaffActionsId"].ToString();
						cmd.Parameters.Add("@Id", SqlDbType.Int);
						cmd.Parameters ["@Id"].Value=i.Cells[0].Text;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		/*private void refreshGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[7].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					cmd.CommandText="Select Id from ProcProcures"
						+ " Where ContractId is null"
						+ " and Id = " + i.Cells[0].Text;
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked = true;
						cb.Enabled = false;
					}
	
				}
		}*/
		private void Exit()
		{
			Response.Redirect (strURL + Session["CSPAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CSPAll"].ToString() + ".aspx?");
		}
	}

}

