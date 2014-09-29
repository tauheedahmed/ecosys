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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmTasks: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblContents2;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadForm()
		{		
			if (Session["CT"].ToString() != "frmProjectsIndT")
			{
                btnBd.Visible = false;
				DataGrid1.Columns[8].Visible=false;
			}
			if (!IsPostBack)
			{
                if (Session["MgrName"] != null)
                {
                    lblMgr.Text=Session["MgrName"].ToString();
                }
                else
                {
                    lblMgr.Text = Session["OrgName"].ToString();
                }
				
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				lblLocation.Text="Location: " + Session["LocName"].ToString();
                if (Session["CProjects"] == "frmPSEvents")
                {
                    lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
                }
				lblProj.Text=Session["PJNameS"].ToString() + ": "
					+ Session["ProjName"].ToString();
                if (Session["MgrOption"].ToString() == "Budget")
                    {
                        lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                            + Session["CurrName"].ToString();
                    }
                else if (Session["BOId"] != null)
				{
					lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
						+ Session["CurrName"].ToString();
				}
				else
				{
					btnBd.Visible=false;
                    lblBd.Visible = false;
				}
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
            cmd.CommandText = "wms_RetrieveProfileSEProcs";
            cmd.Parameters.Add("@ProfileSEventsId", SqlDbType.Int);
            cmd.Parameters["@ProfileSEventsId"].Value = Int32.Parse(Session["PSEventsId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
			if (ds.Tables["Projects"].Rows.Count == 0)
			{
                DataGrid1.Visible=false;
                lblContents1.Text = "Sorry, there are no tasks/procedures defined for this type of "
                    + Session["PJNameS"].ToString()
                    + ". Please contact the system administrator if you think tasks need to be defined.";
			}
			else
			{
                lblContents1.Text = "Listed below are the "
                    + " tasks involved in carrying out the "
                    + Session["PJNameS"].ToString()
                    + " listed above."
                    + " You may enter start and end dates for the task below.  Click on 'Steps'"
                + " to enter start and end dates for each step involved in carrying out this task."
                + " All dates should be entered in form mm/dd/yyyy."
                + " You may also identify resource inputs required by clicking on 'Staff' and 'Good and Services'";
    
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
                refreshGrid();
			}
		}
        private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox txtStart = (TextBox)(i.Cells[2].FindControl("txtStartDate"));
                CheckBox cbStartStatus = (CheckBox)(i.Cells[3].FindControl("cbxStartStatus"));
                TextBox txtEnd = (TextBox)(i.Cells[4].FindControl("txtEndDate"));
                CheckBox cbEndStatus = (CheckBox)(i.Cells[5].FindControl("cbxEndStatus"));
                Button bnStep = (Button)(i.Cells[6].FindControl("btnSteps"));
                Button bnSt = (Button)(i.Cells[7].FindControl("btnStaff"));
                Button bnO = (Button)(i.Cells[7].FindControl("btnOther"));

                /******************************************
                 * Step 1:  Get Task start/end dates/status
                *******************************************/
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_RetrieveProjOLPSEP";
                cmd.Parameters.Add("@ProjectsId", SqlDbType.Int);
                cmd.Parameters["@ProjectsId"].Value = Session["ProjectId"].ToString();
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "ProjOLPSEP");

                if (ds.Tables["ProjOLPSEP"].Rows.Count == 0)
                {
                    txtStart.Text = "";
                    txtEnd.Text = "";
                    cbStartStatus.Checked = false;
                    cbEndStatus.Checked = false;
                }
                else
                {
                    i.Cells[9].Text = "1";
                    txtStart.Text = ds.Tables["ProjOLPSEP"].Rows[0][1].ToString();
                    txtEnd.Text = ds.Tables["ProjOLPSEP"].Rows[0][2].ToString();
                    if (ds.Tables["ProjOLPSEP"].Rows[0][3].ToString() == "1")
                    {
                        cbStartStatus.Checked = true;
                    }
                    else
                    {
                        cbStartStatus.Checked = false;
                    }
                    if (ds.Tables["ProjOLPSEP"].Rows[0][4].ToString() == "1")
                    {
                        cbEndStatus.Checked = true;
                    }
                    else
                    {
                        cbEndStatus.Checked = false;
                    }
                }
                /*********************************************
                 * Step 2:  Suppress buttons as appropriate to 
                 * avoid going to steps, staff, resources 
                 * if none defined in process model
                **********************************************/
                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Connection = this.epsDbConn;
                cmd1.CommandText = "wms_RetrieveProcFlags";
                cmd1.Parameters.Add("@PSEPID", SqlDbType.Int);
                cmd1.Parameters["@PSEPID"].Value = Int32.Parse(i.Cells[0].Text);
                DataSet ds1 = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1, "Tasks");
                if (ds1.Tables["Tasks"].Rows.Count == 0)
                {
                    bnO.Visible = false;
                    bnSt.Visible = false;
                    bnStep.Visible = false;
                    lblContents1.Text = "Listed below are the "
                    + " tasks involved in carrying out the "
                    + Session["PJNameS"].ToString()
                    + " listed above."
                    + " You may enter start and end dates for the task below.  "
                    + " All dates should be entered in form mm/dd/yyyy.";
                }
                else
                {
                    if (ds1.Tables["Tasks"].Rows[0][0].ToString() == "0")
                    {
                        bnSt.Visible = false;
                    }
                    if (ds1.Tables["Tasks"].Rows[0][1].ToString() == "0")
                    {
                         bnO.Visible = false;
                    }
                    if (ds1.Tables["Tasks"].Rows[0][2].ToString() == "0")
                    {
                        bnStep.Visible = false;
                    }
                }
               
            }
        }
        private void updProjOLPSEP()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox txtStart = (TextBox)(i.Cells[2].FindControl("txtStartDate"));
                CheckBox cbStartStatus = (CheckBox)(i.Cells[3].FindControl("cbxStartStatus"));
                TextBox txtEnd = (TextBox)(i.Cells[4].FindControl("txtEndDate"));
                CheckBox cbEndStatus = (CheckBox)(i.Cells[5].FindControl("cbxEndStatus"));
               
                if (i.Cells[9].Text.StartsWith("&") == false)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdateProjOLPSEP";
                    cmd.Connection = this.epsDbConn; 
                    cmd.Parameters.Add("@ProjectsId", SqlDbType.Int);
                    cmd.Parameters["@ProjectsId"].Value = Session["ProjectId"].ToString();
                    cmd.Parameters.Add("@PSEPID", SqlDbType.Int);
                    cmd.Parameters["@PSEPID"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@OrgLocationsId", SqlDbType.Int);
                    cmd.Parameters["@OrgLocationsId"].Value = Int32.Parse(Session["OrgLocId"].ToString());
                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                    if (txtStart.Text != "")
                    {
                        cmd.Parameters["@StartDate"].Value = txtStart.Text;
                    }
                    else
                    {
                        cmd.Parameters["@StartDate"].Value = null;
                    }
                    cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                    if (txtEnd.Text != "")
                    {
                        cmd.Parameters["@EndDate"].Value = txtEnd.Text;
                    }
                    else
                    {
                        cmd.Parameters["@EndDate"].Value = null;
                    }
                    cmd.Parameters.Add("@StartStatus", SqlDbType.Int);
                    if (cbStartStatus.Checked)
                    {
                        cmd.Parameters["@StartStatus"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@StartStatus"].Value = 0;
                    }
                    cmd.Parameters.Add("@EndStatus", SqlDbType.Int);
                    if (cbEndStatus.Checked)
                    {
                        cmd.Parameters["@EndStatus"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@EndStatus"].Value = 0;
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                else
				{
                    SqlCommand cmd = new SqlCommand();					
					cmd.CommandType=CommandType.StoredProcedure;
                    cmd.CommandText = "wms_addProjOLPSEP";
					cmd.Connection=this.epsDbConn;
                    cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
                    cmd.Parameters["@ProjectId"].Value = Session["ProjectId"].ToString();
                    cmd.Parameters.Add("@PSEPID", SqlDbType.Int);
                    cmd.Parameters["@PSEPID"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@OrgLocationsId", SqlDbType.Int);
                    cmd.Parameters["@OrgLocationsId"].Value = Int32.Parse(Session["OrgLocId"].ToString());
                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                    
                    if (txtStart.Text != "")
                    {
                        cmd.Parameters["@StartDate"].Value = txtStart.Text;
                    }
                    else
                    {
                        cmd.Parameters["@StartDate"].Value = null;
                    }
                    cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                    if (txtEnd.Text != "")
                    {
                        cmd.Parameters["@EndDate"].Value = txtEnd.Text;
                    }
                    else
                    {
                        cmd.Parameters["@EndDate"].Value = null;
                    }
                    cmd.Parameters.Add("@StartStatus", SqlDbType.Int);
                    if (cbStartStatus.Checked)
                    {
                        cmd.Parameters["@StartStatus"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@StartStatus"].Value = 0;
                    }
                    cmd.Parameters.Add("@EndStatus", SqlDbType.Int);
                    
                    if (cbEndStatus.Checked)
                    {
                        cmd.Parameters["@EndStatus"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@EndStatus"].Value = 0;
                    }
					
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
            }
        }

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            updProjOLPSEP();
            Exit();
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CT"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CPSel"]="frmProjectsInd";
			Response.Redirect (strURL + "frmProjectsSel.aspx?");			
		}
		private void rpts()
		{
			Session["cRG"]="frmProjectsInd";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			if (e.CommandName == "Steps")
			{
				Session["CUpdTT"]="frmTasks";
				Session["PSEPId"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmUpdTimetable.aspx?");
			}
			else if (e.CommandName == "Clients")
			{
				Session["CPClient"]="frmTasks";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmProcClient.aspx?");
			}
			else if (e.CommandName == "Staff")
			{
				Session["CPStaff"]="frmTasks";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Session["SGFlag"]=null;
				//if (Session["BOId"] != null)
				//{
				Response.Redirect (strURL + "frmProcStaff.aspx?");
				//}
				//else
				//{
				//	Session["CBudOrgs"]="frmTasks";
				//	Response.Redirect (strURL + "frmBudOrgsWP.aspx?");
				//}
			}
			else if (e.CommandName == "Services")
			{
				Session["CPRes"]="frmTasks";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Session["SGFlag"]=1;
				Session["RType"]=1;
				//if (Session["BOId"] != null)
				//{
				Response.Redirect (strURL + "frmProcRes.aspx?");
				//}
				//else
				//{
				//	Session["CBudOrgs"]="frmTasks";
				//	Response.Redirect (strURL + "frmBudOrgsWP.aspx?");
				//}
			}			
			else if (e.CommandName == "Other")
			{
				Session["CPRes"]="frmTasks";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=0;
				Session["ProcName"]=e.Item.Cells[1].Text;
                if (Session["MgrOption"].ToString() == "Plan")
                {
                    Response.Redirect(strURL + "frmProcRes.aspx?");
                }
				else if (Session["BOId"] != null)
				{
					Response.Redirect (strURL + "frmProcRes.aspx?");
				}
				else
				{
					Session["CBudOrgs"]="frmTasks";
					Response.Redirect (strURL + "frmBudOrgsWP.aspx?");
				}
			}
		}

		protected void btnBd_Click(object sender, System.EventArgs e)
		{
			Session["CBudOrgs"]="frmTasks";
			Session["BudChange"]="1";
			Response.Redirect (strURL + "frmBudOrgsWP.aspx?");
		}
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Exit();
        }

        protected void StartDate_TextChanged(object sender, EventArgs e)
        {
            lblService.Text = "hellotxtox";
        }
}
}

