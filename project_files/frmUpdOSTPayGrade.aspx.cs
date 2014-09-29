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
	public partial class frmUpdOSTPayGrade : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private float SalaryMax;
		private float SalaryMin;
		private float SalaryAve;
		private float SalaryOvt;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblContent.Text=Request.Params["btnAction"] + " Pay Grade";	
			lblSal.Text = "Note: Salary figures are in " + 
				Session["CurrName"] + " per " + Session["SalaryPeriod"];
			if (!IsPostBack)
			{
				btnAction.Text= Request.Params["btnAction"];
				if (Request.Params["btnAction"] == "Update")
				{
					loadData();
				}
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

		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrieveOSTPayGrade";
			cmd.Parameters.Add("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Request.Params["Id"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PGrade");
			if (ds.Tables["PGrade"].Rows.Count == 1)
			{

				if (ds.Tables["PGrade"].Rows[0][0].ToString() == "")
				{
					txtName.Text="";
				}
				else
				{
					txtName.Text=ds.Tables["PGrade"].Rows[0][0].ToString();
				}
				if (ds.Tables["PGrade"].Rows[0][1].ToString() == "1")
				{
					ckbStatus.Checked=true;
				}
				else
				{
					ckbStatus.Checked=false;
				}
				
				if (ds.Tables["PGrade"].Rows[0][2].ToString() == "")
				{
					SalaryMax=0;
				}
				else
				{
					SalaryMax=float.Parse(ds.Tables["PGrade"].Rows[0][2].ToString(),
						NumberStyles.Any);
				}
				if (ds.Tables["PGrade"].Rows[0][3].ToString() == "")
				{
					SalaryMin=0;
				}
				else
				{
					SalaryMin=float.Parse(ds.Tables["PGrade"].Rows[0][3].ToString(),
						NumberStyles.Any);
				}
				if (ds.Tables["PGrade"].Rows[0][4].ToString() == "")
				{
					SalaryAve=0;
				}
				else
				{
					SalaryAve=float.Parse(ds.Tables["PGrade"].Rows[0][4].ToString(),
						NumberStyles.Any);
				}
				if (ds.Tables["PGrade"].Rows[0][5].ToString() == "")
				{
					SalaryOvt=0;
				}
				else
				{
					SalaryOvt=float.Parse(ds.Tables["PGrade"].Rows[0][5].ToString(),
						NumberStyles.Any);
				}
				txtSalMax.Text=SalaryMax.ToString();
				txtSalMin.Text=SalaryMin.ToString();
				txtSalAve.Text=SalaryAve.ToString();
				txtOvt.Text=SalaryOvt.ToString();
				//lstCurr.SelectedIndex = GetIndexOfCurr(Curr.ToString());
				//lstSalPeriod.SelectedIndex = SalPeriod;
			}
			else 
			{
				lblContent.Text="Error.  Please Contact System Administrator.";
			}
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdatePayGrade";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				//cmd.Parameters.Add ("@CurrenciesId",SqlDbType.Int);
				//cmd.Parameters["@CurrenciesId"].Value=lstCurr.SelectedItem.Value;
				//cmd.Parameters.Add ("@SalPeriod",SqlDbType.Int);
				//cmd.Parameters["@SalPeriod"].Value=lstSalPeriod.SelectedItem.Value;
				cmd.Parameters.Add ("@SalMax",SqlDbType.Decimal);
				if (txtSalMax.Text != "")
				{
					cmd.Parameters["@SalMax"].Value=decimal.Parse(txtSalMax.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@SalMin",SqlDbType.Decimal);
				if (txtSalMin.Text != "")
				{
					cmd.Parameters["@SalMin"].Value=decimal.Parse(txtSalMin.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@SalAve",SqlDbType.Decimal);
				if (txtSalAve.Text != "")
				{
					cmd.Parameters["@SalAve"].Value=decimal.Parse(txtSalAve.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Ovt",SqlDbType.Decimal);
				if (txtOvt.Text != "")
				{
					cmd.Parameters["@Ovt"].Value=decimal.Parse(txtOvt.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (ckbStatus.Checked)
				{
					cmd.Parameters["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters["@Status"].Value=null;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_AddPayGrade";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@OrgStaffTypesId",SqlDbType.Int);
				cmd.Parameters["@OrgStaffTypesId"].Value=Session["OrgSTId"].ToString();
				cmd.Parameters.Add ("@SalMax",SqlDbType.Decimal);
				if (txtSalMax.Text != "")
				{
					cmd.Parameters["@SalMax"].Value=decimal.Parse(txtSalMax.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@SalMin",SqlDbType.Decimal);
				if (txtSalMin.Text != "")
				{
					cmd.Parameters["@SalMin"].Value=decimal.Parse(txtSalMin.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@SalAve",SqlDbType.Decimal);
				if (txtSalAve.Text != "")
				{
					cmd.Parameters["@SalAve"].Value=decimal.Parse(txtSalAve.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Ovt",SqlDbType.Decimal);
				if (txtOvt.Text != "")
				{
					cmd.Parameters["@Ovt"].Value=decimal.Parse(txtOvt.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (ckbStatus.Checked)
				{
					cmd.Parameters["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters["@Status"].Value=null;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			Done();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdPayGrade"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		}
	}	

