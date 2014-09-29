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
	public partial class frmEventsAll: System.Web.UI.Page
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
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                DataGrid1.Columns[4].Visible = false;
                if (Session["Section"].ToString() == "I")
                {
                    lblTitle.Text = "EcoSys: Service Models";
                    lblProfilesName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                    lblContents.Text = "Listed below are various deliverables that form"
                        + " part of the service indicated above.";
                }
                else
                {

                    
                    if (Session["ProfileType"] == "Consumer")
                    {
                        lblTitle.Text = "Individual/Household Characteristics";
                        lblProfilesName.Text = "Type of Characteristic: " + Session["ProfilesName"].ToString();
                        lblServiceName.Text = "Stage: " + Session["ServiceName"].ToString();
                        DataGrid1.Columns[1].HeaderText = "Events";
                        DataGrid1.Columns[3].Visible = false;
                        DataGrid1.Columns[4].Visible = true;
                        lblContents.Text = "To continue, click on 'Select' for the appropriate Event below."; ;
                    }
                    else if (Session["ProfileType"] == "Producer")
                    {
                        lblTitle.Text = "Business Models";
                        btnAdd.Text = "Identify New Deliverable";
                        lblProfilesName.Visible = false;
                        lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                        lblContents.Text = "Listed below is the full set of deliverables for all kinds of services."
                            + " Select any deliverables that relate to the service above."
                            + " Use the 'Add Deliverables' button to add to the list as needed.  If there is"
                            + " some other deliverable not included in the list below that you wish to add for this service,"
                        + " click on 'Identify New Deliverable'";
                    }
                }
            }

            loadEvents();
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
		private void loadEvents()
		{			
			if (!IsPostBack)
			{
				loadContents1();
				loadData();
			}
		}
		private void loadContents1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveMain";
			cmd.Parameters.Add("@OrgId",SqlDbType.NVarChar);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Dom");
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveEventsAll";
			cmd.Connection=this.epsDbConn;
            if (Session["ProfileType"] != null)
            {
                if (Session["ProfileType"].ToString() == "Consumer")
                {
                    cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                    cmd.Parameters["@HHFlag"].Value = "1";
                }
            }
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
			da.Fill(ds,"EventsAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
            if (Session["CEventsAll"].ToString() == "frmServiceTypes")
            {
                if (Session["ProfileType"].ToString() == "Consumer")
                {
                    refreshGrid1();
                }
            }
            else
            {

                refreshGrid();
            }
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            if (Session["CEventsAll"].ToString() != "frmServiceTypes")
            {
                updateGrid();
            }
			Exit();
		}
		private void updateGrid()
		{
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                if ((cb.Checked) & (cb.Enabled))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Session["CEventsAll"].ToString() == "frmPSEPClientImpact")
                    {
                        if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                        {
                            cmd.CommandText = "wms_UpdatePSEPClientEvents";
                            cmd.Parameters.Add("@PSEPClientsId", SqlDbType.Int);
                            cmd.Parameters["@PSEPClientsId"].Value = Session["PSEPClientsId"].ToString();
                            cmd.Parameters.Add("@EventsId", SqlDbType.Int);
                            cmd.Parameters["@EventsId"].Value = i.Cells[0].Text;

                        }
                        else if (Session["CPSEPC"].ToString() == "frmProcs")
                        {
                            cmd.CommandText = "wms_UpdateProcClientEvents";
                            cmd.Parameters.Add("@ProcClientsId", SqlDbType.Int);
                            cmd.Parameters["@ProcClientsId"].Value = Session["ProcClientsId"].ToString();
                            cmd.Parameters.Add("@EventsId", SqlDbType.Int);
                            cmd.Parameters["@EventsId"].Value = i.Cells[0].Text;
                        }
                    }

                    else
                    {
                        cmd.CommandText = "wms_UpdateServiceEvents";
                        
                        cmd.Parameters.Add("@ServicesId", SqlDbType.Int);
                        cmd.Parameters["@ServicesId"].Value = Session["ServicesId"].ToString();
                        cmd.Parameters.Add("@EventsId", SqlDbType.Int);
                        cmd.Parameters["@EventsId"].Value = i.Cells[0].Text;
                    }
                    cmd.Connection = this.epsDbConn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
			/*}
			else
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
					if (cb.Checked)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateTaskStepsEvents";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@TaskId", SqlDbType.Int);
						cmd.Parameters ["@TaskId"].Value=Session["TaskId"].ToString();
						cmd.Parameters.Add("@EventId", SqlDbType.Int);
						cmd.Parameters ["@EventId"].Value=i.Cells[0].Text;
						cmd.Parameters.Add("@Caller", SqlDbType.NVarChar);
						cmd.Parameters ["@Caller"].Value="frmTaskSteps";
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}*/
		}
        private void refreshGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                Button btUpdate = (Button)(i.Cells[4].FindControl("btnUpdate"));
                Button btDelete = (Button)(i.Cells[4].FindControl("btnDelete"));
                btDelete.Text = "Other";
                btDelete.BackColor = Color.Teal;
                btUpdate.Text = "Services";
                btUpdate.CommandName = "SelectS";
                btDelete.CommandName = "SelectO";
            }
        }
        private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                Button btDelete = (Button)(i.Cells[4].FindControl("btnDelete"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                if (Session["CEventsAll"].ToString() == "frmPSEPClientImpact")
                {
                    if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                    {
                        cmd.CommandText = "Select Id from PSEPClientEvents"
                        + " Where PSEPClientsId = " + Session["PSEPClientsId"].ToString()
                        + " and EventsId = " + i.Cells[0].Text;
                    }
                    else if (Session["CPSEPC"].ToString() == "frmProcs")
                    {
                        cmd.CommandText = "Select Id from ProcClientEvents"
                        + " Where ProcClientsId = " + Session["ProcClientsId"].ToString()
                        + " and EventsId = " + i.Cells[0].Text;
                    }
                }
                else
                {
                    cmd.CommandText = "Select Id from ServiceEvents"
                        + " Where ServicesId = " + Session["ServicesId"].ToString()
                        + " and EventsId = " + i.Cells[0].Text;
                }
                    cmd.Connection.Open();
                    if (cmd.ExecuteScalar() != null)
                    {
                        cb.Checked = true;
                        cb.Enabled = false;
                    }
                    cmd.CommandText = "Select Id from ServiceEvents"
                        + " Where EventsId = " + i.Cells[0].Text;
                    if (cmd.ExecuteScalar() != null)
                    {
                        btDelete.Enabled = false;
                        btDelete.Text = "In Use";
                    }
                    cmd.CommandText = "Select Events.OrgId from Events"
                        + " Where Id = " + i.Cells[0].Text;
                    if (cmd.ExecuteScalar().ToString() != Session["OrgId"].ToString())
                    {
                        btDelete.Visible = false;
                        i.Cells[4].Text = "Externally Created";
                    }
                    cmd.Connection.Close();
                }
            }
		private void Exit()
		{
			Response.Redirect (strURL + Session["CEventsAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CEventsAll"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdEvent"]="frmEventsAll";
			Response.Redirect (strURL + "frmUpdEvent.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdEvent"]="frmEventsAll";
				Response.Redirect (strURL + "frmUpdEvent.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[5].Text
                    + "&HHFlag=" + e.Item.Cells[6].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteEvent";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
            else if (e.CommandName == "SelectS")
            {
                Session["EventsId"] = e.Item.Cells[0].Text;
                Session["EventsName"] = e.Item.Cells[1].Text;
                Session["RType"] = "0";
                Session["CPSEResources"] = "frmEventsAll";
                Response.Redirect(strURL + "frmPSEResources.aspx?");
            }
            else if (e.CommandName == "SelectO")
            {
                Session["EventsId"] = e.Item.Cells[0].Text;
                Session["EventsName"] = e.Item.Cells[1].Text;
                Session["RType"] = "1";
                Session["CPSEResources"] = "frmEventsAll";
                Response.Redirect(strURL + "frmPSEResources.aspx?");
            }
		}
	}

}

