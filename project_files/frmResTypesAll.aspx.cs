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
	public partial class frmResTypesAll: System.Web.UI.Page
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

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				if (Session["CallerServicesAll"].ToString() == "frmProfileServices")
				{
					lblContent1.Text="Select Services for profile "
						+ Session["ProfileName"].ToString()
						+ ". You may identify services not included in this list by clicking"
						+ " on the 'Add Services' button.";
				}				
				loadData();
			}
				
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveResourceTypes";
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
			da.Fill(ds,"Courses");
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
			if (Session["CallerServicesAll"].ToString() == "frmProfileServices")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
					if ((cb.Checked == true) & (cb.Enabled==true))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateProfileServiceTypes";//"eps_UpdateSkillCourses";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@ResTypeId", SqlDbType.Int);
						cmd.Parameters ["@ResTypeId"].Value=i.Cells[0].Text;
						cmd.Parameters.Add("@ProfileId", SqlDbType.Int);
						cmd.Parameters ["@ProfileId"].Value=Session["ProfileId"].ToString();
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}
			else if (Session["CallerServicesAll"].ToString() == "frmTaskInputs")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
					if ((cb.Checked == true) & (cb.Enabled==true))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_AddTaskInput";//"eps_UpdateSkillCourses";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@ResTypeId", SqlDbType.Int);
						cmd.Parameters ["@ResTypeId"].Value=i.Cells[0].Text;
						cmd.Parameters.Add("@TaskId", SqlDbType.Int);
						cmd.Parameters ["@TaskId"].Value=Session["TaskId"].ToString();
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}
		}
		private void refreshGrid()
		{
			if (Session["CallerServicesAll"].ToString() == "frmProfileServices")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					cmd.CommandText="Select Id from ProfileServices"
						+ " Where ResTypeId = " + i.Cells[0].Text
						+ " and ProfileId = " + Session["ProfileId"].ToString();
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked = true;
						cb.Enabled = false;
						lblContent2.Text="Note that services with check marks already"
							+ " present (in shaded boxes) have already been identified for this profile.";
					}
					cmd.Connection.Close();
				}
			}
			else if (Session["CallerServicesAll"].ToString() == "frmTaskInputs")
				 {
					 foreach (DataGridItem i in DataGrid1.Items)
					 {
						 CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
						 SqlCommand cmd=new SqlCommand();
						 cmd.Connection=this.epsDbConn;
						 cmd.CommandType=CommandType.Text;
						 cmd.CommandText="Select ResTypeId from TaskInputs" 
							 + " Where ResTypeId = " + "'" + i.Cells[0].Text + "'"
							 + " and TaskId = " + "'" + Session["TaskId"].ToString() + "'";
						 cmd.Connection.Open();
						 if (cmd.ExecuteScalar() != null) 
						 {
							 cb.Checked = true;
							 cb.Enabled = false;
							 lblContent2.Text="Note that services with check marks already"
								 + " present (in shaded boxes) have already been identified.";
						 }
						 cmd.Connection.Close();
					 }
				 }
		}


		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerServicesAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerServicesAll"].ToString() + ".aspx?");
		}

		protected void btnAddAll_Click(object sender, System.EventArgs e)
		{
			Session["CUpdResType"]="frmServiceTypesAll";	
			Response.Redirect (strURL + "frmUpdResourceType.aspx?"
				+ "&btnAction=" + "Add");
		}
	}

}

