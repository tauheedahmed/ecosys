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
	public partial class frmStepSProcures : System.Web.UI.Page
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
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.deleteRow);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text="Procurement Actions";
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveSSProcures";		
			cmd.Parameters.Add ("@PSEPSID",SqlDbType.Int);
			cmd.Parameters["@PSEPSID"].Value=Session["PSEPSID"].ToString();	
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SSC");
			if (ds.Tables["SSC"].Rows.Count == 0)
			{
				//addContracts();
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
				if (i.Cells[2].Text == "")
				{
					i.Cells[2].Text = "Not Identified";
				}
				CheckBox cb = (CheckBox)(i.Cells[4].FindControl("cbxBkup"));

				if (i.Cells[6].Text == "0")
				{
					cb.Checked=false;
				}
				else
				{
					cb.Checked=true;
				}
			}
		}
		private void deleteRow(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteProcurement";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[7].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_AddContractProcures";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@ContractId", SqlDbType.Int);
					cmd.Parameters ["@ContractId"].Value=Session["ContractId"].ToString();
					cmd.Parameters.Add("@ProcurementsId", SqlDbType.Int);
					cmd.Parameters ["@ProcurementsId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}


		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CallerUpdProcure"]="frmStepSProcures";
				Session["btnAction"]="Update";
				Session["Id"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProcurement.aspx?");
			}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (btnAdd.Text=="Add")
			{
				Session["CallerUpdProcure"]="frmStepSProcures";
				Session["btnAction"]="Add";
				Session["Id"]="0";
				Response.Redirect (strURL + "frmUpdProcurement.aspx?");
			}
			else
			{
				Exit();
			}	
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CProcurements"].ToString() + ".aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (Session["Mode"].ToString() == "Read")
			{
				updateGrid();
			}
			Exit();
		}
	}

}
	