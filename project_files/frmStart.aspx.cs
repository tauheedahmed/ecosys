using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Threading;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmStart.
	/// </summary>
	public partial class frmStart : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		//public String j;
		private string I;

		protected void Page_Load(object sender, System.EventArgs e)
		{
            btnChange.Focus();
			if (!IsPostBack) 
			{	
			getMessage();
			}
			/*j="x" + Request.Params["msg"];
			if ((Convert.ToString(j)).Length == 1)
			{
				lblLic.Text="Note:  Access to these systems requires a license.";
				
			}
			else 
			{
				btnNewUsers.Visible=false;
				lblLic.Text="Your license request has been created."
					+ " You will be contacted directly when your license is activated"
					+ " In the meantime, please contact"
					+ " SPS at 301-963-4777 Ext 64 in case of questions";
			} */			
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
		protected void btnContinue_Click(object sender, System.EventArgs e)
		{
			I="CallMenu";
			loadData();
		}
		private void loadData()
		{
			//Step 1:  Retrieve data for User id
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveLicenseOrg";
			cmd.Parameters.Add("@UserId",SqlDbType.NVarChar);
			cmd.Parameters["@UserId"].Value=txtUserName.Text;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Org");

			
			//Step 2 Do validations
			if (ds.Tables["Org"].Rows.Count == 0)
				if (I == "CallMenu")
				{
					lblError.Text = "Invalid or Missing User Id!";
				}
				else 
				{
					lblError.Text = "Invalid or Missing User Id!"
						+ "  To change your User Id and/or Password"
						+ " you must first enter your current User Id and Password.";
				}			
			else 
			{
				if (txtPassword.Text != ds.Tables["Org"].Rows[0][6].ToString())
				{
					lblError.Text = "Invalid Password!";
				}
					
				else
				{
					if ((ds.Tables["Org"].Rows[0][8].ToString().Trim() == "InActive")
						|| (ds.Tables["Org"].Rows[0][8].ToString().Trim() == "Activate"))
					{
						lblError.Text = "Inactive License";
					}
					else if (ds.Tables["Org"].Rows[0][8].ToString().Trim() != "Active")
					{
						lblError.Text = "Not Licensed";
					}
					else if (ds.Tables["Org"].Rows[0][12].ToString().Trim() != "Active")
					{
						lblError.Text = "This User Id has been DeActivated.";
					}
				
						//if today's date GE [ds.Tables["Org"].Rows[0][3].ToString()] 
						// + ds.Tables["Org"].Rows[0][4].ToString() then 
						// {} else {}
					else
					{
						if (passwordExpired (ds.Tables["Org"].Rows[0][11].ToString()))
						{
							lblError.Text = "Password Expired.";//changePassword();
						}
						else

							//Step 4.  Set Session parameters
						Session["UserId"]=txtUserName.Text;
						Session["OrgId"]=ds.Tables["Org"].Rows[0][0].ToString();
						Session["OrgName"]=ds.Tables["Org"].Rows[0][1].ToString();
						Session["OrgIdP"]=ds.Tables["Org"].Rows[0][2].ToString();
						Session["LicDate"]=ds.Tables["Org"].Rows[0][3].ToString();
						Session["LicenseId"]=ds.Tables["Org"].Rows[0][7].ToString();
						Session["LicStatus"]=ds.Tables["Org"].Rows[0][8].ToString();
						Session["startForm"]=ds.Tables["Org"].Rows[0][9].ToString();
						Session["DomainId"]=ds.Tables["Org"].Rows[0][13].ToString();
						Session["Email"]=ds.Tables["Org"].Rows[0][14].ToString();
						Session["OrgNameP"]=ds.Tables["Org"].Rows[0][15].ToString();
						Session["UserIdId"]=ds.Tables["Org"].Rows[0][17].ToString();
						Session["OrgVis"]=ds.Tables["Org"].Rows[0][18].ToString();
						Session["PName"]=ds.Tables["Org"].Rows[0][19].ToString();
						Session["COrg"]=ds.Tables["Org"].Rows[0][20].ToString();
                        Session["UserLevel"] = ds.Tables["Org"].Rows[0][21].ToString();
						
						//Step 5:  Create Household if necessary
						
						if (Session["startForm"].ToString() == "frmMainPers")
							if (Session["OrgId"].ToString() == Session["COrg"].ToString())
							{
								createHousehold();
								updateSessionparams();
								updateUserId();
							}

						//Step 6:  Call appropriate starting menu
						if (I.ToString() == "UserChange")
						{
							Response.Redirect (strURL + "frmUserIdChange.aspx?");
						}
						else
						{
							callMenu();
						}
					}
				}
			}
		}
		private void getMessage()
		{
/* KST2008			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_Retrievemsg";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Msg");
			if (ds.Tables["msg"].Rows.Count == 1)
			{
				lblMsg.Text=ds.Tables["msg"].Rows[0][0].ToString();
			}
*/
		}
		private void createHousehold()
		{
			Random J = new Random ();
			int num = J.Next();
			Session["J"]=num;
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Insert into Organizations"
				+ "(Name, Status, LicenseId, ParentOrg, IdMap, OrgType) Values"
				+ "('" + Session["PName"] + "'"
				+ ",'Active'"
				+ ",'" + Session["LicenseId"].ToString() + "'"
				+ ",'" + Session["OrgIdP"].ToString() + "'"
				+ ",'" + Session["J"].ToString() + "'"
				+ ",'Household')";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void updateSessionparams()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Select Id, Name from Organizations "
				+ "Where IdMap=" + Session["J"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Org");
			Session["OrgId"]=ds.Tables["Org"].Rows[0][0].ToString();
			Session["OrgName"]=ds.Tables["Org"].Rows[0][1].ToString();
			lblError.Text=Session["OrgId"].ToString() + " Name: " 
				+ Session["OrgName"].ToString()+ " Corg:"
				+ Session["COrg"].ToString() ;
		}
		private void updateUserId()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandText=" Update UserIds "
				+ "Set OrgId=" + "'" + Session["OrgId"].ToString() + "' "
				+ " Where UserId=" + "'" + Session["UserId"].ToString() + "'";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

		}
		private void callMenu()
		{
			Response.Redirect (strURL + Session["startForm"].ToString() + ".aspx?");
		}

		private bool passwordExpired (string creationDate)
		{
			TimeSpan dateDifference;
			dateDifference = DateTime.Now.Date - ((DateTime.Parse (creationDate)).Date);
			if (dateDifference.Days > 365000)
			{
				lblError.Text = "Your password has expired!  You will automatically be redirected to change your password.";
				//Thread.Sleep (10000);
				return true;
			}
			else return false;
		}

		private void changePassword()
		{
			Response.Redirect (strURL + "frmSendMail.aspx?");
		}

		protected void btnNewUsers_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmLicenseTerms.aspx?");
			//	+ "&Ltype='EPS'");		
		}

		private void btnForgetfulUsers_Click(object sender, System.EventArgs e)
		{
		
		}

		protected void btnChange_Click(object sender, System.EventArgs e)
		{
			I="UserChange";
			loadData();	
		}

        protected void btnIntro_Click(object sender, EventArgs e)
        {
            lblIntro1.Visible=true;
            lblIntro1a.Visible = true;
            lblIntro1b.Visible = true;
            lblIntroh1.Visible = true;
            lblIntro2.Visible = true;
            lblIntro2a.Visible = true;
            lblIntroh2.Visible = true;
            lblIntroh3.Visible = true;
            lblIntro3a.Visible = true;
            btnClose.Visible = true;
            btnIntro.Visible = false;
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            lblIntro1.Visible = false;
            lblIntro1a.Visible = false;
            lblIntro1b.Visible = true;
            lblIntroh1.Visible = false;
            lblIntroh3.Visible = true;
            lblIntro2.Visible = false;
            lblIntro2a.Visible = false;
            lblIntroh2.Visible = false;
            lblIntroh3.Visible = true;
            lblIntro3a.Visible = false;
            btnClose.Visible = false;
            btnIntro.Visible = true;
        }
        protected void btnHH_Click(object sender, EventArgs e)
        {

            Session["CHH"] = "frmStart";
            Response.Redirect(strURL + "frmMainHH.aspx?");
        }
}
}
