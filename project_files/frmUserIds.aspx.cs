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
	public partial class frmUserIds : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_UserIds();
			lblContents.Text="User Type: " + Session["UserType"].ToString();
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
		private void Load_UserIds()
		{
			if (!IsPostBack) 
			{
				lblOrg.Text=Session["OrgNamet"].ToString();
				if (Session["startForm"].ToString() == "frmMainHost")
				{
					DataGrid1.Columns[7].Visible=false;
				}
				loadData();
			}
		}
		private void loadData ()
		{
			
		SqlCommand cmd=new SqlCommand();
		cmd.CommandType=CommandType.StoredProcedure;
		cmd.CommandText="eps_RetrieveUsers";
		cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
		cmd.Parameters["@OrgId"].Value=Session["OrgIdt"].ToString();
		cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
		cmd.Parameters["@Caller"].Value="frmMainSec";
		cmd.Parameters.Add ("@UserTypeId",SqlDbType.Int);
		cmd.Parameters["@UserTypeId"].Value=Session["UserTypeId"];
		cmd.Connection=this.epsDbConn;	
		DataSet ds=new DataSet();
		SqlDataAdapter da=new SqlDataAdapter(cmd);
		da.Fill(ds,"Users");
		Session["ds"] = ds;
		DataGrid1.DataSource=ds;
		DataGrid1.DataBind();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{				
				Session["CallerUpdUsers"]="frmUserIds";
				Session["Id"]=e.Item.Cells[0].Text;
				/*Session["User"]=e.Item.Cells[1].Text;
				Session["Pd"]=e.Item.Cells[3].Text;
				Session["Status"]=e.Item.Cells[4].Text;
				Session["PeopleId"]=e.Item.Cells[5].Text;*/
				Session["btnAction"]= "Update";
				Response.Redirect (strURL + "frmUpdUsers.aspx?");
			}
			else if (e.CommandName == "Msg")
			{
				Session["CallerSendMail"]="frmUserIds";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[3].Text
					+ "&RecipientEmail=" + e.Item.Cells[6].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteUser";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerUserIds"].ToString() + ".aspx?"
				+ "&btnAction=Update");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
            Session["btnAction"] = "Add";
            Session["CallerUpdUsers"] = "frmUserIds.aspx?";
			Response.Redirect (strURL + "frmUpdUsers.aspx?");
		}
		
	}
}
