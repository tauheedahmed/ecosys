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
	public partial class frmProfProjectTypes: System.Web.UI.Page
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
			if (Session["CPPTypes"].ToString() == "frmProfiles")
			{
				lblContent1.Text="Select project types for profile '"
					+ Session["ProfilesName"].ToString()
					+ "'. You may identify project types not included in this list by clicking"
					+ " on the 'Add Project Types' button.";
				lblContent3.Text="Use the 'Remove' button to remove Project Types"
					+ " from this list.";
				btnAddAll.Visible=true;
				DataGrid1.Columns[2].Visible=false;
				DataGrid1.Columns[3].Visible=false;
				DataGrid1.Columns[4].Visible=false;
				DataGrid1.Columns[5].Visible=false;

			}
			else if (Session["CPPTypes"].ToString() == "frmMainStaff")
			{
				lblContent1.Text="Select the kind of task you wish to work with.";
				lblContent3.Text="";
				btnAddAll.Visible=false;
				DataGrid1.Columns[2].Visible=true;
				DataGrid1.Columns[3].Visible=false;
				DataGrid1.Columns[4].Visible=false;
			}

			if (!IsPostBack)
			{	
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProfProjTypes";
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProfilesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ST");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
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
				CheckBox cb = (CheckBox) (i.Cells[2].FindControl("cbxSel"));
				if ((cb.Checked == true) & (cb.Enabled==true))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_AddProjectTypesPSEP";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@ProjectTypesId", SqlDbType.Int);
					cmd.Parameters ["@ProjectTypesId"].Value=i.Cells[0].Text;
					cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
					cmd.Parameters ["@ProfilesId"].Value=Session["ProfilesId"].ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}*/
		
		protected void btnAddAll_Click(object sender, System.EventArgs e)
		{
			Session["CProjectTypes"]="frmProfProjectTypes";	
			Response.Redirect (strURL + "frmProjectTypes.aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdProjectTypes"]="frmProfProjectTypes";	
				Response.Redirect (strURL + "frmUpdProjectType.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[8].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Nameshort=" + e.Item.Cells[2].Text
					+ "&Seq=" + e.Item.Cells[3].Text
					+ "&Vis=" + e.Item.Cells[4].Text
					);
			}
			if (e.CommandName == "Procs")
			{
				Session["CPSEPPT"]="frmProfProjectTypes";
				Session["ProjTypesId"]=e.Item.Cells[8].Text;
				Session["Nameshort"]=e.Item.Cells[2].Text;
				Response.Redirect (strURL + "frmPSEPProjectTypes.aspx?");
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteProfProjectTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPPTypes"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		/*private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					Button btu = (Button)(i.Cells[3].FindControl("btnUpdate"));
					Button bt = (Button)(i.Cells[4].FindControl("btnDelete"));
					SqlCommand cmd=new SqlCommand();
					cmd.Connection=this.epsDbConn;
					cmd.CommandType=CommandType.Text;
					cmd.CommandText="Select Id from ProfileProjectTypes"
						+ " Where ProjectTypesId = " + i.Cells[0].Text
						+ " and ProfilesId = " + Session["ProfilesId"].ToString();
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked = true;
						cb.Enabled = false;
						bt.Visible=false;
						i.Cells[4].Text = "In Use";
						lblContent2.Text="Note that project types with check marks already"
							+ " present (in shaded boxes) have already been identified for this profile.";
					}
					cmd.CommandText="Select OrgId from ProjectTypes"
						+ " Where Id = " + i.Cells[0].Text;
						//+ " and OrgId = " + Session["OrgId"].ToString();
					if (cmd.ExecuteScalar().ToString() != Session["OrgId"].ToString())
					{
						bt.Visible=false;
						btu.Visible=false;
						i.Cells[4].Text = "  Externally Created  ";
					}
					if (bt.Visible)
					{
						lblContent3.Visible=true;
					}

					cmd.Connection.Close();
				}
		}*/

	}

}

