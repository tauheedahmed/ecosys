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
	public partial class frmOwnStaffSkillsAll: System.Web.UI.Page
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
			Load_Form();
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
		private void Load_Form()
		{			
			if (!IsPostBack)
			{	loadRoles();
				lblStep1.Text="Step 1:  Select Skill Needed";
				lblStep2.Text="Step 2:  Click Button to List Available People with Matching Skills:";
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text="Skills Search";
			}
		}
		private void loadRoles() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Roles.Id, Roles.Name from Roles inner join Organizations"
				+ " on Roles.OrgId=Organizations.Id"
				+ " inner join Licenses on Organizations.LicenseId=Licenses.Id"
				+ " Where Roles.Visibility='1'"
				+ " or (Roles.Visibility='3' and Organizations.LicenseId=" 
				+ "'" + Session["LicenseId"].ToString() + "')"
				+ " Order by Roles.Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Roles");
			lstRoles.DataSource = ds;			
			lstRoles.DataMember= "Roles";
			lstRoles.DataTextField = "Name";
			lstRoles.DataValueField = "Id";
			lstRoles.DataBind();
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerSSA"].ToString() + ".aspx?");
		}

		protected void btnOwn_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_RetrievePeopleRoleMatch";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
						cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
						cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
						cmd.Parameters["@RoleId"].Value=lstRoles.SelectedItem.Value;
						DataSet ds=new DataSet();
						SqlDataAdapter da=new SqlDataAdapter(cmd);
						da.Fill(ds,"StaffAll");
						Session["ds"] = ds;
						DataGrid1.DataSource=ds;
						DataGrid1.DataBind();
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName.ToString() == "Select")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddStaffing";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
				cmd.Parameters["@RoleId"].Value= lstRoles.SelectedItem.Value;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= "";
				cmd.Parameters.Add ("@PeopleId", SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value=e.Item.Cells[0].Text;
				cmd.Parameters.Add ("@OrgId", SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgIdt"];
				cmd.Parameters.Add ("@CallerId", SqlDbType.Int);
				cmd.Parameters["@CallerId"].Value=0;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				btnOK_Click();
				
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerSSA"].ToString() + ".aspx?");
		}

		protected void btnDomain_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrievePeopleRoleMatchD";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
			cmd.Parameters["@RoleId"].Value=lstRoles.SelectedItem.Value;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		protected void btnOK_Click()
		{
		
		}


	}

}

