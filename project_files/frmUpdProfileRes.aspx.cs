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
	public partial class frmUpdProfileRes : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected System.Web.UI.WebControls.TextBox txtGlAv;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtInAv;
		private String Id;
		private int GetIndexLoc (string s)
		{
			return (lstLoc.Items.IndexOf (lstLoc.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			lblOrg.Text=Session["OrgName"].ToString();
			Id=Request.Params["Id"];
				
			if (!IsPostBack)
			{
				loadlstLoc();
				btnAction.Text= Request.Params["btnAction"];
				lblHead2.Text=Request.Params["ResourceName"];
				lblMeasure.Text=Request.Params["Measure"];				
				txtQtyNeeded.Text=Request.Params["QtyNeeded"];
				lstLoc.SelectedIndex= GetIndexLoc (Request.Params["LocId"]);
				lstLoc.BorderColor=System.Drawing.Color.Navy;		
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
		
		private void loadlstLoc()
		{
		SqlCommand cmd=new SqlCommand();
		cmd.Connection=this.epsDbConn;
		cmd.CommandType=CommandType.Text;
		cmd.CommandText="Select Locations.Name, Locations.Id from Locations"
			+ " inner join Organizations"
			+ " on Locations.OrgId=Organizations.Id"
			+ " Where Organizations.LicenseId=" + Session["LicenseId"].ToString()
			+ " Order by Locations.Name";
		DataSet ds=new DataSet();
		SqlDataAdapter da=new SqlDataAdapter (cmd);
		da.Fill(ds,"Locations");
		lstLoc.DataSource=ds;
			lstLoc.DataMember="Locations";
			lstLoc.DataTextField="Name";
			lstLoc.DataValueField="Id";
			lstLoc.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateProfileResSingle";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse(Id);
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=lstLoc.SelectedItem.Value;
			cmd.Parameters.Add ("@Qty",SqlDbType.Decimal);
			cmd.Parameters["@Qty"].Value=txtQtyNeeded.Text;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			Done();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["Caller3"].ToString() + ".aspx?");
		}




	}
}
