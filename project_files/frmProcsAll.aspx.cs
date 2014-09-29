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
	public partial class frmProcsAll: System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            if (Session["UserLevel"].ToString() == "0")
            {
                btnAddProcs.Visible = false;
            }
            lblProfilesName.Text = "Business Profile for: " + Session["ProfilesName"].ToString();
            lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
            lblDeliverableName.Text = "Deliverable: " + Session["EventsName"].ToString();
			loadProcs();
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
		private void loadProcs()
		{			
			if (!IsPostBack)
			{	
				//lblOrg.Text=Session["OrgName"].ToString();
				lblContent.Text="The processes below are normally associated with the above service."
                + " Check all processes that are normally associated with generating the above deliverable."
                + " Note that"
                + " it is possible that processes that are normally associated with generating other kinds of services"
                + " may also be involved in generating the above deliverable.  To review and appropriately include"
                + " such processes, click on 'More Processes...'.  Finally, if you are unable to locate an"
                + " existing process description to match your requirements, you may identify and describe a new process.  To create a new process, click on"
                + " 'Add Process'";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrieveProcs";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
            cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
            cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
            cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
            cmd.Parameters.Add("@DomainId", SqlDbType.Int);
            cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
            //cmd.Parameters["@ServiceTypesId"].Value=lstService.SelectedItem.Value;
            cmd.Parameters["@ServiceTypesId"].Value = Session["ServicesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcsAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			//refreshGrid();
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            if (Session["CProcsAll"].ToString() == "frmProfileSEProcs")
            {
                updateGridPSEP();
            }
            else
            {
                updateGrid();
            }
			Exit();
		}
        private void updateGridPSEP()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
                if ((cb.Checked) == true)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_AddProfileSEProcs";//eps_UpdateProfileSEProcs
                    cmd.Connection = this.epsDbConn;
                    if (Session["ProfileType"].ToString() == "Producer")
                    {
                        cmd.Parameters.Add("@ProfileSEventsId", SqlDbType.Int);
                        cmd.Parameters["@ProfileSEventsId"].Value = Session["ProfileSEventsId"].ToString();
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                        cmd.Parameters["@Name"].Value = i.Cells[1].Text;
                        /*cmd.Parameters.Add ("@ProcType",SqlDbType.NVarChar);
                        cmd.Parameters["@ProcType"].Value=Session["ProcType"].ToString();*/
                    }
                    else
                    {
                        cmd.Parameters.Add("@ProfileServiceLocsId", SqlDbType.Int);
                        cmd.Parameters["@ProfileServiceLocsId"].Value = Session["ProfileServiceLocsId"].ToString();
                    }
                    cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                    cmd.Parameters["@ProcsId"].Value = i.Cells[0].Text;
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
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					if ((cb.Checked) & (cb.Enabled == true))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateProfileSP";//eps_UpdateServiceProcs
						cmd.Connection=this.epsDbConn;
						if (Session["ProfileType"].ToString() == "Producer")
						{
							cmd.Parameters.Add ("@ProfileServicesId",SqlDbType.Int);
							cmd.Parameters["@ProfileServicesId"].Value=Session["ProfileServicesId"].ToString();
							/*cmd.Parameters.Add ("@ProcType",SqlDbType.NVarChar);
							cmd.Parameters["@ProcType"].Value=Session["ProcType"].ToString();*/
						}
						else
						{
							cmd.Parameters.Add ("@ProfileServiceLocsId",SqlDbType.Int);
							cmd.Parameters["@ProfileServiceLocsId"].Value=Session["ProfileServiceLocsId"].ToString();
						}

						cmd.Parameters.Add("@ProcessId", SqlDbType.Int);
						cmd.Parameters ["@ProcessId"].Value=i.Cells[0].Text;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		private void refreshGrid()
		{
			
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					if (Session["ProfileType"].ToString() == "Producer")
					{
						cmd.CommandText="Select Id from ProfileServiceProcs"
							+ " Where ProfileServicesId=" 
							+ "'" + Session["ProfileServicesId"].ToString() + "'"
							+ " and ProcessId = " 
							+ "'" + i.Cells[0].Text + "'"
							+ " and ProfileServiceProcs.Type=" 
							+ "'" + Session["ProcType"].ToString() + "'";
					}
					else
					{
						cmd.CommandText="Select Id from ProfileServiceProcs"
							+ " Where ProfileServiceLocsId=" 
							+ "'" + Session["ProfileServiceLocsId"].ToString() + "'"
							+ " and ProcessId = " 
							+ "'" + i.Cells[0].Text + "'";
					}

					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked=true;
						cb.Enabled=false;
					}
					cmd.Connection.Close();
				}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CProcsAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		protected void btnAddProcs_Click(object sender, System.EventArgs e)
		{
			 Session["CServiceTypes"] = "frmProfileSEProcs";
            Response.Redirect(strURL + "frmServiceTypes.aspx?");
		}
        protected void btnMoreProcs_Click(object sender, System.EventArgs e)
        {
            Session["btnAction"] = "Add";
            Session["CUPSEP"] = "frmProfileSEProcs";
            Response.Redirect(strURL + "frmUpdProfileSEProcs.aspx?"
                + "&btnAction=" + "Add");
        }
	}

}

