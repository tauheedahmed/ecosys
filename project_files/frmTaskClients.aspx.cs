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
	public partial class frmTaskClients: System.Web.UI.Page
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
				if (Session["OrgNamet"]==null)
				{
					lblOrg.Text=Session["OrgName"].ToString();
				}
				else
				{
					lblOrg.Text=Session["OrgNamet"].ToString();
				}
				setGrid();
				loadData();		
			}		
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveTaskPeople";		
			cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
			cmd.Parameters["@TaskId"].Value=Session["TaskId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Task");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void setGrid()
		{		
			DataGrid1.Columns[11].Visible=false;
			if (Session["startForm"].ToString() == "frmMainStaff") 
			{
				btnAdd.Visible=false;
				DataGrid1.Columns[4].Visible=false;
				DataGrid1.Columns[3].Visible=false;
				
			}
			switch (Session["ServiceTypeP"].ToString())
			{
				case "":
				break;
				case "47"://i.e. Training
				
					lblContent1.Text="Course Name: " + Session["ServiceName"].ToString();
					lblContent2.Text="Location: " + Request.Params["LocName"]
						+ " Time: " + Request.Params["StartTime"];
					if (Session["Type"].ToString()== "Client")
					{			
						btnAdd.Text="Add Students";
						DataGrid1.Columns[3].HeaderText="Student Request";
						DataGrid1.Columns[4].HeaderText="Time of Request";
						DataGrid1.Columns[1].HeaderText="Students";
						
					}
					else
					{
					btnAdd.Text="Add Teachers";
					DataGrid1.Columns[3].HeaderText="Teacher Input";
					DataGrid1.Columns[4].HeaderText="Time of Input";
					DataGrid1.Columns[1].HeaderText="Teachers";	
					}	
				break;
				case "51"://i.e. emergency management
				
					lblContent1.Text="Emergency: " + Session["ServiceName"].ToString();
					lblContent2.Text="Location: " + Request.Params["LocName"]
						+ " Time: " + Request.Params["StartTime"];
					DataGrid1.Columns[3].Visible=false;
					DataGrid1.Columns[4].Visible=false;
					if (Session["Type"].ToString()== "Client")
					{									
						btnAdd.Text="Add Clients";
						DataGrid1.Columns[1].HeaderText="Clients";
					}
					else
					{
						btnAdd.Text="Add Staff";
						DataGrid1.Columns[1].HeaderText="Staff";	
					}	
	
				break;
				
				default:
                    lblContent1.Text="Service Type: " + Session["ServiceName"].ToString();
					if (Session["Type"].ToString() == "Client")
					{
						btnAdd.Text="Add Clients";
						DataGrid1.Columns[3].HeaderText="Client Input";
						DataGrid1.Columns[1].HeaderText="Clients";	
					}
					else
					{
						btnAdd.Text="Add Staff";
					}
					break;
				}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button cb = (Button)(i.Cells[10].FindControl("btnConfirm"));
				if (Session["startForm"].ToString() == "frmMainStaff") cb.Visible=false;
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
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpTaskPeople"]="frmTaskPeople";
			Response.Redirect (strURL + "frmUpdTaskPeople.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{				
				Session["CUpTaskPeople"]="frmTaskPeople";
				Response.Redirect (strURL + "frmUpdTaskPeople.aspx?"
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
				Session["CallerSendMail"]="frmTaskPeople";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["PName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[1].Text
					+ "&RecipientEmail=" + e.Item.Cells[9].Text
					);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteTaskStaffing";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
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

		protected void btnMsgAll_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmTaskPeople";
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
			Response.Redirect (strURL + Session["CallerTaskPeople"].ToString() + ".aspx?");
		}
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerTaskPeople"].ToString() + ".aspx?");
		}
	}

}

