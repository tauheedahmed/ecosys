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
	/// Summary description for frmStaffing.
	/// </summary>
	public partial class frmStaffing : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection ("Server=cp2693-a\\eps1;database=eps1;"+
		"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblOrg2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Staffing();
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
		private void Load_Staffing()
		{
			if (!IsPostBack)
			{
				if (Session["CallerStaffing"].ToString() == "frmOrgs")
				{
					lblOrg1.Text=Session["OrgName"].ToString() + ": " 
						+ Session["OrgNamet"].ToString();
				}
				else
				{
					lblOrg1.Text=Session["OrgName"].ToString();
				}
				lblHeading.Text="Staffing";
				loadData1();				
			}
		}

		private void loadData1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveStaffing";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgIdt",SqlDbType.Int);
			cmd.Parameters["@OrgIdt"].Value=Session["OrgIdt"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Staffing");
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{				
				Session["cUpdStaffing"]="frmStaffing";
				Response.Redirect (strURL + "frmUpdStaffing.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&PeopleId=" + e.Item.Cells[4].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&RoleId=" + e.Item.Cells[6].Text
					+ "&Desc=" + e.Item.Cells[3].Text
					+ "&Caller=" + e.Item.Cells[5].Text);
			}
			else if (e.CommandName == "Msg")
			{		
				Session["CallerSendMail"]="frmStaffing";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[2].Text
					+ "&RecipientEmail=" + e.Item.Cells[7].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteStaffing";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData1();
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			//Session["CallerPeople"]="frmStaffing";
			//Response.Redirect (strURL + "frmPeople.aspx?");
			Session["CallerPeople"]="frmStaffing";
			Response.Redirect (strURL + "frmPeople.aspx?");
			
			/*Response.Redirect (strURL + "frmUpdStaffing.aspx?"
				+ "&btnAction=" + "Add");*/
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerStaffing"].ToString() + ".aspx?");
		}
		protected void btnAddS_Click(object sender, System.EventArgs e)
		{
			Session["CallerSSA"]="frmStaffing";
			Response.Redirect (strURL + "frmStaffSkillsAll.aspx?");
		}
		protected void btnallMsg_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmStaffing";
			Response.Redirect (strURL + "frmSendMail.aspx?"
				+ "&Mailtype=Multiple"
				+ "&SenderName=" + Session["OrgName"].ToString()
				+ "&SenderEmail=" + Session["Email"].ToString()
				);
		}
	}
}
