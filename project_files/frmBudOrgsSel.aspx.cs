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
	/// Summary description for frmOrgs.
	/// </summary>
	public partial class frmBudOrgsSel : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
        int I = 2;
        int J = 0;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Orgs();
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
		private void Load_Orgs()
		{	
			if (!IsPostBack) 
			{
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents1.Text="Budget: " + Session["BudName"].ToString();
				lblContents.Text="Select Organizations to which you wish"
					+ " to distribute this budget";
				loadData();
				refreshGrid();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveOrganizations";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			if (I == 2)
			{
				cmd.Parameters.Add ("@Type",SqlDbType.Int);
				cmd.Parameters["@Type"].Value=1;
			}
			cmd.Connection=this.epsDbConn;	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Orgs");
            if (ds.Tables["Orgs"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                btnCancel.Visible = false;
                J = 1;
                if (I == 2)
                {
                    lblContents1.Text = "There are no External Organizations"
                        + " identified for your license.";
                }
                else
                {
                    lblContents1.Text = "There are no Internal Units"
                        + " identified for your license.";
                }
            }
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_RetrieveBudOrgsSel";
					cmd.Parameters.Add ("@BudgetsId",SqlDbType.Int);
					cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked=true;
						cb.Enabled=false;
					}
					cmd.Connection.Close();
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
					cmd.CommandText="fms_UpdateBudOrgs";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@BudgetsId",SqlDbType.Int);
					cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();
					cmd.Parameters.Add("@OrgId", SqlDbType.Int);
					cmd.Parameters ["@OrgId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            if (J == 0)
            {
                updateGrid();
            }
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CBOSel"].ToString() + ".aspx?");
		}

		protected void btnOrgTypes_Click(object sender, System.EventArgs e)
		{
			if (btnOrgTypes.Text == "Show External Organizations")
			{
				I = 1;
				btnOrgTypes.Text = "Show Internal Units";
				loadData();
			}
			else
			{
				I = 2;
				btnOrgTypes.Text = "Show External Organizations";
				loadData();
			}
		}
	}
}
