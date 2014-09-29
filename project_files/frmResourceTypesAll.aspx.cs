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
	public partial class frmResourceTypesAll: System.Web.UI.Page
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
			if (!IsPostBack)
			{
                if ((Session["startForm"].ToString() == "frmMainBMgr") ||
                    (Session["startForm"].ToString() == "frmMainMgr"))
                {
                    if (Session["MgrOption"].ToString() == "Procure")
                    {
                        lblOrg.Text = Session["OrgName"].ToString();
                        lblContents1.Text = "Now that we are here lets be glad.";
                    }
                    else if (Session["MgrOption"] == "Budget")
          
                    {
                        lblProcessName.Text = "Budget: " + Session["BudName"].ToString();
                        lblOrg.Text = Session["BDOrgName"].ToString();
                        lblContents1.Text = "Click on all resource types are included among the list of outputs to be"
                            + " generated through use of funds provided from this budget to this organization.";
                    }
                }
                else
                {
                if (Session["CallerRTA"].ToString() == "frmPSEPO") //called from frmMainProfileMgr 
                    {
                        if (Session["Section"].ToString() == "I")
                        {
                            lblTitle1.Text = "Service Models";
                            lblProcessName.Text = "Process: " + Session["ProcessName"].ToString();
                            lblContents1.Text = "Click on all outputs that can possibly result from the above process."
                                + " Click on 'Add' to identify more outputs.";
                        }
                        else
                        {
                            lblTitle1.Text = "Business Models";
                            btnAddAll.Visible = false;
                            lblContents1.Text = "Click on all resource types that are needed to carry out the above process."
                                + " Note:  If you do not find the type of resource you need to carry out this process from the list below, please"
                            + " (a)  return to the home page, then (b) click on button titled 'Section I: Service Models' and from there proceed to add that type of resource to this service.  Finally, (c) return to this webpage and you will find that resource added to the list below.";
                        }
                    }
                else if (Session["CallerRTA"].ToString() == "frmPSEPRes")
                {
                    lblTitle1.Text = "Service Models";
                    if (Session["RType"].ToString() == "1")
                    {
                        lblProcessName.Text = "Process: " + Session["ProcessName"].ToString();
                        lblContents1.Text = "Click on all services that could be required for the above process."
                            + " Click on 'Add' to identify more services.";
                        DataGrid1.Columns[1].HeaderText = "Services";
                    }
                    else
                    {
                        lblProcessName.Text = "Process: " + Session["ProcessName"].ToString();
                        lblContents1.Text = "Click on all goods and other resources that could be required for the above process."
                            + " Click on 'Add' to identify more goods and other resources.";
                        DataGrid1.Columns[1].HeaderText = "Goods and Other Resources";
                    }
                } 
                }
				loadData();
			}
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                if ((Session["startForm"].ToString() == "frmMainBMgr") ||
                    (Session["startForm"].ToString() == "frmMainMgr"))
                {
                    cmd.CommandText = "wms_RetrieveResourceTypes";
                    cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                    cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                    cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                    cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                    cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                    cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                    cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                    cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
                }
                else
                {
                    if (Session["TableFlag"].ToString() == "1")
                    {
                        cmd.CommandText = "wms_RetrieveResourceTypes";
                        cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                        cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                        cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                        cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                        cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                        cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                        cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                        cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
                        if (Session["RType"] != null)
                        {
                            cmd.Parameters.Add("@RType", SqlDbType.Int);
                            cmd.Parameters["@RType"].Value = Session["RType"].ToString();
                        }

                    }
                    else
                    {
                        if (Session["CallerRTA"].ToString() == "frmPSEPO")
                        {
                            cmd.CommandText = "wms_RetrieveResourceTypesO";
                        }
                        else
                        {
                            /*cmd.CommandText = "wms_RetrieveResourceTypesI";
                             * above deactivated since option to change inputs from standard process not provided in ProfileSEProcs from where this
                             * option would be provided*/
                        }

                        cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                        cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                        cmd.Parameters.Add("@RType", SqlDbType.Int);
                        cmd.Parameters["@RType"].Value = Session["RType"].ToString();
                    }
                    if (Session["CallerRTA"].ToString() == "frmContractProcures")
                    {
                        cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                        cmd.Parameters["@HHFlag"].Value = 1;
                    }
                }
                cmd.Connection = this.epsDbConn;
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"ResTypes");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				Button btUpdate = (Button)(i.Cells[3].FindControl("btnUpdate"));
				Button btDelete = (Button)(i.Cells[3].FindControl("btnDelete"));

                
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;

                if (Session["CallerRTA"].ToString() == "frmPSEPO")
                {
                    if ((Session["startForm"].ToString() == "frmMainBMgr") ||
                    (Session["startForm"].ToString() == "frmMainMgr"))
                    {
                        cmd.CommandText = "Select Id from BudOrgsOutputs"
                                   + " Where ResTypesId = " + i.Cells[0].Text
                                   + " and BudOrgsId = " + Session["BDOId"].ToString();

                        cmd.Connection.Open();
                        if (cmd.ExecuteScalar() != null)
                        {
                            cb.Checked = true;
                            cb.Enabled = false;
                        }
                    }
                    else if (Session["TableFlag"].ToString() == "1")
                    {
                            cmd.CommandText = "Select Id from ProcResOutputs"
                                   + " Where ResTypesId = " + i.Cells[0].Text
                                   + " and ProcsId = " + Session["ProcsId"].ToString();

                            cmd.Connection.Open();
                            if (cmd.ExecuteScalar() != null)
                            {
                                cb.Checked = true;
                                cb.Enabled = false;
                            }
                    }
                    else
                    {
                        cmd.CommandText = "Select Id from PSEPResOutputs"
                               + " Where ResourceTypesId = " + i.Cells[0].Text
                               + " and PSEPId = " + Session["PSEPId"].ToString();

                        cmd.Connection.Open();
                        if (cmd.ExecuteScalar() != null)
                        {
                            cb.Checked = true;
                            cb.Enabled = false;
                        }
                    }
                }
               
                else if (Session["TableFlag"].ToString() == "1")
                {

                    if (Session["CallerRTA"].ToString() == "frmPSEResources")
                    {
                       /* cmd.CommandText = "Select Id from PSEResources"
                               + " Where ResourceTypesId = " + i.Cells[0].Text
                               + " and ProfileServiceEventsId = " + Session["PSEId"].ToString();

                        
                        if (cmd.ExecuteScalar() != null)
                        {
                            cb.Checked = true;
                            cb.Enabled = false;
                        }*/
                        cmd.Connection.Open();
                    }
                    else if (Session["CallerRTA"].ToString() == "frmContractProcures")
                    {
                        cmd.Connection.Open();
                    }
                    else
                    {
                        cmd.CommandText = "Select Id from PSEPRes"
                                + " Where ResTypesId = " + i.Cells[0].Text
                                + " and ProcsId = " + Session["ProcsId"].ToString();

                        cmd.Connection.Open();
                        if (cmd.ExecuteScalar() != null)
                        {
                            cb.Checked = true;
                            cb.Enabled = false;
                        }
                    }
                }
                else
                {
                    /*cmd.CommandText = "Select Id from PSEPRes"
                            + " Where ResTypesId = " + i.Cells[0].Text
                            + " and PSEPID = " + Session["PSEPID"].ToString();

                    cmd.Connection.Open();
                    if (cmd.ExecuteScalar() != null)
                    {
                        cb.Checked = true;
                        cb.Enabled = false;
                    }
                     * Above deactivated for same reason as indicated above*/
                }

                /*cmd.CommandText = "Select Id from PSEPResOutputs"
                        + " Where ResTypesId = " + i.Cells[0].Text;

                if (cmd.ExecuteScalar() != null)
                {
                    btDelete.Enabled = false;
                    btDelete.Text = "In Use";
                }
                else
                {

                    cmd.CommandText = "Select Id from PSEPRes"
                        + " Where ResTypesId = " + i.Cells[0].Text;

                    if (cmd.ExecuteScalar() != null)
                    {
                        btDelete.Enabled = false;
                        btDelete.Text = "In Use";
                    }
                }*/
                    cmd.CommandText = "Select OrgId from ResourceTypes"
                        + " Where Id = " + i.Cells[0].Text;
                    if (cmd.ExecuteScalar().ToString() != Session["OrgId"].ToString())
                    {
                        btUpdate.Visible = false;
                        btDelete.Visible = false;
                        i.Cells[3].Text = "Externally Maintained";
                    }
				cmd.Connection.Close();

			}
		}


		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
            Exit();		
		}
		private void updateGrid()
		{
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                if (Session["CallerRTA"].ToString() == "frmPSEPO")
                {
                    if (cb.Checked)
                    {
                        if (cb.Enabled)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = this.epsDbConn;
                            if ((Session["startForm"].ToString() == "frmMainBMgr") ||
                    (Session["startForm"].ToString() == "frmMainMgr"))
                            {
                                cmd.CommandText = "wms_addBOOutputs";
                                cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
                                cmd.Parameters["@BudOrgsId"].Value = Session["BDOId"].ToString();
                            }
                            else
                            {
                                if (Session["TableFlag"].ToString() == "1")
                                {
                                    cmd.CommandText = "wms_UpdateProcResOutputs";
                                    cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                                    cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                                }
                                else
                                {
                                    cmd.CommandText = "wms_UpdatePSEPResOutputs";
                                    cmd.Parameters.Add("@PSEPId", SqlDbType.Int);
                                    cmd.Parameters["@PSEPId"].Value = Session["PSEPId"].ToString();
                                }
                            }
                            cmd.Parameters.Add("@ResTypesId", SqlDbType.Int);
                            cmd.Parameters["@ResTypesId"].Value = i.Cells[0].Text;
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                    }

                }

                else if (Session["CallerRTA"].ToString() == "frmPSEResources")
                {
                    if (cb.Checked)
                    {
                        //if (cb.Enabled)
                        //{
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = this.epsDbConn;
                            cmd.CommandText = "wms_UpdatePSEResources";
                            cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
                            cmd.Parameters["@ProfilesId"].Value = Session["ProfilesId"].ToString();
                            cmd.Parameters.Add("@EventsId", SqlDbType.Int);
                            cmd.Parameters["@EventsId"].Value = Session["EventsId"].ToString();
                            cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                            cmd.Parameters["@ServiceTypesId"].Value = Session["ServicesId"].ToString();
                            cmd.Parameters.Add("@ResourceTypesId", SqlDbType.Int);
                            cmd.Parameters["@ResourceTypesId"].Value = i.Cells[0].Text;
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                       // }
                    }
                }
                else if (Session["CallerRTA"].ToString() == "frmContractProcures")
                {

                    if (cb.Checked)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = this.epsDbConn;
                        cmd.CommandText = "wms_UpdateContractSupplies";
                        cmd.Parameters.Add("@ContractsId", SqlDbType.Int);
                        cmd.Parameters["@ContractsId"].Value = Session["ContractId"].ToString();
                        cmd.Parameters.Add("@ResourceTypesId", SqlDbType.Int);
                        cmd.Parameters["@ResourceTypesId"].Value = i.Cells[0].Text;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                else
                {
                     if (cb.Checked)
                    {
                        if (cb.Enabled)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = this.epsDbConn;
                            cmd.CommandText = "wms_UpdatePSEPRes";
                            cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                            cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                            cmd.Parameters.Add("@ResTypesId", SqlDbType.Int);
                            cmd.Parameters["@ResTypesId"].Value = i.Cells[0].Text;
                            cmd.Connection.Open();
                            cmd.ExecuteNonQuery();
                            cmd.Connection.Close();
                        }
                    }
                }
            }
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerRTA"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		protected void btnAddAll_Click(object sender, System.EventArgs e)
		{
			Session["CUpdResType"]="frmResourceTypesAll";	
			Response.Redirect (strURL + "frmUpdResourceType.aspx?"
				+ "&btnAction=" + "Add");
			
		
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{					
				Session["CUpdResType"]="frmResourceTypesAll";
				Response.Redirect (strURL + "frmUpdResourceType.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&ParentId=" + e.Item.Cells[5].Text
					+ "&Visibility=" + e.Item.Cells[4].Text
					+ "&Qty=" + e.Item.Cells[6].Text);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteResourceTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
	}

}

