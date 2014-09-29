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
	public partial class frmSkillResources : System.Web.UI.Page
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
			lblContents1.Text="Skill: " + Session["SkillName"].ToString();
			lblContents2.Text="Relevant Courses";
			DataGrid1.Columns[10].Visible=false;
			if (Session["startForm"].ToString() == "frmMainTrg")
			{
				btnAdd.Visible=true;
				DataGrid1.Columns[10].Visible=false;
			}
			else
			{
				btnAdd.Visible=false;
			}
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveSkillCourses";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@SkillId",SqlDbType.Int);
			cmd.Parameters["@SkillId"].Value=Session["SkillId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SkillCourses");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshData();
		}
		private void refreshData()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				if (Session["LicenseId"].ToString() == i.Cells[5].Text)
				{
					i.Cells[3].Text = i.Cells[7].Text;
				}
				else
				{
					i.Cells[3].Text = i.Cells[6].Text;
				}
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
				Session["ProjectTypesId"]=3;
				Session["CallerServicesAll"]="frmSkillCourses";
				Response.Redirect (strURL + "frmProjects.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerSkillCourses"].ToString() + ".aspx?");
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Classes")
			{
				Session["CallerTasks"]="frmSkillCourses";
				Session["ServiceName"]=e.Item.Cells[4].Text;
				Session["ResourceId"]=e.Item.Cells[2].Text;
				Session["Mode"]="Actual";
				Response.Redirect (strURL + "frmTasks.aspx?");
			}
		}

	}

}
	