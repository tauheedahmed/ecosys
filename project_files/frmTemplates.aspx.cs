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
	/// Summary description for Templates.
	/// </summary>
	public partial class Templates : System.Web.UI.Page
	{
		private string OrgIdT;
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		Load_Main();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Select);

		}
		#endregion
		private void Load_Main()
		{	lblOrg.Text=Session["OrgName"].ToString();	
			if (!IsPostBack) 
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_RetrieveTemplates";
				cmd.Parameters.Add("@MenuType", SqlDbType.NVarChar);
				cmd.Parameters["@MenuType"].Value=Session["MenuType"].ToString();		
				cmd.Connection=this.epsDbConn;
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"UserOrg");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			}
		}
		private void Done ()
		{
		Response.Redirect (strURL + "frmMain.aspx?");
		}

		private void Select(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			OrgIdT=(e.Item.Cells[0].Text);
			TemplateOrgs();
			TemplateProcesses();
			TemplateProcessSteps();			
			TemplateStaffing();		
			TemplateResources();
			TemplateResourceInputs();
			TemplateAssess();
			TemplateEnd();
		}
		private void Exit()
		{
			Response.Redirect (strURL + "frmStart.aspx?");
		}
		private void TemplateEnd()
		{
			DataGrid1.Visible=false;
			btnNoTemplates.Visible=false;
			lblOK.Text="Congratulations.  Emergency Plans have been successfully prepared for "
				+ Session["OrgName"].ToString().Trim()
				+ ".  Please make a note of your User Id and keep in a secure place"
				+ " for future reference."
				+ " Your User Id is: "
				+ "'" + Session["UserId"].ToString().Trim() + "'."
				+ "  Your Password is: "
				+ "'" + Session["Password"].ToString().Trim() + "'."
				+ "Press button to Exit";
		btnExit.Visible=true;
		

		}
		private void TemplateOrgs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateOrgs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId", SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdT", SqlDbType.Int);
			cmd.Parameters["@OrgIdT"].Value=OrgIdT;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		public void TemplateProcesses()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateProcEmergency";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void TemplateProcessSteps()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateProcessSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId", SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}

		private void TemplateStaffing()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateStaffing";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void TemplateResources()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateResources";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void TemplateResourceInputs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateResourceInputs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}

		private void TemplateAssess()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_TemplateAssess";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}

		protected void btnNoTemplates_Click(object sender, System.EventArgs e)
		{
		Exit();
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

	
	}
}
