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
	public partial class frmOrgLocMgrs: System.Web.UI.Page
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
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblContents1.Text="Given below is a list of managers appointed by your organization"
					+ " for the location named '" 
					+ Session["LocationName"].ToString()
					+ "'.  Click on the 'Add' button to add to this list."
					+ " Click on the 'Remove' button to remove any individual from this list.";
				loadData();
			}
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
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveOrgLocMgrs";
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"LocServices");
			if (ds.Tables["LocServices"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CMgr"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "wms_DeleteOrgLocMgrs";
				cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
				cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
				cmd.Parameters.Add ("@StaffActionsId",SqlDbType.Int);
				cmd.Parameters["@StaffActionsId"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
	protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			addMgrs();		
		}
	private void addMgrs()
	{
		Session["SA"]="frmOrgLocMgrs";
		Response.Redirect (strURL + "frmStaffActionsProc.aspx?");
	}
	}

}

