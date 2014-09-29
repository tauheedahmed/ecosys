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
	public partial class frmUpdStep : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String ProcessId;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ProcessId=Request.Params["Id"];
            if (!IsPostBack)
			{
                lblContent.Text = "";
                btnAction.Text = Request.Params["btnAction"] ;	
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

	}
		#endregion


		protected void btnAction_Click(object sender, System.EventArgs e)
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

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}	


}
