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
	public partial class frmUpdOrg : System.Web.UI.Page
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
			return (rblVis.Items.IndexOf (rblVis.Items.FindByValue(s)));
		}
		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
				lblOrg.Text=Session["OrgName"].ToString();
				Id=Request.Params["Id"];
	
				if (!IsPostBack)
				{
					loadLicVisibility();
					loadVisibility();
					loadLocations();
					btnAction.Text= Session["btnAction"].ToString();
					if (Session["startForm"].ToString() != "frmMainCoop")
					{
						lblContent.Text=btnAction.Text + " Organization Details";
					}
					else
					{
						lblContent.Text=btnAction.Text + " Household Details";
					}
					txtName.Text=Request.Params["Name"];
					txtDesc.Text=Request.Params["Desc"];
					txtPhone.Text=Request.Params["Phone"];
					txtEmail.Text=Request.Params["Email"];
					txtAddr.Text=Request.Params["Addr"];
					if (Request.Params["Vis"]== null)
					{
						//rblVis.SelectedIndex=4; Doesnt work
					}
	
					{
						rblVis.SelectedIndex = GetIndexOfVisibility (Request.Params["Vis"]);
					}
					lstLocations.SelectedIndex = GetIndexOfLocs (Request.Params["LocId"]);
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
			rblVis.DataSource = ds;			
			rblVis.DataMember= "Visibility";
			rblVis.DataTextField = "Name";
			rblVis.DataValueField = "Id";
			rblVis.DataBind();
		}
		private void loadLocations() 
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
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="ams_UpdateOrg";
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
				cmd.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=rblVis.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				if ((Session["CallerUpdOrg"].ToString() == "frmMainOrgs")
					||(Session["CallerUpdOrg"].ToString() == "frmMainAdm")
					||(Session["CallerUpdOrg"].ToString() == "frmMainSec")
					||(Session["CallerUpdOrg"].ToString() == "frmMainTrg")
					||(Session["CallerUpdOrg"].ToString() == "frmMainPers"))
				{
					Session["OrgName"]=txtName.Text;
					Session["Email"]=txtEmail.Text;
				}
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
				cmd1.Parameters["@Vis"].Value=rblVis.SelectedItem.Value;
				cmd1.Parameters.Add ("@Creator",SqlDbType.Int);
				if (Session["CallerUpdOrg"].ToString() == "frmServiceOrgs")
				{
					cmd1.Parameters["@Creator"].Value=Session["ActivationId"].ToString();	
				}
				else
				{
					cmd1.Parameters["@Creator"].Value=Session["OrgId"].ToString();
				}
				cmd1.Parameters.Add ("@LicenseId",SqlDbType.Int);
				cmd1.Parameters["@LicenseId"].Value= Session["LicenseId"];
				cmd1.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
				cmd1.Parameters["@OrgType"].Value=Session["OrgType"].ToString();
				cmd1.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd1.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;				
				cmd1.Connection.Open();
				cmd1.ExecuteNonQuery();
				cmd1.Connection.Close();
				if ((Session["CallerUpdOrg"].ToString() == "frmMainAdm")
					||(Session["CallerUpdOrg"].ToString() == "frmMainAsp")
					||(Session["CallerUpdOrg"].ToString() == "frmMainOrgs")
					||(Session["CallerUpdOrg"].ToString() == "frmMainTrg")
					||(Session["CallerUpdOrg"].ToString() == "frmMainTeam")
					||(Session["CallerUpdOrg"].ToString() == "frmMainPers")
					||(Session["CallerUpdOrg"].ToString() == "frmMainSec"))
				{
					Session["OrgName"]=txtName.Text;
					Session["Email"]=txtEmail.Text;
				}
				Done();
				
			}
			else if (btnAction.Text == "OK")
			{
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdOrg"].ToString() + ".aspx?");	
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}


	}	


}
