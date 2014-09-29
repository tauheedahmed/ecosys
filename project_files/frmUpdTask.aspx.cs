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
	public partial class frmUpdTask : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private string I;
		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexOfProcs (string s)
		{
			return (lstProcs.Items.IndexOf (lstProcs.Items.FindByValue(s)));
		}
		private int GetIndexOfStatus (string item)
		{
			if (btnAction.Text == "Update")
			{
				if (item.Trim() == "Planned")
				{
					return 0;
				}
				else if (item.Trim() == "Open") 
				{
					return 1;
				}
				else if (item.Trim() == "Closed")
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
		}		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			if (!IsPostBack)
			{
				//loadLocations();
				//loadProcs();
			
				lblOrg.Text=(Session["OrgName"]).ToString();
				btnAction.Text= Request.Params["btnAction"];
				lblContent.Text=btnAction.Text + " Task";	
				txtName.Text=Request.Params["Name"];
				txtStartTime.Text=Request.Params["StartTime"];
				txtEndTime.Text=Request.Params["EndTime"];
				/*rblStatus.SelectedIndex = GetIndexOfStatus (Request.Params["Status"]);
				lstProcs.SelectedIndex = GetIndexOfProcs (Request.Params["ProcId"]);
				if (Request.Params["btnAction"] == "Add")
				{
					lstLocations.Visible=false;
					lblLocs.Text="Location: " + Session["LocationName"].ToString();
				}
				else
				{
					lstLocations.SelectedIndex= GetIndexOfLocs (Request.Params["LocId"]);
				}*/
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

		private void loadLocations() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Locations.Id, Locations.Name from Locations"
				+ " inner join Organizations on Locations.OrgId=Organizations.Id"
				+ " Where LicenseId =" +  Session["LicenseId"].ToString()
				+ " Order by Locations.Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Locations");
			lstLocations.DataSource = ds;			
			lstLocations.DataMember= "Locations";
			lstLocations.DataTextField = "Name";
			lstLocations.DataValueField = "Id";
			lstLocations.DataBind();
		}
		private void loadProcs() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProcs";
			cmd.Parameters.Add ("@DomainId", SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@Visibility", SqlDbType.Int);
			cmd.Parameters["@Visibility"].Value="1";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Processes");
			lstProcs.DataSource = ds;			
			lstProcs.DataMember= "Processes";
			lstProcs.DataTextField = "Name";
			lstProcs.DataValueField = "Id";
			lstProcs.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			/*if (btnAction.Text == "Update") 
			//{
				//try
				//{*/
				
					SqlCommand cmd = new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateTask2";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id",SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse(Id);
					cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
					cmd.Parameters["@Name"].Value=txtName.Text;
					cmd.Parameters.Add ("@StartTime",SqlDbType.DateTime);
					if (txtStartTime.Text != "") cmd.Parameters["@StartTime"].Value=txtStartTime.Text;
					else cmd.Parameters["@StartTime"].Value = null;
					cmd.Parameters.Add ("@EndTime",SqlDbType.DateTime);
					if (txtEndTime.Text != "") cmd.Parameters["@EndTime"].Value=txtEndTime.Text;
					else cmd.Parameters["@EndTime"].Value = null;
					cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
					cmd.Parameters["@Status"].Value=rblStatus.SelectedItem.Value;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					Done();
				//}
				/*catch (SqlException err)
				{
					if (err.Message.StartsWith ("String was not recognized as a valid DateTime.")) 
						lblContent.Text = "Please enter Start and End Time in form mm/dd/yy (e.g. 10/11/08.";
					else lblContent.Text = err.Message;
				}
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				//cmd.CommandText="eps_AddActivation";
				cmd.CommandText = EPSBase.headingOrg(1);
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@StartTime",SqlDbType.DateTime);
				if (txtStartTime.Text != "") cmd.Parameters["@StartTime"].Value=txtStartTime.Text;
				else cmd.Parameters["@StartTime"].Value = null;
				cmd.Parameters.Add ("@EndTime",SqlDbType.DateTime);
				if (txtEndTime.Text != "") cmd.Parameters["@EndTime"].Value=txtEndTime.Text;
				else cmd.Parameters["@EndTime"].Value = null;
				cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
				cmd.Parameters["@Status"].Value=rblStatus.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				if (Session["CallerUpdTask"].ToString() == "frmTasks")
				{
					addPeople();
				}*/
				
				Done();
			//}

		}
		private void addPeople()
		{
			SqlCommand cmd1=new SqlCommand();
			cmd1.Connection=this.epsDbConn;
			cmd1.CommandType=CommandType.Text;
			cmd1.CommandText="Select Max(Id) from Tasks "
				+ " Where ServiceId =" + Session["ServiceId"].ToString();
			cmd1.Connection.Open();
			I=cmd1.ExecuteScalar().ToString();
			cmd1.Connection.Close();
 
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateTaskPeopleAuto";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
			cmd.Parameters["@TaskId"].Value= I;
			cmd.Parameters.Add ("@ServiceId",SqlDbType.Int);
			cmd.Parameters["@ServiceId"].Value= Session["ServiceId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdTask"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void btnLoc_Click(object sender, System.EventArgs e)
		{
			/*Session["CUpdLocs"]="frmUpdTask";
			Response.Redirect (strURL + "frmUpdLoc.aspx?"
				+ "&btnAction=" + "Add");*/
		}

		protected void btnDetails_Click(object sender, System.EventArgs e)
		{		
					Session["CallerTaskDetail"]="frmUpdTask";
					Response.Redirect (strURL + "frmTaskDetail.aspx?"
						//+ "&ServiceName=" + e.Item.Cells[1].Text
						//+ "&Start=" + e.Item.Cells[2].Text
						//+ "&End=" + e.Item.Cells[3].Text
						//+ "&RegStatus=" + e.Item.Cells[4].Text
						+ "&Desc=" 
						//+ "&StaffClient=" + e.Item.Cells[8].Text
						//+ "&TaskName=" +  e.Item.Cells[6].Text
						//+ "&EventName=" +  e.Item.Cells[11].Text
						//+ "&LicOrg=" +  e.Item.Cells[12].Text
						//+ "&MgrOrg=" +  e.Item.Cells[12].Text
						//+ "&LicId=" +  e.Item.Cells[14].Text					
						//+ "&Status=" + e.Item.Cells[15].Text	//				
						//+ "&Loc=" + e.Item.Cells[16].Text
						//+ "&LocAddress=" +  e.Item.Cells[17].Text
						//+ "&Comment=" +  e.Item.Cells[18].Text
						);
		}

	}	


}
