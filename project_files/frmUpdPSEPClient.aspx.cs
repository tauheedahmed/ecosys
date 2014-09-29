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
	public partial class frmUpdPSEPClient : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		
		private int GetIndexOfDeadlines (string s)
		{
			return (lstTypesOfDeadlines.Items.IndexOf (lstTypesOfDeadlines.Items.FindByValue(s)));
		}

		private int GetIndexOfImpact (string s)
		{
			return (lstTypesOfImpact.Items.IndexOf (lstTypesOfImpact.Items.FindByValue(s)));
		}
		private int GetIndexOfImpactMagnitude (string s)
		{
			return (lstTypesOfImpactMagnitude.Items.IndexOf (lstTypesOfImpactMagnitude.Items.FindByValue(s)));
		}
		/*private int GetIndexOfTypes (int s)
		{
			if (s == 0) return 0; else return 1;
		}*/

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
                lblProfilesName.Text = "Business Profile for: " + Session["ProfilesName"].ToString();
                lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                lblDeliverableName.Text = "Deliverable: " + Session["EventsName"].ToString();
                lblClientName.Text = "Type of Client: " + Session["ClientName"].ToString();
					
			lblAction.Text="You may now update service standards for the above deliverable";
			loadTypesOfDeadlines();
			loadTypesOfImpact();
			loadTypesOfImpactMagnitude();
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
            cmd.CommandText = "wms_RetrievePSEClientsUpd";
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["Id"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Upd");

			lstTypesOfDeadlines.SelectedIndex=GetIndexOfDeadlines (ds.Tables["Upd"].Rows[0][1].ToString());
			txtAcceptableSlip.Text=ds.Tables["Upd"].Rows[0][2].ToString();
			lstTypesOfImpact.SelectedIndex=GetIndexOfImpact (ds.Tables["Upd"].Rows[0][3].ToString());
			lstTypesOfImpactMagnitude.SelectedIndex=GetIndexOfImpactMagnitude (ds.Tables["Upd"].Rows[0][4].ToString());
			txtDollarCostSlip.Text=ds.Tables["Upd"].Rows[0][5].ToString();
			if (ds.Tables["Upd"].Rows[0][0].ToString() == "0")
			{
				btnClientType.SelectedIndex=0;
			}
			else
			{
				btnClientType.SelectedIndex=1;
			}
			//btnClientType.SelectedIndex=Int32.Parse(ds.Tables["Upd"].Rows[0][0].ToString());*/
		}
		private void loadTypesOfImpactMagnitude()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTypesOfImpactMagnitude";
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
			da.Fill(ds,"TypesOfImpactMagnitude");
			lstTypesOfImpactMagnitude.DataSource = ds;			
			lstTypesOfImpactMagnitude.DataMember= "TypesOfImpactMagnitude";
			lstTypesOfImpactMagnitude.DataTextField = "Name";
			lstTypesOfImpactMagnitude.DataValueField = "Id";
			lstTypesOfImpactMagnitude.DataBind();
		}
		private void loadTypesOfImpact()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTypesOfImpact";
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
			da.Fill(ds,"TypesOfImpact");
			lstTypesOfImpact.DataSource = ds;			
			lstTypesOfImpact.DataMember= "TypesOfImpact";
			lstTypesOfImpact.DataTextField = "Name";
			lstTypesOfImpact.DataValueField = "Id";
			lstTypesOfImpact.DataBind();
		}
		private void loadTypesOfDeadlines()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveTypesOfDeadlines";
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
			da.Fill(ds,"TypesOfDeadlines");
			lstTypesOfDeadlines.DataSource = ds;			
			lstTypesOfDeadlines.DataMember= "TypesOfDeadlines";
			lstTypesOfDeadlines.DataTextField = "Name";
			lstTypesOfDeadlines.DataValueField = "Id";
			lstTypesOfDeadlines.DataBind();
		}
			

		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                cmd.CommandText = "wms_UpdatePSEClientStds";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value= Session["Id"].ToString();
				cmd.Parameters.Add ("@TypesOfDeadlinesId",SqlDbType.Int);
				cmd.Parameters["@TypesOfDeadlinesId"].Value= lstTypesOfDeadlines.SelectedItem.Value;
				cmd.Parameters.Add ("@AcceptableSlip",SqlDbType.VarChar);
				cmd.Parameters["@AcceptableSlip"].Value= txtAcceptableSlip.Text;
				cmd.Parameters.Add ("@TypesOfImpactId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactId"].Value= lstTypesOfImpact.SelectedItem.Value;
				cmd.Parameters.Add ("@TypesOfImpactMagnitudeId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactMagnitudeId"].Value= lstTypesOfImpactMagnitude.SelectedItem.Value;
				cmd.Parameters.Add ("@DollarCostSlip",SqlDbType.Int);
				if (txtDollarCostSlip.Text == "")
				{
					cmd.Parameters["@DollarCostSlip"].Value= 0;
				}
				else
				{
					cmd.Parameters["@DollarCostSlip"].Value= Int32.Parse(txtDollarCostSlip.Text);
				}
				cmd.Parameters.Add ("@Type",SqlDbType.Int);
				cmd.Parameters["@Type"].Value= btnClientType.SelectedIndex;
				
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			/*else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_AddProfileSEProcs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ProfileSEventsId",SqlDbType.Int);
				cmd.Parameters["@ProfileSEventsId"].Value= Session["ProfileSEventsId"].ToString();
				cmd.Parameters.Add ("@TypesOfDeadlinesId",SqlDbType.Int);
				cmd.Parameters["@TypesOfDeadlinesId"].Value= lstTypesOfDeadlines.SelectedItem.Value;
				cmd.Parameters.Add ("@AcceptableSlip",SqlDbType.NVarChar);
				cmd.Parameters["@AcceptableSlip"].Value= txtAcceptableSlip.Text;
				cmd.Parameters.Add ("@TypesOfImpactId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactId"].Value= lstTypesOfImpact.SelectedItem.Value;
				cmd.Parameters.Add ("@TypesOfImpactMagnitudeId",SqlDbType.Int);
				cmd.Parameters["@TypesOfImpactMagnitudeId"].Value= lstTypesOfImpactMagnitude.SelectedItem.Value;
				cmd.Parameters.Add ("@DollarCostSlip",SqlDbType.Int);
				if (txtDollarCostSlip.Text == "")
				{
					cmd.Parameters["@DollarCostSlip"].Value= 0;
				}
				else
				{
					cmd.Parameters["@DollarCostSlip"].Value= Int32.Parse(txtDollarCostSlip.Text);
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}*/
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdPSEPC"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void txtAcceptableSlip_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}	
}
