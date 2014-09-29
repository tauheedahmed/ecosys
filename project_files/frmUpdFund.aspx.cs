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
	public partial class frmUpdFund : System.Web.UI.Page
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
		private int GetIndexOfStatus (string s)
		{
			return (lstStatus.Items.IndexOf (lstStatus.Items.FindByValue(s)));
		}
		private int GetIndexOfTTs (string s)
		{
			return (lstTT.Items.IndexOf (lstTT.Items.FindByValue(s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			TransTypesId = 1;
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblFunction.Text=Request.Params["btnAction"] + " Fund";
			if (Request.Params["btnAction"].ToString() == "Update")
			{
			getFundAmt();
			}
			if (!IsPostBack)
			{
				loadFundStatus();
				loadVisibility();
				btnAction.Text= Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];
				lstStatus.SelectedIndex = GetIndexOfStatus (Request.Params["Status"]);
				lstVisibility.SelectedIndex = GetIndexOfVisibility (Request.Params["Vis"]);
				lstTT.SelectedIndex = GetIndexOfTTs (Request.Params["TTs"]);		
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
		private void loadFundStatus()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveFundStatus";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"FundStatus");
			lstStatus.DataSource = ds;			
			lstStatus.DataMember= "FundStatus";
			lstStatus.DataTextField = "Name";
			lstStatus.DataValueField = "Id";
			lstStatus.DataBind();
		}
		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			lstVisibility.DataSource = ds;			
			lstVisibility.DataMember= "Visibility";
			lstVisibility.DataTextField = "Name";
			lstVisibility.DataValueField = "Id";
			lstVisibility.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateFunds";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				cmd.Parameters["@Status"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddFund";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				cmd.Parameters["@Status"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			Done();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdFund"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void btnAct_Click(object sender, System.EventArgs e)
		{
		
		}
	}	

}
