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
	public partial class frmUpdClientAction : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		protected System.Web.UI.WebControls.RadioButtonList rblStatusSS;
		/*private int GetIndexOflstStaffTypes (string s)
		{
			return (lstStaffTypes.Items.IndexOf (lstStaffTypes.Items.FindByValue(s)));
		}
		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}

		private int GetIndexOfPayMethods (string s)
		{
			return (rblPayMethods.Items.IndexOf (rblPayMethods.Items.FindByValue(s)));
		}*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update")
			{
				Id=Session["Id"].ToString();
			}
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				/*loadVisibility();
				loadPayMethods();
				loadLocs();	
				loadStaffTypes();	
				rblPayMethods.BorderColor=System.Drawing.Color.Navy;
				rblPayMethods.ForeColor=System.Drawing.Color.Navy;
				lblContent1.Text=Session["btnAction"].ToString() + " Staff Action";
				lstStaffTypes.BorderColor=System.Drawing.Color.Navy;
				lstStaffTypes.ForeColor=System.Drawing.Color.Navy;
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);*/
				
				btnAction.Text= Session["btnAction"].ToString();
				if (Session["PeopleId"] != null)
				{
					txtName.Text=Session["PeopleName"].ToString();
				}
				else
				{
					peopleAdd();
				}
				if (Session["btnAction"].ToString() == "Update")
				{
					btnPeople.Visible=false;
					loadData();
				}
				else
				{
					//rblPayMethods.SelectedIndex=0;
					cbxStatus.Checked=false;
					//cbxStatusOrg.Checked=true;
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
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveClientAction";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["Id"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ClientAction");
			Session["PeopleId"]=ds.Tables["ClientAction"].Rows[0][0].ToString();
			txtName.Text=ds.Tables["ClientAction"].Rows[0][1].ToString();			
			if (ds.Tables["ClientAction"].Rows[0][6].ToString() == "2")
			{
				cbxStatus.Checked=false;
			}
			else
			{
				cbxStatus.Checked=true;
			}
		}
	/*	private void loadVisibility()
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
		private void loadStaffTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveStaffTypes";
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
			da.Fill(ds,"StaffTypes");
			lstStaffTypes.DataSource = ds;			
			lstStaffTypes.DataMember= "StaffTypes";
			lstStaffTypes.DataTextField = "Name";
			lstStaffTypes.DataValueField = "Id";
			lstStaffTypes.DataBind();
		}
		private void loadLocs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveLocations";
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
			da.Fill(ds,"Locations");
			lstLocations.DataSource = ds;			
			lstLocations.DataMember= "Locations";
			lstLocations.DataTextField = "Name";
			lstLocations.DataValueField = "Id";
			lstLocations.DataBind();
		}
		
		private void loadPayMethods()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrievePayMethods";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PayMethods");
			rblPayMethods.DataSource = ds;			
			rblPayMethods.DataMember= "PayMethods";
			rblPayMethods.DataTextField = "Name";
			rblPayMethods.DataValueField = "Id";
			rblPayMethods.DataBind();
		}*/

		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateClientAction";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["Id"].ToString();
				if (cbxStatus.Checked)
				{
					cmd.Parameters["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters["@Status"].Value=0;
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
				cmd.CommandText="fms_AddClientAction";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value= Session["PeopleId"].ToString();
				
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (cbxStatus.Checked)
				{
					cmd.Parameters["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters["@Status"].Value=0;
				}
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
			Session["PeopleId"]=null;
			Response.Redirect (strURL + Session["CCA"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		private void peopleAdd()
		{
			Session["CallerPeople"]="frmUpdClientAction";
			Response.Redirect (strURL + "frmPeople.aspx?");
		}
		protected void btnPeople_Click(object sender, System.EventArgs e)
		{
			peopleAdd();
		}
	}
}

	
