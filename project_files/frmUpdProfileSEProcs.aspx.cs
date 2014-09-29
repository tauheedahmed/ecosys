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
	public partial class frmUpdProfileSEProcs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string Id;
		
		
		private int GetIndexOfProjects (string s)
		{
			return (lstProjects.Items.IndexOf (lstProjects.Items.FindByValue(s)));
		}
		/*private int GetIndexOfRoles (string s)
		{
			return (lstRoles.Items.IndexOf (lstRoles.Items.FindByValue(s)));
		}
		private int GetIndexOfDeadlines (string s)
		{
			return (lstTypesOfDeadlines.Items.IndexOf (lstTypesOfDeadlines.Items.FindByValue(s)));
		}
		private int GetIndexOfImpact (string s)
		{
			return (lstTypesOfImpact.Items.IndexOf (lstTypesOfImpact.Items.FindByValue(s)));
		}
		private int GetIndexOfImpactMagnitude (string s)
		{
			return (lstTypesOfImpactMagnitude.Items.IndexOf (lstTypesOfImpactMagnitude.Items.FindByValue(s)));
		}*/
		private int GetIndexOfProcs (string s)
		{
			return (lstProcs.Items.IndexOf (lstProcs.Items.FindByValue(s)));
		}
		private int GetIndexOfService (string s)
		{
			return (lstService.Items.IndexOf (lstService.Items.FindByValue(s)));
		}
		/*private int GetIndexOfLocs (string s)
		{
			return (lstLocs.Items.IndexOf (lstLocs.Items.FindByValue(s)));
		}*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update")
				{
					Id=Session["Id"].ToString();
				}
			/*if (cbxTTs.Checked)
			{
				lstProjects.Visible=true;
				Label2.Visible=true;
			}
			else
			{
				lstProjects.Visible=false;
				Label2.Visible=false;
			}*/
			if (!IsPostBack)
			{
                lblProfilesName.Text = "Business Profile for: " + Session["ProfilesName"].ToString();
                lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                lblDeliverableName.Text = "Deliverable: " + Session["EventsName"].ToString();
				btnAction.Text= Session["btnAction"].ToString() + " Process";
				if (Session["btnAction"].ToString() == "Add")
				{
                    lblAction.Text = "You may now select from procedures"
                    + "related to other services, i.e. in addition to the service indicated above.";
				}
				else
				{
					lblAction.Text="You may now update the name and description for this process";
                    lblName.Text = "Process Name";
				}
				//loadLocs();
				loadProjects();
				/*loadRoles();
				loadTypesOfDeadlines();
				loadTypesOfImpact();
				loadTypesOfImpactMagnitude();*/
				loadServices();
				
				if (Session["btnAction"].ToString() == "Update")
				{
					loadData();
				}
				else
				{
					loadProcs();
					
				}
				cbxTTs.AutoPostBack=true;
				cbxCosts.AutoPostBack=true;
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
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProfileSEProcsUpd";
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Id;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Upd");
			
			txtName.Text=ds.Tables["Upd"].Rows[0][1].ToString();
			/*lstTypesOfDeadlines.SelectedIndex=GetIndexOfDeadlines (ds.Tables["Upd"].Rows[0][1].ToString());
			txtAcceptableSlip.Text=ds.Tables["Upd"].Rows[0][2].ToString();
			lstTypesOfImpact.SelectedIndex=GetIndexOfImpact (ds.Tables["Upd"].Rows[0][3].ToString());
			lstTypesOfImpactMagnitude.SelectedIndex=GetIndexOfImpactMagnitude (ds.Tables["Upd"].Rows[0][4].ToString());
			txtDollarCostSlip.Text=ds.Tables["Upd"].Rows[0][5].ToString();*/
			//lstLocs.SelectedIndex=GetIndexOfLocs (ds.Tables["Upd"].Rows[0][2].ToString());
			lstProjects.SelectedIndex=GetIndexOfProjects (ds.Tables["Upd"].Rows[0][3].ToString());
			lstService.SelectedIndex=GetIndexOfService (ds.Tables["Upd"].Rows[0][6].ToString());
			//lstRoles.SelectedIndex=GetIndexOfRoles (ds.Tables["Upd"].Rows[0][8].ToString());
			if (ds.Tables["Upd"].Rows[0][4].ToString() == "1") cbxTTs.Checked=true;
			if (ds.Tables["Upd"].Rows[0][5].ToString() == "1") cbxCosts.Checked=true;
			if ((cbxCosts.Checked)|| (cbxTTs.Checked) )
			{
				lstProjects.Visible=true;
				lblProject.Visible=true;
			}
			loadProcs1();
			lstProcs.SelectedIndex=GetIndexOfProcs (ds.Tables["Upd"].Rows[0][0].ToString());
			//lblContents1.Text=rblTimetable.SelectedItem.Value.ToString() + " - " + rblTimetable.SelectedItem.Value;
		}

		private void loadProcs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProcs";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@ServiceTypesId",SqlDbType.Int);
			//cmd.Parameters["@ServiceTypesId"].Value=lstService.SelectedItem.Value;
			cmd.Parameters["@ServiceTypesId"].Value=Session["ServicesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Procs");
			lstProcs.DataSource = ds;			
			lstProcs.DataMember= "Procs";
			lstProcs.DataTextField = "Name";
			lstProcs.DataValueField = "Id";
			lstProcs.DataBind();

		}
		private void loadServices()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveServiceTypes";
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
			da.Fill(ds,"ServiceTypes");
			lstService.DataSource = ds;			
			lstService.DataMember= "ServiceTypes";
			lstService.DataTextField = "Name";
			lstService.DataValueField = "Id";
			lstService.DataBind();
			if (Session["btnAction"].ToString() != "Update")
			{
				lstService.SelectedIndex=GetIndexOfService (Session["ServicesId"].ToString());
			}
		}
		private void loadProjects()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProjectTypes";
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
			da.Fill(ds,"ProjectTypes");
			lstProjects.DataSource = ds;			
			lstProjects.DataMember= "ProjectTypes";
			lstProjects.DataTextField = "Name";
			lstProjects.DataValueField = "Id";
			lstProjects.DataBind();
		}
		/*private void loadRoles()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveRoles";
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
			da.Fill(ds,"Roles");
			lstRoles.DataSource = ds;			
			lstRoles.DataMember= "Roles";
			lstRoles.DataTextField = "Name";
			lstRoles.DataValueField = "Id";
			lstRoles.DataBind();
		}*/
		/*private void loadLocs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveLocTypes";
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
			da.Fill(ds,"LocTypes");
			lstLocs.DataSource = ds;			
			lstLocs.DataMember= "LocTypes";
			lstLocs.DataTextField = "Name";
			lstLocs.DataValueField = "Id";
			lstLocs.DataBind();
		}*/
		/*private void loadTypesOfImpactMagnitude()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTypesOfImpactMagnitude";
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
			da.Fill(ds,"TypesOfImpactMagnitude");
			lstTypesOfImpactMagnitude.DataSource = ds;			
			lstTypesOfImpactMagnitude.DataMember= "TypesOfImpactMagnitude";
			lstTypesOfImpactMagnitude.DataTextField = "Name";
			lstTypesOfImpactMagnitude.DataValueField = "Id";
			lstTypesOfImpactMagnitude.DataBind();
		}
		private void loadTypesOfImpact()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTypesOfImpact";
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
			da.Fill(ds,"TypesOfImpact");
			lstTypesOfImpact.DataSource = ds;			
			lstTypesOfImpact.DataMember= "TypesOfImpact";
			lstTypesOfImpact.DataTextField = "Name";
			lstTypesOfImpact.DataValueField = "Id";
			lstTypesOfImpact.DataBind();
		}
		private void loadTypesOfDeadlines()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTypesOfDeadlines";
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
			da.Fill(ds,"TypesOfDeadlines");
			lstTypesOfDeadlines.DataSource = ds;			
			lstTypesOfDeadlines.DataMember= "TypesOfDeadlines";
			lstTypesOfDeadlines.DataTextField = "Name";
			lstTypesOfDeadlines.DataValueField = "Id";
			lstTypesOfDeadlines.DataBind();
		}*/
			

		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateProfileSEProcs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value= Int32.Parse(Id);
				cmd.Parameters.Add ("@ProcsId",SqlDbType.Int);
				cmd.Parameters["@ProcsId"].Value= lstProcs.SelectedItem.Value;
				/*cmd.Parameters.Add ("@LocsId",SqlDbType.Int);
				cmd.Parameters["@LocsId"].Value= lstLocs.SelectedItem.Value;*/
				cmd.Parameters.Add ("@Name",SqlDbType.VarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				/*cmd.Parameters.Add ("@TypesOfDeadlinesId",SqlDbType.Int);
				cmd.Parameters["@TypesOfDeadlinesId"].Value= lstTypesOfDeadlines.SelectedItem.Value;
				cmd.Parameters.Add ("@AcceptableSlip",SqlDbType.NVarChar);
				cmd.Parameters["@AcceptableSlip"].Value= txtAcceptableSlip.Text;
				cmd.Parameters.Add ("@TypesOfImpactId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactId"].Value= lstTypesOfImpact.SelectedItem.Value;
				cmd.Parameters.Add ("@TypesOfImpactMagnitudeId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactMagnitudeId"].Value= lstTypesOfImpactMagnitude.SelectedItem.Value;
				cmd.Parameters.Add ("@DollarCostSlip",SqlDbType.Int);
				cmd.Parameters.Add ("@RolesId",SqlDbType.Int);
				cmd.Parameters["@RolesId"].Value= lstRoles.SelectedItem.Value;*/
				
				cmd.Parameters.Add ("@ProjectTypesId",SqlDbType.Int);
				cmd.Parameters["@ProjectTypesId"].Value= lstProjects.SelectedItem.Value;
				cmd.Parameters.Add ("@Timetables",SqlDbType.Int);
				if (cbxTTs.Checked)
				{
					cmd.Parameters["@Timetables"].Value= 1;
				}
				else
				{
					cmd.Parameters["@Timetables"].Value= 0;
				}
				cmd.Parameters.Add ("@Costs",SqlDbType.Int);
				if (cbxCosts.Checked)
				{
					cmd.Parameters["@Costs"].Value= 1;
				}
				else
				{
					cmd.Parameters["@Costs"].Value= 0;
				}

				/*if (txtDollarCostSlip.Text == "")
				{
					cmd.Parameters["@DollarCostSlip"].Value= 0;
				}
				else
				{
					cmd.Parameters["@DollarCostSlip"].Value= Int32.Parse(txtDollarCostSlip.Text);
				}*/
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else 
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_AddProfileSEProcs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ProfileSEventsId",SqlDbType.Int);
				cmd.Parameters["@ProfileSEventsId"].Value= Session["ProfileSEventsId"].ToString();
				cmd.Parameters.Add ("@ProcsId",SqlDbType.Int);
				cmd.Parameters["@ProcsId"].Value= lstProcs.SelectedItem.Value;
				/*cmd.Parameters.Add ("@LocsId",SqlDbType.Int);
				cmd.Parameters["@LocsId"].Value= lstLocs.SelectedItem.Value;*/
				
				cmd.Parameters.Add ("@Name",SqlDbType.VarChar);
				if (txtName.Text == "")
				{
					cmd.Parameters["@Name"].Value=lstProcs.SelectedItem.Text;
				}
				else
				{
					cmd.Parameters["@Name"].Value= txtName.Text;
				}
				
				/*cmd.Parameters.Add ("@TypesOfDeadlinesId",SqlDbType.Int);
				cmd.Parameters["@TypesOfDeadlinesId"].Value= lstTypesOfDeadlines.SelectedItem.Value;
				cmd.Parameters.Add ("@AcceptableSlip",SqlDbType.NVarChar);
				cmd.Parameters["@AcceptableSlip"].Value= txtAcceptableSlip.Text;
				cmd.Parameters.Add ("@TypesOfImpactId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactId"].Value= lstTypesOfImpact.SelectedItem.Value;
				cmd.Parameters.Add ("@TypesOfImpactMagnitudeId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactMagnitudeId"].Value= lstTypesOfImpactMagnitude.SelectedItem.Value;

				cmd.Parameters.Add ("@RolesId",SqlDbType.Int);
				cmd.Parameters["@RolesId"].Value= lstRoles.SelectedItem.Value;*/
				
				cmd.Parameters.Add ("@ProjectTypesId",SqlDbType.Int);
				cmd.Parameters["@ProjectTypesId"].Value= lstProjects.SelectedItem.Value;
				cmd.Parameters.Add ("@Timetables",SqlDbType.Int);
				if (cbxTTs.Checked)
				{
					cmd.Parameters["@Timetables"].Value= 1;
				}
				else
				{
					cmd.Parameters["@Timetables"].Value= 0;
				}
				cmd.Parameters.Add ("@Costs",SqlDbType.Int);
				if (cbxCosts.Checked)
				{
					cmd.Parameters["@Costs"].Value= 1;
				}
				else
				{
					cmd.Parameters["@Costs"].Value= 0;
				}
				/*cmd.Parameters.Add ("@DollarCostSlip",SqlDbType.Int);
				if (txtDollarCostSlip.Text == "")
				{
					cmd.Parameters["@DollarCostSlip"].Value= 0;
				}
				else
				{
					cmd.Parameters["@DollarCostSlip"].Value= Int32.Parse(txtDollarCostSlip.Text);
				}*/
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUPSEP"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void cbxTTs_CheckedChanged(object sender, System.EventArgs e)
		{
			cbxChanged();

		}
		private void cbxChanged()
		{
			if ((cbxCosts.Checked)|| (cbxTTs.Checked) )
			{
				lstProjects.Visible=true;
				lblProject.Visible=true;
			}
			else
			{
				lstProjects.Visible=false;
				lblProject.Visible=false;
			}

		}

		protected void cbxCosts_CheckedChanged(object sender, System.EventArgs e)
		{
			cbxChanged();
		}

		protected void lstService_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadProcs1();
			lblAction.Text="Process List Changed to reflect service selected.";
		}
		private void loadProcs1()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProcs";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@ServiceTypesId",SqlDbType.Int);
			cmd.Parameters["@ServiceTypesId"].Value=lstService.SelectedItem.Value;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Procs");
			lstProcs.DataSource = ds;			
			lstProcs.DataMember= "Procs";
			lstProcs.DataTextField = "Name";
			lstProcs.DataValueField = "Id";
			lstProcs.DataBind();
		}
	}	
}
