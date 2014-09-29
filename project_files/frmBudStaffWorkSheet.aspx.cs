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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmBudStaffWorkSheet : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label Label2;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Procedures();
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
		private void Load_Procedures()
		{	
			//DataGrid1.Columns[6].HeaderText="Budgeted Amount in " + Session["Curr"].ToString();
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["MgrName"].ToString();
				lblLoc.Text="Location: " + Session["LocationName"].ToString();
				lblBd.Text="Budget: " + Session["BudName"].ToString() +" - "
					+ Session["CurrName"].ToString();
				lblService.Text="Service: " + Session["ServiceName"].ToString();
				lblContents.Text="Please enter amounts in the column titled 'Request Override'"
					+ " only if you wish to provide an amount that is different"
					+ " from the amount indicated in the column titled 'Budget Requested'.";
				if (Session["PRS"].ToString() == "1")
				{
					lblDel.Text="Deliverable: " + Session["EventName"].ToString();
					lblTask.Text=Session["PJNameS"].ToString() + ": "
						+ Session["ProjName"].ToString()
						+ " (Task: " + Session["ProcName"].ToString() + ")";
				}
				else
				{
					lblDel.Text="Task: " + Session["ProcName"].ToString();
					
				}
				loadData();
			}
		}
		private void loadData ()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveBudStaffWS";
				cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
				cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
				//cmd.Parameters.Add("@PSEPSID",SqlDbType.Int);
				//cmd.Parameters["@PSEPSID"].Value=Session["PSEPSID"].ToString();
				cmd.Parameters.Add("@PSEPId",SqlDbType.Int);
				cmd.Parameters["@PSEPId"].Value=Session["PSEPId"].ToString();
				if (Session["PRS"].ToString() == "1")
				{
					cmd.Parameters.Add("@ProjectId",SqlDbType.Int);
					cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
				}
				if (Session["BRS"].ToString() == "1")
				{
					cmd.Parameters.Add("@BudgetsId",SqlDbType.Int);
					cmd.Parameters["@BudgetsId"].Value=Session["BudgetsId"].ToString();			
				}

				cmd.Connection=this.epsDbConn;
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"ProcS");
				if (ds.Tables["ProcS"].Rows.Count == 0)
				{
					DataGrid1.Visible=false;
					lblContents.Text="Note:  There is no budget requested.";
				}
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				/*decimal x = 
					decimal.Parse(i.Cells[3].Text) 
					* decimal.Parse(i.Cells[8].Text) 
					* decimal.Parse(i.Cells[9].Text);
				decimal y = decimal.Round(x/((decimal.Parse(i.Cells[10].Text) * (decimal.Parse(i.Cells[12].Text)))),2);
				i.Cells[6].Text = y.ToString();*/
				TextBox tb = (TextBox)(i.Cells[5].FindControl("txtBud"));

				if (i.Cells[4].Text.StartsWith("&") == false)
				{
					tb.Text=i.Cells[4].Text;
				}
				//i.Cells[4].Text = i.Cells[3].Text + " " + i.Cells[5].Text;
			}
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox)(i.Cells[5].FindControl("txtBud"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateProcProcuresWS";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add("@BudAmount", SqlDbType.Decimal);
				if (tb.Text != "")
				{
					cmd.Parameters ["@BudAmount"].Value=decimal.Parse(tb.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
				}
				cmd.Parameters.Add("@Id", SqlDbType.Int);
				cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text); 
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CBudSerWS"].ToString() + ".aspx?");
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}

	}

}
	