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
using CrystalDecisions.Shared;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmOrgResTypes1.
	/// </summary>
	public partial class frmContacts : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			loadForm();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				lblContents.Text="Emergency Contacts";
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveContacts";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Contacts");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (ds.Tables["Contacts"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				lblContents.Text = "You have no contacts identified at present."
					+ " Please click on 'Add' to start adding contacts.";				
			}
			else 
			{
				assignValues();
			}
		}
		private void itemCommand (object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{				
				TextBox tbName = (TextBox)(e.Item.Cells[1].FindControl("txtName"));
				TextBox tbPhone = (TextBox)(e.Item.Cells[2].FindControl("txtPhone"));
				TextBox tbCell = (TextBox)(e.Item.Cells[3].FindControl("txtCell"));
			if (e.CommandName == "Details")
			{
				Response.Redirect(strURL + "frmUpdContact.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[0].Text
					+ "&Name=" + tbName.Text
					+ "&RegularPhone=" + tbPhone.Text
					+ "&CellPhone=" + tbCell.Text
					+ "&Email=" + e.Item.Cells[9].Text
					+ "&Address=" + e.Item.Cells[8].Text
					);
			}
			else if (e.CommandName == "Delete")
			{
				//lblOrg.Text="e11" + e.Item.Cells[11].Text;
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_DeleteContact";
				cmd.Connection=this.epsDbConn;
				/*if (e.Item.Cells[0].Text != "0")*/
				//{
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=e.Item.Cells[0].Text;
				//}
				/*cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
				cmd.Parameters ["@Type"].Value=e.Item.Cells[11].Text;
				cmd.Parameters.Add("@ProfileId", SqlDbType.Int);
				cmd.Parameters ["@ProfileId"].Value=e.Item.Cells[10].Text;
				cmd.Parameters.Add("@OrgId", SqlDbType.Int);
				cmd.Parameters ["@OrgId"].Value=Session["OrgId"].ToString();*/
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		private void assignValues()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				//Object tmp = new object();
				TextBox tbName = (TextBox)(i.Cells[1].FindControl("txtName"));
				TextBox tbPhone = (TextBox)(i.Cells[2].FindControl("txtPhone"));
				TextBox tbCell = (TextBox)(i.Cells[3].FindControl("txtCell"));
				tbName.Text = i.Cells[5].Text;
				tbPhone.Text = i.Cells[6].Text;
				tbCell.Text = i.Cells[7].Text;
				if (tbPhone.Text == "&nbsp;") tbPhone.Text="";
				if (tbCell.Text == "&nbsp;") tbCell.Text="";
				/*if (i.Cells[11].Text == "Profile")
				{
					Button bt= (Button) (i.Cells[4].FindControl("btnDelete"));
					bt.Visible=false;
				}*/
				
				/*SqlCommand cmd = new SqlCommand();
				cmd.Connection = this.epsDbConn;
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "Select Flag from Contacts"
					+ " Where OrgId = " + Session["OrgId"].ToString();
				cmd.Connection.Open();*/
				//tmp = cmd.ExecuteScalar();
				
				
				//if (tmp != null) tb.Text = tmp.ToString();
				//if (tb.Text == "0") tb.Text = "";
				//cmd.Connection.Close();
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbName = (TextBox) (i.Cells[1].FindControl("txtName"));
				TextBox tbPhone = (TextBox) (i.Cells[2].FindControl("txtPhone"));
				TextBox tbCell = (TextBox) (i.Cells[3].FindControl("txtCell"));
				if (i.Cells[0].Text.ToString() != "0")
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_UpdateContact";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
					cmd.Parameters ["@Name"].Value=tbName.Text.ToString();//Int32.Parse(tb.Text);
					cmd.Parameters.Add("@RegularPhone", SqlDbType.NVarChar);
					cmd.Parameters ["@RegularPhone"].Value=tbPhone.Text.ToString();
					cmd.Parameters.Add("@CellPhone", SqlDbType.NVarChar);
					cmd.Parameters ["@CellPhone"].Value=tbCell.Text.ToString();
					cmd.Parameters.Add("@Caller", SqlDbType.NVarChar);
					cmd.Parameters ["@Caller"].Value="frmContacts";
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
				else
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_AddContact";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
					cmd.Parameters ["@Name"].Value=tbName.Text.ToString();//Int32.Parse(tb.Text);
					cmd.Parameters.Add("@ProfileId", SqlDbType.Int);
					cmd.Parameters ["@ProfileId"].Value=i.Cells[10].Text;
					cmd.Parameters.Add("@OrgId", SqlDbType.Int);
					cmd.Parameters ["@OrgId"].Value=Session["OrgId"].ToString();
					cmd.Parameters.Add("@RegularPhone", SqlDbType.NVarChar);
					cmd.Parameters ["@RegularPhone"].Value=tbPhone.Text.ToString();
					cmd.Parameters.Add("@CellPhone", SqlDbType.NVarChar);
					cmd.Parameters ["@CellPhone"].Value=tbCell.Text.ToString();
					cmd.Parameters.Add("@Caller", SqlDbType.NVarChar);
					cmd.Parameters ["@Caller"].Value="frmContacts";
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["startForm"].ToString() + ".aspx?");
		}

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmUpdContact.aspx?"
				+ "&btnAction=" + "Add");
		}
	}
}
