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
using System.Globalization;
using System.Data.SqlClient;


namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmBudCurERs: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
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
				lblOrg.Text=Session["OrgName"].ToString();
                lblBudName.Text = "Budget: " + Session["FundsName"].ToString()
					+ " (Budget Currency: " + Session["Curr"].ToString() +  ")";
				lblContent1.Text="Please enter exchange rates for converting to "
						+ Session["Curr"].ToString() 
						+ " for all currencies (other than "
						+ Session["Curr"].ToString() + ") that may be used to make payments"
						+ " in which payments"
						+ " may be made and charged to this budget.  Commitments and Payments will be permitted"
						+ " only in currencies for which a budgeted exchange rate is provided.";
						 ;
				loadData();
			}
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveBudCurrERs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@FundsId",SqlDbType.Int);
				cmd.Parameters["@FundsId"].Value=Session["FundsId"].ToString();
				cmd.Parameters.Add ("@FundCurrId",SqlDbType.Int);
				cmd.Parameters["@FundCurrId"].Value=Session["FundCurrId"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"BCER");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtER"));
				if (tb.Text != "")
				{
					if (i.Cells[0].Text.StartsWith("&") == true)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
                        cmd.CommandText = "fms_AddFundCurrencies";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@CurrId", SqlDbType.Int);
						cmd.Parameters ["@CurrId"].Value=i.Cells[3].Text;
                        cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                        cmd.Parameters["@OrgId"].Value = Int32.Parse(Session["OrgId"].ToString());
                        cmd.Parameters.Add("@FY", SqlDbType.Int);
                        cmd.Parameters["@FY"].Value = Int32.Parse(Session["FY"].ToString());
                        cmd.Parameters.Add("@FundsId", SqlDbType.Int);
						cmd.Parameters ["@FundsId"].Value=Int32.Parse(Session["FundsId"].ToString());
						cmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
						cmd.Parameters ["@ExchangeRate"].Value=decimal.Parse(tb.Text, NumberStyles.Any);
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
					else
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
                        cmd.CommandText = "fms_UpdateFundCurrencies";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@Id", SqlDbType.Int);
						cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text);
						cmd.Parameters.Add("@CurrId", SqlDbType.Int);
						cmd.Parameters ["@CurrId"].Value=i.Cells[3].Text;
						cmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
						cmd.Parameters ["@ExchangeRate"].Value=decimal.Parse(tb.Text, NumberStyles.Any);
						
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
				else if (i.Cells[0].Text != "")
				{
					if (i.Cells[0].Text.StartsWith("&") == false)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="fms_DeleteBudCurrERs";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@Id", SqlDbType.Int);
						cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text);
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtER"));
				if (i.Cells[0].Text.StartsWith("&") == false)
				{
					tb.Text = i.Cells[4].Text;
				}
				else if (i.Cells[4].Text == Session["FundCurrId"].ToString())
					{
						tb.Text = "1";
					}
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerBCER"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				/*Response.Redirect (strURL + "frmUpdContactType.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[5].Text);*/
			}
			else if (e.CommandName == "Delete")
			{
				/*SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteContactType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();*/
			}
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}

}

