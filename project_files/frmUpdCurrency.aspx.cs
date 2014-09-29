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
	public partial class frmUpdCurrency: System.Web.UI.Page
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
			
	
			if (!IsPostBack)
			{
				btnAction.Text= Request.Params["btnAction"];		
				lblContent.Text=btnAction.Text + " Currency";	
				txtNameS.Text=Request.Params["NameS"];	
				txtNameP.Text=Request.Params["NameP"];	
				txtCurrCode.Text=Request.Params["Code"];
				if (Request.Params["Status"] == "1")
				{
					cbxStatus.Checked=true;
				}
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
				cmd.CommandText="fms_UpdateCurrencies";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@NameS",SqlDbType.NVarChar);
				cmd.Parameters["@NameS"].Value=txtNameS.Text;
				cmd.Parameters.Add ("@NameP",SqlDbType.NVarChar);
				cmd.Parameters["@NameP"].Value=txtNameP.Text;
				cmd.Parameters.Add ("@Code",SqlDbType.NVarChar);
				cmd.Parameters["@Code"].Value=txtCurrCode.Text;
				if (cbxStatus.Checked)
				{
					cmd.Parameters.Add ("@Status",SqlDbType.Int);
					cmd.Parameters["@Status"].Value=1;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddCurrencies";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@NameS",SqlDbType.NVarChar);
				cmd.Parameters["@NameS"].Value=txtNameS.Text;
				cmd.Parameters.Add ("@NameP",SqlDbType.NVarChar);
				cmd.Parameters["@NameP"].Value=txtNameP.Text;
				cmd.Parameters.Add ("@Code",SqlDbType.NVarChar);
				cmd.Parameters["@Code"].Value=txtCurrCode.Text;
				if (cbxStatus.Checked)
				{
					cmd.Parameters.Add ("@Status",SqlDbType.Int);
					cmd.Parameters["@Status"].Value=1;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdCurr"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}	


}
