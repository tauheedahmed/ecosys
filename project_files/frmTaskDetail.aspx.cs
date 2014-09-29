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
	public partial class frmActivationDetail : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		//private string I;
		
		/*private int GetIndexStatus (string item)
		{
			switch(item)
			{
				case "":
				case "Registered":
					return 0;
					break;
				default:
					return 1;
					break;
			}
					
						
				{
				if (item.Trim() == "Registered")
				{
					return 0;
				}
				else if (item.Trim() == "Ended") 
				{
					return 2;
				}
				else if (item.Trim() == "Cancelled")
				{
					return 3;
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
		}		*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];

			if (Request.Params["MgrOrg"].ToString() == Request.Params["LicOrg"].ToString())
			{
				lblOrg.Visible=false;
				lblLicOrg.Text=Request.Params["LicOrg"].ToString() 
					+ " (" + "License No. " + Request.Params["LicId"].ToString()+ ")";
			}
			else
			{
				lblOrg.Text=Request.Params["MgrOrg"].ToString();
				lblLicOrg.Text=Request.Params["LicOrg"].ToString() 
					+ " (" + "License No. " + Request.Params["LicId"].ToString()+ ")";
			}
			
			txtDesc.Text=Request.Params["Desc"].ToString();
			lblActName.Text=Request.Params["TaskName"].ToString() + " (Status: "
				+ Request.Params["Status"].ToString() + ")";
			lblComment.Text=Request.Params["Comment"].ToString();
			if (lblComment.Text == "")
			{
				lblComment.Visible=false;
			}
			txtStartTime.Text=Request.Params["Start"].ToString();
			txtEndTime.Text=Request.Params["End"].ToString();
			txtLoc.Text=Request.Params["Loc"].ToString();
			txtLocAddress.Text=Request.Params["LocAddress"].ToString();
				
			switch(Request.Params["ServiceType"].ToString())
			{
				case "":

				case "47":
					lblService.Text="Class Name: " + Request.Params["TaskName"].ToString();
					lblDesc.Text="Course Description:";
					lblLicOrg.Text="Course Provider: " + Request.Params["LicOrg"].ToString() 
						+ " (" + "License No. " + Request.Params["LicId"].ToString()+ ")";
					break;
				case "51":
					lblService.Text="Type of Emergency: " 
						+  Request.Params["TaskName"].ToString();
					lblDesc.Text="Task Description:";
					lblLicOrg.Text="Incident Manager: " + Request.Params["LicOrg"].ToString() 
						+ " (" + "License No. " + Request.Params["LicId"].ToString()+ ")";
					break;
				default:
					lblService.Text="Type of Event: " 
						+ Request.Params["TaskName"].ToString();
					lblDesc.Text="Task Description:";
					lblLicOrg.Text="Service Provider: " + Request.Params["LicOrg"].ToString() 
						+ " (" + "License No. " + Request.Params["LicId"].ToString()+ ")";
					break;
			}
			switch (Request.Params["Type"].ToString())
			{
				case "":
				case "Client":
					lblAptStatus.Text="Your Registration Status: " 
						+ Request.Params["RegStatus"].ToString();
					break;
				default:
					lblAptStatus.Text="Your Appointment Status: " 
						+ Request.Params["RegStatus"].ToString();
					break;
			}		
			
			if (!IsPostBack)
			{
				


				//loadLocations();
				/*if ((Request.Params["ActivationName"].ToString() == "Licenses")
					& (Request.Params["btnExit"].ToString() == "Update"))
				{
					btnDetails.Visible = true;
					btnDetails.Text = "License Details";
				}
				btnExit.Text= Request.Params["btnExit"];
				txtName.Text=Request.Params["Name"];				
				txtDesc.Text=Request.Params["Desc"];
				txtStartTime.Text=Request.Params["StartTime"];
				txtEndTime.Text=Request.Params["EndTime"];
				rblStatus.SelectedIndex = GetIndexType (Request.Params["Status"]);
				lstLocations.SelectedIndex = GetIndexOfLocs (Request.Params["LocId"]);*/
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
		}
		private void End()
		{
			Response.Redirect (strURL + Session["CallerActDetail"].ToString() + ".aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			End();
		}

		protected void lblComment_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnAction_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}