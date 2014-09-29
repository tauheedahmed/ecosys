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
	public partial class frmBudgetsClosed: System.Web.UI.Page
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
                if (Session["MgrOption"].ToString() == "Budget")
                {
                    lblStatus.Text = "Closed Budgets";
                }
                else
                {
                    lblStatus.Text = "Closed Funds";
                }
				loadData();
			}
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveBudgetsClosed";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
                
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"BudC");
			if (ds.Tables["BudC"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
                if (Session["MgrOption"].ToString() == "Budget")
                {
                    lblContents.Text = "There are no closed budgets that were created by your organization.  Click on 'Cancel' to Continue.";
                }
                else
                {
                    lblContents.Text = "There are no closed funds that were created by your organization.  Click on 'Cancel' to Continue.";
                }
				
			}
			else
			{
				lblContents.Text="The budget(s) listed were previously closed by this organization."
					+ " Click on the 'Re-Open' to reopen a given closed budget.";
			}
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				//refreshGrid();
			
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
				Exit();
		}

		/*private void updateGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));
					if ((cb.Checked) & (cb.Enabled))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="fms_UpdateBudOrgs";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@OrgId", SqlDbType.Int);
						cmd.Parameters ["@OrgId"].Value=Session["OrgId"].ToString();
						cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
						cmd.Parameters ["@BudgetsId"].Value=i.Cells[0].Text;
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
					CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));
					Button btC = (Button)(i.Cells[5].FindControl("btnControls"));
					Button btU = (Button)(i.Cells[5].FindControl("btnUpdate"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					cmd.CommandText="Select Id from BudOrgs"
						+ " Where OrgId = " + Session["OrgId"].ToString()
						+ " and BudgetsId = " + i.Cells[0].Text;
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked = true;
						cb.Enabled = false;
					}
					cmd.CommandText="Select Id from BudOrgs"
						+ " Where BudgetsId = " + i.Cells[0].Text;
					if (cmd.ExecuteScalar() != null) 
					{
						//btD.Text= "In Use";
						//btD.Enabled=false;
					}
					cmd.CommandText="Select Id from Budgets"
						+ " Where Id = " + i.Cells[0].Text
						+ " and Budgets.Status = '2'";
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Visible=false;
					}
					
					cmd.Connection.Close();
				}
		}*/
		private void Exit()
		{
			//Session["BudgetsIdC"]=null;
			Response.Redirect (strURL + Session["CBudsC"].ToString() + ".aspx?");
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			
			Response.Redirect (strURL + Session["CBudsC"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "ReOpen")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateBudgetsOpen";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
				cmd.Parameters ["@BudgetsId"].Value=Int32.Parse(e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Exit();
			}
		}
	}

}

