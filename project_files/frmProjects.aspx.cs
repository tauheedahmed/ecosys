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
using System.Globalization;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmProjects: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblContents2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
        int TaskCount = 2;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadForm()
		{
            Session["ProjectId"] = null;
			
			if (!IsPostBack)
			{
                lblService.Text="Service: " + Session["ServiceName"].ToString();
                lblLoc.Text = "Location: " + Session["LocName"].ToString();
                lblLoc.Text = "Location: " + Session["LocName"].ToString();
                
                btnAddNew.Text = "Add New " + Session["PJName"].ToString();
                btnAddOth.Text = "Add External " + Session["PJName"].ToString();
                btnDeAct.Text = "Access Completed " + Session["PJName"].ToString();
                if (Session["MgrOption"] == "Plan")
                {
                    lblMgr.Text = Session["OrgName"].ToString();
                    DataGrid1.Columns[1].HeaderText = Session["PJName"].ToString();
	         
                    loadTasks();
                    if (TaskCount == 1)
                    {
                        lblTask.Visible = false;
                        btnTask.Visible = false;
                        DataGrid1.Columns[3].Visible = true;
                        DataGrid1.Columns[4].Visible = true;
                        DataGrid1.Columns[5].Visible = false;
                    }
                    else if (TaskCount == 2)
                    {
                        DataGrid1.Columns[3].Visible = false;
                        DataGrid1.Columns[4].Visible = false;
                        DataGrid1.Columns[5].Visible = true;
                        setTask();
                    }
                    else //i.e. if (TaskCount == 0)
                    {
                        lblTask.Visible = false;
                        btnTask.Visible = false;
                        btnAddNew.Visible = false;
                        btnAddOth.Visible = false;
                        btnDeAct.Visible = false;
                        DataGrid1.Visible = false;
                        lblContents1.Text = "The business model for the Type of "
                            + Session["PJName"].ToString() + " indicated above is incomplete."
                            + " In order to plan for such " + Session["PJName"].ToString()
                        + ", please contact your system administrator.";
                    }
                  
                   
                    lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
                    DataGrid2.Visible = false;
                    loadData1();
                }
                else if (Session["MgrOption"] == "Budget")
                {
                    lblMgr.Text = Session["MgrName"].ToString();
                    lblLoc.Text = "Location: " + Session["LocName"].ToString();
                    lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                    + Session["CurrName"].ToString();
                    btnAddNew.Visible = false;
                    btnAddOth.Visible = false;
                    btnDeAct.Visible = false;
                    btnTask.Visible = false;
                    lblContents1.Text = Session["PJName"].ToString()
                        + " that are currently active at this location"
                        + " are listed below.  You may now"
                        + " provide a budget for them as needed.";
                    DataGrid1.Visible = false;
                    DataGrid2.Columns[1].HeaderText = Session["PJName"].ToString();
                    loadData2();
                }
			}		
		}
		private void loadData1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;

			cmd.CommandText="wms_RetrieveProjectsPlan";
            cmd.Parameters.Add ("@PSEventId",SqlDbType.Int);
			cmd.Parameters["@PSEventId"].Value=Int32.Parse(Session["PSEventsId"].ToString());
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
            if (ds.Tables["Projects"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContents1.Text = "Note:  There are no "
                        + Session["PJName"].ToString()
                        + " of this type that are currently active at this location."
                        + " You may identify a new such "
                        + Session["PJNameS"].ToString()
                        + " at this or some other location by clicking on "
                        + " the appropriate button below.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                refreshGrid1();
            }
		}
        private void loadData2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText="wms_RetrieveProjectsPlan";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["MgrId"].ToString();
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
            DataSet ds = new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
            if (ds.Tables["Projects"].Rows.Count == 0)
            {
                DataGrid2.Visible = false;
                lblContents1.Text = "Note:  There are no "
                        + Session["PJName"].ToString()
                        + " of this type that are currently planned or active at this location."
                        + " You may however identify new such "
                        + Session["PJName"].ToString()
                        + " by exiting this 'Budget' option and proceeding to the 'Plan' Option.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid2.DataSource = ds;
                DataGrid2.DataBind();
                refreshGrid2();
            }
        }
        private void refreshGrid2()
		{
			foreach (DataGridItem i in DataGrid2.Items)
			{ 
                TextBox tb = (TextBox)(i.Cells[3].FindControl("txtBud"));
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "fms_RetrieveBudProjProcs";
                cmd.Parameters.Add("@ProjectsId", SqlDbType.Int);
                cmd.Parameters["@ProjectsId"].Value = Int32.Parse(i.Cells[0].Text);
                cmd.Parameters.Add("@ProfileSEProcsId", SqlDbType.Int);
                cmd.Parameters["@ProfileSEProcsId"].Value = Int32.Parse(i.Cells[9].Text);
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["MgrId"].ToString();
                cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
                cmd.Parameters.Add("@BudOLServicesId", SqlDbType.Int);
                cmd.Parameters["@BudOLServicesId"].Value = Int32.Parse(Session["BudOLServicesId"].ToString());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Projects");
                if (ds.Tables["Projects"].Rows.Count != 0)
                {
                    tb.Text = ds.Tables["Projects"].Rows[0][0].ToString();
                     i.Cells[10].Text = "y";
                }
                else
                {
                    tb.Text = null;
                }
           }
        }
        private void refreshGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                Button btTT = (Button)(i.Cells[5].FindControl("btnTT"));
                Button btD = (Button)(i.Cells[6].FindControl("btnDeActivate"));
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_RetrieveProfileSEProcs";
                cmd.Parameters.Add("@ProfileSEventsId", SqlDbType.Int);
                cmd.Parameters["@ProfileSEventsId"].Value = Int32.Parse(Session["PSEventsId"].ToString());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tasks");
                if (ds.Tables["Tasks"].Rows.Count != 0)
                {
                    btTT.Text = "Tasks";
                }
                else
                {
                    btTT.Visible = false;
                }

            }
        }

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            if (Session["MgrOption"].ToString() == "Budget")
            {
                updateBudAmt();
            }
			Exit();
		}
		
		private void Exit()
		{
			Response.Redirect (strURL + Session["CProjects"].ToString() + ".aspx?");
		}

		private void rpts()
		{
			Session["cRG"]="frmProjects";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}

        private void updateBudAmt()
        {
           foreach (DataGridItem i in DataGrid2.Items)
            {
                
               TextBox tb = (TextBox)(i.Cells[3].FindControl("txtBud"));
               {
                     
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdateBudProjProcs";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int);
                    if (i.Cells[10].Text == "y")
                    {
                    cmd.Parameters["@Flag"].Value = 1;
                    }
                    cmd.Parameters.Add("@ProjectsId", SqlDbType.Int);
                    cmd.Parameters["@ProjectsId"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@PSEPId", SqlDbType.Int);
                    cmd.Parameters["@PSEPId"].Value = Int32.Parse(i.Cells[9].Text);
                    cmd.Parameters.Add("@BudOLServicesId", SqlDbType.Int);
                    cmd.Parameters["@BudOLServicesId"].Value = Int32.Parse(Session["BudOLServicesId"].ToString());
                    cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                    cmd.Parameters["@OrgId"].Value = Session["MgrId"].ToString();
                    cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                    cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
                    cmd.Parameters.Add("@BudAmt", SqlDbType.Decimal);
                    if (tb.Text != "")
                    {
                        cmd.Parameters["@BudAmt"].Value = decimal.Parse(tb.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands);
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
           
			Session["ProjName"]=e.Item.Cells[1].Text;

            if (e.CommandName == "Steps")
            {
                Session["CUpdTT"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text;
                Session["PSEPId"] = lstTasks.SelectedValue;
                Session["ProcName"] = lstTasks.SelectedItem;
                Response.Redirect(strURL + "frmUpdTimetable.aspx?");
            }
            else if (e.CommandName == "Staff")
			{
                Session["CPStaff"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text; 
                Session["PSEPId"] = lstTasks.SelectedValue;
                Session["ProcName"] = lstTasks.SelectedItem;
				Session["SGFlag"]=null;
				Response.Redirect (strURL + "frmProcStaff.aspx?");
			}
            else if (e.CommandName == "Other")
            {
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text;
                Session["PSEPId"] = lstTasks.SelectedValue;
                Session["ProcName"] = lstTasks.SelectedItem;
                Session["CPRes"] = "frmProjects";
                Session["SGFlag"] = 0;
                Response.Redirect(strURL + "frmProcRes.aspx?");
            }
            else if (e.CommandName == "Status")
            {
                Session["CUpdProject"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Response.Redirect(strURL + "frmUpdProject.aspx?");

            }
            else if (e.CommandName == "Tasks")
            {
                Session["CT"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmTasks.aspx?");

            }
            else if (e.CommandName == "TimetableReport")
            {
                ParameterFields paramFields = new ParameterFields();
                ParameterField paramField = new ParameterField();
                ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
                paramField.ParameterFieldName = "ProjectsId";
                discreteval.Value = e.Item.Cells[0].Text;
                paramField.CurrentValues.Add(discreteval);
                paramFields.Add(paramField);
                Session["ReportParameters"] = paramFields;
                Session["ReportName"] = "rptTTInd.rpt";
                rpts();
            }
            else if (e.CommandName == "Clients")
            {
                Session["CPSEPC"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmPSEPClient.aspx?");
            }
            else if (e.CommandName == "Resources")
            {
                Session["COrgLocSEProcs"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmOrgLocSEProcs.aspx?");
            }
            /*else if (e.CommandName == "Pay")
            {
                Session["CPay"]="frmProjectsInd";
                //Session["PSEventsId"] = e.Item.Cells[0].Text;- Session["PSEventsId"]
                //Session["EventName"]Session["EventName"] 
                Session["ProcProcuresId"] = e.Item.Cells[0].Text;
                //Session["CPay"]="frmContracts";
                //Session["LocName"]=e.Item.Cells[1].Text; - Session["LocationName"]
                Session["TaskName"]=e.Item.Cells[3].Text;
                Session["SupplierName"]=e.Item.Cells[5].Text;
                Session["GSName"]=e.Item.Cells[6].Text;
                Response.Redirect (strURL + "frmPayments.aspx?");
            }*/
            else if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_DeleteProjOrgLoc";
                cmd.Parameters.Add("@ProjectsId", SqlDbType.Int);
                cmd.Parameters["@ProjectsId"].Value = Int32.Parse(e.Item.Cells[0].Text);
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData1();
            }
            else if (e.CommandName == "Cancel")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_UpdateProjectC";
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(e.Item.Cells[0].Text);
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Value = 3;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData1();
            }
            else if (e.CommandName == "DeActivate")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_UpdateProjectC";
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(e.Item.Cells[0].Text);
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Value = 2;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData1();
            }
            else if (e.CommandName == "Activate")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_UpdateProjectC";
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(e.Item.Cells[0].Text);
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                cmd.Parameters["@Status"].Value = 1;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData1();
            }
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CPSel"]="frmProjects";
			Response.Redirect (strURL + "frmProjectsSel.aspx?");
		}
		protected void btnAddOth_Click(object sender, System.EventArgs e)
		{
			Session["CPSel"]="frmProjects";
			Response.Redirect (strURL + "frmProjectsSelO.aspx?");
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Session["CUpdProject"]="frmProjects";
			Response.Redirect (strURL + "frmUpdProject.aspx?");	
		}
        protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            updateBudAmt();
            Session["ProjName"] = e.Item.Cells[1].Text;
            if (e.CommandName == "Budget")
            {
                Session["CT"] = "frmProjects";
                Session["ProjectId"] = e.Item.Cells[0].Text;
                Session["ProjName"] = e.Item.Cells[1].Text;
                //Response.Redirect(strURL + "frmTasks.aspx?");
                Response.Redirect(strURL + "frmProcSReq.aspx?");

            }

        }
        protected void btnAddExt_Click(object sender, EventArgs e)
        {

        }
        
        
        //Set Tasks
        private void loadTasks()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveProfileSEProcs";
            cmd.Parameters.Add("@ProfileSEventsId", SqlDbType.Int);
            cmd.Parameters["@ProfileSEventsId"].Value = Int32.Parse(Session["PSEventsId"].ToString());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Tasks");
            if (ds.Tables["Tasks"].Rows.Count == 0)
            {
                TaskCount= 0;
            }
            else if (ds.Tables["Tasks"].Rows.Count == 1)
            {
                TaskCount = 1;
            }
            lstTasks.DataSource = ds;
            lstTasks.DataMember = "Tasks";
            lstTasks.DataTextField = "Name";
            lstTasks.DataValueField = "Id";
            lstTasks.DataBind();
        }
        protected void btnTask_Click(object sender, EventArgs e)
        {
            lblTask.Visible = false;
            lblTaskC.Visible = true;
            btnTask.Visible = false;
            lstTasks.Visible = true;

        }
        protected void lstTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTask.Visible = true;
            lblTaskC.Visible = false;
            btnTask.Visible = true;
            lstTasks.Visible = false;
            setTask();
        }
        private void setTask()
        {
            Session["TaskName"] = lstTasks.SelectedItem;
            Session["TasksId"] = lstTasks.SelectedValue;
            lblTask.Text = "Task: " + lstTasks.SelectedItem;
        }
        //End Set Tasks
}
}

