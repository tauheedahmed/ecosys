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
	public partial class frmOrgStaffTypes : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
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
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				
                if (Session["MgrOption"].ToString() == "AptStruct")
                {
                    DataGrid1.Columns[2].Visible = false;
                    lblContents.Text = "Listed below are the various Appointment Types"
                    + " that may be made in your Organization.  Click on 'Add' to add to this list."
                    + " Click on 'Pay grades'"
                    + " to maintain pay grades for each Appointment Type in the list.";
                }
                else
                {
                    DataGrid1.Columns[3].Visible = false;
                    btnAdd.Visible = false;
                    lblContents.Text = "Listed below are the various Appointment Types"
                    + " that may be made in your Organization."
                    + " Click on 'Appointments'"
                    + " to maintain staff appointments for your organization.";
                }
                
            
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrieveOrgStaffTypes";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffTypes");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
            refreshGrid();
		}
        private void refreshGrid()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                Button btnRemove = (Button)(i.Cells[3].FindControl("btnRemove"));
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = this.epsDbConn;
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                {
                    cmd.CommandText = "Select Id from StaffActions"
                        + " Where StaffActions.TypeId = " + i.Cells[0].Text;
                    if (cmd.ExecuteScalar() != null)
                    {
                        btnRemove.Enabled = false;
                    }
                }
                cmd.Connection.Close();
            }
        }

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Appointments")
			{

				Session["SA"]="frmOrgStaffTypes";
				Session["STName"]=e.Item.Cells[1].Text;
				Session["OrgStaffTypesId"]=e.Item.Cells[0].Text;
				Session["CurrId"]=e.Item.Cells[7].Text;
				Response.Redirect (strURL + "frmStaffActions.aspx?");
			}
			else if (e.CommandName == "PayGrades")
			{
				Session["CPayGrades"]="frmOrgStaffTypes";
				Session["OrgSTId"]=e.Item.Cells[0].Text;
				Session["OrgST"]=e.Item.Cells[1].Text;
				Session["CurrName"]=e.Item.Cells[5].Text;
				Session["SalaryPeriod"]=e.Item.Cells[6].Text;
				Response.Redirect (strURL + "frmPayGrades.aspx?");
			}
			else if (e.CommandName == "Details")
			{
				Session["CUpdOST"]="frmOrgStaffTypes";
				Response.Redirect (strURL + "frmUpdOrgStaffTypes.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_DeleteOrgStaffTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
				Session["CStaffTypesAll"]="frmOrgStaffTypes";
				Response.Redirect (strURL + "frmStaffTypesAll.aspx?"
				+ "&btnAction=" + "Add");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CAptTypes"].ToString() + ".aspx?");
		}
	}

}
	