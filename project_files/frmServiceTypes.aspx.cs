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
    public partial class frmServiceTypes : System.Web.UI.Page
    {
        /*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
            "uid=tauheed;pwd=tauheed;");*/
        private static string strURL =
            System.Configuration.ConfigurationSettings.AppSettings["local_url"];
        private static string strDB =
            System.Configuration.ConfigurationSettings.AppSettings["local_db"];
        public SqlConnection epsDbConn = new SqlConnection(strDB);
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
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                    DataGrid1.Columns[5].Visible = false;
                if (Session["CServiceTypes"].ToString() == "frmMainControl")
                {

                    DataGrid1.Columns[3].Visible = false;
                    btnAddAll.Visible = true;
                }
                else
                {
                    
                    DataGrid1.Columns[1].Visible = false;
                    DataGrid1.Columns[3].Visible =true;
                    DataGrid1.Columns[4].Visible = false;
                    btnAddAll.Visible = false;
                }
            }
            else if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["CServiceTypes"].ToString() == "frmProfileServiceTypes")
                {
                    btnRpt1.Visible = false;
                    btnRpt5.Visible = false;
                    btnRpt6.Visible = false;
                     lblTitle.Text = "Service List";
                    DataGrid1.Columns[1].Visible = false;
                    DataGrid1.Columns[3].Visible = false;
                    DataGrid1.Columns[4].Visible = false;
                    DataGrid1.Columns[5].Visible = false;
                    btnAddAll.Visible = false;
                    lblProcs.Visible = false;
                    btnRpt2.Visible = false;
                    lblStaff.Visible = false;
                    btnRpt3.Visible = false;
                    btnRpt4.Visible = false;
                    DataGrid1.Columns[13].Visible = true;
                    
                    btnExit.Text = "OK";
                    lblContents.Text = "Please select services you wish to add to the business model then click 'OK'.";

                }
                else if (Session["CServiceTypes"].ToString() == "frmProfiles")
                {
                    lblTitle.Text = "EcoSys:  Individual/Household Characteristics";
                    lblTitle1.Text = "Type of Characteristic:  " + Session["ProfilesName"].ToString();
                    lblContents.Text = "To continue, click on 'Select' for the appropriate stage below.";
                      DataGrid1.Columns[2].HeaderText = "Stage";
                    DataGrid1.Columns[1].Visible = false;
                    DataGrid1.Columns[4].Visible = false;
                    DataGrid1.Columns[5].Visible = false;
                    DataGrid1.Columns[13].Visible = false;
                    btnAddAll.Visible = false;
                    lblProcs.Visible = false;
                    btnRpt1.Visible = false;
                    btnRpt2.Visible = false;
                    lblStaff.Visible = false;
                    btnRpt3.Visible = false;
                    btnRpt4.Visible = false;
                    btnRpt5.Visible = false;
                    btnRpt6.Visible = false;
                     btnExit.Text = "OK";
                    lblContents.Text = "";

                }
                else
                {
                    lblContents.Text = "As indicated earlier, a service model"
                    + " identifies the full set of service"
            + " deliverables, as well as related delivery procedures, staffing and other resource requirements."
            + " Listed below are the service models for which you are one of the designated authors."
            + " In the over-all EcoSys suite of systems, these service models, serve as building blocks for"
            + " business models.";
                    
                    DataGrid1.Columns[1].Visible = false;
                    DataGrid1.Columns[3].Visible = false;
                    DataGrid1.Columns[4].Visible = false;
                    btnAddAll.Visible = false;
                }
            }
            else
            {
                DataGrid1.Columns[4].Visible = false;
            }
            if (!IsPostBack)
            {
                /*if (Session["startForm"].ToString() == "frmMainControl")
                {
                    lblContent1.Text = "Update this service, including business processes "
                        + " normally associated with this service"
                        + ". You may identify services not included in this list by clicking"
                        + " on the 'Add Services' button.";
                }
                else if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {

                    lblContent1.Text = "";
                    lblProcs.Text = "";
                    lblStaff.Text = "";
                    lblOther.Text = "";
                    lblUpdate.Text = "To update/add to the process models described by the reports above, click on the appropriate button"
                        + " against the list of services below.";
                }*/

                loadData();
            }

        }
        private void loadData()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = this.epsDbConn;
            cmd.CommandText = "wms_RetrieveServiceTypes";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["CServiceTypes"].ToString() == "frmMainProfileMgr")
                {
                    cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                    cmd.Parameters["@PeopleId"].Value = Session["PeopleId"].ToString();
                }
                else if (Session["ProfileType"].ToString() == "Consumer")
                {
                    cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                    cmd.Parameters["@HHFlag"].Value = 1;
                }
            }
            else
            {
                cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            }
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                if (Session["ProfileType"].ToString() == "Consumer")
                {
                    cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                    cmd.Parameters["@HHFlag"].Value = "1";
                }
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ST");
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            refreshGrid();
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["CServiceTypes"].ToString() == "frmProfileServiceTypes")
                {
                    refreshGrid1();
                }
            }
            else if (Session["startForm"].ToString() == "frmMainControl")
            {
                refreshGrid3();
            }
        }
        private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tb = (TextBox)(i.Cells[1].FindControl("txtSeq"));
                if (i.Cells[8].Text == "&nbsp;")
                {
                    tb.Text = "99";
                }
                else tb.Text = i.Cells[8].Text;
            }
        }
        private void refreshGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[13].FindControl("cbxSel"));

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Id from ProfileServiceTypes"
                        + " Where ServiceTypesId = " + i.Cells[0].Text
                        + " and ProfilesId = " + Session["ProfilesId"].ToString();
                cmd.Connection.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    cb.Checked = true;
                    cb.Enabled = false;                    
                }
                cmd.Connection.Close();  
            }
        }
       /* private void refreshGrid2()
        {
           
            foreach (DataGridItem i in DataGrid1.Items)
                if (i.Cells[14].Text == "1")
                {
                    Button btnD = (Button)(i.Cells[5].FindControl("btnDeliver"));
                    Button btnP = (Button)(i.Cells[5].FindControl("btnProcess"));

                    btnD.BackColor = Color.Cyan;
                    btnD.Text = "";
                    btnP.ForeColor = Color.White;
                    btnP.BackColor = Color.Cyan;
                    btnP.Text = "Profiles";
                    btnP.CommandName="Profiles";
                    i.BackColor = Color.Cyan;
                    i.ForeColor = Color.White;
                    if (Session["startForm"].ToString() == "frmMainControl")
                    {
                        btnP.Enabled = false;
                    }

                }
        }*/
        private void refreshGrid3()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                if (i.Cells[14].Text == "1")
                {
                    Button btnD = (Button)(i.Cells[5].FindControl("btnDeliver"));
                    Button btnP = (Button)(i.Cells[5].FindControl("btnProcess"));

                    btnD.BackColor = Color.Azure;
                    btnD.Text = "";
                    btnP.BackColor = Color.Aqua;
                    btnP.Text = "Profiles";
                    btnP.CommandName = "Profiles";
                    i.BackColor = Color.Aqua;
                }
            }
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            Exit();
        }
        /*private void updateGrid()
        {
            if (Session["CServiceTypes"].ToString() == "frmProfileServiceTypes")
            {
                foreach (DataGridItem i in DataGrid1.Items)
                {
                    CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
                    if ((cb.Checked == true) & (cb.Enabled==true))
                    {
                        SqlCommand cmd=new SqlCommand();
                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.CommandText="wms_UpdateProfileServiceTypes";
                        cmd.Connection=this.epsDbConn;
                        cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                        cmd.Parameters ["@ServiceTypesId"].Value=i.Cells[0].Text;
                        cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
                        cmd.Parameters ["@ProfilesId"].Value=Session["ProfilesId"].ToString();
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
            else if (Session["CServiceTypes"].ToString() == "frmPSEPSer")
            {
                foreach (DataGridItem i in DataGrid1.Items)
                {
                    CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
                    if ((cb.Checked == true) & (cb.Enabled==true))
                    {
                        SqlCommand cmd=new SqlCommand();
                        cmd.CommandType=CommandType.StoredProcedure;
                        cmd.CommandText="wms_UpdatePSEPSer";
                        cmd.Connection=this.epsDbConn;
                        cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                        cmd.Parameters ["@ServiceTypesId"].Value=i.Cells[0].Text;
                        cmd.Parameters.Add("@PSEPID", SqlDbType.Int);
                        cmd.Parameters ["@PSEPID"].Value=Session["PSEPID"].ToString();
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
            }
        }*/
        private void Exit()
        {
            Response.Redirect(strURL + Session["CServiceTypes"].ToString() + ".aspx?");
        }

        protected void btnLogoff_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEnd.aspx?");
        }
        protected void btnCancel_Click(object sender, System.EventArgs e)
        {
            if (Session["CServiceTypes"].ToString() == "frmMainControl")
            {
                updateGrid();
            }
            else if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["CServiceTypes"].ToString() == "frmProfileServiceTypes")
                {
                    updateGrid1();
                }
            }

            Response.Redirect(strURL + Session["CServiceTypes"].ToString() + ".aspx?");
        }
        private void updateGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[13].FindControl("cbxSel"));
                if ((cb.Checked) & (cb.Enabled))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdateProfileServiceTypes";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
                    cmd.Parameters["@ProfilesId"].Value = Session["ProfilesId"].ToString();
                    cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                    cmd.Parameters["@ServiceTypesId"].Value = i.Cells[0].Text;
                   cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
        private void updateGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tb = (TextBox)(i.Cells[2].FindControl("txtSeq"));
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdateSSeqNo";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = i.Cells[0].Text;
                    cmd.Parameters.Add("@Seq", SqlDbType.Int);
                    cmd.Parameters["@Seq"].Value = Int32.Parse(tb.Text);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }

        protected void btnAddAll_Click(object sender, System.EventArgs e)
        {
            Session["CUpdServiceTypes"] = "frmServiceTypes";
            Response.Redirect(strURL + "frmUpdServiceType.aspx?"
                + "&btnAction=" + "Add");
        }

        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            
        }
        private void rpts()
        {
            Session["cRG"] = "frmServiceTypes";
            Response.Redirect(strURL + "frmReportGen.aspx?");
        }
        protected void btnRpt1_Click(object sender, EventArgs e)
        {
        ParameterFields paramFields = new ParameterFields();
        ParameterField paramField = new ParameterField();
        ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
        paramField.ParameterFieldName = "PeopleId";
        if (Session["startForm"].ToString() == "frmMainControl")
        {
            discreteval.Value = "0";
        }
        else
        {
            discreteval.Value = Session["PeopleId"].ToString();
        }
        paramField.CurrentValues.Add(discreteval);
        paramFields.Add(paramField);
        Session["ReportParameters"] = paramFields;
        Session["ReportName"] = "rptServiceDeliverables.rpt";
        rpts();	
        }
        protected void btnRpt2_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "PeopleId";
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                discreteval.Value = "0";
            }
            else
            {
                discreteval.Value = Session["PeopleId"].ToString();
            }
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptServiceProcs.rpt";
            rpts();	

        }
        protected void btnRpt3_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "PeopleId";
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                discreteval.Value = "0";
            }
            else
            {
                discreteval.Value = Session["PeopleId"].ToString();
            } 
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProcStaff.rpt";
            rpts();	
        }
        protected void btnRpt4_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "PeopleId";
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                discreteval.Value = "0";
            }
            else
            {
                discreteval.Value = Session["PeopleId"].ToString();
            }
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProcOther.rpt";
            rpts();	

        }
        protected void btnRpt5_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "PeopleId";
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                discreteval.Value = "0";
            }
            else
            {
                discreteval.Value = Session["PeopleId"].ToString();
            }
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProcOutputs.rpt";
            rpts();	

        }
        protected void btnRpt6_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "PeopleId";
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                discreteval.Value = "0";
            }
            else
            {
                discreteval.Value = Session["PeopleId"].ToString();
            }
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProcClientImpacts.rpt";
            rpts();	

        }
        protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                Session["CUpdServiceTypes"] = "frmServiceTypes";
                Response.Redirect(strURL + "frmUpdServiceType.aspx?"
                    + "&btnAction=" + "Update"
                    + "&Id=" + e.Item.Cells[0].Text
                    + "&Name=" + e.Item.Cells[2].Text
                    + "&ParentId=" + e.Item.Cells[6].Text
                    + "&QtyMeasuresId=" + e.Item.Cells[7].Text
                    + "&Seq=" + e.Item.Cells[8].Text
                    + "&PJName=" + e.Item.Cells[9].Text
                    + "&PJNameS=" + e.Item.Cells[10].Text
                    + "&FunctionId=" + e.Item.Cells[11].Text
                    + "&Desc=" + e.Item.Cells[12].Text
                    + "&HHFlag=" + e.Item.Cells[14].Text
                    );
            }
            else if (e.CommandName == "Supply")
            {
                Session["CSEvents"] = "frmServiceTypes";
                Session["ServicesId"] = e.Item.Cells[0].Text;
                Session["ServiceName"] = e.Item.Cells[2].Text;
                Response.Redirect(strURL + "frmServiceEvents.aspx?");

            }
            else if (e.CommandName == "Profiles")
            {
                Session["CProfiles"] = "frmServiceTypes";
                Session["ServicesId"] = e.Item.Cells[0].Text;
                Session["ServiceName"] = e.Item.Cells[2].Text;
                Session["ProfileType"] = "Consumer";
                Session["Mode"] = "Profiles";
                Response.Redirect(strURL + "frmProfiles.aspx?");
            }
            else if (e.CommandName == "Processes")
            {
                Session["CProcs"] = "frmServiceTypes";
                Session["ServicesId"] = e.Item.Cells[0].Text;
                Session["ServiceName"] = e.Item.Cells[2].Text;
                Response.Redirect(strURL + "frmProcs.aspx?");

            }
            else if (e.CommandName == "Select")
            {
                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    if (Session["CServiceTypes"].ToString() == "frmProfileServiceTypes")
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "wms_UpdateProfileServiceTypes";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
                        cmd.Parameters["@ProfilesId"].Value = Session["ProfilesId"].ToString();
                        cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                        cmd.Parameters["@ServiceTypesId"].Value = Int32.Parse(e.Item.Cells[0].Text);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        /*SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "wms_UpdatePSEPSer";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                        cmd.Parameters["@ServiceTypesId"].Value = Int32.Parse(e.Item.Cells[0].Text);
                        cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                        cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();*/
                        Exit();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "wms_UpdatePeopleServiceTypes";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@ResTypesId", SqlDbType.Int);
                        cmd.Parameters["@ResTypesId"].Value = Int32.Parse(e.Item.Cells[0].Text);
                        cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                        cmd.Parameters["@PeopleId"].Value = Session["PeopleId"].ToString();
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        Exit();
                    }

                }
                else // i.e. frmProfileServiceTypes
                {
                    if (Session["startForm"].ToString() == "frmMainProfileMgr")
                    {
                        if (Session["ProfileType"].ToString() == "Consumer")
                        {
                            Session["CEventsAll"] = "frmServiceTypes";
                            Session["ServicesId"] = e.Item.Cells[0].Text;
                            Session["ServiceName"] = e.Item.Cells[2].Text;
                            Response.Redirect(strURL + "frmEventsAll.aspx?");
                        }
                    }
                    
                }
                //Exit();

            }
            else if (e.CommandName == "Delete")
            {
                //SqlCommand cmd=new SqlCommand();
                //cmd.CommandType=CommandType.StoredProcedure;
                //cmd.CommandText="wms_DeleteServiceType";
                //cmd.Connection=this.epsDbConn;
                //cmd.Parameters.Add ("@Id", SqlDbType.Int);
                //cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
                //cmd.Connection.Open();
                //cmd.ExecuteNonQuery();
                //cmd.Connection.Close();
                //loadData();
            }

        }
}

}

