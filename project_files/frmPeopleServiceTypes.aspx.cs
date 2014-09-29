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
	/// Summary description for frmAsses.
	/// </summary>
	public partial class frmAssesOrg : System.Web.UI.Page
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
			Load_Assess();
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
			//this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);

		}
		#endregion
		private void Load_Assess()
		{
			lblContent1.Text=Session["PeopleName"].ToString() + ": Services Profiled";
			if (!IsPostBack)
			{
				loadData();
			}	
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_RetrievePeopleServiceTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
				cmd.Parameters["@PeopleId"].Value=Int32.Parse(Session["PeopleId"].ToString());
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"Assess");
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
		}
/*			private void editCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
			{
				DataGrid1.EditItemIndex = e.Item.ItemIndex;
				DataGrid1.DataSource = (DataSet)Session["ds"];
				DataGrid1.DataBind();
			}
*/
        

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
		Response.Redirect (strURL + Session["CPST"].ToString() + ".aspx?");
		}

		protected void btnAddDel_Click(object sender, System.EventArgs e)
		{
            Session["CServiceTypes"] = "frmPeopleServiceTypes";
            Response.Redirect(strURL + "frmServiceTypes.aspx?");
		}

        protected void DataGrid1_ItemCommand1(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "wms_DeletePeopleServiceTypes";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                cmd.Parameters["@PeopleId"].Value = Int32.Parse(Session["PeopleId"].ToString());
                cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
                cmd.Parameters["@ServiceTypesId"].Value = Int32.Parse(e.Item.Cells[1].Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData();
            }
        }
}
}
