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
	public partial class frmActStaff: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
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
				lblOrg.Text=Session["OrgNamet"].ToString();
				setGrid();
			}
				
		}
		private void setGrid()
		{
			if (Session["ActivationName"].ToString() == "Courses")
			{
				
					lblContent1.Text="Course Name: " + Session["ServiceName"].ToString();
					lblContent2.Text="Location: " + Request.Params["LocName"]
						+ " Time: " + Request.Params["StartTime"];
					lblContent3.Text="Appoint Teachers";
					btnAdd.Text="Add Teachers";
					DataGrid1.Columns[1].HeaderText="Teachers";
					DataGrid1.Columns[3].Visible=false;
					DataGrid1.Width=914;
					DataGrid1.Columns[2].Visible=false;
					DataGrid1.Columns[3].Visible=true;		
					DataGrid1.Columns[4].Visible=false;
					DataGrid1.Columns[5].Visible=true;
					DataGrid1.Columns[10].Visible=true;
					DataGrid1.Columns[11].Visible=false;
				
			}
			else
			{
				lblContent1.Text="Service Type: " + Session["ServiceName"].ToString();
				lblContent3.Text="Add/Remove Team Members";
				btnAdd.Text="Add Team Members";
				DataGrid1.Columns[3].Visible=false;
				DataGrid1.Columns[4].Visible=false;
				DataGrid1.Columns[5].Visible=false;
				DataGrid1.Columns[10].Visible=false;
				DataGrid1.Columns[11].Visible=true;
			}
			loadData();
		}

		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveActPeopleMgr";
			if (Session["ActivationName"].ToString() == "Courses")
			{
				cmd.Parameters.Add ("@ActivationId",SqlDbType.Int);
				cmd.Parameters["@ActivationId"].Value=Session["ActivationId"].ToString();
				cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
				cmd.Parameters["@RoleId"].Value=9;
			}
			else
			{
				cmd.Parameters.Add ("@ActivationId",SqlDbType.Int);
				cmd.Parameters["@ActivationId"].Value=Session["ActivationId"].ToString();
			}
			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Act");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button cb = (Button)(i.Cells[10].FindControl("btnConfirm"));
				
				if (i.Cells[5].Text == "Cancelled")
				{
					cb.Text="Re-Instate";
				}
				else if (i.Cells[5].Text == "Awaiting Registration")
				{
					cb.Text = "Confirm";
				}
				else if (i.Cells[5].Text == "Registered")
				{
					cb.Text = "Cancel";
				}
				
				else
				{
					cb.Text = "Unknown";
				}

			}
		}


		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerActStaff"].ToString() + ".aspx?");
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerActStaff"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpActPeople"]="frmActStaff";
			Response.Redirect (strURL + "frmUpdActPeople.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{				
				Session["CUpActPeople"]="frmActStaff";
				Response.Redirect (strURL + "frmUpdActPeople.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&PeopleId=" + e.Item.Cells[8].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&RoleId=" + e.Item.Cells[2].Text
					+ "&Desc=" + e.Item.Cells[6].Text
					+ "&Caller=" + e.Item.Cells[7].Text);
			}
			else if (e.CommandName == "Message")
			{		
				Session["CallerSendMail"]="frmActPeople";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[1].Text
					+ "&RecipientEmail=" + e.Item.Cells[9].Text
					);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteStaffingAct";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Confirm")
			{
					Button cb = (Button)(e.Item.Cells[10].FindControl("btnConfirm"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateStaffingActC";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id", SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
					cmd.Parameters.Add ("@Action", SqlDbType.NVarChar);
					cmd.Parameters["@Action"].Value=cb.Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				setGrid();
			}
		}

		protected void btnMsgAll_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmActStaff";
			Response.Redirect (strURL + "frmSendMail.aspx?"
				+ "&Mailtype=Multiple"
				+ "&SenderName=" + Session["OrgName"].ToString()
				+ "&SenderEmail=" + Session["Email"].ToString()
				);
		}
	}

}

