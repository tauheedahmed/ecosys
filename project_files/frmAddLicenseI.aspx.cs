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
	public partial class frmAdd : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string FName;
		private string LName;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			loadLicenseIForm();
		}

		private void loadLicenseIForm ()
		{
			loadDomains();
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

		private void loadDomains() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Domains Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Domains");
			lstDomain.DataSource = ds;
			lstDomain.DataMember = "Domains";
			lstDomain.DataTextField = "Name";
			lstDomain.DataValueField = "Id";
			lstDomain.DataBind();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmStart.aspx?");
		}

		protected void lblContinue_Click(object sender, System.EventArgs e)
		{
			Session["FName"] = txtFName.Text;
			Session["LName"] = txtLName.Text;
			FName=txtFName.Text;
			LName=" " + txtLName.Text;
			Session["Address"] = txtAddress.Text;
			Session["DomainId"] = lstDomain.SelectedItem.Value;
			Session["MenuType"] = RadioButtonList1.SelectedItem.Value;
			Session["HPhone"] = txtHPhone.Text;
			Session["WPhone"] = txtWPhone.Text;
			Session["CPhone"] = txtCPhone.Text;
			Session["Email"] = txtEmail.Text;

			if (Session["MenuType"].ToString() == "Organization")
			{
				Response.Redirect (strURL + "frmAddLicenseIa.aspx?");
			}
			else
			{
				Session["Org"]=FName+LName;
				Response.Redirect (strURL + "frmAddLicenseIb.aspx?");
			}
		}

	
	}
}
