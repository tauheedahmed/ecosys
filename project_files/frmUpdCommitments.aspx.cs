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
	public partial class frmUpdDeadlines : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string Id;
		private string ServiceId;
		private int GetImpact (string item)
		{
			if (btnAction.Text == "Update")
			{
				if (item.Trim() == "Client") 
				{
					return 0;
				}
				else if (item.Trim() == "Legal") 
				{
					return 1;
				}
				else if (item.Trim() == "Financial") 
				{
					return 2;
				}
				else return 3;
			}
			else return 0;
		}
		private int GetMag (string item)
		{
			if (btnAction.Text == "Update")
			{
				if (item.Trim() == "Major") 
				{
					return 0;
				}
				
				else return 1;
			}
			else return 0;
		}
		private int GetIndexLoc (string s)
		{
			return (lstLoc.Items.IndexOf (lstLoc.Items.FindByValue(s)));
		}
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			ServiceId=Request.Params["ServiceId"];
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblOutput.Text=Request.Params["OutputName"];

			if (!IsPostBack)
			{
				loadLoc();
				btnAction.Text= Request.Params["btnAction"];		
				lblAction.Text=btnAction.Text + " Service Commitments";
				txtClient.Text=Request.Params["Client"];				
				txtDeadline.Text=Request.Params["Deadline"];
				txtValue.Text=Request.Params["Value"];
				txtAccDelay.Text=Request.Params["AccDelay"];
				lstImpact.SelectedIndex=GetImpact (Request.Params["Impact"]);
				lstMagnitude.SelectedIndex=GetMag (Request.Params["Mag"]);
				lstLoc.SelectedIndex=GetIndexLoc (Request.Params["Loc"]);
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

		private void loadLoc() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Locations.Id, Locations.Name from Locations"
				+ " inner join Organizations on Locations.OrgId=Organizations.Id"
			+ " Where LicenseId =" +  Session["LicenseId"].ToString();
			//cmd.CommandText="eps_RetrieveLocs";
			//cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			//cmd.Parameters["@LicenseId"].Value=Int32.Parse(Id);
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Locations");
			lstLoc.DataSource = ds;			
			lstLoc.DataMember= "Locations";
			lstLoc.DataTextField = "Name";
			lstLoc.DataValueField = "Id";
			lstLoc.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateDeadline";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Client",SqlDbType.NVarChar);
				cmd.Parameters["@Client"].Value= txtClient.Text;
				cmd.Parameters.Add ("@Deadline",SqlDbType.NVarChar);
				cmd.Parameters["@Deadline"].Value= txtDeadline.Text;
				cmd.Parameters.Add ("@AccDelay",SqlDbType.NVarChar);
				cmd.Parameters["@AccDelay"].Value= txtAccDelay.Text;
				cmd.Parameters.Add ("@Value",SqlDbType.NVarChar);
				cmd.Parameters["@Value"].Value= txtValue.Text;
				cmd.Parameters.Add ("@Impact", SqlDbType.NVarChar);
				cmd.Parameters["@Impact"].Value=lstImpact.SelectedItem.Value;
				cmd.Parameters.Add ("@Mag", SqlDbType.NVarChar);
				cmd.Parameters["@Mag"].Value=lstMagnitude.SelectedItem.Value;
				cmd.Parameters.Add ("@Loc", SqlDbType.Int);
				cmd.Parameters["@Loc"].Value=lstLoc.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddDeadline";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ServiceId",SqlDbType.Int);
				cmd.Parameters["@ServiceId"].Value=ServiceId;
				cmd.Parameters.Add ("@Client",SqlDbType.NVarChar);
				cmd.Parameters["@Client"].Value= txtClient.Text;
				cmd.Parameters.Add ("@Deadline",SqlDbType.NVarChar);
				cmd.Parameters["@Deadline"].Value= txtDeadline.Text;
				cmd.Parameters.Add ("@AccDelay",SqlDbType.NVarChar);
				cmd.Parameters["@AccDelay"].Value= txtAccDelay.Text;
				cmd.Parameters.Add ("@Value",SqlDbType.NVarChar);
				cmd.Parameters["@Value"].Value= txtValue.Text;
				cmd.Parameters.Add ("@Impact", SqlDbType.NVarChar);
				cmd.Parameters["@Impact"].Value=lstImpact.SelectedItem.Value;
				cmd.Parameters.Add ("@Mag", SqlDbType.NVarChar);
				cmd.Parameters["@Mag"].Value=lstMagnitude.SelectedItem.Value;
				cmd.Parameters.Add ("@Loc", SqlDbType.Int);
				cmd.Parameters["@Loc"].Value=lstLoc.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				
				Done();
			}

		}
		private void Done()
		{
				Response.Redirect (strURL + "frmCommitments.aspx?"
				+ "&ServiceId=" + ServiceId
				+ "&OutputName=" + lblOutput.Text);

		} 
	}	

}
