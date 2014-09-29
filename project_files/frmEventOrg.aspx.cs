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
	/// Summary description for EmergencyPlans1.
	/// </summary>
	public partial class EmergencyPlans1 : System.Web.UI.Page
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
			// Put user code to initialize the page here
			Load_Events();
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
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);

		}
		#endregion
		private void Load_Events()
		{
			if (!IsPostBack) 
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				lblTitle.Text="Potential Hazards";
				loadData();
			}
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_RetrieveEventOrg";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=(Session["OrgId"]).ToString();	
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"Events");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
		}
		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteEvent";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["Evnt"]="Yes";
			Session["CEventsAll"]="frmEventOrg";
			Session["Function"]="List of Events";
			Response.Redirect (strURL + "frmEventsAll.aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["startForm"].ToString() + ".aspx?");
		}
	}
	
}

