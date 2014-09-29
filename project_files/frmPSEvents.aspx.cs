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
	/// Summary description for frmOrgResTypes1.
	/// </summary>
	public partial class frmPSEvents : System.Web.UI.Page
	{
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadForm()
		{			
			if (Session["MgrName"] != null)
			{
				lblOrg.Text=Session["MgrName"].ToString();
			}
			else
			{
				lblOrg.Text=Session["OrgName"].ToString();
			}
			DataGrid1.Columns[1].HeaderText = "Types of " + Session["PJName"].ToString();	
			if (!IsPostBack)
			{	
				lblLocation.Text="Location: " + Session["LocName"].ToString();
				/*lblBud.Text="Budget: " + Session["BudName"].ToString();*/
                lblService.Text = "Service: " + Session["ServiceName"].ToString();
				lblContents1.Text="The following types of " 
					+ Session["PJName"].ToString()
					+ " are related to this service. Click on 'Select' on at the appropriate row"
					+ " to continue";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveOLPSEvents";
			cmd.Parameters.Add ("@ProfileServicesId",SqlDbType.Int);
			cmd.Parameters["@ProfileServicesId"].Value=Int32.Parse(Session["ProfileServicesId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Events");
			if (ds.Tables["Events"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.Text="Sorry.  There are no kind of deliverables identified for this service."
					+ " Please contact your System Administrator.";
			}
            else if (ds.Tables["Events"].Rows.Count == 1)
            {
                Session["CProjects"] = "frmPSEvents";
                Session["EventName"] = ds.Tables["Events"].Rows[0][1].ToString();
                Session["PSEventsId"] = ds.Tables["Events"].Rows[0][0].ToString();
                Response.Redirect(strURL + "frmProjects.aspx?");		
            }
			else
			{
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				//refreshGrid();
			}
		}
		/*private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button cb = (Button)(i.Cells[2].FindControl("btnProjects"));
				cb.Text=Session["PJName"].ToString();
			}
		}*/
		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CPSE"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			if (e.CommandName == "Projects")
			{
				Session["CProjects"]="frmPSEvents";
				Session["EventName"]=e.Item.Cells[1].Text;
				Session["PSEventsId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmProjects.aspx?");					
			}		
		}
	}
}
