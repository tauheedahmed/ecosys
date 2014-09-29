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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmResources : System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Resources();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Remove);

		}
		#endregion
		private void Load_Resources()
		{			
			if (!IsPostBack)
			{	
				Session["Caller2"]="frmResources";
				lblOrg.Text=Session["OrgName"].ToString();
				if (Session["CallerResources"].ToString() =="frmLocs")
				{
					lblContents.Text="Location: " + Session["LocationName"].ToString();
				}
				else
				{
					lblContents.Text=Session["ParentTypeName"].ToString() + " Needed";
					txtHeading.Text="        Available " + Session["ParentTypeName"].ToString();
				}
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveResOrg";
			cmd.Connection=this.epsDbConn;
			//cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			//cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			//cmd.Parameters.Add ("@ParentType",SqlDbType.Int);//Parent Resource Type
			//cmd.Parameters["@ParentType"].Value=Session["ParentType"].ToString();
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);//Parent Resource Type
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Resources");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerResources"].ToString() + ".aspx?");
		}

		protected void btnPublic_Click(object sender, System.EventArgs e)
		{
			Session["Avail"]="Public";
			Session["btnAddOwn"]="false";
			Response.Redirect (strURL + "frmResourcesAll.aspx?"
				+ "&Type=" + Session["ParentType"].ToString()
				);
		}

		protected void btnOwn_Click(object sender, System.EventArgs e)
		{
			Session["btnAddOwn"]="true";
			Session["Avail"]="Owner";
			Response.Redirect (strURL + "frmResourcesAll.aspx?"
				+ "&Type=" + Session["ParentType"].ToString()
				);
		}

		private void Remove(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.Text;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="Delete from ResourceOrg "
				+ "Where ResourceId = " + e.Item.Cells[0].Text
				+ " and OrgId = " + Session["OrgId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}

		protected void btnInstitution_Click(object sender, System.EventArgs e)
		{
			Session["Avail"]="Institution";
			Session["btnAddOwn"]="false";
			Response.Redirect (strURL + "frmResourcesAll.aspx?"
				+ "&Type=" + Session["ParentType"].ToString()
				);
		
		}


	}

}

