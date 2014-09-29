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
	public partial class frmPeopleRoles : System.Web.UI.Page
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
			this.dgdRoles.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents1.Text=Session["PName"].ToString();//Session["FName"].ToString() + " " + Session["LName"].ToString();
			lblContents2.Text="Organizational Roles";
			if (!IsPostBack) 
			{	
				loadRoles();
				if (Session["CallerPeopleRoles"].ToString() == "frmPeople")
				{
					btnAddR.Visible=false;
				}
			}
		}
		private void loadRoles ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrievePeopleRoles";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"PeopleSkills");
			Session["ds"] = ds;
			dgdRoles.DataSource=ds;
			dgdRoles.DataBind();
		}
		protected void btnAddRole_Click(object sender, System.EventArgs e)
		{
			Session["RoleType"]="Role";
			Response.Redirect (strURL + "frmRolesAllStaff.aspx?"
				+ "&PeopleId=" + Session["PeopleId"].ToString()
				+ "&PeopleName=" + Session["PName"].ToString());
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerPeopleRoles"].ToString() + ".aspx?");
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Skills")
			{
				Session["CallerRoleSkills"] = "frmPeopleRoles";
				Session["RoleId"] = e.Item.Cells[3].Text;
				Session["RoleType"]="Role";
				Session["RoleName"] =  e.Item.Cells[2].Text; 
				Response.Redirect (strURL + "frmRoleSkills.aspx?");
			}

		}
	}
}
	