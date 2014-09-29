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
	public partial class frmUpdOrgHousehold : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String ParentId;
		private String Id;
		protected void Page_Load(object sender, System.EventArgs e)
		{
				lblOrg.Text=Session["OrgName"].ToString();
				Id=Request.Params["Id"];
	
			if (!IsPostBack)
			{
				btnAction.Text= Session["btnAction"].ToString();
				lblContent.Text=btnAction.Text + " Household Details";
				txtName.Text=Request.Params["Name"];
				txtDesc.Text=Request.Params["Desc"];
				txtPhone.Text=Request.Params["Phone"];
				txtEmail.Text=Request.Params["Email"];
				txtAddr.Text=Request.Params["Addr"];
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
				cmd.CommandText="eps_UpdateOrg";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;
				cmd.Parameters.Add ("@Phone",SqlDbType.NVarChar);
				cmd.Parameters["@Phone"].Value=txtPhone.Text;
				cmd.Parameters.Add ("@Email",SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value=txtEmail.Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				ParentId = Session["OrgId"].ToString();

				SqlCommand cmd1=new SqlCommand();
				cmd1.CommandType=CommandType.StoredProcedure;
				cmd1.CommandText="eps_AddOrg";
				cmd1.Connection=this.epsDbConn;
				cmd1.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd1.Parameters["@Name"].Value= txtName.Text;
				cmd1.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd1.Parameters["@Desc"].Value= txtDesc.Text;
				cmd1.Parameters.Add ("@Phone",SqlDbType.NVarChar);
				cmd1.Parameters["@Phone"].Value= txtPhone.Text;
				cmd1.Parameters.Add ("@Email",SqlDbType.NVarChar);
				cmd1.Parameters["@Email"].Value=txtEmail.Text;
				cmd1.Parameters.Add ("@Addr",SqlDbType.NText);
				cmd1.Parameters["@Addr"].Value= txtAddr.Text;
				cmd1.Parameters.Add ("@ParentOrg",SqlDbType.Int);
				cmd1.Parameters["@ParentOrg"].Value=ParentId;
				cmd1.Parameters.Add ("@Creator",SqlDbType.Int);
				cmd1.Parameters["@Creator"].Value=Session["OrgId"].ToString();
				cmd1.Parameters.Add ("@LicenseId",SqlDbType.Int);
				cmd1.Parameters["@LicenseId"].Value= Session["LicenseId"];
				cmd1.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
				cmd1.Parameters["@OrgType"].Value="Household";				
				cmd1.Connection.Open();
				cmd1.ExecuteNonQuery();
				cmd1.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdOrgHousehold"].ToString() + ".aspx?");	
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}	


}
