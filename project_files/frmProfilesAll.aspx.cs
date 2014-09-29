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
	public partial class frmProfilesAll: System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadProfiles();
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
		private void loadProfiles()
		{			
			if (!IsPostBack)
			{	
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProfilesAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Type",SqlDbType.NVarChar);
			cmd.Parameters["@Type"].Value=Session["Type"].ToString();
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
			da.Fill(ds,"ProfilesAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			//refreshGrid();
		}
        private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                if (Session["startForm"].ToString() == "frmMainEPS")
                    cmd.CommandText = "Select ProfileId from Organizations"
                            + " Where Id = " + Session["OrgId"].ToString()
                            + " and ProfileId = " + i.Cells[0].Text;
                cmd.Connection.Open();
                if (cmd.ExecuteScalar() != null) cb.Checked = true;
                cmd.Connection.Close();
            }
        }
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            if (Session["CSProfilesAll"].ToString() == "frmPSEPClient")
                if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                {
                    {
                        updateGridPSEP();
                    }
                }
                else if (Session["CPSEPC"].ToString() == "frmProcs")
                {
                    updateGridProc();
                }
            Exit();
		}
		/*private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd2=new SqlCommand();
					cmd2.CommandType=CommandType.StoredProcedure;
					cmd2.CommandText="wps_UpdateOrgProfile";
					cmd2.Connection=this.epsDbConn;
					cmd2.Parameters.Add("@OrgId", SqlDbType.Int);
					cmd2.Parameters ["@OrgId"].Value=Session["OrgId"].ToString();
					cmd2.Parameters.Add("@ProfileId", SqlDbType.Int);
					cmd2.Parameters ["@ProfileId"].Value=i.Cells[0].Text;
					cmd2.Connection.Open();
					cmd2.ExecuteNonQuery();
					cmd2.Connection.Close();
				}
			}
			Exit();
		}*/
        private void updateGridProc()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
                if ((cb.Checked) & (cb.Enabled))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_AddProcClient";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
                    cmd.Parameters["@ProfilesId"].Value = i.Cells[0].Text;
                    cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                    cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
        private void updateGridPSEP()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
                if ((cb.Checked) & (cb.Enabled))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_AddPSEPClient";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
                    cmd.Parameters["@ProfilesId"].Value = i.Cells[0].Text;
                    cmd.Parameters.Add("@PSEPID", SqlDbType.Int);
                    cmd.Parameters["@PSEPID"].Value = Session["PSEPID"].ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
		private void Exit()
		{
			Response.Redirect (strURL + Session["CSProfilesAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CSProfilesAll"].ToString() + ".aspx?");
		}
	}

}

