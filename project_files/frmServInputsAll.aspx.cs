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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmServInputsAll: System.Web.UI.Page
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
			Load_ServInputs();
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
		private void Load_ServInputs()
		{			
			Session["Caller99"]="frmResourcesAll";
			if (Session["btnAddOwn"].ToString() == "false")
			{
				btnAdd.Visible=false;
				DataGrid1.Columns[1].Visible=true;
				DataGrid1.Columns[9].Visible=false;
			}
			else
			{
				btnAdd.Visible=true;
				DataGrid1.Columns[1].Visible=false;
				DataGrid1.Columns[9].Visible=true;
			}
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				if (Session["Avail"].ToString() == "Institution")
				{
					lblAvail.Text="Resources available from Other Units";
				}
				else if (Session["Avail"].ToString() == "Public")
				{
					lblAvail.Text="Publicly Available Resources";
				}
				else if (Session["Avail"].ToString() == "Owner")
				{
					lblAvail.Text="Own Resources"; 
				}
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveResourcesAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@Avail",SqlDbType.NVarChar);
			cmd.Parameters["@Avail"].Value=Session["Avail"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServInputsAll");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();		
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[8].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from ResourceInputs"
					+ " Where ResourceInput=" + i.Cells[0].Text 
					+ " and ResourceOutput=" + Session["ResourceId"];
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteServiceInputs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ResourceId",SqlDbType.Int);
			cmd.Parameters["@ResourceId"].Value=Session["ResourceId"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@Avail",SqlDbType.NVarChar);
			cmd.Parameters["@Avail"].Value=Session["Avail"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[8].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdServInputs";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@ResourceOutput", SqlDbType.Int);
					cmd.Parameters ["@ResourceOutput"].Value=Session["ResourceId"].ToString();
					cmd.Parameters.Add("@ResourceInput", SqlDbType.Int);
					cmd.Parameters ["@ResourceInput"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		private void Exit()
		{
		  Response.Redirect (strURL + Session["Caller3"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["Caller3"].ToString() + ".aspx?");
		}
	}

}

