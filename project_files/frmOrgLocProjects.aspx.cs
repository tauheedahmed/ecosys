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
	public partial class frmOrgLocProjects : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button btnAddTemp;
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

			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
					+ Session["CurrName"].ToString();
				lblContents1.Text="Given below is a list of different types of deliverables from the above organization"
					+ " from the above location.  Click on the 'Deliverables' button to get a list of tasks"
					+ " that are performed to deliver a given service.";
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveOrgLocationsInd";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Locs");
			if (ds.Tables["Locs"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.ForeColor=System.Drawing.Color.Maroon;
				lblContents1.Text="Sorry.  There are no existing deliverables identified for this profile."
					+ " Press 'Signoff' and contact your system administrator.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
	}
		
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				try
				{
					Session["CPSEInd"]="frmMainOrgLocInd";
					Session["OrgLocId"]=e.Item.Cells[0].Text;
					Session["MgrName"]=e.Item.Cells[1].Text;
					Session["LocationName"]=e.Item.Cells[2].Text;
					Session["ServiceName"]=e.Item.Cells[3].Text;
					Session["EventName"]=e.Item.Cells[4].Text;
					Session["ProfileId"]=e.Item.Cells[6].Text;
					Session["PSEventsId"]=e.Item.Cells[7].Text;
					Session["PJName"]=e.Item.Cells[8].Text;
					Session["PJNameS"]=e.Item.Cells[9].Text;
					
					Response.Redirect (strURL + "frmPSEventsInd.aspx?");
					
				}
				catch (SqlException err)
				{
					if (err.Message.StartsWith ("Object reference not set")) 
						Response.Redirect (strURL + "frmStart.aspx?");
					else lblContents1.Text = err.Message;
				}			
			}
		}

	}

}
	