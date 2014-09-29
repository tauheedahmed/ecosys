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
	/// Summary description for frmOrgResTypes1.
	/// </summary>
	public partial class frmProjStepStaff : System.Web.UI.Page
	{
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
				lblOrg.Text=Session["OrgName"].ToString();
				btnAdd.Text="Cancel";
				lblContents1.Text="Staff Assigned for step '"
					+ Session["StepName"].ToString() 
					+ "'.";
				btnAdd.Text="Add";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProjSStaff";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProjectsId", SqlDbType.Int);
			cmd.Parameters["@ProjectsId"].Value=Session["ProjectId"].ToString();
			cmd.Parameters.Add ("@PSEPSId",SqlDbType.Int);
			cmd.Parameters["@PSEPSId"].Value=Session["PSEPSId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"STasks");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (ds.Tables["STasks"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="There are no staff assigned for this step."
					+ " Return to the Process Form and assign staff for this step.";								
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CPStaff"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CSRSP"]="frmProjectStaff";
			Response.Redirect (strURL + "frmSRSProject.aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_DeleteProjectStaff";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProjectId", SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			cmd.Parameters.Add ("@PSEPSId",SqlDbType.Int);
			cmd.Parameters["@PSEPSId"].Value=Session["PSEPSId"].ToString();
			cmd.Parameters.Add ("@OLPSPeopleId", SqlDbType.Int);
			cmd.Parameters["@OLPSPeopleId"].Value=e.Item.Cells[0].Text;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}
	}
}
