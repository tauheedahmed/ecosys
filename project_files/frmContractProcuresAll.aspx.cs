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
	public partial class frmContractProcuresAll : System.Web.UI.Page
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
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblTitle.Text="Procurement Actions";
				lblContents1.Text="Listed below is a list of outstanding procurement requests"
					+ " for various types of goods and services.  Please select the request"
					+ " (if any) to be included in the list of procurement items under contract titled '"
					+ Session["ContractTitle"].ToString()
					+ "' from the following supplier: '"
					+ Session["ContractSupplier"].ToString()
					+ "'.";
				loadData();
			}
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
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrievePSEPResInvRequests";
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ContracProcures");
			if (ds.Tables["ContracProcures"].Rows.Count == 0)
			{
				lblContents1.Visible=false;
				lblContents.Text="There are no contract requests outstanding against which you may "
					+ " prepare contracts.  Contract requests are prepared using a different type"
					+ " of user account.  Contact your System Administrator for further assistance."
					+ " Click on 'Exit' to continue.";
				DataGrid1.Visible=false;
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "fms_AddPSEPResInventory";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Parameters.Add ("@ContractId", SqlDbType.Int);
				cmd.Parameters["@ContractId"].Value=Session["ContractId"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Exit();
                //lblContents.Text = "Id: " + e.Item.Cells[0].Text + "|| ContractID: " + Session["ContractId"].ToString();
			}
		
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CCPAll"].ToString() + ".aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
        
}
}
	