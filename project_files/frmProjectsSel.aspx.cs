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
	public partial class frmProjectsSel: System.Web.UI.Page
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
			DataGrid1.Columns[1].HeaderText = "Inactive or Completed " + Session["PJName"].ToString();		
			if (!IsPostBack)
			{
                if (Session["MgrName"] == null)
				{
					lblOrg.Text=Session["OrgName"].ToString();
				}
				else
				{
					lblOrg.Text=Session["MgrName"].ToString();
				}
                lblService.Text = "Service: " + Session["ServiceName"].ToString();
                lblLoc.Text = "Location: " + Session["LocationName"].ToString();
                lblEventName.Text = "Type of " + Session["PJNameS"].ToString() + ": " + Session["EventName"].ToString();
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				loadData();
			}
				
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="wms_RetrieveProjects";
			cmd.Parameters.Add ("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add ("@PSEventsId",SqlDbType.Int);
			cmd.Parameters["@PSEventsId"].Value=Session["PSEventsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Projects");
			Session["ds"] = ds;
			if (ds.Tables["Projects"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContent1.Text="There are no inactive or completed "
				+ Session["PJName"].ToString()
				+ " created by the manager and at the location indicated above.";
				
			}
			else
			{
				lblContent1.Text="Click on the button titled 'Update' to update " 
					+ "a given " 
					+ Session["PJNameS"].ToString()
					+ ".";
			}
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSel"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Session["CUpdProject"]="frmProjectsSel";
			Session["ProjectId"]=e.Item.Cells[0].Text;
			Response.Redirect (strURL + "frmUpdProject.aspx?");			
		}

	}

}

