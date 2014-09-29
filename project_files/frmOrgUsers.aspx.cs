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
using System.Data.SqlClient;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmOrgs.
	/// </summary>
	public partial class frmOrgUsers : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Orgs();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Orgs()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
		
			if (!IsPostBack) 
			{
                lblContents.Text = "The organizations listed below are covered by this license.  You may issue/modify user ids for these organizations upto the limit set for this license.";
				loadData();	
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgs";
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			if (Session["startForm"].ToString() == "frmMainHost")
			{
				cmd.Parameters["@LicenseId"].Value=Session["ClientLicenseId"].ToString();
			}
			else
			{
				cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			}
			cmd.Parameters.Add ("@UserTypeId",SqlDbType.Int);
			cmd.Parameters["@UserTypeId"].Value=Session["UserTypeId"].ToString();
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="Security";
			cmd.Connection=this.epsDbConn;	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Orgs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Staffing")
			{
				Session["CallerStaffing"]="frmOrgs";
				Session["OrgIdt"]=e.Item.Cells[0].Text;
				Session["OrgNamet"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmStaffing.aspx?");
			}
			else if (e.CommandName == "Msg")
			{		
				Session["CallerSendMail"]="frmOrgs";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[1].Text
					+ "&RecipientEmail=" + e.Item.Cells[3].Text
					);
			}
	
			else if (e.CommandName == "UserIds")
			{
				Session["CallerUserIds"]="frmOrgUsers";
				Session["OrgIdt"]=e.Item.Cells[0].Text;
				Session["OrgNamet"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmUserIds.aspx?");
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Session.Remove("btnAction");
			Session.Remove("CallerSendMail");
			Response.Redirect (strURL + Session["CallerOrgs"].ToString() + ".aspx?");
		}

		private void btnallMsg_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmOrgs";
			Response.Redirect (strURL + "frmSendMail.aspx?"
				+ "&Mailtype=Multiple"
				+ "&SenderName=" + Session["OrgName"].ToString()
				+ "&SenderEmail=" + Session["Email"].ToString()
				);
		}
	}
}
