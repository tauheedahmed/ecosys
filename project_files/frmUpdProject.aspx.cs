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
	public partial class frmUpdProject : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
		private int GetIndexOfType (string s)
		{
			return (lstType.Items.IndexOf (lstType.Items.FindByValue(s)));
		}
		/*private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}*/
		private int GetIndexOfStatus (string s)
		{
			switch(s)       
			{         
				case "Planned": 
					return 0;
				case "Started":   
					return 1;                 
				case "Completed":            
					return 2;       
				case "Cancelled":            
					return 3;          
				default:            
					return 0;    
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                if (Session["MgrName"] != null)
                {
					lblMgr.Text=Session["MgrName"].ToString();
				}
				else
				{
					lblMgr.Text=Session["OrgName"].ToString();
				}
                /*lblBud.Text = "Budget: " + Session["BudName"].ToString();*/
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				lblLocation.Text="Location: " + Session["LocName"].ToString();
                if (Session["CProjects"] == "frmPSEvents")
                {
                     lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
				 }
                else if (Session["CProjects"] == "frmOrgLocServices")
                {
                    lblEventName.Text = "";
                }
               loadVisibility();
				//loadType();
				if (Session["ProjectId"] == null)
				{
					btnAction.Text= "Add";
					lblContents1.Text="Add " + Session["PJNameS"].ToString();
				}
				else 
				{
					btnAction.Text= "OK";		
					lblContents1.Text="Update " + Session["PJNameS"].ToString();
					lblProj.Text=Session["PJNameS"].ToString()
						+ ": "
						+ Session["ProjName"].ToString();
					projData();
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
		private void projData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjdata";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProjectId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projdata");
			txtName.Text=ds.Tables["Projdata"].Rows[0][0].ToString();			
			rblStatus.SelectedIndex=GetIndexOfStatus(ds.Tables["Projdata"].Rows[0][1].ToString());
			lstVisibility.SelectedIndex=GetIndexOfVisibility(ds.Tables["Projdata"].Rows[0][2].ToString());
			txtStartTime.Text=ds.Tables["Projdata"].Rows[0][3].ToString();	
			txtEndTime.Text=ds.Tables["Projdata"].Rows[0][4].ToString();
			txtDesc.Text=ds.Tables["Projdata"].Rows[0][5].ToString();
			//lstType.SelectedIndex=GetIndexOfType(ds.Tables["Projdata"].Rows[0][5].ToString());
			
			/*lstLocations.SelectedIndex=
				GetIndexOfLocs(ds.Tables["StaffAction"].Rows[0][5].ToString());*/
		}
		/*private void loadLocs()
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
		/*private void loadType()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProjectType";
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
			cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
			cmd.Parameters["@ProfileId"].Value=Session["ProfileId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Type");
			lstType.DataSource = ds;			
			lstType.DataMember= "Type";
			lstType.DataTextField = "Name";
			lstType.DataValueField = "Id";
			lstType.DataBind();
		}*/
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			
			{
				if (btnAction.Text == "OK") 
					try
					{
						SqlCommand cmd = new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="wms_UpdateProject";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@Id",SqlDbType.Int);
						cmd.Parameters["@Id"].Value=Int32.Parse(Session["ProjectId"].ToString());
						cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
						cmd.Parameters["@Name"].Value=txtName.Text;
						cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
						cmd.Parameters["@Desc"].Value=txtDesc.Text;
						cmd.Parameters.Add ("@Vis",SqlDbType.Int);
						cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
						cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
						cmd.Parameters["@Status"].Value=rblStatus.SelectedItem.Value;
						cmd.Parameters.Add ("@StartTime",SqlDbType.SmallDateTime);
						if (txtStartTime.Text != "") cmd.Parameters["@StartTime"].Value=txtStartTime.Text;
						else cmd.Parameters["@StartTime"].Value = null;
						cmd.Parameters.Add ("@EndTime",SqlDbType.SmallDateTime);
						if (txtEndTime.Text != "") cmd.Parameters["@EndTime"].Value=txtEndTime.Text;
						else cmd.Parameters["@EndTime"].Value = null;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
						Done();
					}

					catch 
					{
						lblDate.ForeColor=Color.Orange;
					}
				else if (btnAction.Text == "Add")
				{
					try
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="wms_AddProject";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
						cmd.Parameters["@Name"].Value= txtName.Text;
						cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
						cmd.Parameters["@Desc"].Value=txtDesc.Text;
						cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
						cmd.Parameters["@Status"].Value=rblStatus.SelectedItem.Value;
						cmd.Parameters.Add ("@Vis",SqlDbType.Int);
						cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
						cmd.Parameters.Add ("@PSEventsId",SqlDbType.Int);
						cmd.Parameters["@PSEventsId"].Value=Session["PSEventsId"].ToString();
						/*cmd.Parameters.Add ("@ProjectTypesId",SqlDbType.Int);
						cmd.Parameters["@ProjectTypesId"].Value=lstType.SelectedItem.Value;*/
						cmd.Parameters.Add ("@StartTime",SqlDbType.SmallDateTime);
						if (txtStartTime.Text != "") cmd.Parameters["@StartTime"].Value=txtStartTime.Text;
						else cmd.Parameters["@StartTime"].Value = null;
						cmd.Parameters.Add ("@EndTime",SqlDbType.SmallDateTime);
						if (txtEndTime.Text != "") cmd.Parameters["@EndTime"].Value=txtEndTime.Text;
						else cmd.Parameters["@EndTime"].Value = null;
						cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
                        cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                        cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                        cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
						//cmd.Parameters.Add ("@ProjectTypesId",SqlDbType.Int);
						//cmd.Parameters["@ProjectTypesId"].Value=Session["ProjectTypesId"].ToString();
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						//retrieveProjPeople();

						Done();
					}
					catch
					{
						lblDate.ForeColor=Color.Orange;
					}
				}
			}
		}
		/*private void retrieveProjPeople()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjdataNew";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProjectId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projdata");
			txtName.Text=ds.Tables["Projdata"].Rows[0][0].ToString();			
			rblStatus.SelectedIndex=GetIndexOfStatus(ds.Tables["Projdata"].Rows[0][1].ToString());
			lblStatus.Text="Current Status: " + ds.Tables["Projdata"].Rows[0][1].ToString();
			lstVisibility.SelectedIndex=GetIndexOfVisibility(ds.Tables["Projdata"].Rows[0][2].ToString());
			txtStartTime.Text=ds.Tables["Projdata"].Rows[0][3].ToString();	
			txtEndTime.Text=ds.Tables["Projdata"].Rows[0][4].ToString();
		}
		private void updateProjPeople()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_UpdateProjectsPeople";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
			cmd.Parameters ["@ProjectId"].Value=I;
			cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
			cmd.Parameters ["@PeopleId"].Value=Session["PeopleId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}*/
		private void Done()
		{
			if (Session["startForm"].ToString() == "frmMainOrgLocInd")
			{
				Session["ProjectId"]=null;
			}
			Response.Redirect (strURL + Session["CUpdProject"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}	
}
