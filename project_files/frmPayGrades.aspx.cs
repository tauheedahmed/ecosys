using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmPayGrades : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblFunction.Text="Appointment Type: " + Session["OrgST"].ToString();
			if (!IsPostBack)
			{
				loadData();
			}
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
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="hrs_RetrieveOrgSTPayGrades";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgSTId",SqlDbType.Int);
			cmd.Parameters["@OrgSTId"].Value=Session["OrgSTId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"PGs");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignSeq();
		}
		private void assignSeq()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[1].FindControl("txtSeq"));
				if (i.Cells[4].Text == "&nbsp;")
				{
					tb.Text="99";
				}
				else tb.Text=i.Cells[4].Text;
			}
		}

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Done();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[1].FindControl("txtSeq"));
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdateOrgSTPayGradesSeq";
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
		private void Done()
		{
			Response.Redirect (strURL + Session["CPayGrades"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			updateGrid();
			if (e.CommandName == "Update")
			{
				Session["CUpdPayGrade"]="frmPayGrades";
				Response.Redirect (strURL + "frmUpdOSTPayGrade.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[2].Text
					+ "&Status=" + e.Item.Cells[5].Text);
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_DeleteOSTPayGrade";
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
			Session["CUpdPayGrade"]="frmPayGrades";
			Response.Redirect (strURL + "frmUpdOSTPayGrade.aspx?"
				+ "&btnAction=" + "Add");
		}
	}	

}
