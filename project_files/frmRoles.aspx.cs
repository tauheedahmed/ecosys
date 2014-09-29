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
	public partial class frmRoles : System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.deleteRow);

		}
		#endregion
		private void Load_Procedures()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents.Text="Types of Human Resources";
			if (!IsPostBack) 
			{	
				loadData();
			}
		}

		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveRoles";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Visibility",SqlDbType.NVarChar);
			cmd.Parameters["@Visibility"].Value="No";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Roles");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		private void deleteRow(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/*Add Try/Catch on:
			 * DELETE statement conflicted with COLUMN REFERENCE constraint 'FK_EventOrgs_Events'. 
			 * The conflict occurred in database 'EPS1', table 'EventOrgs', column 'EventId'.
			 * */
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteRole";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);			
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["Type"]="Role";
				Session["CallerUpdRole"]="frmRoles";
				Response.Redirect (strURL + "frmUpdRole.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Type=" + e.Item.Cells[3].Text
					+ "&ParentId=" + e.Item.Cells[4].Text);
			}
			else if (e.CommandName == "Skills")
			{

				Session["CallerRoleSkills"] = "frmRoles";
				Session["RoleId"] = e.Item.Cells[0].Text;
				Session["RoleName"] =  e.Item.Cells[1].Text; 
				Response.Redirect (strURL + "frmRoleSkills.aspx?");
			}

		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
				Session["Type"]="Role";
				Session["CallerUpdRole"]="frmRoles";
				Response.Redirect (strURL + "frmUpdRole.aspx?"
				+ "&btnAction=" + "Add");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerRoles"].ToString() + ".aspx?");
		}



	}

}
	