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
	public partial class frmBudStaffWSTS : System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			DataGrid1.Columns[6].HeaderText="Budgeted Amount in " + Session["Curr"].ToString();
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
			lblLocation.Text="Location: " + Session["LocationName"].ToString();
				lblContents.Text="Services Budget: " 
					+ Session["SerName"].ToString();
				lblComment.Text= "";
				lblBudName.Text=Session["BOrgName"].ToString()
					+ ": " + Session["BudName"].ToString()
					+ " (Budget Currency: " + Session["Curr"].ToString() +  ")";
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveBudStaffWS";
			cmd.Parameters.Add("@SerId",SqlDbType.Int);
			cmd.Parameters["@SerId"].Value=Session["SerId"].ToString();
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add("@Price",SqlDbType.Decimal);
			cmd.Parameters["@Price"].Value=decimal.Parse(Session["Price"].ToString(), System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
			cmd.Parameters.Add("@BOId",SqlDbType.Int);
			cmd.Parameters["@BOId"].Value=Session["BOId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procurements");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			//decimal x, y;
			foreach (DataGridItem i in DataGrid1.Items)
			{
				/*x=0;
				y=0;
				if ((i.Cells[3].Text.StartsWith("&") != true) & (i.Cells[5].Text.StartsWith("&") != true))
					{
						x = decimal.Parse(i.Cells[3].Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
						y = decimal.Parse(Session["Price"].ToString(), System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
						
					//x= Int32.Parse(i.Cells[3].Text) * decSession["Price"].ToString();
						i.Cells[6].Text=x.ToString();
					}*/
				TextBox tb = (TextBox)(i.Cells[6].FindControl("txtBud"));

				if (i.Cells[7].Text.StartsWith("&") == false)
				{
					tb.Text=i.Cells[7].Text;
				}					
			}
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox)(i.Cells[6].FindControl("txtBud"));
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


		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
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
	}

}
	