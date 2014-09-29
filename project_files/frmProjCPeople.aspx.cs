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
	public partial class frmProjCPeople: System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents1.Text="Location: " + Session["LocationName"].ToString();
				lblContents2.Text="Click on 'Add' to register new Clients for the process '"
				+ " project '"
				+ Session["ProjName"].ToString()
				+ "', process named "
				+ Session["ProcName"].ToString()
				+ "'";
				loadData();	
			}
		}
		
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjCPeople";	
			cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			cmd.Parameters.Add ("@PSEPCID",SqlDbType.Int);
			cmd.Parameters["@PSEPCID"].Value=Session["PSEPCID"].ToString();
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProjCPeople");
			if (ds.Tables["ProjCPeople"].Rows.Count == 0)
			{
				lblContents2.Text="There are no clients identified.  Click on 'Add' to add clients.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			//refreshGrid();
		}
		/*private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxBackup"));

				if (i.Cells[3].Text == "0")
				{
					cb.Checked=false;
				}
				else
				{
					cb.Checked=true;
				}
			}
		}*/
		
		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_DeleteOLPCPeople";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id", SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
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
			loadData();
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			//updateGrid();
			Exit();
		}
		/*private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxBackup"));				
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;					
				if (cb.Checked)
				{
					cmd.CommandText="Update OLPSPeople"
						+ " Set BkupFlag=1" 
						+ " Where Id = " + i.Cells[0].Text;
				}
				else
				{
					cmd.CommandText="Update OLPSPeople"
						+ " Set BkupFlag=0" 
						+ " Where Id = " + i.Cells[0].Text;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
		}*/

		private void Exit()
		{
			Response.Redirect (strURL + Session["CPCP"].ToString() + ".aspx?");
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CA"]="frmProjCPeople";
			Response.Redirect (strURL + "frmClientActions.aspx?");
		}
	}

}

