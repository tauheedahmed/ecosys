using System;
using System.Collections;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmUpdProcSReq: System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		protected System.Web.UI.HtmlControls.HtmlForm frmAddProcSAR;
		protected System.Web.UI.WebControls.Label Label2;
		private int GetIndexOfAptType (string s)
		{
			return (lstAptTypes.Items.IndexOf (lstAptTypes.Items.FindByValue(s)));
		}
		private int GetIndexOfTimeMeasure (string s)
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
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                /************************************************************
                 * 1.  Headings
                *************************************************************/
                if (Session["startForm"].ToString() == "frmMainWP")
                {
                    if (Session["EPS"].ToString() == "1")
                    {
                        lblBackup.Visible = true;
                        cbxBackup.Visible = true;
                    }
                }
                if (Session["startForm"].ToString() == "frmMainWP")
                {
                    lblOrg.Text = Session["OrgName"].ToString();
                }
                else if (Session["MgrName"] != null)
                {
                    lblOrg.Text = Session["MgrName"].ToString();
                }
                lblLoc.Text = "Location: " + Session["LocationName"].ToString();
                lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                    + Session["CurrName"].ToString();
                lblService.Text = "Service: " + Session["ServiceName"].ToString();
                if (Session["CBudOrgs"] !=null)
                {
                    if (Session["PRS"].ToString() == "1")
                    {
                        lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
                        lblTask.Text = Session["PJNameS"].ToString() + ": "
                            + Session["ProjName"].ToString()
                            + " (Task: " + Session["ProcName"].ToString() + ")";
                    }
                    else 
                    {
                        lblEventName.Text = "Task: " + Session["ProcName"].ToString();
                    }
                }
                lblRole.Text = "Staff Role: " + Session["PSEPSName"].ToString();
                btnAction.Text = Session["btnAction"].ToString();
                lblContent1.Text = "";

                /************************************************************
                * 2.  Activate List Box for Appointment Types
                *************************************************************/
                loadAptTypes();
                /************************************************************
                * 3.  If new, load Staff Action Data
                *     If existing, load a.  ProcProcure Data, b.  StaffAction Data
                *************************************************************/
                if (Session["btnAction"].ToString() == "Add")
                {
                    if (Session["StaffActionId"] != null)//i.e. if StaffAction has been identified from frmStaffActionsProc
                    {
                        loadStaffAction();
                        //lstTimeMeasure.SelectedItem.Value="2";
                    }
                    //else go to 4.
                }
                else
                {
                    Id = Session["ProcSARId"].ToString();
                    loadProcProcure();
                    lstAptTypes.SelectedIndex = GetIndexOfAptType(Session["OSTId"].ToString());
                    if (Session["StaffActionId"] != null)
                    {
                        loadStaffAction();
                    }
                   else if (Session["ContractId"] != null)
                    {
                        loadStaffAction();
                    } 
                }
                /************************************************************
                * 4.  Determine Budget Amounts incl. currency conversions
                *     
                *************************************************************/
                loadStaffTypeDetails();
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
        private void loadProcProcure()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "RetrieveTaskBudgets";
            cmd.Parameters.Add("@Id", SqlDbType.Int);
            cmd.Parameters["@Id"].Value = Session["ProcSARId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "PP");
            // 2/28 txtDesc.Text=ds.Tables["PP"].Rows[0][0].ToString();
            if (ds.Tables["PP"].Rows.Count != 0)
            {
                txtTime.Text = ds.Tables["PP"].Rows[0][1].ToString();
                Session["TypeId"] = ds.Tables["PP"].Rows[0][4].ToString();
                Session["BudProvider"] = ds.Tables["PP"].Rows[0][7].ToString();
                Session["BudName"] = ds.Tables["PP"].Rows[0][8].ToString();
                Session["BudStatus"] = ds.Tables["PP"].Rows[0][9].ToString();
                Session["ReqAmount"] = ds.Tables["PP"].Rows[0][10].ToString();
                Session["BudAmount"] = ds.Tables["PP"].Rows[0][11].ToString();
                if (ds.Tables["PP"].Rows[0][12].ToString() == "1")
                {
                    cbxBackup.Checked = true;
                }
                if (ds.Tables["PP"].Rows[0][10].ToString() != "")
                {
                    Session["Bud"] = ds.Tables["PP"].Rows[0][10].ToString();
                }

                lstTimeMeasure.SelectedIndex = GetIndexOfTimeMeasure(ds.Tables["PP"].Rows[0][6].ToString());
                if (ds.Tables["PP"].Rows[0][3].ToString() != "")
                {
                    Session["ContractId"] = ds.Tables["PP"].Rows[0][3].ToString();
                }
                else
                {
                    Session["ContractId"] = null;
                    if (ds.Tables["PP"].Rows[0][4].ToString() != "")
                    {
                        Session["TypeId"] = Int32.Parse(ds.Tables["PP"].Rows[0][4].ToString());
                    }
                    /*if (ds.Tables["PP"].Rows[0][5].ToString() != "")
                    {
                        Session["SalaryRate"] = ds.Tables["PP"].Rows[0][5].ToString();
                    }*/
                }
            }
        }
		private void loadStaffAction()
		{
			lblAptStatus.Visible=false;
			lstAptTypes.Visible=false;
			Session["ExchRate"] = null;
			
            //float Salary=0;

			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveProcSReqSA";
			if (Session["BRS"].ToString() == "1")
			{
				cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
				cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();			
			}
			cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
			if (Session["StaffActionId"] != null)
			{
				cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["StaffActionId"].ToString());
			}
			else if (Session["ContractId"] != null)
			{
				cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["ContractId"].ToString());
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SAR");				
			lblName.Text="Person Assigned: " + ds.Tables["SAR"].Rows[0][0].ToString();
			lblAptType.Text="Appointment Status: " + ds.Tables["SAR"].Rows[0][1].ToString();
			Session["TypeIdSA"]=Int32.Parse(ds.Tables["SAR"].Rows[0][9].ToString());
			Session["OrgIdSA"]=Int32.Parse(ds.Tables["SAR"].Rows[0][10].ToString());
			Session["ExchRate"]=ds.Tables["SAR"].Rows[0][14].ToString();

			if (ds.Tables["SAR"].Rows[0][8].ToString() == "")
			{
				if (Session["ContractId"] != null)
				{
					//btnSA.Visible=false;
				}
			}
			Session["SalaryRateSA"] = ds.Tables["SAR"].Rows[0][2].ToString();
			Session["SalaryPeriod"]=ds.Tables["SAR"].Rows[0][6].ToString();
		}
        /* *************************************************************************************/
        /* *************************************************************************************/
        /* Load Staff Type Related Data and recalculate amount requested                     **/
        /* *************************************************************************************/
        /* *************************************************************************************/	
		private void loadStaffTypeDetails()
		{
			/* ********************************************************************************************/
            /* Step 1a:  Retreive Staff Type Related Data                                                **/
            /* ********************************************************************************************/
                SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
            
				cmd.CommandText="hrs_RetrieveStaffTypeDetails";
                cmd.Parameters.Add("@OrgStaffTypesId", SqlDbType.Int);
				if (Session["StaffActionId"] != null)//i.e. if StaffAction has been identified from frmStaffActionsProc
				{
					cmd.Parameters["@OrgStaffTypesId"].Value=Int32.Parse(Session["TypeIdSA"].ToString());
				}
				else
				{
                    cmd.Parameters["@OrgStaffTypesId"].Value = lstAptTypes.SelectedItem.Value;
				}
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"ost");
                /* ********************************************************************************************/
                /* Step 1b:  Retreive Budget Related Data                                                     **/
                /* ********************************************************************************************/
                /*SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Connection = this.epsDbConn;
                cmd1.CommandText = "bud_RetrieveExchangeRate";
                cmd1.Parameters.Add("@BudgetsId", SqlDbType.Int);
                cmd1.Parameters["@BudgetsId"].Value = Int32.Parse(Session["BudgetsId"].ToString());
                DataSet ds1 = new DataSet();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(ds1, "bud");*/
            /* ********************************************************************************************/
            /* Step 2a:  If there is no Budget Structure set up, generate message and go no further ``````**/
            /* ********************************************************************************************/
                /*if (ds.Tables["ost"].Rows[0][2].ToString() == "")
                    {
                        Session["ExchRate"] = 1;
                    }
                    else
                    {
                        Session["ExchRate"] = ds.Tables["ost"].Rows[0][2].ToString();
                    }
                Session["ExchRate"] = 1;
                if (Session["ExchRate"] == null)
                {
                    lblContent1.Text = "Note:  You cannot assign staff to any task for this organization until"
                        + " the budget structures has been set up for this organization."
                        + " Please contact your System Administrator to make sure this is done. Press 'OK' to continue. ";
                }*/
            
            /* ********************************************************************************************/
            /* Step ab:  If there is no Staff Structure set up, generate message and go no further **/
            /* ********************************************************************************************/
			if (ds.Tables["ost"].Rows.Count == 0)
			{
				lblContent1.Text="Note:  You cannot assign staff to any task for this organization until"
					+ " the staffing structures has been fully set up for this organization."
                    + " Please contact your System Administrator to make sure this is done. Press 'OK' to continue. ";
				btnAction.Text="OK";
				btnCancel.Visible=false;
				btnSA.Visible=false;
				lstAptTypes.Visible=false;
                /* 2/28 lblDesc.Visible = false;
				txtDesc.Visible=false;*/
				txtTime.Visible=false; 
				lstTimeMeasure.Visible=false;
			}
            /* *************************************************************************************/
            /* Step 2:  Normalize salary period, the                                              **/
            /*          measure of quantity for staff time input, and exchange rate               **/
            /*          indicated on the form                                                     **/
            /* *************************************************************************************/
			else
			{
				Session["SalaryPeriod"]=ds.Tables["ost"].Rows[0][1].ToString();
                if (Session["StaffActionId"] != null)
                {
                    Session["SalaryRate"] = Session["SalaryRateSA"];
                }
                else if (Session["ContractId"] != null)
                {
                    Session["SalaryRate"] = Session["SalaryRateSA"];
                }
                else
                {
                    Session["SalaryRate"] = decimal.Parse(ds.Tables["ost"].Rows[0][2].ToString());
                   
                }
                
                Session["ExchRate"] = 1;
                /*if (Session["ExchRate"] == null)
                {
                    lblContent1.Text = "Note:  You cannot assign staff to any task for this organization until"
                        + " the budget structures has been set up for this organization."
                        + " Please contact your System Administrator to make sure this is done. Press 'OK' to continue. ";
                }*/
				int TimeMeasure;
				int SalaryPeriod;
				switch (Session["SalaryPeriod"].ToString())
				{
					case "":
					case "Year":
						SalaryPeriod = 12 * 4 * 5 * 8;
						break;
					case "Month":
						SalaryPeriod = 4 * 5 * 8;
						break;
					case "Week":
						SalaryPeriod = 5 * 8;
						break;
					case "Day":
						SalaryPeriod = 8;
						break;
					default:
						SalaryPeriod = 1;
						break;
				}
				switch (Int32.Parse(lstTimeMeasure.SelectedItem.Value))
				{
					case 0:
						TimeMeasure = 12 * 4 * 5 * 8;
						break;
					case 1:
						TimeMeasure = 4 * 5 * 8;
						break;
					case 2:
						TimeMeasure = 5 * 8;
						break;
					case 3:
						TimeMeasure = 8;
						break;
					default:
						TimeMeasure = 1;
						break;
				}

 
                
                /* *************************************************************************************/
                /* Step 3:  If there is a Staff Structure set up, normalize salary period and the     **/
                /*          measure of quantity for staff time input indicated on the form            **/
                /* *************************************************************************************/
				if (Session["BRS"].ToString() == "1")
				{
					if ((txtTime.Text != "") & (Session["SalaryRate"] != null))
					{
                        Session["BudReq"] =
                                decimal.Round((decimal.Parse(Session["SalaryRate"].ToString())
                                * TimeMeasure
                                * decimal.Parse(Session["ExchRate"].ToString())
                                * decimal.Parse(txtTime.Text) / SalaryPeriod),2);
						lblBud.Text="Required Budget: "
                            + Session["BudReq"].ToString()
							/*+ decimal.Round(((decimal.Parse(Session["SalaryRate"].ToString()) 
							* TimeMeasure * decimal.Parse(txtTime.Text))/SalaryPeriod),2) ta 8/14/09*/
							+ " " 
							+ ds.Tables["ost"].Rows[0][0].ToString();
                        if (ds.Tables["ost"].Rows[0][0].ToString() != Session["CurrName"].ToString())
                        {
                            lblBudget.Visible = true;
                            lblBudget.Text =
                                "(Converted from "
                                + ds.Tables["ost"].Rows[0][0].ToString()
                                + " using the budgeted exchange rate of "
                                + Session["ExchRate"].ToString()
                                + ")";
                        }
				
						if (Session["btnAction"].ToString() == "Add")
						{
                           /* Session["BudReq"] =
                                (decimal.Parse(Session["SalaryRate"].ToString())
                                * TimeMeasure
								* decimal.Parse(Session["ExchRate"].ToString())
                                * decimal.Parse(txtTime.Text) / SalaryPeriod);
						
							if (ds.Tables["ost"].Rows[0][0].ToString() != Session["CurrName"].ToString())
							{
								lblBudget.Text=
									"(Converted from "
									+ ds.Tables["ost"].Rows[0][0].ToString()
									+ " using the budgeted exchange rate of "
									+ Session["ExchRate"].ToString()
									+ ")";
							}*/
						}
						else if (Session["BudAmount"].ToString() != "")
						{
							if (Session["ReqAmount"].ToString() != Session["BudAmount"].ToString())
							{
								lblBudget.Text=
									"Note: Amount requested above differs from"
									+ " amount approved, which is: "
									+ Session["BudAmount"].ToString()
									+ " " + Session["CurrName"].ToString();
							}
						}
					}
					else if ((txtTime.Text != "") & (Session["SalaryRate"] == null))
					{
						lblBud.Text="Required Budget cannot be determined:  Salary Rate not indicated for this appointment.";
					}
                    else if ((txtTime.Text == "") & (Session["SalaryRate"] == null))
					{
						lblBud.Text="Required Budget cannot be determined:  Time Input not indicated for this request.";
					}
					else 
					{
						lblBud.Text="Required Budget cannot be determined:  Time Input and Salary Rate not indicated for this request.";
					}
				}
                /* *************************************************************************************/
                /* Step 4:  Set Labels                                     **/
                /* *************************************************************************************/
                lblSalaryPeriod.Text = "Salary/Fee Rate: " + Session["SalaryRate"].ToString() + " " + ds.Tables["ost"].Rows[0][0].ToString()
                        + " per " + ds.Tables["ost"].Rows[0][1].ToString();
			}
		}
        private void setLabels()
        {
            if (Session["BRS"].ToString() == "0")
            {

               
                lblBud.Visible = false;
                btnBud.Visible = false;
                lblBudName.Visible = false;
                lblSalaryPeriod.Visible = false;
            }
            else if (Session["PRS"].ToString() == "0")
            {
                lblBudName.Text =
                    "Budget Provider: "
                    + Session["BProv"].ToString()
                    + " Budget Title: "
                    + Session["BudName"].ToString();
                btnBud.Visible = false;

            }
            else if (Session["BudSel"] != null)
            {
                if (Session["startForm"].ToString() == "frmOrgLocInd")
                {
                    lblBudName.Text =
                        "Budget Provider: "
                        + Session["BProvSel"].ToString()
                        + " Budget Title: "
                        + Session["BudNameSel"].ToString();
                    btnBud.Text = "Change Budget";
                }
            }
            else if (Session["btnAction"].ToString() == "Update")
            {
                lblBudName.Text =
                    "Budget Provider: "
                    + Session["BudProvider"].ToString()
                    + " Budget Title: "
                    + Session["BudName"].ToString();
                btnBud.Text = "Change Budget";
            }
            else
            {
                lblBudName.Visible = false;
            }
        }
		private void loadAptTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveOrgStaffTypes";		
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			if (Session["OrgIdSA"] == null)
			{
				cmd.Parameters["@OrgId"].Value=Int32.Parse(Session["OrgId"].ToString());
			}
			else
			{
				cmd.Parameters["@OrgId"].Value=Int32.Parse(Session["OrgIdSA"].ToString());	
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffTypes");
			lstAptTypes.DataSource = ds;			
			lstAptTypes.DataMember= "StaffTypes";
			lstAptTypes.DataTextField = "Name";
			lstAptTypes.DataValueField = "Id";
			lstAptTypes.DataBind();
		}
		
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text !="OK")
			{
				if (Session["BRS"].ToString() == "1")
				{
					/*if (txtTime.Text == "")
					{
						lblContent1.ForeColor=Color.Maroon;
						lblContent1.Text="You must enter Time Input Required.";
					}
					else if (Session["SalaryRate"] == null)
						{
							lblContent1.ForeColor=Color.Maroon;
							lblContent1.Text="Salary Rate not Available.";
						}
					else 
					{*/
						updateGrid();
					//}
				}
				else
				{
					updateGrid();
				}
			}
			else
			{
				Done();
			}
		}
		private void updateGrid()
		{
			if (Session["btnAction"].ToString() == "Add")
				 {
					 SqlCommand cmd=new SqlCommand();
					 cmd.CommandType=CommandType.StoredProcedure;
					 cmd.CommandText="fms_AddProcSReq";
					 cmd.Connection=this.epsDbConn;
					 cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
					 cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
					 cmd.Parameters.Add ("@PSEPSId",SqlDbType.Int);
					 cmd.Parameters["@PSEPSId"].Value=Session["PSEPSId"].ToString();
					 cmd.Parameters.Add ("@PSEPId",SqlDbType.Int);
					 cmd.Parameters["@PSEPId"].Value=Session["PSEPId"].ToString();
					 cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
					 /* 2/28 cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
					 cmd.Parameters["@Desc"].Value= txtDesc.Text;*/
					if (Session["BRS"].ToString() == "1")
					 {
						 if (Session["BudgetsIdSel"] != null)
						 {
							 cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
							 cmd.Parameters["@BudgetsId"].Value=Session["BudgetsIdSel"].ToString();
						 }
						 else 
						 {
							 cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
							 cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();
						 }
					 }

					 if (Session["StaffActionId"] != null)
					 {
						 cmd.Parameters["@StaffActionId"].Value=Session["StaffActionId"].ToString();
					 }
					 else
					 {
						 cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
						 cmd.Parameters["@TypeId"].Value=Int32.Parse(lstAptTypes.SelectedItem.Value);	
					 }	 
					 if (Session["PRS"].ToString() == "1")
					 {
						 cmd.Parameters.Add("@ProjectId",SqlDbType.Int);
						 cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
					 }
					 if (txtTime.Text != "")
					 {
						 cmd.Parameters.Add ("@Time",SqlDbType.Decimal);
						 cmd.Parameters["@Time"].Value=Decimal.Parse(txtTime.Text, NumberStyles.Any);
					 }
					 
					 if (Session["SalaryRate"] != null)
					 {
						 cmd.Parameters.Add ("@Price",SqlDbType.Decimal);
                         cmd.Parameters["@Price"].Value = Decimal.Parse(Session["SalaryRate"].ToString(), NumberStyles.Any);
					 }
                     if (Session["BudReq"] != null)
					{
						cmd.Parameters.Add ("@ReqAmount",SqlDbType.Decimal);
                        cmd.Parameters["@ReqAmount"].Value = Decimal.Parse(Session["BudReq"].ToString(), NumberStyles.Any);
					}
					 cmd.Parameters.Add ("@TimeMeasure",SqlDbType.Int);
					 cmd.Parameters["@TimeMeasure"].Value=Int32.Parse(lstTimeMeasure.SelectedItem.Value);
					if (cbxBackup.Checked)
					{
						cmd.Parameters.Add("@BkupFlag",SqlDbType.Int);
						cmd.Parameters["@BkupFlag"].Value=1;
					}
					 cmd.Connection.Open();
					 cmd.ExecuteNonQuery();
					 cmd.Connection.Close();
					 Done();
				 }
				else if (Session["btnAction"].ToString() == "Update") 
				{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateProcSReq";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ProcSARId"].ToString();
				/* 2/28 cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;*/

				if (txtTime.Text != "")
				{
					cmd.Parameters.Add ("@Time",SqlDbType.Decimal);
					cmd.Parameters["@Time"].Value=Decimal.Parse(txtTime.Text, NumberStyles.Any);
				}
				cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
				if (Session["StaffActionId"] != null)
				{
					cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["StaffActionId"].ToString());
				}
				else if (Session["ContractId"] != null)
				{
					cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["ContractId"].ToString());

				}
				else
				{
					cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
					cmd.Parameters["@TypeId"].Value=Int32.Parse(lstAptTypes.SelectedItem.Value);
					cmd.Parameters.Add ("@Price",SqlDbType.Decimal);
					
					if (Session["SalaryRate"] != null)
					{
                        cmd.Parameters["@Price"].Value = Decimal.Parse(Session["SalaryRate"].ToString(), NumberStyles.Any);
					}
				}
				cmd.Parameters.Add ("@TimeMeasure",SqlDbType.Int);
				cmd.Parameters["@TimeMeasure"].Value=Int32.Parse(lstTimeMeasure.SelectedItem.Value);
				if (Session["BRS"].ToString() == "1")
				{
					if (Session["BudgetsIdSel"] != null)
					{
						cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
						cmd.Parameters["@BudgetsId"].Value=Session["BudgetsIdSel"].ToString();
					}
				}
                if (Session["BudReq"] != null)
				{
					cmd.Parameters.Add ("@ReqAmount",SqlDbType.Decimal);
                    cmd.Parameters["@ReqAmount"].Value = Decimal.Parse(Session["BudReq"].ToString(), NumberStyles.Any);
				}
				if (cbxBackup.Checked)
				{
					cmd.Parameters.Add("@BkupFlag",SqlDbType.Int);
					cmd.Parameters["@BkupFlag"].Value=1;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}		
		private void Done()
		{
			Session["BudSel"] = null;
			Session["BudgetsIdSel"]=null;
			Session["BProvSel"]=null;
			Session["BudNameSel"]=null;
			Session["CurrNameSel"]=null;
			Session["StaffActionId"]=null;
            Session["ContractId"] = null;
			Session["TypeId"] = null;
			Session["TypeIdSA"] = null;
			Session["BudAmount"] = null;
            Session["BudReq"] = null;
			Response.Redirect (strURL + Session["CUpdSAR"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		protected void btnSA_Click(object sender, System.EventArgs e)
		{
			getStaffAction();
		}
		private void getStaffAction()
		{
			Session["SA"]="frmUpdProcSReq";
			Response.Redirect (strURL + "frmStaffActionsProc.aspx?");
		}

		

		private void btnRecomputeBudget (object sender, System.EventArgs e)
		{
			lblBud.Visible=true;
			if (Session["ExchRate"].ToString() == "")
			{
				lblBud.Text="Salary for this appointment is denominated in."
					+ " The budgeted exchange rate for this currency has not"
					+ " been entered to the system.  Therefore, the budget required"
					+ " for this task cannot be automatically determined by the system"
					+ " until the exchange rate is entered by the budget staff."
					+ " You may however enter the amount requested manually below.";
			}
			else
			{
				loadStaffTypeDetails();
			}			

		}

		private void btnSOF_Click(object sender, System.EventArgs e)
		{
			Session["CBS"]="frmUpdProcSReq";
			Response.Redirect (strURL + "frmBudSel.aspx?");
		}
        protected void txtTime_TextChanged(object sender, EventArgs e)
        {
            loadStaffTypeDetails();
        }
        protected void lstTimeMeasure_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadStaffTypeDetails();
        }
        protected void btnBud_Click(object sender, EventArgs e)
        {
            loadStaffTypeDetails();
        }
        protected void lstAptTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadStaffTypeDetails();
        }
}
}

	
