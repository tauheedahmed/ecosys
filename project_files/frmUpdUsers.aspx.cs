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
	public partial class frmUpdUsers : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string Id;
/*		private int GetIndexType (string item)
		{
			if (Request.Params["btnAction"].Trim() == "Update")
			{
				if (item.Trim() == "Organization")
				{
					return 0;
				}
				else if (item.Trim() == "Staff")
				{
					return 1;
				}				
				else if (item.Trim() == "Household")
				{
					return 2;
				}
				else if (item.Trim() == "Administrator")
				{
					return 3;
				}
				else if (item.Trim() == "Security")
				{
					return 4;
				}
				else if (item.Trim() == "Training")
				{
					return 5;
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
		}*/
		private int GetIndexStatus (string item)
		{
			if (btnAction.Text == "Update")
			{
				if (item.Trim() == "Active")
				{
					return 0;
				}
				else 
				{
					return 1;
				}
				
			}
			else
			{
				return 0;
			}
		}
		private int GetIndexOrg (string s)
		{
			return (lstOrganization.Items.IndexOf (lstOrganization.Items.FindByValue(s)));
		}
		private int GetIndexOfSelection (string s)
		{
			return (lstPerson.Items.IndexOf (lstPerson.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() != "Add")
			{
				Id=Session["Id"].ToString();
			}
			if (Session["startForm"].ToString() == "frmMainHost")
			{
				lblOrg.Text="License Holder: " + Session["ClientLicHolder"].ToString();
			}
			lblAction.Text=Session["btnAction"].ToString() + " User Id";
			lblUserTypeName.Text="Type of User: " + Session["UserTypeName"].ToString();
			
			if (!IsPostBack)
			{
				loadOrg();
				loadPeople();
				btnAction.Text= Session["btnAction"].ToString();
				if (Session["btnAction"].ToString() == "Update")
				{
					loadUser();
					
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
		private void loadUser()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveUsers";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgIdt"].ToString();
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="frmMainSec";
			cmd.Parameters.Add ("@UserTypeId",SqlDbType.Int);
			cmd.Parameters["@UserTypeId"].Value=Session["UserTypeId"];
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["Id"].ToString();
			cmd.Connection=this.epsDbConn;	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Users");
			lstOrganization.SelectedIndex = GetIndexOrg (ds.Tables["Users"].Rows[0][1].ToString());
			txtPd.Text=ds.Tables["Users"].Rows[0][2].ToString();
			lstPerson.SelectedIndex = GetIndexOfSelection (ds.Tables["Users"].Rows[0][3].ToString());
			rblStatus.SelectedIndex = GetIndexStatus (ds.Tables["Users"].Rows[0][4].ToString());
			txtUser.Text=ds.Tables["Users"].Rows[0][5].ToString();

		}
		private void loadOrg() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText=
			"Select Organizations.Id, Organizations.Name from Organizations inner join Licenses"
			+ " on Organizations.LicenseId=Licenses.Id"
			+ " Where LicenseId =" +  Session["LicenseIdT"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Organizations");
			lstOrganization.DataSource = ds;			
			lstOrganization.DataMember= "Organizations";
			lstOrganization.DataTextField = "Name";
			lstOrganization.DataValueField = "Id";
			lstOrganization.DataBind();
		}
		private void loadPeople() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrievePeopleList";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			/*cmd.CommandText="Select PeopleId, Fname + ' ' + LName as Name from People"
				+ " inner join Staffing"
				+ " on People.Id = Staffing.PeopleId"
				+ " Where Staffing.OrgId = " + lstOrganization.SelectedItem.Value.ToString();*/
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"People");
			lstPerson.DataSource = ds;			
			lstPerson.DataMember= "People";
			lstPerson.DataTextField = "Name";
			lstPerson.DataValueField = "Id";
			lstPerson.DataBind();
			//lblOrg.Text=Session["DomainId"].ToString();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (btnAction.Text == "Update") 
				{
					SqlCommand cmd = new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateUserId";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id",SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse(Id);
					cmd.Parameters.Add ("@User",SqlDbType.NVarChar);
					cmd.Parameters["@User"].Value= txtUser.Text;
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value= lstOrganization.SelectedItem.Value;
					cmd.Parameters.Add ("@Status", SqlDbType.NVarChar);
					cmd.Parameters["@Status"].Value=rblStatus.SelectedItem.Value;
					cmd.Parameters.Add ("@Pd", SqlDbType.NVarChar);
					cmd.Parameters["@Pd"].Value=txtPd.Text;
					cmd.Parameters.Add ("@PeopleId", SqlDbType.Int);
					cmd.Parameters["@PeopleId"].Value=lstPerson.SelectedItem.Value;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					Done();
				}
				else if (btnAction.Text == "Add")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_AddUserId";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@User",SqlDbType.NVarChar);
					cmd.Parameters["@User"].Value= txtUser.Text;
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value= lstOrganization.SelectedItem.Value;
					cmd.Parameters.Add ("@Status", SqlDbType.NVarChar);
					cmd.Parameters["@Status"].Value=rblStatus.SelectedItem.Value;
					cmd.Parameters.Add ("@Type", SqlDbType.NVarChar);
					cmd.Parameters["@Type"].Value=Session["UserTypeId"].ToString();
					cmd.Parameters.Add ("@Pd", SqlDbType.NVarChar);
					cmd.Parameters["@Pd"].Value=txtPd.Text;
					cmd.Parameters.Add ("@PeopleId", SqlDbType.Int);
					cmd.Parameters["@PeopleId"].Value=lstPerson.SelectedItem.Value;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				
					Done();
				}
			}
				catch (SqlException err)
			{
				if (err.Message.StartsWith ("Violation of UNIQUE")) 
				{
					lblAction.Text = "This User ID already exists, please use a different one.";
					lblAction.BackColor=Color.Red;
					lblAction.ForeColor=Color.White;
				}
				else lblAction.Text = err.Message;
			}
				//Violation of UNIQUE KEY constraint 'IX_UserId'. 
		}
		private void createHousehold()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Insert into Organizations"
				+ "(Name, ContactPerson, Status) Values"
				+ "('" + Session["OrgName"] + "'"
				+ ",'" + Session["OPhone"] + "'"
				+ ",'" + Session["OEmail"] + "'"
				+ ",'" + Session["OAddr"] + "'"
				+ ",'" + Session["ContactName"] + "'"
				+ ",'New')";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdUsers"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void btnPerson_Click(object sender, System.EventArgs e)
		{
			Session["CallerUpdPeople"]="frmUpdUsers";
			Response.Redirect (strURL + "frmUpdPeople.aspx?"
			+ "&btnAction1=Add");
		}

		protected void btnOrgs_Click(object sender, System.EventArgs e)
		{
			Session["OrgType"]="Organization";
			Session["CallerUpdOrg"]="frmUpdUsers";
			Session["btnAction"]="Add";
			Response.Redirect (strURL + "frmUpdOrg.aspx?"
				+ "&Parent=" + Session["OrgIdP"].ToString());
		
		}

	}	
}
