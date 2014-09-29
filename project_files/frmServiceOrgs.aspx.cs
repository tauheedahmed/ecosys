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
	public partial class frmServiceOrgs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string ParentId;
        
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
			if (!IsPostBack) 
			{
				ParentId=Session["OrgId"].ToString();
				lblContents.Text="Studentand Teacher Groups";
				loadData();
				lblOrg.Text=Session["OrgName"].ToString();
				lblService.Text=Session["ServiceName"].ToString();
			}
		}
		
		private void loadData ()
		{
		SqlCommand cmd=new SqlCommand();
		cmd.CommandType=CommandType.StoredProcedure;
		cmd.CommandText="eps_RetrieveServiceOrgs";
		cmd.Parameters.Add ("@Service",SqlDbType.Int);
		cmd.Parameters["@Service"].Value=Session["ActivationId"].ToString();
		cmd.Connection=this.epsDbConn;	
		DataSet ds=new DataSet();
		SqlDataAdapter da=new SqlDataAdapter(cmd);
		da.Fill(ds,"ServiceOrgs");
		Session["ds"] = ds;
		DataGrid1.DataSource=ds;
		DataGrid1.DataBind();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Staffing")
			{
				Session["CallerStaffing"]="frmServiceOrgs";
				Session["OrgIdS"]=e.Item.Cells[0].Text;
				Session["OrgIdSName"]=e.Item.Cells[2].Text;;
				//Session["ResourceName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmStaffing.aspx?");
			}

			else if (e.CommandName == "Update")
			{				
				Session["CallerUpdOrg"]="frmServiceOrgs";
				Response.Redirect (strURL + "frmUpdOrg.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&OrgType=" + e.Item.Cells[1].Text
					+ "&Name=" + e.Item.Cells[2].Text
					+ "&Desc=" + e.Item.Cells[3].Text
					+ "&Phone=" + e.Item.Cells[4].Text
					+ "&Email=" + e.Item.Cells[5].Text
					+ "&Addr=" + e.Item.Cells[6].Text
					+ "&PeopleId=" + e.Item.Cells[7].Text
					+ "&LocId=" + e.Item.Cells[8].Text);
			}
			else if (e.CommandName == "Msg")
			{		
				Session["CallerSendMail"]="frmServiceOrgs";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[1].Text
					+ "&RecipientEmail=" + e.Item.Cells[3].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteServiceOrg";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["OrgType"]="Student Batch";
			Session["CallerUpdOrg"]="frmServiceOrgs";
			Response.Redirect (strURL + "frmUpdOrg.aspx?"
				+ "&btnAction=" + "Add");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerServiceOrgs"].ToString() + ".aspx?");
		}

		protected void btnallMsg_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmServiceOrgs";
			Response.Redirect (strURL + "frmSendMail.aspx?"
				+ "&Mailtype=Multiple"
				+ "&SenderName=" + Session["OrgName"].ToString()
				+ "&SenderEmail=" + Session["Email"].ToString()
				);
		}

		protected void btnAddt_Click(object sender, System.EventArgs e)
		{
			Session["OrgType"]="Teacher Group";
			Session["CallerUpdOrg"]="frmServiceOrgs";
			Response.Redirect (strURL + "frmUpdOrg.aspx?"
				+ "&btnAction=" + "Add");
		}
	}
}
