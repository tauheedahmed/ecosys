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

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmProcStaff : System.Web.UI.Page
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
			if (!IsPostBack) 
			{	
				if (Session["startForm"].ToString() == "frmMainWP")
				{
					lblOrg.Text=Session["OrgName"].ToString();
				}
				else if (Session["MgrName"] != null)
				{
					lblOrg.Text=Session["MgrName"].ToString();
				
				}
				lblLoc.Text="Location: " + Session["LocName"].ToString();
				
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				if (Session["PRS"].ToString() == "1")
				{
                    if (Session["CProjects"] == "frmPSEvents")
                    {
                        lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
                    }
                    lblTask.Text = Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Procedure: " + Session["ProcName"].ToString() + ")";
				}
				else 
				{
                    lblEventName.Text = "Procedure: " + Session["ProcName"].ToString();
				}
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProcStaff";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcStaff");
			if (ds.Tables["ProcStaff"].Rows.Count == 0)
			{
				if (Session["PRS"].ToString() == "1")
				{
					lblContents1.Text="There are no staff roles identified"
						+ " to carry out the above procedure for "
						+ Session["PJNameS"].ToString()
						+ " titled '"
						+ Session["ProjName"].ToString();
					
				}
				else
				{
					DataGrid1.Visible=false;
					lblContents1.ForeColor=System.Drawing.Color.Maroon;
					lblContents1.Text="There are no staff roles identified for the above procedure.";
				}
			}
			/*else if (ds.Tables["ProcStaff"].Rows.Count == 1)
			{
				Session["PSEPSID"]=ds.Tables["ProcStaff"].Rows[0][0].ToString();
				Session["PSEPSName"]=ds.Tables["ProcStaff"].Rows[0][1].ToString();
				Session["COSA"]=Session["CPStaff"].ToString();
				getStaff();
			}*/
			else
			{
				setContents();
			}
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
		}
        private void setContents()
        {
            if (Session["startForm"].ToString() == "frmMainBMgr")
            {
                if (Session["PRS"].ToString() == "0")
                {
                    lblContents1.Text = "Listed below are the roles needed to carry out the above procedure."
                        + "  Click on the button 'Staffing' to assign"
                        + " staff to this role.";
                }
                else
                {
                    lblContents1.Text = "Listed below are the roles played"
                        + " to carry out the above procedure for "
                        + Session["PJNameS"].ToString()
                        + " titled '"
                        + Session["ProjName"].ToString()
                        + "'.  Click on the button 'Staffing' to assign"
                        + " staff to this role.";

                }
            }
            else if (Session["PRS"].ToString() == "0")
            {
                lblContents1.Text = "Listed below are the roles needed to carry out the above procedure."
                    + " Click on the button 'Staffing' to review"
                    + " staff assigned to a given role and related details, and to specify"
                    + " the approved budget at this level as needed.";
            }
            else
            {
                lblContents1.Text = "Listed below are the roles played"
                    + " to carry out the above procedure for "
                    + Session["PJNameS"].ToString()
                    + " titled '"
                    + Session["ProjName"].ToString()
                    + "'.  Click on the button 'Staffing' to review"
                    + " staff assigned to a given role and related details, and to specify"
                    + " the approved budget at this level as needed.";
            }
        }
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPStaff"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Staff")
			{
				Session["PSEPSID"]=e.Item.Cells[0].Text;
				Session["PSEPSName"]=e.Item.Cells[1].Text;
				Session["COSA"]="frmProcStaff";
				getStaff();
			}
            else if (e.CommandName == "Desc")
            {
            Session["SecPS"] = "Desc";
            Session["PSEPSId"] = e.Item.Cells[0].Text;
            DataGrid1.Visible = false;
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
            cmd.CommandText = "wms_RetrieveOrgPSEPSDesc";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
            cmd.Parameters["@Id"].Value = Int32.Parse(Session["PSEPSId"].ToString());
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Desc");
            txtDesc.Text = ds.Tables["Desc"].Rows[0][0].ToString();
            Session["Srce"] = ds.Tables["Desc"].Rows[0][1].ToString();
            txtDesc.Visible = true;
            lblDesc.Visible = true;
            btnCancel.Visible = true;
            lblContents1.Text = "Please add/Update instructions specific to this Organization below";
            lblRole.Text = "Role: " + e.Item.Cells[1].Text; 

            }
		}
        protected void btnExit_Click(object sender, System.EventArgs e)
		{
            if (Session["SecPS"] == null)
            {
                Exit();
            }
            else
            {
                if (Session["Srce"].ToString() == "Org")
                {
                SqlCommand cmd=new SqlCommand();
			    cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "wms_UpdateOrgPSEPSDesc";
			    cmd.Connection=this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(Session["PSEPSId"].ToString());
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                cmd.Parameters["@Desc"].Value = txtDesc.Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_AddOrgPSEPSDesc";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@PSEPStaffId", SqlDbType.Int);
                    cmd.Parameters["@PSEPStaffId"].Value = Int32.Parse(Session["PSEPSId"].ToString());
                    cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                    cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                    cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                    cmd.Parameters["@Desc"].Value = txtDesc.Text;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                frmReturn();
            }
		}
        private void frmReturn()
        {
            btnCancel.Visible = false;
            txtDesc.Visible = false;
            lblDesc.Visible = false;
            lblContents1.Text = "Please add/Update instructions specific to this Organization below";
            lblRole.Text = "";
            Session["SecPS"] = null;
            Session["PSEPSId"] = null;
            setContents();
            DataGrid1.Visible = true;
			    
        }
		private void getStaff()
		{
			if (Session["startForm"].ToString() == "frmMainBMgr")
			{
				Session["CBudSerWS"]="frmProcStaff";
				Session["SGFlag"]= 0;
				Session["GS"]="Staff";
				Response.Redirect (strURL + "frmBudStaffWorkSheet.aspx?");
			}
			else
			{
				Response.Redirect (strURL + "frmProcSReq.aspx?");
			}
		}
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmReturn();
        }
}

}