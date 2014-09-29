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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmPSEPClient : System.Web.UI.Page
	{
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
                partLoad();
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

/*********************************************************************************************************************
 * Section A handles clients identified in budget targets.  Section C handles clients as part of WP using business model.  Section D
 * handles clients identified in Business Model
 * *******************************************************************************************************************/
        /*********************************************************************************************************************
        *                                            PART I:  LOAD
        * *******************************************************************************************************************/
        private void partLoad()
        {
            Session["Part"] = "Load";
            if (Session["CPSEPC"].ToString() == "frmBudOrgsD")
            {
                SectionA();
            }
            else if (Session["CPSEPC"].ToString() == "frmProjects")
            {
                SectionB();
            }
            else if (Session["CPSEPC"].ToString() == "frmOrgLocSEProcs")
            {
                SectionC();
            }
            else if (Session["CPSEPC"].ToString() == "frmProfileserviceEvents")
            {
                SectionD();
            }
        }
      
        /******************************************************************************************************************** 
        * PART I:  Section A Load Budget Clients
        * *******************************************************************************************************************/
        private void SectionA()
        {
            Session["frmSec"] = "SecA";
            lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                + Session["CurrName"].ToString();
            lblTitle.Text = "Performance Targets for: " + Session["BudName"].ToString();
            lblServiceName.Visible = false;
            lblDeliverableName.Visible=false;
            lblProcessName.Visible = false;
            lblContents1.Text = "You may now identify performance indicators in terms of impact on the various types of clients "
            + "and beneficiaries listed below.  Click on 'Add' to the list below.";
            btnAddO.Visible = true;
            DataGrid1.Visible = true;
            DataGrid1.Columns[3].Visible = false;
            loadDataBud();
        }
        private void loadDataBud()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveBudOrgClients";
            cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
            cmd.Parameters["@BudOrgsId"].Value = Session["BOId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "BOClients");
            if (ds.Tables["BOClients"].Rows.Count == 0)
            {
                //LoadAllClients
                lblContents1.Text = "There are no client types identified for this kind of organization"
                    + " in the business model.  Please contact your system administrator.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                assignValues();
            }
        }
        private void assignValues()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
                if (i.Cells[5].Text == "&nbsp;")
                {
                    tbDesc.Text = null;
                }
                else
                {
                    tbDesc.Text = i.Cells[5].Text;
                }
            }
        }
        /******************************************************************************************************************** 
        * PART I:  Section B Load Project Clients
        * *******************************************************************************************************************/
        private void SectionB()
        {
            Session["frmSec"] = "SecB";
            //lblBd.Text = "Budget: " + Session["BudName"].ToString();
            //lblTitle.Text = "Performance Targets for: " + Session["BudName"].ToString();
            lblServiceName.Visible = false;
            lblDeliverableName.Visible = false;
            lblProcessName.Visible = false;
            lblContents1.Text = "You may now identify performance indicators in terms of impact on the various types of clients "
            + "and beneficiaries listed below.  Click on 'Add' to the list below.";
            lblProject.Text = Session["PJNameS"].ToString() + ": " + Session["ProjName"].ToString();
            btnAddO.Visible = true;
            DataGrid1.Visible = true;
            DataGrid1.Columns[3].Visible = false;
            loadDataClient();
        }
        private void loadDataClient()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveProjectClients";
            cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
            cmd.Parameters["@ProjectId"].Value = Session["ProjectId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ProjectC");
            if (ds.Tables["ProjectC"].Rows.Count == 0)
            {
                //LoadAllClients
                DataGrid1.Visible = false;
                DataGrid2.Visible = false;
                
                //Get BudgetClientsList, if that is not present then do next three lines
                loadDataBud();
                //lblnewClient.Visible = true;
                //lblnewClient.Text = "What is the name for this kind of client?";
                //txtnewClient.Visible = true;
                btnAddProjectClient.Visible = true;
                btnAddO.Visible = false;
            }
            else
            {
                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                assignValues();
            }
        }

        /*********************************************************************************************************************
         *  * PART I:  Section C Load Org Location Service Clients (not working)
        * *******************************************************************************************************************/
        private void SectionC()
        {
            Session["frmSec"] = "SecC";
            lblTitle.Visible = false;
            lblProfilesName.Visible = false;
            lblServiceName.Visible = false;
            lblDeliverableName.Visible = false;
            DataGrid1.Columns[2].Visible = false;
            if (Session["MgrName"] == null)
            {
                lblOrg.Text = Session["OrgName"].ToString();
            }
            else 
            {
                lblOrg.Text = Session["MgrName"].ToString();

            }
            lblProcessName.Visible = false;
            lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                + Session["CurrName"].ToString();
            lblLoc.Text = "Location: " + Session["LocationName"].ToString();
            lblService.Text = "Service: " + Session["ServiceName"].ToString();
            if (Session["PRS"].ToString() == "1")
            {
                lblProject.Text = Session["EventName"].ToString()
                    + ": "
                    + Session["ProjName"].ToString();
            }
            if (Session["startForm"].ToString() == "frmMainBMgr")
            {
                lblContents1.Text = "Given below are the different types of procedures"
                    + " that are undertaken to deliver the above service."
                    + " Click on the appropriate button to review resources assigned to perform a given procedure.";
            }
            else
            {
                lblContents1.Text = "Given below are the different types of procedures"
                    + " that are undertaken to deliver the above service."
                    + " Click on the appropriate button to assign resources to perform a given procedure.";
            }
            loadDataOL();
        }
        private void loadDataOL()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveOLPSEPClient";
            cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
            cmd.Parameters["@BudgetsId"].Value = Session["BudgetsId"].ToString();
            cmd.Parameters.Add("@OrgLocID", SqlDbType.Int);
            cmd.Parameters["@OrgLocID"].Value = Session["OrgLocID"].ToString();
            cmd.Parameters.Add("@ProfileServicesId", SqlDbType.Int);
            cmd.Parameters["@ProfileServicesId"].Value = Session["ProfileServicesId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ProcClients");
            if (ds.Tables["ProcClients"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
            }
            else
            {
                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }
        }
        /*********************************************************************************************************************
        * Section D Load Business Model Clients
        * *******************************************************************************************************************/

        private void SectionD()
        {
            Session["frmSec"] = "SecD";
            lblProfilesName.Text = "Business Profile for: " + Session["ProfilesName"].ToString();
            lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
            lblDeliverableName.Text = "Deliverable: " + Session["EventsName"].ToString();
            loadDataPS();
        }
        private void loadDataPS()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrievePSEClients";
            cmd.Parameters.Add("@PSEID", SqlDbType.Int);
            cmd.Parameters["@PSEID"].Value = Session["ProfileSEventsId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "PSEClients");
            if (ds.Tables["PSEClients"].Rows.Count == 0)
            {
                addSelect();
                addSelectView();
            }
            else
            {
                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                assignValues();

                DataGrid1.Visible = true;
                lblnewClient.Visible = false;
                lblContents1.Text = "The client types for this service are listed below.  Click on 'Add' to add to this list.dd";
                lblnewClient.Visible = false;
                txtnewClient.Visible = false;
                btnAddO.Visible = true;
                btnAdd.Visible = false;
                btnAddO1.Visible = false;
                btnAddProjectClient.Visible = false;
                btnAddProjectClient.Text = "Add Project Client";
            }
        }
        /**************************************************************************************************************
         * PART II:  Add new rows
         * ***********************************************************************************************************/
        protected void btnAddO_Click1(object sender, EventArgs e)
        {
            addSelect();
            addSelectView();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_AddClient";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            cmd.Parameters["@Name"].Value = txtnewClient.Text;
            cmd.Parameters.Add("@Vis", SqlDbType.Int);
            cmd.Parameters["@Vis"].Value = 3;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            DataGrid1.Visible = false;
            DataGrid2.Visible = true;
            lblnewClient.Visible = false;
              txtnewClient.Visible = false;
            btnAdd.Visible = false;
            btnAddO.Visible = true;
            btnExit.Visible = false;

            addSelect();
        }
  
        
        private void addSelect()
        {
            Session["Part"] = "Add";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveClientsAll";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
            cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
            cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
            cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
            cmd.Parameters.Add("@DomainId", SqlDbType.Int);
            cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Clients");
            if (ds.Tables["Clients"].Rows.Count == 0)
            {
                addNew();
            }
            else
            {
                Session["ds"] = ds;
                DataGrid2.DataSource = ds;
                DataGrid2.DataBind();
                refreshSec();
                addSelectView();
              
                
            }
        }
        private void refreshSec()
        {
            foreach (DataGridItem i in DataGrid2.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                if (Session["CPSEPC"].ToString() == "frmProfileserviceEvents")
                {
                    cmd.CommandText = "Select Id from PSEClients"
                         + " Where PSEClients.ProfileServiceEventsId = " + Session["ProfileSEventsId"].ToString()
                         + " and PSEClients.ClientsId = " + i.Cells[0].Text;
                }
                /*else if (Session["CPSEPC"].ToString() == "frmOrgLocSEProcs")
                {
                    cmd.CommandText = "Select Id from ServiceEvents"
                        + " Where ServicesId = " + Session["ServicesId"].ToString()
                        + " and EventsId = " + i.Cells[0].Text;
                }*/
                else if (Session["CPSEPC"].ToString() == "frmBudOrgsD")
                {
                    cmd.CommandText = "Select Id from BudOrgClients"
                        + " Where BudOrgsId = " + Session["BOId"].ToString()
                        + " and ClientsId = " + i.Cells[0].Text;
                }
                cmd.Connection.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    cb.Checked = true;
                    cb.Enabled = false;
                }
                cmd.Connection.Close();
            }

        }
        private void addSelectView()
        {
            lblnewClient.Visible = false;
            txtnewClient.Visible = false;
            btnAdd.Visible = false;
            btnAddProjectClient.Visible = false;

            btnExit.Text = "OK";
            btnExit.Visible = true;
            btnAddO.Visible = false;
            btnAddO1.Visible = true;

            DataGrid1.Visible = false;
            DataGrid2.Visible = true;
        }
        
        
        /**************************************************************************************************************
         * PART III:  Update Existing rows
         * ***********************************************************************************************************/
		private void updateGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
                    if (Session["CPSEPC"].ToString() == "frmBudOrgsD")
                    {
                        cmd.CommandText = "wms_UpdateBudOrgClientsDesc";
                    }
                    else if (Session["CPSEPC"].ToString() == "frmProfileserviceEvents")
                    {
                        cmd.CommandText = "wms_UpdatePSEClientDesc";
                    }
                    else if (Session["CPSEPC"].ToString() == "frmProcs")
                    {
                        cmd.CommandText = "wms_UpdateProcClientDesc";
                    }
                    
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
					cmd.Parameters ["@Desc"].Value=tbDesc.Text.ToString();
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text.ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
		}
        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Standards")
            {
                Session["ClientName"] = e.Item.Cells[1].Text;
                Session["Id"] = e.Item.Cells[0].Text;
                Session["CUpdPSEPC"] = "frmPSEPClient";
                Response.Redirect(strURL + "frmUpdPSEPClient.aspx?");
            }
            else if (e.CommandName == "Deliverables")
            {
            //Session["ProfileName"] = e.Item.Cells[1].Text;
            Session["Id"] = e.Item.Cells[0].Text;
            Session["CPSEPCRT"] = "frmPSEPClient";
            Response.Redirect(strURL + "frmPSEPClientRT.aspx?");
            }
            else if (e.CommandName == "Impact")
            {
                Session["ProfileName"] = e.Item.Cells[1].Text;
                if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                {
                    Session["PSEPClientsId"] = e.Item.Cells[0].Text;
                }
                else if (Session["CPSEPC"].ToString() == "frmProcs")
                {
                    Session["ProcClientsId"] = e.Item.Cells[0].Text;
                }
                Session["CPSEPCI"] = "frmPSEPClient";
                Response.Redirect(strURL + "frmPSEPClientImpact.aspx?");
            }
            else if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (Session["frmSec"] == "SecA")
                {
                    cmd.CommandText = "wms_DeleteBudOrgClients";
                }
                else if (Session["frmSec"] == "SecC")
                {
                    cmd.CommandText = "wms_DeleteOLPSEPClient";
                }
                else if (Session["CPSEPC"].ToString() == "frmProfileserviceEvents")
                {
                    cmd.CommandText = "wms_DeletePSEClient";
                }
                else if (Session["CPSEPC"].ToString() == "frmProcs")
                {
                    cmd.CommandText = "wms_DeleteProcClient";
                }
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = e.Item.Cells[0].Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                partLoad();
            }
        }
		 /*protected void btnAddO_Click(object sender, System.EventArgs e)
		{
			updateGrid();
            Session["CallerProfilesAll"] = "frmPSEPClient";
            Response.Redirect(strURL + "frmProfilesAll.aspx?");	
		}*/
 /**************************************************************************************************************
 * PART IV:  EXIT
 * ***********************************************************************************************************/


		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            if (Session["Part"] == "Load")
            {
                updateGrid();
                Response.Redirect(strURL + Session["CPSEPC"].ToString() + ".aspx?");
            }
            else if (Session["Part"] == "Add")
            {
                foreach (DataGridItem i in DataGrid2.Items)
                {
                CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
                    if ((cb.Checked) & (cb.Enabled))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (Session["frmSec"].ToString() == "SecA")//i.e. budget management
                            {
                                cmd.CommandText = "wms_AddBudOrgClients";
                                cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
                                cmd.Parameters["@BudOrgsId"].Value = Int32.Parse(Session["BOId"].ToString());
                                cmd.Parameters.Add("@ClientsId", SqlDbType.Int);
                                cmd.Parameters["@ClientsId"].Value = Int32.Parse(i.Cells[0].Text);
                            }
                            else if (Session["frmSec"].ToString() == "SecC")//i.e. work planning
                            {
                                cmd.CommandText = "wms_AddOLPSEPClient";
                                cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
                                cmd.Parameters["@BudgetsId"].Value = Int32.Parse(Session["BudgetsId"].ToString());
                                cmd.Parameters.Add("@OrgLocID", SqlDbType.Int);
                                cmd.Parameters["@OrgLocID"].Value = Int32.Parse(Session["OrgLocID"].ToString());
                                cmd.Parameters.Add("@ProfileServicesId", SqlDbType.Int);
                                cmd.Parameters["@ProfileServicesId"].Value = Int32.Parse(Session["ProfileServicesId"].ToString());
                                cmd.Parameters.Add("@ClientProfilesId", SqlDbType.Int);
                                cmd.Parameters["@ClientProfilesId"].Value = Int32.Parse(i.Cells[0].Text);
                            }
                        else if (Session["frmSec"].ToString() == "SecD")//i.e. business model
                        {
                            cmd.CommandText = "wms_AddPSEClients";
                            cmd.Parameters.Add("@PSEID", SqlDbType.Int);
                            cmd.Parameters["@PSEID"].Value = Session["ProfileSEventsId"].ToString();
                            cmd.Parameters.Add("@ClientsId", SqlDbType.Int);
                            cmd.Parameters["@ClientsId"].Value = Int32.Parse(i.Cells[0].Text);
                        }
                        cmd.Connection = this.epsDbConn;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                btnExit.Text = "OK";
                btnAddO.Visible = true;
                DataGrid1.Visible = true;
                DataGrid2.Visible = false;
                partLoad();
            }
		}
/********************************************************************************************************************************
       
        // Proc related material below.  To be taken out

        /*if (Session["CPSEPC"].ToString() == "frmProcs")
                
               {
                   lblTitle.Text = "EcoSys:  Service Models";
                   lblContents1.Text = "You may now identify the various types of client/stakeholders"
                      + " for the process indicated above.";
                   DataGrid1.Columns[3].Visible = false;
                   loadData();
               }
              
        private void loadDataProcs()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn; cmd.CommandText = "wms_RetrieveProcClient";
            cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
            cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ProcClients");
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            assignValues();
        } else */
        protected void btnAddProjectClient_Click(object sender, EventArgs e)
        {
            if (Session["frmSec"]  == "SecD")
            {
                addSelect();
                addSelectView();
                
            }

        }
        protected void btnAddO1_Click(object sender, EventArgs e)
        {
            addNew();
        }
        private void addNew()
        {
            DataGrid1.Visible = false;
            DataGrid2.Visible = false;
            lblnewClient.Visible = true;
            lblContents1.Text = "There are no client types identified for this business model. You may"
                + " identify a new client type if you wish.";
            lblnewClient.Visible = true;
             txtnewClient.Visible = true;
             btnExit.Visible = false;
            btnAddO.Visible = false;
            btnAddO1.Visible = false;
            btnAdd.Visible = true;
            btnAddProjectClient.Visible = true;
            btnAddProjectClient.Text = "Cancel";
        }
}


}