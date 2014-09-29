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
	public partial class frmUpdResources : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.TextBox txtGlAv;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtInAv;
		private string Id;
	
		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
		private int GetIndexStatus (string item) 
		{
			if (btnAction.Text == "Update")
			{
				if (item.Trim() == "Actual")  
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			else
			{
				return 0;
			}
		}
		private int GetIndexType (string s)
		{
			return (lstType.Items.IndexOf (lstType.Items.FindByValue(s)));
			
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				Id=Request.Params["Id"];
				loadType();
				loadVisibility();
				loadLocations();
				lblOrg.Text=Session["OrgName"].ToString();	
				btnAction.Text= Request.Params["btnAction"];								
				txtName.Text=Request.Params["Name"];
				txtDesc.Text=Request.Params["Desc"];
				lstLocations.SelectedIndex = GetIndexOfLocs (Request.Params["LocId"]);
				lstStatus.SelectedIndex=GetIndexStatus (Request.Params["Status"]);	
				lstType.SelectedIndex = GetIndexType (Request.Params["Type"]);
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);
				
				if (Session["Cuor"].ToString() == "frmResourcesAll")
				{
					lstType.Visible=false;
					lblType.Visible=false;					
					lstVisibility.Visible=false;
					lblVisibility.Visible=false;
					lblContent.Text="Resource Type: " + Session["ResTypeName"].ToString() 
					+ ": " + Request.Params["btnAction"];
				}
				else
				{
					lstStatus.BorderColor=System.Drawing.Color.Navy;
					lblContent.Text="Owned Resources: " + Request.Params["btnAction"];
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

		private void loadType() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from ResourceTypes"
				+ " Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Resources");
			lstType.DataSource = ds;			
			lstType.DataMember= "Resources";
			lstType.DataTextField = "Name";
			lstType.DataValueField = "Id";
			lstType.DataBind();
			
		}
		private void loadLocations() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveLocations";
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();			
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Locations");
			lstLocations.DataSource = ds;			
			lstLocations.DataMember= "Locations";
			lstLocations.DataTextField = "Name";
			lstLocations.DataValueField = "Id";
			lstLocations.DataBind();
		}
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

		protected void btnAction_Click(object sender, System.EventArgs e)
		{
				if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateOwnResources";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Request.Params["Id"].ToString();
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Visibility",SqlDbType.Int);
				cmd.Parameters["@Visibility"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;
				cmd.Parameters.Add ("@Stat",SqlDbType.NVarChar);
				cmd.Parameters["@Stat"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Parameters.Add ("@Type",SqlDbType.Int);
				cmd.Parameters["@Type"].Value=lstType.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();/*
					lblOrg.Text="Type: " + lstType.SelectedItem.Value.ToString()
						+ "--LocId: " + lstLocations.SelectedItem.Value.ToString()
						+ "--ID: " + Request.Params["Id"].ToString();*/
			}
	
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddOwnResources";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@Stat",SqlDbType.NVarChar);
				cmd.Parameters["@Stat"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@Visibility",SqlDbType.Int);
				if (Session["Cuor"].ToString()=="frmResourcesAll")
				{
					cmd.Parameters["@Visibility"].Value=5;
				}
				else
				{
					cmd.Parameters["@Visibility"].Value=lstVisibility.SelectedItem.Value;
				}
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@Type",SqlDbType.Int);				
				cmd.Parameters["@Type"].Value=lstType.SelectedItem.Value;
				cmd.Parameters.Add ("@LocId", SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["Cuor"].ToString() + ".aspx?");
		}




	}
}
