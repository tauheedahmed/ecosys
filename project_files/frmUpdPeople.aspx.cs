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
	public partial class frmAddPeople : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
        private int GetIndexOfLevel(string s)
        {
            return (rblLevel.Items.IndexOf(rblLevel.Items.FindByValue(s)));
        }

	
		protected void Page_Load(object sender, System.EventArgs e)
		{	
			
			if (!IsPostBack)
			{
                if (Session["startForm"].ToString() != "frmMainControl")
                {
                    lblLevel.Visible = false;
                    rblLevel.Visible = false;
                }
                else
                {
                    
                    rblLevel.SelectedIndex = GetIndexOfLevel(Request.Params["UserLevel"]);
                }

				loadVisibility();
				lblOrg.Text=Session["OrgName"].ToString();
				btnAction.Text= Request.Params["btnAction1"];
				lblAction.Text=btnAction.Text + " People";
				txtFName.Text=Request.Params["FName"];
				txtLName.Text=Request.Params["LName"];
				txtCPhone.Text=Request.Params["CPhone"];
				txtHPhone.Text=Request.Params["HPhone"];
				txtWPhone.Text=Request.Params["WPhone"];
				txtEmail.Text=Request.Params["Email"];
				txtAddr.Text=Request.Params["Addr"];
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);
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
			this.btnCancel.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Done);

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
		private void Done(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			Done();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_AddPeople";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@FName",SqlDbType.NVarChar);
				cmd.Parameters["@FName"].Value= txtFName.Text;
				cmd.Parameters.Add ("@LName",SqlDbType.NVarChar);
				cmd.Parameters["@LName"].Value= txtLName.Text;
				cmd.Parameters.Add ("@Addr",SqlDbType.NText);
				cmd.Parameters["@Addr"].Value= txtAddr.Text;
				cmd.Parameters.Add ("@Email", SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value=txtEmail.Text;
				cmd.Parameters.Add ("@HPhone", SqlDbType.NVarChar);
				cmd.Parameters["@Hphone"].Value=txtHPhone.Text;
				cmd.Parameters.Add ("@WPhone", SqlDbType.NVarChar);
				cmd.Parameters["@Wphone"].Value=txtWPhone.Text;
				cmd.Parameters.Add ("@CPhone", SqlDbType.NVarChar);
				cmd.Parameters["@Cphone"].Value=txtCPhone.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value= Session["OrgId"];
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    cmd.Parameters.Add("@UserLevel", SqlDbType.Int);
                    cmd.Parameters["@UserLevel"].Value = Int32.Parse(rblLevel.SelectedItem.Value);
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			
			else if (btnAction.Text == "Update")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdatePeople";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value= Request.Params["PeopleId"];;
				cmd.Parameters.Add ("@FName",SqlDbType.NVarChar);
				cmd.Parameters["@FName"].Value= txtFName.Text;
				cmd.Parameters.Add ("@LName",SqlDbType.NVarChar);
				cmd.Parameters["@LName"].Value= txtLName.Text;
				cmd.Parameters.Add ("@Addr",SqlDbType.NText);
				cmd.Parameters["@Addr"].Value= txtAddr.Text;
				cmd.Parameters.Add ("@Email", SqlDbType.NVarChar);
				cmd.Parameters["@Email"].Value=txtEmail.Text;
				cmd.Parameters.Add ("@HPhone", SqlDbType.NVarChar);
				cmd.Parameters["@Hphone"].Value=txtHPhone.Text;
				cmd.Parameters.Add ("@WPhone", SqlDbType.NVarChar);
				cmd.Parameters["@Wphone"].Value=txtWPhone.Text;
				cmd.Parameters.Add ("@CPhone", SqlDbType.NVarChar);
				cmd.Parameters["@Cphone"].Value=txtCPhone.Text;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    cmd.Parameters.Add("@UserLevel", SqlDbType.Int);
                    cmd.Parameters["@UserLevel"].Value = Int32.Parse(rblLevel.SelectedItem.Value);
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				if (Session["CallerUpdPeople"].ToString() == "frmMainStaff")
				{
					Session["FName"]=txtFName.Text;
					Session["LName"]=txtLName.Text;
					Session["Email"]=txtEmail.Text;
				}
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdPeople"].ToString() + ".aspx?");
		}
	}
}
