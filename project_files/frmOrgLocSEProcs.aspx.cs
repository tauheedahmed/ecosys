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
	public partial class frmOrgLocSEProcs: System.Web.UI.Page
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
                lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				
				if (Session["MgrOption"] == "Plan")
                {
                    lblOrg.Text=Session["MgrName"].ToString();
                    lblContents1.Text="Given below are the different types of procedures"
						+ " that are undertaken to deliver the above service."
						+ " Click on the appropriate button to assign resources as needed.";
                    DataGrid2.Visible = false;
                    loadData1();
				}
                else if (Session["MgrOption"] == "Budget")
                {
                    lblOrg.Text = Session["OrgName"].ToString();
                    lblContents1.Text = "Given below are the different types of procedures"
                        + " that are undertaken to deliver the above service."
                        + " You may now provide a for them as needed.";
                    DataGrid1.Visible = false;
                    loadData2();
                }
                
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
			
		}
		#endregion
		private void loadData1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveOrgLocSEProcs";
			if (Session["PRS"].ToString() == "1")
			{
				cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
				cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();	
			}
			cmd.Parameters.Add ("@ProfileServicesId",SqlDbType.Int);
			cmd.Parameters["@ProfileServicesId"].Value=Session["ProfileServicesId"].ToString();
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"OrgLocSEProcs");
			if (ds.Tables["OrgLocSEProcs"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.ForeColor=System.Drawing.Color.White;
				lblContents1.Text="Note:  There are no existing procedures identified for this service."
					+ " Please contact your system administrator.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid1();
			}
		private void refreshGrid1()
		{
            if ((Session["startForm"].ToString() == "frmMainWP") || (Session["startForm"].ToString() == "frmMainMgr"))
            {
                foreach (DataGridItem i in DataGrid1.Items)
                {
                    Button bnSt = (Button)(i.Cells[2].FindControl("btnStaff"));
                    Button bnO = (Button)(i.Cells[2].FindControl("btnOther"));
                    Button bnOutputs = (Button) (i.Cells[5].FindControl("btnOutputs"));
                    Button bnClients = (Button) (i.Cells[5].FindControl("btnClients"));
                    if (Int32.Parse(i.Cells[3].Text) > 0)
                    {
                        bnSt.Enabled = true;
                        bnSt.ForeColor = bnSt.BackColor;
                    }
                    else
                    {
                        bnSt.Visible = false;
                    }
                    
                    if (Int32.Parse(i.Cells[4].Text) > 0)
                    {
                        bnO.Enabled = true;
                        bnO.ForeColor = bnO.BackColor;
                    }
                    else
                    {
                        bnO.Visible = false;
                    }
                }
            }
            else if (Session["startForm"].ToString() == "frmMainBMgr")
            {
                foreach (DataGridItem i in DataGrid1.Items)
                {
                    Button bnO = (Button)(i.Cells[2].FindControl("btnOther"));
                    bnO.Visible = false;
                }
            }
		}
        private void loadData2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveOrgLocSEProcs";
            cmd.Parameters.Add("@ProfileServicesId", SqlDbType.Int);
            cmd.Parameters["@ProfileServicesId"].Value = Session["ProfileServicesId"].ToString();
            cmd.Parameters.Add("@OrgLocId", SqlDbType.Int);
            cmd.Parameters["@OrgLocId"].Value = Session["OrgLocId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "OrgLocSEProcs");
            if (ds.Tables["OrgLocSEProcs"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContents1.ForeColor = System.Drawing.Color.White;
                lblContents1.Text = "Note:  There are no existing procedures identified for this service."
                    + " Please contact your system administrator.";
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
                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtBud"));

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "fms_RetrieveBudProjProcs";
                cmd.Parameters.Add("@ProfileSEProcsId", SqlDbType.Int);
                cmd.Parameters["@ProfileSEProcsId"].Value = Int32.Parse(i.Cells[9].Text);
                cmd.Parameters.Add("@OrgLocId", SqlDbType.Int);
                cmd.Parameters["@OrgLocId"].Value = Int32.Parse(Session["OrgLocId"].ToString());
                cmd.Parameters.Add("@BudOLServiceId", SqlDbType.Int);
                cmd.Parameters["@BudOLServiceId"].Value = Int32.Parse(Session["BudOLServicesId"].ToString());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Tasks");
                if (ds.Tables["Tasks"].Rows.Count != 0)
                {
                    tb.Text = ds.Tables["Tasks"].Rows[0][0].ToString();
                    i.Cells[4].Text = "y";
                }
                else
                {
                    tb.Text = null;
                }
            }
        }

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            if (Session["MgrOption"].ToString() == "Budget")
            {
                updateBudAmt();
            }
            Exit();			
		}
        private void updateBudAmt()
        {
            foreach (DataGridItem i in DataGrid2.Items)
            {

                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtBud"));
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdateBudProjectProcAmt";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Flag", SqlDbType.Int);
                    if (i.Cells[4].Text == "y")
                    {
                        cmd.Parameters["@Flag"].Value = 1;
                    }
                   
                    cmd.Parameters.Add("@PSEPId", SqlDbType.Int);
                    cmd.Parameters["@PSEPId"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
                    cmd.Parameters["@BudgetsId"].Value = Int32.Parse(Session["BudgetsId"].ToString());
                    cmd.Parameters.Add("@OrgLocId", SqlDbType.Int);
                    cmd.Parameters["@OrgLocId"].Value = Int32.Parse(Session["OrgLocId"].ToString());
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

		private void Exit()
		{
			Response.Redirect (strURL + Session["COrgLocSEProcs"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		
        
        protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
        {

        }
        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Task")
				{
				Session["CProj"]="frmOrgLocSEProcs";
				Session["ProcName"]=e.Item.Cells[1].Text;
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmOLPProjects.aspx?");
				}
                else if (e.CommandName == "Outputs")
                {
                    Session["CPSEPO"] = "frmOrgLocSEProcs";
                    Session["ProcessName"] = e.Item.Cells[1].Text;
                    Session["PSEPID"] = e.Item.Cells[0].Text;
                    //Session["RType"] = 1;
                    Response.Redirect(strURL + "frmPSEPO.aspx?");
                }
                else if (e.CommandName == "Clients")
                {
                    Session["CPSEPC"] = "frmOrgLocSEProcs";
                    Session["ProcessName"] = e.Item.Cells[1].Text;
                    Session["PSEPID"] = e.Item.Cells[0].Text;
                    Response.Redirect(strURL + "frmPSEPClient.aspx?");
                }
				else if (e.CommandName == "Staff")
				{
					Session["PSEPID"]=e.Item.Cells[0].Text;
					Session["ProcName"]=e.Item.Cells[1].Text;
					if (Session["startForm"].ToString() == "frmMainBMgr")
					{
						Session["CBudSerWS"]="frmOrgLocSEProcs";
						Session["GS"]="Staff";
						Response.Redirect (strURL + "frmBudStaffWorkSheet.aspx?");
					}
					else
					{
						Session["CPStaff"]="frmOrgLocSEProcs";
						Response.Redirect (strURL + "frmProcStaff.aspx?");
					}
					
				}
				else if (e.CommandName == "Services")
				{	
					Session["PSEPID"]=e.Item.Cells[0].Text;
					Session["ProcName"]=e.Item.Cells[1].Text;
					if (Session["startForm"].ToString() == "frmMainBMgr")
					{
						Session["CBudSerWS"]="frmOrgLocSEProcs";
						Session["GS"]="Staff";
						Response.Redirect (strURL + "frmBudSerWorkSheet.aspx?");
					}
					else
					{	Session["CPRes"]="frmOrgLocSEProcs";
						Session["RType"]=1;
						Response.Redirect (strURL + "frmProcRes.aspx?");
					}
					
				}
				else if (e.CommandName == "Other")
				{
				Session["CPRes"]="frmOrgLocSEProcs";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["RType"]=0;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcRes.aspx?");
				}
				else if (e.CommandName == "Timetable")
				{
					Session["CUpdTT"]="frmOrgLocSEProcs";
					Session["PSEPId"]=e.Item.Cells[0].Text;
					Session["ProcName"]=e.Item.Cells[1].Text;
					Response.Redirect (strURL + "frmUpdTimetable.aspx?");
				}
        }
}

}

