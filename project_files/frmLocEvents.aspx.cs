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
	public partial class frmLocEvents : System.Web.UI.Page
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
			lblContent1.Text="Listed below are various events that trigger"
				+ " delivery of the service titled '"
				+ Session["ServiceName"].ToString()
				+ "' for profile titled '"
				+ Session["ProfileName"].ToString()
				+ "'. Review the list below to ensure that it includes all such events."
				+ " Use the 'Add Events' button to add to the list as needed.";
			
			lblContent2.Text="Step 6:  Identify the key steps taken in response to"
				+ " each event listed below"
				+ " by clicking on the"
				+ " pushbutton titled 'Response Steps' to the right of each given event.";
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProfileSEvents";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProfileServiceId",SqlDbType.Int);
			cmd.Parameters["@ProfileServiceId"].Value=Session["ProfileServicesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSProcs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
				Session["CEventsAll"]="frmProfileServiceEvents";
				Response.Redirect (strURL + "frmEventsAll.aspx?");
		}		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSEvents"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Steps")
			{
			Session["ProfileSEventsId"]=e.Item.Cells[0].Text;
			Session["EventName"]=e.Item.Cells[2].Text;
			Session["CPSESteps"]="frmProfileServiceEvents";
			Response.Redirect (strURL + "frmProfileSEventSteps.aspx?");
			}
			else if (e.CommandName == "Remove")
			{

				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileServiceEvents";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Staff")
			{
				Session["ProfileSPId"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[2].Text;
				Session["CSPStaff"]="frmProfileServiceProcs";
				Session["StaffingType"]="Staff";
				Response.Redirect (strURL + "frmProfileSPStaff.aspx?");
			}
			else if (e.CommandName == "Clients")
			{
				Session["ProfileSPId"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[2].Text;
				Session["CSPStaff"]="frmProfileServiceProcs";
				Session["StaffingType"]="Clients";
				Response.Redirect (strURL + "frmProfileSPStaff.aspx?");
			}
			else if (e.CommandName == "Resources")
			{
				Session["ProfileSPId"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[2].Text;
				Session["CSPResTypes"]="frmProfileServiceProcs";
				Response.Redirect (strURL + "frmProfileSPResTypes.aspx?");
			}
			else if (e.CommandName == "Contacts")
			{
				Session["ProfileSPId"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[2].Text;
				Session["CSPC"]="frmProfileServiceProcs";
				Response.Redirect (strURL + "frmProfileSPC.aspx?");
			}
		}

	}

}