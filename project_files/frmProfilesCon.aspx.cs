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
	public partial class frmProfilesCon: System.Web.UI.Page
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
                if (Session["CM"] != null)
                {
                    lblOrg.Text = "Household Characteristics for: " + Session["OrgName"].ToString();
                }
				lblFunction.Text="Please check all items that are true for you or your household";
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
			refreshGrid();
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            if (Session["CM"] != null)
            {
                prepareReport();
            }
            else
            {
                deleteGrid();
                updateGrid();
                Exit();
            }
		}
		private void deleteGrid()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteProfileOrg";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
			
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				if (cb.Checked)
				{	
					SqlCommand cmd1=new SqlCommand();
					cmd1.CommandType=CommandType.StoredProcedure;
					cmd1.CommandText="eps_UpdateProfileOrg";
					cmd1.Connection=this.epsDbConn;
					cmd1.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd1.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
					cmd1.Parameters.Add ("@ProfileId",SqlDbType.Int);
					cmd1.Parameters["@ProfileId"].Value=i.Cells[0].Text;
					cmd1.Connection.Open();
					cmd1.ExecuteNonQuery();
					cmd1.Connection.Close();
				}
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from ProfileOrg"
						+ " Where OrgId = " + Session["OrgId"].ToString()
						+ " and ProfileId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CSProfilesCon"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CSProfilesCon"].ToString() + ".aspx?");
		}
        private void rpts()
        {
            Session["cRG"] = "frmMainWP";
            Response.Redirect(strURL + "frmReportGen.aspx?");
        }
        private void prepareReport()
        {
            ParameterFields myParams = new ParameterFields();
            ParameterField myParam = new ParameterField();
            ParameterDiscreteValue myDiscreteValue = new ParameterDiscreteValue();
            myParam.ParameterFieldName = "ProfileId";
            //Reuse myDiscreteValue
            foreach (DataGridItem i in DataGrid1.Items)
            {
                CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
                if (cb.Checked)
                {
                    myDiscreteValue = new ParameterDiscreteValue();
                    myDiscreteValue.Value = i.Cells[0].Text;
                    myParam.CurrentValues.Add(myDiscreteValue);

                   /* SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.CommandText = "eps_UpdateProfileOrg";
                    cmd1.Connection = this.epsDbConn;
                    cmd1.Parameters.Add("@OrgId", SqlDbType.Int);
                    cmd1.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                    cmd1.Parameters.Add("@ProfileId", SqlDbType.Int);
                    cmd1.Parameters["@ProfileId"].Value = ;
                    cmd1.Connection.Open();
                    cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();*/
                }
            }
            // Add param object to params collection
            myParams.Add(myParam);

            // Assign the params collection to the report viewer
            Session["ReportParameters"] = myParams;
            Session["ReportName"] = "rptHouseholdPlan.rpt";
            rpts();
        }
	}

}

