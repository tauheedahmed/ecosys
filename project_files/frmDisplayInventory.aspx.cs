using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmDisplayInventory : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int GetIndexOfBackup (string s)
		{
			return (rblBackup.Items.IndexOf (rblBackup.Items.FindByValue(s)));
		}	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Session["Id"].ToString();
			if (!IsPostBack)
			{
				loadBackup();
				btnAction.Text= "OK";
				loadData();
			}
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
	
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTaskResource";
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["TaskResId"].ToString();
			cmd.Parameters.Add ("@Type",SqlDbType.VarChar);
			cmd.Parameters["@Type"].Value=Request.Params["Type"];
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Resources");

			lblOrg.Text=(Session["OrgName"]).ToString();
			rblBackup.SelectedIndex = 
				GetIndexOfBackup(Request.Params["BackupId"]);
			lblResType.Text= 
				"Type of Resource: " + Session["ResTypeName"].ToString();
			
			lblName.Text="Item Name: " + ds.Tables["Resources"].Rows[0][0].ToString();
			lblDesc.Text="Description: " + ds.Tables["Resources"].Rows[0][1].ToString();
			lblStatus.Text= "Status: " + ds.Tables["Resources"].Rows[0][2].ToString();
			lblLocation.Text="Location: " + ds.Tables["Resources"].Rows[0][3].ToString();
			lblEmail.Text="Email: " + ds.Tables["Resources"].Rows[0][5].ToString(); 
			lblUrl.Text="Website: " + ds.Tables["Resources"].Rows[0][6].ToString();
			lblPhone.Text="Phone: " + ds.Tables["Resources"].Rows[0][7].ToString();
			lblAddress.Text="Address: " + ds.Tables["Resources"].Rows[0][8].ToString();

			lblFunction.Text="This Resources is available from: "
					+ ds.Tables["Resources"].Rows[0][4].ToString()
					+ ".  Contact information available for this organization is as follows:";
		}
		private void loadBackup()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTaskResourceBackups";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"TaskResourceBackups");
			rblBackup.DataSource = ds;			
			rblBackup.DataMember= "TaskResourceBackups";
			rblBackup.DataTextField = "Name";
			rblBackup.DataValueField = "Id";
			rblBackup.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			updateTaskResources();
			Done();
		}
		
		private void updateTaskResources()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateTaskResource";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@TaskResId",SqlDbType.Int);
			cmd.Parameters["@TaskResId"].Value=Session["TaskResId"].ToString();
			cmd.Parameters.Add ("@BackupsId",SqlDbType.Int);
			cmd.Parameters["@BackupsId"].Value=rblBackup.SelectedItem.Value;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerDisInv"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}


	}	

}
