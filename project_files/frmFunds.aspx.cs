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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmFunds : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnAddTemp;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
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
			lblOrg.Text=Session["OrgName"].ToString() ;
			if (!IsPostBack) 
			{	
				loadData();
				lblContents.Text="";
			} 
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveFunds";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Funds");
			if (ds.Tables["Funds"].Rows.Count == 0)
			{
				redirectNow();
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();				
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button btD = (Button)(i.Cells[3].FindControl("btnDelete"));
				
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.Connection.Open();
				
				cmd.CommandText="Select FundsId from Budgets"
					+ " Where FundsId = " + i.Cells[0].Text;
				if (cmd.ExecuteScalar() != null) 
				{
					btD.Text= "In Use";
					btD.Enabled=false;
				}
				cmd.Connection.Close();
			}
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdFund"]="frmFunds";
				Session["Id"]=e.Item.Cells[0].Text;
				Session["Name"]=e.Item.Cells[1].Text;
				Session["Status"]=e.Item.Cells[2].Text;
				Response.Redirect (strURL + "frmUpdFund.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Status=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[3].Text
					);
			}
			else if (e.CommandName == "Acts")
			{
				Session["CUpdActsJ"]="frmFunds";
				Session["Id"]=e.Item.Cells[0].Text;
				Session["Name"]=e.Item.Cells[1].Text;
				Session["Status"]=e.Item.Cells[2].Text;
				Response.Redirect (strURL + "frmUpdActsJ.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Status=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[3].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_DeleteFund";
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
			Session["CUpdFund"]="frmFunds";
			Response.Redirect (strURL + "frmUpdFund.aspx?"
				+ "&btnAction=" + "Add");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CFunds"].ToString() + ".aspx?");
		}
	}

}
	