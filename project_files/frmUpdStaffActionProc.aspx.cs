using System;
using System.Collections;
using System.Globalization;
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
	public partial class frmUpdStaffActionProc : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.RadioButtonList rblStatusSS;

		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}

		private int GetIndexOfPayMethods (string s)
		{
			return (lstPayMethods.Items.IndexOf (lstPayMethods.Items.FindByValue(s)));
		}
		private int GetIndexOfAptTypes (string s)
		{
			return (lstAptTypes.Items.IndexOf (lstAptTypes.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				loadVisibility();
				loadLocs();
				loadPayMethods();
				loadAptTypes();
				lstPayMethods.BorderColor=System.Drawing.Color.Navy;
				lstPayMethods.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);
				if (Session["btnAction1"].ToString() == "Update")
				{
					loadStaffAction();
				}
				if (Session["PeopleId"] != null)
				{
					lblName.Text = Session["PeopleName"].ToString();
				}
				btnAction.Text=Session["btnAction1"].ToString();
				if (Session["btnAction1"].ToString() == "Add")
				{
					lblContent1.Text="You may now prepare a new staff or consultant appointment."
						+ " If you have already identified the individual to be appointed, you may"
						+ " identify this individual by clicking on 'Identify Person Requested (if any)'."
						+ " Or you may complete the request without identifying the person, who will"
						+ " then be identified separately by the recruitment staff in your organization.";
				}
				else
				{
					lblContent1.Text="You may only review the status of the appointment action at this point."
						+ " Any changes will need to be requested from staff responsible for carrying out"
						+ " the appointment action.";
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
	
		private void loadAptTypesc()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveOrgStaffTypesInd";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=lstAptTypes.SelectedItem.Value;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ost");
			lblSalaryPeriod.Text=ds.Tables["ost"].Rows[0][3].ToString()
				+ " per " + ds.Tables["ost"].Rows[0][4].ToString();
		}
		private void loadAptTypes()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="hrs_RetrieveOrgStaffTypes";		
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();	
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"StaffTypes");
				lstAptTypes.DataSource = ds;			
				lstAptTypes.DataMember= "StaffTypes";
				lstAptTypes.DataTextField = "Name";
				lstAptTypes.DataValueField = "Id";
				lstAptTypes.DataBind();
				lblSalaryPeriod.Text=ds.Tables["StaffTypes"].Rows[0][3].ToString()
				+ " per " + ds.Tables["StaffTypes"].Rows[0][4].ToString();
		}
		private void loadStaffAction()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveStaffAction";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["Id"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffAction");
			if (Session["PeopleId"] != null)
			{
				lblName.Text = Session["PeopleName"].ToString();
			}
			else if (ds.Tables["StaffAction"].Rows[0][0].ToString() == null)
			{
				lblName.Text= "Unidentified";
				Session["PeopleId"]=null;
			}
			else
			{
				Session["PeopleId"]=ds.Tables["StaffAction"].Rows[0][0].ToString();
				lblName.Text=ds.Tables["StaffAction"].Rows[0][1].ToString();	
			}		
			lstLocations.SelectedIndex=
				GetIndexOfLocs(ds.Tables["StaffAction"].Rows[0][3].ToString());
			lstVisibility.SelectedIndex=
				GetIndexOfVisibility(ds.Tables["StaffAction"].Rows[0][4].ToString());
			lstPayMethods.SelectedIndex = GetIndexOfPayMethods (ds.Tables["StaffAction"].Rows[0][5].ToString());
			Session["Status"]=ds.Tables["StaffAction"].Rows[0][7].ToString();
			//Session["StaffTypesId"]=Int32.Parse(Session["StaffTypeId"].ToString());
			txtSalary.Text=ds.Tables["StaffAction"].Rows[0][8].ToString();
			lstAptTypes.SelectedIndex = GetIndexOfAptTypes(ds.Tables["StaffAction"].Rows[0][9].ToString());

			if (Session["Status"].ToString() == null)
			{
				lblAptStatus.Text="Status:  Appointment Action Request Created";

			} 
			else if (Session["Status"].ToString() == "0")
			{
				lblAptStatus.Text="Status:  Appointment Action Requested";
				btnAction.Visible=false;
				btnSave.Text="Accept Request";

			}
			else if (Session["Status"].ToString() == "1")
			{
				lblAptStatus.Text="Status:  Appointment Action in Process";
				btnAction.Text="OK";
				btnSave.Text="Appoint";
			}
			else if (Session["Status"].ToString() == "2")
			{
				lblAptStatus.Text="Status:  Appointed";
				btnAction.Text="OK";
				btnPeople.Visible=false;
				btnSave.Text="Terminate";
			}
			else if (Session["Status"].ToString() == "3")
			{
				lblAptStatus.Text="Status:  Appointment Terminated";
				btnAction.Text="OK";
				btnPeople.Visible=false;
				btnSave.Visible=false;
			}
			else if (Session["Status"].ToString() == "4")
			{
				lblAptStatus.Text="Status:  Appointment Request Rejected";
				btnAction.Text="OK";
				btnSave.Visible=false;
				btnPeople.Visible=false;
			}
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{ 
				Session["StatusC"] = 0;	
				if (Session["btnAction1"].ToString() == "Add")
				{
					addData();
				}
				else
				{
					updateData();
				}
				Done();
		}
		protected void btnSave_Click(object sender, System.EventArgs e)
		{
			if (Session["btnAction1"].ToString() == "Add")
				{
					addData();
				}
				else
				{
					updateData();
				}
				Done();
			
		}
		private void updateData()
		{
			try
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdateStaffAction";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["Id"].ToString();
				cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
				cmd.Parameters["@TypeId"].Value=lstAptTypes.SelectedItem.Value;
				cmd.Parameters.Add ("@LocId",SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Parameters.Add ("@PM",SqlDbType.Int);
				cmd.Parameters["@PM"].Value=lstPayMethods.SelectedItem.Value;
				if (Session["PeopleId"] != null)
				{
					cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
					cmd.Parameters["@PeopleId"].Value= Session["PeopleId"].ToString();
				}
				cmd.Parameters.Add ("@Sal",SqlDbType.Decimal);
				cmd.Parameters["@Sal"].Value=decimal.Parse(txtSalary.Text,
					NumberStyles.Any);
				//cmd.Parameters.Add ("@PayGrade",SqlDbType.Int);
				//cmd.Parameters["@PayGrade"].Value=lstAptTypes.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (Session["StatusC"] != null)
				{
					cmd.Parameters["@Status"].Value=Session["StatusC"].ToString();
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			catch
			{
				if (txtSalary.Text == "")
				{
					lblContent1.ForeColor=Color.Maroon;
					lblContent1.Text="You must enter a Salary Amount or click 'Cancel'";
				}
			}
		}
		private void addData()
		{
			try
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_AddStaffAction";
				cmd.Connection=this.epsDbConn;
				if (Session["PeopleId"] != null)
				{
					cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
					cmd.Parameters["@PeopleId"].Value= Session["PeopleId"].ToString();
				}
				cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
				cmd.Parameters["@TypeId"].Value=lstAptTypes.SelectedItem.Value;
				cmd.Parameters.Add ("@LocId",SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				//cmd.Parameters.Add ("@PayGrade",SqlDbType.Int);
				//cmd.Parameters["@PayGrade"].Value=lstAptTypes.SelectedItem.Value;
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (Session["StatusC"] != null)
				{
					cmd.Parameters["@Status"].Value=Session["StatusC"].ToString();
				}
				cmd.Parameters.Add ("@Sal",SqlDbType.Decimal);
				if (txtSalary.Text != "")
				{
					cmd.Parameters["@Sal"].Value=decimal.Parse(txtSalary.Text,
						NumberStyles.Any);
				}
			
				cmd.Parameters.Add ("@PM",SqlDbType.Int);
				cmd.Parameters["@PM"].Value=lstPayMethods.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			catch
			{
				if (txtSalary.Text == "")
				{
					lblContent1.ForeColor=Color.Maroon;
					lblContent1.Text="You must enter a Salary Amount or click 'Cancel'";
				}
			}
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

		private void loadLocs()
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
		
		private void loadPayMethods()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrievePayMethods";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PayMethods");
			lstPayMethods.DataSource = ds;			
			lstPayMethods.DataMember= "PayMethods";
			lstPayMethods.DataTextField = "Name";
			lstPayMethods.DataValueField = "Id";
			lstPayMethods.DataBind();
		}

		private void Done()
		{
			Session["PeopleId"]=null;
			Response.Redirect (strURL + Session["CSA"].ToString() + ".aspx?");
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		private void peopleAdd()
		{lblOrg.Text="h2";
			Session["CallerPeople"]="frmUpdStaffActionProc";
			Response.Redirect (strURL + "frmPeople.aspx?");
			
		}
		protected void btnPeople_Click(object sender, System.EventArgs e)
		{
			peopleAdd();
			lblOrg.Text="h1";
		}

		protected void lstAptTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadAptTypesc();
		}

	}
}

	
