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
	public partial class frmOrgVis : System.Web.UI.Page
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			lblContents1.Text="Listed below are the Visibility Levels for various entities.";
			lblContents2.Text="Each process has certain basic characteristics, including the level of detail"
				+ " at which it is budgeted and progress monitored, service standards, and so on.  Click on the"
				+ " button titled 'Update' to maintain these characteristics for that process.";
			lblContents3.Text="A given process is delivered in a series of steps."
					+ " Click on the button titled 'Timetables' to identify and provide details about"
					+ " steps for each process." 
					;
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProfileSEProcs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProfileSEventsId",SqlDbType.Int);
			cmd.Parameters["@ProfileSEventsId"].Value=Session["ProfileSEventsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSEProcs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{
			updateGrid();
			Response.Redirect (strURL + Session["CPSEProcs"].ToString() + ".aspx?");
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtSeq"));
				Button btSt = (Button) (i.Cells[4].FindControl("btnStaff"));
				Button btSe = (Button) (i.Cells[4].FindControl("btnServices"));
				Button btRe = (Button) (i.Cells[4].FindControl("btnOther"));
				//Button btTimetables = (Button) (i.Cells[4].FindControl("btnTimetables"));
				if (i.Cells[1].Text == "&nbsp;")
				{
					tb.Text="99";
				}
				else tb.Text=i.Cells[1].Text;
				/*if (i.Cells[6].Text == "1")
				{
				}
				else
				{
					btTimetables.Enabled = false;
					btTimetables.BackColor=Color.Transparent;
					btTimetables.Text="";
				}*/
			}
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtSeq"));
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="wms_UpdateProfileSEProcsSeqNo";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text;
					cmd.Parameters.Add("@Seq", SqlDbType.Int);
					cmd.Parameters ["@Seq"].Value=Int32.Parse(tb.Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			updateGrid();
			
			if (e.CommandName == "Update")
			{
				Session["CUPSEP"]="frmProfileSEProcs";
				Session["btnAction"]="Update";
				Session["ProcessName"]=e.Item.Cells[3].Text;
				Session["Id"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProfileSEProcs.aspx?");
	
			}
			else if (e.CommandName == "Staff")
			{
				Session["CPSEPStaff"]="frmProfileSEProcs";
				Session["ProcessName"]=e.Item.Cells[3].Text;
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmPSEPStaff.aspx?");
	
			}
			else if (e.CommandName == "Clients")
			{
				Session["CPSEPC"]="frmProfileSEProcs";
				Session["ProcessName"]=e.Item.Cells[3].Text;
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmPSEPClient.aspx?");
	
			}
			else if (e.CommandName == "Services")
			{
				Session["CPSEPSer"]="frmProfileSEProcs";
				Session["ProcessName"]=e.Item.Cells[3].Text;
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmPSEPSer.aspx?");
	
			}
			else if (e.CommandName == "Other")
			{
				Session["CPSEPRes"]="frmProfileSEProcs";
				Session["ProcessName"]=e.Item.Cells[3].Text;
				Session["PSEPID"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmPSEPRes.aspx?");
	
			}
			else if (e.CommandName == "Steps")
			{
				Session["ProfileSEProcsId"]=e.Item.Cells[0].Text;
				Session["ProfileSEProcsName"]=e.Item.Cells[3].Text;
				Session["CPSEPSteps"]="frmProfileSEProcs";
				Response.Redirect (strURL + "frmPSEPSteps.aspx?");
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteProfileSEProcs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		
	}

}
	