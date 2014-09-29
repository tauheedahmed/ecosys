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
	public partial class frmProjCOrgs: System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents1.Text="Location: " + Session["LocationName"].ToString();
				lblContents2.Text="Click on 'Add' to register new Clients for the process '"
					+ " project '"
					+ Session["ProjName"].ToString()
					+ "', process named "
					+ Session["ProcName"].ToString()
					+ "'";
				loadData();	
			}
		}
		
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjCOrgs";		
			cmd.Parameters.Add ("@PSEPCID",SqlDbType.Int);
			cmd.Parameters["@PSEPCID"].Value=Session["PSEPCID"].ToString();
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"RoleStaff");
			if (ds.Tables["RoleStaff"].Rows.Count == 0)
			{
				lblContents2.Text="There are no clients of this kind.  Click on 'Add' to add clients.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void addClient()
		{
			Session["CContracts"]="frmProjCOrgs";
			Response.Redirect (strURL + "frmContractsC.aspx?");
		}
		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_DeleteProjCOrgs";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id", SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			loadData();
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			//updateGrid();
			Exit();
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CPCO"].ToString() + ".aspx?");
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			addClient();
		}
	}

}

