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
	public partial class frmUpdBackups : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string Id;
		

		private int GetIndexOfOriginals (string s)
		{
			return (lstOriginal.Items.IndexOf (lstOriginal.Items.FindByValue(s)));
		}
		private int GetIndexOfBackups (string s)
		{
			return (lstBackup.Items.IndexOf (lstBackup.Items.FindByValue(s)));
		}

		private int GetIndexScope (string item)
		{
			if (btnAction.Text == "Update")
			{
				if (item.Trim() == "Incremental")
				{
					return 1;
				}
				else 
				{
					return 0;
				}
			}

			else
			{
				return 0;
			}
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString(); 
			lblAction.Text=btnAction.Text.ToString();
			
			if (!IsPostBack)
			{
				loadOriginal();
				loadBackup();
				btnAction.Text= Request.Params["btnAction"];
				txtTiming.Text=Request.Params["Timing"];				
				txtRetention.Text=Request.Params["Retention"];
				rblScope.SelectedIndex=GetIndexScope (Request.Params["Scope"]);
				lstOriginal.SelectedIndex = GetIndexOfOriginals (Request.Params["Resource"]);
				lstBackup.SelectedIndex = GetIndexOfBackups (Request.Params["Backup"]);
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

		private void loadOriginal() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Resources.Id, Resources.Name from Resources inner join"
				+ " ResourceTypes on Resources.Type=ResourceTypes.Id"
				+ " (Where SupplierOrganization =" +  Session["OrgId"].ToString()
				
				+ " or SupplierOrganization =" +  Session["OrgIdt"].ToString() + ")" 
				+ " and (ResourceTypes.ParentId='4' or ResourceTypes.ParentId='13')";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Original");
			lstOriginal.DataSource = ds;			
			lstOriginal.DataMember= "Original";
			lstOriginal.DataTextField = "Name";
			lstOriginal.DataValueField = "Id";
			lstOriginal.DataBind();
		}
		private void loadBackup() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Resources.Id, Resources.Name from Resources inner join"
				+ " ResourceTypes on Resources.Type=ResourceTypes.Id"
				+ " Where (SupplierOrganization =" +  Session["OrgId"].ToString()
				+ " or SupplierOrganization =" +  Session["OrgIdt"].ToString() + ")" 
				+ " and (ResourceTypes.ParentId='4' or ResourceTypes.ParentId='13')";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Backup");
			lstBackup.DataSource = ds;			
			lstBackup.DataMember= "Backup";
			lstBackup.DataTextField = "Name";
			lstBackup.DataValueField = "Id";
			lstBackup.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateBackups";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Resource",SqlDbType.Int);
				cmd.Parameters["@Resource"].Value=lstOriginal.SelectedItem.Value;
				cmd.Parameters.Add ("@Backup",SqlDbType.Int);
				cmd.Parameters["@Backup"].Value=lstBackup.SelectedItem.Value;
				cmd.Parameters.Add ("@Timing", SqlDbType.NVarChar);
				cmd.Parameters["@Timing"].Value=txtTiming.Text;
				cmd.Parameters.Add ("@Retention", SqlDbType.NVarChar);
				cmd.Parameters["@Retention"].Value=txtRetention.Text;
				cmd.Parameters.Add ("@Scope", SqlDbType.NVarChar);
				cmd.Parameters["@Scope"].Value=rblScope.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddBackups";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Resource",SqlDbType.Int);
				cmd.Parameters["@Resource"].Value=lstOriginal.SelectedItem.Value;
				cmd.Parameters.Add ("@Backup",SqlDbType.Int);
				cmd.Parameters["@Backup"].Value=lstBackup.SelectedItem.Value;
				cmd.Parameters.Add ("@Timing", SqlDbType.NVarChar);
				cmd.Parameters["@Timing"].Value=txtTiming.Text;
				cmd.Parameters.Add ("@Retention", SqlDbType.NVarChar);
				cmd.Parameters["@Retention"].Value=txtRetention.Text;
				cmd.Parameters.Add ("@Scope", SqlDbType.NVarChar);
				cmd.Parameters["@Scope"].Value=rblScope.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + "frmBackups.aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}	
}
