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
	public partial class frmUpdStaffAction : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.RadioButtonList rblStatusSS;

		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
		private int GetIndexOfPayMethods (string s)
		{
			return (lstPayMethods.Items.IndexOf (lstPayMethods.Items.FindByValue(s)));
		}
		private int GetIndexOfRoles (string s)
		{
			return (lstRoles.Items.IndexOf (lstRoles.Items.FindByValue(s)));
		}
		private int GetIndexOfPayGrades (string s)
		{
			return (lstPayGrades.Items.IndexOf (lstPayGrades.Items.FindByValue(s)));
		}
        private int GetIndexOfBudgets(string s)
        {
            return (lstFunds.Items.IndexOf(lstFunds.Items.FindByValue(s)));
        }
		/*private int GetIndexOfStatus (string s)
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
			else if (s == "4")
			{
				return 4;
			}
			else 
			{
				return 0;
			}
		}*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
			    if (!IsPostBack)
			{
                lblPay.Visible = false;
                    lstPayMethods.Visible = false;
                    lblRoles.Visible = false;
                    lstRoles.Visible = false;
                    lblLocation.Visible = false;
                    lstLocations.Visible = false;
				lblOrg.Text=(Session["OrgName"]).ToString();
				lblAptType.Text = "Appointment Type: " + Session["STName"].ToString();
				loadVisibility();
				loadLocs();
				loadPayMethods();
				loadRoles();
                loadSOF();
				loadPayGrades();
				lstPayMethods.BorderColor=System.Drawing.Color.Navy;
				lstPayMethods.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);

				if (Session["btnAction"].ToString() == "Update")
				{
					loadStaffAction();
                    loadStaffSalary();
					loadPGSalDetails();
                    if (lstAptStatus.SelectedItem.Value != "0")
                    {
                        btnPeople.Visible = false;
                    }
                   
                    txtStartDateS.Focus();
                    lblStartDate.Visible = true;

				}
				else
				{
					//1/6/10 btnPeople.Visible=true;
					loadPGSalDetails();

                    /*1/6/10 if (Session["PeopleId"] == null)
                    {
                        lblStartDate.Visible = false;
                        txtStartDate.Visible = false;
                        lblEndDate.Visible = false;
                        txtEndDate.Visible = false;
                        lblAptType.Visible = false;
                        lblAptStatus.Visible = false;
                        lstAptStatus.Visible = false;
                        lblVisibility.Visible = false;
                        lstVisibility.Visible = false;
                        lblSARevision.Visible = false;
                        lblSalary.Visible = false;
                        txtSalary.Visible = false;
                        lblSalaryPeriod.Visible = false;
                        lblSalMax.Visible = false;
                        lblSalMin.Visible = false;
                        lblPayGrades.Visible = false;
                        lstPayGrades.Visible = false;
                    }*/

                    lblCurrStartDate.Visible = false;
                    lblCurr.Visible = false;
                    lblCurrGrade.Visible = false;
                    lblCurrSal.Visible = false;
                    lblRev.Visible = false;
                    lblSalaryPeriod1.Visible = false;
                    lblStartDateS.Visible = false;
                    txtStartDateS.Visible = false;
				}
				if (Session["PeopleId"] != null)
				{
					lblName.Text = "Name: " + Session["PeopleName"].ToString();
				}
				lblContent1.Text=Session["btnAction"].ToString() + " Appointment Action";
				if (Session["btnAction"].ToString() == "Add")
				{
					btnAction.Text="OK";
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
		private void loadPGSalDetails()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="hrs_RetrievePayGrade";		
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=lstPayGrades.SelectedItem.Value;
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"PGID");
				lblSalaryPeriod.Text=ds.Tables["PGID"].Rows[0][0].ToString()
					+ " per " + ds.Tables["PGID"].Rows[0][4].ToString();
                lblSalaryPeriod1.Text = ds.Tables["PGID"].Rows[0][0].ToString()
                        + " per " + ds.Tables["PGID"].Rows[0][4].ToString();

				lblSalMin.Text="Minimum Salary for this Grade Level: " 
				+ ds.Tables["PGID"].Rows[0][1].ToString()
				+ " " 
				+ ds.Tables["PGID"].Rows[0][0].ToString()
					+ " per " + ds.Tables["PGID"].Rows[0][4].ToString();
			lblSalMax.Text="Maximum Salary for this Grade Level: " 
				+ ds.Tables["PGID"].Rows[0][2].ToString()
				+ " " 
				+ ds.Tables["PGID"].Rows[0][0].ToString()
				+ " per " + ds.Tables["PGID"].Rows[0][4].ToString();
		}
		private void loadStaffAction()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveStaffAction";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["Id"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffAction");
			if (Session["PeopleId"] != null)
			{
				lblName.Text = "Name: " + Session["PeopleName"].ToString();
			}
			else if (ds.Tables["StaffAction"].Rows[0][0].ToString() == null)
			{
				lblName.Text= "Name: " + "Unidentified";
				Session["PeopleId"]=null;
			}
			else
			{
				Session["PeopleId"]=ds.Tables["StaffAction"].Rows[0][0].ToString();
				lblName.Text="Name: " + ds.Tables["StaffAction"].Rows[0][1].ToString();	
			}		
			lstLocations.SelectedIndex=
				GetIndexOfLocs(ds.Tables["StaffAction"].Rows[0][3].ToString());
			lstVisibility.SelectedIndex=
				GetIndexOfVisibility(ds.Tables["StaffAction"].Rows[0][4].ToString());
			lstPayMethods.SelectedIndex = GetIndexOfPayMethods (ds.Tables["StaffAction"].Rows[0][5].ToString());
			Session["Status"]=ds.Tables["StaffAction"].Rows[0][7].ToString();
			//txtSalary.Text=ds.Tables["StaffAction"].Rows[0][8].ToString();
			//lstPayGrades.SelectedIndex = GetIndexOfPayGrades(ds.Tables["StaffAction"].Rows[0][9].ToString());
			lstRoles.SelectedIndex = GetIndexOfRoles (ds.Tables["StaffAction"].Rows[0][10].ToString());
			lstAptStatus.SelectedIndex=Int32.Parse(Session["Status"].ToString());
            txtStartDate.Text = ds.Tables["StaffAction"].Rows[0][11].ToString();
            txtEndDate.Text = ds.Tables["StaffAction"].Rows[0][12].ToString();
            lstFunds.SelectedIndex = GetIndexOfBudgets(ds.Tables["StaffAction"].Rows[0][13].ToString());
            //refreshTextBox();
		}
        private void loadStaffSalary()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "hrs_RetrieveStaffSalary";
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Session["Id"].ToString();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "StaffSalary");
                lblCurrStartDate.Text = "Start Date: " + ds.Tables["StaffSalary"].Rows[0][1].ToString();
                Session["DT"] = ds.Tables["StaffSalary"].Rows[0][1].ToString();
                lblCurrSal.Text = "Salary: " + ds.Tables["StaffSalary"].Rows[0][2].ToString();
                lstPayGrades.SelectedIndex = GetIndexOfPayGrades(ds.Tables["StaffSalary"].Rows[0][3].ToString());
                Session["CurrPayGrade"] = lstPayGrades.SelectedItem.Value;
                lblCurrGrade.Text = "Grade: " + ds.Tables["StaffSalary"].Rows[0][4].ToString();
                txtSalary.Text = "";
                txtStartDateS.Text = "";
            }
            catch (Exception Ex)
            {
                if (Ex.Message.StartsWith("String was not recognized as a valid DateTime."))
                {
                    lblContent2.Text = "Please enter dates in form mm/dd/yyyy.";
                }
                else lblContent2.Text = Ex.Message;
            }

            
        }
        /*private void refreshTextBox()
        {
            if (txtStartDate.Text.StartsWith("&") == true)
                    {
                        txtStartDate.Text = "";
                    }
            if (txtEndDate.Text.StartsWith("&") == true)
            {
                txtEndDate.Text = "";
            }
        }*/
        protected void btnAction_Click(object sender, System.EventArgs e)
        {
            try
            { 
            if (Session["btnAction"].ToString() == "Add")
            {
                int t = 0;
                    if (Convert.ToDateTime(txtStartDate.Text) ==
                    Convert.ToDateTime(txtEndDate.Text))
                    {
                        t = 1;
                    }
                    else
                    {
                        t = 2;
                    }
                
                    if (txtSalary.Text == "")
                    {
                        lblContent1.Text = "You must enter the Salary, actual or estimated, even if it is not determined yet.";
                    }
                    else if (txtStartDateS.Text == "")
                    {
                        lblContent1.Text = "You must enter the start date even if it is not determined yet.";
                    }
                    else if (lblName.Text == "")
                    {
                        if (lstAptStatus.SelectedItem.Value == "1")
                        {
                            lblContent1.Text = "You must identify the person being appointed.";
                        }
                    }
          
                if (txtStartDate.Text == "")
                    {
                        lblContent2.Text = "You must enter an appointment start date";
                    }
                    else if (txtEndDate.Text.StartsWith(" ") == true)
                    {
                        txtEndDate.Text = "";
                        lblContent2.Text = "You must enter an appointment end date";
                    }

                    else if (Convert.ToDateTime(txtEndDate.Text) < Convert.ToDateTime(txtStartDate.Text))
                    {
                        lblContent2.Text = "Appointment End Date cannot be before the Appointment Start Date.";
                    }
                    else if (Session["PeopleId"] == null)
                    {
                        lblContent2.Text = "You must identify the person being appointed.";
                    }
                    else
                    {
                        addAData();
                        getStaffActionsId();
                        addSData();
                        Done();
                    }
                
            }
            else
            {
                    if ((txtStartDateS.Text == "") && (txtSalary.Text == "") &&
                        (lstPayGrades.SelectedItem.Value == (Session["CurrPayGrade"].ToString())))
                    {
                        updateAData();
                        Done();
                    }
                    else
                    {
                        if (txtStartDateS.Text == "")
                        {
                            lblContent1.Text = "You must enter the start date for this update.";
                            txtStartDateS.Focus();
                        }
                        else if (txtSalary.Text == "")
                        {
                            lblContent1.Text = "You must enter the Salary amount after this update.";
                        }
                        else if (Convert.ToDateTime(txtEndDate.Text) < Convert.ToDateTime(txtStartDate.Text))
                        {
                            lblContent2.Text = "Appointment End Date cannot be before the Appointment Start Date.";
                        }
                        else if (Convert.ToDateTime(txtStartDateS.Text) < Convert.ToDateTime(txtStartDate.Text))
                        {
                            lblContent2.Text = "Salary Start Date cannot be before the Appointment Start Date.";
                        }
                        else if (Convert.ToDateTime(txtStartDateS.Text) > Convert.ToDateTime(txtEndDate.Text))
                        {
                            lblContent2.Text = "Salary Start Date cannot be after the Appointment End Date.";
                        }

                        else
                        {
                            if (Session["Ctr"] == null)
                            {
                                DateTime dtCurr = new DateTime();
                                dtCurr = Convert.ToDateTime(Session["DT"].ToString());
                                DateTime dtRev = new DateTime();
                                dtRev = Convert.ToDateTime(txtStartDateS.Text);
                                if (DateTime.Compare(dtCurr, dtRev) >= 0)
                                {
                                    lblContent2.Text = "Start date of this revision is PRIOR to the start date of current revision (see above). "
                                    + " By continuing with this update, you will replace the current revision with this update, not simply update it.  "
                                    + " To continue"
                                    + " click on 'OK' again.  Else click on 'Cancel'";
                                    Session["Ctr"] = "OK";
                                }
                                else
                                {
                                    updateAData();
                                    addSData();
                                    updateSData();
                                    Done();
                                }
                            }
                            else
                            {
                                if (Session["Ctr"].ToString() == "OK")//delete staff action(s) with dates prior to this one.
                                {
                                    SqlCommand cmd = new SqlCommand();
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Connection = this.epsDbConn;
                                    cmd.CommandText = "hrs_DeleteSARevisions";
                                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                                    cmd.Parameters["@StartDate"].Value = Convert.ToDateTime(txtStartDateS.Text);
                                    cmd.Parameters.Add("@StaffActionsId", SqlDbType.Int);
                                    cmd.Parameters["@StaffActionsId"].Value = Session["Id"].ToString();

                                    cmd.Connection.Open();
                                    cmd.ExecuteNonQuery();
                                    cmd.Connection.Close();
                                }
                                Session["Ctr"] = null;
                                updateAData();
                                addSData();
                                Done();
                            }
                        }
                    }
                }
            } 
     
            catch (Exception Ex)
                {
                    if (Ex.Message.StartsWith("String was not recognized as a valid DateTime."))
                    {
                        lblContent2.Text = "Please enter dates in form mm/dd/yyyy.";
                    }
                    else lblContent2.Text = Ex.Message;
                }
         }
        private void updateSData()

        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "hrs_updateSARevisions";
            cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
            cmd.Parameters["@EndDate"].Value = Convert.ToDateTime(txtStartDateS.Text);
            cmd.Parameters.Add("@StaffActionsId", SqlDbType.Int);
            cmd.Parameters["@StaffActionsId"].Value = Session["Id"].ToString();

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        private void getStaffActionsId()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "hrs_RetrieveStaffActionsNew";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "SAId");
            Session["Id"] = ds.Tables["SAId"].Rows[0][0].ToString();
        }
      
		private void updateAData()
		{
			/*try
			{*/
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdateStaffAction";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["Id"].ToString();
				cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
				cmd.Parameters["@TypeId"].Value=Int32.Parse(Session["OrgStaffTypesId"].ToString());
				cmd.Parameters.Add ("@LocId",SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Parameters.Add ("@PM",SqlDbType.Int);
				cmd.Parameters["@PM"].Value=lstPayMethods.SelectedItem.Value;
				if (Session["PeopleId"] != null)
				{
					cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
					cmd.Parameters["@PeopleId"].Value= Session["PeopleId"].ToString();
				}
                if (txtStartDate.Text != "")
                {
                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                    cmd.Parameters["@StartDate"].Value = txtStartDate.Text;
                }
                if (txtEndDate.Text.StartsWith("&") == false)
                {
                    cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                    cmd.Parameters["@EndDate"].Value = txtEndDate.Text;
                }
				
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				cmd.Parameters["@Status"].Value=lstAptStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@RolesId",SqlDbType.Int);
				cmd.Parameters["@RolesId"].Value=lstRoles.SelectedItem.Value;
                cmd.Parameters.Add("@FundsId", SqlDbType.Int);
                cmd.Parameters["@FundsId"].Value = lstFunds.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			/*}
			catch (Exception Ex)
			{
				
			}*/
		}
        private void addAData()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "hrs_AddStaffAction";
                cmd.Connection = this.epsDbConn;
                if (Session["PeopleId"] != null)
                {
                    cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                    cmd.Parameters["@PeopleId"].Value = Session["PeopleId"].ToString();
                }
                cmd.Parameters.Add("@TypeId", SqlDbType.Int);
                cmd.Parameters["@TypeId"].Value = Int32.Parse(Session["OrgStaffTypesId"].ToString());
                cmd.Parameters.Add("@LocId", SqlDbType.Int);
                    cmd.Parameters["@LocId"].Value = lstLocations.SelectedItem.Value;
                    cmd.Parameters.Add("@Status", SqlDbType.Int);
                    cmd.Parameters["@Status"].Value = lstAptStatus.SelectedItem.Value;
                    cmd.Parameters.Add("@PM", SqlDbType.Int);
                    cmd.Parameters["@PM"].Value = lstPayMethods.SelectedItem.Value;
                    cmd.Parameters.Add("@RolesId", SqlDbType.Int);
                    cmd.Parameters["@RolesId"].Value = lstRoles.SelectedItem.Value;
                    cmd.Parameters.Add("@FundsId", SqlDbType.Int);
                    cmd.Parameters["@FundsId"].Value = lstFunds.SelectedItem.Value;
                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                    cmd.Parameters["@StartDate"].Value = DateTime.Parse(txtStartDate.Text);
                    cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                    cmd.Parameters["@EndDate"].Value = DateTime.Parse(txtEndDate.Text);
                cmd.Parameters.Add("@Vis", SqlDbType.Int);
                cmd.Parameters["@Vis"].Value = lstVisibility.SelectedItem.Value;
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch
            {
                if (txtSalary.Text == "")
                {
                    lblContent1.Text = "You must enter a Salary Amount or click 'Cancel'";
                }
            }
        }
        private void addSData()
        {
           try
            {
               SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "hrs_AddSARevisions";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@StaffActionsId", SqlDbType.Int);
                cmd.Parameters["@StaffActionsId"].Value = Session["Id"].ToString();
                cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                if (Session["btnAction"].ToString() == "Update")
                {
                    cmd.Parameters["@StartDate"].Value = DateTime.Parse(txtStartDateS.Text);
                }
                else
                {
                    cmd.Parameters["@StartDate"].Value = DateTime.Parse(txtStartDate.Text);
               
                }
                cmd.Parameters.Add("@PayGradeId", SqlDbType.Int);
                cmd.Parameters["@PayGradeId"].Value = lstPayGrades.SelectedItem.Value;
                cmd.Parameters.Add("@Salary", SqlDbType.Decimal);
                cmd.Parameters["@Salary"].Value = decimal.Parse(txtSalary.Text, NumberStyles.Any);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }

            catch (Exception Ex)
			{
                if (Ex.Message.StartsWith("String was not recognized as a valid DateTime."))
                {
                    lblContent2.Text = "Please enter dates in form mm/dd/yyyy.";
                }
                else lblContent2.Text = Ex.Message;
			}
        }
		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			lstVisibility.DataSource = ds;			
			lstVisibility.DataMember= "Visibility";
			lstVisibility.DataTextField = "Name";
			lstVisibility.DataValueField = "Id";
			lstVisibility.DataBind();
		}
		private void loadRoles()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveRolesAll";
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
			da.Fill(ds,"Roles");
			lstRoles.DataSource = ds;			
			lstRoles.DataMember= "Roles";
			lstRoles.DataTextField = "Name";
			lstRoles.DataValueField = "Id";
			lstRoles.DataBind();
		}
        private void loadSOF()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "fms_RetrieveFunds";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
             DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Budgets");
            lstFunds.DataSource = ds;
            lstFunds.DataMember = "Budgets";
            lstFunds.DataTextField = "Name";
            lstFunds.DataValueField = "Id";
            lstFunds.DataBind();
        }
		private void loadPayGrades()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrievePayGrades";
			cmd.Parameters.Add ("@OrgStaffTypesId",SqlDbType.Int);
			cmd.Parameters["@OrgStaffTypesId"].Value=Int32.Parse(Session["OrgStaffTypesId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PayGrades");
			lstPayGrades.DataSource = ds;			
			lstPayGrades.DataMember= "PayGrades";
			lstPayGrades.DataTextField = "Name";
			lstPayGrades.DataValueField = "Id";
			lstPayGrades.DataBind();
		}
		private void loadLocs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveLocations";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Locations");
			lstLocations.DataSource = ds;			
			lstLocations.DataMember= "Locations";
			lstLocations.DataTextField = "Name";
			lstLocations.DataValueField = "Id";
			lstLocations.DataBind();
		}

        private void loadPayMethods()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrievePayMethods";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "PayMethods");
            lstPayMethods.DataSource = ds;
            lstPayMethods.DataMember = "PayMethods";
            lstPayMethods.DataTextField = "Name";
            lstPayMethods.DataValueField = "Id";
            lstPayMethods.DataBind();
        }
		private void Done()
		{
			Session["PeopleId"]=null;
			Response.Redirect (strURL + Session["CSA"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		private void peopleAdd()
		{
			Session["CallerPeople"]="frmUpdStaffAction";
			Response.Redirect (strURL + "frmPeople.aspx?");
		}
		protected void btnPeople_Click(object sender, System.EventArgs e)
		{
			peopleAdd();
		}
		protected void Dropdownlist1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadPGSalDetails();
			if (lblSalMin.ForeColor== Color.Ivory)
			{
				lblSalMin.ForeColor = Color.White;
				lblSalMax.ForeColor = Color.White;
			}
			else
			{
				lblSalMin.ForeColor = Color.Ivory;
				lblSalMax.ForeColor = Color.Ivory;
			}
		}
}
}

	
