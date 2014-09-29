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
    /// Summary description for Main.
    /// </summary>
    public partial class MainMgr : System.Web.UI.Page
    {   
        private static string strURL =
            System.Configuration.ConfigurationSettings.AppSettings["local_url"];
        private static string strDB =
            System.Configuration.ConfigurationSettings.AppSettings["local_db"];
        protected System.Web.UI.WebControls.Button lblResME;
        protected System.Web.UI.WebControls.Button btnTraining;
        public SqlConnection epsDbConn = new SqlConnection(strDB);
        string Report;
        int OrgFlag = 0;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            Session.Timeout = 60; 
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

        }
        #endregion

        private void Load_Procedures()
        {
            if (!IsPostBack)
            {
                loadOrg();
                if (Session["OrgId"] != null)
                {
                    lstOrg.SelectedIndex = GetIndexOfOrg(Session["OrgId"].ToString());  
                }
                loadSessions();
                EMBM();
                getPeopleId();
                lblLicense.Text = "License Id: " + Session["LicenseId"].ToString();
                lblPerson.Text =
                    Session["FName"].ToString() + " " + Session["LName"].ToString();
            }
        }
        
        private void EMBM()
        {
            if (Session["EPS"].ToString() == "1")
            {
                modeEM();
            }
            else
            {
                modeBM();
            }
        }
        private void loadData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveOrgLocationsInd";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
            cmd.Parameters["@PeopleId"].Value = Session["UserPerson"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Locs");
            if (ds.Tables["Locs"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContents.Text = "Welcome "
                    + Session["FName"].ToString()
                    + ".  To continue, please click on the appropriate button below ";
                
            }
            else
            {
                lblContents.Text = "Welcome "
                    + Session["FName"].ToString()
                    + ".  The various tasks to which you have been assigned are listed below.  To continue, please click on the appropriate button below ";
            }
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }
        private void getTRSFlag()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrgFlagsTRS";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TRS");
            if (ds.Tables["TRS"].Rows[0][0].ToString() == "0")
            {
                Session["TRS"] = 0;
            }
            else
            {
                Session["TRS"] = 1;
            }
        }
        private void getEPSFlag()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrgFlagsEPS";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "EPS");
            if (ds.Tables["EPS"].Rows[0][0].ToString() == "0")
            {
                Session["EPS"] = 0;
            }
            else
            {
                Session["EPS"] = 1;
            }
        }
        
        private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                try
                {
                    Session["CPSEInd"] = "frmMainMgr";
                    Session["OrgLocId"] = e.Item.Cells[0].Text;
                    Session["MgrName"] = e.Item.Cells[1].Text;
                    Session["LocationName"] = e.Item.Cells[2].Text;
                    Session["ServiceName"] = e.Item.Cells[3].Text;
                    Session["EventName"] = e.Item.Cells[4].Text;
                    Session["ProfileId"] = e.Item.Cells[6].Text;
                    Session["PSEventsId"] = e.Item.Cells[7].Text;
                    Session["PJName"] = e.Item.Cells[8].Text;
                    Session["PJNameS"] = e.Item.Cells[9].Text;

                    Response.Redirect(strURL + "frmPSEventsInd.aspx?");

                }
                catch (SqlException err)
                {
                    if (err.Message.StartsWith("Object reference not set"))
                        Response.Redirect(strURL + "frmStart.aspx?");
                    else lblContents.Text = err.Message;
                }
            }
        }
        protected void btnExit_Click(object sender, System.EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect(strURL + "frmStart.aspx?");
        }


        protected void btnTS_Click(object sender, System.EventArgs e)
        {
            Session["CSAI"] = "frmMainMgr";
            Response.Redirect(strURL + "frmStaffActionsInd.aspx?");
        }

        private void buttonsOff()
        {
           /* btnERTT.Visible = false;
            btnERS.Visible = false;
            btnERA.Visible = false;
            btnERG.Visible = false;
            btnERP.Visible = false;
            btnERT.Visible = false;*/
        }
        private void buttonsOn()
        {
            /*btnERTT.Visible = true;
            btnERS.Visible = true;
            btnERA.Visible = true;
            btnERG.Visible = true;
            btnERP.Visible = true;
            btnERT.Visible = true;*/
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            lblMode.Text = "Profile";
            lblContents.Visible = false;
            btnExit.Visible = false;
            
            btnEM.Visible = false;
            btnBM.Visible = false;
            btnProfile.Visible = false;
            btnCS.Visible = false;
            //btnrptER1.Visible = false;
            EMBMOff();

            buttonsOff();

            btnUProfile.Visible = true;
            btnCProfile.Visible = true;
            DataGrid1.Visible = false;
            txtCPhone.Visible = true;
            txtHPhone.Visible = true;
            txtWPhone.Visible = true;
            txtEmail.Visible = true;
            lblCPhone.Visible = true;
            lblHPhone.Visible = true;
            lblWPhone.Visible = true;
            lblEmail.Visible = true;
        }
        protected void btnUProfile_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "eps_UpdatePeople";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
            cmd.Parameters["@PeopleId"].Value = Session["UserPerson"].ToString();
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
            cmd.Parameters["@Email"].Value = txtEmail.Text;
            cmd.Parameters.Add("@HPhone", SqlDbType.NVarChar);
            cmd.Parameters["@Hphone"].Value = txtHPhone.Text;
            cmd.Parameters.Add("@WPhone", SqlDbType.NVarChar);
            cmd.Parameters["@Wphone"].Value = txtWPhone.Text;
            cmd.Parameters.Add("@CPhone", SqlDbType.NVarChar);
            cmd.Parameters["@Cphone"].Value = txtCPhone.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            profileEnd();
        }
        private void profileEnd()
        {
            /*lblMode.Text = "Dashboard";
            lblContents.Visible = true;
            
            btnHH.Visible = true;
            btnTS.Visible = true;
            */
            btnExit.Visible = true;
            btnProfile.Visible = true;
            DataGrid1.Visible = true;
            txtCPhone.Visible = false;
            txtHPhone.Visible = false;
            txtWPhone.Visible = false;
            txtEmail.Visible = false;
            lblCPhone.Visible = false;
            lblHPhone.Visible = false;
            lblWPhone.Visible = false;
            lblEmail.Visible = false;
            btnUProfile.Visible = false;
            btnCProfile.Visible = false;
            EMBM();
        }
        protected void btnCProfile_Click(object sender, EventArgs e)
        {
            profileEnd();
        }
        protected void btnWP_Click(object sender, EventArgs e)
        {
            loadData();
            DataGrid1.Visible = true;
        }
        protected void btnCS_Click(object sender, EventArgs e)
        {
            Session["MgrOption"] = "Supply";
            Session["CContracts"] = "frmMainMgr";
            Session["HHFlag"] = "1";
            Session["PRC"] = "0";
            Response.Redirect(strURL + "frmContractsS.aspx?");
        }
        protected void btnPlan_Click(object sender, EventArgs e)
        {
            Session["MgrOption"] = "Plan";
            //Session["ProfileId"]=;//e.Item.Cells[4].Text;
			//Session["LocationName"]=;//e.Item.Cells[1].Text;
			//Session["OrgLocId"]=;//e.Item.Cells[0].Text;
            //Session["LocationsId"] = ;//e.Item.Cells[6].Text;
            Session["COrgLocServices"] = "frmMainMgr";
            Session["PAY"] = null;
            Response.Redirect (strURL + "frmOrgLocServices.aspx?");
            /*Response.Redirect(strURL + "frmOrgLocations.aspx?");*/
        }
        protected void btnBud_Click(object sender, EventArgs e)
        {
            Session["MgrOption"] = "Budget";
            getBRSFlag();
            Session["CBudgets"] = "frmMainMgr";
            Response.Redirect(strURL + "frmBudgets.aspx?");
        }
        private void getBRSFlag()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrgFlagsBRS";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "BRS");
            if (ds.Tables["BRS"].Rows[0][0].ToString() == "0")
            {
                Session["BRS"] = 0;
            }
            else
            {
                Session["BRS"] = 1;
            }
        }
        protected void btnStaff_Click(object sender, EventArgs e)
        {
            Session["CAptTypes"] = "frmMainMgr";
            Session["MgrOption"] = "Staffing";
            Response.Redirect(strURL + "frmOrgStaffTypes.aspx?");
        }
        protected void btnProc_Click(object sender, EventArgs e)
        {
            getPRCFlag();
            Session["MgrOption"] = "Procure";
            Session["CContracts"] = "frmMainMgr";
            Response.Redirect(strURL + "frmContractsS.aspx?");


        }
        /*private void getSAS()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrgFlagsSAS";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "SAS");
            if (ds.Tables["SAS"].Rows[0][0].ToString() == "0")
            {
                Session["SAS"] = 0;
            }
            else
            {
                Session["SAS"] = 1;
            }
        }*/
        private void getPRCFlag()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrgFlagsPRC";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "PRC");
            if (ds.Tables["PRC"].Rows[0][0].ToString() == "0")
            {
                Session["PRC"] = 0;
            }
            else
            {
                Session["PRC"] = 1;
            }
        }
        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {

        }
        protected void btnIWP_Click(object sender, EventArgs e)
        {
            if (DataGrid1.Visible = false)
            {
                loadData();
                DataGrid1.Visible = true;
            }
            else
            {
                DataGrid1.Visible = false;
            }
        }
        protected void btnMgr_Click(object sender, EventArgs e)
        {

        }
        protected void btnSec_Click(object sender, EventArgs e)
        {
            Session["CSec"] = "frmMainMgr";
            Response.Redirect(strURL + "frmLicenseUsers.aspx?");
        }
        
        
        private void rpts()
        {
            Session["cRG"] = "frmMainMGR";
            Response.Redirect(strURL + "frmReportGen.aspx?");
        }
        /*private void getProfile()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "eps_RetrieveOrgProfile";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "OrgProfile");
            if (ds.Tables["OrgProfile"].Rows.Count == 0)
            {
                //setProfile();
                lblOrg.Text = "Warning:  System Error - No Profile.  "
                    + " Please Exit and Report the following"
                    + " information to System Administrator:  "
                    + Session["OrgName"].ToString()
                    + "Org Id=" + Session["OrgId"].ToString() + ".";
            }
            else
            {
                Session["ProfilesId"] = ds.Tables["OrgProfile"].Rows[0][0].ToString();
                Session["ProfilesName"] = ds.Tables["OrgProfile"].Rows[0][1].ToString();
            }
        }*/
        protected void btnERS_Click(object sender, EventArgs e)
        {
            //Report = "ERS";
            //reportGen();
        }
        protected void btnER1_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Int32.Parse(Session["ProfilesId"].ToString());
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptBIA.rpt";
            rpts();
        }
        protected void btnStfT_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
            paramField2.ParameterFieldName = "OrgId";
            discreteval2.Value = Int32.Parse(Session["OrgId"].ToString());
            paramField2.CurrentValues.Add(discreteval2);
            paramFields.Add(paramField2);

            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptOrgTORs.rpt";
            rpts();	
        }
        protected void btnTeams_Click(object sender, EventArgs e)
        {
            /*ParameterFields paramFields = new ParameterFields();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
            paramField2.ParameterFieldName = "OrgId";
            discreteval2.Value = Int32.Parse(Session["OrgId"].ToString());
            paramField2.CurrentValues.Add(discreteval2);
            paramFields.Add(paramField2);

            Session["ReportParameters"] = paramFields;*/
            Session["ReportName"] = "rptOrgTeams.rpt";
            rpts();
        }
        protected void btnERP_Click(object sender, EventArgs e)
        {
            Report = "ERP";
            reportGen();
        }
 
        protected void btnERA_Click(object sender, EventArgs e)
        {
            Report = "ERA";
            reportGen();
           
        }
        protected void btnGS_Click(object sender, EventArgs e)
        {
            Session["CInv"] = "frmMainMgr";
            Response.Redirect(strURL + "frmInventory.aspx?");
        }
        protected void btnERG_Click(object sender, EventArgs e)
        {
            Session["CInv"] = "frmMainMGR";
            Response.Redirect(strURL + "frmInventory.aspx?");
        }
    protected void btnERTT_Click(object sender, EventArgs e)
        {
            //Report = "ERTT";
            //reportGen();

        }
        private void reportGen()
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
            paramField2.ParameterFieldName = "OrgId";
            discreteval2.Value = Int32.Parse(Session["OrgId"].ToString());
            paramField2.CurrentValues.Add(discreteval2);
            paramFields.Add(paramField2);

            /*ParameterField paramField3 = new ParameterField();
            ParameterDiscreteValue discreteval3 = new ParameterDiscreteValue();
            paramField3.ParameterFieldName = "RFormat";
            discreteval3.Value = rblRep.SelectedValue;
            paramField3.CurrentValues.Add(discreteval3);
            paramFields.Add(paramField3);*/


            Session["ReportParameters"] = paramFields;
            if (Report == "ERTT")
            {
                Session["ReportName"] = "rptOrgTT.rpt";
            }
            else if (Report == "Resources")
            {
                Session["ReportName"] = "rptOrgInvRes.rpt";
            }
            else if (Report == "ERInv")
            {
                Session["ReportName"] = "rptOrgInv.rpt";
            }
            else if (Report == "ERA")
            {
                Session["ReportName"] = "rptOrgStaffAssign.rpt";
            }
            else if (Report == "ERP")
            {
                Session["ReportName"] = "rptOrgProcs.rpt";
            }
            else if (Report == "ERS")
            {
                Session["ReportName"] = "rptOrgServices.rpt";
            }
            else if (Report == "Teams")
            {
                Session["ReportName"] = "rptOrgTeams.rpt";
            }
            else if (Report == "Roles")
            {
                Session["ReportName"] = "rptOrgTORs.rpt";
            }
            else if (Report == "Business")
            {
                Session["ReportName"] = "rptOrgTORs.rpt";
            }
            rpts();	
        }
        private void reportGenProfile()
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Int32.Parse(Session["ProfilesId"].ToString());
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            if (Report == "Business")
            {
                Session["ReportName"] = "rptBIA.rpt";
            }
            rpts();
        }

        private void reportGenOrgId()
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "OrgId";
            discreteval.Value = Int32.Parse(Session["OrgId"].ToString());
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            switch (Report)
            {
                case "":
                case "rptBudgetR1":
                    Session["ReportName"] = "rptBudgetR1.rpt";
                    break;
                case "rptBudgetR3":
                    Session["ReportName"] = "rptBudgetR3.rpt";
                    break;
                case "rptBudOrgOutputs":
                    Session["ReportName"] = "rptBudOrgOutputs.rpt";
                    break;
                case "rptBudOrgClients":
                    Session["ReportName"] = "rptBudOrgClients.rpt";
                    break; 
                case "rptStaffActions":
                    Session["ReportName"] = "rptStaffActions.rpt";
                    break;
                case "rptProcurements":
                    Session["ReportName"] = "rptProcurements.rpt";
                    break;
                 default:
                    Session["ReportName"] = "rptBudgetR1.rpt";
                    break;

            }
            rpts();
        }
        protected bool CheckDate(String date)
        {
            DateTime Temp;

            if (DateTime.TryParse(date, out Temp) == true)
                return true;
            else
                return false;
        }
        private void reportGenDate()
        {
            if (CheckDate(txtAsOfDate.Text))
            {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "AsOf";
            if (lstRepPB.SelectedValue == "rptBudgetR3" ||
                lstRepPB.SelectedValue == "rptBudgetR3S" ||
                lstRepPB.SelectedValue == "rptBudgetR3O")
            {
                discreteval1.Value = txtAsOfDate.Text;//DateTime.Now.ToString("M/d/yyyy");
            }
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            ParameterField paramField2 = new ParameterField();
            ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
            paramField2.ParameterFieldName = "OrgId";
            discreteval2.Value = Int32.Parse(Session["OrgId"].ToString());
            paramField2.CurrentValues.Add(discreteval2);
            paramFields.Add(paramField2);

            Session["ReportParameters"] = paramFields;
            switch (Report)
            {
                case "rptBudgetR3":
                    Session["ReportName"] = "rptBudgetR3.rpt";
                    break;
                case "rptBudgetR3S":
                    Session["ReportName"] = "rptBudgetR3S.rpt";
                    break;
                case "rptBudgetR3O":
                    Session["ReportName"] = "rptBudgetR3O.rpt";
                    break;
                default:
                    Session["ReportName"] = "rptBudgetR1.rpt";
                    break;

            }
            rpts();
            }
            else
            {
                lblAsOf.Text="Please enter valid date in form mm/dd/yyyy)";
                lblAsOf.Font.Bold = true;
            }
        }
        protected void btnRep_Click(object sender, EventArgs e)
        {
            switch (lstRep.SelectedValue)
            {
                case "":
                case "Services":
                    Report = "ERS";
                    reportGen();
                    break;
                case "Assignments":
                    Report = "ERA";
                    reportGen();
                    break;
                case "Procedures":
                    Report = "ERP";
                    reportGen();
                    break;

                case "Timetables":
                    Report = "ERTT";
                    reportGen();
                    break;
                case "Roles":
                    Report = "Roles";
                    reportGen();
                    break;
                case "Teams":
                    Report = "Teams";
                    reportGen();
                    break;
                case "Goods":
                    Report = "Resources";
                    reportGen();
                    break;
                case "Inventory":
                    Report = "ERInv";
                    reportGen();
                    break;
                case "Business":
                    Report = "Business";
                    reportGenProfile();
                    break;
                case "rptBudgetR1":
                    Report = "rptBudgetR1";
                    reportGenOrgId();
                    break;
                case "rptBudgetR3":
                    Report = "rptBudgetR3";
                    reportGenDate();
                    break;
                case "rptBudOrgOutputs":
                    Report = "rptBudOrgOutputs";
                    reportGenOrgId();
                    break;
                case "rptBudOrgClients":
                    Report = "rptBudOrgClients";
                    reportGenOrgId();
                    break;

                default:
                    Report = "ERTT";
                    reportGen();
                    break;

            }
        }
        protected void btnERInv_Click(object sender, EventArgs e)
        {
            //Report = "ERInv";
            //reportGen();
           
        }
       
        private void EMBMOn()
        {
            btnPlan.Visible = true;
            btnBud.Visible = true;
            btnStaff.Visible = true;
            btnGS.Visible = true;
            btnProc.Visible = true;
            btnSec.Visible = true;
            
        }
        private void EMBMOff()
        {
            btnPlan.Visible = false;
            btnBud.Visible = false;
            btnStaff.Visible = false;
            btnGS.Visible = false;
            btnProc.Visible = false;
            btnSec.Visible = false;
        }
       
       
        protected void btnSM_Click(object sender, EventArgs e)
        {
            Session["CallerOpt"] = "SR";
            lblMode.Text = "Status Reporting";
            btnCS.Visible = false;
            //btnrptER1.Visible = false;
            /*btnERTT.Visible = false;
            btnERS.Visible = false;
            btnERA.Visible = false;
            btnERG.Visible = false;
            btnERP.Visible = false;
            btnERT.Visible = false;
            btnInv.Visible = false;*/
            btnCS.Visible = false;
            btnPlan.Visible = false;
            btnBud.Visible = false;
            btnStaff.Visible = false;
            btnGS.Visible = false;
            btnProc.Visible = false;
            btnSec.Visible = false;

        }
        protected void btnEM_Click(object sender, EventArgs e)
        {
            modeEM();

        }
        protected void btnBM_Click(object sender, EventArgs e)
        {
            modeBM();
        }
        private void modeBM()
        {
            EMBMOn();
            buttonsOn();
            Session["CallerOpt"] = "BM";
            Session["EPS"] = "0";
            lblMode.Text = "Business Management";
            btnEM.Visible = true;
            btnBM.Visible = false;
            btnProfile.Visible = true;
            btnCS.Visible = false;    
        }
        private void modeEM()
        {
            EMBMOn();
            buttonsOn();
            Session["CallerOpt"] = "EM";
            Session["EPS"] = "1";
            lblMode.Text = "Emergency Management";

            btnEM.Visible = false;
            btnBM.Visible = true;
            btnProfile.Visible = true;
            btnCS.Visible = true;
        }
        protected void btnERGS_Click(object sender, EventArgs e)
        {
            //Report = "ERGS";
            //reportGen();
        }
        protected void btnOrgC_Click(object sender, EventArgs e)
        {
            lblOrg.Visible = false;
            btnOrgC.Visible = false;
            lblOrgC.Visible = true;
            lstOrg.Visible = true;
        }
        protected void lstOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSessions();
            backToMenu(); 
        }
        
        
        private int GetIndexOfOrg(string s)
        {
            return (lstOrg.Items.IndexOf(lstOrg.Items.FindByValue(s)));
        }
        private void loadOrg()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrg";
            cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
            cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Orgs");
            if (ds.Tables["Orgs"].Rows.Count == 1)
            {
                OrgFlag = 1;
                btnOrgC.Visible = false;
            }
			lstOrg.DataSource = ds;
            lstOrg.DataMember = "Orgs";
            lstOrg.DataTextField = "Name";
            lstOrg.DataValueField = "Id";
            lstOrg.DataBind();
		}
        protected void btnOrgCExit_Click(object sender, EventArgs e)
        {
            backToMenu();
        }


        protected void btnRepPB_Click(object sender, EventArgs e)
        {
            switch (lstRepPB.SelectedValue)
            {
                case "":
                case "Services":
                    Report = "ERS";
                    reportGen();
                    break;
                case "Assignments":
                    Report = "ERA";
                    reportGen();
                    break;
                case "Procedures":
                    Report = "ERP";
                    reportGen();
                    break;

                case "Timetables":
                    Report = "ERTT";
                    reportGen();
                    break;
                case "Roles":
                    Report = "Roles";
                    reportGen();
                    break;
                case "Teams":
                    Report = "Teams";
                    reportGen();
                    break;
                case "Goods":
                    Report = "Resources";
                    reportGen();
                    break;
                case "Inventory":
                    Report = "ERInv";
                    reportGen();
                    break;
                case "Business":
                    Report = "Business";
                    reportGenProfile();
                    break;
                case "rptBudgetR1":
                    Report = "rptBudgetR1";
                    reportGenOrgId();
                    break;
                case "rptBudgetR3":
                    Report = "rptBudgetR3";
                    reportGenDate();
                    break;
                case "rptBudgetR3S":
                    Report = "rptBudgetR3S";
                    reportGenDate();
                    break;
                case "rptBudgetR3O":
                    Report = "rptBudgetR3O";
                    reportGenDate();
                    break;
                case "rptBudOrgOutputs":
                    Report = "rptBudOrgOutputs";
                    reportGenOrgId();
                    break;
                case "rptBudOrgClients":
                    Report = "rptBudOrgClients";
                    reportGenOrgId();
                    break;

                default:
                    Report = "ERTT";
                    reportGen();
                    break;

            }
        }
        protected void btnRepOth_Click(object sender, EventArgs e)
        {
            switch (lstRepOth.SelectedValue)
            {
                
                case "Inventory":
                    Report = "ERInv";
                    reportGen();
                    break;
                case "rptStaffActions":
                    Report = "rptStaffActions";
                    reportGenOrgId();
                    break;

                case "rptProcurements":
                    Report = "rptProcurements";
                    reportGenOrgId();
                    break;

                default:
                    Report = "ERInv";
                    reportGen();
                    break;
            }

        }
        protected void lstRepPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRepPB.SelectedValue == "rptBudgetR3" ||
                lstRepPB.SelectedValue == "rptBudgetR3S"||
                lstRepPB.SelectedValue == "rptBudgetR3O")
            {
                txtAsOfDate.Visible = true;
                lblAsOf.Visible = true;
                txtAsOfDate.Text = DateTime.Now.ToString("M/d/yyyy"); 
                btnRepPB1.Visible = true;
                btnRepPB.Visible = false;
            }
   
            else
            {
                txtAsOfDate.Visible = false;
                lblAsOf.Visible = false;
                btnRepPB1.Visible = false;
                btnRepPB.Visible = true;
            }
        }
        
        private void loadSessions()
        {
            Session["OrgId"] = lstOrg.SelectedItem.Value;
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveOrgData";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = lstOrg.SelectedValue;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Org");
            if (ds.Tables["Org"].Rows.Count == 0)
            {
                lblOrg.Text = "Warning:  System Error - No Profile.  "
                    + " Please Exit and Report the following"
                    + " information to System Administrator:  "
                    + Session["OrgName"].ToString()
                    + "Org Id=" + Session["OrgId"].ToString() + ".";
            }
            else
            {
                Session["ProfilesId"] = ds.Tables["Org"].Rows[0][0].ToString();
                Session["ProfilesName"] = ds.Tables["Org"].Rows[0][1].ToString();
                Session["OrgName"] = ds.Tables["Org"].Rows[0][2].ToString();
                Session["OrgIdP"] = ds.Tables["Org"].Rows[0][3].ToString();
                Session["OrgVis"] = ds.Tables["Org"].Rows[0][4].ToString();
                lblOrg.Text = Session["OrgName"].ToString();
            }
            getTRSFlag();
            getEPSFlag();
            getBRSFlag();
        }
        private void backToMenu()
        {
            lblOrg.Visible = true;
            lblOrgC.Visible = false; 
            if (OrgFlag == 0)
            {
                btnOrgC.Visible = true;
            }
            lstOrg.Visible = false;
            
            //Session["MgrId"] = lstOrg.SelectedItem.Value; 
                     
        }
        private void getPeopleId()
        {
            Object tmp = new object();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveUserIdName";
            cmd.Parameters.Add("@UserId", SqlDbType.NVarChar);
            cmd.Parameters["@UserId"].Value = Session["UserId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "UserPerson");
            /*tmp = cmd.ExecuteScalar();*/
            Session["UserPerson"] = ds.Tables["UserPerson"].Rows[0][0];
            Session["LName"] = ds.Tables["UserPerson"].Rows[0][1];
            Session["Fname"] = ds.Tables["UserPerson"].Rows[0][2];
            Session["CellPhone"] = ds.Tables["UserPerson"].Rows[0][3];
            Session["HomePhone"] = ds.Tables["UserPerson"].Rows[0][4];
            Session["WorkPhone"] = ds.Tables["UserPerson"].Rows[0][5];
            Session["Address"] = ds.Tables["UserPerson"].Rows[0][6];
            Session["Email"] = ds.Tables["UserPerson"].Rows[0][7];
        }

        protected void btnFunds_Click(object sender, EventArgs e)
        {
            Session["MgrOption"] = "SOF";
            getBRSFlag();
            Session["CBudgets"] = "frmMainMgr";
            Response.Redirect(strURL + "frmBudgets.aspx?");
        }
        
        protected void btnERs_Click(object sender, EventArgs e)
        {
                Session["CallerBCER"] = "frmMainMgr";
                Session["FY"] = "";
                Session["Curr"] = "";
                Session["OrgCurrId"] = "";
                Response.Redirect(strURL + "frmBudCurrERs.aspx?");
        }
        protected void btnAptStr_Click(object sender, EventArgs e)
        {
            Session["CAptTypes"] = "frmMainMgr";
            Session["MgrOption"] = "AptStruct";
            Response.Redirect(strURL + "frmOrgStaffTypes.aspx?");
        }
}
}
