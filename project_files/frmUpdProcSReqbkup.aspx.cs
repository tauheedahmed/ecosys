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
	public partial class frmUpdProcSReqbkup: System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int BOId;
		int a, b;
		protected System.Web.UI.HtmlControls.HtmlForm frmAddProcSAR;
		private int GetIndexOfAptType (string s)
		{
			return (lstAptTypes.Items.IndexOf (lstAptTypes.Items.FindByValue(s)));
		}
		private int GetIndexOfTimeMeasure (string s)
		{
			if (s == "0")
			{
				return 0;
			}
			else if (s == "1")
			{
				return 1;
			}
			else if (s == "2")
			{
				return 2;
			}
			else if (s == "3")
			{
				return 3;
			}
			else 
			{
				return 4;
			}
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update")
			{
				Id=Session["ProcSARId"].ToString();
			}

			if (!IsPostBack)
			{
				lblOrg.Text=Session["OrgName"].ToString()
					+ ", Location: " + Session["LocationName"].ToString();
				if (Session["CPStaff"].ToString() == "frmOLPProjects")
				{
					lblContent1.Text="Request assignment of an individual, and/or identify the budget to carry out the process '"
						+ Session["ProcName"].ToString() + "', " + "for " + Session["ProjTypeNameS"].ToString()
						+ "' titled " + Session["ProjName"].ToString() + "'. ";
				}
				else
				{
					lblContent1.Text="Request assignment of an individual and/or identify the budget to carry out the process '"
						+ Session["ProcName"].ToString() + "'.";
				}
				btnAction.Text= Session["btnAction"].ToString();
				loadAptTypes();

				if (Session["btnAction"].ToString() == "Add")
				{
					if (Session["StaffActionId"] != null)//i.e. if StaffAction has been identified from frmStaffActionsProc
					{
						loadStaffAction();
					}					
				}
				else
				{	
					lstTimeMeasure.SelectedItem.Value="2";
					lstAptTypes.SelectedIndex=GetIndexOfAptType(Session["OSTId"].ToString());
					loadProcProcure();
					if (Session["StaffActionId"] != null)
					{
						loadStaffAction();
					}
					else if (Session["ContractId"] != null)
					{
						loadStaffAction();
					}
				}
				loadStaffTypeDetails();
				loadGrid();
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
			cmd.CommandText="fms_RetrieveProcSReq";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProcSARId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"PP");				
			txtDesc.Text=ds.Tables["PP"].Rows[0][0].ToString();
			txtTime.Text=ds.Tables["PP"].Rows[0][1].ToString();
			lstTimeMeasure.SelectedIndex=GetIndexOfTimeMeasure(ds.Tables["PP"].Rows[0][6].ToString());
			Session["TypeId"]=ds.Tables["PP"].Rows[0][4].ToString();
			
			if (ds.Tables["PP"].Rows[0][2].ToString() != "")
			{
				BOId=Int32.Parse(ds.Tables["PP"].Rows[0][2].ToString());
			}
			else
			{
				BOId=0;
			}
		
			if (ds.Tables["PP"].Rows[0][3].ToString() != "")
			{
				Session["ContractId"]=ds.Tables["PP"].Rows[0][3].ToString();
			}
			else
			{
				Session["ContractId"]=null;
				if (ds.Tables["PP"].Rows[0][4].ToString() != "")
				{
					Session["TypeId"]=Int32.Parse(ds.Tables["PP"].Rows[0][4].ToString());
				}
				if (ds.Tables["PP"].Rows[0][5].ToString() != "")
				{
					txtSalaryRate.Text=ds.Tables["PP"].Rows[0][5].ToString();
				}
				
			}
		}
		private void loadStaffAction()
		{
			lblAptType.Visible=false;
			lstAptTypes.Visible=false;
			lblSal.Text="Salary";
			txtSalaryRate.Enabled=false;

			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveProcSReqSA";		
			cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
			if (Session["StaffActionId"] != null)
			{
				cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["StaffActionId"].ToString());
			}
			else if (Session["ContractId"] != null)
			{
				cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["ContractId"].ToString());
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SAR");				
			lblName.Text="Person Assigned: " + ds.Tables["SAR"].Rows[0][0].ToString();
			lblAptStatus.Text="Appointment Status: " + ds.Tables["SAR"].Rows[0][1].ToString();
			Session["TypeId"]=Int32.Parse(ds.Tables["SAR"].Rows[0][9].ToString());
			Session["OrgIdSA"]=Int32.Parse(ds.Tables["SAR"].Rows[0][10].ToString());

			if (ds.Tables["SAR"].Rows[0][8].ToString() == "")
			{
				if (Session["ContractId"] != null)
				{
					btnSA.Visible=false;
				}
			}
			/*lblSalaryPeriod.Text=ds.Tables["SAR"].Rows[0][6].ToString() + "(s)";*/
			txtSalaryRate.Text=ds.Tables["SAR"].Rows[0][2].ToString();
			lblSal.Text="Salary";
			/*lblSalaryPeriod.Text=ds.Tables["SAR"].Rows[0][3].ToString()
				+ " per " + ds.Tables["SAR"].Rows[0][6].ToString();*/
			Session["SalaryPeriod"]=ds.Tables["SAR"].Rows[0][6].ToString();
		}

		private void loadStaffTypeDetails()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveStaffTypeDetails";
			cmd.Parameters.Add ("@StaffTypeId",SqlDbType.Int);
			if (Session["StaffActionId"] != null)//i.e. if StaffAction has been identified from frmStaffActionsProc
			{
				cmd.Parameters["@StaffTypeId"].Value=Int32.Parse(Session["TypeId"].ToString());
			}
			else
			{
				cmd.Parameters["@StaffTypeId"].Value=lstAptTypes.SelectedItem.Value;
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ost");
			lblSalaryPeriod.Text=ds.Tables["ost"].Rows[0][0].ToString()
				+ " per " + ds.Tables["ost"].Rows[0][1].ToString();
			Session["SalaryPeriod"]=ds.Tables["ost"].Rows[0][1].ToString();
			int TimeMeasure;
			int SalaryPeriod;
			switch (Session["SalaryPeriod"].ToString())
			{
				case "":
				case "Year":
					SalaryPeriod = 12 * 4 * 5 * 8;
					break;
				case "Month":
					SalaryPeriod = 4 * 5 * 8;
					break;
				case "Week":
					SalaryPeriod = 5 * 8;
					break;
				case "Day":
					SalaryPeriod = 8;
					break;
				default:
					SalaryPeriod = 1;
					break;
			}
			switch (Int32.Parse(lstTimeMeasure.SelectedItem.Value))
			{
				case 0:
					TimeMeasure = 12 * 4 * 5 * 8;
					break;
				case 1:
					TimeMeasure = 4 * 5 * 8;
					break;
				case 2:
					TimeMeasure = 5 * 8;
					break;
				case 3:
					TimeMeasure = 8;
					break;
				default:
					TimeMeasure = 1;
					break;
			}
			
			if ((txtTime.Text != "") & (txtSalaryRate.Text != ""))
			{
				lblBud.Text="Required Budget: "
					+ decimal.Round(((decimal.Parse(txtSalaryRate.Text) 
					* TimeMeasure * decimal.Parse(txtTime.Text))/SalaryPeriod),2)
					+ " " 
					+ ds.Tables["ost"].Rows[0][0].ToString();
			}
			else if ((txtTime.Text != "") & (txtSalaryRate.Text == ""))
			{
				lblBud.Text="Required Budget cannot be determined:  Salary Rate not indicated for this appointment.";
			}
			else if ((txtTime.Text == "") & (txtSalaryRate.Text != ""))
			{
				lblBud.Text="Required Budget cannot be determined:  Time Input not indicated for this request.";
			}
			else 
			{
				lblBud.Text="Required Budget cannot be determined:  Time Input and Salary Rate not indicated for this request.";
			}
		}
		private void loadAptTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="hrs_RetrieveOrgStaffTypes";		
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			if (Session["OrgIdSA"] == null)
			{
				cmd.Parameters["@OrgId"].Value=Int32.Parse(Session["OrgId"].ToString());
			}
			else
			{
				cmd.Parameters["@OrgId"].Value=Int32.Parse(Session["OrgIdSA"].ToString());	
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffTypes");
			lstAptTypes.DataSource = ds;			
			lstAptTypes.DataMember= "StaffTypes";
			lstAptTypes.DataTextField = "Name";
			lstAptTypes.DataValueField = "Id";
			lstAptTypes.DataBind();
		}
		private void loadGrid()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveBudOrgs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BudOrgs");
			if (ds.Tables["BudOrgs"].Rows.Count == 0)
			{
				lblContent1.Text="Warning.  There is no budget available for this Organization.";
				DataGrid1.Visible=false;
			}
			else
			{
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[6].FindControl("cbxSel"));
				if (i.Cells[0].Text==BOId.ToString())
				{
					cb.Checked=true;
				}
			}
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			//lblAptStatus.Text="Apt" + Session["ContractId"].ToString() + "C";
			a=0;
			b=0;
			checkGrid();
			if (a>1)
			{
				lblContent1.ForeColor=Color.Maroon;
				lblContent1.Text="Please Select only one budget to be charged.";
			}
			else if (a<1)
			{
				lblContent1.ForeColor=Color.Maroon;
				lblContent1.Text="You must identify the budget to be charged.";
			}
			else if (txtTime.Text == "")
			{
				lblContent1.ForeColor=Color.Maroon;
				lblContent1.Text="You must enter Time Input Required.";
			}
			else if (txtSalaryRate.Enabled == true)
			{
				if (txtSalaryRate.Text == "")
				{
					lblContent1.ForeColor=Color.Maroon;
					lblContent1.Text="You must enter the Proposed Salary.";
				}
				else
				{
					updateGrid();
				}
			}
			else 
			{
				updateGrid();
			}
		}
		private void checkGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[6].FindControl("cbxSel"));
				if (cb.Checked)
				{
					a=++a;
					b=Int32.Parse(i.Cells[0].Text);
				}
			}
			
		}
		private void updateGrid()
		{
			if (Session["btnAction"].ToString() == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateProcSReq";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ProcSARId"].ToString();
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@BOId",SqlDbType.Int);
				if (b != 0)
				{
					cmd.Parameters["@BOId"].Value=b;
				}
				if (txtTime.Text != "")
				{
					cmd.Parameters.Add ("@Time",SqlDbType.Decimal);
					cmd.Parameters["@Time"].Value=Decimal.Parse(txtTime.Text, NumberStyles.Any);
				}
				cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
				if (Session["StaffActionId"] != null)
				{
					cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["StaffActionId"].ToString());
				}
				else if (Session["ContractId"] != null)
				{
					cmd.Parameters["@StaffActionId"].Value=Int32.Parse(Session["ContractId"].ToString());

				}
				else
				{
					cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
					cmd.Parameters["@TypeId"].Value=Int32.Parse(lstAptTypes.SelectedItem.Value);
					cmd.Parameters.Add ("@SuggestedRate",SqlDbType.Decimal);
					
					if (txtSalaryRate.Text != "")
					{
						cmd.Parameters["@SuggestedRate"].Value=Decimal.Parse(txtSalaryRate.Text, NumberStyles.Any);
					}
				}
				cmd.Parameters.Add ("@TimeMeasure",SqlDbType.Int);
				cmd.Parameters["@TimeMeasure"].Value=Int32.Parse(lstTimeMeasure.SelectedItem.Value);
					
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (Session["btnAction"].ToString() == "Add")
			{
				lblOrg.Text="adds" + lstAptTypes.SelectedItem.Value.ToString() + "addstart";
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddProcSReq";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@StaffActionId",SqlDbType.Int);
				if (Session["StaffActionId"] != null)
				{
					cmd.Parameters["@StaffActionId"].Value=Session["StaffActionId"].ToString();
				}
				cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
				cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
				cmd.Parameters.Add ("@BOId",SqlDbType.Int);
				if (b != 0)
				{
					cmd.Parameters["@BOId"].Value=b;
				}
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@PSEPSId",SqlDbType.Int);
				cmd.Parameters["@PSEPSId"].Value=Session["PSEPSId"].ToString();
				if (Session["CPStaff"].ToString() == "frmOLPProjects")
				{
					cmd.Parameters.Add("@ProjectId",SqlDbType.Int);
					cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
				}
				if (txtTime.Text != "")
				{
					cmd.Parameters.Add ("@Time",SqlDbType.Decimal);
					cmd.Parameters["@Time"].Value=Decimal.Parse(txtTime.Text, NumberStyles.Any);
				}
				if (Session["StaffActionId"] == null)
				{
					cmd.Parameters.Add ("@TypeId",SqlDbType.Int);
					cmd.Parameters["@TypeId"].Value=Int32.Parse(lstAptTypes.SelectedItem.Value);
					if (txtSalaryRate.Text != "")
					{
						cmd.Parameters.Add ("@SuggestedRate",SqlDbType.Decimal);
						cmd.Parameters["@SuggestedRate"].Value=Decimal.Parse(txtSalaryRate.Text, NumberStyles.Any);
					}
				}

				cmd.Parameters.Add ("@TimeMeasure",SqlDbType.Int);
				cmd.Parameters["@TimeMeasure"].Value=Int32.Parse(lstTimeMeasure.SelectedItem.Value);
				
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}		
		private void Done()
		{
			Session["StaffActionId"]=null;
			Session["TypeId"] = null;
			Response.Redirect (strURL + Session["CUpdSAR"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		protected void btnSA_Click(object sender, System.EventArgs e)
		{
			getStaffAction();
		}
		private void getStaffAction()
		{
			Session["SA"]="frmUpdProcSReq";
			Response.Redirect (strURL + "frmStaffActionsProc.aspx?");
		}

		protected void lstAptTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			loadStaffTypeDetails();
		}

		protected void btnRecomputeBudget (object sender, System.EventArgs e)
		{
			loadStaffTypeDetails();
		}
	}
}

	
