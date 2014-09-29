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
	/// Summary description for frmOrgs.
	/// </summary>
	public partial class frmOrgs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string ParentId;
        
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Orgs();
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
		private void Load_Orgs()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
		
			if (!IsPostBack) 
			{
				ParentId=Session["OrgId"].ToString();
				if (Session["CallerOrgs"].ToString() == "frmMainHost")
				{
					DataGrid1.Columns[11].Visible=true;
				}
				else
				{
					DataGrid1.Columns[11].Visible=false;
				}

				if (Session["CallerOrgs"].ToString() == "frmMainHost")
				{
					lblContents.Text="New License Requests";
				}
	
                else if (Session["OrgType"].ToString() == "Team")
				{
					lblContents.Text="Organizing:  Formal and Informal Groups";
				}
				else if (Session["OrgType"].ToString() == "Group")
				{	
					lblContents.Text="External Groups: Clients and Suppliers";
				}
				else if (Session["OrgType"].ToString() == "Household")
				{	
					lblContents.Text="Households";
				}
				else 
				{	
					lblContents.Text="All Units, Teams and Other Groups";
				}
				loadData();	
				setGrid();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveOrgs";
			if (Session["CallerOrgs"].ToString() == "frmLocs")
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
				cmd.Parameters["@OrgType"].Value=Session["OrgType"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="Locs";
			}

			else if (Session["CallerOrgs"].ToString() == "frmMainOrgs")
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
				cmd.Parameters["@OrgType"].Value=Session["OrgType"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="Orgs";
			}
			else if (Session["startForm"].ToString() == "frmMainCoop")
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
				cmd.Parameters["@OrgType"].Value=Session["OrgType"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="Orgs";
			}
			
			else if (Session["CallerOrgs"].ToString() == "frmMainHost")
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="Host";
			}

			cmd.Connection=this.epsDbConn;	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Orgs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		
		private void setGrid()
		{
			if (Session["OrgType"].ToString() == "Group")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					Button bt = (Button) (i.Cells[8].FindControl("btnStaff"));
					Button bts = (Button) (i.Cells[8].FindControl("btnServices"));
					Button btu = (Button) (i.Cells[8].FindControl("btnUserIds"));
					bt.Text="Members";
					bts.Visible=false;
					btu.Visible=false;
					DataGrid1.Width=720;
				}
			}
			else if (Session["OrgType"].ToString() == "Household")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					Button bt = (Button) (i.Cells[8].FindControl("btnStaff"));
					Button bts = (Button) (i.Cells[8].FindControl("btnServices"));
					Button btu = (Button) (i.Cells[8].FindControl("btnUserIds"));
					bt.Visible=false;
					bts.Visible=false;
					btu.Visible=false;
				}
			}
			else// i.e. if (Session["OrgType"].ToString() == "Organization")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					Button btu = (Button) (i.Cells[8].FindControl("btnUserIds"));
					btu.Visible=false;
				}
			}
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Staffing")
			{
				Session["CallerStaffing"]="frmOrgs";
				Session["OrgIdt"]=e.Item.Cells[0].Text;
				Session["OrgNamet"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmStaffing.aspx?");
			}
			else if (e.CommandName == "UserIds")
			{
				Response.Redirect (strURL + "frmUserIds.aspx?");
			}

			else if (e.CommandName == "Update")
			{		
				Session["btnAction"]="Update";
				if (Session["startForm"].ToString() != "frmMainCoop")
				{
					Session["CallerUpdOrg"]="frmOrgs";
					
					Response.Redirect (strURL + "frmUpdOrg.aspx?"
						+ "&Name=" + e.Item.Cells[1].Text
						+ "&Id=" + e.Item.Cells[0].Text
						+ "&Desc=" + e.Item.Cells[2].Text
						+ "&Phone=" + e.Item.Cells[4].Text
						+ "&Email=" + e.Item.Cells[3].Text
						+ "&Addr=" + e.Item.Cells[5].Text
						+ "&PeopleId=" + e.Item.Cells[6].Text
						+ "&LocId=" + e.Item.Cells[7].Text
						+ "&Vis=" + e.Item.Cells[12].Text);
				}
				else
				{
					Session["CallerUpdOrgHousehold"]="frmOrgs";
					Response.Redirect (strURL + "frmUpdOrgHousehold.aspx?"
						+ "&Name=" + e.Item.Cells[1].Text
						+ "&Id=" + e.Item.Cells[0].Text
						+ "&Desc=" + e.Item.Cells[2].Text
						+ "&Phone=" + e.Item.Cells[4].Text
						+ "&Email=" + e.Item.Cells[3].Text
						+ "&Addr=" + e.Item.Cells[5].Text
						+ "&PeopleId=" + e.Item.Cells[6].Text);
				}
			}
			else if (e.CommandName == "Services")
			{				
				Session["CallerServices"]="frmOrgs";
				Session["OrgIdt"]=e.Item.Cells[0].Text;
				Session["OrgNamet"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmServices.aspx?");
			}
			else if (e.CommandName == "Msg")
			{		
				Session["CallerSendMail"]="frmOrgs";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[1].Text
					+ "&RecipientEmail=" + e.Item.Cells[3].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteOrg";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "License")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;			
				cmd.CommandText="Insert into Licenses"
					+ "(OrgId, LicenseStatus) Values"
					+ "('" + e.Item.Cells[0].Text + "'"
					+ ",'Activate'"
					+ ")";
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				cmd.CommandText="Update Organizations"
					+ " Set Status='Existing'"
					+ " Where Id =" + "'" + e.Item.Cells[0].Text + "'";
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Response.Redirect (strURL + "frmLicenses.aspx?");
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (Session["startForm"].ToString() != "frmMainCoop")
			{
				Session["CallerUpdOrg"]="frmOrgs";
				Session["btnAction"]="Add";
				Response.Redirect (strURL + "frmUpdOrg.aspx?"
					+ "&Parent=" + ParentId);
			}
			else
			{
				Session["CallerUpdOrgHousehold"]="frmOrgs";
				Session["btnAction"]="Add";
				Response.Redirect (strURL + "frmUpdOrgHousehold.aspx?"
					+ "&Parent=" + ParentId);
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Session.Remove("btnAction");
			Session.Remove("CallerSendMail");
			Response.Redirect (strURL + Session["CallerOrgs"].ToString() + ".aspx?");
		}

		protected void btnallMsg_Click(object sender, System.EventArgs e)
		{
			Session["CallerSendMail"]="frmOrgs";
			Response.Redirect (strURL + "frmSendMail.aspx?"
				+ "&Mailtype=Multiple"
				+ "&SenderName=" + Session["OrgName"].ToString()
				+ "&SenderEmail=" + Session["Email"].ToString()
				);
		}

		protected void btnAddTemp_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
