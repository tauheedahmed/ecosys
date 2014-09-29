using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for ServiceStepsNum.
	/// </summary>
	public partial class TaskStepsAdd : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadTaskSteps();
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
		private void loadTaskSteps()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text=Session["ServiceName"].ToString();
				lblContent2.Text=Session["TaskName"].ToString();
				lblContent3.Text="Enter a sequence number in first column"
					+ " for each step that you wish to add.";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveStepsAll";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ServSteps");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();//lblOrg.Text="hello";
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{	
			foreach (DataGridItem i in DataGrid1.Items)
				{
				TextBox tb = (TextBox)(i.Cells[1].FindControl("txtSeq"));
				if (tb.Text != "")
					{
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = this.epsDbConn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "Insert into TaskSteps (Seq, TaskId, StepId)"
							+ " Values(" + "'" + tb.Text + "',"
							+ "'" + Session["TaskId"].ToString() + "'," 
							+ "'" + (i.Cells[0].Text) + "')";
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					}
				//lblOrg.Text="Res: " + Session["ResourceId"].ToString() + " Step: " + Session["StepType"].ToString();
				}
			Done();		
		}
		private void Done()
		{
			Response.Redirect (strURL + "frmTaskSteps.aspx?");
		}

		protected void btnReseq_Click(object sender, System.EventArgs e)
		{
			Done();
		}
	}
}
