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
	public partial class frmProfileSPC : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
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
			if (!IsPostBack) 
			{	
				lblOrg.Text=Session["OrgName"].ToString();
				loadData();
				if (Session["Mode"].ToString() == "Locs")
				{
					lblContents1.Text="Location: " + Session["LocationName"].ToString();
					lblContents2.Text="Task Name: " + Session["ResourceName"].ToString()
						+ Session["TaskName"].ToString() + ": Check Types of Resource Required";
					btnAdd.Text="  Cancel  ";
					DataGrid1.Columns[3].Visible=false;
					DataGrid1.Columns[4].Visible=false;
				}
				else if (Session["Mode"].ToString() == "Profiles")
				{
					lblContents1.Text=Session["ProfileName"].ToString();
					lblContents2.Text=Session["ProcName"].ToString() + ": Types of Contacts";
					btnAdd.Width=134;
					DataGrid1.Columns[6].Visible=false;
				}
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProfileSPC";
			cmd.Connection=this.epsDbConn;
			if (Session["Mode"].ToString() == "Profiles")
			{
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ProfileSPId"].ToString();
			}
			if (Session["Mode"].ToString() == "Locs")
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@ResourceTypeId",SqlDbType.Int);
				cmd.Parameters["@ResourceTypeId"].Value=Session["ResourceTypeId"].ToString();
				cmd.Parameters.Add ("@ProcId",SqlDbType.Int);
				cmd.Parameters["@ProcId"].Value=Session["ProcId"].ToString();
			}
			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSPC");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (Session["Mode"].ToString() == "Profiles")
			{
				assignValues();
			}
		}
		private void assignValues()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbDesc = (TextBox)(i.Cells[3].FindControl("txtDesc"));
				if (i.Cells[5].Text == "&nbsp;")
				{
					tbDesc.Text=null;
				}
				else
				{
					tbDesc.Text = i.Cells[5].Text;
				}
			}
		}
		private void updateGrid()
		{
			if (Session["Mode"].ToString() == "Profiles")
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tbDesc = (TextBox)(i.Cells[3].FindControl("txtDesc"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_UpdateProfileSPC";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Desc", SqlDbType.NText);
					cmd.Parameters ["@Desc"].Value=tbDesc.Text.ToString();//Int32.Parse(tb.Text);
					cmd.Parameters.Add("@Caller", SqlDbType.NVarChar);
					cmd.Parameters ["@Caller"].Value="frmProfileSPC";
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=i.Cells[0].Text.ToString();
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
			else if (Session["Mode"].ToString() == "Locs")
			{
				
				foreach (DataGridItem i in DataGrid1.Items)
				{
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_AddContactTypes";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
						cmd.Parameters["@RoleId"].Value= i.Cells[1].Text;
						cmd.Parameters.Add ("@TaskId", SqlDbType.Int);
						cmd.Parameters["@TaskId"].Value=Session["TaskId"];
						cmd.Connection.Open();
						cmd.ExecuteNonQuery();
						cmd.Connection.Close();
					}
				}
			}
		}
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (Session["Mode"].ToString() == "Profiles")
			{
				updateGrid();
				Session["CallerCTA"]="frmProfileSPC";
				Response.Redirect (strURL + "frmContactTypesAll.aspx?");
			}
			else
			{
				Exit();
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CSPC"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileSPC";
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