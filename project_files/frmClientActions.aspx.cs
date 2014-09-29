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
	public partial class frmClientActions: System.Web.UI.Page
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
			loadForm();
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
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text="The list of registered clients is provided below.  Click"
					+ " on 'Add' to add new clients.  Click on 'Update' to change"
					+ " the registration status of an existing client.";
				lblContent2.Text="";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveClientActions";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StaffActions");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			//refreshGrid();
		}
		/*private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				if (i.Cells[7].Text == "0")
				{
					i.Cells[3].Text = "No";
				}
				else
				{
					i.Cells[3].Text = "Yes";
				}
				if (i.Cells[8].Text == "0")
				{
					i.Cells[4].Text = "No";
				}
				else
				{
					i.Cells[4].Text = "Yes";
				}
				if ( Session["OrgId"].ToString() != i.Cells[9].Text)
				{
					Button btU = (Button)(i.Cells[9].FindControl("btnUpdate"));
					Button btD = (Button)(i.Cells[9].FindControl("btnDelete"));
					btU.Visible=false;
					btD.Visible=false;
					i.Cells[9].Text="Externally Managed"; 
				}
			}
		}*/

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CCA"]="frmClientActions";
			Session["btnAction"]="Add";
			Response.Redirect (strURL + "frmUpdClientAction.aspx?");
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CA"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				if (Session["CA"].ToString() == "frmProjCPeople")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.Connection=this.epsDbConn;
					cmd.CommandText="fms_AddProjCPeople";
					cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
					cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
					cmd.Parameters.Add ("@PSEPCID",SqlDbType.Int);
					cmd.Parameters["@PSEPCID"].Value=Session["PSEPCID"].ToString();
					cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
					cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
					cmd.Parameters.Add ("@ClientActionsId",SqlDbType.Int);
					cmd.Parameters["@ClientActionsId"].Value=e.Item.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					Exit();
				}
				else if (Session["CA"].ToString() == "frmOLPSEPCPeople")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.Connection=this.epsDbConn;
					cmd.CommandText="fms_AddOLPSEPCPeople";
					cmd.Parameters.Add ("@PSEPCID",SqlDbType.Int);
					cmd.Parameters["@PSEPCID"].Value=Session["PSEPCID"].ToString();
					cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
					cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
					cmd.Parameters.Add ("@ClientActionsId",SqlDbType.Int);
					cmd.Parameters["@ClientActionsId"].Value=e.Item.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					Exit();
				}
			}
			else if (e.CommandName == "Update")
			{
				Session["CCA"]="frmClientActions";
				Session["btnAction"]="Update";
				Session["Id"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdClientAction.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.Connection=this.epsDbConn;
				cmd.CommandText="fms_DeleteClientAction";
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CA"].ToString() + ".aspx?");
		}
	}
}

