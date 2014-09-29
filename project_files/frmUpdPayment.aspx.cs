using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
	public partial class frmUpdPayment : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=Session["OrgName"].ToString();	
			lblLoc.Text="Location: " + Session["LocationName"].ToString();
			lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
				+ Session["CurrName"].ToString();
			lblService.Text="Service: " + Session["ServiceName"].ToString();
			if (Session["CBudOrgs"].ToString() == "frmTasks")
			{
				lblDel.Text="Deliverable: " + Session["EventName"].ToString();
				lblTask.Text=Session["PJNameS"].ToString() + ": "
					+ Session["ProjName"].ToString()
					+ " (Task: " + Session["ProcName"].ToString() + ")";
			}
			else if (Session["CBudOrgs"].ToString() == "frmMainWP")
			{
				lblDel.Text="Task: " + Session["ProcName"].ToString();
			}
			if (Session["CPay"].ToString() == "frmProcSReq")
			{
				lblRole.Text="Role: " + Session["PSEPSName"].ToString();
			}
			else if (Session["CPay"].ToString() == "frmProcSerReq")
			{
				lblRole.Text="Resource:  " + Session["SerName"].ToString();
			}
			lblContents1.Text=Request.Params["btnAction"] + " Payment Authorization";

			if (!IsPostBack)
			{
				btnAction.Text= Request.Params["btnAction"];
				loadProcProcures();
				if (Request.Params["btnAction"].ToString() == "Update")
				{
					loadPayments();
				}
				else
				{
					txtPayDate.Text = DateTime.Now.ToString("MM-dd-yyyy");
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
		private void loadProcProcures()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveProcurePay";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProcProcuresId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procure");
			lblDesc.Text=ds.Tables["Procure"].Rows[0][0].ToString();
			lblCurrency.Text=ds.Tables["Procure"].Rows[0][1].ToString();			
		}
		private void loadPayments()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveProcPay";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse(Id);			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Pay");
			txtPayAmt.Text=ds.Tables["Pay"].Rows[0][0].ToString();
			lstStatus.SelectedIndex=Int32.Parse(ds.Tables["Pay"].Rows[0][1].ToString());
			txtPayDate.Text=ds.Tables["Pay"].Rows[0][2].ToString();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateProcPay";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@ProcProcuresId",SqlDbType.Int);
				cmd.Parameters["@ProcProcuresId"].Value=Int32.Parse(Session["ProcProcuresId"].ToString());
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				cmd.Parameters["@Status"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@ReqDate",SqlDbType.DateTime);
				cmd.Parameters["@ReqDate"].Value=DateTime.Parse(txtPayDate.Text);
				if (txtPayAmt.Text != "")
				{
					cmd.Parameters.Add ("@PayAmt",SqlDbType.Decimal);
					cmd.Parameters["@PayAmt"].Value=Decimal.Parse(txtPayAmt.Text, NumberStyles.Any);
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddProcPay";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ProcProcuresId",SqlDbType.Int);
				cmd.Parameters["@ProcProcuresId"].Value=Int32.Parse(Session["ProcProcuresId"].ToString());
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				cmd.Parameters["@Status"].Value=Int32.Parse(lstStatus.SelectedItem.Value);
				if (txtPayAmt.Text != "")
				{
					cmd.Parameters.Add ("@PayAmt",SqlDbType.Decimal);
					cmd.Parameters["@PayAmt"].Value=Decimal.Parse(txtPayAmt.Text, NumberStyles.Any);
				}
				cmd.Parameters.Add ("@ReqDate",SqlDbType.DateTime);
				cmd.Parameters["@ReqDate"].Value=DateTime.Parse(txtPayDate.Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			Done();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdPayments"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}	

}
