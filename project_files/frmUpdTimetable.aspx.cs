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
	public partial class frmUpdTimetable : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private int GetIndexOfStatus (string s)
		{
			switch(s)       
			{         
				case "Planned": 
					return 0;
				case "Active":   
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
                if (Session["MgrName"] == null)
                {
					lblMgr.Text=Session["OrgName"].ToString();
				}
				else
				{
					lblMgr.Text=Session["MgrName"].ToString()
                        ;
				}
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				lblLocation.Text="Location: " + Session["LocName"].ToString();
				lblProj.Text=Session["PJNameS"].ToString() 
					+ ": " + Session["ProjName"].ToString();
              
				lblTask.Text="Task Name: " 
					+ Session["ProcName"].ToString();
                lblContents1.Text = "Please enter dates in form mm/dd/yyyy)";
				loadData();
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
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveTimetable";
			cmd.Parameters.Add ("@PSEPId",SqlDbType.Int);
			cmd.Parameters["@PSEPId"].Value=Session["PSEPId"].ToString();
			cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString();
			/*cmd.Parameters.Add ("@OLPProjectsId",SqlDbType.Int);
			cmd.Parameters["@OLPProjectsId"].Value=Session["OLPProjectsId"].ToString();*/
			/*
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();*/
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Timetables");
			if (ds.Tables["Timetables"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.Text="Note:  There are no timetable steps related to this task"
					+ " that need to be monitored.";
				/*lblOrg.Text="PTPId: "+Session["ProjTypesPSEPId"].ToString()+
					" ProjectId: "+ Session["ProjectId"].ToString()+
				" OrgLocId: " + Session["OrgLocId"].ToString();*/
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbDate = (TextBox)(i.Cells[6].FindControl("txtCompletionDate"));
				CheckBox cbStatus = (CheckBox)(i.Cells[7].FindControl("cbxStatus"));
				if (i.Cells[0].Text.StartsWith("&") == false)
				{
					if (i.Cells[4].Text.StartsWith("&")  == true)
					{
						tbDate.Text="";
					}
					else
					{
						tbDate.Text= i.Cells[4].Text;
					}
					if (i.Cells[5].Text == "Actual")
					{
						cbStatus.Checked=true;
					}
				}
				else
				{
					tbDate.Text="";
				}

			}
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			updateTimetable();
			Done();
		}
		private void updateTimetable()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				if (i.Cells[0].Text.StartsWith("&") == false)
				{
					TextBox tbDate = (TextBox)(i.Cells[6].FindControl("txtCompletionDate"));
					CheckBox cbStatus = (CheckBox)(i.Cells[7].FindControl("cbxStatus")); 
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_UpdateTimetable";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id",SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse(i.Cells[0].Text);
					cmd.Parameters.Add ("@CompletionDate",SqlDbType.SmallDateTime);
					if (tbDate.Text != "") 
					{
						cmd.Parameters["@CompletionDate"].Value=tbDate.Text;
					}
					else 
					{
						cmd.Parameters["@CompletionDate"].Value = null;
					}		
					cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
					if (cbStatus.Checked)
					{
						cmd.Parameters["@Status"].Value="Actual";
					}
					else
					{
						cmd.Parameters["@Status"].Value="Plan";
					}
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
				else
				{
					TextBox tbDate = (TextBox)(i.Cells[6].FindControl("txtCompletionDate"));
					CheckBox cbStatus = (CheckBox)(i.Cells[7].FindControl("cbxStatus"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_AddTimetable";
					cmd.Connection=this.epsDbConn;
					//cmd.Parameters.Add ("@OLPProjectsId",SqlDbType.Int);
					//cmd.Parameters["@OLPProjectsId"].Value=Session["OLPProjectsId"].ToString();
					cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
					cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
					cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
					cmd.Parameters["@PSEPID"].Value=Session["PSEPId"].ToString();
                    cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                    cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                    cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
                    cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString());
					cmd.Parameters.Add ("@CompletionDate",SqlDbType.SmallDateTime);
					if (tbDate.Text != "") 
					{
						cmd.Parameters["@CompletionDate"].Value=tbDate.Text;
					}
					else 
					{
						cmd.Parameters["@CompletionDate"].Value = null;
					}		
					cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
					cmd.Parameters.Add ("@PSEPStepsId",SqlDbType.Int);
					cmd.Parameters["@PSEPStepsId"].Value=i.Cells[2].Text;
					if (cbStatus.Checked)
					{
						cmd.Parameters["@Status"].Value="Actual";
					}
					else
					{
						cmd.Parameters["@Status"].Value="Plan";
					}
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdTT"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		/*private void addTimetable()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjectStepsNew";
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Timetables");
			if (ds.Tables["Timetables"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.ForeColor=System.Drawing.Color.Maroon;
				lblContents1.Text="Note:  No timetable steps available."
					+ "Please contact your system administrator and request creation of timetable steps.";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}*/
		/*private void createTimetable()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbDate = (TextBox)(i.Cells[5].FindControl("txtCompletionDate"));
				CheckBox cbStatus = (CheckBox)(i.Cells[6].FindControl("cbxStatus"));
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_AddTimetable";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ProjectsId",SqlDbType.Int);
				cmd.Parameters["@ProjectsId"].Value=Session["ProjectId"].ToString();
				cmd.Parameters.Add ("@CompletionDate",SqlDbType.SmallDateTime);
				if (tbDate.Text != "") 
				{
					cmd.Parameters["@CompletionDate"].Value=tbDate.Text;
				}
				else 
				{
					cmd.Parameters["@CompletionDate"].Value = null;
				}		
				cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
				cmd.Parameters.Add ("@ProfileSEPStepsId",SqlDbType.Int);
				cmd.Parameters["@ProfileSEPStepsId"].Value=Int32.Parse(i.Cells[2].Text);
				if (cbStatus.Checked)
				{
					cmd.Parameters["@Status"].Value="Actual";
				}
				else
				{
					cmd.Parameters["@Status"].Value="Plan";
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
		}*/
/*		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Staff")
			{		
				Session["PSEPSId"]=e.Item.Cells[1].Text;
				Session["StepName"]=e.Item.Cells[2].Text;
				Session["CPStaff"]="frmUpdProject";
				Response.Redirect (strURL + "frmProjStepStaff.aspx?");
				
			}
			else if (e.CommandName == "Resources")
			{
				Session["PSEPSId"]=e.Item.Cells[1].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[2].Text;
				Session["CSEPResTypes"]="frmOLPSEPSteps";
				Response.Redirect (strURL + "frmOLPSEPSRes.aspx?");
			}
			else if (e.CommandName == "Services")
			{			
				Session["PSEPSId"]=e.Item.Cells[1].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[2].Text;
				Session["CSEPServices"]="frmOLPSEPSteps";
				Response.Redirect (strURL + "frmOLPSEPSSer.aspx?");				
			}

		}
		*/

	}	


}
