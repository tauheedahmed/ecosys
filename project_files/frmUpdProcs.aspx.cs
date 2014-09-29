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
	public partial class frmUpdProcs : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string Id;
		
		private int GetIndexOfVisibility (string s)
		{
			return (rblVis.Items.IndexOf (rblVis.Items.FindByValue(s)));
		}
		private int GetIndexOfServices (string s)
		{
			return (lstServices.Items.IndexOf (lstServices.Items.FindByValue(s)));
		}
        private int GetIndexOfPeople(string s)
        {
            return (lstPeople.Items.IndexOf(lstPeople.Items.FindByValue(s)));
        }
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update")
				{
					Id=Session["Id"].ToString();
				}
			if (!IsPostBack)
			{			
				btnAction.Text= Session["btnAction"].ToString();
				
                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    loadPeople();
                    loadVisibility();
				    loadServices();
                }
                else
                {
                    lblProfileMgr.Text = "Process Manager: " + Session["FName"].ToString() + " " + Session["LName"].ToString();
                    lblService.Text = "Service: " + Session["ServiceName"].ToString();
                    lstServices.Visible = false;
                    lstPeople.Visible = false;
                    rblVis.Visible = false;
                    lblVis.Visible = false;
                }
				if (Session["btnAction"].ToString() == "Update")
				{
					loadData();
				}
				else
				{
					rblVis.SelectedIndex=GetIndexOfVisibility ("1");
				}

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
			cmd.CommandText="wms_RetrieveProcsUpd";
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Id;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Upd");
			txtName.Text=ds.Tables["Upd"].Rows[0][0].ToString();
			txtDesc.Text=ds.Tables["Upd"].Rows[0][1].ToString();
			rblVis.SelectedIndex=GetIndexOfVisibility (ds.Tables["Upd"].Rows[0][2].ToString());
			lstServices.SelectedIndex=GetIndexOfServices (ds.Tables["Upd"].Rows[0][3].ToString());
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                lstPeople.SelectedIndex = GetIndexOfPeople(ds.Tables["Upd"].Rows[0][4].ToString());
            }
		}

		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=1;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			rblVis.DataSource = ds;			
			rblVis.DataMember= "Visibility";
			rblVis.DataTextField = "Name";
			rblVis.DataValueField = "Id";
			rblVis.DataBind();
		}
        private void loadPeople()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "hrs_RetrievePeople";
            cmd.Parameters.Add("@OrgId", SqlDbType.Int);
            cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
            cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
            cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
            cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
            cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
            cmd.Parameters.Add("@DomainId", SqlDbType.Int);
            cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
            cmd.Parameters["@ServiceTypesId"].Value = Session["ServicesId"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "People");
            lstPeople.DataSource = ds;
            lstPeople.DataMember = "People";
            lstPeople.DataTextField = "Name";
            lstPeople.DataValueField = "Id";
            lstPeople.DataBind();
        }
		private void loadServices()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveServiceTypes";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ServiceTypes");
			lstServices.DataSource = ds;			
			lstServices.DataMember= "ServiceTypes";
			lstServices.DataTextField = "Name";
			lstServices.DataValueField = "Id";
			lstServices.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
                SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateProcs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value= Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.VarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.VarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				
                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                    cmd.Parameters["@PeopleId"].Value = lstPeople.SelectedItem.Value;
                    cmd.Parameters.Add("@Vis", SqlDbType.Int);
                    cmd.Parameters["@Vis"].Value = rblVis.SelectedItem.Value;
                    cmd.Parameters.Add("@Services", SqlDbType.Int);
                    cmd.Parameters["@Services"].Value = lstServices.SelectedItem.Value;
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "wms_AddProcs";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@Name"].Value = txtName.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
                cmd.Parameters["@Desc"].Value = txtDesc.Text;
                cmd.Parameters.Add("@Vis", SqlDbType.Int);
                cmd.Parameters.Add("@Services", SqlDbType.Int);
                cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    cmd.Parameters["@PeopleId"].Value = lstPeople.SelectedItem.Value;
                    cmd.Parameters["@Services"].Value = lstServices.SelectedItem.Value;
                    cmd.Parameters["@Vis"].Value = rblVis.SelectedItem.Value;
                }
                else if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    cmd.Parameters["@PeopleId"].Value = Int32.Parse(Session["PeopleId"].ToString());
                    cmd.Parameters["@Services"].Value = Session["ServicesId"].ToString();
                    cmd.Parameters["@Vis"].Value = 5;
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                Done();
            }
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUPSEP"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}	
}
