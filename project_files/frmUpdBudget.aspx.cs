using System;
using System.Collections;
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
    public partial class frmUpdBudget : System.Web.UI.Page
    {
        private static string strURL =
            System.Configuration.ConfigurationSettings.AppSettings["local_url"];
        private static string strDB =
            System.Configuration.ConfigurationSettings.AppSettings["local_db"];
        public SqlConnection epsDbConn = new SqlConnection(strDB);

        /*private int GetIndexOfFY (string s)
        {
            return (lstFY.Items.IndexOf (lstFY.Items.FindByValue(s)));
        }	
        private int GetIndexOfFunds (string s)
        {
            return (lstFunds.Items.IndexOf (lstFunds.Items.FindByValue(s)));
        }	
        private int GetIndexOfType (string s)
        {
            return (lstType.Items.IndexOf (lstType.Items.FindByValue(s)));
        }
        private int GetIndexOfVisibility (string s)
        {
            return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
        }	*/
        private int GetIndexOfStatus(string s)
        {
            return (lstStatus.Items.IndexOf(lstStatus.Items.FindByValue(s)));
        }
        private int GetIndexOfCurr(string s)
        {
            return (lstCurr.Items.IndexOf(lstCurr.Items.FindByValue(s)));
        }
        private int GetIndexOfFunds(string s)
        {
            return (lstFunds.Items.IndexOf(lstFunds.Items.FindByValue(s)));
        }
                protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAction.Text = Session["Action"].ToString();
                loadCurr();
                if (Session["MgrOption"].ToString() == "Budget")
                {
                    loadFunds();

                    lstFY.Visible = true;
                    lblFunction.Text = Session["Action"].ToString() + " Budget";
                    if (Session["Action"].ToString() == "Update")
                    {
                        loadData2();
                    }
                    else
                    {
                        
                        loadFY();
                        lblName.Visible = false;
                        txtName.Visible = false;
                    }
                }
                else
                {
                    lblFunction.Text = Session["Action"].ToString() + " Fund";
                    lblStartDate.Visible = true;
                    txtStartDate.Visible = true;
                    lblEndDate.Visible = true;
                    txtEndDate.Visible = true;
                    lblFY.Visible = false;
                    lstFY.Visible = false;
                    lblName.Text = "Source of Funds Name";
                    txtName.Text = "";
                    txtAmt.Text = "";
                    lblCurr.Text = "Fund Currency";
                    lstCurr.Visible = true;
                    lstFunds.Visible = false;
                    lblFunds.Visible = false;
                    lblStart.Visible = true;
                    lblEnd.Visible = true;
                    loadCurr();
                    if (Session["Action"].ToString() == "Update")
                        {
                            loadData1();
                        }
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
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveFund";
            cmd.Parameters.Add("@FundsId", SqlDbType.Int);
            cmd.Parameters["@FundsId"].Value = Session["FundsId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Fund");
            txtName.Text = ds.Tables["Fund"].Rows[0][0].ToString();
            lstStatus.SelectedIndex = GetIndexOfStatus(ds.Tables["Fund"].Rows[0][1].ToString());
            lstCurr.SelectedIndex = GetIndexOfCurr(ds.Tables["Fund"].Rows[0][2].ToString());
            txtAmt.Text = ds.Tables["Fund"].Rows[0][4].ToString();
            txtStartDate.Text = ds.Tables["Fund"].Rows[0][5].ToString();
            txtEndDate.Text = ds.Tables["Fund"].Rows[0][6].ToString();
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //decimal.Parse(tbHours.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);

        }
        private void loadData2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveBudget";
            cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
            cmd.Parameters["@BudgetsId"].Value = Session["BudgetsId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Budget");

            txtName.Text = ds.Tables["Budget"].Rows[0][0].ToString();
            lstStatus.SelectedIndex = GetIndexOfStatus(ds.Tables["Budget"].Rows[0][1].ToString());
            lstCurr.SelectedIndex = GetIndexOfCurr(ds.Tables["Budget"].Rows[0][2].ToString());
            txtAmt.Text = ds.Tables["Budget"].Rows[0][3].ToString();
            txtStartDate.Text = ds.Tables["Budget"].Rows[0][4].ToString();
            txtEndDate.Text = ds.Tables["Budget"].Rows[0][5].ToString();
            if (Session["Action"].ToString() == "Update")
                {
                    lblFY.Visible=false;
                    lstFY.Visible = false;
                }

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //decimal.Parse(tbHours.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);

        }
        private void loadFY()
        {
            DateTime dt = DateTime.Now;
            int i = dt.Year - 1;
            //txtFY.Text = i.ToString();
            int j = 0;
            do
            {
                j++;
                i++;
                lstFY.Items.Add(i.ToString());
            }
            while (j < 5);
        }

        /*private void loadBudStatus()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveBudStatus";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
            cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
            cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
            cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
            cmd.Parameters.Add("@DomainId", SqlDbType.Int);
            cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            cmd.Parameters.Add("@BRS", SqlDbType.Int);
            cmd.Parameters["@BRS"].Value = Int32.Parse(Session["BRS"].ToString());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "BudStatus");
            lstStatus.DataSource = ds;
            lstStatus.DataMember = "BudStatus";
            lstStatus.DataTextField = "Name";
            lstStatus.DataValueField = "Id";
            lstStatus.DataBind();
        }*/
        
        private void loadCurr()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveCurrencies";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Currencies");
            lstCurr.DataSource = ds;
            lstCurr.DataMember = "Currencies";
            lstCurr.DataTextField = "Name";
            lstCurr.DataValueField = "Id";
            lstCurr.DataBind();
        }
        
        private void loadFunds()
        {
            SqlCommand cmd=new SqlCommand();
            cmd.Connection=this.epsDbConn;
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText="fms_RetrieveFundsAll";
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
            da.Fill(ds,"Funds");
            lstFunds.DataSource = ds;			
            lstFunds.DataMember= "Funds";
            lstFunds.DataTextField = "Name";
            lstFunds.DataValueField = "Id";
            lstFunds.DataBind();
        }
		/*
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
        }*/
        protected void btnAction_Click(object sender, System.EventArgs e)
        {
            if (Session["MgrOption"].ToString() == "Budget")
                
            {
                if (Session["Action"].ToString() == "Update")
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdateBudget";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(Session["BudgetsId"].ToString());
                    cmd.Parameters.Add("@FundsId", SqlDbType.Int);
                    cmd.Parameters["@FundsId"].Value = lstFunds.SelectedItem.Value; 
                    cmd.Parameters.Add("@Amt", SqlDbType.Decimal);
                    if (txtAmt.Text != "")
                    {
                        cmd.Parameters["@Amt"].Value = decimal.Parse(txtAmt.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    }

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    Done();
                }
                else if (Session["Action"].ToString() == "Add")
                {
                    //string Str = txtFY.Text.Trim();
                    //double Num;
                    //bool isNum = double.TryParse(Str, out Num);
                    //if (isNum)
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_RetrieveBudgetFY";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@FundsId", SqlDbType.Int);
                    cmd.Parameters["@FundsId"].Value = lstFunds.SelectedItem.Value;
                    cmd.Parameters.Add("@FY", SqlDbType.Int);
                    cmd.Parameters["@FY"].Value = lstFY.SelectedItem.Value;
                    cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                    cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "FY");
                    if (ds.Tables["FY"].Rows.Count == 0)
                    {
                        addBudget();
                        Done();
                    }
                    else
                    {
                        lblFY.Text = "Budget against the above Source of Funds has already been created for this FY.  Select "
                        + " a different FY or else press 'OK' to return to previous form.";
                        //lstStatus.SelectedIndex = GetIndexOfStatus(ds.Tables["Budget"].Rows[0][1].ToString());
                        
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }

            else //i.e. if Funds
            {

                DateTime date1, date2;
                bool date1OK, date2OK;
                date1 = new DateTime(1, 1, 1);
                date2 = new DateTime(1, 1, 1);
                try
                {
                    date1 = Convert.ToDateTime(txtStartDate.Text);
                    date1OK = true;
                }
                catch
                {
                    date1OK = false;
                    lblStart.Text = "Please enter date in form mm/dd/yyyy";
                    txtStartDate.Focus();
                }
                try
                {
                    date2 = Convert.ToDateTime(txtEndDate.Text);
                    date2OK = true;
                }
                catch
                {
                    date2OK = false;
                    lblEnd.Text = "Please enter date in form mm/dd/yyyy";
                    lblEnd.Focus();
                }
                if (date1OK && date2OK)
                {
                    if (date1.CompareTo(date2) > -1)
                    {
                        lblStart.Text = "";
                        lblEnd.Text = "End date must be after start date";
                    }
                    else
                    {

                        if (Session["Action"].ToString() == "Update")
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "fms_UpdateFund";
                            cmd.Connection = this.epsDbConn;
                            cmd.Parameters.Add("@Id", SqlDbType.Int);
                            cmd.Parameters["@Id"].Value = Int32.Parse(Session["FundsId"].ToString());
                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                            cmd.Parameters["@Name"].Value = txtName.Text;
                            cmd.Parameters.Add("@Status", SqlDbType.Int);
                            cmd.Parameters["@Status"].Value = lstStatus.SelectedItem.Value;
                            cmd.Parameters.Add("@CurrenciesId", SqlDbType.Int);
                            cmd.Parameters["@CurrenciesId"].Value = lstCurr.SelectedItem.Value;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal);
                            if (txtAmt.Text != "")
                            {
                                cmd.Parameters["@Amt"].Value = decimal.Parse(txtAmt.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                            }
                            cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                            if (txtStartDate.Text != "")
                            {
                                cmd.Parameters["@StartDate"].Value = txtStartDate.Text;
                            }
                            cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                            if (txtEndDate.Text != "")
                            {
                                cmd.Parameters["@EndDate"].Value = txtEndDate.Text;
                            }
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                            Done();

                        }
                        else if (Session["Action"].ToString() == "Add")
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "fms_AddFund";
                            cmd.Connection = this.epsDbConn;
                            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                            cmd.Parameters["@Name"].Value = txtName.Text;
                            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                            cmd.Parameters.Add("@CurrenciesId", SqlDbType.Int);
                            cmd.Parameters["@CurrenciesId"].Value = lstCurr.SelectedItem.Value;
                            cmd.Parameters.Add("@Status", SqlDbType.Int);
                            cmd.Parameters["@Status"].Value = lstStatus.SelectedItem.Value;
                            cmd.Parameters.Add("@Amt", SqlDbType.Decimal);
                            if (txtAmt.Text != "")
                            {
                                cmd.Parameters["@Amt"].Value = decimal.Parse(txtAmt.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                            }
                            cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime);
                            if (txtStartDate.Text != "")
                            {
                                cmd.Parameters["@StartDate"].Value = txtStartDate.Text;
                            }
                            cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime);
                            if (txtEndDate.Text != "")
                            {
                                cmd.Parameters["@EndDate"].Value = txtEndDate.Text;
                            }
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                            Done();
                        }
                    }
                }
            }
        }
        private void addBudget()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_AddBudget";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
            cmd.Parameters.Add("@FundsId", SqlDbType.Int);
            cmd.Parameters["@FundsId"].Value = lstFunds.SelectedItem.Value;
            cmd.Parameters.Add("@FY", SqlDbType.Int);
            cmd.Parameters["@FY"].Value = lstFY.SelectedItem.Value;//Int32.Parse(txtFY.Text);
            cmd.Parameters.Add("@Status", SqlDbType.Int);
            cmd.Parameters["@Status"].Value = lstStatus.SelectedItem.Value;
            cmd.Parameters.Add("@Amt", SqlDbType.Decimal);
            if (txtAmt.Text != "")
            {
                cmd.Parameters["@Amt"].Value = decimal.Parse(txtAmt.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
            }
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        private void Done()
        {
            Session["BudgetsId"] = null;
            Response.Redirect(strURL + Session["CUpdBudget"].ToString() + ".aspx?");
        }

        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            Done();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            
        }
        /*private void SwitchBud()
        {
            lblFunction.Text = Session["Action"].ToString() + " Budget";
            btnAction.Text = Session["Action"].ToString();
            lblStartDate.Visible = false;
            txtStartDate.Visible = false;
            lblEndDate.Visible = false;
            txtEndDate.Visible = false;
            btnFunds.Visible = true;
            lblFY.Visible = true;
            txtFY.Visible = true;
            lblName.Text = "Budget Name";
            lblCurr.Visible = false;
            lstCurr.Visible = false;
            lstFunds.Visible = true;
            lblFunds.Visible = true;
            lblStart.Visible = false;
            lblEnd.Visible = false;
            loadFunds();
        }*/

}

}
