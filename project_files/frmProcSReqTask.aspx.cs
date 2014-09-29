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
	public partial class frmProcSReqTask: System.Web.UI.Page
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
				lblOrg.Text=Session["OrgName"].ToString()
					+ ", Location: "
					+ Session["LocationName"].ToString();
				/*lblContents.Text="You may now assign one or more individuals to carry out the role of '"
					+ Session["PSEPSName"].ToString()
					+ "', to perform process titled '"
					+ Session["ProcName"].ToString()
					+ "', against "
					+ Session["ProjTypeNameS"].ToString()
					+ " titled '"
					+ Session["ProjName"].ToString() + "'";*/
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveProcSARs";
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add("@PSEPSID",SqlDbType.Int);
			cmd.Parameters["@PSEPSID"].Value=Session["PSEPSID"].ToString();
			cmd.Parameters.Add("@BOId",SqlDbType.Int);
			cmd.Parameters["@BOId"].Value=Session["BOId"].ToString();
			cmd.Parameters.Add("@ProjectId",SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procurements");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["btnAction"]="Add";
			Session["ProcSARId"]=0;
			Session["CUpdSARPath"] = "frmProcSReq";
			Session["CUpdSAR"]="frmProcSReq";
			Response.Redirect (strURL + "frmUpdProcSReq.aspx?");

		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CUpdSAR"]="frmProcSReq";
				Session["btnAction"]="Update";
				Session["ProcSARId"]=e.Item.Cells[0].Text;
				Session["ContractId"]=e.Item.Cells[4].Text;
				Session["OSTId"]=e.Item.Cells[6].Text;
				Response.Redirect (strURL + "frmUpdProcSReq.aspx?");
			}
			/*else if (e.CommandName == "StaffAction")
			{
				if (e.Item.Cells[4].Text.StartsWith("&") == true)
				{
					Session["SA"]="frmProcSReq";
					Session["ProcSARId"]=e.Item.Cells[0].Text;
					Response.Redirect (strURL + "frmStaffActions.aspx?");
				}
				else
				{
					Session["CSA"]="frmProcSReq";
					Session["btnAction"]="Update";
					Session["Id"]=e.Item.Cells[4].Text;
					Response.Redirect (strURL + "frmUpdStaffAction.aspx?");
				}
			}*/
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_DeleteProcSAR";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["COSA"].ToString() + ".aspx?");
		}

		protected void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Session["SA"]="frmUpdProcSReq";
			Session["CUpdSAR"]="frmProcSReq";
			Session["btnAction"]="Add";
			Response.Redirect (strURL + "frmStaffActionsProc.aspx?");
		}
	}

}

