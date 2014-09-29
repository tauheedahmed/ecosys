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
	public partial class frmLicenseConfirm : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.Label lblAccept;
		//Random I;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			loadOrg();
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

		private void loadOrg()
		{
			try 
			{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandText=" Insert into Organizations"
					+ "(Name, Phone, Email, Address, FName, LName, Status) Values"
					+ "('" + Session["OrgName"] + "'"
					+ ",'" + Session["OPhone"] + "'"
					+ ",'" + Session["OEmail"] + "'"
					+ ",'" + Session["OAddr"] + "'"
					+ ",'" + Session["ContactFName"] + "'"
					+ ",'" + Session["ContactLName"] + "'"
					+ ",'New')";
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				lblThanks.Text="Thank you for your interest in using the SPS Application Systems."
					+ " You will be contacted directly if needed, and when your license is activated."
					+ " In the meantime, please do not hesitate to call "
					+ " SPS at 301-963-4777 Ext 64 in case of questions."
					+ " Alternatively, you may email your query to Ahmed.Tauheed@spsnet.com";
				Session.Clear();
				/*Response.Redirect (strURL + "frmStart.aspx?"
					+ "&msg=Yes");*/
			}
			catch (SqlException err)
			{
				if (err.Message.StartsWith ("Violation of UNIQUE")) 
					Label11.Text = "This User ID already exists, please use a different one.";
				else Label11.Text = err.Message;
			}
		}
		protected void btnContinue_Click(object sender, System.EventArgs e)
		{
			try 
			{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandText=" Insert into Organizations"
					+ "(Name, Phone, Email, Address, ContactPerson, Status /*UserIdOrig*/) Values"
					+ "('" + Session["OrgName"] + "'"
					+ ",'" + Session["OPhone"] + "'"
					+ ",'" + Session["OEmail"] + "'"
					+ ",'" + Session["OAddr"] + "'"
					+ ",'" + Session["ContactName"] + "'"
					+ ",'New')";
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				lblThanks.Text="Thank you for your interest in using the SPS Application Systems."
					+ " You will be contacted directly if needed, and when your license is activated"
					+ " In the meantime, please do not hesitate to call "
					+ " SPS at 301-963-4777 Ext 64 in case of questions."
					+ " Alternatively, you may email your query to Ahmed.Tauheed@spsnet.com";
				Session.Clear();
				/*Response.Redirect (strURL + "frmStart.aspx?"
					+ "&msg=Yes");*/
			}
			catch (SqlException err)
			{
				if (err.Message.StartsWith ("Violation of UNIQUE")) 
					Label11.Text = "This User ID already exists, please use a different one.";
				else Label11.Text = err.Message;
			}
		}
		private void verifyPW()
		{
			//	Validate: PW max 12 characters, min 10 characters
			//	Validate: txtPassword=txtPasswordcheck
		}
		private void createUserId()
		{// Kashif:  Add try/Catch Error if UserId is already present in Org
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Insert into UserIds"
				+ "(UserId, Password, MenuType) Values"
				+ "('" + txtUserId.Text.Trim() + "'"
				+ ",'" + txtPassword.Text + "'"				
				+ ",'" + Session["MenuType"] + "'"
				+ ")";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();	
			cmd.Connection.Close();
			Session["UserId"]=txtUserId.Text.Trim();
			Session["Password"]=txtPassword.Text.Trim();
		}

		private void createOrg()
		{
			if (Session["MenuType"].ToString() == "Organization")
			{
				//I=I.Next();
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandText=" Insert into Organizations"
					+ "(Name, Phone, Email, Address, /*UserIdOrig*/) Values"
					+ "('" + Session["OrgName"] + "'"
					+ ",'" + Session["OPhone"] + "'"
					+ ",'" + Session["OEmail"] + "'"
					+ ",'" + Session["OAddr"] + "'"
					+ ",'" + Session["ContactName"] + "'"
					//+ ",'" + I + "'"
					+ ")";
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			else
			{
				Session["PersonName"]=Session["FName"] + " " + Session["LName"];
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandText=" Insert into Organizations"
					+ "(Name, UserIdOrig) Values"
					+ "('" + Session["PersonName"].ToString() + "'"
					+ ",'" + Session["UserId"] + "'"
					+ ")";
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}

		}
		
		private void retrieveOrgId()
		{	
			SqlCommand cmd=new SqlCommand();
			
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id From Organizations"
				+ " Where UserIdOrig=" + "'" + Session["UserId"].ToString() + "'";
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"UserId");
			Session["OrgId"]=(ds.Tables["UserId"].Rows[0][0]).ToString();
		}
		private void createPeople()
		{		
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_AddPeople";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@FName",SqlDbType.NVarChar);
			cmd.Parameters["@FName"].Value= Session["FName"];
			cmd.Parameters.Add ("@LName",SqlDbType.NVarChar);
			cmd.Parameters["@LName"].Value= Session["LName"];
			cmd.Parameters.Add ("@Addr",SqlDbType.NText);
			cmd.Parameters["@Addr"].Value= Session["Address"];
			cmd.Parameters.Add ("@Email", SqlDbType.NVarChar);
			cmd.Parameters["@Email"].Value=Session["Email"];
			cmd.Parameters.Add ("@HPhone", SqlDbType.NVarChar);
			cmd.Parameters["@Hphone"].Value=Session["HPhone"];
			cmd.Parameters.Add ("@WPhone", SqlDbType.NVarChar);
			cmd.Parameters["@Wphone"].Value=Session["WPhone"];
			cmd.Parameters.Add ("@CPhone", SqlDbType.NVarChar);
			cmd.Parameters["@Cphone"].Value=Session["CPhone"];
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Int32.Parse(Session["OrgId"].ToString());
			//cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			//cmd.Parameters["@LicenseId"].Value=0;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void retrievePeopleId()
		{	
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id From People"
				+ " Where OrgId=" + "'" + Session["OrgId"] + "'";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"People");
			Session["PeopleId"]=(ds.Tables["People"].Rows[0][0]);
		}
		private void createLicense()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;			
			cmd.CommandText="Insert into Licenses"
				+ "(EulaId, OrgId, PeopleId, DomainId, LicenseStatus) Values"
				+ "('" + Session["EulaId"].ToString() + "'"
				+ ",'" + Session["OrgId"].ToString() + "'"
				+ ",'" + Session["PeopleId"].ToString() + "'"
				+ ",'" + Session["DomainId"].ToString() + "'"
				+ ",'InActive'"
				+ ")";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void retrieveLicenseId()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id From Licenses"
				+ " Where OrgId=" + "'" + Session["OrgId"] + "'";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Licenses");
			Session["LicenseId"]=(ds.Tables["Licenses"].Rows[0][0]).ToString();
			
		}
		private void updateUserId()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Update UserIds"
				+ " Set OrgId=" + "'"+ Session["OrgId"] + "',"
				+ " PeopleId=" + "'"+ Session["PeopleId"] + "',"
				+ " CreationDate=" + "'"+ DateTime.Now.Date + "',"
				+ " Status='Active',"
				+ " PasswordUpdate=" + "'"+ DateTime.Now.Date + "'"
				+ " Where UserId=" + "'" + Session["UserId"] + "'";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void updateOrg()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Update Organizations"
				+ " Set ParentOrg=" + "'"+ Session["OrgId"] + "'"
				+ "," + " LicenseId=" + "'"+ Session["LicenseId"] + "'"
				+ " Where Id=" + "'" + Session["OrgId"] + "'";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void updatePeople()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Update People"
				+ " Set LicenseId=" + "'"+ Session["LicenseId"] + "'"
				+ " Where Id=" + "'" + Session["PeopleId"] + "'";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmStart.aspx?");
		}
	}
}
