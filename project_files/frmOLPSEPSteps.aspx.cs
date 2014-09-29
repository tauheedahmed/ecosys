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
	public partial class frmOLPSEPSteps : System.Web.UI.Page
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
			lblContents1.Text="For each step in the list below, click on the "
				+ " pushbuttons titled 'Staff', 'Services' and'Physical Resources'"
				+ " to identify the types of inputs required to carry out this step,"
				+ " and from there to recruit and/or assign existing staff"
				+ " and to procure services and/or assign existing non-staff resources.";/*"Complete the list below to identify the key steps"
				+ " that are taken for this profile '" + Session["ProfilesName"].ToString()
				+ "' in response to the event '" + Session["EventsName"].ToString()
				+ "' to deliver the service '" + Session["ServiceTypesName"].ToString() + "'."  
				+ " Be sure to review and correct the Step Numbers to the left, since this is the"
				+ " order in which the system will display these steps later on.";*/
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProfileSEPSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProfileSEProcsId",SqlDbType.Int);
			cmd.Parameters["@ProfileSEProcsId"].Value=Session["ProfileSEProcsId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"StepsAdm");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignSeq();
		}
		protected void btnBack_Click(object sender, System.EventArgs e)
		{
			//updateGrid();
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["COLSEPSteps"].ToString() + ".aspx?");
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
			if (e.CommandName == "Staff")
			{		
				Session["ProfileSEPStepTypesId"]=e.Item.Cells[0].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[3].Text;
				Session["COLPSStaff"]="frmOLPSEPSteps";
				Session["StaffingType"]="Staff";
				Response.Redirect (strURL + "frmOLPSEPSStaff.aspx?");
				
			}
			else if (e.CommandName == "Resources")
			{
				Session["PSEPSID"]=e.Item.Cells[0].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[3].Text;
				Session["CSEPResTypes"]="frmOLPSEPSteps";
				Response.Redirect (strURL + "frmOLPSEPSRes.aspx?");
			}
			else if (e.CommandName == "Services")
			{			
				Session["PSEPSID"]=e.Item.Cells[0].Text;
				Session["ProfileSEPSName"]=e.Item.Cells[3].Text;
				Session["CSEPServices"]="frmOLPSEPSteps";
				Response.Redirect (strURL + "frmOLPSEPSSer.aspx?");				
			}

			/*else if (e.CommandName == "Remove")
			{
				updateGrid();
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteProfileSEPStepTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}*/
		}

		protected void btnSignoff_Click(object sender, System.EventArgs e)
		{
			//updateGrid();
			Response.Redirect (strURL + "frmEnd.aspx?");
		}
	}

}
	