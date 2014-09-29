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
	public partial class frmUpdContact : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblFunction.Text=Request.Params["btnAction"] + " Contact";
			if (!IsPostBack)
			{
				btnAction.Text= Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];				
				txtAddress.Text=Request.Params["Address"];
				txtRegularPhone.Text=Request.Params["RegularPhone"];
				txtCellPhone.Text=Request.Params["CellPhone"];
				txtEmail.Text=Request.Params["Email"];
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
				cmd.CommandText="eps_UpdateContact";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@RegularPhone",SqlDbType.NVarChar);
				cmd.Parameters["@RegularPhone"].Value=txtRegularPhone.Text;
				cmd.Parameters.Add ("@CellPhone",SqlDbType.NVarChar);
				cmd.Parameters["@CellPhone"].Value=txtCellPhone.Text;
				cmd.Parameters.Add ("@Email",SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value=txtEmail.Text;
				cmd.Parameters.Add ("@Address",SqlDbType.NVarChar);
				cmd.Parameters["@Address"].Value=txtAddress.Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddContact";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@RegularPhone",SqlDbType.NVarChar);
				cmd.Parameters["@RegularPhone"].Value=txtRegularPhone.Text;
				cmd.Parameters.Add ("@CellPhone",SqlDbType.NVarChar);
				cmd.Parameters["@CellPhone"].Value=txtCellPhone.Text;
				cmd.Parameters.Add ("@Email",SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value=txtEmail.Text;
				cmd.Parameters.Add ("@Address",SqlDbType.NVarChar);
				cmd.Parameters["@Address"].Value=txtAddress.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + "frmContacts.aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void Textbox3_TextChanged(object sender, System.EventArgs e)
		{
		
		}


	}	

}
