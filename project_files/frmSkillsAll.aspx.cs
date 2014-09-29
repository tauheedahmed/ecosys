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
	public partial class frmSkillsAll: System.Web.UI.Page
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

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text=Session["RoleName"].ToString();
				lblContent2.Text="Select Skills from List Below";
				loadData();
			}
				
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveSkillsAll";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Skills");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{

			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteRoleSkills";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
			cmd.Parameters["@RoleId"].Value=Session["RoleId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox) (i.Cells[3].FindControl("cbxSel"));
					if (cb.Checked == true)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateRoleSkills";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@RoleId", SqlDbType.Int);
						cmd.Parameters ["@RoleId"].Value=Session["RoleId"].ToString();
						cmd.Parameters.Add("@SkillId", SqlDbType.Int);
						cmd.Parameters ["@SkillId"].Value=i.Cells[0].Text;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from RoleSkills"
							+ " Where SkillId = " + i.Cells[0].Text
							+ " and RoleId = " + Session["RoleId"].ToString();
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}
		}


		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerSkillsAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerSkillsAll"].ToString() + ".aspx?");
		}
	}

}

