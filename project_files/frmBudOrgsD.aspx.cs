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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmBudOrgsD : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAddTemp;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		int I;
		int Rules = 0;

	
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
			if (Session["BRS"].ToString() == "0")
			{
                DataGrid1.Columns[2].HeaderText = "Budget";
				DataGrid1.Columns[3].Visible=false;
				DataGrid1.Columns[4].Visible=false;
				DataGrid1.Columns[5].Visible=false;
                DataGrid1.Columns[6].Visible=false;
                DataGrid1.Columns[7].Visible = false;
				lblContents.Text="The above budget has been distributed to the following"
					+ " internal units and/or external organizations.  You may"
					+ " add or remove organizations from this list using the buttons"
					+ " titled 'Add' and 'Remove' respectively.";
			}
			else if (Session["Status"].ToString() == "Formulation")
			{
				DataGrid1.Columns[3].Visible=false;
				DataGrid1.Columns[4].Visible=false;
				DataGrid1.Columns[5].Visible=false;
				lblContents.Text="The above budget will be distributed to the following"
					+ " internal units and/or external organizations.  You may"
					+ " add or remove organizations from this list using the buttons"
					+ " titled 'Add' and 'Remove' respectively.";
			}
			else if (Session["Status"].ToString() == "Open")
			{
				DataGrid1.Columns[2].Visible=false;
				lblContents.Text="The above budget has been distributed to the following"
					+ " internal units and/or external organizations.  You may"
					+ " add or remove organizations from this list using the buttons"
					+ " titled 'Add' and 'Remove' respectively.  You may change the current"
					+ " budget by adding the amount to be added or reduced in the column titled '+/- Current Budget'.";				
			}
			else 
			{
				lblContents.Text="System Error.  Please Contact Administrator.";				
			}
			if (!IsPostBack) 
			{	
				lblOrg.Text="Budget Manager: " + Session["OrgName"].ToString();
				lblBudAmt.Text="Budget Amount Available: " + Session["BudAmt"].ToString()
					+ " " + Session["CurrName"].ToString();
				loadData();
                lblBud.Text = "Budget Name: " + Session["BudName"].ToString();   
			} 
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveBudOrgsD";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@BudgetsId",SqlDbType.Int);
			cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BudOrgs");
			if (ds.Tables["BudOrgs"].Rows.Count == 0)
			{	
				DataGrid1.Visible=false;
				lblContents.Text="The above budget has not yet been distributed.  To distribute"
					+ " click on 'Add'.";
	
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignValues();
		}
		
		private void computeBudget()
		{
			float Change = 0;
			float CurrBud = 0;
			float CurrBudChange = 0;
			float Req = 0;
			float DiffBudD = 0;
			int	ChangeFlag = 0;
			foreach (DataGridItem i in DataGrid1.Items)
			{
				
				TextBox tbCurr = (TextBox)(i.Cells[5].FindControl("txtCurr"));
				
				if (i.Cells[4].Text != "&nbsp;")
				{
					CurrBud = 
						CurrBud 
						+ float.Parse(i.Cells[4].Text, NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands|NumberStyles.AllowLeadingSign);
				}
				if (tbCurr.Text != "")
				{
					Change = 
						Change 
						+ float.Parse(tbCurr.Text.ToString(), NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands|NumberStyles.AllowLeadingSign);
					ChangeFlag = ChangeFlag + 1;
				}
                if (i.Cells[6].Text != "")
                {
                    if (i.Cells[6].Text != "&nbsp;")
                    {
                        Req = Req + float.Parse(i.Cells[6].Text, NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands|NumberStyles.AllowLeadingSign);
                    }
                }
            }	
			if (ChangeFlag == 0)
			{
				Exit();
			}
			else
			{
				CurrBudChange = CurrBud + Change;
				DiffBudD = 
					float.Parse(Session["BudAmt"].ToString(), NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands|NumberStyles.AllowLeadingSign)
					 - CurrBudChange;
				lblBudDist.Text="Distributed below " + CurrBudChange.ToString();
				if (DiffBudD >= 0)
				{
					lblDiff.Text = "Undistributed Budget: " + DiffBudD.ToString();
				}
				else
				{
					lblDiff.Text = "Overdistributed Budget: " + DiffBudD.ToString();
					lblDiff.ForeColor=Color.White;
				}
				lblReq.Text="Budget Required per Work Program : " + Req.ToString();
			}
			/* /Check 1
			if (CurrBud + Change 
				>
				float.Parse(Session["BudAmt"].ToString(), NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands|NumberStyles.AllowLeadingSign)
				)
			{
				lblContents.Text = "You may not distribute more than the funds available for this budget."
					+ "currbud" + CurrBud.ToString() + "change" + Change.ToString();
				Rules = 2;
			}
			else if (CurrBud + Change > 0)
			{
				lblContents.Text = "You may not distribute more than the funds available for this budget."
					+ "currbud" + CurrBud.ToString() + "change" + Change.ToString();
				Rules = 3;
			}*/
		}
		private void assignValues()
		{
			if (Session["Status"].ToString() != "Open")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tbOrig = (TextBox)(i.Cells[2].FindControl("txtOrig"));
					if (Session["Status"].ToString() == "Created")
					{
						if (i.Cells[3].Text == "&nbsp;")
						{
							tbOrig.Text = "";
						}
						else
						{
							tbOrig.Text = i.Cells[3].Text;
						}
					}
				}
			}
			else
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tbCurr = (TextBox)(i.Cells[5].FindControl("txtCurr"));
				{
					if (i.Cells[5].Text == "&nbsp;")
					{
						tbCurr.Text = "";
					}
					else
					{
						tbCurr.Text = i.Cells[5].Text;
					}
				}
				}
			}
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Revs")
			{
				Session["BDOId"] = e.Item.Cells[0].Text;
				Session["BDOrgName"] = e.Item.Cells[1].Text;
				Session["CurrBAmt"] = e.Item.Cells[4].Text;
				Session["ReqBAmt"] = e.Item.Cells[6].Text;
				Session["CBORevs"]="frmBudOrgsD";
				Response.Redirect (strURL + "frmBORevisions.aspx?");
			}
            else if (e.CommandName == "Tasks")
			{
                Session["BDOId"] = e.Item.Cells[0].Text;
                Session["MgrId"]=e.Item.Cells[11].Text;
				Session["MgrName"] = e.Item.Cells[1].Text;
                Session["COrgLocServices"] = "frmBudOrgsD";
				Response.Redirect (strURL + "frmOrgLocServices.aspx?");
			}
            else if (e.CommandName == "Outputs")
            {
                Session["CPSEPO"] = "frmBudOrgsD";
                Session["BDOId"] = e.Item.Cells[0].Text;
                Session["BDOrgName"] = e.Item.Cells[1].Text;
                //Session["ProcessName"] = e.Item.Cells[1].Text; to be added
                //Session["PSEPID"] = e.Item.Cells[0].Text; to be added
                Response.Redirect(strURL + "frmPSEPO.aspx?");
            }
            else if (e.CommandName == "Clients")
            {
                Session["CPSEPC"] = "frmBudOrgsD";
                Session["BOId"] = e.Item.Cells[0].Text;
                Session["BDOrgName"] = e.Item.Cells[1].Text;
                //Session["ProcessName"] = e.Item.Cells[1].Text;
                //Session["PSEPID"] = e.Item.Cells[0].Text;
                Response.Redirect(strURL + "frmPSEPClient.aspx?");
            }
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_DeleteBudOrgs";
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
			redirectNow();
		}
		private void redirectNow()
		{
			Session["CBOSel"]="frmBudOrgsD";
			Response.Redirect (strURL + "frmBudOrgsSel.aspx?");
		}
		private void updateOrigAmt()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbOrigAmt = (TextBox)(i.Cells[2].FindControl("txtOrig"));
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateBudOrgsAmt";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add("@OrigAmt", SqlDbType.Decimal);
				if (tbOrigAmt.Text != "")
				{
					cmd.Parameters ["@OrigAmt"].Value=decimal.Parse(tbOrigAmt.Text, NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands);
				}
				cmd.Parameters.Add("@Id", SqlDbType.Int);
				cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			}
		}
		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (Session["BRS"].ToString() == "0")
			{
				updateOrigAmt();
				Exit();
			}

			else
			{
				if (btnExit.Text == "OK")
				{
					{
						if (Session["Status"].ToString() == "Open")
						
						{
							computeBudget();
							if (Rules == 0)
							btnExit.Text = "Confirm";
							txtDesc.Visible=true;
							lblContents.ForeColor=Color.White;
							lblContents.Text="Please add reasons for this budget change below, and press 'OK' to confirm"
								+ " or 'Cancel' to discard changes";
						}
						else
						{
							updateOrigAmt();
							Exit();
						}
					}
				
				}
				else
				{
					updateJournal();
					retrieveBOJournals();
					Exit();
				}
			}
			
		}
		private void updateJournal()
		{		
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_UpdateBOJournals";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
			if (txtDesc.Text != "")
			{
				cmd.Parameters ["@Desc"].Value=txtDesc.Text;
			}
			cmd.Parameters.Add("@BudgetsId", SqlDbType.Int);
			cmd.Parameters ["@BudgetsId"].Value=Session["BudgetsId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void retrieveBOJournals()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_retrieveBOJournalsId";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@BudgetsId", SqlDbType.Decimal);
			cmd.Parameters ["@BudgetsId"].Value=Session["BudgetsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BOJ");
			if (ds.Tables["BOJ"].Rows.Count == 1)
			{
				I = Int32.Parse(ds.Tables["BOJ"].Rows[0][0].ToString());
				updateBOAmts();
				updateCurrAmt(); //This summarizes BOAmts and is done to simplify read queries for reporting 
				//as well as for loadData() for this form.
			}
			else
			{
				lblContents.Text="System Error.  Journal entry not created.  Please contact System Administrator.";
			
			}
		}
		private void updateCurrAmt()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbCurrAmt = (TextBox)(i.Cells[5].FindControl("txtCurr"));
			{
				if (tbCurrAmt.Text !="")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_UpdateBudOrgsCAmt";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@BOId", SqlDbType.Int);
					cmd.Parameters ["@BOId"].Value=Int32.Parse(i.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
			}
		}
		private void updateBOAmts()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbCurrAmt = (TextBox)(i.Cells[5].FindControl("txtCurr"));
			{
				if (tbCurrAmt.Text !="")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_UpdateBOAmts";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@BOJournalsId", SqlDbType.Int);
					cmd.Parameters ["@BOJournalsId"].Value=I;
					cmd.Parameters.Add("@BOId", SqlDbType.Int);
					cmd.Parameters ["@BOId"].Value=Int32.Parse(i.Cells[0].Text);
					cmd.Parameters.Add("@CurrAmt", SqlDbType.Decimal);
					cmd.Parameters ["@CurrAmt"].Value=decimal.Parse(tbCurrAmt.Text, NumberStyles.AllowDecimalPoint|NumberStyles.AllowThousands|NumberStyles.AllowLeadingSign);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
			}
		}

		private void Exit()
		{
            Session["MgrName"] = null;
			Response.Redirect (strURL + Session["CBudOrgsD"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}

}
	