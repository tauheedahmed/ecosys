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
	public partial class frmOLPProjectsAdd: System.Web.UI.Page
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
			DataGrid1.Columns[1].HeaderText=Session["ProjTypeName"].ToString();
			DataGrid1.Columns[6].Visible=false;
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text="Select projects to from the list below.  To create"
					 + " new projects, click on the 'Add' button";
				loadData();
			}
				
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveOLPProjectsAdd";
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@PSEPId",SqlDbType.Int);
			cmd.Parameters["@PSEPId"].Value=Session["PSEPID"].ToString();
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from OLPProjects"
							+ " Where ProjectId = " + i.Cells[0].Text
							+ " and PSEPID = " + Session["PSEPID"].ToString()
							+ " and OrgLocId = " + Session["OrgLocId"].ToString();

				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true; 
					cb.Enabled=false;
				}
				cmd.Connection.Close();
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
					if ((cb.Checked == true) & (cb.Enabled == true))
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="wms_AddOLPProjects";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
						cmd.Parameters ["@ProjectId"].Value=i.Cells[0].Text;
						cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
						cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
						cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
						cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPOLPAdd"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdProject"]="frmOLPProjectsAdd";
			Response.Redirect (strURL + "frmUpdProject.aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdProject"]="frmOLPProjectsAdd";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProject.aspx?");
					
			}
			/*else if (e.CommandName == "Timetable")
			{
				Session["CUpdTT"]="frmProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmUpdTimetable.aspx?");
					
			}
			else if (e.CommandName == "Clients")
			{
				Session["CPClient"]="frmProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcClient.aspx?");
			}
			else if (e.CommandName == "Staff")
			{
				Session["COLPPP"]="frmProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProjPeople.aspx?");
			}
			else if (e.CommandName == "Services")
			{
				Session["CPSer"]="frmProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=0;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcSer.aspx?");
			}
			else if (e.CommandName == "Other")
			{
				Session["CPSer"]="frmProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=1;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcSer.aspx?");
			}*/
			else if (e.CommandName == "Delete")
			{
				try
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_DeleteProject";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id",SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					loadData();
				}
				catch (SqlException err)
				{
					if (err.Message.StartsWith ("DELETE statement conflicted")) 
						lblContent1.Text = "Sorry.  This project is being referred to elsewhere in the system."
							+ " All references must be reviewed and, if appropriate, deleted before you may"
							+ " delete this project.";
					else lblContent1.Text = err.Message;
				}
			}
				/*Session["CPStaff"]="frmProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmProjectStaff.aspx?");
			}
			else if (e.CommandName == "Services")
			{
				Session["CPSer"]="frmOrgLocSEProcs";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=0;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcSer.aspx?");
			}
			else if (e.CommandName == "Resources")
			{
				Session["CPRes"]="frmOrgLocSEProcs";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Session["SGFlag"]=1;
				Response.Redirect (strURL + "frmProcRes.aspx?");
			}
			else */
		}

	}
}

