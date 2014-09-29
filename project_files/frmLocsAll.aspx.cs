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
	public partial class frmLocsAll: System.Web.UI.Page
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
                if (Session["CLocsAll"].ToString() != "frmLicenseOrgs")
                {
                    lblOrg.Text = Session["OrgName"].ToString();
                }
                else
                {
                    lblOrg.Text = Session["OrgNameC"].ToString();
                }
				
				lblContents.Text="Check All Locations for which"
						+ " a Continuity of Operations Plan will be developed";
				loadData();
			}
		}	
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveLocsAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			if (Session["CLocsAll"].ToString() != "frmLicenseOrgs")
			{
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
				cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
				cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			}
			else
			{
				cmd.Parameters["@OrgId"].Value=Session["OrgIdC"].ToString();
				cmd.Parameters["@LicenseId"].Value=Session["LicenseIdC"].ToString();
				cmd.Parameters["@OrgIdP"].Value=Session["OrgIdPC"].ToString();
				cmd.Parameters["@DomainId"].Value=Session["DomainIdC"].ToString();
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"LocsAll");
			if (ds.Tables["LocsAll"].Rows.Count == 0)
			{
				redirect();
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();			
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
				if ((cb.Checked) & (cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.Connection=this.epsDbConn;
					cmd.CommandText="wms_UpdateOrgLocations";
					cmd.Parameters.Add("@OrgId", SqlDbType.Int);
					if (Session["CLocsAll"].ToString() != "frmLicenseOrgs")
					{
						cmd.Parameters ["@OrgId"].Value=Session["OrgId"].ToString();
					}
					else
					{
						cmd.Parameters ["@OrgId"].Value=Session["OrgIdC"].ToString();
					}
					
					cmd.Parameters.Add("@LocId", SqlDbType.Int);
					cmd.Parameters ["@LocId"].Value=i.Cells[0].Text;
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
					CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
					Button bnDelete = (Button)(i.Cells[4].FindControl("btnDelete"));
					Button bnUpdate = (Button)(i.Cells[4].FindControl("btnUpdate"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
                    cmd.Connection.Open();
					if (Session["CLocsAll"].ToString() != "frmLicenseOrgs")
					{
						cmd.CommandText="Select Id from Locations"
							+  " Where Id = " + i.Cells[0].Text
							+ " and OrgId != " + Session["OrgIdC"].ToString();
					    if (cmd.ExecuteScalar() != null) 
						bnDelete.Visible=false;
						bnUpdate.Visible=false;
						i.Cells[4].Text="External Location";
					}
					if (Session["CLocsAll"].ToString() != "frmLicenseOrgs")
					{
						cmd.CommandText="Select Id from OrgLocations"
							+ " Where OrgId = " + Session["OrgId"].ToString()
							+ " and LocId = " + i.Cells[0].Text;
					}
					else
					{
						cmd.CommandText="Select Id from OrgLocations"
							+ " Where OrgId = " + Session["OrgIdC"].ToString()
							+ " and LocId = " + i.Cells[0].Text;
					}
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked = true;
						cb.Enabled=false;
					}
					/*cmd.CommandText="Select Id from OrgLocations"
							+ " Where LocId = " + i.Cells[0].Text;
					if (cmd.ExecuteScalar() != null) 
					{
						bnDelete.Visible=false;
					}*/
					cmd.Connection.Close();
				}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CLocsAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CLocsAll"].ToString() + ".aspx?");
		}
		private void redirect()
		{			
			Session["CUpdLocs"]="frmLocsAll";
			Response.Redirect (strURL + "frmUpdLoc.aspx?"
				+ "&btnAction=" + "Add");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			redirect();		
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteLocId";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Update")
			{
				Session["CUpdLocs"]="frmLocsAll";
				Response.Redirect (strURL + "frmUpdLoc.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[5].Text);
				
			}
            else if (e.CommandName == "Remove")
            {
                SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteOrgLocId";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=Int32.Parse (e.Item.Cells[0].Text);
                cmd.Parameters.Add ("@OrgId", SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Int32.Parse (Session["OrgIdC"].ToString());
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
            }
		}
	}

}

