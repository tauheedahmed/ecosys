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
using CrystalDecisions.Shared;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmOrgStaffTypesBudBud : System.Web.UI.Page
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

		}
		#endregion
		private void Load_Procedures()
		{
			DataGrid1.Visible=false;
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["BDOrgName"].ToString();
				lblContents.Text="Listed below are the various Appointment Types"
					+ " that may be made in this Organization.";
					/*+ " Click on 'Pay grades'"
					+ " to maintain pay grades for each Appointment Type.";*/
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrieveOrgStaffTypes";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["BDOrgId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffTypes");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Budget")
			{

				Session["CBudSerWS"]="frmOrgStaffTypesBud";
				Session["OrgSTId"]=e.Item.Cells[0].Text;
				Session["STName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmBudStaffWorkSheet.aspx?");
			}
			else if (e.CommandName == "ControlPos")
			{
				Session["CBudSer"]="frmOrgStaffTypesBud";
				Session["OrgSTId"]=e.Item.Cells[0].Text;
				Session["STName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmBudStaff.aspx?");
			}
			else if (e.CommandName == "Update")
			{
				Session["CUpdOST"]="frmOrgStaffTypesBud";
				Response.Redirect (strURL + "frmUpdOrgStaffTypes.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteEventId";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CAptTypes"].ToString() + ".aspx?");
		}
	}

}
	