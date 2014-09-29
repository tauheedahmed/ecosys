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
	/// Summary description for frmBackupsInfo.
	/// </summary>
	public partial class frmBackupsInfo : System.Web.UI.Page
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
			Load_Backups();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Backups()
		{
			if (!IsPostBack)
			{
				loadPlans();
			}
		}
		private void loadPlans()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveBackups";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId", SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Backups");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
	
			if (e.CommandName == "Update")
			{
				Response.Redirect (strURL + "frmUpdBackups.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Resource=" + e.Item.Cells[1].Text
					+ "&Backup=" + e.Item.Cells[3].Text
					+ "&Timing=" + e.Item.Cells[5].Text
					+ "&Retention=" + e.Item.Cells[6].Text
					+ "&Scope=" + e.Item.Cells[7].Text);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();				
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteBackup";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadPlans();
			}
			else 
			{
				lblOrg.Text="below updatenone";
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmUpdBackups.aspx?"
				+ "&btnAction=" + "Add");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect(strURL + Session["startForm"].ToString() + ".aspx?");
		}
	}
}
