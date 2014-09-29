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
	/// Summary description for frmProcedureSteps.
	/// </summary>
	public partial class frmTesting : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
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
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.cancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.editCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);

		}
		#endregion
		private void Load_Procedures()
		{
			if (!IsPostBack)
				loadData();
		}

		private void loadData()
			
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTesting";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Process",SqlDbType.Int);
			cmd.Parameters["@Process"].Value=Request.Params["Process"];
			lblOrg.Text=Request.Params["OrgName"];
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcedureSteps");
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			lblMN.Text=Request.Params["ModeName"];
			lblPN.Text = Request.Params["ProcessName"];
		}
		private void editCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			DataGrid1.DataSource = (DataSet)Session["ds"];
			DataGrid1.DataBind();
		}
		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateTesting";
			cmd.Connection=this.epsDbConn;
			TextBox txtStartDate = (TextBox)e.Item.Cells[1].Controls[0];
			TextBox txtEndDate = (TextBox)e.Item.Cells[2].Controls[0];
			TextBox txtStatus = (TextBox)e.Item.Cells[3].Controls[0];
			TextBox txtResults = (TextBox)e.Item.Cells[4].Controls[0];
			TextBox txtComments = (TextBox)e.Item.Cells[5].Controls[0];

			cmd.Parameters.Add ("@StartDate",SqlDbType.SmallDateTime);
			cmd.Parameters["@StartDate"].Value= txtStartDate.Text;
			cmd.Parameters.Add ("@EndDate",SqlDbType.SmallDateTime);
			cmd.Parameters["@EndDate"].Value= txtEndDate.Text;
			cmd.Parameters.Add ("@Status",SqlDbType.NVarChar);
			cmd.Parameters["@Status"].Value= txtStatus.Text;
			cmd.Parameters.Add ("@Results",SqlDbType.NVarChar);
			cmd.Parameters["@Results"].Value= txtResults.Text;
			cmd.Parameters.Add ("@Comments",SqlDbType.NText);
			cmd.Parameters["@Comments"].Value= txtComments.Text;

			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value= Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			DataGrid1.EditItemIndex = -1;
			loadData();
		}

		private void cancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			DataGrid1.DataSource = (DataSet)Session["ds"];
			DataGrid1.DataBind();
		}

	}
}
