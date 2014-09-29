using System;
using System.Globalization;
using System.Collections;
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
	public partial class frmUpdActsJ : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int TransTypesId;
		private int ActTrans;
		private int ActNonTrans;
		private float FundAmt;
		private float FundAmtCr;
		private float FundAmtDr;
		private String FundCurr;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			TransTypesId = 1;
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblFunction.Text=Request.Params["btnAction"] + " Fund " + Request.Params["Name"];
			getFundAmt();
			if (!IsPostBack)
			{
				btnAction.Text= Request.Params["btnAction"];
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

		private void getFundAmt()
		{
			getActs();
			getFundAmtCr();
			getFundAmtDr();
			FundAmt=FundAmtCr - FundAmtDr;
			getFundCurr();
			lblFundAmt.Text=FundAmt.ToString() + " " + FundCurr;

		}
		private void getFundAmtCr()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveActBalCr";
			cmd.Parameters.Add("@ActsId",SqlDbType.Int);
			cmd.Parameters["@ActsId"].Value=ActTrans;
			cmd.Parameters.Add("@SubActsId",SqlDbType.Int);
			cmd.Parameters["@SubActsId"].Value=Id;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"FundBalCr");
			if (ds.Tables["FundBalCr"].Rows.Count == 0)
			{
				FundAmtCr=0;
			}
			else if (ds.Tables["FundBalCr"].Rows.Count == 1)
			{
				if (ds.Tables["FundBalCr"].Rows[0][0].ToString() == "")
				{
					 FundAmtCr=0;
				}
				else
				{
					FundAmtCr=float.Parse(ds.Tables["FundBalCr"].Rows[0][0].ToString(),
						NumberStyles.Any);
				}
			}
			//lblFunction.Text="Acts:  " + Acts + " SubActsId: " + Id;
		}
		private void getFundAmtDr()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveActBalDr";
			cmd.Parameters.Add("@ActsId",SqlDbType.Int);
			cmd.Parameters["@ActsId"].Value=ActTrans;
			cmd.Parameters.Add("@SubActsId",SqlDbType.Int);
			cmd.Parameters["@SubActsId"].Value=Id;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"FundBalDr");
			if (ds.Tables["FundBalDr"].Rows.Count == 0)
			{
				FundAmtDr=0;
			}
			else if (ds.Tables["FundBalDr"].Rows.Count == 1)
			{
				if (ds.Tables["FundBalDr"].Rows[0][0].ToString() == "")
				{
					FundAmtDr=0;
				}
				else
				{
					FundAmtDr=float.Parse(ds.Tables["FundBalDr"].Rows[0][0].ToString(),
						NumberStyles.Any);
				}
			}
		}
		private void getFundCurr()
		{
			FundCurr="US Dollars";
		}
		private void getActs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveActs";
			cmd.Parameters.Add("@TransTypesId",SqlDbType.Int);
			cmd.Parameters["@TransTypesId"].Value=TransTypesId;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Act");
			if (ds.Tables["Act"].Rows.Count == 0)
			{
				lblFunction.Text = "No account rules created for this transaction type!";
			}
			else
			{
				ActTrans=Int32.Parse(ds.Tables["Act"].Rows[0][0].ToString());
				ActNonTrans=Int32.Parse(ds.Tables["Act"].Rows[0][1].ToString());
			}
			
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdActsJ"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void btnAct_Click(object sender, System.EventArgs e)
		{
			if ((txtAmtInc.Text != "") & (txtAmtDec.Text != ""))
			{
				lblFunction.Text = "Sorry, you cannot indicate an increase as"
					+ " well as a decrease to the fund amount at the same time.";
				lblFunction.ForeColor=Color.Maroon;
			}
			else if ((txtAmtInc.Text == "") & (txtAmtDec.Text == ""))
			{
				lblFunction.Text = "Sorry, you have not indicated any increase or"
					+ " decrease to the fund amount.";
				lblFunction.ForeColor=Color.Maroon;
			}
			else 
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdActJournals";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ActLedgersId",SqlDbType.Int);
				cmd.Parameters["@ActLedgersId"].Value= Session["ActLedgersId"];
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
				cmd.Parameters.Add ("@Amt",SqlDbType.Int);
				cmd.Parameters.Add ("@ActsCr",SqlDbType.Int);
				cmd.Parameters.Add ("@ActsDr",SqlDbType.Int);	
				if (txtAmtInc.Text != "")
				{
					cmd.Parameters ["@ActsCr"].Value=ActTrans;
					cmd.Parameters.Add ("@SubActsCr",SqlDbType.Int);
					cmd.Parameters["@SubActsCr"].Value=Id;
					cmd.Parameters ["@ActsDr"].Value=ActNonTrans;//Int32Parse(Session["ActTrans"]);
					cmd.Parameters ["@Amt"].Value=decimal.Parse(txtAmtInc.Text,
						NumberStyles.Any);
				}
				else
				{
					cmd.Parameters ["@ActsCr"].Value=ActNonTrans;//Int32Parse(Session["ActTrans"]);
					cmd.Parameters ["@ActsDr"].Value=ActTrans;//Int32Parse(Session["ActTrans"]);
					cmd.Parameters.Add ("@SubActsDr",SqlDbType.Int);
					cmd.Parameters["@SubActsDr"].Value=Id;
					cmd.Parameters ["@Amt"].Value=decimal.Parse(txtAmtDec.Text,
						NumberStyles.Any);
				}
				if (txtDesc.Text != "")
				{
					cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
					cmd.Parameters["@Desc"].Value=txtDesc.Text;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			Done();
		
		
		}
	}	

}
