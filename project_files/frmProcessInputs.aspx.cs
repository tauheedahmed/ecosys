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
	/// Summary description for frmProcessInputs.
	/// </summary>
	public partial class frmProcessInputs : System.Web.UI.Page
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
			Load_Inputs();
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
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);

		}
		#endregion
		
		private void Load_Inputs()
		{
			if (!IsPostBack)
			{
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text="Procedure Name: " + Request.Params["Name"];
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProcResourceTypes";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProcId",SqlDbType.Int);
			cmd.Parameters["@ProcId"].Value=Request.Params["Id"];
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProcessInputs");
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}


		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProcInput";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			DataGrid1.DataSource = (DataSet)Session["ds"];
			DataGrid1.DataBind();
		}
		
		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateResources";
			cmd.Connection=this.epsDbConn;
			TextBox txtName = (TextBox)e.Item.Cells[1].Controls[0];
			TextBox txtUnit = (TextBox)e.Item.Cells[2].Controls[0];
			TextBox txtQty = (TextBox)e.Item.Cells[3].Controls[0];
			cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
			cmd.Parameters["@Name"].Value= txtName.Text;
			cmd.Parameters.Add ("@Unit",SqlDbType.NVarChar);
			//cmd.Parameters["@Unit"].Value= txtUnit.text;
			cmd.Parameters.Add ("@Qty",SqlDbType.Int);
			cmd.Parameters["@Qty"].Value= txtQty.Text;
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value= Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			DataGrid1.EditItemIndex = -1;
			loadData();
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				DataGrid1.EditItemIndex = -1;
				DataGrid1.DataSource = (DataSet)Session["ds"];
				DataGrid1.DataBind();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
		
		}



	}
}
