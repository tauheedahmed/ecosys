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
	public partial class TaskStepsNum : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadSerSteps();
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
		private void loadSerSteps()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text="Task: " + Session["TaskName"].ToString();
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveTaskSteps";
			cmd.Connection=this.epsDbConn;
			/*if (Session["CallerServiceSteps"].ToString() == "frmServices")
			{
				cmd.Parameters.Add ("@ServiceId",SqlDbType.Int);
				cmd.Parameters["@ServiceId"].Value=Session["ResourceId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="Service";

			}
			else if (Session["CallerServiceSteps"].ToString() == "frmActivations")
			{*/
				cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
				cmd.Parameters["@TaskId"].Value=Session["TaskId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="Activation";
			//}
			/*cmd.Parameters.Add ("@StepType",SqlDbType.NVarChar);
			cmd.Parameters["@StepType"].Value=Session["StepType"].ToString();*/
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"TaskSteps");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			//refreshGrid();
			assignSequence();
		}
		private void assignSequence()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Object tmp = new object();
				TextBox tb = (TextBox)(i.Cells[1].FindControl("txtSeq"));
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.Text;
				/*if (Session["CallerTaskSteps"].ToString() == "frmActivations")
				{*/
					cmd.CommandText = "Select Seq from TaskSteps"
						+ " Where TaskSteps.Id =" + i.Cells[0].Text;
				/*}
				else
				{
					cmd.CommandText = "Select Seq from ServiceSteps"
						+ " Where ServiceSteps.Id =" + i.Cells[0].Text;
				}*/
				cmd.Connection.Open();
				tmp = cmd.ExecuteScalar();
				if (tmp != null) tb.Text = tmp.ToString();
				if (tb.Text == "0") tb.Text = "";
				cmd.Connection.Close();
			}
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					Object tmp = new object();
					TextBox tb = (TextBox)(i.Cells[1].FindControl("txtSeq"));
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = this.epsDbConn;
					cmd.CommandType = CommandType.Text;
					/*if (Session["CallerServiceSteps"].ToString() == "frmActivations")
					{*/
						cmd.CommandText = "Update TaskSteps"
							+ " Set Seq=" + Int32.Parse(tb.Text)
							+ " Where TaskSteps.Id =" + Int32.Parse(i.Cells[0].Text);
					/*}
					else
					{
						cmd.CommandText = "Update ServiceSteps"
							+ " Set Seq=" + Int32.Parse(tb.Text)
							+ " Where ServiceSteps.Id =" + Int32.Parse(i.Cells[0].Text);
					}*/

					cmd.Connection.Open();
					tmp = cmd.ExecuteScalar();
					if (tmp != null) tb.Text = tmp.ToString();
					if (tb.Text == "0") tb.Text = "";
					cmd.Connection.Close();
				}
			Done();		
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerTSNum"].ToString() + ".aspx?");
		}

		protected void btnReseq_Click(object sender, System.EventArgs e)
		{
		Done();		
		}
	}
}
