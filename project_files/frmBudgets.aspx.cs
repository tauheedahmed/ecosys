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
using CrystalDecisions.Shared;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmBudgets : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAddTemp;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{
                if (Session["MgrOption"].ToString() == "SOF")
                {
                    btnAdd.Text = "Add Fund";
                    btnReopen.Text = "Access Closed Funds";
                    lblOrg.Text = Session["OrgName"].ToString();
                    lblBd.Text = "Sources of Funds";
                    DataGrid2.Visible = false;
                    loadData1();
                    //Session["BProv"] = Session["OrgName"];
                }
                else if (Session["MgrOption"].ToString() == "Budget")
                {
                    btnAdd.Text = "Add Budget";
                    btnReopen.Text = "Access Closed Budgets";
                    lblOrg.Text = Session["OrgName"].ToString();
                    lblBd.Text = "Annual Budgets";
                    DataGrid1.Visible = false;
                    Session["BProv"] = Session["OrgName"];
                    loadData2();
                }
			} 
		}
        private void loadData1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveFunds";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
            
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"FundOrgs");
            if (ds.Tables["FundOrgs"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
                lblContents.Text = "There are no funds that are open for your"
                        + " organization.  Click on 'Add' if"
                        + " you wish to create a new source of fund.";
			}
			
			else
			{
                lblContents.Text = "The following sources of funds are currently open,"
                        + " and available for distribution. Click on 'Add' if the fund"
                        + " you wish to work with is not listed below."
                        + " Otherwise click on the appropriate button as indicated.";
			}
		    Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();	
		}
        private void loadData2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveBudgets";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Budgets");
            if (ds.Tables["Budgets"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContents.Text = "There are no budgets that are open for your"
                        + " organization.  Click on 'Add' if"
                        + " you wish to create a budget.";
            }
            else if (ds.Tables["Budgets"].Rows.Count == 1)
            {
                lblContents.Text = "The following annual budget is currently open,"
                        + " and available for distribution. Click on 'Add' if the budget"
                        + " you wish to work with is not listed below."
                        + " Otherwise click on the appropriate button as indicated.";
            }
            else
            {
                lblContents.Text = "The following annual budgets are currently open,"
                        + " and available for distribution. Click on 'Add' if the budget"
                        + " you wish to work with is not listed below."
                        + " Otherwise click on the appropriate button as indicated.";
            }
            Session["ds"] = ds;
            DataGrid2.DataSource = ds;
            DataGrid2.DataBind();
            refreshGrid2();
            
        }
        private void refreshGrid2()
        {
            foreach (DataGridItem i in DataGrid2.Items)
            {
                TextBox tb = (TextBox)(i.Cells[4].FindControl("txtAmount"));
                if (i.Cells[3].Text == "&nbsp;")
                {
                    tb.Text = null;
                }
                else
                {
                    tb.Text = i.Cells[3].Text;
                }
                DropDownList dl = (DropDownList)(i.Cells[5].FindControl("lstStatus"));
                dl.SelectedValue = i.Cells[6].Text;
                
            }
        }
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		
		{
            
		}
		private void rpts()
		{
			Session["cRG"]="frmMainWP";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}
		
		
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdBudget"]="frmBudgets";
            Session["Action"] = "Add";
			Response.Redirect (strURL + "frmUpdBudget.aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CBudgets"].ToString() + ".aspx?");
		}

		protected void btnReopen_Click(object sender, System.EventArgs e)
		{
			Session["CBudsC"]="frmBudgets";
			Response.Redirect (strURL + "frmBudgetsClosed.aspx?");
		}

        protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Orgs")
            {

                Session["BudgetsId"] = e.Item.Cells[0].Text;
                Session["BudName"] = e.Item.Cells[1].Text + " (FY" + e.Item.Cells[2].Text + ")";
                Session["Status"] = e.Item.Cells[7].Text;
                Session["CurrName"] = e.Item.Cells[9].Text;
                if (e.Item.Cells[3].Text == "&nbsp;")
                {
                    Session["BudAmt"] = 0;
                }
                else
                {
                    Session["BudAmt"] = e.Item.Cells[3].Text;
                }
                Session["CBudOrgsD"] = "frmBudgets";
                Response.Redirect(strURL + "frmBudOrgsD.aspx?");
            }


            else if (e.CommandName == "Update")
            {
                Session["CUpdBudget"] = "frmBudgets";
                Session["Action"] = "Update";
                Session["BudgetsId"] = e.Item.Cells[0].Text;
                Response.Redirect(strURL + "frmUpdBudget.aspx?");
                /*+ "&BudName=" + e.Item.Cells[1].Text
                + "&Curr=" + e.Item.Cells[4].Text
                + "&Amt=" + e.Item.Cells[5].Text
                + "&Status=" + e.Item.Cells[8].Text
                );*/
            }
            /*if (e.CommandName == "Controls")
            {
                Session["BF"] = "frmBudgets";
                Session["BudgetsIdC"] = e.Item.Cells[0].Text;
                Session["BudNameC"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmBudFlags.aspx?");
            }*/
            
            else if (e.CommandName == "Close")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fms_UpdateBudgetsClose";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
                cmd.Parameters["@BudgetsId"].Value = Int32.Parse(e.Item.Cells[0].Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData2();
            }

        }
        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Orgs")
            {
                Session["BudgetsId"] = e.Item.Cells[0].Text;
                Session["BudName"] = e.Item.Cells[1].Text;
                Session["Status"] = e.Item.Cells[2].Text;
                Session["CurrName"] = e.Item.Cells[3].Text;
                if (e.Item.Cells[4].Text == "&nbsp;")
                {
                    Session["BudAmt"] = 0;
                }
                else
                {
                    Session["BudAmt"] = e.Item.Cells[4].Text;
                }
                Session["CBudOrgsD"] = "frmBudgets";
                Response.Redirect(strURL + "frmBudOrgsD.aspx?");
            }


            else if (e.CommandName == "Update")
            {
                Session["CUpdBudget"] = "frmBudgets";
                Session["Action"] = "Update";
                Session["FundsId"] = e.Item.Cells[0].Text;
                Response.Redirect(strURL + "frmUpdBudget.aspx?");
                /*+ "&BudName=" + e.Item.Cells[1].Text
                + "&Curr=" + e.Item.Cells[4].Text
                + "&Amt=" + e.Item.Cells[5].Text
                + "&Status=" + e.Item.Cells[8].Text
                );*/
            }
            if (e.CommandName == "Controls")
            {
                Session["BF"] = "frmBudgets";
                Session["BudgetsIdC"] = e.Item.Cells[0].Text;
                Session["BudNameC"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmBudFlags.aspx?");
            }
            else if (e.CommandName == "Close")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fms_UpdateBudgetsClose";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
                cmd.Parameters["@BudgetsId"].Value = Int32.Parse(e.Item.Cells[0].Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData2();
            }

        }
}

}

	