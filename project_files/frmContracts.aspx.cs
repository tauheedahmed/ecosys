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
	public partial class frmContracts : System.Web.UI.Page
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
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text="Contracts";
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveContractsPay";
			cmd.Parameters.Add("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Contracts");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				if (Session["OrgId"].ToString() != i.Cells[8].Text)
				{
					Button btU = (Button) (i.Cells[7].FindControl("btnUpdate"));
					Button btD = (Button) (i.Cells[7].FindControl("btnDelete"));
					btU.Visible=false;
					btD.Visible=false;
					i.Cells[7].Text="Created by Contractor";
				}
			}
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CallerUpdContract"]="frmContractsS";
				Session["btnAction"]="Update";
				Session["ContractId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdContractS.aspx?");

			}
			else if (e.CommandName == "Select")
			{
				Session["ProcProcuresId"] = e.Item.Cells[0].Text;
				Session["CPay"]="frmContracts";
				Session["LocName"]=e.Item.Cells[1].Text;
				Session["TaskName"]=e.Item.Cells[2].Text;
				Session["SupplierName"]=e.Item.Cells[4].Text;
				Session["GSName"]=e.Item.Cells[5].Text;
				Response.Redirect (strURL + "frmPayments.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_DeleteContract";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (btnAdd.Text=="Add")
			{
				Session["CallerUpdContract"]="frmContractsS";
				Session["btnAction"]="Add";
				Session["ContractId"]="0";
				Response.Redirect (strURL + "frmUpdContractS.aspx?");
			}
			else
			{
				Exit();
			}	
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["Caller"].ToString() + ".aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
	}

}
	