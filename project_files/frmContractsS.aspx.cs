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
	public partial class frmContractsS : System.Web.UI.Page
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
            lblOrg.Text = Session["OrgName"].ToString();
            DataGrid1.Columns[0].Visible = false;//Id
            DataGrid1.Columns[1].Visible = false;//OrgIdSupplier
            if (Session["MgrOption"].ToString() == "Supply")
            {
                DataGrid1.Columns[2].Visible = false;//Supplier Name
                DataGrid1.Columns[3].Visible = true;//Contract Title
                DataGrid1.Columns[3].HeaderText = "Commitments";
                DataGrid1.Columns[4].Visible = true;//Contract Status
                DataGrid1.Columns[5].Visible = false;//StatusId
                DataGrid1.Columns[6].Visible = false;//btnSelect
                DataGrid1.Columns[7].Visible = false;//btnUpdate
                DataGrid1.Columns[8].Visible = false;//OrgId
                DataGrid1.Columns[9].Visible = true;//btnProcures
                DataGrid1.Columns[10].Visible = true;//btnDelete

                lblContents.Text = "Commitments";
                lblContents1.Text = "Listed below are commitments to provide community service"
                    + " by your organization at designated locations.";
            }
            else if (Session["MgrOption"].ToString() == "Plan")
            {
                DataGrid1.Columns[2].Visible = true;//Supplier Name
                DataGrid1.Columns[3].Visible = true;//Contract Title
                DataGrid1.Columns[4].Visible = true;//Contract Status
                DataGrid1.Columns[5].Visible = false;//StatusId
                DataGrid1.Columns[6].Visible = true;//btnSelect
                DataGrid1.Columns[7].Visible = false;//btnUpdate
                DataGrid1.Columns[8].Visible = false;//OrgId
                DataGrid1.Columns[9].Visible = false;//btnProcures
                DataGrid1.Columns[10].Visible = false;//btnDelete
            }
            else if (Session["MgrOption"].ToString() == "Procure")
            {
                DataGrid1.Columns[2].Visible = true;//Supplier Name
                DataGrid1.Columns[3].Visible = true;//Contract Title
                DataGrid1.Columns[4].Visible = true;//Contract Status
                DataGrid1.Columns[5].Visible = false;//StatusId
                DataGrid1.Columns[6].Visible = false;//btnSelect
                DataGrid1.Columns[7].Visible = true;//btnUpdate
                DataGrid1.Columns[8].Visible = false;//OrgId
                DataGrid1.Columns[9].Visible = true;//btnProcures
                DataGrid1.Columns[10].Visible = true;//btnDelete
               
            }
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveContractsSupplier";
            if (Session["MgrOption"].ToString() == "Supply")
            {
                cmd.CommandText = "fms_RetrieveContractsSupplier";
                cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                cmd.Parameters["@HHFlag"].Value = Session["HHFlag"].ToString();
            }
            else if (Session["MgrOption"].ToString() == "Procure")
            {
                cmd.CommandText = "fms_RetrieveContractsProvider";
            
            }
            
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Contracts");
			if (ds.Tables["Contracts"].Rows.Count == 0)
			{
				lblContents1.Visible=false;
				lblContents.Text="There are no contracts currently in effect for your organization.";
				DataGrid1.Visible=false;
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
            if (Session["MgrOption"].ToString() == "Supply")
            {
                refreshGrid2();
            }
            else if (Session["MgrOption"].ToString() == "Procure")
            {
                refreshGrid1();
            }
		}
        private void refreshGrid2()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                Button btP = (Button)(i.Cells[9].FindControl("btnProcures"));
                btP.Text = "Resources Made Available";
                btP.CommandName = "RAvailable";
            }
        }
        private void refreshGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                /*Button btD = (Button)(i.Cells[10].FindControl("btnDelete"));
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select Id from ProcProcures"// To be fixed
                    + " Where Id==" + Int32.Parse(i.Cells[0].Text); 
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Proc");
                if (ds.Tables["Contracts"].Rows.Count == 0)
                {
                    lblContents1.Visible = false;
                    lblContents.Text = "There are no contracts currently in effect for your organization.";
                    DataGrid1.Visible = false;
                }
                btD.Enabled = false;*/
            }
        }
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CallerUpdContract"]="frmContractsS";
				Session["Contract"]="Update";
				Session["ContractId"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdContractS.aspx?");

			}
			else if (e.CommandName == "Procurements")
			{
				Session["CCP"]="frmContractsS";
				Session["ContractId"]=e.Item.Cells[0].Text;
				Session["ContractSupplier"]=e.Item.Cells[2].Text;
				Session["ContractTitle"]=e.Item.Cells[3].Text;
                Session["CurrName"] = e.Item.Cells[11].Text;
				Response.Redirect (strURL + "frmContractProcures.aspx?");
			}
            else if (e.CommandName == "RAvailable")
            {
                Session["CCP"] = "frmContractsS";
                Session["ContractId"] = e.Item.Cells[0].Text;
                Session["ContractSupplier"] = e.Item.Cells[1].Text;
                Session["ContractTitle"] = e.Item.Cells[2].Text;
                Response.Redirect(strURL + "frmContractProcures.aspx?");
            }
			else if (e.CommandName == "Select")
			{
				Session["ContractIdSel"] = e.Item.Cells[0].Text;
				Exit();
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
				Session["Contract"]="Add";
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
			Response.Redirect (strURL + Session["CContracts"].ToString() + ".aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
}

}
	