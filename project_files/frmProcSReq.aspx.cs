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
	public partial class frmProcSReq: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
        int StaffActionID=0;
        int StaffActionFlag = 0;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{
                lblLoc.Text = "Location: " + Session["LocName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();

                if (Session["MgrOption"].ToString() == "Plan")
                {
				    lblOrg.Text = Session["OrgName"].ToString();
                    lblBd.Visible = false;
                    lblRole.Text="Role: " + Session["PSEPSName"].ToString();
				    lblContents.Text="You may now assign one or more individuals to play the above role"
					    + " and/or update existing assignments.";
                    if (Session["TRS"].ToString() == "0")
                    {
                        DataGrid1.Columns[4].Visible = false;
                    }

                    if (Session["PRS"].ToString() == "1")
                    {
                        lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
                        lblTask.Text = Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Procedure: " + Session["ProcName"].ToString() + ")";
                    }
                    else
                    {
                        lblEventName.Text = "Procedure: " + Session["ProcName"].ToString();
                    }
                    if (Session["PeopleId"] != null)
                    {
                        assignStaffAction();
                        if (StaffActionFlag == 2)
                        {
                            DataGrid1.Visible = false;
                            DataGrid3.Visible = true;
                            lblContents.Visible = false;
                
                            lblContents1.Text = "The individual you selected has more than one appointment.  Please select"
                                + " the appointment against which staff costs for this assignment will apply.";
                            lblMsg.Text = Session["PeopleName"].ToString();
                            btnOK.Visible = false;
                            btnAdd.Visible = false;
                            btnAddNew.Visible = false;
                        }
                        else
                        {
                            AddProcSReq();
                            Session["PeopleId"] = null;
                            StaffActionID = 0;
                            StaffActionFlag = 0;
                            DataGrid1.Visible = true;
                            DataGrid2.Visible = false;
                            DataGrid3.Visible = false;
                            DataGrid1.Columns[4].Visible = false;
                            
                        }                        
                    }
                    loadData1();
                    
                }
                else if (Session["MgrOption"].ToString() == "Budget")
                {
				   
                    lblOrg.Text = Session["MgrName"].ToString();
                    lblContents.Text="You may now budget against the planned staffing";
                    
		            if (Session["PRS"].ToString() == "1")
                    {
                        lblTask.Text = Session["PJNameS"].ToString() + ": "
                            + Session["ProjName"].ToString();
                    }
                    DataGrid1.Visible = false;
                    DataGrid2.Visible = true;
                    loadData2();
                }
			}
		}
		private void loadData1()
		{
            //lblOrg.Text = "org:" + Session["OrgId"].ToString() + "LOC:" + Session["LocationsId"].ToString() + "PSEPSID:" + Session["PSEPSID"].ToString();
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrievePSEPSPeople";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
            cmd.Parameters.Add("@PSEPSID", SqlDbType.Int);
            cmd.Parameters["@PSEPSID"].Value = Int32.Parse(Session["PSEPSID"].ToString());
			if (Session["PRS"].ToString() == "1")
			{
				cmd.Parameters.Add("@ProjectId",SqlDbType.Int);
				cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			}
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcS");
			if (ds.Tables["ProcS"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="Note:  There is no one assigned to the above role"
					+ ". Click on 'Add' to assign staff.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
            refreshGrid1();
		}
        
        private void refreshGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtPlan"));
                if (i.Cells[6].Text == "&nbsp;")
                {
                    tb.Text = null;
                }
                else
                {
                    tb.Text = i.Cells[6].Text;
                }
                DropDownList dl =(DropDownList) (i.Cells[2].FindControl("lstTimeMeasure"));
                dl.SelectedIndex = GetIndexOfTimeMeasure(i.Cells[7].Text);
                DropDownList dlb = (DropDownList)(i.Cells[3].FindControl("lstFunds"));

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "fms_RetrieveFunds";
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                /*cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();*/
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Funds");
                dlb.DataSource = ds;
                dlb.DataMember = "Funds";
                dlb.DataTextField = "Name";
                dlb.DataValueField = "Id";
                dlb.DataBind();
                dlb.SelectedIndex = dlb.Items.IndexOf(dlb.Items.FindByValue(i.Cells[12].Text));               
            }
        }
        /*private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[10].FindControl("cbxBackup"));
                DropDownList dl = (DropDownList)(i.Cells[11].FindControl("lstFunds"));
                TextBox tQ = (TextBox)(i.Cells[2].FindControl("txtQty"));
                //TextBox tP = (TextBox)(i.Cells[3].FindControl("txtPrice"));

                if (i.Cells[14].Text == "1")
                {
                    cb.Checked = true;
                }

                if (i.Cells[5].Text.StartsWith("&") == false)
                {
                    tQ.Text = i.Cells[5].Text;
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fms_RetrieveBudOrgsId";
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "BudOrgs");

                dl.DataSource = ds;
                dl.DataMember = "BudOrgs";
                dl.DataTextField = "Name";
                dl.DataValueField = "Id";
                dl.DataBind();
                dl.SelectedIndex = dl.Items.IndexOf(dl.Items.FindByValue(i.Cells[15].Text));
            }
        }*/
        private void loadData2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrievePSEPSPBud";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["MgrId"].ToString());
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
            if (Session["PRS"].ToString() == "1")
            {
                cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
                cmd.Parameters["@ProjectId"].Value = Session["ProjectId"].ToString();
            }
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ProcS");
            if (ds.Tables["ProcS"].Rows.Count == 0)
            {
                DataGrid2.Visible = false;
                lblContents.Text = "Note:  There is no one assigned to the above role"
                    + ". Click on 'Add' to assign staff.";
            }
            Session["ds"] = ds;
            DataGrid2.DataSource = ds;
            DataGrid2.DataBind();
        }
        private void AddProcSReq()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_AddPSEPSPeople";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@PSEPSId", SqlDbType.Int);
            cmd.Parameters["@PSEPSId"].Value = Session["PSEPSId"].ToString(); 
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
            
            if (Session["PeopleId"] != null)
            {
                cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                cmd.Parameters["@PeopleId"].Value = Session["PeopleId"].ToString();
            }
           
            if (Session["PRS"].ToString() == "1")
            {
                cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
                cmd.Parameters["@ProjectId"].Value = Session["ProjectId"].ToString();
            }
            if (StaffActionFlag != 0)
            {
                cmd.Parameters.Add("@StaffActionsId", SqlDbType.Int);
                cmd.Parameters["@StaffActionsId"].Value = StaffActionID;
            }
           
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        private void assignStaffAction()
        {
            SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveSAPeople";
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Int32.Parse(Session["PeopleId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SA");
            if (ds.Tables["SA"].Rows.Count == 1)
            {
                StaffActionFlag = 1;
                StaffActionID = Int32.Parse(ds.Tables["SA"].Rows[0][0].ToString());
                
            }
            else if (ds.Tables["SA"].Rows.Count == 0)
            {
                
                lblMsg.Text = "There is no staff action for this individual.  Therefore"
                    + " this task assignment does not constitute a commitment to accept charges against the budget.";
            }
             else
            {
            StaffActionFlag = 2;
            Session["ds"] = ds;
            DataGrid3.DataSource = ds;
            DataGrid3.DataBind();
            }
        }
        protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                StaffActionID = Int32.Parse(e.Item.Cells[0].Text);
                StaffActionFlag = 2;
                AddProcSReq();
                Session["PeopleId"] = null;
                Session["PeopleName"] = null;
                lblMsg.Text = "";
                StaffActionID = 0;
                StaffActionFlag = 0;
                lblContents1.Text = "";
                btnOK.Visible = true;
                btnAdd.Visible = true;
                btnAddNew.Visible = true;
                DataGrid1.Visible = true;
                DataGrid2.Visible = false;
                DataGrid3.Visible = false;
                DataGrid1.Columns[4].Visible = false;
            }
        }
        private void computeCost()
        {
            //Find OrgStaffType
            //Present Salary Level
            //Assign
        }
        private void UpdateProcSReq()
        {
            float r = 1;       
            foreach (DataGridItem i in DataGrid1.Items)
            {
                if (r == 0)
                {
                    break;
                }
                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtPlan"));
                DropDownList dl = (DropDownList) (i.Cells[2].FindControl("lstTimeMeasure"));
                DropDownList dlb = (DropDownList)(i.Cells[3].FindControl("lstFunds"));
                if (tb.Text.Trim() != "")
                {
                    string s = tb.Text.Trim();
                    bool result = float.TryParse(s, out r);
                    if (r == 0)
                    {
                        lblContents.Text = "Please enter valid number in the Column titled 'Planned Input'.";
                        break;
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "wms_UpdatePSEPSPeople";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                        cmd.Parameters.Add("@TimeMeasure", SqlDbType.Int);
                        cmd.Parameters["@TimeMeasure"].Value = Int32.Parse(dl.SelectedItem.Value);
                        cmd.Parameters.Add("@FundsId", SqlDbType.Int);
                        cmd.Parameters["@FundsId"].Value = Int32.Parse(dlb.SelectedItem.Value);
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal);
                        if (tb.Text != "")
                        {
                            cmd.Parameters["@Qty"].Value = decimal.Parse(tb.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                        }
                        cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                        if (i.Cells[11].Text != "&nbsp;")
                        {
                            cmd.Parameters["@PeopleId"].Value = Int32.Parse(i.Cells[11].Text);
                        }
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        r = 1;
                    }

                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdatePSEPSPeople";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@TimeMeasure", SqlDbType.Int);
                    cmd.Parameters["@TimeMeasure"].Value = Int32.Parse(dl.SelectedItem.Value);
                    cmd.Parameters.Add("@FundsId", SqlDbType.Int);
                    cmd.Parameters["@FundsId"].Value = Int32.Parse(dlb.SelectedItem.Value);
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal);
                    if (tb.Text != "")
                    {
                        cmd.Parameters["@Qty"].Value = decimal.Parse(tb.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    }
                    cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                    if (i.Cells[11].Text != "&nbsp;")
                    {
                        cmd.Parameters["@PeopleId"].Value = Int32.Parse(i.Cells[11].Text);
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            if (r == 1)
            {
                if (Session["MgrOption"].ToString() != "Plan")
                {
                    Response.Redirect(strURL + Session["COSA"].ToString() + ".aspx?");
                }
            }
        }

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
            Session["PeopleId"] = null;
            UpdateProcSReq();
            AddProcSReq();
            loadData1();
            /*Session["SA"] = "frmUpdProcSReq";
            Session["CUpdSAR"] = "frmProcSReq";
            Session["btnAction"] = "Add";
            Response.Redirect (strURL + "frmStaffActionsProc.aspx?");*/
		}
        
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            /*if (e.CommandName == "Update")
			 {
               Session["SA"] = "frmProcSReq";
                Session["ProcSARId"] = e.Item.Cells[0].Text;
			}
            else */
            if (e.CommandName == "Budget")
            { 
               /* Session["CUpdSAR"]="frmProcSReq";
				Session["btnAction"]="Update";
				Session["ProcSARId"]=e.Item.Cells[0].Text;
				Session["ContractId"]=e.Item.Cells[2].Text;
				Response.Redirect (strURL + "frmUpdProcSReq.aspx?");*/
            }
            else if (e.CommandName == "TRS")
            {
                Session["CTSA"] = "frmProcSReq";
                Session["ProcProcuresId"] = e.Item.Cells[0].Text;
                Session["PeopleName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmTSApprove.aspx?");
            }
            else if (e.CommandName == "Delete")
            {
                UpdateProcSReq();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[wms_DeletePSEPSPeople]";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = e.Item.Cells[0].Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData1();
            }
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            if (Session["MgrOption"].ToString() == "Plan")
            {
                Session["PeopleId"] = null;
                UpdateProcSReq();
                Response.Redirect(strURL + Session["COSA"].ToString() + ".aspx?");
            }
            else
            {
                if (Session["PRS"].ToString() == "1")
                {
                    Response.Redirect(strURL + "frmProjects.aspx?");
                }
                else
                {
                    Response.Redirect(strURL + "frmTasks.aspx?");
                }
            }

		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
            UpdateProcSReq();
            Session["PeopleId"] = null;
            Session["Update"] = "No";
            Session["CallerPeople"] = "frmProcSReq";
            Session["CSA"] = "frmProcSReq";//to feed frmUpdPeople if new person is identified
            Response.Redirect(strURL + "frmPeople.aspx?");
            
		}
        private int GetIndexOfTimeMeasure(string s)
        {
            if (s == "0")
            {
                return 0;
            }
            else if (s == "1")
            {
                return 1;
            }
            else if (s == "2")
            {
                return 2;
            }
            else if (s == "3")
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
       
}

}

