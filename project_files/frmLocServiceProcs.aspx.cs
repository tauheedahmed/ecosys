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
	public partial class frmLocServiceProcs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private int I=0;

	
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

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				loadData();
				refreshGrid();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveLocSProcs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
			cmd.Parameters["@ProfileId"].Value=Session["ProfileId"].ToString();
			cmd.Parameters.Add ("@TaskType",SqlDbType.NVarChar);
			cmd.Parameters["@TaskType"].Value=Session["TaskType"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"LocSProcs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			checkUpdate();
			if (I>0)
			{
				updateGrid();
			}
			Exit();
		}
		private void checkUpdate()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				if (cb.Checked)
				{
					++I;
				}
			}
		}
		private void Exit()
		{
			if (I>0)
			{
				Response.Redirect (strURL + Session["CLSProcs"].ToString() + ".aspx?");
			}
			else
			{
				Response.Redirect (strURL + "frmLocs.aspx?");
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			
				{
				/*
				 * SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTasks";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			if (Session["startForm"].ToString() == "frmMainEPS")
			{ 
				cmd.Parameters.Add ("@TaskType",SqlDbType.NVarChar);
				cmd.Parameters["@TaskType"].Value=Session["TaskType"].ToString();
			}
			else
			{
				cmd.Parameters.Add ("@ServiceId",SqlDbType.Int);
				cmd.Parameters["@ServiceId"].Value=Session["ServiceId"].ToString();
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Tasks");
				 */
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_RetrieveTasks";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@LocId",SqlDbType.Int);
					cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
					cmd.Parameters.Add ("@ProcId",SqlDbType.Int);
					cmd.Parameters["@ProcId"].Value=i.Cells[0].Text;
					cmd.Parameters.Add ("@TaskType",SqlDbType.NVarChar);
					cmd.Parameters["@TaskType"].Value=Session["TaskType"].ToString();
					cmd.Connection.Open();
					if (cmd.ExecuteScalar() != null) 
					{
						cb.Checked = true;
						cb.Enabled=false;
						lblContents1.Visible=true;
					}
					cmd.Connection.Close();
			}
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
				if ((cb.Checked) &(cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateTasksfromProfiles";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
					cmd.Parameters.Add ("@LocId",SqlDbType.Int);
					cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
					cmd.Parameters.Add ("@ProcId",SqlDbType.Int);
					cmd.Parameters["@ProcId"].Value=i.Cells[0].Text;
					cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
					cmd.Parameters["@Name"].Value=i.Cells[1].Text;
					cmd.Parameters.Add ("@TaskType",SqlDbType.NVarChar);
					cmd.Parameters["@TaskType"].Value=Session["TaskType"].ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			checkUpdate();
			Exit();
		}
	}

}