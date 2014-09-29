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
	public partial class frmUpdOrganization : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String ParentId;
		private String Id;
		private int GetIndexOfVisibility (string s)
		{
			return (lstVis.Items.IndexOf (lstVis.Items.FindByValue(s)));
		}
		/*private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexProfile (string s)
		{
			return (lstProfile.Items.IndexOf (lstProfile.Items.FindByValue(s)));
		}*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
				Id=Request.Params["Id"];
				if (!IsPostBack)
				{
					//loadProfiles();
					loadLicVisibility();
					loadVisibility();
					//loadLocations();
					btnAction.Text= Session["btnAction"].ToString();
					lblTitle.Text=btnAction.Text + " Organization";
                    if (Session["btnAction"].ToString() == "Update")
                    {
                        loadData();
                    }
                    else
                    {
                        lstVis.SelectedIndex = 0;
			
                    }
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

	}
		#endregion
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveOrg";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Request.Params["Id"];
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"OO");	
			txtName.Text=ds.Tables["OO"].Rows[0][0].ToString();
			txtDesc.Text=ds.Tables["OO"].Rows[0][1].ToString();
			txtPhone.Text=ds.Tables["OO"].Rows[0][2].ToString();
			txtEmail.Text=ds.Tables["OO"].Rows[0][3].ToString();
			txtAddr.Text=ds.Tables["OO"].Rows[0][4].ToString();
			//lstLocations.SelectedIndex = GetIndexOfLocs (ds.Tables["OO"].Rows[0][5].ToString());
			lstVis.SelectedIndex = GetIndexOfVisibility (ds.Tables["OO"].Rows[0][6].ToString());
			//lstProfile.SelectedIndex = GetIndexOfLocs (ds.Tables["OO"].Rows[0][7].ToString());
			
			
		}
		/*private void loadProfiles() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Profiles"
				+ " Where Type = 'Producer'"
				+ " Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Profiles");
			lstProfile.DataSource = ds;
			lstProfile.DataMember = "Profiles";
			lstProfile.DataTextField = "Name";
			lstProfile.DataValueField = "Id";
			lstProfile.DataBind();
		}*/
		private void loadLicVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveLicVis";
			cmd.Parameters.Add("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"LicVis");
			Session["LicOrg"]=ds.Tables["LicVis"].Rows[0][1].ToString();
			Session["LicVis"]=ds.Tables["LicVis"].Rows[0][0].ToString();
		}
		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			if (Session["LicOrg"].ToString() != Session["OrgId"].ToString())
			{
				cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
			}
			else
			{
				cmd.Parameters["@Vis"].Value=Session["LicVis"].ToString();
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			lstVis.DataSource = ds;			
			lstVis.DataMember= "Visibility";
			lstVis.DataTextField = "Name";
			lstVis.DataValueField = "Id";
			lstVis.DataBind();
		}
		/*private void loadLocations() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveLocations";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Locations");
			lstLocations.DataSource = ds;			
			lstLocations.DataMember= "Locations";
			lstLocations.DataTextField = "Name";
			lstLocations.DataValueField = "Id";
			lstLocations.DataBind();
		}*/
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateOrg";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;
				cmd.Parameters.Add ("@Addr",SqlDbType.NText);
				cmd.Parameters["@Addr"].Value=txtAddr.Text;
				cmd.Parameters.Add ("@Phone",SqlDbType.NVarChar);
				cmd.Parameters["@Phone"].Value=txtPhone.Text;
				cmd.Parameters.Add ("@Email",SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value=txtEmail.Text;
				/*cmd.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;*/
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVis.SelectedItem.Value;
				/*cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
				cmd.Parameters["@ProfileId"].Value=lstProfile.SelectedItem.Value;*/
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				ParentId = Session["OrgId"].ToString();

				SqlCommand cmd1=new SqlCommand();
				cmd1.CommandType=CommandType.StoredProcedure;
				cmd1.CommandText="ams_AddOrg";
				cmd1.Connection=this.epsDbConn;
				cmd1.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd1.Parameters["@Name"].Value= txtName.Text;
				cmd1.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd1.Parameters["@Desc"].Value= txtDesc.Text;
				cmd1.Parameters.Add ("@Phone",SqlDbType.NVarChar);
				cmd1.Parameters["@Phone"].Value= txtPhone.Text;
				cmd1.Parameters.Add ("@Email",SqlDbType.NVarChar);
				cmd1.Parameters["@Email"].Value=txtEmail.Text;
				cmd1.Parameters.Add ("@Addr",SqlDbType.NText);
				cmd1.Parameters["@Addr"].Value=txtAddr.Text;
				cmd1.Parameters.Add ("@ParentOrg",SqlDbType.Int);
				cmd1.Parameters["@ParentOrg"].Value=ParentId;
				cmd1.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd1.Parameters["@Vis"].Value=lstVis.SelectedItem.Value;
				cmd1.Parameters.Add ("@Creator",SqlDbType.Int);
				cmd1.Parameters["@Creator"].Value=Session["OrgId"].ToString();
				cmd1.Parameters.Add ("@LicenseId",SqlDbType.Int);
				cmd1.Parameters["@LicenseId"].Value= Session["LicenseId"];
				cmd1.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
				cmd1.Parameters["@OrgType"].Value="na";
				/*cmd1.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd1.Parameters.Add ("@ProfileId",SqlDbType.Int);
				cmd1.Parameters["@ProfileId"].Value=lstProfile.SelectedItem.Value;
				cmd1.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;*/				
				cmd1.Connection.Open();
				cmd1.ExecuteNonQuery();
				cmd1.Connection.Close();
				//retrieveOrgId();
				//addService();
				Done();
				
			}
			else if (btnAction.Text == "OK")
			{
				Done();
			}
		}
		/*private void retrieveOrgId()
		{	
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Max(Id) From Organizations"
				+ " Where CreatorOrg=" + "'" + Session["OrgId"] + "'";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"OrgIdSP");
			Session["OrgIdSP"]=(ds.Tables["OrgIdSP"].Rows[0][0]);
		}*/
		/*private void addService()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_AddService";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
			cmd.Parameters["@Name"].Value=Session["ServiceName"].ToString();
			cmd.Parameters.Add ("@OrgId", SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgIdSP"].ToString();
			cmd.Parameters.Add ("@Desc",SqlDbType.NText);
			cmd.Parameters["@Desc"].Value=txtDesc.Text;
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=lstVis.SelectedItem.Value;
			cmd.Parameters.Add ("@Type",SqlDbType.Int);
			cmd.Parameters["@Type"].Value=Session["ServiceTypesId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			Done();
		}*/
		private void Done()
		{
			Response.Redirect (strURL + Session["CUO"].ToString() + ".aspx?");	
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}


	}	


}
