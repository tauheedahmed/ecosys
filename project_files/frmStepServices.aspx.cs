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
	public partial class frmStepTasks : System.Web.UI.Page
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
			Load_Procedures();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents.Text="Business Procedure: " 
				+ Request.Params["StepName"];
			lblContents2.Text="The above Step is required by one or more services as listed below."
                + " If you still wish to delete this step,"
				+ " please first remove these links by clicking on the button marked 'delete'."
				+ " You may then go back and delete this step.";
			if (!IsPostBack) 
			{	
				loadData();		
			}
		}

		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTaskSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="Steps";
			cmd.Parameters.Add ("@StepId",SqlDbType.Int);
			cmd.Parameters["@StepId"].Value=Request.Params["StepId"];
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StepTasks");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Delete from TaskSteps"
					+ " Where Id = " + e.Item.Cells[0].Text;
				cmd.Connection=this.epsDbConn;
				//cmd.Parameters.Add ("@Id", SqlDbType.Int);
				//cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CStepTasks"].ToString() + ".aspx?");
		}


	}

}
	