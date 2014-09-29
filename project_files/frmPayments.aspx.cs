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
	public partial class frmPayments: System.Web.UI.Page
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
				lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
					+ Session["CurrName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				if (Session["CBudOrgs"].ToString() == "frmTasks")
				{
					lblDel.Text="Deliverable: " + Session["EventName"].ToString();
					lblTask.Text=Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Task: " + Session["ProcName"].ToString() + ")";
				}
				else if (Session["CBudOrgs"].ToString() == "frmMainWP")
				{
					lblDel.Text="Task: " + Session["ProcName"].ToString();
				}
				if (Session["CPay"].ToString() == "frmProcSReq")
				{
					lblRole.Text="Role: " + Session["PSEPSName"].ToString();
				}
				else if (Session["CPay"].ToString() == "frmProcSerReq")
				{
					lblRole.Text="Resource:  " + Session["SerName"].ToString();
				}
				
				lblContents.Text="Payment approvals to date for the goods or services received"
					+ " as indicated above";
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
				cmd.CommandText="fms_RetrievePayments";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ProcProcuresId",SqlDbType.Int);
				cmd.Parameters["@ProcProcuresId"].Value=Session["ProcProcuresId"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"PP");
				if (ds.Tables["PP"].Rows.Count == 0)
				{
					addPayment();
				}
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
				Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPay"].ToString() + ".aspx?");
		}
		private void addPayment()
		{
			Session["CUpdPayments"]="frmPayments";
			Response.Redirect (strURL + "frmUpdPayment.aspx?"
				+ "&btnAction=" + "Add");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			addPayment();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdPayments"]="frmPayments";
				Response.Redirect (strURL + "frmUpdPayment.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					);
			}
		}
	}

}

