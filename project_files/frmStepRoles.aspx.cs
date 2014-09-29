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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmStepRoles : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//Session["Caller3"]="frmStepRoles";
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
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents1.Text=Session["StepName"].ToString();
			lblContents2.Text="Types of Skills Required";
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveStepRoles";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@StepId",SqlDbType.Int);
			cmd.Parameters["@StepId"].Value=Session["StepId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StepRoles");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CallerRolesAll"]="frmStepRoles";	
			Response.Redirect (strURL + "frmRolesAll.aspx?"
				+ "&StepId=" + Session["StepId"].ToString()
				+ "&StepName=" + Session["StepName"].ToString());
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerStepRoles"].ToString() + ".aspx?");
		}
	}

}
	