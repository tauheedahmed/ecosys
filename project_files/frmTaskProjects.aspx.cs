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
	public partial class frmTaskProjects: System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{		
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["Orgname"].ToString();
				lblContents1.Text="Location: " + Session["LocationName"].ToString();
				lblContents2.Text="Task: " + Session["TaskName"].ToString();
				loadData();
			}		
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveTaskProjects";		
			cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
			cmd.Parameters["@TaskId"].Value=Session["TaskId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"TaskR");
			if (ds.Tables["TaskR"].Rows.Count == 0)
			{
				addProject();
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void addProject()
		{
			Session["CUpdProject"]="frmTaskProjects";
			Response.Redirect (strURL + "frmUpdProject.aspx?"
				+ "&btnAction=Add");
		}
		private void refreshGrid()
		{
		}
		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{	
				Session["CUpdProject"]="frmTaskProjects";
				Response.Redirect (strURL + "frmUpdProject.aspx?"
					+ "&btnAction=Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Status=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[3].Text);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProject";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			loadData();
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		
		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerTaskProjects"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			addProject();
		}

	}

}

