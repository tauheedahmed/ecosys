using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmAddResourcesInfo : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			loadData();
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

		private void loadData()
		{
			
			if (!IsPostBack)
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select * from Locations where OrganizationId = "+Request.Params["@OrgId"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"Locations");//name of dataset
				lstLocation.DataSource = ds;
				lstLocation.DataMember = "Locations";//table name
				lstLocation.DataTextField = "LocationName"; //display field
				lstLocation.DataValueField = "Id"; //bound field
				lstLocation.DataBind();
			}
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
		}
	
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_AddResourcesInfo";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Request.Params["@OrgId"];
			cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
			cmd.Parameters["@Name"].Value= txtName.Text;
			cmd.Parameters.Add ("@Description",SqlDbType.NVarChar);
			cmd.Parameters["@Description"].Value= txtDescription.Text;
			cmd.Parameters.Add ("@AvailStat",SqlDbType.NVarChar);
			cmd.Parameters["@AvailStat"].Value= txtAvailStat.Text;
			cmd.Parameters.Add ("@LocationId", SqlDbType.Int);
			cmd.Parameters["@LocationId"].Value=Int32.Parse (lstLocation.SelectedItem.Value);
			cmd.Parameters.Add ("@UpdateTiming", SqlDbType.NVarChar);
			cmd.Parameters["@UpdateTiming"].Value=txtUpdateTiming.Text;
			cmd.Parameters.Add ("@UpdateScope", SqlDbType.NVarChar);
			cmd.Parameters["@UpdateScope"].Value=txtUpdateScope.Text;
			cmd.Parameters.Add ("@RetentionPeriod", SqlDbType.NVarChar);
			cmd.Parameters["@RetentionPeriod"].Value=txtRetentionPeriod.Text;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

			Response.Redirect (strURL + "frmResourcesInfo.aspx?"
				+ "&OrgId=330");
		}

		protected void txtName_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
