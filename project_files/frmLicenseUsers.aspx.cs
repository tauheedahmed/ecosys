using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmLicenseUsers : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.Label lblComment1;
		private int GetIndexStatus (string item)
		{
				if (item.Trim() == "Active")
				{
					return 1;
				}
				else if (item.Trim() == "Activate")
				{
					return 2;
				}
				else
				{
					return 0;
				}
		}
		private int GetIndexDomain (string s)
		{
			return (lstDomain.Items.IndexOf (lstDomain.Items.FindByValue(s)));
		}
		private int GetIndexVis (string s)
		{
			return (rblVis.Items.IndexOf (rblVis.Items.FindByValue(s)));
		}
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{		
				loadDomains();
				loadVisibility();
				if (Session["startForm"].ToString() == "frmMainHost")
				{
					Session["LicenseIdT"]=Session["ClientLicenseId"];
					lblOrg.Text="License No: " + Session["ClientLicenseId"].ToString()
						+ " (" + Session["ClientLicHolder"].ToString() + ")";
					lstLicStatus.SelectedIndex=GetIndexStatus(Session["ClientLicStatus"].ToString());
					lstDomain.SelectedIndex=GetIndexDomain(Session["ClientDomainId"].ToString());
					
					rblVis.SelectedIndex=GetIndexDomain(Session["ClientLicVis"].ToString());
					DataGrid1.Columns[4].Visible=false;
					if (Session["ClientLicDate"].ToString().StartsWith("&"))
					{
						txtLicDate.Text=System.DateTime.Today.ToShortDateString();
					}
					else 
					{
						txtLicDate.Text=Session["ClientLicDate"].ToString();
					}
				}
				else
				{
					
					Session["LicenseIdT"]=Session["LicenseId"];
					lblOrg.Text=Session["OrgName"].ToString();
					lstLicStatus.Visible=false;
					lblLicStatus.Visible=false;
					lstDomain.SelectedIndex=GetIndexDomain(Session["DomainId"].ToString());
					lstDomain.Enabled=false;
					txtLicDate.Visible=false;
					lblLicDate.Visible=false;
					rblVis.Visible=false;
					lblVis.Visible=false;
				}
				loadData();
			}
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
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveUserTypes";
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"UserTypes");
			Session["ds"] = ds;
            DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
			refreshCount();
		}
		private void loadDomains() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Domains Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Domains");
			lstDomain.DataSource = ds;
			lstDomain.DataMember = "Domains";
			lstDomain.DataTextField = "Name";
			lstDomain.DataValueField = "Id";
			lstDomain.DataBind();
		}
		
		private void loadVisibility() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Visibility "
				+ " Order by Id";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			rblVis.DataSource = ds;
			rblVis.DataMember = "Visibility";
			rblVis.DataTextField = "Name";
			rblVis.DataValueField = "Id";
			rblVis.DataBind();
		}

		private void refreshGrid()
		{			
			if (Session["startForm"].ToString() == "frmMainHost")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					//Button bna = (Button) (i.Cells[4].FindControl ("btnAdd"));
					//bna.Visible=false;
					TextBox tb = (TextBox) (i.Cells[2].FindControl("txtMax"));					
					Object tmp1 = new object();				
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = this.epsDbConn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "Select UserTypeMax from LicenseUserTypes"
						+ " Where LicenseId = " + Session["LicenseIdT"].ToString()
						+ " and UserTypeId = " + i.Cells[0].Text;
					cmd.Connection.Open();
					tmp1 = cmd.ExecuteScalar();
					if (tmp1 != null) tb.Text = tmp1.ToString();
					if (tb.Text == "0") tb.Text = "";
					cmd.Connection.Close();
				}
			}
			else if ((Session["startForm"].ToString() == "frmMainSec")||
                (Session["startForm"].ToString() == "frmMainMgr"))
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tb = (TextBox) (i.Cells[2].FindControl("txtMax"));
					tb.ReadOnly=true;
					Object tmp2 = new object();
				
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = this.epsDbConn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "Select UserTypeMax from LicenseUserTypes"
						+ " Where LicenseId = " + Session["LicenseIdT"].ToString()
						+ " and UserTypeId = " + i.Cells[0].Text;
					cmd.Connection.Open();
					tmp2 = cmd.ExecuteScalar();
					if (tmp2 != null) tb.Text = tmp2.ToString();
					if (tb.Text == "0") tb.Text = "";
					//i.Cells[2].Text = "x";// + tb.Text;
					//if (tmp2 != null) i.Cells[2].Text = tmp2.ToString();
					//if (i.Cells[2].Text == "0") i.Cells[2].Text = "";			
					cmd.Connection.Close();
				}
			}
		}
		private void refreshCount()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Object tmp = new object();
				
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select Count(UserIds.Id) from UserIds"
					+ " inner join Organizations on UserIds.OrgId=Organizations.Id"
					+ " Where LicenseId = " + Session["LicenseIdT"].ToString()
					+ " and UserIds.Type = " + i.Cells[0].Text;
				cmd.Connection.Open();
				tmp = cmd.ExecuteScalar();
				if (tmp != null) i.Cells[3].Text=tmp.ToString();
				cmd.Connection.Close();
				
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtMax"));
				Button bna = (Button) (i.Cells[4].FindControl("btnAdd"));
				Button bnu = (Button) (i.Cells[4].FindControl("btnUpdate"));
				
				if (String.Compare (i.Cells[3].Text, i.Cells[2].Text) <= 0)
				{
					bna.Visible=false;
				}
				else if ((tb.Text == i.Cells[3].Text)
					||(tb.Text == ""))
				{
					bna.Visible=false;

				}
				if (i.Cells[3].Text == "0")
				{
					bnu.BackColor=Color.Transparent;
					bnu.BorderStyle=BorderStyle.None;
					bnu.ForeColor=Color.Transparent;
					bnu.Text="";
				}
			}
			
		}
		protected void updateForm(object sender, System.EventArgs e)

		{
			if (Session["startForm"].ToString() == "frmMainHost")
			{
			updateLicense();			
			deleteLicUserTypes();
			updateLicUserTypes();
			}
			endIt();
			
		}
		private void updateLicense()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateLicense";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseIdT"].ToString();
			cmd.Parameters.Add ("@Licdate",SqlDbType.DateTime);
			cmd.Parameters["@LicDate"].Value=txtLicDate.Text;
			cmd.Parameters.Add ("@LicStatus",SqlDbType.NVarChar);
			cmd.Parameters["@LicStatus"].Value=lstLicStatus.SelectedItem.Value;
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=lstDomain.SelectedItem.Value;
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=rblVis.SelectedItem.Value;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void deleteLicUserTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteLicenseUserTypes";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseIdT"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
			private void updateLicUserTypes()
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tb = (TextBox) (i.Cells[2].FindControl("txtMax"));
					if (tb.Text != "")
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateLicUserTypes";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
						cmd.Parameters["@LicenseId"].Value=Session["LicenseIdT"].ToString();
						cmd.Parameters.Add("@UserTypeId", SqlDbType.Int);
						cmd.Parameters ["@UserTypeId"].Value = Int32.Parse(i.Cells[0].Text);
						cmd.Parameters.Add("@UserTypeMax", SqlDbType.Int);
						cmd.Parameters ["@UserTypeMax"].Value=Int32.Parse(tb.Text);
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["UserTypeId"] = e.Item.Cells[0].Text;
			Session["UserTypeName"] = e.Item.Cells[1].Text;
			if (Session["startForm"].ToString() == "frmMainHost")
			{
				updateLicense();			
				deleteLicUserTypes();
				updateLicUserTypes();
			}
				
			if (e.CommandName == "Update")
			{
				Session["CallerOrgs"]="frmLicenseUsers";
				Session["UserTypeId"]=e.Item.Cells[0].Text;			
				Session["UserType"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmOrgUsers.aspx?");
			}
				
			else if (e.CommandName == "Add")
			{
				Session["CallerUpdUsers"]="frmLicenseUsers";
				Session["btnAction"]="Add";
				Response.Redirect (strURL + "frmUpdUsers.aspx?"
				+ "&btnAction=Add");
			}
		}
		private void endIt()
		{
			if (Session["startForm"].ToString() == "frmMainMgr")
			{
				Response.Redirect (strURL + "frmMainMgr.aspx?");
			}
            else if (Session["startForm"].ToString() == "frmMainSec")
            {
                Response.Redirect(strURL + "frmMainSec.aspx?");
            }
			else
			{
				Response.Redirect (strURL + "frmLicenses.aspx?");
			}
		}


	}	
}
