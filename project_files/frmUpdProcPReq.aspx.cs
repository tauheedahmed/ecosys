using System;
using System.Collections;
using System.Globalization;
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
	public partial class frmUpdProcPReq: System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int I;
		protected System.Web.UI.HtmlControls.HtmlForm frmAddProcSAR;
		protected System.Web.UI.WebControls.Button btnSuppliers;
		protected System.Web.UI.WebControls.RadioButtonList rblType;
		protected System.Web.UI.WebControls.Button btnSupplierList;
		protected System.Web.UI.WebControls.Label lblSupplier1;
		protected System.Web.UI.WebControls.Label lblStep2;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!IsPostBack)
			{
                if (Session["MgrOption"].ToString() == "Plan")
				{
                    txtBud.Visible = false;
                    btnBud.Visible = false;
					if (Session["EPS"].ToString() == "1")
					{
						lblBackup.Visible=true;
						cbxBackup.Visible=true;
					}
				}
                else if (Session["MgrOption"].ToString() == "Budget")
                {
                    txtBud.Visible = true;
                    btnBud.Visible = true;
                    lblBud.Text = "Budget Authorized (enter only if different from budget requested)";
                }
                if (Session["ResTypesId"].ToString() == "1")
				{
					lblTime.Visible=false;
					txtQty.Visible=false;
					lblQtyMeasure.Visible=false;
					btnBud.Visible=false;
					lblPrice.Visible=false;
					txtPrice.Visible=false;
					lblGS.Text="Resource Required:  " + Session["ResourceName"].ToString();
				}
				else
				{
					lblGS.Text="Service Required:  " + Session["ResourceName"].ToString();
				}
				if (Session["MgrName"] == null)
                {
					lblOrg.Text=Session["OrgName"].ToString();
				}
				else 
				{
					lblOrg.Text=Session["MgrName"].ToString();
				}
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
					+ Session["CurrName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				if (Session["PRS"].ToString() == "1")
				{
					lblDel.Text="Deliverable: " + Session["EventName"].ToString();
					lblTask.Text=Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Task: " + Session["ProcName"].ToString() + ")";
				}
				else 
				{
					lblDel.Text="Task: " + Session["ProcName"].ToString();
				}
				if (Session["btnAction"].ToString() == "Update")
				{
					Id=Session["ProcProcureId"].ToString();
					loadProcProcure();
					if (Session["BRS"].ToString() == "1")
					{
                        if (Session["ResTypesId"].ToString() == "0")//here
						{
							computeBudget();
						}
					}
				}
				if (Session["BRS"].ToString() == "0")
				{
					btnBud.Visible=false;
					lblBudReq.Visible=false;
					lblPrice.Visible=false;
					btnSOF.Visible=false;
					lblBudName.Visible=false;
					lblPerMeasure.Visible=false;
					txtPrice.Visible=false;
					txtPrice.Enabled=false;

				}
				else if (Session["PRS"].ToString() == "0")
				{
                    if (Session["ResTypesId"].ToString() == "0")//here
					{
						lblPerMeasure.Text=Session["CurrName"].ToString() + " per " 
							+ Session["QtyMeasure"].ToString();
					}
					lblBudName.Text=
						"Budget Provider: "
						+ Session["BProv"].ToString()
						+ " Budget Title: "
						+ Session["BudName"].ToString();
					btnSOF.Visible=false;

				}
				else if (Session["BudSel"] != null)
				{
                    if (Session["ResTypesId"].ToString() == "0")//here
					{
						lblPerMeasure.Text=Session["CurrNameSel"].ToString() + " per " 
							+ Session["QtyMeasure"].ToString();
					}
					lblBudName.Text=
						"Budget Provider: "
						+ Session["BProvSel"].ToString()
						+ " Budget Title: "
						+ Session["BudNameSel"].ToString() ;
					btnSOF.Text="Change Budget";
				}
				else if (Session["btnAction"].ToString() == "Update")
				{
                    if (Session["ResTypesId"].ToString() == "0")//here
					{
						lblPerMeasure.Text=Session["CurrNamePl"].ToString() + " per " 
							+ Session["QtyMeasure"].ToString();
					}
					/*else
					{
						lblPerMeasure.Text=Session["CurrNamePl"].ToString();
					}*/
					lblBudName.Text=
						"Budget Provider: "
						+ Session["BudProvider"].ToString()
						+ " Budget Title: "
						+ Session["BudName"].ToString();
					btnSOF.Text="Change Budget";
				}
				else
					{
						lblPerMeasure.Visible=false;
						lblBudName.Visible=false;
					}
				
				lblQtyMeasure.Text=Session["QtyMeasurePl"].ToString();
				lblContent1.Text=Session["btnAction"].ToString() + " Procurement Request";
				btnAction.Text= Session["btnAction"].ToString();
				if (Session["ContractIdSel"] != null)//i.e. if Contract has been identified
				{
					loadContract();
				}
				/*if (Session["StaffActionId"] != null)//i.e. if StaffAction has been identified from frmStaffActionsProc
				{
					loadStaffAction();
				}	*/
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
		private void loadProcProcure()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveProcProcure";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProcProcureId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procure");			
			txtDesc.Text=ds.Tables["Procure"].Rows[0][0].ToString();
			txtQty.Text=ds.Tables["Procure"].Rows[0][1].ToString();
			txtPrice.Text=ds.Tables["Procure"].Rows[0][2].ToString();
			if (ds.Tables["Procure"].Rows[0][3].ToString().StartsWith("&")== true)
			{
				Session["ContractId"] = null;
			}
			else
			{
				Session["ContractId"]=ds.Tables["Procure"].Rows[0][3].ToString();
			}
			//Session["ContractAptFlag"]=ds.Tables["Procure"].Rows[0][4].ToString();
			Session["CurrNamePl"]=ds.Tables["Procure"].Rows[0][5].ToString();
			Session["BudProvider"]=ds.Tables["Procure"].Rows[0][6].ToString();
			Session["BudName"]=ds.Tables["Procure"].Rows[0][7].ToString();
			Session["BudStatus"]=ds.Tables["Procure"].Rows[0][8].ToString();
			Session["ReqAmount"]=ds.Tables["Procure"].Rows[0][9].ToString();
			Session["BudAmount"]=ds.Tables["Procure"].Rows[0][10].ToString();
            
			
			if (ds.Tables["Procure"].Rows[0][11].ToString() == "1")
			{
				cbxBackup.Checked=true;
			}
			if (ds.Tables["Procure"].Rows[0][9].ToString() != "")
			{
				txtBud.Text=ds.Tables["Procure"].Rows[0][9].ToString();
			}
            lblChargeStatus.Text = "Request Status:  " + ds.Tables["Procure"].Rows[0][4].ToString();

			if (Session["ContractId"].ToString() != "")
			{
                
                btnSA.Visible = false;
                loadContract();
			}
		}
		private void loadContract()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveContract";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			if (Session["ContractIdSel"] != null)
			{
				Session["ContractId"]=Session["ContractIdSel"];
				cmd.Parameters["@Id"].Value=Int32.Parse(Session["ContractIdSel"].ToString());
			}
			else if (Session["ContractId"] != null)
			{
				cmd.Parameters["@Id"].Value=Int32.Parse(Session["ContractId"].ToString());
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Contract");
			lblSupplier.Text="Supplier: " + ds.Tables["Contract"].Rows[0][9].ToString();	
			lblContractTitle.Text="Contract/Agreement Title: " + ds.Tables["Contract"].Rows[0][1].ToString();
			lblStatus.Text="Contract Status: " + ds.Tables["Contract"].Rows[0][10].ToString();
			//Session["ContractAptFlag"]=0;
		}
		/*private void loadStaffAction()
		{
			try
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="fms_RetrieveProcSReqSA";		
				cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
				if (Session["StaffActionId"] != null)
				{
					Session["ContractId"]=Session["StaffActionId"];
					cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["StaffActionId"].ToString());
				}
				else if (Session["ContractId"] != null)
				{
					cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["ContractId"].ToString());
				}
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"SAR");				
				lblContractTitle.Text="Supplier: " + ds.Tables["SAR"].Rows[0][0].ToString();
				lblSupplier.Text="";
				lblStatus.Text="Appointment Type: " + ds.Tables["SAR"].Rows[0][12].ToString()
					+ " (" + ds.Tables["SAR"].Rows[0][13].ToString() + ")";
				lblType.Text="Appointment Status: " + ds.Tables["SAR"].Rows[0][1].ToString();
				Session["ContractAptFlag"]=1;
			}
			catch
			{
				lblContent1.Text="There are no staff appointments in place for you to choose from.";
			}
		}*/

		private void computeBudget()
		{
			performChecks();
			I=0;

			if ((txtQty.Text != "") & (txtPrice.Text != ""))
			{
				if (Session["CurrNameSel"] != null)
				{
					lblBudReq.Text="Budget Request: "
						+ decimal.Round(
						(decimal.Parse(txtPrice.Text)* decimal.Parse(txtQty.Text)),2)
						+ " " 
						+ Session["CurrNameSel"].ToString();
				}
				else
				{
					lblBudReq.Text="Budget Request: "
						+ decimal.Round(
						(decimal.Parse(txtPrice.Text)* decimal.Parse(txtQty.Text)),2)
						+ " " 
						+ Session["CurrNamePl"].ToString();
				}
			}
			else if ((txtQty.Text != "") & (txtPrice.Text == ""))
			{
				lblBudReq.Text="Budget Request cannot be determined:  The Price is not indicated for this item.";
			}
			else if ((txtQty.Text == "") & (txtPrice.Text != ""))
			{
                lblBudReq.Text = "Budget Request cannot be determined:  The Quantity Required is not indicated for this item.";
			}
			else 
			{
                lblBudReq.Text = "Budget Request cannot be determined:  The Price and Quantity Required are not indicated for this item.";
			}
		}
		private void performChecks()
		{
            if (Session["ResTypesId"].ToString() == "0")
				
			{
				if (txtQty.Text == "")
				{
					lblContent1.ForeColor=Color.Orange;
					lblContent1.Text="You must enter quantity required.";
				}
				else if (txtPrice.Text == "")
				{
					lblContent1.ForeColor=Color.Orange;
					lblContent1.Text="You must enter the expected price of this resource.";
				}
				else I=1;
			}
			else I=1;
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			
			if (Session["BRS"].ToString() == "1")
			{
				performChecks();
				if (I == 1)
				{
					updateData();
				}
			}
			else
			{
				
				updateData();
			}
			
		}

		private void updateData()
		{
			
			if (Session["btnAction"].ToString() == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateProcPReq";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ProcProcureId"].ToString();
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				if (Session["ContractId"].ToString() != "")
				{
					cmd.Parameters.Add("@ContractId",SqlDbType.Int);
					cmd.Parameters["@ContractId"].Value=Int32.Parse(Session["ContractId"].ToString());
					
				}
				cmd.Parameters.Add ("@Price",SqlDbType.Decimal);
				if (txtPrice.Text != "")
				{
					cmd.Parameters["@Price"].Value=Decimal.Parse(txtPrice.Text, NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Qty",SqlDbType.Decimal);
				if (txtQty.Text != "")
				{
					cmd.Parameters["@Qty"].Value=Decimal.Parse(txtQty.Text, NumberStyles.Any);
				}

				if (Session["BRS"].ToString() == "1")
				{
					if (Session["BudgetsIdSel"] != null)
					{
						cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
						cmd.Parameters["@BudgetsId"].Value=Session["BudgetsIdSel"].ToString();
					}
				}
				if (txtBud.Text != "")
				{
					cmd.Parameters.Add ("@ReqAmount",SqlDbType.Decimal);
					cmd.Parameters["@ReqAmount"].Value=Decimal.Parse(txtBud.Text, NumberStyles.Any);
				}
				if (cbxBackup.Checked)
				{
					cmd.Parameters.Add("@BkupFlag",SqlDbType.Int);
					cmd.Parameters["@BkupFlag"].Value=1;
				}
			
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (Session["btnAction"].ToString() == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddProcPReq";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
				cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@PSEPSID",SqlDbType.Int);
				cmd.Parameters["@PSEPSID"].Value=Session["PSEPResId"].ToString();
				cmd.Parameters.Add ("@PSEPId",SqlDbType.Int);
				cmd.Parameters["@PSEPId"].Value=Session["PSEPId"].ToString();
				if (Session["PRS"].ToString() == "1")
				{
					cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
					cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
				}
				if (Session["BRS"].ToString() == "1")
				{
					if (Session["BudgetsIdSel"] != null)
					{
						cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
						cmd.Parameters["@BudgetsId"].Value=Session["BudgetsIdSel"].ToString();
					}
					else 
					{
						cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
						cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();
					}
				}
				if (Session["ContractId"] != null)
				{
					cmd.Parameters.Add("@ContractId",SqlDbType.Int);
					cmd.Parameters["@ContractId"].Value=Session["ContractId"].ToString();
                }
                if (Session["ResTypesId"].ToString() == "0")//here
				{
					cmd.Parameters.Add ("@Qty",SqlDbType.Decimal);
					cmd.Parameters["@Qty"].Value=1;
				}
				else
				{
					if (txtQty.Text != "")
					{
						cmd.Parameters.Add ("@Qty",SqlDbType.Decimal);
						cmd.Parameters["@Qty"].Value=Decimal.Parse(txtQty.Text, NumberStyles.Any);
					}
				}
				if (txtPrice.Text != "")
				{
					cmd.Parameters.Add ("@Price",SqlDbType.Decimal);
					cmd.Parameters["@Price"].Value=Decimal.Parse(txtPrice.Text, NumberStyles.Any);
				}
				if (txtBud.Text != "")
				{
					cmd.Parameters.Add ("@ReqAmount",SqlDbType.Decimal);
					cmd.Parameters["@ReqAmount"].Value=Decimal.Parse(txtBud.Text, NumberStyles.Any);
				}
				if (cbxBackup.Checked)
				{
					cmd.Parameters.Add("@BkupFlag",SqlDbType.Int);
					cmd.Parameters["@BkupFlag"].Value=1;
				}
                cmd.Parameters.Add("@TypeId", SqlDbType.Int);
                cmd.Parameters["@TypeId"].Value = Int32.Parse(Session["ResTypesId"].ToString());
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}		
		private void Done()
		{
			Session["BudSel"] = null;
			Session["BudgetsIdSel"]=null;
			Session["BProvSel"]=null;
			Session["BudNameSel"]=null;
			Session["CurrNameSel"]=null;
			Session["ContractIdSel"]=null;
			Session["StaffActionId"]=null;
			Session["ContractId"]=null;
			Response.Redirect (strURL + Session["CPPR"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		protected void btnSA_Click(object sender, System.EventArgs e)
		{
			Session["StaffActionId"]=null;
			getContract();
		}
		private void getContract()
		{
			Session["CContracts"]="frmUpdProcPReq";
			Response.Redirect (strURL + "frmContractsS.aspx?");
		}
		protected void btnRecomputeBudget (object sender, System.EventArgs e)
		{
			computeBudget();
		}

		/*protected void btnSupplier_Click(object sender, System.EventArgs e)
		{
			Session["ContractIdSel"]=null;
			Session["SA"]="frmUpdProcPReq";
			Response.Redirect (strURL + "frmStaffActionsProc.aspx?");
		}*/

		protected void btnSOF_Click(object sender, System.EventArgs e)
		{
			Session["CBS"]="frmUpdProcPReq";
			Response.Redirect (strURL + "frmBudSel.aspx?");
		}
	}
}

	
