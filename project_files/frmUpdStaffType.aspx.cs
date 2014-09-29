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
	public partial class frmUpdStaffType : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}				
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblFunction.Text=Request.Params["btnAction"] + " Appointment Type";
			if (!IsPostBack)
			{
				loadVisibility();
				btnAction.Text= Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];
				lstVisibility.BorderColor=System.Drawing.Color.Navy;
				lstVisibility.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex = GetIndexOfVisibility (Request.Params["Vis"]);
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

		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdateStaffType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_AddStaffType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			Done();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdStaffType"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}	

}
