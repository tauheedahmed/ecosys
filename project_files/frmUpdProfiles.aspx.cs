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
	public partial class frmUpdProfiles : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string Id;
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
		private int GetIndexOfSelection (string s)
		{
			return (lstPerson.Items.IndexOf (lstPerson.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblFunction.Text=Request.Params["btnAction"] + " Profile";
	
			if (!IsPostBack)
			{
				loadVisibility();
				loadPeople();
				btnAction.Text= Request.Params["btnAction"];
				txtName.Text=Request.Params["Name"];				
				txtDesc.Text=Request.Params["Desc"];
				lstVisibility.BorderColor=System.Drawing.Color.Navy;
				lstVisibility.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex = GetIndexOfVisibility (Request.Params["Vis"]);
				lstPerson.SelectedIndex = GetIndexOfSelection (Request.Params["PeopleId"]);
                /*if (Session["ProfileType"].ToString() == "Producer")
                {
                        cbxHouseholds.Visible = false;
                }
                else if (Request.Params["btnAction"] == "Update")
                {
                    if (Request.Params["Households"] == "0")
                        {
                            cbxHouseholds.Checked = false;
                        }
                    else
                    {
                        cbxHouseholds.Checked = true;
                    }
                }
                else
                {
                    cbxHouseholds.Checked = false;
                    cbxStatus.Checked = false;
                }*/
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
		private void loadPeople() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrievePeopleList";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			/*cmd.CommandText="Select PeopleId, Fname + ' ' + LName as Name from People"
				+ " inner join Staffing"
				+ " on People.Id = Staffing.PeopleId"
				+ " Where Staffing.OrgId = " + lstOrganization.SelectedItem.Value.ToString();*/
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"People");
			lstPerson.DataSource = ds;			
			lstPerson.DataMember= "People";
			lstPerson.DataTextField = "Name";
			lstPerson.DataValueField = "Id";
			lstPerson.DataBind();
			//lblOrg.Text=Session["DomainId"].ToString();
		}
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
				cmd.CommandText="eps_UpdateProfile";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value=lstPerson.SelectedItem.Value;
                /*if (Session["ProfileType"].ToString() == "Consumer")
                {
                    cmd.Parameters.Add ("@AllHH",SqlDbType.Int);
                 
                    if (cbxHouseholds.Checked)
                    {
                        cmd.Parameters["@AllHH"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@AllHH"].Value = 0;
                    }
                }*/
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                if (cbxStatus.Checked)
                {
                    cmd.Parameters["@Status"].Value = 1;
                }
                else
                {
                    cmd.Parameters["@Status"].Value = 0;
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddProfile";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@Type",SqlDbType.NText);
				cmd.Parameters["@Type"].Value= Session["ProfileType"].ToString();
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value=lstPerson.SelectedItem.Value;
                /*if (Session["ProfileType"].ToString() == "Consumer")
                {
                    cmd.Parameters.Add("@AllHH", SqlDbType.Int);

                    if (cbxHouseholds.Checked)
                    {
                        cmd.Parameters["@AllHH"].Value = 1;
                    }
                    else
                    {
                        cmd.Parameters["@AllHH"].Value = 0;
                    }
                }*/
                cmd.Parameters.Add("@Status", SqlDbType.Int);
                if (cbxStatus.Checked)
                {
                    cmd.Parameters["@Status"].Value = 1;
                }
                else
                {
                    cmd.Parameters["@Status"].Value = 0;
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}

		}
		private void Done()
		{
			Response.Redirect (strURL + "frmProfiles.aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}


	}	

}
