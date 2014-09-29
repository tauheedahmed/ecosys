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
using System.Globalization;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmOrgLocServices: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		int LocFlag = 0;
        protected void Page_Load(object sender, System.EventArgs e)
       {
			// Put user code to initialize the page here
            lblOrg.Text=Session["OrgName"].ToString();
            
               
            if (Session["MgrOption"] == "Budget")
			{
				lblContents1.Text="Given below is a list of services delivered by the above organization"
					+ " from the above location.  You may provide a budget for the service as a whole "
                    + " and/or for individual tasks undertaken as part of a given service.";
                DataGrid1.Columns[4].Visible = false;
                DataGrid2.Visible = false;
			}
            else if (Session["MgrOption"] == "Plan")
			
			{
                //DataGrid2.Columns[4].Visible=false;
                DataGrid1.Visible = false;
			}
            if (!IsPostBack)
            {
                loadLocations();
                setLoc();
                /* LoadLocs *********************/
                
                if (LocFlag == 1)
                {
                    lblLoc.Visible = false;
                    btnLoc.Visible = false;
                    
                }
                /* LoadLocs *********************/

                if (Session["MgrOption"].ToString() == "Budget")
                {
                    lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                    + Session["CurrName"].ToString();
                }
                /*else
                {
                    setBudget();
        
                }*/
                btnAdd.Text = "Show All Services";
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
        /*private void loadBudgets()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "fms_RetrieveBudOrgs";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Budgets");
            lstBd.DataSource = ds;
            lstBd.DataMember = "Budgets";
            lstBd.DataTextField = "Name";
            lstBd.DataValueField = "Id";
            lstBd.DataBind();
            //lstBudgets.SelectedIndex = GetIndexOfBudgets(ds.Tables["StaffAction"].Rows[0][13].ToString());
			
        }
        private int GetIndexOfBudgets(string s)
        {
            return (lstBd.Items.IndexOf(lstBd.Items.FindByValue(s)));
        }*/
        private void loadLocations()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveLocations";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Locations");
            if (ds.Tables["Locations"].Rows.Count == 1)
            {
                LocFlag = 1;
            }
            lstLoc.DataSource = ds;
            lstLoc.DataMember = "Locations";
            lstLoc.DataTextField = "Name";
            lstLoc.DataValueField = "Id";
            lstLoc.DataBind();
        }
        private void loadData()
        {
            if (Session["MgrOption"] == "Plan")
                {
                    loadDataP();
                }
            else if (Session["MgrOption"] == "Budget")
                {
                    loadDataB();
                }
        }
        private void loadDataP()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
            cmd.CommandText = "wms_RetrieveOrgServiceTypes";
            cmd.Parameters.Add ("@EPSFlag",SqlDbType.Int);
			cmd.Parameters["@EPSFlag"].Value=Int32.Parse(Session["EPS"].ToString());
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"LocServices");
            if (ds.Tables["LocServices"].Rows.Count == 0)
            {
                DataGrid2.Visible = false;
                /* LoadLocs *********************/
                btnLoc.Visible = false;
                /* LoadLocs *********************/
                
                lblContents1.Text = "Sorry.  There are no existing services identified for this profile."
                    + " Press 'Signoff' and contact your system administrator.";
            }
            else
            {
                lblContents1.Text = "Given below is a list of services delivered by your organization"
                    + " from the above location.  Click on 'Select' to enter planned inputs"
                    + " and other details related to a given service. If possible at this stage, please"
                    + " have identify the budget that will be charged for planned inputs"
                    + " by clicking on the appropriate button above and selecting the"
                    + " appropriate item from the list that will then appear. Do the same for location above."; 
                Session["ds"] = ds;
                DataGrid2.DataSource = ds;
                DataGrid2.DataBind();
                refreshGridP();
                /* LoadLocs *********************/
                
                if (ds.Tables["LocServices"].Rows.Count == 1)
                {
                    btnLoc.Visible = false;
                }
                /* LoadLocs *********************/
                
            }
		}
        private void loadDataB()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveBudOLServiceTypes";
            cmd.Parameters.Add("@EPSFlag", SqlDbType.Int);
            cmd.Parameters["@EPSFlag"].Value = Int32.Parse(Session["EPS"].ToString());
            cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
            cmd.Parameters["@BudOrgsId"].Value = Int32.Parse(Session["BDOId"].ToString());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "LocServices");
            if (ds.Tables["LocServices"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                btnLoc.Visible = false;
                lblContents1.Text = "Sorry.  There are no existing services identified for this profile."
                    + " Press 'Signoff' and contact your system administrator.";
            }
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            refreshGridB();
        }
        /*private void loadBudget()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveOrgLocServiceTypes";
            cmd.Parameters.Add("@OrgLocId", SqlDbType.Int);
            cmd.Parameters["@OrgLocId"].Value = Session["OrgLocId"].ToString();
            //cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
            //cmd.Parameters["@BudgetsId"].Value = Session["BudgetsId"].ToString();
            cmd.Parameters.Add("@EPSFlag", SqlDbType.Int);
            cmd.Parameters["@EPSFlag"].Value = Int32.Parse(Session["EPS"].ToString());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "LocServices");
            if (ds.Tables["LocServices"].Rows.Count == 0)
            {
                DataGrid2.Visible = false;
                lblContents1.Text = "Sorry.  There are no existing services identified for this profile."
                    + " Press 'Signoff' and contact your system administrator.";
            }
            Session["ds"] = ds;
            DataGrid2.DataSource = ds;
            DataGrid2.DataBind();
            loadBudget();
            refreshGrid();
        }*/
		private void refreshGridB()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtBud"));
                Button btp = (Button)(i.Cells[3].FindControl("btnProjects"));
                Button btn = (Button)(i.Cells[3].FindControl("btnProcess"));
                btp.Text = i.Cells[8].Text;
                btn.Text = "Ongoing Tasks";
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_RetrieveBudOLServices";
                cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
                cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
                cmd.Parameters["@BudOrgsId"].Value = Int32.Parse(Session["BDOId"].ToString());
                cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                cmd.Parameters["@ServiceTypesId"].Value = Int32.Parse(i.Cells[0].Text);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "ServiceBudget"); 
                if (ds.Tables["ServiceBudget"].Rows.Count > 0)
                {
                    i.Cells[10].Text = ds.Tables["ServiceBudget"].Rows[0][1].ToString();
                    i.Cells[11].Text = ds.Tables["ServiceBudget"].Rows[0][0].ToString();
                    
                }
                if (i.Cells[10].Text == "&nbsp;")
                {
                    
                    tb.Text = null;
                }
                else
                {
                    tb.Text = i.Cells[10].Text;
                }

			}
		}
        private void refreshGridP()
        {
            foreach (DataGridItem i in DataGrid2.Items)
            {
                Button btp = (Button)(i.Cells[2].FindControl("btnProjects"));
                btp.Text = "Select";
                //btp.Text = i.Cells[6].Text;
            }
        }
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            updateBudAmt();
			Response.Redirect (strURL + Session["COrgLocServices"].ToString() + ".aspx?");
		}
        private void updateBudAmt()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtBud"));
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdateBudOLServiceAmt";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@BudAmt", SqlDbType.Decimal);
                    if (tb.Text != "")
                    {
                        cmd.Parameters["@BudAmt"].Value = decimal.Parse(tb.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands);
                    }
                    if (i.Cells[11].Text != "&nbsp;")
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[11].Text);
                    }
                    else
                    {
                        cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                        cmd.Parameters["@ServiceTypesId"].Value = Int32.Parse(i.Cells[0].Text);
                        cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                        cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
                        cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
                        cmd.Parameters["@BudOrgsId"].Value = Int32.Parse(Session["BDOId"].ToString());
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
		
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            updateBudAmt();
			Session["ProfileServicesId"]=e.Item.Cells[7].Text;
			Session["ServiceName"]=e.Item.Cells[1].Text;
			if (e.CommandName == "Procs")
			{
				Session["COrgLocSEProcs"]="frmOrgLocServices";
				Session["PRS"]="0";
				Response.Redirect (strURL + "frmOrgLocSEProcs.aspx?");
			}
			else if (e.CommandName == "Projects")
			{
				Session["PJName"]=e.Item.Cells[8].Text;
				Session["PJNameS"]=e.Item.Cells[9].Text;
				Session["BudOLServicesId"]=e.Item.Cells[11].Text;
                Session["PRS"] = "1";
                Session["CProjects"] = "frmOrgLocServices";
                Response.Redirect(strURL + "frmProjects.aspx?");	
			}
			else if (e.CommandName == "Remove")
			{
				/*SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "wms_AddOrgLocServiceTypes";
				//services are added since these services will be excluded from datagrid in method loadData.
				cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
				cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
				cmd.Parameters.Add ("@ServiceTypesId",SqlDbType.Int);
				cmd.Parameters["@ServiceTypesId"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				loadData();
				//refreshGrid();*/
			}
		}

	protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "wms_DeleteOrgLocServices";
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		
		}
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        Session["ProfileServicesId"] = e.Item.Cells[5].Text;
        Session["ServiceName"] = e.Item.Cells[1].Text;
           
        if (e.CommandName == "Procs")
        {
            Session["COrgLocSEProcs"] = "frmOrgLocServices";
            Session["PRS"] = "0";
            Response.Redirect(strURL + "frmOrgLocSEProcs.aspx?");
        }
        else if (e.CommandName == "Projects")
        {
            Session["PJName"] = e.Item.Cells[6].Text;
            Session["PJNameS"] = e.Item.Cells[7].Text;
            Session["PRS"] = "1";
            Session["CPSE"] = "frmOrgLocServices";
            Response.Redirect(strURL + "frmPSEvents.aspx?");
        }
        else if (e.CommandName == "Remove")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_AddOrgLocServiceTypes";
            //services are added since these services will be excluded from datagrid in method loadData.
            cmd.Parameters.Add("@OrgLocId", SqlDbType.Int);
            cmd.Parameters["@OrgLocId"].Value = Session["OrgLocId"].ToString();
            cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
            cmd.Parameters["@ServiceTypesId"].Value = e.Item.Cells[0].Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            loadData();
        }
    }
    /* LoadLocs *********************/
    protected void btnLoc_Click(object sender, EventArgs e)
    {
        lblLoc.Visible = false;
        lblLocC.Visible = true;
        btnLoc.Visible = false;
        lstLoc.Visible = true;

    }
    protected void lstLoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Session["MgrOption"] == "Plan")
        {
            setLoc();
            loadDataP();
        }
        else if (Session["MgrOption"] == "Budget")
        {
            updateBudAmt();
            setLoc();
            loadDataB();
            
        }
        lblLoc.Visible = true;
        lblLocC.Visible = false;
        btnLoc.Visible = true;
        lstLoc.Visible = false;
        
        
    }
    private void setLoc()
    {
        Session["LocName"] = lstLoc.SelectedItem;
        Session["LocationsId"] = lstLoc.SelectedValue;
        lblLoc.Text = "Location: " + Session["LocName"].ToString();
    }
}

}

