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
	public partial class frmRolesAll: System.Web.UI.Page
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
                lblContent1.Text = "Please select from the list of roles defined below, or add new roles new roles if necessary.";
                if (Session["CallerRolesAll"].ToString() == "frmMainTrg")
                {
                    DataGrid1.Columns[2].Visible = false;
                }
                else if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    DataGrid1.Columns[4].Visible = false;
                }

               loadData();
            }
        }
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
            /*if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["Section"].ToString() == "I")
                {
                    cmd.CommandText = "wms_RetrievePCRolesAll";
                    cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                    cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                }
            }
            else
            {*/
                cmd.CommandText = "hrs_RetrieveRolesAll";
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            //}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Roles");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
            if (ds.Tables["Roles"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;

                if (Session["CallerRolesAll"].ToString() != "frmMainTrg")
                {
                    refreshGrid();
                }
            }
			
		}
        private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
                Button btUpdate = (Button)(i.Cells[3].FindControl("btnUpdate"));
                Button btSkills = (Button)(i.Cells[3].FindControl("btnSkills"));
                Button btDelete = (Button)(i.Cells[4].FindControl("btnDelete"));

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    btSkills.Visible = false;

                }

                if (Session["CallerRolesAll"].ToString() == "frmPSEPStaff")
                {
                    cmd.CommandText = "Select Id from PSEPStaff"
                        + " Where RolesId = " + i.Cells[0].Text
                        + " and ProcsId = " + Session["ProcsId"].ToString();
                }

                /*else if (Session["CallerRolesAll"].ToString() == "frmPSEPClient")
                {
                    if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                    {
                        cmd.CommandText = "Select Id from PSEPClients"
                            + " Where RolesId = " + i.Cells[0].Text
                            + " and PSEPID = " + Session["PSEPID"].ToString();
                    }
                    else
                    {
                        cmd.CommandText = "Select Id from ProcClients"
                        + " Where RolesId = " + i.Cells[0].Text
                        + " and ProcsId = " + Session["ProcsId"].ToString();
                    }
                    btSkills.Visible = false;
                }*/
                cmd.Connection.Open();
                if (cmd.ExecuteScalar() != null)
                {
                    cb.Checked = true;
                    cb.Enabled = false;
                }

                cmd.CommandText = "Select OrgId from Roles"
                    + " Where Id = " + i.Cells[0].Text;
                if (cmd.ExecuteScalar().ToString() != Session["OrgId"].ToString())
                {
                    btUpdate.Visible = false;
                    btSkills.Visible = false;
                    btDelete.Visible = false;
                    i.Cells[4].Text = "Externally Maintained";
                }
                else
                {
                    cmd.CommandText = "Select Id from PSEPClients"
                        + " Where RolesId = " + i.Cells[0].Text;
                    if (cmd.ExecuteScalar() != null)
                    {

                        btDelete.Visible = false;
                        i.Cells[4].Text = "In Use";
                    }
                    else
                    {
                        cmd.CommandText = "Select Id from PSEPStaff"
                            + " Where RolesId = " + i.Cells[0].Text;
                        if (cmd.ExecuteScalar() != null)
                        {
                            btDelete.Visible = false;
                            i.Cells[4].Text = "In Use";
                        }
                        else
                        {
                            cmd.CommandText = "Select Id from ProcStaff"
                                + " Where RolesId = " + i.Cells[0].Text;
                            if (cmd.ExecuteScalar() != null)
                            {
                                btDelete.Visible = false;
                                i.Cells[4].Text = "In Use";
                            }
                        }
                    }
                    cmd.Connection.Close();
                }
            }
        }

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
				
			/*if (Session["CallerRolesAll"].ToString() == "frmStepRoles")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteStepRoles";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@StepId",SqlDbType.Int);
				cmd.Parameters["@StepId"].Value=Request.Params["StepId"];
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				updateGrid();
				Exit();
			}
			else if (Session["CallerRolesAll"].ToString() == "frmPeopleRoles")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeletePeopleRoles";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value=Request.Params["PeopleId"];
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				updateGrid();
				Exit();

			}
			else if (Session["CallerRolesAll"].ToString() == "frmRoleRelations")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteRoleSkills";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
				cmd.Parameters["@RoleId"].Value=Session["RoleId"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				updateGrid();
				Exit();

			}*/

			updateGrid();
			Exit();

			//}
				
		}
		private void updateGrid()
		{
			if ((Session["CallerRolesAll"].ToString() == "frmPSEPStaff"))
			{
				updateGrid1();
			}
		}
		private void updateGrid1()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
				if ((cb.Checked) & (cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_AddPSEPStaff";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@RolesId", SqlDbType.Int);
					cmd.Parameters ["@RolesId"].Value=i.Cells[0].Text;
					cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
					cmd.Parameters ["@ProcsId"].Value=Session["ProcsId"].ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerRolesAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerRolesAll"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CallerUpdRole"]="frmRolesAll";
			Response.Redirect (strURL + "frmUpdRole.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["Type"]="Role";
				Session["CallerUpdRole"]="frmRolesAll";
				Response.Redirect (strURL + "frmUpdRole.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Visibility=" + e.Item.Cells[5].Text	
					+ "&ParentId=" + e.Item.Cells[6].Text
					+ "&Seq=" + e.Item.Cells[7].Text);
			}
			else if (e.CommandName == "Skills")
			{

				Session["CallerRoleSkills"] = "frmRolesAll";
				Session["RoleId"] = e.Item.Cells[0].Text;
				Session["RoleName"] =  e.Item.Cells[1].Text; 
				Response.Redirect (strURL + "frmRoleSkills.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
			
				/*SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_DeleteRole";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);			
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				updateGrid();
				loadData();*/
			}
		}
	}

}

