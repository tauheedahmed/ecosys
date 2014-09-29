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
	public partial class frmLicenseRequest : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		
		protected void Page_Load(object sender, System.EventArgs e)
		{	
			lblContent.Text="Please enter information requested:";
			/*txtName.Text=Session["Org"].ToString();
			txtPhone.Text=Session["OPhone"].ToString();
			txtEmail.Text=Session["OEmail"].ToString();
			txtAddr.Text=Session["OAddr"].ToString();*/			
			Random i = new Random ();
			int num = i.Next();

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
		protected void btnContinue_Click(object sender, System.EventArgs e)
		{
			Session["ContactFName"]=txtFNamePerson.Text;
			Session["ContactLName"]=txtLNamePerson.Text;
			Session["OrgName"]=txtName.Text;
			Session["OPhone"]=txtPhone.Text;
			Session["OEmail"]=txtEmail.Text;
			Session["OAddr"]=txtAddr.Text;
			Response.Redirect (strURL + "frmLicenseConfirm.aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmStart.aspx?");
		}

		protected void btnPrevious_Click(object sender, System.EventArgs e)
		{
			Session["Org"]=txtName.Text;
			Session["OPhone"]=txtPhone.Text;
			Session["OEmail"]=txtEmail.Text;
			Session["OAddr"]=txtAddr.Text;
			Response.Redirect (strURL + "frmStart.aspx?");
		
		}
	}
}
