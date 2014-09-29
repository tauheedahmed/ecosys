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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmProcRes: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		//private int I;
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
			if ((Session["startForm"].ToString() == "frmMainWP")||(Session["startForm"].ToString() == "frmMainMgr"))
			{
				lblOrg.Text=Session["OrgName"].ToString();
			}
			else if (Session["MgrName"] != null)
			{
				lblOrg.Text=Session["MgrName"].ToString();
			}
			if (!IsPostBack)
			{		
				lblLoc.Text="Location: " + Session["LocName"].ToString();
				if (Session["startForm"].ToString() == "frmMainMgr")
                {
                    if (Session["MgrOption"].ToString() == "Budget")
                    {
                        lblBd.Text = "Budget: " + Session["BudName"].ToString() + " - "
                        + Session["CurrName"].ToString();
                    }
                }
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				if (Session["PRS"].ToString() == "1")
				{
					lblDel.Text="Deliverable: " + Session["EventName"].ToString();
					lblTask.Text=Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Procedure: " + Session["ProcName"].ToString() + ")";
				}
                else if ((Session["startForm"].ToString() == "frmMainWP") || (Session["startForm"].ToString() == "frmMainMgr"))
				{
					lblDel.Text="Procedure: " + Session["ProcName"].ToString();
				}
				loadData();
			}
		}
		
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProcRes";
			cmd.Parameters.Add ("@PSEPID",SqlDbType.Int);
			cmd.Parameters["@PSEPID"].Value=Session["PSEPID"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcRes");
            if (ds.Tables["ProcRes"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                DataGrid1.Columns[1].HeaderText = "Goods and Services Needed";
                lblContents1.Text = "There are no goods or services identified for the above procedure."
                    + " Please contact your system administrator if you believe this procedure"
                    + " involves procurement of certain types of services.";
            }
            /*else if (ds.Tables["ProcRes"].Rows.Count == 1)
            {
                Session["cps"]=Session["CPRes"].ToString();
                Session["PSEPResID"]=ds.Tables["ProcRes"].Rows[0][0].ToString();
                Session["ResTypesId"]=ds.Tables["ProcRes"].Rows[0][2].ToString();
                Session["ResourceName"]=ds.Tables["ProcRes"].Rows[0][1].ToString();
                Session["QtyMeasure"]=ds.Tables["ProcRes"].Rows[0][4].ToString();
                Session["QtyMeasurePl"]=ds.Tables["ProcRes"].Rows[0][5].ToString();
                Session["RType"]=ds.Tables["ProcRes"].Rows[0][6].ToString();
				
                getProcs();
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
            if (Session["PRS"].ToString() == "1")
            {
                lblContents1.Text = "Listed below are the goods and/or services required"
                        + " to carry out the above procedure for "
                        + Session["PJNameS"].ToString()
                        + " titled '"
                        + Session["ProjName"].ToString()
                        + "'.  Click on the button 'Procurements' to identify"
                        + " procurement arrangements for these resources";
            }
            else
            {
                lblContents1.Text = "Listed below are the goods and/or services required"
                        + "'.  Click on the button 'Procurements' to identify"
                        + " procurement arrangements for these resources";
            }
        }
		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            if (e.CommandName == "Items")
            {
                Session["PSEPResID"] = e.Item.Cells[0].Text;
                Session["ResourceName"] = e.Item.Cells[1].Text;
                Session["ResTypesId"] = e.Item.Cells[3].Text;
                Session["QtyMeasure"] = e.Item.Cells[4].Text;
                Session["QtyMeasurePl"] = e.Item.Cells[5].Text;
                Session["ResTypesType"] = e.Item.Cells[6].Text;
                getProcs();
            }
            else if (e.CommandName == "Desc")
            {
                Session["SecPS"] = "Desc";
                Session["PSEPResId"] = e.Item.Cells[0].Text;
                DataGrid1.Visible = false;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "wms_RetrieveOrgPSEPRDesc";
                cmd.Parameters.Add("@PSEPResId", SqlDbType.Int);
                cmd.Parameters["@PSEPResId"].Value = Int32.Parse(Session["PSEPResId"].ToString());
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Desc");
                txtDesc.Text = ds.Tables["Desc"].Rows[0][0].ToString();
                Session["Srce"] = ds.Tables["Desc"].Rows[0][1].ToString();
                txtDesc.Visible = true;
                lblDesc.Visible = true;
                btnCancel.Visible = true;
                lblContents1.Text = "Please add/Update instructions specific to this Organization below";
                lblType.Text = "Comments: " + e.Item.Cells[1].Text;

            }
		}
		private void getProcs()
		{
			if (Session["startForm"].ToString() == "frmMainBMgr")
			{
				Session["CBudSerWS"]="frmProcRes";
				Response.Redirect (strURL + "frmBudSerWorkSheet.aspx?");
			}
			else
			{
				Session["cps"]="frmProcRes";
				Response.Redirect (strURL + "frmProcRReq.aspx?");
			}
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
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
                cmd.CommandText = "[wms_UpdateOrgPSEPRDesc]";
			    cmd.Connection=this.epsDbConn;
                cmd.Parameters.Add("@PSEPResId", SqlDbType.Int);
                cmd.Parameters["@@PSEPResId"].Value = Int32.Parse(Session["PSEPResId"].ToString());
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
                    cmd.CommandText = "wms_AddOrgPSEPRDesc";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@PSEPRId", SqlDbType.Int);
                    cmd.Parameters["@PSEPRId"].Value = Int32.Parse(Session["PSEPResId"].ToString());
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
            lblType.Text = "";
            Session["SecPS"] = null;
            Session["PSEPSId"] = null;
            setContents();
            DataGrid1.Visible = true;
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPRes"].ToString() + ".aspx?");
		}
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            frmReturn();
        }
        
}
}

