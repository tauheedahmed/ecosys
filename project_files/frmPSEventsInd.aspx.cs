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
	/// Summary description for frmOrgResTypes1.
	/// </summary>
	public partial class frmPSEventsInd : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
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
			//getTRSFlag();
			getFlagsMgr();
			if (Session["Mgr"].ToString() == "0")
			{
				btnAdd.Visible=false;
				DataGrid1.Columns[3].Visible=false;
			}
			else
			{
				btnAdd.Text="Add";
				getBRS();
				getWPS();
				getPRS();
			}
			DataGrid1.Columns[1].HeaderText = Session["PJName"].ToString();
			if (!IsPostBack)
			{	
				lblMgr.Text=Session["MgrName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				lblDel.Text="Deliverable: " + Session["EventName"].ToString();
				lblLocation.Text="Location: " + Session["LocationName"].ToString();
				lblContents1.Text="Click on the buttons below titled 'Procedures', 'Staff' and/or 'Non-Staff Resources'"
					+ " to generate reports providing this reference information to help you carry out your"
					+ " tasks related to the above deliverable." ;
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjectsInd";
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Int32.Parse(Session["PeopleId"].ToString());
			cmd.Parameters.Add ("@PSEventId",SqlDbType.Int);
			cmd.Parameters["@PSEventId"].Value=Int32.Parse(Session["PSEventsId"].ToString());
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Int32.Parse(Session["OrgLocId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
			if (ds.Tables["Projects"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				if (Session["Mgr"].ToString() == "1")
				{
						lblContents2.Text="There are no active "
						+ Session["PJName"].ToString()
						+ " that have been identified related to the above deliverable."
						+ "Click on 'Add' to identify a new "
						+ Session["PJNameS"].ToString()
						+ ". Or Click on 'Update Past "
						+ Session["PJName"].ToString()
						+ "' to access past" 
						+ Session["PJName"].ToString() + ".";
				}
			}
			else if (ds.Tables["Projects"].Rows.Count == 1)
			{
				if (Session["Mgr"].ToString() == "1")
				{
					lblContents2.Text="The following "
						+ Session["PJNameS"].ToString()
						+ " is currently active."
						+ " Click on 'Tasks' to create or update timetables,"
						+ " and assign resources for individual tasks related to this "
						+ Session["PJNameS"].ToString()
						+ ". Click on '"
						+ Session["PJNameS"].ToString()
						+ "' to update this "
						+ Session["PJNameS"].ToString()
						+ ". Click on 'Add' to add an additional "
						+ Session["PJNameS"].ToString() + ".";
				}
				else
				{
					lblContents2.Text="The following " + Session["PJNameS"].ToString()
						+ " is currently active. Click on the appropriate button below to "
						+ " generate more specific information related to this "
						+ Session["PJNameS"].ToString();
				}
			}
			else
			{
				lblContents2.Text="The following "
					+ Session["PJName"].ToString()
					+ " are currently active. ";
				if (Session["Mgr"].ToString() == "1")
				{
					lblContents2.Text="The following "
						+ Session["PJName"].ToString()
						+ " are currently active. Click on 'Tasks' to create or update timetables, "
						+ " and assign resources for individual tasks related to this "
						+ Session["PJNameS"].ToString()
						+ ". Click on 'Update' to update a given "
						+ Session["PJNameS"].ToString()
						+ ". Click on 'Add' to add an additional "
						+ Session["PJNameS"].ToString() + ".";
				}
				else
				{
					lblContents2.Text="The following" + Session["PJName"].ToString()
						+ " are currently active. Click on the appropriate button below to "
						+ " generate more specific information related to a given "
						+ Session["PJNameS"].ToString();
				}
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (Session["Mgr"].ToString() == "1")
			{
				refreshGrid();
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button cb = (Button)(i.Cells[3].FindControl("btnUpd"));
				cb.Text=Session["PJNameS"].ToString();
			}
		}
		private void getFlagsMgr()//wp menu - person identified as mgr for orgloc
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveFlagsMgr";
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Mgr");
			if (ds.Tables["Mgr"].Rows[0][0].ToString() == "0")
			{
				Session["Mgr"]= 0;
			}
			else
			{
				Session["Mgr"]= 1;
			}
		}
		private void getBRS()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsBRS";
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"BRS");
			if (ds.Tables["BRS"].Rows[0][0].ToString() == "0")
			{
				Session["BRS"]= 0;
			}
			else
			{
				Session["BRS"]= 1;
			}
		}
		private void getWPS()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsWPS";
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"WPS");
			if (ds.Tables["WPS"].Rows[0][0].ToString() == "0")
			{
				Session["WPS"]= 0;
			}
			else
			{
				Session["WPS"]= 1;
			}
		}
		private void getPRS()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsPRS";
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PRS");
			if (ds.Tables["PRS"].Rows[0][0].ToString() == "0")
			{
				Session["PRS"]= 0;
			}
			else
			{
				Session["PRS"]= 1;
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CPSEInd"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["ProjectId"]=e.Item.Cells[0].Text;
			if (e.CommandName == "Timetable")
			{
				ParameterFields paramFields = new ParameterFields();

				ParameterField paramField = new ParameterField();
				ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
				paramField.ParameterFieldName = "PSEventsId";
				discreteval.Value = Int32.Parse(e.Item.Cells[0].Text);
				paramField.CurrentValues.Add (discreteval);
				paramFields.Add (paramField);

				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptProjTypeTT.rpt";
				rpts();
			}
			else if (e.CommandName == "Staff")
			{
				ParameterFields paramFields = new ParameterFields();

				ParameterField paramField = new ParameterField();
				ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
				paramField.ParameterFieldName = "OrgId";
				discreteval.Value = Session["OrgId"].ToString();
				paramField.CurrentValues.Add (discreteval);
				paramFields.Add (paramField);

				ParameterField paramField2 = new ParameterField();
				ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
				paramField2.ParameterFieldName = "OrgLocId";
				discreteval2.Value = Session["OrgLocId"].ToString();
				paramField2.CurrentValues.Add (discreteval2);
				paramFields.Add (paramField2);

				ParameterField paramField3 = new ParameterField();
				ParameterDiscreteValue discreteval3 = new ParameterDiscreteValue();
				paramField3.ParameterFieldName = "ProjectId";
				discreteval3.Value = Session["ProjectId"].ToString();
				paramField3.CurrentValues.Add (discreteval3);
				paramFields.Add (paramField3);

				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptProjStaff.rpt";
				rpts();				
			}
			else if (e.CommandName == "Res")
			{
				ParameterFields paramFields = new ParameterFields();
				ParameterField paramField1 = new ParameterField();
				ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
				paramField1.ParameterFieldName = "PSEventsId";
				discreteval1.Value = e.Item.Cells[0].Text;
				ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
				ParameterField paramField2 = new ParameterField();
				paramField2.ParameterFieldName = "ProjectId";
				discreteval2.Value = Int32.Parse(Session["ProjectId"].ToString());
				paramField1.CurrentValues.Add (discreteval1);
				paramFields.Add (paramField1);
				paramField2.CurrentValues.Add (discreteval2);
				paramFields.Add (paramField2);
				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptProjRes.rpt";
				rpts();	
					
			}
			else if (e.CommandName == "Update")
			{
				Session["CUpdProject"]="frmPSEventsInd";
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmUpdProject.aspx?");		
			}
			else if (e.CommandName == "Tasks")
			{
				Session["CT"]="frmPSEventsInd";
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmTasks.aspx?");					
			}	
			/*else if (e.CommandName == "Mgr")
			{
				Session["CPI"]="frmPSEventsInd";
				Session["PSEventsId"] = e.Item.Cells[0].Text;
				Session["EventName"] = e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmProjectsInd.aspx?");
			}*/		
		}
		private void rpts()
		{
			Session["cRG"]="frmPSEventsInd";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}

		protected void btnProcs_Click(object sender, System.EventArgs e)
		{

		}

		protected void btnStaff_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();

			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "PSEId";
			discreteval.Value = Int32.Parse(Session["PSEventsId"].ToString());
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			ParameterField paramField2 = new ParameterField();
			ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
			paramField2.ParameterFieldName = "OrgLocId";
			discreteval2.Value = Int32.Parse(Session["OrgLocId"].ToString());
			paramField2.CurrentValues.Add (discreteval2);
			paramFields.Add (paramField2);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptProcStaff.rpt";
			rpts();	
		}

		private void btnRes_Click(object sender, System.EventArgs e)
		{
			ParameterFields paramFields = new ParameterFields();

			ParameterField paramField = new ParameterField();
			ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
			paramField.ParameterFieldName = "PSEId";
			discreteval.Value = Int32.Parse(Session["PSEventsId"].ToString());
			paramField.CurrentValues.Add (discreteval);
			paramFields.Add (paramField);

			ParameterField paramField2 = new ParameterField();
			ParameterDiscreteValue discreteval2 = new ParameterDiscreteValue();
			paramField2.ParameterFieldName = "OrgLocId";
			discreteval2.Value = Int32.Parse(Session["OrgLocId"].ToString());
			paramField2.CurrentValues.Add (discreteval2);
			paramFields.Add (paramField2);

			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptProcRes.rpt";
			rpts();	
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdProject"]="frmPSEventsInd";
			Response.Redirect (strURL + "frmUpdProject.aspx?");	
		}


	}
}
