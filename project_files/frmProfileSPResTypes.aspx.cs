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
	public partial class frmProfileSPResTypes : System.Web.UI.Page
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
				if (Session["Mode"].ToString() == "Profiles")
				{
					lblContents1.Text="Profile: " + Session["ProfileName"].ToString();
					lblContents2.Text="Procedure: " + Session["ProcName"].ToString();
					btnAdd.Width=134;
					btnAllTypes.Visible=false;
					DataGrid1.Columns[6].Visible=false;
				}
				else if (Session["Mode"].ToString() == "Locs")
				
				{
					if (Session["ProfileType"].ToString() == "Producer")
					{
						lblContents1.Text="Location: " + Session["LocationName"].ToString();
						lblContents2.Text="Task Name: " + Session["TaskName"].ToString()	
							+ ": Check Types of Resource Inputs Required";
						/*lblContents3.Text= 
							"Service Output: " + Session["ServiceName"].ToString() */
						
						lblContents4.Text="Note:  Resource Types listed below have been previously"
							+ " indicated by the system administrator as being standard inputs for"
							+ " this task.  You may now simply accept all or some of these selections,"
							+ " or expand the list by clicking on the button 'Show All Resource Types'.";
						btnAdd.Text="  Cancel  ";
						btnExit.Text="OK";
						DataGrid1.Columns[3].Visible=false;
						DataGrid1.Columns[4].Visible=false;
					}
					else
					{
						lblContents1.Text="Location: " + Session["LocationName"].ToString();
						lblContents2.Text="";
						lblContents3.Text= "";
						lblContents4.Text="";
						btnAdd.Visible=false;
						btnAllTypes.Visible=false;
						btnExit.Text="OK";
						DataGrid1.Columns[4].Visible=false;
						DataGrid1.Columns[5].Visible=false;
						DataGrid1.Columns[6].Visible=false;
					}
				}
				
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProfileSPResTypes";
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
				if (Session["ProfileType"].ToString() == "Producer")
				{
					cmd.Parameters.Add ("@ProcId",SqlDbType.Int);
					cmd.Parameters["@ProcId"].Value=Session["ProcId"].ToString();
				}
				else
				{
					cmd.Parameters.Add ("@LocId",SqlDbType.Int);
					cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
				}
			}
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSPResTypes");
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
					cmd.CommandText="eps_UpdateProfileSPResTypes";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Desc", SqlDbType.NText);
					cmd.Parameters ["@Desc"].Value=tbDesc.Text.ToString();//Int32.Parse(tb.Text);
					cmd.Parameters.Add("@Caller", SqlDbType.NVarChar);
					cmd.Parameters ["@Caller"].Value="frmProfileSPResTypes";
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
					CheckBox cb = (CheckBox) (i.Cells[6].FindControl("cbxSel"));
					TextBox tb = (TextBox) (i.Cells[3].FindControl("txtDesc"));
					if (cb.Checked)
					{
						SqlCommand cmd=new SqlCommand();
						cmd.CommandType=CommandType.StoredProcedure;
						cmd.CommandText="eps_AddTaskResources";
						cmd.Connection=this.epsDbConn;
						cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
						cmd.Parameters["@ResTypeId"].Value= i.Cells[1].Text;
						cmd.Parameters.Add ("@TaskId", SqlDbType.Int);
						cmd.Parameters["@TaskId"].Value=Session["TaskId"];
						cmd.Parameters.Add ("@Desc", SqlDbType.NVarChar);
						cmd.Parameters["@Desc"].Value=tb.Text;
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
				Session["CallerRTA"]="frmProfileSPResTypes";
				Response.Redirect (strURL + "frmResourceTypesAll.aspx?");
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
			Response.Redirect (strURL + Session["CSPResTypes"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileSPResTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		protected void btnAllTypes_Click(object sender, System.EventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveResourceTypes";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSPStaff");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			btnAllTypes.Visible=false;
			lblContents4.Visible=false;
		}


	}

}