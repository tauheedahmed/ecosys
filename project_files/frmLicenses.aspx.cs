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
	public partial class frmLicenses : System.Web.UI.Page
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
			lblOrg.Text=Session["OrgName"].ToString() ;
			lblContents.Text="List of Licenses";
			if (!IsPostBack) 
			{	
				loadData();
			}
		}

		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveLicenses";
			if (Convert.ToInt32(Request.Params["ActId"]) != 0)
			{
				cmd.Parameters.Add ("@ActId",SqlDbType.Int);
				cmd.Parameters["@ActId"].Value=Request.Params["ActId"].ToString();
			}
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"licenses");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
				{
					Button bn = (Button) (i.Cells[5].FindControl("btnUpdate"));
					if (i.Cells[3].Text == "Activate")
					{
						bn.BackColor=Color.Red;
						bn.ForeColor=Color.White;
						bn.Text="Activate";
					}
				}
		}

		private void deleteRow(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/*Add Try/Catch on:
			 * DELETE statement conflicted with COLUMN REFERENCE constraint 'FK_EventOrgs_Events'. 
			 * The conflict occurred in database 'EPS1', table 'EventOrgs', column 'EventId'.
			 * */
			/*SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteLicenseId";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();*/
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				if (e.Item.Cells[3].Text == "Activate")
				{
					Session["ClientOrgId"]=e.Item.Cells[6].Text;
					Session["ClientLicenseId"]=e.Item.Cells[0].Text;
					Session["ClientLicDate"]=e.Item.Cells[2].Text;
					Session["ClientLicHolder"]=e.Item.Cells[1].Text;
					Session["ClientLicStatus"]=e.Item.Cells[3].Text;
					Session["ClientDomainId"]=e.Item.Cells[4].Text;
					Session["ClientProfileId"]=e.Item.Cells[9].Text;
					updateLicenseStatus();
					Session["ClientLicStatus"]="Active";
					Session["ClientLicVis"]=3;
					updateOrganization();
					updatePeople();
					issueSecurityUserId();		
					Response.Redirect (strURL + "frmLicenseUsers.aspx?");
				}
				else
				{
					Session["ClientOrgId"]=e.Item.Cells[6].Text;
					Session["ClientLicenseId"]=e.Item.Cells[0].Text;
					Session["ClientLicDate"]=e.Item.Cells[2].Text;
					Session["ClientLicHolder"]=e.Item.Cells[1].Text;
					Session["ClientLicStatus"]=e.Item.Cells[3].Text;
					Session["ClientDomainId"]=e.Item.Cells[4].Text;
					Session["ClientProfileId"]=e.Item.Cells[9].Text;
					Session["ClientLicVis"]=e.Item.Cells[7].Text;
					Response.Redirect (strURL + "frmLicenseUsers.aspx?");			
				}
			}
			else if (e.CommandName == "Msg")
			{
				Session["CallerSendMail"]="frmLicenses";
				Response.Redirect (strURL + "frmSendMail.aspx?"
					+ "&Mailtype=Single"
					+ "&SenderName=" + Session["OrgName"].ToString()
					+ "&SenderEmail=" + Session["Email"].ToString()
					+ "&RecipientName=" + e.Item.Cells[3].Text
					+ "&RecipientEmail=" + e.Item.Cells[8].Text
					);
			}
			else if (e.CommandName == "Organizations")
			{
				Session["CLO"]="frmLicenses";
				Session["ClientLicenseId"]=e.Item.Cells[0].Text;
                Session["ClientLicenseName"] = e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmLicenseOrgs.aspx?");
			}
		}
		private void updateLicenseStatus()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "Update Licenses"
				+ " Set LicenseStatus='Active' "
				+ " ,Visibility=3"
				+ " Where Licenses.Id = " +  Session["ClientLicenseId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

		}
		private void updateOrganization()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "Update Organizations"
				+ " Set LicenseId= " +  Session["ClientLicenseId"].ToString()
				+ ", ParentOrg = " + Session["ClientOrgId"].ToString()
				+ ", Visibility=3"
				+ " Where Organizations.Id = " +  Session["ClientOrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void updatePeople()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "eps_UpdPeopleLic";
			cmd.Parameters.Add ("@ClientOrgId",SqlDbType.Int);
			cmd.Parameters["@ClientOrgId"].Value=Session["ClientOrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void issueSecurityUserId()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "eps_UpdUserIdsLic";
			cmd.Parameters.Add ("@UserId",SqlDbType.NVarChar);
			cmd.Parameters["@UserId"].Value=Session["ClientLicenseId"].ToString();
			cmd.Parameters.Add ("@ClientOrgId",SqlDbType.Int);
			cmd.Parameters["@ClientOrgId"].Value=Session["ClientOrgId"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["startForm"].ToString() + ".aspx?");
		}

	}

}
	