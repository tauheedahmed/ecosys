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
	public partial class frmInventory : System.Web.UI.Page
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
            if (Session["CInv"].ToString() == "frmProcRReq")
            {
                btnOK.Visible = false;btnAdd.Text = "Cancel";
                DataGrid1.Columns[1].Visible = true;//ItemName
                DataGrid1.Columns[2].Visible = true;//OrgName
                DataGrid1.Columns[3].Visible = true;//LocName
                DataGrid1.Columns[4].Visible = true;//SubLocation
                DataGrid1.Columns[5].Visible = true;//Status
                DataGrid1.Columns[6].Visible = true;//btnSelect
                DataGrid1.Columns[7].Visible = false;//btnUpdate; btnDelete
                DataGrid1.Columns[8].Visible = false;//cbxSel
                DataGrid1.Columns[9].Visible = false;//OrgId
            }
            else if (Session["CInv"].ToString() == "frmMainMgr")
            {
                
                DataGrid1.Columns[1].Visible = true;//ItemName
                DataGrid1.Columns[2].Visible = false;//OrgName
                DataGrid1.Columns[3].Visible = true;//LocName
                DataGrid1.Columns[4].Visible = true;//SubLocation
                DataGrid1.Columns[5].Visible = true;//Status
                DataGrid1.Columns[6].Visible = false;//btnSelect
                DataGrid1.Columns[7].Visible = true;//btnUpdate; btnDelete
                DataGrid1.Columns[8].Visible = false;//cbxSel
                DataGrid1.Columns[9].Visible = false;//OrgId
            }

			if (!IsPostBack) 
			{				
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents1.Text="";
				loadData();
                
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveInventory";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
            cmd.Parameters.Add("@Caller", SqlDbType.Int);
            cmd.Parameters["@Caller"].Value = 1;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Inventory");
            if (ds.Tables["Inventory"].Rows.Count != 0)
                {
                    Session["ds"] = ds;
                    DataGrid1.DataSource = ds;
                    DataGrid1.DataBind();
                }
            else if (Session["CInv"].ToString() == "frmProcRReq")// i.e. if no inventory item and requestor is planner
            {
                Session["CPPR"] = "frmInventory";
                Session["btnAction"] = "Add";
                Response.Redirect(strURL + "frmUpdProcPReq.aspx?");
            }
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button btu = (Button)(i.Cells[7].FindControl("btnUpdate"));
				Button btd = (Button)(i.Cells[7].FindControl("btnDelete"));
				if (Session["OrgId"].ToString() != i.Cells[9].Text)
				{
					btu.Visible=false;
					btd.Visible=false;
					i.Cells[7].Text = "Externally Maintained";
				}
				
			}
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[10].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_AddProcureInventory";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@ProcurementsId", SqlDbType.Int);
					cmd.Parameters ["@ProcurementsId"].Value=Session["ProcurementsId"].ToString();
					cmd.Parameters.Add("@InventoryId", SqlDbType.Int);
					cmd.Parameters ["@InventoryId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            if (e.CommandName == "Select")
            {
                //if (Session["CallerPeople"].ToString() == "frmProcSReq")
                Session["InventoryId"] = e.Item.Cells[0].Text;
                Exit();
            }
			else if (e.CommandName == "Update")
			{
				Session["CallerUpdInv"]="frmInventory";
				Response.Redirect (strURL + "frmUpdInventory.aspx?"
					+ "&btnAction=Update"
					+ "&Id=" + e.Item.Cells[0].Text);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteInventory";
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
				Session["CallerUpdInv"]="frmInventory";	
				Response.Redirect (strURL + "frmUpdInventory.aspx?"
					+ "&btnAction=" + "Add");
			}
			else
			{
				Exit();
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CInv"].ToString() + ".aspx?");
		}
        protected void btnOK_Click(object sender, EventArgs e)
        {
            //updateGrid();
			Exit();	
        }
}

}
	