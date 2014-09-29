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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmPeopleStatus : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnContactData;
		protected System.Web.UI.WebControls.Button btnAdd;
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
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents1.Text=Session["PName"].ToString();
			lblContents2.Text="Status Reporting";
		
			/*Label1.Text="Welcome to your Individual Task form."
				+ " Here, you can review all your tasks,"
				+ " apply for registration for certain types of tasks including training classes,"
				+ " report on the completion status of these tasks,"
				+ " as well as your time spent on them.";*/
			if (!IsPostBack) 
			{	
				
				loadStatus();
				setGrid();	
			}
		}
		private void loadStatus ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTaskPeople";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="frmMainStaff";
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"TaskPeople");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerPeopleStatus"].ToString() + ".aspx?");
		}
		private void setGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button btnStaff = (Button)(i.Cells[9].FindControl("btnStaff"));
				Button btnClient = (Button)(i.Cells[9].FindControl("btnClients"));
				switch (i.Cells[19].Text.ToString())
				{
					case "":
					case "47":
						btnStaff.Text = "Teachers";
						btnClient.Text = "Students";
						break;
					default:
						btnStaff.Text = "Staff";
						btnClient.Text = "Clients";
						break;
				}
			}
		}
		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				if (e.CommandName == "Clients")
			{
				Session["CallerTaskPeople"]="frmPeopleStatus";
				Session["TaskName"]=e.Item.Cells[10].Text;
				Session["TaskId"]=e.Item.Cells[18].Text;
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ServiceType"]=e.Item.Cells[19].Text;
				Session["Type"]="Client";
				Response.Redirect (strURL + "frmTaskPeople.aspx?"
					+ "&LocName=" + e.Item.Cells[15].Text
					+ "&StartTime=" + e.Item.Cells[2].Text);
			}
			else if (e.CommandName == "Staff")
			{
				Session["CallerTaskPeople"]="frmPeopleStatus";
				Session["TaskName"]=e.Item.Cells[10].Text;
				Session["TaskId"]=e.Item.Cells[18].Text;
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ServiceType"]=e.Item.Cells[19].Text;
				Session["Type"]="Staff";
				Response.Redirect (strURL + "frmTaskPeople.aspx?"
					+ "&LocName=" + e.Item.Cells[15].Text
					+ "&StartTime=" + e.Item.Cells[2].Text);
			}
			else if (e.CommandName == "Details")
			{
					
				Session["CallerActDetail"]="frmPeopleStatus";
				Response.Redirect (strURL + "frmTaskDetail.aspx?"
					+ "&ServiceName=" + e.Item.Cells[1].Text
					+ "&Start=" + e.Item.Cells[2].Text
					+ "&End=" + e.Item.Cells[3].Text
					+ "&RegStatus=" + e.Item.Cells[4].Text
					+ "&Desc=" + e.Item.Cells[7].Text
					+ "&Type=" + e.Item.Cells[8].Text
					+ "&TaskName=" +  e.Item.Cells[10].Text
					+ "&LicOrg=" +  e.Item.Cells[11].Text
					+ "&MgrOrg=" +  e.Item.Cells[12].Text
					+ "&LicId=" +  e.Item.Cells[13].Text					
					+ "&Status=" + e.Item.Cells[14].Text				
					+ "&Loc=" + e.Item.Cells[15].Text
					+ "&LocAddress=" +  e.Item.Cells[16].Text
					+ "&Comment=" +  e.Item.Cells[17].Text
					+ "&ServiceType=" + e.Item.Cells[19].Text
					);
			}
		}
	}
}
	