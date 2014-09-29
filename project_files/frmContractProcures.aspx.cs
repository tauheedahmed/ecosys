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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
    public partial class frmContractProcures : System.Web.UI.Page
    {
        private static string strURL =
            System.Configuration.ConfigurationSettings.AppSettings["local_url"];
        private static string strDB =
            System.Configuration.ConfigurationSettings.AppSettings["local_db"];
        protected System.Web.UI.WebControls.Label Label2;
        public SqlConnection epsDbConn = new SqlConnection(strDB);
        char StateTypesName;
        private int GetIndexOfLocations(string s)
        {
            return (rblLocs.Items.IndexOf(rblLocs.Items.FindByValue(s)));
        }
       
        
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here
            if (!IsPostBack)
            {   
                lblOrg.Text = Session["OrgName"].ToString();
                lblContract.Text = "Contract/Commitment Title: " + Session["ContractTitle"].ToString();
                if (Session["MgrOption"].ToString() == "Procure")
                {
                    GridDeliver.Columns[8].Visible = false;
                    GridDeliver.Columns[2].HeaderText = " Delivery Location ";
                    lblContents1.Text = "Listed below are the procurement items to be acquired as part of contract"
                    + " titled '"
                    + Session["ContractTitle"].ToString()
                    + "' from the following supplier: '"
                    + Session["ContractSupplier"].ToString()
                    + "'."
                    + " To add items being procured through each contract,"
                    + " click on 'Add'."
                    + " To remove an item from this list, click on 'Remove'.";
                
                    GridProcure.Columns[0].Visible = false;
                    GridProcure.Columns[1].Visible = false;
                    GridProcure.Columns[6].HeaderText = " Price (in " + Session["CurrName"].ToString() + ")";
                    GridProcure.Columns[7].Visible = false;
                    GridProcure.Columns[8].Visible = false;
                    GridProcure.Columns[9].Visible = false;
                    loadProcure();
                    GridProcure.Visible = true;

                    GridProcureS.Columns[0].Visible = false;
                    GridProcureS.Columns[1].Visible = false;
                    GridProcureS.Columns[6].HeaderText = " Cost (in " + Session["CurrName"].ToString() + ")";
                    GridProcureS.Columns[7].Visible = false;
                    GridProcureS.Columns[8].Visible = false;
                    GridProcureS.Columns[9].Visible = false;
                    loadProcureS();
                    GridProcureS.Visible = true;
       
                }
                else if (Session["MgrOption"].ToString() == "Deliver")
                {
                    lblContents1.Text = "Listed below are the types of resources to be made made"
                        + " available as part of this commitment";
                    GridDeliver.Columns[1].Visible = false;
                    GridDeliver.Columns[2].Visible = false;
                    loadDeliver();
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
            this.GridDeliver.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.GridDeliver_ItemCommand);

        }
        #endregion
        /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
        /********************************* PART I Procure********************************************/
        /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
        private void loadProcure()
        {
            Session["Part"] = "Procure";
            GridProcure.Visible = true;
            lblContents1.Visible = true;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrievePSEPResInvG";
            cmd.Parameters.Add("@ContractId", SqlDbType.Int);
            cmd.Parameters["@ContractId"].Value = Session["ContractId"].ToString();
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ConItems");
            if (ds.Tables["ConItems"].Rows.Count == 0)
            {
                lblContents1.Text = "There are no procurement items identified for this contract."
                    + " Click on 'Add' to identify outstanding procurement requests (if any) that you may"
                    + " acquire as part of this contract";
                GridDeliver.Visible = false;
                GridProcure.Visible = false;
            }
            else
            {
                Session["ds"] = ds;
                GridProcure.DataSource = ds;
                GridProcure.DataBind();
                refreshGridG();
            }
        }

        private void refreshGridG()
        {
            foreach (DataGridItem i in GridProcure.Items)
            {
                TextBox tQ = (TextBox)(i.Cells[4].FindControl("txtQty"));
                TextBox tP = (TextBox)(i.Cells[6].FindControl("txtPrice"));
                
                if (i.Cells[8].Text.StartsWith("&") == false)
                {
                    tQ.Text = i.Cells[8].Text;
                }
                if (i.Cells[9].Text.StartsWith("&") == false)
                {
                    tP.Text = i.Cells[9].Text;
                }
            }                             
        }
        private void loadProcureS()
        {
            Session["Part"] = "Procure";
            GridProcure.Visible = true;
            lblContents1.Visible = true;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrievePSEPResInvS";
            cmd.Parameters.Add("@ContractId", SqlDbType.Int);
            cmd.Parameters["@ContractId"].Value = Session["ContractId"].ToString();
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ConItems");
            if (ds.Tables["ConItems"].Rows.Count == 0)
            {
                lblContents1.Text = "There are no procurement items identified for this contract."
                    + " Click on 'Add' to identify outstanding procurement requests (if any) that you may"
                    + " acquire as part of this contract";
               GridProcureS.Visible = false;
            }
            else
            {
                Session["ds"] = ds;
                
                GridProcureS.DataSource = ds;
                GridProcureS.DataBind();
                refreshGridS();
            }
        }
        private void refreshGridS()
        {
            foreach (DataGridItem i in GridProcureS.Items)
            {
                 TextBox tP = (TextBox)(i.Cells[6].FindControl("txtCost"));

                if (i.Cells[9].Text.StartsWith("&") == false)
                {
                    tP.Text = i.Cells[9].Text;
                }
            }            
        }
        
        /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/
        /********************************* PART II Deliver ******************************************/
        /*!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*/

        /********************************************************************************************/
        /********** Section Deliver:  List Supplies provided under contract ****************************/
        /********************************************************************************************/
        private void loadDeliver()
        {
            Session["Part"] = "Deliver"; 
            GridDeliver.Visible = true;
            lblContents1.Visible = true;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveContractSupplies";
            cmd.Parameters.Add("@ContractId", SqlDbType.Int);
            cmd.Parameters["@ContractId"].Value = Session["ContractId"].ToString();
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ConItems");
            if (ds.Tables["ConItems"].Rows.Count == 0)
            {
                lblContents1.Text = "There are no supply items identified for the above contract or commitment."
                    + " Click on 'Add' to identify the identify the resources you wish to supply as part of this contract or "
                    + " contract";
                GridDeliver.Visible = false;
            }
            Session["ds"] = ds;
            GridDeliver.DataSource = ds;
            GridDeliver.DataBind();
            refreshGridDeliver();
        }
        private void refreshGridDeliver()
        {
            foreach (DataGridItem i in GridDeliver.Items)
            {
                Button btLoc = (Button)(i.Cells[8].FindControl("btnLocations"));
                if (i.Cells[10].Text == "1")
                {
                    btLoc.Enabled = false;
                    btLoc.Text = "Anywhere";
                }
            }
        }
        /********************************************************************************************/
        /*********************************************  ADD SUPPLIES UNDER CONTRACT *****************/
        /********************************************************************************************/
        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (Session["MgrOption"].ToString() == "Procure")
                
            {
                Session["CCPAll"] = "frmContractProcures";
                Response.Redirect(strURL + "frmContractProcuresAll.aspx?");
            }
            else if (Session["MgrOption"].ToString() == "Deliver")
            {
                if (Session["Part"].ToString() == "Deliver")
                {
                    Session["RType"] = null;
                    Session["TableFlag"] = "1";
                    Session["CallerRTA"] = "frmContractProcures";
                    Response.Redirect(strURL + "frmResourceTypesAll.aspx?");
                }
                else if (Session["Part"].ToString() == "SCountries")
                {
                    DataGrid2.Visible = false;
                    Countries();
                }
                else if (Session["Part"].ToString() == "SStates")
                {
                    DataGrid4.Visible = false;
                    States();
                }
                else if (Session["Part"].ToString() == "SLocs")
                {
                    DataGrid4.Visible = false;
                    Locs();
                }
                else if (Session["Part"].ToString() == "Locs")
                {
                    DataGrid4.Visible = false;
                    LocsAdd();
                }
                else if (Session["Part"].ToString() == "LocsAdd")
                {
                    addLocation();
                    Locs();
                }
            }
        }

//INSERT ITEMCOMMANDGRIDDELIVERHRE
        private void loadCSCountries()
        {
            
            Session["Part"] = "SCountries";
            btnAdd.Text = "Add Countries";
            lblContents2.Visible = true;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveContractSuppliesCountries";
            cmd.Parameters.Add("@ContractSuppliesId", SqlDbType.Int);
            cmd.Parameters["@ContractSuppliesId"].Value = Int32.Parse(Session["Id"].ToString());
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ServiceCtrys");
            if (ds.Tables["ServiceCtrys"].Rows.Count == 0)
            {
                DataGrid2.Visible = false;
                lblContents2.Text = "You have not yet identified any country where the above service is avaiable.  "
                    + " Click on the button titled 'Add Countries' to continue.  If the service is available "
                    + " from anywhere, click on 'OK', to return to the previous menu.  From there select "
                    + " 'Details' for this service to indicate that the service is available from any location.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid2.DataSource = ds;
                DataGrid2.DataBind();

                DataGrid2.Visible = true;
                lblContents2.Text = "The list below shows the country (or countries) where you have indicated the "
                + " above service as being available.  If the service is available only at selected locations"
                + " within a given country, click on the button to its right titled 'State' or 'Province' to "
                + "continue.";
                refreshGrid2();
            }
        }
        private void refreshGrid2()
        {
            foreach (DataGridItem j in DataGrid2.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSel"));
                Button bt = (Button)(j.Cells[3].FindControl("btnStates"));
                Button btL = (Button)(j.Cells[3].FindControl("btnLocs"));
                if (j.Cells[5].Text == "1")
                {
                    cb.Checked = true;
                    if (j.Cells[8].Text == "1")
                    {
                        bt.Text = "Entire Country";
                        bt.Enabled = false;
                    }
                    else
                    {
                        btL.Text = "Entire Country";
                        btL.Enabled = false;
                    }
                }
                else
                {
                    if (j.Cells[8].Text == "1")
                    {
                        bt.Text = j.Cells[6].Text;
                        bt.Enabled = true;
                        btL.Visible = false;
                    }
                    else
                    {
                        bt.Visible = false;
                    }
                    
                }
            }
        }
        private void refreshGrid2a()
        {
            foreach (DataGridItem j in DataGrid2.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSel"));
                Button bt = (Button)(j.Cells[3].FindControl("btnStates"));
                Button btL = (Button)(j.Cells[3].FindControl("btnLocs"));
                if (cb.Checked)
                {
                    if (j.Cells[8].Text == "1")
                    {
                        bt.Text = "Entire Country";
                        bt.Enabled = false;
                    }
                    else
                    {
                        btL.Text = "Entire Country";
                        btL.Enabled = false;
                    }
                    
                }
                else
                {
                    if (j.Cells[8].Text == "1")
                    {
                        bt.Text = j.Cells[6].Text;
                        bt.Enabled = true;
                    }
                    else
                    {
                        btL.Text = "Locations";
                        btL.Enabled = true;
                    }
                    
                   
                }
            }
        }
        protected void cbxSel_CheckedChanged(object sender, EventArgs e)
        {
            refreshGrid2a();
        }
        private void updateCSCountries()
        {
            foreach (DataGridItem j in DataGrid2.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSel"));
              
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fms_UpdateCSCountriesFlag";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(j.Cells[7].Text);
                if (cb.Checked)
                {
                    cmd.Parameters.Add("@StatesFlag", SqlDbType.Int);
                    cmd.Parameters["@StatesFlag"].Value = 1;
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
        /********************************************************************************************/
        /********** Item Commands:  Contract Service Countries*************************************************************/
        /********************************************************************************************/

        protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fms_DeleteContractSuppliesCountries";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@CSCId", SqlDbType.Int);
                cmd.Parameters["@CSCId"].Value = e.Item.Cells[7].Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                updateCSCountries();
                loadCSCountries();
            }
            else if (e.CommandName == "States")
            {
                Session["CountriesId"] = Int32.Parse(e.Item.Cells[0].Text);
                DataGrid2.Visible = false;
                Session["CountryName"] = e.Item.Cells[1].Text;
                Session["States"] = e.Item.Cells[6].Text;
                updateCSCountries();
                loadCSStates();
            }
            else if (e.CommandName == "Locations")
            {
                Session["CountriesId"] = Int32.Parse(e.Item.Cells[0].Text);
                DataGrid2.Visible = false;
                Session["CountryName"] = e.Item.Cells[1].Text;
                updateCSCountries();
                loadCSLocs();
            }
        }
        /********************************************************************************************/
        /********** Part: All Countries*************************************************************/
        /********************************************************************************************/
        private void Countries()
        {
            Session["Part"] = "Countries";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveCountries";
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Countries");
            Session["ds"] = ds;
            DataGrid3.DataSource = ds;
            DataGrid3.DataBind();
            DataGrid3.Visible = true;
            refreshGrid3();
        }
        private void refreshGrid3()
        {
            foreach (DataGridItem k in DataGrid3.Items)
            {
                CheckBox cb = (CheckBox)(k.Cells[2].FindControl("cbxSel"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                if (Session["Part"].ToString() == "Countries")
                {
                    cmd.CommandText = "Select Id from ContractSuppliesCountries"
                        + " Where CountriesId = " + Int32.Parse(k.Cells[0].Text)
                        + " and ContractSuppliesId =" + Int32.Parse(Session["Id"].ToString());
                    cmd.Connection.Open();
                    if (cmd.ExecuteScalar() != null)
                    {
                        cb.Checked = true;
                        cb.Enabled = false;
                    }
                    cmd.Connection.Close();

                }
            }
        }
        /********************************************************************************************/
        /********** Part: Update Contract Service Countries *************************************************************/
        /********************************************************************************************/

        private void updateGrid3()
        {
            foreach (DataGridItem k in DataGrid3.Items)
            {
                CheckBox cb = (CheckBox)(k.Cells[2].FindControl("cbxSel"));
                if ((cb.Checked) & (cb.Enabled))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdateContractSuppliesCountries";
                    if (Session["Part"].ToString() == "Countries")
                    {
                        cmd.Parameters.Add("@ContractSuppliesId", SqlDbType.Int);
                        cmd.Parameters["@ContractSuppliesId"].Value = Session["Id"].ToString();
                        cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
                        cmd.Parameters["@CountriesId"].Value = k.Cells[0].Text;
                    }
                    cmd.Connection = this.epsDbConn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }

        /****END OF COUNTRIES ********************************************************
         * 
         * 
        /********************************************************************************************/
        /*********************** Part: Service States ***********************************************/
        /********************************************************************************************/
        private void loadCSStates()
        {
            Session["Part"] = "SStates";
            lblCountryName.Text = "Country: " + Session["CountryName"].ToString();
            lblStateName.Text = "";
            btnAdd.Text = "Add " + Session["States"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveContractSuppliesStates";
            cmd.Parameters.Add("@ContractSuppliesId", SqlDbType.Int);
            cmd.Parameters["@ContractSuppliesId"].Value = Int32.Parse(Session["Id"].ToString());
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
            cmd.Parameters["@CountriesId"].Value = Int32.Parse(Session["CountriesId"].ToString());
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ServiceStates");
            if (ds.Tables["ServiceStates"].Rows.Count == 0)
            {
                DataGrid4.Visible = false;
                lblContents2.Text = "You have not yet identified any "
                + Session["States"].ToString()
                + " where the above service is avaiable.  "
                    + " Click on the button titled 'Add "
                + Session["States"].ToString()
                + " ' to continue.  If the service is available "
                    + " from anywhere in the "
                + Session["States"].ToString()
                +  ", click on 'OK', to return to the previous menu.  From there select "
                    + " 'Details' for this service to indicate that the service is available from any location.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid4.DataSource = ds;
                DataGrid4.DataBind();

                DataGrid4.Visible = true;
                lblContents2.Text = "The list below shows the "
                + Session["States"].ToString() 
                + " where you have indicated the "
                + " above service as being available.";
                refreshGrid4();
            }
        }
        private void refreshGrid4()
        {
            foreach (DataGridItem j in DataGrid4.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSelStates"));
                Button bt = (Button)(j.Cells[3].FindControl("btnLocs"));
                if (j.Cells[5].Text == "1")
                {
                    cb.Checked = true;
                    bt.Text = "All Locations";
                    bt.Enabled = false;
                }
                else
                {
                    bt.Text = "Locations";
                    bt.Enabled = true;
                }
            }
        }
        private void refreshGrid4a()
        {
            foreach (DataGridItem j in DataGrid4.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSelStates"));
                Button bt = (Button)(j.Cells[3].FindControl("btnLocs"));
                if (cb.Checked)
                {
                    bt.Enabled = false;
                    bt.Text = "All Locations";
                }
                else
                {
                    bt.Enabled = true;
                    bt.Text = "Locations";
                }
            }
        }
         protected void cbxSelStates_CheckedChanged(object sender, EventArgs e)
        {
            refreshGrid4a();
        }
        private void updateCSStates()
        {
            foreach (DataGridItem j in DataGrid4.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSelStates"));

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "fms_UpdateCSStatesFlag";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(j.Cells[6].Text);
                if (cb.Checked)
                {
                    cmd.Parameters.Add("@LocsFlag", SqlDbType.Int);
                    cmd.Parameters["@LocsFlag"].Value = 1;
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
        /********************************************************************************************/
        /********** Item Commands:  Contract Service States*************************************************************/
        /********************************************************************************************/

        protected void DataGrid4_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                if (Session["Part"].ToString() == "SStates")
                { 
                    cmd.CommandText = "fms_DeleteContractSuppliesStates";
                    cmd.Parameters.Add("@CSSId", SqlDbType.Int);
                    cmd.Parameters["@CSSId"].Value = Int32.Parse(e.Item.Cells[6].Text);
                }
                else if (Session["Part"].ToString() == "SLocs")
                {
                    cmd.CommandText = "fms_DeleteContractSuppliesLocs";
                    cmd.Parameters.Add("@CSLId", SqlDbType.Int);
                    cmd.Parameters["@CSLId"].Value = Int32.Parse(e.Item.Cells[6].Text);
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                if (Session["Part"].ToString() == "States")
                {
                    updateCSStates();
                    loadCSStates();
                }
                else if (Session["Part"].ToString() == "SLocs")
                {
                    loadCSLocs();
                }
            }
            else if (e.CommandName == "Locs")
            {
                Session["StatesId"] = Int32.Parse(e.Item.Cells[0].Text);
                Session["StateName"] = e.Item.Cells[1].Text;
                updateCSStates();//sets ContractSuppliesStates.LocsFlag to indicate if service is statewide
                loadCSLocs();
            }
        }
        /********************************************************************************************/
        /********** Part: All States *************************************************************/
        /********************************************************************************************/
        private void States()
        {
            Session["Part"] = "States";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveStates";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
            cmd.Parameters["@CountriesId"].Value = Int32.Parse(Session["CountriesId"].ToString());
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "States");
            if (ds.Tables["States"].Rows.Count == 0)
            {
                lblContents2.Text = "There are no "
                    + Session["States"].ToString()
                    + " identified for this country.  Click on 'Add States' to Continue.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid5.DataSource = ds;
                DataGrid5.DataBind();
                DataGrid5.Visible = true;
                refreshGrid5();
                lblContents2.Text = "Please select" + Session["States"].ToString() + " where the above service is available";
            }
        }
        private void refreshGrid5()
        {
            foreach (DataGridItem k in DataGrid5.Items)
            {
                CheckBox cb = (CheckBox)(k.Cells[2].FindControl("cbxSel"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                if (Session["Part"].ToString() == "States")
                {
                    cmd.CommandText = "Select Id from ContractSuppliesStates"
                        + " Where StatesId = " + Int32.Parse(k.Cells[0].Text)
                        + " and ContractSuppliesId =" + Int32.Parse(Session["Id"].ToString());
                }
                else if (Session["Part"].ToString() == "Locs")
                {
                    cmd.CommandText = "Select Id from ContractSuppliesLocs"
                        + " Where LocsId = " + Int32.Parse(k.Cells[0].Text)
                        + " and ContractSuppliesId =" + Int32.Parse(Session["Id"].ToString());
                }
                cmd.Connection.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    cb.Checked = true;
                    cb.Enabled = false;
                }
                cmd.Connection.Close();
            }
        }
        /********************************************************************************************/
        /********** Part: Update Contract Service States *************************************************************/
        /********************************************************************************************/

        private void updateGrid5()
        {
            foreach (DataGridItem k in DataGrid5.Items)
            {
                CheckBox cb = (CheckBox)(k.Cells[2].FindControl("cbxSel"));
                if ((cb.Checked) & (cb.Enabled))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Session["Part"].ToString() == "States")
                    {
                        cmd.CommandText = "fms_UpdateContractSuppliesStates";                    
                        cmd.Parameters.Add("@StatesId", SqlDbType.Int);
                        cmd.Parameters["@StatesId"].Value = k.Cells[0].Text;
                    }
                    else if (Session["Part"].ToString() == "Locs")
                    {
                        cmd.CommandText = "fms_UpdateContractSuppliesLocs";                    
                        cmd.Parameters.Add("@LocsId", SqlDbType.Int);
                        cmd.Parameters["@LocsId"].Value = k.Cells[0].Text;
                    }
                    cmd.Parameters.Add("@ContractSuppliesId", SqlDbType.Int);
                    cmd.Parameters["@ContractSuppliesId"].Value = Session["Id"].ToString();

                    cmd.Connection = this.epsDbConn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
        /********************STATE ENDS HERE*********************************************************/
        /********************************************************************************************/
        /********************************************************************************************/
        /*********************** Part: Service Locs ***********************************************/
        /********************************************************************************************/
        private void loadCSLocs()
        {
            Session["Part"] = "SLocs";
            btnAdd.Text = "Add Locations";
            lblCountryName.Text = "Country: " + Session["CountryName"].ToString();
            if (Session["StatesId"] != null)
            {
                lblStateName.Text = Session["States"].ToString() + ": " + Session["StateName"].ToString();
            }
            else
            {
                DataGrid4.Columns[1].HeaderText = "Locations";
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveContractSuppliesLocs";
            cmd.Parameters.Add("@ContractSuppliesId", SqlDbType.Int);
            cmd.Parameters["@ContractSuppliesId"].Value = Int32.Parse(Session["Id"].ToString());
            if (Session["StatesId"] != null)
            {
                cmd.Parameters.Add("@StatesId", SqlDbType.Int);
                cmd.Parameters["@StatesId"].Value = Int32.Parse(Session["StatesId"].ToString());
            }
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
            cmd.Parameters["@CountriesId"].Value = Int32.Parse(Session["CountriesId"].ToString());
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ServiceLocs");
            if (ds.Tables["ServiceLocs"].Rows.Count == 0)
            {
                DataGrid4.Visible = false;
                lblContents2.Text = "You have not yet identified any locations where the above service is avaiable.  "
                    + " Click on the button titled 'Add Locations' to continue.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid4.DataSource = ds;
                DataGrid4.DataBind();
                DataGrid4.Columns[2].Visible = false;
                DataGrid4.Columns[3].Visible = false;
                DataGrid4.Visible = true;
                lblContents2.Text = "The list below shows the locations"
                + " where you have indicated the "
                + " above service as being available.";
               // refreshGrid4L();
            }
        }
       /* private void refreshGrid4L()
        {
            foreach (DataGridItem j in DataGrid4.Items)
            {
                CheckBox cb = (CheckBox)(j.Cells[2].FindControl("cbxSelStates"));
                Button bt = (Button)(j.Cells[3].FindControl("btnLocs"));
                if (j.Cells[5].Text == "1")
                {
                    cb.Checked = true;
                    bt.Text = "All Locations";
                    bt.Enabled = false;
                }
                else
                {
                    bt.Text = "Locations";
                    bt.Enabled = true;
                }
            }
        }*/

        /********** Part: All Locations *************************************************************/
        /********************************************************************************************/
        private void Locs()
        {
            Session["Part"] = "Locs";
            lblCountryName.Text = "Country: " + Session["CountryName"].ToString();
            
            if (Session["StatesId"] != null)
            {
                lblStateName.Text = Session["States"].ToString() + ": " + Session["StateName"].ToString();
            }
            
            btnAdd.Text = "Add Locations";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveLocs";
            cmd.Connection = this.epsDbConn;
            if (Session["StatesId"] != null)
            {
                cmd.Parameters.Add("@StatesId", SqlDbType.Int);
                cmd.Parameters["@StatesId"].Value = Int32.Parse(Session["StatesId"].ToString());
            }
            cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
            cmd.Parameters["@CountriesId"].Value = Int32.Parse(Session["CountriesId"].ToString());
            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Locs");
            if (ds.Tables["Locs"].Rows.Count == 0)
            {
                lblContents2.Text = "There are no locations"
                    + " identified.  Click on 'Add Locations' to continue.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid5.DataSource = ds;
                DataGrid5.DataBind();
                DataGrid5.Visible = true;
                refreshGrid5();
                lblContents2.Text = "Please select all locations where the above service is available";
            }
        }
        private void LocsAdd()
        {
            Session["Part"] = "LocsAdd";
            btnAdd.Visible = false;
            lblURL.Text = "Please Enter the location name below";
            lblURL.Visible = true;
            txtURL.Visible = true;
        }
        private void addLocation()
        {
                SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddLoc";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtURL.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=0;
                if (Session["StatesId"] != null)
                {
                    cmd.Parameters.Add("@StatesId", SqlDbType.Int);
                    cmd.Parameters["@StatesId"].Value = Int32.Parse(Session["StatesId"].ToString());
                }
                cmd.Parameters.Add("@CountriesId", SqlDbType.Int);
                cmd.Parameters["@CountriesId"].Value = Int32.Parse(Session["CountriesId"].ToString());

				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
        }
        /********************************************************************************************/
        /*********************************************  EXIT ****************************************/
        /********************************************************************************************/
       /* private static void TryToParse(string value)
        {
          int number;
          bool result = Int32.TryParse(value, out number);
          if (result)
          {
                 
          }
          else
          {
             //break;
          }
       }*/

        protected void btnExit_Click(object sender, System.EventArgs e)
        {
            if (Session["Part"].ToString() == "Procure")
            {
                foreach (DataGridItem i in GridProcure.Items)
                {
                    TextBox tQ = (TextBox)(i.Cells[4].FindControl("txtQty"));
                    TextBox tP = (TextBox)(i.Cells[6].FindControl("txtPrice"));
                    float Result;
                    if (float.TryParse(tQ.Text.Trim(), out Result) == false)
                    {
                        lblContents1.Text = "Please enter valid number in the Column titled 'Quantity'.";
                        break;
                    }
                    else if (float.TryParse(tP.Text.Trim(), out Result) == false)
                    {
                        lblContents1.Text = "Please enter valid number in the Column titled 'Price'.";
                        break;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "fms_UpdatePSEPResInv";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                        cmd.Parameters.Add("@Qty", SqlDbType.Float);
                        cmd.Parameters["@Qty"].Value = Int32.Parse(tQ.Text);
                        cmd.Parameters.Add("@Price", SqlDbType.Float);
                        cmd.Parameters["@Price"].Value = Int32.Parse(tP.Text);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                        }
                    }
                foreach (DataGridItem i in GridProcureS.Items)
                {
                    TextBox tC = (TextBox)(i.Cells[2].FindControl("txtCost"));
                    float Result;
                    if (float.TryParse(tC.Text.Trim(), out Result) == false)
                    {
                        lblContents1.Text = "Please enter valid number in the Column titled 'Cost'.";
                        break;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "fms_UpdatePSEPResInv";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                        cmd.Parameters.Add("@Price", SqlDbType.Float);
                        
                        cmd.Parameters["@Price"].Value = Int32.Parse(tC.Text);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                Exit();
                }   
            else if (Session["Part"].ToString() == "Deliver")
            {
                Session["Id"] = null;
                Session["CountriesId"] = null;
                Session["CountryName"] = null;
                Session["States"] = null;
                Session["StatesId"] = null;
                Session["StateName"] = null;
                Exit();
            }
            else if (Session["Part"].ToString() == "Details")
            {
                btnAdd.Visible = true;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "wms_UpdateContractSuppliesDesc";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(Session["Id"].ToString());
                cmd.Parameters.Add("@Desc", SqlDbType.NText);
                cmd.Parameters["@Desc"].Value = txtDesc.Text;
                cmd.Parameters.Add("@URL", SqlDbType.NVarChar);
                cmd.Parameters["@URL"].Value = txtURL.Text;
                if (rblLocs.SelectedValue == "Any")
                {
                    cmd.Parameters.Add("@LocsFlag", SqlDbType.Int);
                    cmd.Parameters["@LocsFlag"].Value = 1;
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                lblDesc.Visible = false;
                txtDesc.Visible = false;
                lblURL.Visible = false;
                txtURL.Visible = false;
                lblLocs.Visible = false;
                rblLocs.Visible = false;
                loadDeliver();
            }
            else if (Session["Part"].ToString() == "SCountries")
            {
                DataGrid2.Visible = false;
                lblContents2.Visible = false;
                updateCSCountries();
                loadDeliver();

            }
            else if (Session["Part"].ToString() == "Countries")
            {
                updateGrid3();
                DataGrid3.Visible = false;
                loadCSCountries();
            }
            else if (Session["Part"].ToString() == "SStates")
            {
                DataGrid4.Visible = false;
                lblCountryName.Text = "";
                updateCSStates();
                loadCSCountries();

            }
            else if (Session["Part"].ToString() == "States")
            {
                updateGrid5();
                Session["StatesId"]= null;
                Session["StateName"] = null;
                DataGrid5.Visible = false;
                loadCSStates();
            }
            else if (Session["Part"].ToString() == "SLocs")
            {
                DataGrid4.Columns[2].Visible = true;
                DataGrid4.Columns[3].Visible = true;
                if (Session["StatesId"] != null)
                {
                    loadCSStates();
                }
                else
                {
                    DataGrid4.Visible = false;
                    loadCSCountries();
                }
                

            }
            else if (Session["Part"].ToString() == "Locs")
            {
                updateGrid5();
                DataGrid5.Visible = false;
                loadCSLocs();
            }
            else if (Session["Part"].ToString() == "LocsAdd")
            {
                //updateLocs();
                lblURL.Visible = false;
                txtURL.Visible = false;
                btnAdd.Visible = false;
                addLocation();
                Locs();
            }
        }
        private void Exit()
        {
            Response.Redirect(strURL + Session["CCP"].ToString() + ".aspx?");
        }

        protected void GridDeliver_ItemCommand(object source, DataGridCommandEventArgs e)
         {
            if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                if (Session["MgrOption"].ToString() == "Procure")
                {
                    cmd.CommandText = "fms_DeleteContractProcure";
                }
                else if (Session["MgrOption"].ToString() == "Supply")
                {
                    cmd.CommandText = "fms_DeleteContractSupplies";
                }
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = e.Item.Cells[0].Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadDeliver();
            }
            else
            /********** Leaving Part Deliver****************************************************************/
            /********************************************************************************************/
            {
                GridDeliver.Visible = false;
                lblContents1.Visible = false;
                Session["Id"] = e.Item.Cells[0].Text;
                lblContractItem.Text = "Supply Item: " + e.Item.Cells[3].Text;

/********************************************************************************************/
/********** Part Service Details: Description, URL and Locations****************************************/
/********************************************************************************************/
                if (e.CommandName == "Details")
                {
                    Session["Part"] = "Details";

                    btnAdd.Visible = false;
                    lblContents1.Text = "Please provide further details for this item as indicated below.";
                    lblDesc.Visible = true;
                    txtDesc.Visible = true;
                    lblURL.Text = "If you have a website that describes"
                    + " this good or service and/or allows the user to order it online, "
                    + "please enter the complete website address below.";
                    lblURL.Visible = true;
                    txtURL.Visible = true;
                    lblLocs.Visible = true;
                    rblLocs.Visible = true;

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_RetreiveContractSupplies";
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = e.Item.Cells[0].Text;
                    cmd.Connection = this.epsDbConn;
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Details");
                    if (ds.Tables["Details"].Rows.Count == 1)
                    {
                        txtDesc.Text = ds.Tables["Details"].Rows[0][0].ToString();
                        if (ds.Tables["Details"].Rows[0][1].ToString() == "1")
                        {
                            rblLocs.SelectedIndex = GetIndexOfLocations("Any");
                        }
                        else
                        {
                            rblLocs.SelectedIndex = GetIndexOfLocations("Specified");
                        }
                    }
                }
/********************************************************************************************/
/********** Part: Contract Service Countries*************************************************************/
/********************************************************************************************/
                else if (e.CommandName == "CSCountries")
                {
                    loadCSCountries();
                }
            }
        }  
    }
}