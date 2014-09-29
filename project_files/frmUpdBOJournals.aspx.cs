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
	public partial class frmUpdBOJournals : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		
		/*private int GetIndexOfOrgs (string s)
		{
			return (lstOrgs.Items.IndexOf (lstOrgs.Items.FindByValue(s)));
		}*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				lblOrg.Text="Transfer To: " + Session["OrgName"].ToString();
				txtDesc.Text=Request.Params["Desc"].ToString();
				lblDate.Text=Request.Params["UDate"].ToString();
				lblBudget.Text=Session["BudName"].ToString();
				lblContents.Text="Listed below are the changes"
					+ " to budget distribtuion made as a result of this update."
					+ " Type over 'Description' to changed the description. "
					+ " You cannot use this form to change the budget distribtuion itself."
					+ " To do that, you should use the previous budget distribution form."
					+ " Note:  This restriction is necessary in order to maintain the integrity of the audit trail.";
				lblBud.Text="Current Budget: " + Session["CurrBAmt"].ToString();
				lblReq.Text="Budget Requested: " + Session["ReqBAmt"].ToString();
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
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveBOJournal";		
			cmd.Parameters.Add ("@BOJournalsId",SqlDbType.Int);
			cmd.Parameters["@BOJournalsId"].Value=Int32.Parse(Request.Params["BOJournalsId"].ToString());			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BOJ");
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();			
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			{
					try
					{
						SqlCommand cmd = new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="fms_UpdateBOJournal";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@BOJournalsId",SqlDbType.Int);
						cmd.Parameters["@BOJournalsId"].Value=Int32.Parse(Request.Params["BOJournalsId"].ToString());			
						cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
						cmd.Parameters["@Desc"].Value=txtDesc.Text;
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
						Done();
					}
					catch 
					{
					}
				}
		}
		private void Done()
		{
			
			Response.Redirect (strURL + Session["CUBOR"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}	
}
