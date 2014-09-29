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
	public partial class frmProjPeopleAdd: System.Web.UI.Page
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

		}
		#endregion
		private void loadForm()
		{
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				loadData();	
			}
		}
		
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjPeopleAdd";		
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"RoleStaff");
			if (ds.Tables["RoleStaff"].Rows.Count == 0)
			{
				lblContents1.Text="There are no staff currently assigned to carry out the process '"
					+ Session["ProcName"].ToString()
					+ "'.  Click on 'Add' to assign individuals to this process first.  Once you have done that"
					+ " you will be returned to this page and will be able to then assign individuals for this particular "
					+ Session["ProjTypeNameS"].ToString() 
					+ ", i.e. '" + Session["ProjName"].ToString() + "'";
			}
			else
			{
				lblContents1.Text="The list below identifies individuals who are assigned  to play various roles"
					+ " in individual " + Session["ProjTypeName"].ToString()
					+ ". You may now identify individuals for this particular"
					+ Session["ProjTypeNameS"].ToString() 
					+ ", i.e. '" + Session["ProjName"].ToString() + "' by placing a checkmark against them."
					+ " To add an individual whom you wish to include in the team, click on 'Add'";
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
					CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.Connection=this.epsDbConn;
					cmd.CommandText="wms_RetrieveOLPPPAddR";		
					cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
					cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
					cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
					cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
					cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
					cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
					cmd.Parameters.Add ("@StaffingType",SqlDbType.VarChar);
					cmd.Parameters["@StaffingType"].Value="Staff";
					cmd.Parameters.Add ("@ProcSARsId",SqlDbType.Int);
					cmd.Parameters["@ProcSARsId"].Value=i.Cells[0].Text;
					/*DataSet ds=new DataSet();
					SqlDataAdapter da=new SqlDataAdapter(cmd);
					da.Fill(ds,"RoleStaff");
					if (ds.Tables["RoleStaff"].Rows.Count == 0)*/
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
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxSel"));	
				if (cb.Checked)
				{
					if (cb.Enabled)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.Connection=this.epsDbConn;
						cmd.CommandType=CommandType.Text;
						cmd.CommandText="Insert into OLPPPeople"
							+ " (ProcSARsId, ProjectId)" 
							+ " Values("
							+ i.Cells[0].Text
							+ "," 
							+ Session["ProjectId"].ToString()
							+ ")";
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
				
			}
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CProjPeopleAdd"].ToString() + ".aspx?");
		}


		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}

}

