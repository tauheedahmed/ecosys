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
	public class frmUpdStep : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.Label lblProcName;
		protected System.Web.UI.WebControls.TextBox txtProcessName;
		protected System.Web.UI.WebControls.Button btnAction;
		private String ProcessId;
		protected System.Web.UI.WebControls.Label lblOrg;
		protected System.Web.UI.WebControls.Label lblContent;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox txtDesc;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnCancel;		
		private void Page_Load(object sender, System.EventArgs e)
		{
			ProcessId=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString();
	
			if (!IsPostBack)
			{
				btnAction.Text= Request.Params["btnAction"];		
				lblContent.Text=btnAction.Text;	
				txtProcessName.Text=Request.Params["Name"];	
				txtDesc.Text=Request.Params["Desc"];	
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
		this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
		this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
		this.Load += new System.EventHandler(this.Page_Load);

	}
		#endregion


		private void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateStep";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(ProcessId);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtProcessName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_AddStep";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtProcessName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@ProcsId",SqlDbType.Int);
				cmd.Parameters["@ProcsId"].Value=Session["ProcsId"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}

		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdStep"].ToString() + ".aspx?");
				
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}	


}
