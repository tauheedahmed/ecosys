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
	public partial class frmUpdOutputs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String ResourceId;
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
		private int GetIndexType (string s)
		{
			return (lstType.Items.IndexOf (lstType.Items.FindByValue(s)));
		}
		private int GetIndexOrgs (string s)
		{
			return (lstOrgs.Items.IndexOf (lstOrgs.Items.FindByValue(s)));
		}
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			ResourceId=Request.Params["ResourceId"];
				lblOrg1.Text=(Session["OrgName"]).ToString();
			
			if (Session["CallerServices"].ToString() == "frmMainTrg")
			{
				lblFunction.Text=Request.Params["btnAction"] + " Training Course or Service";
			}
			else
			{
				lblFunction.Text=Request.Params["btnAction"] + " Service";
			}
			if (!IsPostBack)
			{
				loadType();
				loadOrgs();
				loadVisibility();
				btnAction.Text= Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];				
				txtDesc.Text=Request.Params["Desc"];
				lstVisibility.BorderColor=System.Drawing.Color.Navy;
				lstVisibility.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex = GetIndexOfVisibility (Request.Params["Vis"]);
				lstType.SelectedIndex = GetIndexType (Request.Params["Type"]);
				lstOrgs.SelectedIndex = GetIndexOrgs (Request.Params["SupplierOrg"]);
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
		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			lstVisibility.DataSource = ds;			
			lstVisibility.DataMember= "Visibility";
			lstVisibility.DataTextField = "Name";
			lstVisibility.DataValueField = "Id";
			lstVisibility.DataBind();
		}
		private void loadType() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			if (Session["startForm"].ToString() == "frmMainTrg")
			{
				cmd.CommandText="Select ResourceTypes.Id, ResourceTypes.Name from ResourceTypes"
				+ " inner join ResourceTypes as Parent on"
					+ " ResourceTypes.ParentId = Parent.Id"
					+ " Where Parent.Id='47'"
					+ " Order by ResourceTypes.Name";
			}
			if (Session["startForm"].ToString() == "frmMainEPS")
			{
				cmd.CommandText="Select ResourceTypes.Id, ResourceTypes.Name from ResourceTypes"
					+ " Where Id !='51'"  // 51=ResTypeId for Service Emergency Management
					+ " Order by ResourceTypes.Name";
			}
			else
			{
				cmd.CommandText="Select Id, Name from ResourceTypes"
					+ " Where Visibility='1'"
					+ " Order by Name";
			}
				   DataSet ds=new DataSet();
				   SqlDataAdapter da=new SqlDataAdapter (cmd);
				   da.Fill(ds,"Resources");
				   lstType.DataSource = ds;			
				   lstType.DataMember= "Resources";
				   lstType.DataTextField = "Name";
				   lstType.DataValueField = "Id";
				   lstType.DataBind();
			   }
		private void loadOrgs() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Organizations"
					+ " Where (ParentOrg ='" + Session["OrgId"].ToString()+ "'"
					+ " or Id = '" + Session["OrgId"].ToString() + "')"
					+ " and OrgType != 'Household'";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Organizations");
			lstOrgs.DataSource = ds;			
			lstOrgs.DataMember= "Organizations";
			lstOrgs.DataTextField = "Name";
			lstOrgs.DataValueField = "Id";
			lstOrgs.DataBind();
		}

		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateService";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(ResourceId);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Type",SqlDbType.Int);
				cmd.Parameters["@Type"].Value=lstType.SelectedItem.Value;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=lstOrgs.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddService";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgIdt"];
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Type",SqlDbType.Int);
				cmd.Parameters["@Type"].Value=lstType.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}

		}
		private void Done()
		{
			Response.Redirect (strURL + "frmServices.aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}


	}	

}
