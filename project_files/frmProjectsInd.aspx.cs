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
	public partial class frmProjectsInd: System.Web.UI.Page
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
			DataGrid1.Columns[1].HeaderText=Session["EventName"].ToString();
			if (!IsPostBack)
			{	
				/*lblAddOth.Text = "To add planned or active "
					+ Session["PJNameS"].ToString()
					+ " created by other organizations and/or at other locations.";
				lblAddOwn.Text = "To access de-activated "
					+ Session["PJNameS"].ToString()
					+ " created at this location by this organization.";
				lblAddNew.Text = "To create a new "
					+ Session["PJNameS"].ToString()
					+ " at this location by this organization.";*/
                if (Session["MgrName"] != null)
                {
                    lblMgr.Text = Session["MgrName"].ToString();
                }
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				lblLocation.Text="Location: " + Session["LocationName"].ToString();
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
				lblContents1.ForeColor=System.Drawing.Color.Maroon;
				lblContents1.Text="Note:  There are no "
					+ Session["PJName"].ToString()
					+ " activated by the event '"
					+ Session["EventName"].ToString()
					+ "' that are currently active at this location."
					+ " You may identify a new such "
					+ Session["PJNameS"].ToString()
					+ " at this or some other location by clicking on "
					+ " the appropriate button below.";
			}
			else
			{
				lblContents1.Text="Listed below are "
					+ Session["PJName"].ToString()
					+ " of type '"
					+ Session["EventName"].ToString()
					+ "' which are currently active at this location."
					+ " You may add an existing or new "
					+ Session["PJNameS"].ToString()
					+ " by clicking on "
					+ " the appropriate button below.  For each "
					+ Session["PJNameS"].ToString() 
					+ " on this list, you may "
					+ " update the name and other details of the "
					+ Session["PJNameS"].ToString()
					+ ", create or update the "
					+ Session["PJName"].ToString()
					+ ", and/or generate a report reflecting these updates.";
				btnDeAct.Text="De-Activated " + Session["PJName"].ToString();
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				//refreshGrid();
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		/*private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
				{
					Button cb = (Button)(i.Cells[3].FindControl("btnProj"));
					Button cba = (Button)(i.Cells[3].FindControl("btnDeActivate"));
					Button cbb = (Button)(i.Cells[4].FindControl("btnCancel"));
					cb.Text = Session["PJNameS"].ToString();
					if (i.Cells[6].Text == "Planned")
						{
							cba.Text = "Activate";
							cba.CommandName = "Activate";
						}
				if (i.Cells[5].Text.StartsWith("&") == false)
				{
					cba.Text = "Remove";
					cba.CommandName = "Remove";
					cbb.Visible=false;
				}

				}
		}*/
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPI"].ToString() + ".aspx?");
		}

		private void rpts()
		{
			Session["cRG"]="frmProjectsInd";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["ProjName"]=e.Item.Cells[1].Text;
			if (e.CommandName == "Timetable")
			{
				ParameterFields paramFields = new ParameterFields();
				ParameterField paramField = new ParameterField();
				ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
				paramField.ParameterFieldName = "ProjectsId";
				discreteval.Value = e.Item.Cells[0].Text;
				paramField.CurrentValues.Add (discreteval);
				paramFields.Add (paramField);
				Session["ReportParameters"] = paramFields;
				Session["ReportName"] = "rptTTInd.rpt";
				rpts();				
			}
			else if (e.CommandName == "Status")
			{
				Session["CUpdProject"]="frmProjectsInd";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProject.aspx?");
					
			}
			else if (e.CommandName == "Tasks")
			{
				Session["CT"]="frmProjectsInd";
				Session["ProjectId"]=e.Item.Cells[0].Text;
				Session["ProjName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmTasks.aspx?");					
			}
			/*else if (e.CommandName == "Pay")
			{
				Session["CPay"]="frmProjectsInd";
				//Session["PSEventsId"] = e.Item.Cells[0].Text;- Session["PSEventsId"]
				//Session["EventName"]Session["EventName"] 
				Session["ProcProcuresId"] = e.Item.Cells[0].Text;
				//Session["CPay"]="frmContracts";
				//Session["LocName"]=e.Item.Cells[1].Text; - Session["LocationName"]
				Session["TaskName"]=e.Item.Cells[2].Text;
				Session["SupplierName"]=e.Item.Cells[4].Text;
				Session["GSName"]=e.Item.Cells[5].Text;
				Response.Redirect (strURL + "frmPayments.aspx?");
			}*/
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="wms_DeleteProjectPeople";
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[5].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Cancel")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="wms_UpdateProjectC";
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[0].Text);
				cmd.Parameters.Add ("@Status", SqlDbType.Int);
				cmd.Parameters["@Status"].Value=3;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "DeActivate")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="wms_UpdateProjectC";
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[0].Text);
				cmd.Parameters.Add ("@Status", SqlDbType.Int);
				cmd.Parameters["@Status"].Value=2;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			else if (e.CommandName == "Activate")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="wms_UpdateProjectC";
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(e.Item.Cells[0].Text);
				cmd.Parameters.Add ("@Status", SqlDbType.Int);
				cmd.Parameters["@Status"].Value=1;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}

		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CPSel"]="frmProjectsInd";
			Response.Redirect (strURL + "frmProjectsSel.aspx?");
		}

		protected void btnAddOth_Click(object sender, System.EventArgs e)
		{
			Session["CPSel"]="frmProjectsInd";
			Response.Redirect (strURL + "frmProjectsSelO.aspx?");
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Session["CUpdProject"]="frmProjectsInd";
			Response.Redirect (strURL + "frmUpdProject.aspx?");	
		}
	}
}

