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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmOrgLocations : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAddTemp;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Procedures();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Procedures()
		{
            DataGrid1.Columns[5].Visible = false;
			if (Session["startForm"].ToString() == "frmMainBMgr")
			{
				lblOrg.Text=Session["MgrName"].ToString();
				DataGrid1.Columns[3].Visible=false;
			}
			else
			{
				lblOrg.Text=Session["OrgName"].ToString();
			}
			/*lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
			+ Session["CurrName"].ToString();*/
			if (!IsPostBack) 
			{	
				loadData();
			} 
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveOrgLocations";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			if (Session["startForm"].ToString() == "frmMainBMgr")
			{
				cmd.Parameters["@OrgId"].Value=Session["MgrId"].ToString();
			}
			else
			{
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			}
           
			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Locs");
			if (ds.Tables["Locs"].Rows.Count == 1)
			{
                if (Session["CallType"] == null)
                {
                    Session["CallType"] = "Forward";

                    Session["OrgLocId"] = ds.Tables["Locs"].Rows[0][0];
                     
                    Session["LocationName"] = ds.Tables["Locs"].Rows[0][1];
                    Session["ProfileId"] = ds.Tables["Locs"].Rows[0][2];
                    Session["LocationsId"] = ds.Tables["Locs"].Rows[0][3];
                   
                    Session["COrgLocServices"] = "frmOrgLocations";
                    Response.Redirect(strURL + "frmOrgLocServices.aspx?");

                }
                else
                {
                    Session["CallType"] = null;
                    Exit();
                }
				
			}
			else if (ds.Tables["Locs"].Rows.Count > 1)
			{

				lblContents.Text="Click on the button titled '"
					+ "Services' to identify services delivered from from a given location.";
			}
			else
			{
				lblContents.Text="Sorry, there are no budget details "
					+ "available for this organization.";
                DataGrid1.Visible=false;
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Services")
			{
				Session["COrgLocServices"]="frmOrgLocations";
				Session["ProfileId"]=e.Item.Cells[4].Text;
				Session["LocationName"]=e.Item.Cells[1].Text;
				Session["OrgLocId"]=e.Item.Cells[0].Text;
                Session["LocationsId"] = e.Item.Cells[6].Text;
				
				Response.Redirect (strURL + "frmOrgLocServices.aspx?");
			}
			else if (e.CommandName == "Mgrs")
			{
				Session["CMgr"]="frmOrgLocations";
				Session["LocationName"]=e.Item.Cells[1].Text;
				Session["ProfileServices"]=e.Item.Cells[0].Text;
				Session["OrgLocId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmOrgLocMgrs.aspx?");
			}

			else if (e.CommandName == "Clients")
			{
				/*Session["COrgLocServices"]="frmOrgLocations";
				Session["LocId"]=e.Item.Cells[3].Text;
				Session["LocationName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmOrgLocServices.aspx?");*/
			}
			else if (e.CommandName == "rptWP3")
			{
			ParameterFields paramFields = new ParameterFields();
			ParameterField paramField1 = new ParameterField();
			ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
			paramField1.ParameterFieldName = "OrgLocId";
			discreteval1.Value = e.Item.Cells[0].Text;
			
			paramField1.CurrentValues.Add (discreteval1);
			paramFields.Add (paramField1);
			
			Session["ReportParameters"] = paramFields;
			Session["ReportName"] = "rptWP3.rpt";
			rpts();
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="wms_DeleteOrgLocation";
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		private void rpts()
		{
			Session["cRG"]="frmPSEventsInd";
			Response.Redirect (strURL + "frmReportGen.aspx?");
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
				redirectNow();
		}
		private void redirectNow()
		{
			Session["CLocsAll"]="frmOrgLocations";
			Response.Redirect (strURL + "frmLocsAll.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            Exit();
		}
        private void Exit()
        { 
            Response.Redirect(strURL + Session["COrgLocs"].ToString() + ".aspx?"); 
        }


	}

}
	