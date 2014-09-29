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
	public partial class frmProfileStepsAll: System.Web.UI.Page
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
			loadEvents();
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
		private void loadEvents()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContent1.Text=Session["ProfileName"].ToString();
				lblContent2.Text="Emergency Procedures";
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
				da.Fill(ds,"EventSteps");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
				//assignSequence();
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileSteps";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@ProfileId",SqlDbType.Int);
				cmd.Parameters["@ProfileId"].Value=Session["ProfileId"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				updateGrid();
				Exit();
		}
		private void updateGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[2].FindControl("cbxSel"));
					//TextBox tb = (TextBox) (i.Cells[5].FindControl("txtSeq"));
					//if (tb.Text != "")
					if (cb.Checked)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_UpdateProfileSteps";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add("@ProfileId", SqlDbType.Int);
						cmd.Parameters ["@ProfileId"].Value=Session["ProfileId"].ToString();
						cmd.Parameters.Add("@StepId", SqlDbType.Int);
						cmd.Parameters ["@StepId"].Value=i.Cells[0].Text;
						//cmd.Parameters.Add("@Seq", SqlDbType.Int);
						//cmd.Parameters ["@Seq"].Value=Int32.Parse(tb.Text);
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[3].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from ProfileSteps"
					+ " Where ProfileId = " + Session["ProfileId"].ToString()
					+ " and StepId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close();
			}
		}
		private void assignSequence()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Object tmp = new object();
				TextBox tb = (TextBox)(i.Cells[3].FindControl("txtSeq"));
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select Seq from ProfileSteps"
					+ " Where ProfileId = " + Session["ProfileId"].ToString()
					+ " and StepId = " + i.Cells[0].Text;
				cmd.Connection.Open();
				tmp = cmd.ExecuteScalar();
				if (tmp != null) tb.Text = tmp.ToString();
				if (tb.Text == "0") tb.Text = "";
				cmd.Connection.Close();
			}
		}


		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerStepsAll"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerStepsAll"].ToString() + ".aspx?");
		}
	}

}

