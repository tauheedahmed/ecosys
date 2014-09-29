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
	public partial class frmActperiods : System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["AptOrgName"].ToString();
				lblPerson.Text=
					Session["FName"].ToString() + " " + Session["LName"].ToString()
					+ " (Appointment Type: " + Session["StaffType"].ToString() + ")";
				lblContents.Text="To report time you spent on tasks assigned to you,"
					+ " click on 'Timesheets' for the time  period for which you "
					+ " are reporting time.";
				loadData();
			}
		}
        /*private void setFY()
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.CommandText="fms_RetrieveTimeperiods";
            cmd.Connection=this.epsDbConn;
            //cmd.Parameters.Add ("@SCId",SqlDbType.Int);
            //cmd.Parameters["@SCId"].Value=Session["SCId"].ToString();
            DataSet ds=new DataSet();
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            da.Fill(ds,"FY");
            if (ds.Tables["FY"].Rows.Count ==0)
            {
                DataGrid1.Visible=false;
                lblContents.Text = "Your organization has no Fiscal Years identified at present."
                    + " Please contact your system administrator";				
            }
            else
            {
                Session["FY"]="Timesheets for Fiscal year: " + ds.Tables["FY"].Rows[0][0];
                lblFY.Text="";//Session["FY"].ToString();		
            }
        } #03138041424*/
        private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveActperiodsOrg";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["AptOrgId"].ToString();
			cmd.Connection=this.epsDbConn;
			/*cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();*/
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Timeperiods");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (ds.Tables["Timeperiods"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				lblContents.Text = "Your organization has no Account Periods identified at present."
					+ " Please contact your system administrator";	
								
			}
		}
		private void itemCommand (object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			if (e.CommandName == "Timesheet")
			{
				Session["ActPeriodsId"]=e.Item.Cells[0].Text;
				Session["CTS"]="frmActPeriods";
				Response.Redirect(strURL + "frmTS.aspx?");
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CSAI"].ToString() + ".aspx?");
		}
	}
}
