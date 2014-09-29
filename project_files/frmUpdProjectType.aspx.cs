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
	public partial class frmUpdProjectType : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.Label lblNameshort;
		private string Id;
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
		private int GetIndexOfService (string s)
		{
			return (lstService.Items.IndexOf (lstService.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblComment.Text=Request.Params["btnAction"] + " Project Type";
			lblOrg.Text=Session["OrgName"].ToString();
			if (!IsPostBack)
			{
				loadVisibility();
				loadService();
				btnAction.Text= Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];				
				txtNameshort.Text=Request.Params["Nameshort"];
				txtSeq.Text=Request.Params["Seq"];
				lstVisibility.BorderColor=System.Drawing.Color.Navy;
				lstVisibility.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex = GetIndexOfVisibility (Request.Params["Vis"]);
				lstService.BorderColor=System.Drawing.Color.Navy;
				lstService.ForeColor=System.Drawing.Color.Navy;
				lstService.SelectedIndex = GetIndexOfService (Request.Params["Ser"]);
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

		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			lstVisibility.DataSource = ds;			
			lstVisibility.DataMember= "Visibility";
			lstVisibility.DataTextField = "Name";
			lstVisibility.DataValueField = "Id";
			lstVisibility.DataBind();
		}
		private void loadService()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProjTypeServiceTypes";
			cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
			cmd.Parameters["@ProfileId"].Value=Session["ProfilesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ServiceTypes");
			lstService.DataSource = ds;			
			lstService.DataMember= "ServiceTypes";
			lstService.DataTextField = "Name";
			lstService.DataValueField = "Id";
			lstService.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateProjectType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Nameshort",SqlDbType.NVarChar);
				cmd.Parameters["@Nameshort"].Value=txtNameshort.Text;
				cmd.Parameters.Add ("@Seq",SqlDbType.Int);
				cmd.Parameters["@Seq"].Value=Int32.Parse(txtSeq.Text);
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Ser",SqlDbType.Int);
				cmd.Parameters["@Ser"].Value=lstService.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_AddProjectType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Nameshort",SqlDbType.NVarChar);
				cmd.Parameters["@Nameshort"].Value=txtNameshort.Text;
				cmd.Parameters.Add ("@Seq",SqlDbType.Int);
				cmd.Parameters["@Seq"].Value=Int32.Parse(txtSeq.Text);
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@Ser",SqlDbType.Int);
				cmd.Parameters["@Ser"].Value=lstService.SelectedItem.Value;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdProjectTypes"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}	

}
