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
	public partial class frmBudOrgsWP : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
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
			lblOrg.Text=Session["OrgName"].ToString();
			if (!IsPostBack) 
			{	
				loadData();
			} 
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveBudOrgsWP";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BudOrgs");
			if (ds.Tables["BudOrgs"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="Sorry.  There is no budget identified for this organization."
					+ " Please contact your System or Budget Administrator."; 
			}
			else 
			{
				lblContents.Text="Click on 'Select' to identify the budget that will"
					+ " finance the staff and other resources you will be assigning"
					+ " to various tasks";
				if (ds.Tables["BudOrgs"].Rows.Count == 1)
				{
					Session["BOId"]=ds.Tables["BudOrgs"].Rows[0][0].ToString();
					Session["BProv"]=ds.Tables["BudOrgs"].Rows[0][1].ToString();
					Session["BudName"]=ds.Tables["BudOrgs"].Rows[0][2].ToString();
					Session["CurrName"]=ds.Tables["BudOrgs"].Rows[0][3].ToString();
					Session["BudgetsId"]=ds.Tables["BudOrgs"].Rows[0][6].ToString();
					setControls();
					if (Session["CBudOrgs"].ToString() == "frmMainWP")
					{
						Session["COrgLocs"]="frmMainWP";
						Response.Redirect (strURL + "frmOrgLocations.aspx?");
					}
					else if (Session["CBudOrgs"].ToString() == "frmTasks")
					{
						if (Session["BudChange"] != null)
						{
							Session["BudChange"] = null;
							Response.Redirect (strURL + "frmTasks.aspx?");
						}
						else
						{
							if (Session["SGFlag"] == null)
							{
								Session["CPStaff"]="frmTasks";
								Response.Redirect (strURL + "frmProcStaff.aspx?");
							}
							else
							{	
								Session["CPSer"]="frmTasks";
								Response.Redirect (strURL + "frmProcRes.aspx?");
							}
						}
					}
				}
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				Session["BudgetsId"]  = e.Item.Cells[5].Text;
				setControls();
				Session["BOId"]=e.Item.Cells[0].Text;
				Session["BProv"]=e.Item.Cells[1].Text;
				Session["BudName"]=e.Item.Cells[2].Text;
				Session["CurrName"]=e.Item.Cells[3].Text;
				if (Session["CBudOrgs"].ToString() == "frmMainWP")
				{
					Session["COrgLocs"]="frmBudOrgsWP";
					Response.Redirect (strURL + "frmOrgLocations.aspx?");
				}
                else if (Session["CBudOrgs"].ToString() == "frmMainMgr")
                {
                    Session["COrgLocs"] = "frmBudOrgsWP";
                    Response.Redirect(strURL + "frmOrgLocations.aspx?");
                }
				else if (Session["CBudOrgs"].ToString() == "frmTasks")
				{
				if (Session["BudChange"] != null)
					{
						Session["BudChange"] = null;
						Response.Redirect (strURL + "frmTasks.aspx?");
					}
					else
					{
						if (Session["SGFlag"] == null)
						{
							Session["CPStaff"]="frmTasks";
							Response.Redirect (strURL + "frmProcStaff.aspx?");
						}
						else
						{	
							Session["CPSer"]="frmTasks";
							Response.Redirect (strURL + "frmProcRes.aspx?");
						}
					}
				}
			}
		}
		private void setControls()
		{
			SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="ams_RetrieveBudFlagsPAY";
				cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
				cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter (cmd);
				da.Fill(ds,"PAY");
				if (ds.Tables["PAY"].Rows[0][0].ToString() == "0")
				{
					Session["PAY"]= 0;
				}
				else
				{
					Session["PAY"]= 1;
				}
			/*if (Session["startForm"].ToString() == "frmMainOrgLocInd")
			{
				Session["BudgetsId"]=null;
			}*/
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{

			Response.Redirect (strURL + Session["CBudOrgs"].ToString() + ".aspx?");
		}

}

}
	