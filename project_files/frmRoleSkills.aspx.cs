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
	public partial class frmRoleSkills : System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents1.Text="Role: " + Session["RoleName"].ToString();
			lblContents2.Text="Relevant Skills";
			if (!IsPostBack) 
			{	
				if (Session["startForm"].ToString() == "frmMainTrg")
				{
					btnAdd.Visible=true;
				}
				else if (Session["CallerRolesAll"].ToString() == "frmProfileSEPSStaff")
				{
					btnAdd.Visible=true;
				}
				else
				{
					btnAdd.Visible=false;
				}
              loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveRoleSkills";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
			cmd.Parameters["@RoleId"].Value=Session["RoleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"RoleSkills");
			Session["ds"] = ds;
			if (ds.Tables["RoleSkills"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.Text="Sorry.  There are no skills identified for this role in the system";
			}
			else
			{
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
				Session["CallerSkillsAll"]="frmRoleSkills";
				Response.Redirect (strURL + "frmSkillsAll.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerRoleSkills"].ToString() + ".aspx?");
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/*
			Session["SkillName"]=e.Item.Cells[1].Text;
			Session["SkillId"]=e.Item.Cells[2].Text;
			Session["CallerSkillCourses"]="frmRoleSkills";
			Response.Redirect (strURL + "frmSkillCourses.aspx?");*/
		}

	}

}
	