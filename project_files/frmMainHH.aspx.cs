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
    public partial class MainOrgs : System.Web.UI.Page
    {
        private static string strURL =
            System.Configuration.ConfigurationSettings.AppSettings["local_url"];
        private static string strDB =
            System.Configuration.ConfigurationSettings.AppSettings["local_db"];
        protected System.Web.UI.WebControls.Button lblResME;
        public SqlConnection epsDbConn = new SqlConnection(strDB);
        private int GetIndexOfCountries(string s)
        {
            return (lstCountries.Items.IndexOf(lstCountries.Items.FindByValue(s)));
        }
        private int GetIndexOfStates(string s)
        {
            return (lstStates.Items.IndexOf(lstStates.Items.FindByValue(s)));
        }
        private int GetIndexOfLocs(string s)
        {
            return (lstLocs.Items.IndexOf(lstLocs.Items.FindByValue(s)));
        }
 /************************************************************************************************************
 * I.  Page Load and Exit
 * **********************************************************************************************************/
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

            if (!IsPostBack)
            {
                if (Session["CHH"] != null)
                {
                    btnOK.Visible = true;
                }
                loadHome();
            }
        }
        /***************************************************************************************************
         * btnOK:  Provides exit to calling form (with btnOK displayed only if accessed from another form)
         ***************************************************************************************************/
        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (Session["CHH"] != null)
            {
                if ((Session["CHH"].ToString() == "frmMainMgr")||(Session["CHH"].ToString() == "frmStart"))
                {
                    Response.Redirect(strURL + Session["CHH"].ToString() + ".aspx?");
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
        
/*******************************************************
* II.  Home Page Load
* *****************************************************/
   
        private void loadHome()
        {
            DataGrid1.Visible = false;
            DataGrid2.Visible = false;
            DataGrid3.Visible = false;
            btnPlan.Visible = true;
            btnRes.Visible = true;
            btnHome.Visible = false;
            btnOK2.Visible = false;
            
            lblIntro1.Text = "Welcome to EcoSys<sup>&copy;</sup>." ;
            lblIntro2.Text = "The buttons above provide you with customized information that"
            + " geared to help you protect yourself and your household from various types of natural and man-made hazards.  Specifically:";
            cleanAbout();
        }
        /*******************************************************
         * Returns to home page
         * *****************************************************/
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect(strURL + "frmMainHH.aspx?");
        }
        private void cleanHome()
        {

            btnPlan.Visible = false;
            btnHome.Text = "Cancel";
            btnHome.Visible = true;
            btnOKPlan1.Visible = true;
            lblIntro3.Visible = false;
            lblIntro3a.Visible = false;
            lblIntro4.Visible = false;
            lblIntro4a.Visible = false;
            lblIntro5.Visible = false;
            lblIntro5a.Visible = false;
        }
        
/*******************************************************************************************************************************
 * III.  btnPlan:  Generates Emergency Preparedness Checklist
 * *****************************************************************************************************************************/
        protected void btnPlan_Click(object sender, EventArgs e)
        {
            cleanHome();//Erase Home Page content
            cleanAbout(); 
            btnRes.Visible = false;
            btnAbout.Visible = false;
            loadData1();//Display household profiles - step 1 to generate checklist
            lblIntro1.Text = "Household Emergency Checklist";
            lblIntro2.Text = "You will now generate an emergency plan checklist that"
                + " is customized to your household characteristics and to your concerns.  Thus, for example, a household with small children will have"
                + " different needs compared to a household comprising an adult couple only.  Similarly, a household located inland will"
                + " have somewhat different concerns than one that is located in a coastal area.  You will therefore first select"
                + " the household characterists for which the report is to be customized in Step 1 below.  After you have made your"
                + " selections, click on 'Continue to Step 2'";
            DataGrid1.Visible = true;
            btnOKPlan1.Visible = true;
        }
        private void loadData1()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveProfilesAll";
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ProfilesAll");
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            refreshGrid1();
        }
        private void refreshGrid1()
        {

            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                if (i.Cells[4].Text == "1")
                {
                    i.BackColor = Color.Black;
                    i.ForeColor = Color.Black;
                    cb.Visible = false;
                }
            }
        }
        
        protected void btnOKPlan1_Click(object sender, EventArgs e)
        {
            if (btnOKPlan1.Text == "Continue to Step 2")
            {
                DataGrid1.Visible = false;       
                btnOKPlan1.Text = "Return to Step 1"; 
                loadData2();//Display risks - step 2 to generate checklist
                DataGrid2.Visible = true;
                btnOKPlan2.Visible = true;
                lblIntro1.Text = "Household Emergency Checklist:  Step 2";
                lblIntro2.Text = "In Step 2 below, select the types of emergency events for which you wish to make preparations."
                + " Once you have made your selections, click on 'Generate Report' and wait for the report to be prepared.  You may wish to print out the"
                + " report for easy reference once it is prepared.  If you wish to continue to work on this website after you have "
                + " generated the report, use the browser button to return to this page.  Alternatively, you may simply select this web-site"
                + " address again.";
            }
            else
            { 
                btnOKPlan1.Text = "Continue to Step 2";
                DataGrid1.Visible = true;
                DataGrid2.Visible = false;
                btnOKPlan2.Visible = false;
                lblIntro1.Text = "Household Emergency Checklist:  Step 1";
                lblIntro2.Text = "You will now generate an emergency plan checklist that"
                + " is customized to your household characteristics and to your concerns.  Thus, for example, a household with small children will have"
                + " different needs compared to a household comprising an adult couple only.  Similarly, a household located inland will"
                + " have somewhat different concerns than one that is located in a coastal area.  You will therefore first select"
                + " the household characterists for which the report is to be customized in Step 1 below.  After you have made your"
                + " selections, click on 'Continue to Step 2'";
            } 
        }
        private void loadData2()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveEventsAll";
            cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
            cmd.Parameters["@HHFlag"].Value = "1";
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "EventsAll");
            Session["ds"] = ds;
            DataGrid2.DataSource = ds;
            DataGrid2.DataBind();
            refreshGrid2();
        }
        private void refreshGrid2()
        {

            foreach (DataGridItem i in DataGrid2.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel0"));
                if (i.Cells[4].Text == "1")
                {
                    i.BackColor = Color.Maroon;
                    i.ForeColor = Color.Maroon;
                    cb.Visible = false;
                }
            }
        }
         /*******************************************************
         * btnOKPlan2:  Generates Emergency Preparedness Checklist
         * *****************************************************/
        protected void btnOKPlan2_Click(object sender, EventArgs e)
        {
            prepareReport();
        }
        private void rpts()
        {
            Session["cRG"] = "frmMainHH";
            Response.Redirect(strURL + "frmReportGen.aspx?");
        }
        private void prepareReport()
        {
            ParameterFields myParams = new ParameterFields();
            ParameterField myParam = new ParameterField();
            myParam.ParameterFieldName = "ProfilesId";

            int Check1 = 0;
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                if (cb.Checked)
                {
                    Check1 = 1;
                    ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();

                    myDiscreteValue.Value = Int32.Parse(i.Cells[0].Text);
                    myParam.CurrentValues.Add(myDiscreteValue);
                }
                else
                {
                    if (i.Cells[4].Text == "1")
                    {
                        ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();
                        myDiscreteValue.Value = Int32.Parse(i.Cells[0].Text);
                        myParam.CurrentValues.Add(myDiscreteValue);
                    }

                }
            }

            if (Check1 == 0)
            {
                lblIntro1.ForeColor = Color.Orange;
                lblIntro1.Text = "In order to generate a report, you must select at least one household characteristic.";
            }
            else
            {
                ParameterField myParam1 = new ParameterField();
                myParam1.ParameterFieldName = "EventsId";

                int Check2 = 0;
                foreach (DataGridItem j in DataGrid2.Items)
                {
                    CheckBox cb1 = (CheckBox)(j.Cells[3].FindControl("cbxSel0"));
                    if (cb1.Checked)
                    {
                        Check2 = 1;
                        ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();
                        myDiscreteValue1.Value = Int32.Parse(j.Cells[0].Text);
                        myParam1.CurrentValues.Add(myDiscreteValue1);
                    }
                    else
                    {
                        if (j.Cells[4].Text == "1")
                        {
                            ParameterDiscreteValue myDiscreteValue1 = new ParameterDiscreteValue();
                            myDiscreteValue1.Value = Int32.Parse(j.Cells[0].Text);
                            myParam1.CurrentValues.Add(myDiscreteValue1);
                        }

                    }

                }
                if (Check2 == 0)
                {
                    lblIntro1.ForeColor = Color.Orange;
                    lblIntro1.Text = "In order to generate a report, you must select at least one emergency event.";
                }
                else
                {
                    myParams.Add(myParam1);
                    myParams.Add(myParam);

                    Session["ReportParameters"] = myParams;
                    Session["ReportName"] = "rptHouseholdPlan.rpt";
                    rpts();
                }
            }
        }        
 /*******************************************************
 * IV.  btnRes (Button Emergency Services):  displays location, displays services in a given location
 * *****************************************************/
        /*******************************************************
        * IVa.  btnRes (Button Emergency Services):  displays locations
        * *****************************************************/
        protected void btnRes_Click(object sender, EventArgs e)
        {
            cleanHome();
            cleanAbout();
            cleanCheck();
            btnHome.Visible = true;
            btnAbout.Visible = false;
            lblIntro1.Text = "Emergency Services";
            lblIntro2.Text = "You will now generate list of "
                + " emergency services available in your area.  You will therefore first identify"
                + " the area you live in below, then click on 'Show Services'.";
            btnRes.Visible = false;
            btnOK2.Visible = true;
   
            loadCountries();
            loadStates();
            loadLocs();
            
            lblCountry.Visible = true;
            lblState.Visible = true;
            lblLoc.Visible = true;
            lstCountries.Visible = true;
            lstLocs.Visible = true;
            lstStates.Visible = true;
        }
       
        private void loadCountries()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveCountries";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Countries");
            lstCountries.DataSource = ds;
            lstCountries.DataMember = "Countries";
            lstCountries.DataTextField = "Name";
            lstCountries.DataValueField = "Id";
            lstCountries.DataBind();
        } 

        protected void lstCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadStates();
            loadLocs();
            if (lstLocs.SelectedItem == null)
            {
                btnOK2.Visible = false;
                lblIntro2.Text = "Sorry.  There are no emergency services identified in our database for this country."
                   + "Would you like to help maintain a list of emergency services"
                   + " in this country?"
                   + " If so, please contact me by sending an email to tauheedahmed@hotmail.com.";
            }
            else
            {
                if (lstStates.SelectedItem != null)
                {
                    lblIntro2.Text = "You will now generate list of "
                + " emergency services available in your area.  You will therefore first identify"
                + " the area you live in below, then click on 'Show Services'.";

                }
                if (lstLocs.SelectedItem != null)
                {
                   lblIntro2.Text = "You will now generate list of "
               + " emergency services available in your area.  You will therefore first identify"
               + " the area you live in below, then click on 'Show Services'.";
                }
            }
        }
        protected void lstStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLocs();
        }
        private void loadStates()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
            cmd.Parameters["@CountriesId"].Value = Int32.Parse(lstCountries.SelectedItem.Value);
            cmd.CommandText = "wms_RetrieveStates";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "States");
            if (ds.Tables["States"].Rows.Count == 0)
            {
                lblState.Visible = false;
                lstStates.Visible = false;
                lstLocs.Visible = false;
                lblLoc.Visible = false;
            }
            else
            {
                lblState.Visible = true;
                lstStates.Visible = true;
                lstLocs.Visible = true;
                lblLoc.Visible = true;
            }
            
            lstStates.DataSource = ds;
            lstStates.DataMember = "States";
            lstStates.DataTextField = "Name";
            lstStates.DataValueField = "Id";
            lstStates.DataBind();
        }
        private void loadLocs()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
           
            if (lstStates.SelectedItem != null)
            {
                cmd.Parameters.Add("@StatesId", SqlDbType.Int);
                cmd.Parameters["@StatesId"].Value = Int32.Parse(lstStates.SelectedItem.Value);
            }
            else
            { 
                cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
                cmd.Parameters["@CountriesId"].Value = Int32.Parse(lstCountries.SelectedItem.Value);
            }
            cmd.CommandText = "wms_RetrieveLocs";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Locations");
            if (ds.Tables["Locations"].Rows.Count == 0)
            {
                lstLocs.Visible = false;
                lblLoc.Visible = false;
            }
            else
            {
                lstLocs.Visible = true;
                lblLoc.Visible = true;
            }
            lstLocs.DataSource = ds;
            lstLocs.DataMember = "Locations";
            lstLocs.DataTextField = "Name";
            lstLocs.DataValueField = "Id";
            lstLocs.DataBind();

        }
        /*******************************************************
        * IVb.  btnRes (Button Emergency Services):  displays services in a given location
        * *****************************************************/
        protected void btnOK2_Click(object sender, EventArgs e)
        {
            btnHome.Text = "Home";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveHHContractSupplies";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
            cmd.Parameters["@CountriesId"].Value = Int32.Parse(lstCountries.SelectedValue);
            
            if (lstStates.SelectedItem !=null)
            {   
                cmd.Parameters.Add("@StatesId", SqlDbType.Int);
                cmd.Parameters["@StatesId"].Value = Int32.Parse(lstStates.SelectedValue);
            }
            if (lstLocs.SelectedItem != null)
            {
                cmd.Parameters.Add("@LocsId", SqlDbType.Int);
                cmd.Parameters["@LocsId"].Value = Int32.Parse(lstLocs.SelectedValue);
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "HHRes");
            if (ds.Tables["HHRes"].Rows.Count == 0)
            {
                lblIntro1.Text = "There are no services in the area below that have been identified.";
                lblIntro2.Text = "Would you like to help maintain contact information for basic fire, security and emergency services"
                + " in your area?"
                    + " Do you know of other organizations that might be interested in participating in "
                    + " strengthening local community efforts at emergency preparedness?"  
                    + " If so, please contact me by sending an email to tauheedahmed@hotmail.com.";
                
            }
            else
            {

                Session["ds"] = ds;
                DataGrid3.DataSource = ds;
                DataGrid3.DataBind();

                btnOK2.Visible = false;
                lblCountry.Visible = false;
                lblState.Visible = false;
                lblLoc.Visible = false;
                lstCountries.Visible = false;
                lstLocs.Visible = false;
                lstStates.Visible = false;

                lblIntro1.Text = "Emergency Services";
                lblIntro2.Text = "Given below is a list of emergency services in your area.";
                    

                DataGrid3.Visible = true;
            }
        }
        private void cleanAbout()
        {
            lblAbout1.Visible = false;
            lblAbout2.Visible = false;
            lblAbout3.Visible = false;
            lblAbout4.Visible = false;
        }
        private void cleanCheck()
        {
            btnPlan.Visible = false;
            btnOKPlan1.Visible = false;
            btnOKPlan2.Visible = false;

        }
        protected void btnAbout_Click(object sender, EventArgs e)
        {
            lblIntro1.Visible = false;
            lblIntro2.Visible=false;
            lblAbout1.Visible=true;
            lblAbout2.Visible=true;
            lblAbout3.Visible = true;
            lblAbout4.Visible = true;
            bltAbout.Visible = true;
            cleanHome();
            cleanCheck();
           
            btnHome.Visible = true;
            btnHome.Text = "Home";
            btnAbout.Visible = false;
            btnRes.Visible = false;
        }

}
}

