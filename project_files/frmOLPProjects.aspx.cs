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
using CrystalDecisions.Shared;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmOLPProjects: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblContents2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadForm();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadForm()
		{			
			DataGrid1.Columns[1].HeaderText=Session["ProjTypeName"].ToString();
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString()
					+ ", Location: "
					+ Session["LocationName"].ToString();
				loadData();
			}
				
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveOLPProjects";
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
			if (ds.Tables["Projects"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents1.ForeColor=System.Drawing.Color.Maroon;
				lblContents1.Text="Note:  There are no "
					+ Session["ProjTypeName"].ToString()
					+ " currently identified for this process (i.e. "
					+ Session["ProcName"].ToString()
					+ ") at this location (i.e. "
					+ Session["LocationName"].ToString()
					+ ").  Click on Add to continue.";
			}
			else
			{
				lblContents1.Text="Listed below are the "
					+ Session["ProjTypeName"].ToString()
					+ " to which the process '"
					+ Session["ProcName"].ToString() 
					+ "' is (or has been) applied at this location (i.e. "
					+ Session["LocationName"].ToString()
					+ ").  You may use the various buttons to maintain timetables, clients lists"
					+ " staffing lists, and goods and services needed to carry out this process.";

				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
			}
		}
		private void refreshGrid()
		{
			/*foreach (DataGridItem i in DataGrid1.Items)
			{
				if (Session["LicenseId"].ToString()==i.Cells[5].Text.ToString())
				{
					i.Cells[1].Text=i.Cells[4].Text.ToString();
				}
				else
				{
					i.Cells[1].Text=i.Cells[6].Text.ToString();
				}
				CheckBox cb = (CheckBox)(i.Cells[7].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from SkillCourses"
							+ " Where ProjectId = " + i.Cells[0].Text
							+ " and SkillId = " + Session["SkillId"].ToString();
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}*/
			//lblContent2.Text="List of " + Session["ProjName"].ToString();
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Exit();
			/*SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_DeleteSkillCourses";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@SkillId",SqlDbType.Int);
			cmd.Parameters["@SkillId"].Value=Session["SkillId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			updateGrid();
			Exit();*/
		}
		private void updateGrid()
		{
			/*foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox) (i.Cells[7].FindControl("cbxSel"));
					if (cb.Checked == true)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="wms_UpdateSkillCourses";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
						cmd.Parameters ["@ProjectId"].Value=i.Cells[0].Text;
						cmd.Parameters.Add("@SkillId", SqlDbType.Int);
						cmd.Parameters ["@SkillId"].Value=Session["SkillId"].ToString();
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}*/
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CProj"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CPOLPAdd"]="frmOLPProjects";
			Response.Redirect (strURL + "frmOLPProjectsAdd.aspx?");			
		}
		private void rpts()
		{
			Session["cRG"]="frmOLPProjects";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["ProjName"]=e.Item.Cells[1].Text;
			if (e.CommandName == "Report")
			{
				/*Session["CUpdProject"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				ParameterFields paramFields = new ParameterFields();
				ParameterField paramField = new ParameterField();
				ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
				paramField.ParameterFieldName = "ProjId";
				discreteval.Value = e.Item.Cells[0].Text;
				paramField.CurrentValues.Add (discreteval);
				paramFields.Add (paramField);
				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptTTs.rpt";
				rpts();	*/
					
			}
			else if (e.CommandName == "Update")
			{
				Session["CUpdProject"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProject.aspx?");
					
			}
			else if (e.CommandName == "Timetable")
			{
				Session["CUpdTT"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Session["OLPProjectsId"]=e.Item.Cells[7].Text;
				Response.Redirect (strURL + "frmUpdTimetable.aspx?");
					
			}
			else if (e.CommandName == "Clients")
			{
				Session["CPClient"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcClient.aspx?");
			}
			else if (e.CommandName == "Staff")
			{
				Session["CPStaff"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcStaff.aspx?");
			}
			else if (e.CommandName == "Services")
			{
				Session["CPSer"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=0;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcSer.aspx?");
			}
			else if (e.CommandName == "Other")
			{
				Session["CPSer"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=1;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcSer.aspx?");
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteOLPProject";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[7].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
				/*Session["CPStaff"]="frmOLPProjects";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmOLPProjectstaff.aspx?");
			}
			else if (e.CommandName == "Services")
			{
				Session["CPSer"]="frmOrgLocSEProcs";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["SGFlag"]=0;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProcSer.aspx?");
			}
			else if (e.CommandName == "Resources")
			{
				Session["CPRes"]="frmOrgLocSEProcs";
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Session["ProcName"]=e.Item.Cells[1].Text;
				Session["SGFlag"]=1;
				Response.Redirect (strURL + "frmProcRes.aspx?");
			}
			else */
		}

	}
}

