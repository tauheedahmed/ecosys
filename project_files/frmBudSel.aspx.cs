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
	public partial class frmBudSel: System.Web.UI.Page
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
			loadBuds();
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
		private void loadBuds()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text="Please select from the following budget(s).";
				loadContents1();
				loadData();
			}
		}
		private void loadContents1()
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
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveBudgetsAll";
				cmd.Connection=this.epsDbConn;
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
				da.Fill(ds,"BudOrgsAll");
				if (ds.Tables["BudOrgsAll"].Rows.Count == 0)
				{
					DataGrid1.Visible=false;
					lblContents.Text="There are no budgets created for this"
						+ " organization.  Click on 'Add' to create budgets.";
				}
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			
		}
		
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdBudget"]="frmBudgetsAll";
			Response.Redirect (strURL + "frmUpdBudget.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				Session["BudgetsIdSel"] = e.Item.Cells[0].Text;
				Session["BProvSel"] = e.Item.Cells[1].Text;
				Session["BudNameSel"] = e.Item.Cells[2].Text;
				Session["CurrNameSel"] = e.Item.Cells[3].Text;
				Session["BudStatus"] = e.Item.Cells[4].Text;
				Session["BudSel"] = "1";
				Exit();
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
			{
				Response.Redirect (strURL + Session["CBS"].ToString() + ".aspx?");
			}
	}

}

