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
	public partial class frmPSEPAll : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Procedures();
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
		private void Load_Procedures()
		{	
			lblContents1.Text="Listed below are the various processes that are undertaken"
				+ " by organizations forming part of profile '" 
				+ Session["ProfilesName"].ToString() + "'";
			lblContents2.Text="Select all those processes that are applied to the project type "
				+ Session["Nameshort"].ToString();
			lblContents3.Text="";
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrievePSEPAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
			cmd.Parameters["@ProfileId"].Value=Session["ProfilesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSEProcs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{
			updateGrid();
			Response.Redirect (strURL + Session["CPSEPAll"].ToString() + ".aspx?");
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_RetrievePSEPProj";
				cmd.Parameters.Add("@ProjTypesId", SqlDbType.Int);
				cmd.Parameters ["@ProjTypesId"].Value=Int32.Parse(Session["ProjTypesId"].ToString());
				cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
				cmd.Parameters["@ProfileId"].Value=Session["ProfilesId"].ToString();
				cmd.Parameters.Add("@PSEPId", SqlDbType.Int);
				cmd.Parameters ["@PSEPId"].Value=Int32.Parse(i.Cells[0].Text);
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
					cb.Enabled = false;
					lblContents2.Text="Note that project types with check marks already"
						+ " present (in shaded boxes) have already been identified for this profile.";
				}
				cmd.Connection.Close();
			}
		}
		private void updateGrid()
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
					cmd.CommandText="wms_AddProjectTypesPSEP";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
					cmd.Parameters["@ProfileId"].Value=Session["ProfilesId"].ToString();
					cmd.Parameters.Add("@ProjTypesId", SqlDbType.Int);
					cmd.Parameters ["@ProjTypesId"].Value=Int32.Parse(Session["ProjTypesId"].ToString());
					cmd.Parameters.Add("@PSEPId", SqlDbType.Int);
					cmd.Parameters ["@PSEPId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
				}
			}
		}
	}

}
	