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
	/// Summary description for frmCommitments
	/// </summary>
	public partial class frmServInputs : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private string ServiceId;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Commitments();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Update);

		}
		#endregion
		private void Load_Commitments()
		{
			ServiceId=Request.Params["ServiceId"];
			if (!IsPostBack) 
			{	
				lblOrg.Text=(Session["OrgName"]).ToString();
				lblOutputName.Text="Service:  " + Request.Params["OutputName"];
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveCommitments";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@ServiceId",SqlDbType.Int);
			cmd.Parameters["@ServiceId"].Value=ServiceId;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Deadline");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
		}
		private void Update (object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Response.Redirect (strURL + "frmUpdCommitments.aspx?"
					+ "&btnAction=" + "Update"
					+ "&ServiceId=" + ServiceId
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Client=" + e.Item.Cells[1].Text
					+ "&Deadline=" + e.Item.Cells[2].Text
					+ "&AccDelay=" + e.Item.Cells[3].Text
					+ "&Value=" + e.Item.Cells[6].Text
					+ "&OutputName=" + lblOutputName.Text
					+ "&Impact=" + e.Item.Cells[4].Text
					+ "&Mag=" + e.Item.Cells[5].Text
					+ "&Loc=" + e.Item.Cells[7].Text);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteDeadline";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmUpdCommitments.aspx?"
				+ "&btnAction=" + "Add"
				+ "&ServiceId=" + ServiceId
				+ "&OutputName=" + lblOutputName.Text);
		
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["frmCCommitments"].ToString() + ".aspx?");
		}
	}
}
