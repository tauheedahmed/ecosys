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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmProcRoles: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		//private int I;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadForm();		
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadForm()
		{
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents1.Text="Location: " + Session["LocationName"].ToString();
				lblContents2.Text="Procedure: " + Session["ProcName"].ToString();
				loadData();	
			}
		}
		
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProcRoles";		
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcStaff");
			if (ds.Tables["ProcStaff"].Rows.Count == 0)
			{
				lblContents1.Text="Sorry, no staff roles have been created for this procedure.  Contact the system administrator.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		private void btnMsgAll_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmTaskStaffing";
			Response.Redirect (strURL + "frmSendMail.aspx?"
				+ "&Mailtype=Multiple"
				+ "&SenderName=" + Session["PName"].ToString()
				+ "&SenderEmail=" + Session["Email"].ToString()
				);
		
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CPR"].ToString() + ".aspx?");
		}
		private void btnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmMainEPS.aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Staff")
			{
				Session["CRS"]="frmProcRoles";
				Session["PSEPSSRName"]=e.Item.Cells[2].Text;
				Session["PSEPSSId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmStepRStaff.aspx?");
			}

			else if (e.CommandName == "Message")
			{		
				Session["CallerSendMail"]="frmTaskStaffing";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["PName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					//+ "&RecipientName=" + e.Item.Cells[2].Text
					//+ "&RecipientEmail=" + e.Item.Cells[9].Text
					);
			}
			else if (e.CommandName == "Confirm")
			{					
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateStaffingTaskC";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Parameters.Add ("@Action", SqlDbType.NVarChar);
				Button cb = (Button)(e.Item.Cells[10].FindControl("btnConfirm"));
				cmd.Parameters["@Action"].Value=cb.Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			loadData();
		
		}

	}

}

