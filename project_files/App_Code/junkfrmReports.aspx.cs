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
using CrystalDecisions.Shared;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for MainReport.
	/// </summary>
	public class junkfrmReport : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Button Button2;
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		protected System.Web.UI.WebControls.Label lblOrg;
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Main();
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Main()
		{
			lblOrg.Text=(Session["OrgName"]).ToString();
		}

		

		private void Button2_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["Caller1"].ToString() + ".aspx?");
		}


		
		

		
	}
}
