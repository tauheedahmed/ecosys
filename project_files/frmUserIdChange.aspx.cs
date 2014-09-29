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
	public partial class frmUserIdChange : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.Label lblAccept;
		Decimal I;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				loadOrg();
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

		private void loadOrg()
		{
			
		
		}
		protected void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//verifyCurrent();
			lblError.Text=null;
			verifyPW();
			Response.Redirect (strURL + "frmStart.aspx?");
		}
		private void verifyPW()
		{
			I=txtPassword.Text.Length;
			if ((I < 6 ) || (I >12) )
			{
				lblError.Text="Sorry.  The password must be between 6 and 12 characters.";
			}
			else if (txtPassword.Text != txtPasswordcheck.Text)
			{
				lblError.Text="Sorry.  The Password entered in the two fields for Password do not match)";
			}
			else if (txtUser.Text.Length >20)
			{
				lblError.Text="Sorry.  The UserId cannot be larger than 20 characters.";
			}
			else
			{
				updateUserId();
			}
			//	Validate: PW max 12 characters, min 10 characters
			//	Validate: txtPassword=txtPasswordcheck
		}
		private void updateUserId()
		{
			try
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateUserIds";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Session["UserIdId"].ToString());
				cmd.Parameters.Add ("@pw",SqlDbType.NVarChar);
				cmd.Parameters["@pw"].Value=txtPassword.Text;
				cmd.Parameters.Add ("@userid",SqlDbType.NVarChar);
				cmd.Parameters["@userid"].Value=txtUser.Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				done();
			}
			catch (SqlException err)
			{
				if (err.Message.StartsWith ("Violation of UNIQUE")) 
					lblError.Text = "This User ID already exists, please use a different one.";
				else lblError.Text = err.Message;
			}
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			done();
		}
		private void done()
		{
			Response.Redirect (strURL + "frmStart.aspx?");
		}

	}
}
