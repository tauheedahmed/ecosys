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
	public partial class frmStaffActions: System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadForm()
		{			
			DataGrid1.Columns[1].HeaderText="Appointment Actions";
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
                lblAptType.Text = "Type of Appointment: " + Session["STName"].ToString();
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveStaffActionsApt";
			cmd.Parameters.Add ("@OrgStaffTypesId",SqlDbType.Int);
			cmd.Parameters["@OrgStaffTypesId"].Value=Int32.Parse(Session["OrgStaffTypesId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffActions");
			if (ds.Tables["StaffActions"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.Text="There are no individuals who are identified"
					+ " as being part of your organization."
					+ " Click on 'Add' to identify such individuals.";
			}
			else
			{
				
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (Session["startForm"].ToString() == "frmMainWorkProg")
			{
				refreshGrid();
			}
			
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button btDu = (Button)(i.Cells[4].FindControl("btnDuties"));
				Button btD = (Button)(i.Cells[4].FindControl("btnDelete"));
				if (i.Cells[5].Text != Session["OrgId"].ToString())
				{
					btDu.Visible=false;
					btD.Visible=false;
					i.Cells[4].Text="Externally Managed"; 
				}
				else if (i.Cells[2].Text.Trim() != "New Appointment Request")
				{
					btDu.Visible=false;
					btD.Visible=false;
					i.Cells[4].Text="Existing Appointment Action";
				}
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            {
                Session["PeopleId"]=null;
                Session["CallerPeople"] = "frmStaffActions";
                Session["CSA"] = "frmStaffActions";
                Response.Redirect(strURL + "frmPeople.aspx?");
            }
            /*			
			Session["btnAction"]="Add";
			Response.Redirect (strURL + "frmUpdStaffAction.aspx?");*/
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["SA"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["SA"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["PeopleName"]=e.Item.Cells[1].Text;
			if (e.CommandName == "Duties")
			{				
				Session["StaffActionsId"] = e.Item.Cells[0].Text;
				Session["CTSSA"]="frmStaffActions";
				Response.Redirect (strURL + "frmTSSA.aspx?");				
			}
			else if (e.CommandName == "Revisions")
			{
				Session["CallerSARev"]="frmStaffActions";
				Session["btnAction"]="Update";
				Session["OrgIdSA"]=e.Item.Cells[5].Text;
				Session["Id"]=e.Item.Cells[0].Text;
                Response.Redirect(strURL + "frmSARev.aspx?");
				
			}
            else if (e.CommandName == "Update")
            {
                Session["CSA"] = "frmStaffActions";
                Session["btnAction"] = "Update";
                Session["OrgIdSA"] = e.Item.Cells[5].Text;
                Session["Id"] = e.Item.Cells[0].Text;
                Response.Redirect(strURL + "frmUpdStaffAction.aspx?");

            }
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="hrs_DeleteStaffAction";
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
	}
}

