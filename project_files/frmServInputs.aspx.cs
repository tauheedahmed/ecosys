using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmDeadlines.
	/// </summary>
	public partial class ServInputs : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			LoadData();

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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Update);

		}
		#endregion
		private void LoadData()
		{
			Session["Caller3"]="frmServInputs";
			if (!IsPostBack) 
			{	
				lblOrg.Text=(Session["OrgName"]).ToString();
				lblPriorities.Text="Resources needed to produce the following output: " + Session["OutputName"].ToString();
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveServiceInputs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@ResourceId",SqlDbType.Int);
			cmd.Parameters["@ResourceId"].Value=Session["ResourceId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServInputs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void Update (object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.Text;
					cmd.Connection=this.epsDbConn;
					cmd.CommandText="Delete from ResourceInputs "
						+ "Where Id = " + e.Item.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					loadData();
			}
		}


		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmServices.aspx?");
		}

		protected void btnPublic_Click(object sender, System.EventArgs e)
		{
			Session["Avail"]="Public";
			Session["btnAddOwn"]="false";
			Response.Redirect (strURL + "frmServInputsAll.aspx?");
		}

		protected void btnInstitution_Click(object sender, System.EventArgs e)
		{
			Session["Avail"]="Institution";
			Session["btnAddOwn"]="false";
			Response.Redirect (strURL + "frmServInputsAll.aspx?");
		}

		protected void btnOwn_Click(object sender, System.EventArgs e)
		{
			Session["Avail"]="Owner";
			Session["btnAddOwn"]="false";
			Response.Redirect (strURL + "frmServInputsAll.aspx?");
		}
	}
}
