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
	public partial class frmProjectsSelO: System.Web.UI.Page
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
			DataGrid1.Columns[1].HeaderText = Session["PJName"].ToString();
			if (!IsPostBack)
			{	
				
				lblOrg.Text="Managing Organization: " + Session["OrgName"].ToString();
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblContent1.Text="Listed below are " 
					+ Session["PJName"].ToString()
					+ " created at other locations and/or by other managers "
					+ " that may also be worked on at this location/manager."
					+ " Click on 'Select' to select a "
					+ Session["PJNameS"].ToString()
					+ " from this list.";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjectsO";
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add ("@PSEventsId",SqlDbType.Int);
			cmd.Parameters["@PSEventsId"].Value=Session["PSEventsId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
			Session["ds"] = ds;
			if (ds.Tables["Projects"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContent1.Text="No externally managed projects found.";
			}
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
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
					CheckBox cb = (CheckBox) (i.Cells[3].FindControl("cbxSel"));
					if (cb.Checked == true) 
					{
						if (cb.Enabled == true)
						{
							SqlCommand cmd=new SqlCommand();
							cmd.CommandType=CommandType.StoredProcedure;
							cmd.CommandText="wms_UpdateProjectsPeople";
							cmd.Connection=this.epsDbConn;
							cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
							cmd.Parameters ["@ProjectId"].Value=i.Cells[0].Text;
							cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
							cmd.Parameters ["@PeopleId"].Value=Session["PeopleId"].ToString();
							cmd.Connection.Open();
							cmd.ExecuteNonQuery();
							cmd.Connection.Close();
						}
					}
				}
		}*/
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bn = (Button)(i.Cells[5].FindControl("btnSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				/*cmd.CommandText="Select Id from ProjectsPeople"
							+ " Where ProjectsId = " + i.Cells[0].Text
							+ " and PeopleId = " + Session["PeopleId"].ToString();*/
                cmd.CommandText = "Select Id from ProjOrgLoc"
                            + " Where ProjectsId = " + i.Cells[0].Text
                            + " and OrgLocationsId = " + Session["OrgLocId"].ToString();
							
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					bn.Visible=false;
					i.Cells[5].Text="Already Selected";
				}
				cmd.Connection.Close();
			}
		}


		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSel"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			/*cmd.CommandText="wms_UpdateProjectsPeople";*/
            cmd.CommandText = "wms_AddProjOrgLoc";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
            cmd.Parameters["@ProjectId"].Value = e.Item.Cells[0].Text; ;
            cmd.Parameters.Add("@OrgLocationsId", SqlDbType.Int);
            cmd.Parameters["@OrgLocationsId"].Value = Session["OrgLocId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
            Exit();
		}

	}

}

