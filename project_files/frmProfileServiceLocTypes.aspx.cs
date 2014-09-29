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
	public partial class frmProfileServiceLocTypes : System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				loadData();
				if (Session["Mode"].ToString() == "Locs")
				{
					refreshGrid();
					btnAdd.Text="  Cancel  ";
					btnExit.Text="OK";
					DataGrid1.Columns[4].Visible=false;
					//DataGrid1.Columns[4].HeaderText="Check Selection";
					lblContents1.Text="Service: " + Session["ServiceName"].ToString();
					lblContents2.Text="Types of Locations";
					foreach (DataGridItem i in DataGrid1.Items)
					{	
						CheckBox cb = (CheckBox) (i.Cells[5].FindControl("cbxSel"));
						cb.Checked=true;
					}

				}
				else if (Session["Mode"].ToString() == "Profiles")
				{
					lblContents1.Text="Profile Name: " + Session["ProfileName"].ToString();
					lblContents2.Text="Service Name: " + Session["ServiceName"].ToString();
					btnAdd.Width=134;
					DataGrid1.Columns[5].Visible=false;
				}
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProfileSLocs";
			cmd.Connection=this.epsDbConn;
			if (Session["Mode"].ToString() == "Profiles")
			{
				cmd.Parameters.Add ("@ProfileServiceId",SqlDbType.Int);
				cmd.Parameters["@ProfileServiceId"].Value=Session["ProfileServicesId"].ToString();
			}
			if (Session["Mode"].ToString() == "Locs")
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
				cmd.Parameters["@ResTypeId"].Value=Session["ResTypeId"].ToString();
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSProcs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (Session["Mode"].ToString() == "Profiles")
			{
				Session["CLocTypesAll"]="frmProfileServiceLocTypes";
				Response.Redirect (strURL + "frmLocTypesAll.aspx?");
			}
			else
			{
				Exit();
			}
		}
		
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (Session["Mode"].ToString() == "Locs")
			{
				updateGrid();
			}
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSLocTypes"].ToString() + ".aspx?");
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			
			{
				CheckBox cb = (CheckBox)(i.Cells[5].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_RetrieveWPLocs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ServiceId",SqlDbType.Int);
				cmd.Parameters["@ServiceId"].Value=Session["ServiceId"].ToString();
				cmd.Parameters.Add ("@LocId",SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();				
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
			//deleteWPServices();
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[5].FindControl("cbxSel"));
				if ((cb.Checked) &(cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateLocsfromProfiles";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
					cmd.Parameters.Add ("@LocId",SqlDbType.Int);
					cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
					cmd.Parameters.Add ("@ServiceId",SqlDbType.Int);
					cmd.Parameters["@ServiceId"].Value=Session["ServiceId"].ToString();
					cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
					cmd.Parameters["@Name"].Value=i.Cells[2].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Procedures")
			{
				Session["CPSProcs"]="frmProfileServiceLocTypes";
				Session["ProfileServiceLocsId"]=e.Item.Cells[0].Text;
				Session["LocationName"]=e.Item.Cells[2].Text;
				Response.Redirect(strURL + "frmProfileServiceProcs.aspx?");
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileSL";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

	}

}