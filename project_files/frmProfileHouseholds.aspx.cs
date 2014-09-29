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
	public class frmEventsSteps : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Label lblOrg;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnExit;
		protected System.Web.UI.WebControls.Label lblContents;
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Session["Caller2"]="frmEvents";
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
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.deleteRow);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Load_Procedures()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents.Text="Hazardous Events and Key Control Steps for " + lblOrg.Text;
			if (!IsPostBack) 
			{	
				loadData();
			}
		}

		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveEvents";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"EventsAdm");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}

		private void deleteRow(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/*Add Try/Catch on:
			 * DELETE statement conflicted with COLUMN REFERENCE constraint 'FK_EventOrgs_Events'. 
			 * The conflict occurred in database 'EPS1', table 'EventOrgs', column 'EventId'.
			 * */
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteEventId";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Response.Redirect (strURL + "frmUpdEvent.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Type=" + e.Item.Cells[3].Text);
			}
			else if (e.CommandName == "Steps")
			{
				Session["EventId"]=e.Item.Cells[0].Text;
				Session["EventName"]=e.Item.Cells[1].Text;
				Response.Redirect (strURL + "frmEventSteps.aspx?"
					+ "&EventId = " + e.Item.Cells[0].Text);
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
				Response.Redirect (strURL + "frmUpdEvent.aspx?"
				+ "&btnAction=" + "Add");
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Session["Caller98"]="frmEvents";
			Response.Redirect (strURL + Session["Caller1"].ToString() + ".aspx?");
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}

}
	