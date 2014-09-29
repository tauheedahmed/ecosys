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
	public partial class frmUpdRole: System.Web.UI.Page
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
		private int GetIndexOfRoles (string s)
		{
			return (lstParentRoles.Items.IndexOf (lstParentRoles.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblFunction.Text=Request.Params["btnAction"] + " Staff Role";
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                lstVisibility.Visible = false;
                lblVisibility.Visible = false;
                lblTitle.Text = "Service Models";
            }
            else
            {
                lblTitle.Text = "Business Models";
            }

			if (!IsPostBack)
			{
				btnAction.Text=Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];
				txtSeq.Text=Request.Params["Seq"];
                loadVisibility();
				loadRoleTypes();
				lstParentRoles.SelectedIndex = GetIndexOfRoles (Request.Params["ParentId"]);
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Visibility"]);
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
		private void loadRoleTypes() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Roles.Id, Roles.Name from Roles"
				+ " Where Roles.Visibility=1";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Roles");
			lstParentRoles.DataSource = ds;			
			lstParentRoles.DataMember= "Roles";
			lstParentRoles.DataTextField = "Name";
			lstParentRoles.DataValueField = "Id";
			lstParentRoles.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update")
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdateRoles";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Seq",SqlDbType.Int);
				cmd.Parameters["@Seq"].Value= Int32.Parse(txtSeq.Text);
				cmd.Parameters.Add ("@Visibility",SqlDbType.Int);
				cmd.Parameters["@Visibility"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@ParentId",SqlDbType.Int);
				cmd.Parameters["@ParentId"].Value=lstParentRoles.SelectedItem.Value;
				cmd.Connection.Open();
				SqlTransaction epsTrans = epsDbConn.BeginTransaction();
				cmd.Transaction = epsTrans;
				try 
				{
					cmd.ExecuteNonQuery();
					cmd.Transaction.Commit();
				}
				catch
				{
					cmd.Transaction.Rollback();
                    lblContents2.Text = "testing";
				}
				finally
				{
					cmd.Connection.Close();
					Done();
				}
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_AddRoles";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
                if (txtSeq.Text != "")
                {
                    cmd.Parameters.Add("@Seq", SqlDbType.Int);
                    cmd.Parameters["@Seq"].Value = Int32.Parse(txtSeq.Text);
                }
				cmd.Parameters.Add ("@Visibility",SqlDbType.Int);
				cmd.Parameters["@Visibility"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@ParentId",SqlDbType.Int);
				cmd.Parameters["@ParentId"].Value=lstParentRoles.SelectedItem.Value;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdRole"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}


	}	

}
