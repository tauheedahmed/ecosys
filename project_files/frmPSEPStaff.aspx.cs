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
	public partial class frmPSEPStaff : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
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
				if (!IsPostBack) 
				{	
					loadData();
					lblContents1.Text="Identify the various types of staff who would be needed"
							+ " to carry out the process '"
							+ Session["ProcessName"].ToString()
							+ "'.";
					lblContents2.Text="";
				}
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrievePSEPStaff";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProcsId",SqlDbType.Int);
			cmd.Parameters["@ProcsId"].Value=Session["ProcsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSEPSStaff");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignValues();
		}
		private void assignValues()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
				if (i.Cells[3].Text == "&nbsp;")
				{
					tbDesc.Text=null;
				}
				else
				{
					tbDesc.Text = i.Cells[3].Text;
				}
			}
		}
		private void updateGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_UpdatePSEPStaffDesc";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Desc", SqlDbType.NText);
					cmd.Parameters ["@Desc"].Value=tbDesc.Text;
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text.ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Session["CallerRolesAll"]="frmPSEPStaff";
			Response.Redirect (strURL + "frmRolesAll.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSEPStaff"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeletePSEPStaff";
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