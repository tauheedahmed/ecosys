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
using System.IO;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmLicenseTerms : System.Web.UI.Page
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
			loadLicenseIForm();
		}

		private void loadLicenseIForm ()
		{
			if (!IsPostBack)
			{
/* KST2008				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select EULA, Id from LicenseTerms where Type='EPS' ";
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter (cmd);
				da.Fill(ds,"Eula");
				StreamReader r = new StreamReader (ds.Tables["Eula"].Rows[0][0].ToString());
				txtEula.Text = r.ReadToEnd();
				r.Close();
				Session["EulaId"]=ds.Tables["Eula"].Rows[0][1]; 
*/			}
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

		protected void btnAccept_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmLicenseRequest.aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmStart.aspx?");
		}




	}
}
