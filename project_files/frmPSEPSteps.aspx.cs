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
	public partial class frmPSEPSteps : System.Web.UI.Page
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
			lblContents1.Text="Complete the list below to identify the key steps"
				+ " that are taken for process " 
				+ Session["ProcessName"].ToString()
				+ ".";
			lblContents2.Text="";
			if (!IsPostBack) 
			{	
				DataGrid1.Columns[4].Visible=false;
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrievePSEPSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProcsId",SqlDbType.Int);
			cmd.Parameters["@ProcsId"].Value=Session["ProcsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StepsAdm");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignSeq();
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["CUpdStep"] = "frmPSEPSteps";	
			Response.Redirect (strURL + "frmUpdStep.aspx?"
				+ "&btnAction=" + "Add");
				/*Session["CStepTypes"]="frmPSEPSteps";
				Response.Redirect (strURL + "frmStepTypes.aspx?");*/
		}
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSEPSteps"].ToString() + ".aspx?");
		}
		private void assignSeq()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtSeq"));
				if (i.Cells[1].Text == "&nbsp;")
				{
					tb.Text="99";
				}
				else tb.Text=i.Cells[1].Text;
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
					cmd.CommandText="wms_UpdateProfileSEPStepNo";
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
				Session["CUpdStep"] = "frmPSEPSteps";
				Response.Redirect (strURL + "frmUpdStep.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[3].Text
					+ "&Desc=" + e.Item.Cells[4].Text);
			}
			else if (e.CommandName == "Delete")
			{
				updateGrid();
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteStep";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
			/*if (e.CommandName == "Staff")
			{		
				updateGrid();
				Session["ProfileSEPStepTypesId"]=e.Item.Cells[0].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[3].Text;
				Session["CSEPSStaff"]="frmPSEPSteps";
				Session["StaffingType"]="Staff";
				Response.Redirect (strURL + "frmProfileSEPSStaff.aspx?");
				
			}
			else if (e.CommandName == "Resources")
			{
				updateGrid();
				Session["ProfileSEPStepTypesId"]=e.Item.Cells[0].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[3].Text;
				Session["CSEPResTypes"]="frmPSEPSteps";
				Response.Redirect (strURL + "frmProfileSEPSRes.aspx?");
			}
			else if (e.CommandName == "Services")
			{			
				updateGrid();
				Session["ProfileSEPStepTypesId"]=e.Item.Cells[0].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[3].Text;
				Session["CSEPServices"]="frmPSEPSteps";
				Response.Redirect (strURL + "frmProfileSEPSSer.aspx?");				
			}*/
		}

		protected void btnSignoff_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Response.Redirect (strURL + "frmEnd.aspx?");
		}
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Exit();
        }
}

}
	