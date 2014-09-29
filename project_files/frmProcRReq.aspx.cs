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
using System.Globalization;

namespace WebApplication2
{
	/// <summary>
	/// Called by ProcRes.  Used for planning.
	/// </summary>
	public partial class frmProcRReq : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                if (Session["MgrName"] == null)
                {
                    lblOrg.Text = Session["OrgName"].ToString();
                }
                else 
                {
                    lblOrg.Text = Session["MgrName"].ToString();
                }
                lblService.Text = "Service: " + Session["ServiceName"].ToString();
                lblLoc.Text = "Location: " + Session["LocName"].ToString();

                btnAddNew.Text = "Identify Procurement Need";
                btnAddExisting.Text = "Add from Existing Service Contracts";

                DataGrid1.Columns[0].Visible = false;//Id
                DataGrid1.Columns[1].Visible = true;//ItemName
                if (Session["ResTypesType"].ToString() == "0")//goods
                {
                    lblGS.Text = "Type of Good:  " + Session["ResourceName"].ToString();
                    btnAddExisting.Text = "Add from Existing Goods";
                    DataGrid1.Columns[2].Visible = true;//txtQty
                    DataGrid1.Columns[2].HeaderText = "Qty (" + Session["QtyMeasure"].ToString() + ")";
                }
                else
                {
                    lblGS.Text = "Type of Service:  " + Session["ResourceName"].ToString();
                    btnAddExisting.Text = "Add from Existing Services";
                    DataGrid1.Columns[2].Visible = false;
                }

                DataGrid1.Columns[3].Visible = false;//textbox Price 
                DataGrid1.Columns[4].Visible = false;//Cost (Computed)
                DataGrid1.Columns[5].Visible = false;//Qty
                DataGrid1.Columns[6].Visible = false;//Price
                DataGrid1.Columns[7].Visible = false;//Inventory - Owner Organization
                DataGrid1.Columns[8].Visible = true;//Inventory - Location
                DataGrid1.Columns[9].Visible = true;//Inventory - SubLocation
                if (Session["CallerOpt"] == "EM")
                {
                    DataGrid1.Columns[10].Visible = true;//cbxBackup
                }
                else
                {
                    DataGrid1.Columns[10].Visible = false;//cbxBackup
                }
                DataGrid1.Columns[11].Visible = true;//BudgetsId List
                if (Session["PAY"] == null)
                {
                    DataGrid1.Columns[12].Visible = false;
                }
                else if (Session["PAY"].ToString() == "0")
                {
                    DataGrid1.Columns[0].Visible = false;
                }
                DataGrid1.Columns[13].Visible = true;//btnDelete
                DataGrid1.Columns[14].Visible = false;//BackupFlag
                DataGrid1.Columns[15].Visible = false;//BudgetsId

                if (Session["InventoryId"] != null)
                {
                    AddProcRReq();
                    Session["InventoryId"] = null;
                }
                if (Session["ContractIdSel"] != null)
                {
                    AddProcRReq();
                    Session["ContractIdSel"] = null;
                }
                if (Session["PRS"].ToString() == "1")
                {
                    lblDel.Text = "Deliverable: " + Session["EventName"].ToString();
                    lblTask.Text = Session["PJNameS"].ToString() + ": "
                        + Session["ProjName"].ToString()
                        + " (Procedure: " + Session["ProcName"].ToString() + ")";
                }
                else
                {
                    lblDel.Text = "Procedure: " + Session["ProcName"].ToString();
                }
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		   
		private void loadData ()
		{
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_RetrievePSEPRInv";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Int32.Parse(Session["LocationsId"].ToString()); 
            cmd.Parameters.Add("@PSEPResID", SqlDbType.Int);
            cmd.Parameters["@PSEPResID"].Value = Int32.Parse(Session["PSEPResID"].ToString());
            if (Session["PRS"].ToString() == "1")
            {
                cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
                cmd.Parameters["@ProjectId"].Value = Int32.Parse(Session["ProjectId"].ToString());
            }

            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ProcS");
            if (ds.Tables["ProcS"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContents1.Text = "Note:  There is no resource assigned."
                    + ". Click on 'Add' to assign resources.";
                //lblOrg.Text = "PP" + Session["MgrId"].ToString() + "LL" + Session["LocationsId"].ToString()
                 //   + "PSepResID:" + Session["PSEPResID"].ToString()
                 //   + "PRS:" + Session["PRS"].ToString()  + "Project:" + Session["ProjectId"].ToString();
            }
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            refreshGrid();
           
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
                CheckBox cb = (CheckBox)(i.Cells[10].FindControl("cbxBackup"));
                DropDownList dl = (DropDownList) (i.Cells[11].FindControl("lstBudgets"));
                TextBox tQ = (TextBox)(i.Cells[2].FindControl("txtQty"));
                //TextBox tP = (TextBox)(i.Cells[3].FindControl("txtPrice"));
               
				if (i.Cells[14].Text == "1")
				{
                    cb.Checked = true;
				}

                if (i.Cells[5].Text.StartsWith("&") == false)
                {
                    tQ.Text = i.Cells[5].Text;
                }
                /*if (i.Cells[6].Text.StartsWith("&") == false)
                {
                    tP.Text = i.Cells[6].Text;
                }*/

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = this.epsDbConn;
                cmd.CommandText = "fms_RetrieveFunds";
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                /*cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();*/
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Funds");
                dl.DataSource = ds;
                dl.DataMember = "Funds";
                dl.DataTextField = "Name";
                dl.DataValueField = "Id";
                dl.DataBind();

            if (i.Cells[15].Text != "")
            {
                dl.SelectedIndex = dl.Items.IndexOf(dl.Items.FindByValue(i.Cells[15].Text));
            }
			}
		}
		private void updateGrid()
		{
            float r = 1;       
            foreach (DataGridItem i in DataGrid1.Items)
            {
                if (r == 0)
                {
                    break;
                }
                CheckBox cb = (CheckBox)(i.Cells[10].FindControl("cbxBackup"));
                DropDownList dl = (DropDownList)(i.Cells[11].FindControl("lstBudgets"));
                TextBox tQ = (TextBox)(i.Cells[2].FindControl("txtQty"));
                //TextBox tP = (TextBox)(i.Cells[3].FindControl("txtPrice"));

                
                if (Session["ResTypesType"].ToString() == "0" && tQ.Text.Trim() != "")
                {
                    string s = tQ.Text.Trim();
                    bool result = float.TryParse(s, out r);
                    if (r == 0)
                    {
                        lblContents1.Text = "Please enter valid number in the Column titled 'Quantity'.";
                        break;
                    }
                    else
                    {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdatePSEPResInv";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@BackupFlag", SqlDbType.Int);
                    if (cb.Checked)
                    {
                        cmd.Parameters["@BackupFlag"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@BackupFlag"].Value = 0;
                    }

                    cmd.Parameters.Add("@Budgets", SqlDbType.Int);
                    cmd.Parameters["@Budgets"].Value = Int32.Parse(dl.SelectedItem.Value);
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal);

                    if (tQ.Text != "")
                    {
                        if (Session["ResTypesType"].ToString() == "0")
                        {
                            cmd.Parameters["@Qty"].Value = decimal.Parse(tQ.Text.Trim(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                        }
                    }
                    /*cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    if (tP.Text != "")
                    {
                        cmd.Parameters["@Price"].Value = decimal.Parse(tP.Text.Trim(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    }*/
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    r = 1;  
                    }
                }
                
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "fms_UpdatePSEPResInv";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@BackupFlag", SqlDbType.Int);
                    if (cb.Checked)
                    {
                        cmd.Parameters["@BackupFlag"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@BackupFlag"].Value = 0;
                    }

                    cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
                    cmd.Parameters["@BudgetsId"].Value = Int32.Parse(dl.SelectedItem.Value);
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal);

                    if (tQ.Text != "")
                    {
                        if (Session["ResTypesType"].ToString() == "0")
                        {
                            cmd.Parameters["@Qty"].Value = decimal.Parse(tQ.Text.Trim(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                        }
                    }
                    /*cmd.Parameters.Add("@Price", SqlDbType.Decimal);
                    if (tP.Text != "")
                    {
                        cmd.Parameters["@Price"].Value = decimal.Parse(tP.Text.Trim(), System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    }*/
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
              }
            if (r == 1)
            {
                Exit();
            }
		    }
        /*if (tP.Text.Trim() != "")
                {
                    float r = 0;
                    string s = tP.Text.Trim();
                    bool result = float.TryParse(s, out r);
                    if (r == 0) 
                    {
                        lblContents1.Text = "Please enter valid number in the Column titled 'Price'.";
                        break;
                    }
                }*/
           private void AddProcRReq()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "wms_AddPSEPResInv";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@PSEPResId", SqlDbType.Int);
            cmd.Parameters["@PSEPResId"].Value = Session["PSEPResId"].ToString();
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@LocationsId", SqlDbType.Int);
            cmd.Parameters["@LocationsId"].Value = Session["LocationsId"].ToString(); 
            if (Session["InventoryId"] != null)
            {
                cmd.Parameters.Add("@InventoryId", SqlDbType.Int);
                cmd.Parameters["@InventoryId"].Value = Session["InventoryId"].ToString();
            }
            if (Session["ContractIdSel"] != null)
            {
                cmd.Parameters.Add("@ContractsId", SqlDbType.Int);
                cmd.Parameters["@ContractsId"].Value = Session["ContractIdSel"].ToString();
            }
            if (Session["PRS"].ToString() == "1")
            {
                cmd.Parameters.Add("@ProjectId", SqlDbType.Int);
                cmd.Parameters["@ProjectId"].Value = Session["ProjectId"].ToString();
            }
            cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
            cmd.Parameters["@BudgetsId"].Value = 5;

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CPPR"]="frmProcRReq";
				Session["btnAction"]="Update";
				Session["ProcProcureId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProcPReq.aspx?");
			}
			else if (e.CommandName == "Pay")
			{
				Session["CPay"]="frmProcRReq";
				Session["ProcProcuresId"] = e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmPayments.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "wms_DeletePSEPResInv";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		/*private void btnAdd_Click(object sender, System.EventArgs e)
		{
				Session["CallerUpdProcure"]="frmProcRReq";
				Session["Contractor"] = "Table";
				Session["btnAction"]="Add";
				Session["Id"]="0";
				Response.Redirect (strURL + "frmUpdProcProcure.aspx?");
		}*/
		private void Exit()
		{
			Response.Redirect (strURL + Session["cps"].ToString() + ".aspx?");
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
		    updateGrid();
		}
        private void getInv()
        {
            Session["InventoryId"] = null;
            Session["Update"] = "No";
            Session["CInv"] = "frmProcRReq";
            Response.Redirect(strURL + "frmInventory.aspx?");
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
           
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["InventoryId"] = null;
            AddProcRReq();
            loadData();
        }
        protected void btnAddExisting_Click1(object sender, EventArgs e)
        {
            if (Session["ResTypesType"].ToString() == "0")
            {
                getInv();
            }
            else
            {
                Session["CContracts"] = "frmProcRReq";
                Response.Redirect(strURL + "frmContractsS.aspx?");
            }
        }
}

}
	