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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmTaskResources: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private int I;
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
				lblOrg.Text=Session["Orgname"].ToString();
				lblContents1.Text="Location: " + Session["LocationName"].ToString();
				lblContents2.Text="Task: " + Session["TaskName"].ToString();
				loadData();
				if (Session["startForm"].ToString() == "frmMainEPS")
				{
					DataGrid1.Columns[7].Visible=false;
				}
			}		
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="eps_RetrieveTaskResources";		
			cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
			cmd.Parameters["@TaskId"].Value=Session["TaskId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"TaskR");
			if (ds.Tables["TaskR"].Rows.Count == 0)
			{
				if (I == 0)
				{
					addTaskResources();
				}
				else
				{
					lblContents1.Text="Sorry, task goods could not be created.  Contact the system administrator.";

				}
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void addTaskResources()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateTaskResourcesfromProfiles";//"eps_RetrieveProfileSPStaff";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@TaskId",SqlDbType.Int);
			cmd.Parameters["@TaskId"].Value=Session["TaskId"].ToString();			
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			I++;
			loadData();
			//Response.Redirect (strURL + "frmTaskResources.aspx?");
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				//Button bt = (Button)(i.Cells[10].FindControl("btnDetails"));
				TextBox tb = (TextBox) (i.Cells[9].FindControl("txtQty"));
				Label lb = (Label) (i.Cells[9].FindControl("lblQtyMeasure"));
				tb.Text=i.Cells[8].Text;
				if (tb.Text == "&nbsp;") tb.Text="0";
				lb.Text=i.Cells[12].Text;
				if ((i.Cells[5].Text == "0") & (i.Cells[6].Text == "0"))
				{
					//bt.Text="Add Item";
					//bt.Width=115;
					//bt.CommandName="Add";
				}
				else 
				{
					//bt.Text=""; 
					//bt.Enabled=false;
				}
				if (i.Cells[4].Text == "Backup")
				{
					i.Cells[3].Text=i.Cells[3].Text + "(Backup)";
				}
			}
		}
		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Add")
			{			
				Session["TaskResId"]=e.Item.Cells[0].Text;
				Session["ResTypeId"]=e.Item.Cells[1].Text;
				Session["ResTypeName"]=e.Item.Cells[3].Text;
				Session["CResAll"]="frmTaskResources";
				Response.Redirect (strURL + "frmResourcesAll.aspx?");	
			}
			else if (e.CommandName == "Details")
			{
			string Type;
			if (e.Item.Cells[5].Text == "0")
				{
					Type = "Inventory";
				}
					else
				{
					Type ="Procurement";
				}
				Session["Id"]=e.Item.Cells[6].Text;
				Session["TaskResId"]=e.Item.Cells[0].Text;
				Session["ResTypeName"]=e.Item.Cells[3].Text;
				Session["CallerDisInv"]="frmTaskResources";
				Response.Redirect (strURL + "frmDisplayInventory.aspx?"
					+ "&BackupId=" + e.Item.Cells[2].Text
					+ "&Type=" + Type);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteTaskResources";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			loadData();
		}
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[9].FindControl("txtQty"));
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateTaskResourceQty";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text;
					cmd.Parameters.Add("@Qty", SqlDbType.Decimal);
					cmd.Parameters ["@Qty"].Value=tb.Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}

		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerTaskResources"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void btnAddInv_Click(object sender, System.EventArgs e)
		{
			Session["CInv"]="frmTaskResources";
			Session["Mode"]="Read";
			Response.Redirect (strURL + "frmInventory.aspx?");
		}

		private void btnAddProcure_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmProcurement.aspx?"
				+ "&btnAction=Add");
		}

		protected void btnAddTemp_Click(object sender, System.EventArgs e)
		{
			Session["Mode"]="Locs";
			Session["ProfileType"]= "Producer";
			Session["CSPResTypes"]="frmTaskResources";
			Response.Redirect (strURL + "frmProfileSPResTypes.aspx?");
		}

		private void btnAddGood_Click(object sender, System.EventArgs e)
		{
		
		}

	}

}

