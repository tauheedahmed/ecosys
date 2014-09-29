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
	/// Summary description for frmProceduresProcedures.
	/// </summary>
	public partial class frmServicesPeople : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Plans();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Plans()
		{
			lblOrg1.Text=(Session["OrgName"]).ToString();
			if (!IsPostBack) 
			{
				loadData();
			}
		}
		private void loadData()
		{
			
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveServices";
			cmd.Connection=this.epsDbConn;
			if (Session["CallerServices"].ToString() == "frmPeopleCourses")
			{
				cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
				cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="frmPeopleCourses";
			}
			else if ((Session["CallerServices"].ToString() == "frmPeopleStatus"))
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value="frmPeopleStatus";
			}
			else if ((Session["CallerServices"].ToString() == "frmRoleSkills"))
			{
				/*cmd.Parameters.Add ("@RoleId",SqlDbType.Int);
				cmd.Parameters["@RoleId"].Value=Session["RoleId"].ToString();
				cmd.Parameters.Add ("@ResourceId",SqlDbType.Int);
				cmd.Parameters["@Caller"].Value="Role";*/
			}
			else if ((Session["CallerServices"].ToString() == "frmOrgs"))
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgIdt"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value=Session["CallerServices"].ToString();
			}
			else if ((Session["CallerServices"].ToString() == "frmMainOrgs"))
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value=Session["CallerServices"].ToString();
			}
			else if ((Session["CallerServices"].ToString() == "frmMainTrg"))
			{
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
				cmd.Parameters["@Caller"].Value=Session["CallerServices"].ToString();
			}
			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Outputs");
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			gridSet();

		}
		private void gridSet()
		{
			if (Session["CallerServices"].ToString() == "frmOrgs")
			{
				lblContent1.Text="Service List";
				gridSet2();
			}
					
			else if ((Session["CallerServices"].ToString() == "frmPeopleRoles")
				|| (Session["CallerServices"].ToString() == "frmPeopleCourses"))

			{
				lblContent1.Text="Available Courses";
				gridSet3();
			}
			else if	(Session["CallerServices"].ToString() == "frmMainTrg")
			{
				lblContent1.Text="Available Courses";
				gridSet2();
			}
			else
			{
				lblContent1.Text="Service List";
				gridSet2();
			}
		}
			private void gridSet1()
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					Button bItem = (Button)(i.Cells[6].FindControl("btnItems"));
					bItem.Visible=true;
					if (i.Cells[9].Text.StartsWith("&") == true)
					{
						bItem.Enabled=false;
						bItem.Text="";
					}
					else
					{
						bItem.Text = i.Cells[9].Text;
					}
					Button bEm = (Button)(i.Cells[8].FindControl("btnProcedures"));
					bEm.Visible=false;
					Button bRg = (Button)(i.Cells[8].FindControl("btnRegular"));
					bRg.Visible=false;				
				}
			}
		private void gridSet2()
			   {
			DataGrid1.Columns[1].ItemStyle.Width=300;
			DataGrid1.Columns[6].ItemStyle.Width=300;
			DataGrid1.Columns[7].ItemStyle.Width=90;
			DataGrid1.Columns[8].ItemStyle.Width=100;
			DataGrid1.Width=850;
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bItem = (Button)(i.Cells[6].FindControl("btnItems"));
				if (i.Cells[9].Text.StartsWith("&") == true)
				{
					bItem.Enabled=false;
					bItem.Text="";
				}
				else 
				{
					bItem.Visible=true;
					bItem.Text=i.Cells[9].Text;
					/*Button bIt = (Button)(i.Cells[8].FindControl("btnItems"));
					   bIt.Visible=false;*/
				}
			}
			   }
		private void gridSet3()
		{
			DataGrid1.Columns[6].Visible=true;
			DataGrid1.Columns[7].Visible=false;
			DataGrid1.Columns[8].Visible=false;
			DataGrid1.Width=510;
			DataGrid1.Columns[6].HeaderStyle.Width=100;			

			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bItem = (Button)(i.Cells[6].FindControl("btnItems"));
				if (i.Cells[9].Text.StartsWith("&") == true)
				{
					bItem.Enabled=false;
					bItem.Text="";
				}
				else 
				{
					bItem.Visible=true;
					bItem.Text=i.Cells[9].Text;
				}
				Button bEm = (Button)(i.Cells[6].FindControl("btnUpdate"));
				bEm.Visible=false;
				Button bRg = (Button)(i.Cells[6].FindControl("btnDelete"));
				bRg.Visible=false;	
			}
		}
		
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmUpdServices.aspx?"
				+ "&btnAction=" + "Add"
				+ "&SupplierOrg=" + Session["OrgId"].ToString());
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "BIA")
			{
				Response.Redirect (strURL + "frmCommitments.aspx?"
					+ "&ResourceId=" + e.Item.Cells[0].Text
					+ "&OutputName=" + e.Item.Cells[1].Text );
			}
			else if (e.CommandName == "Update")
			{
				Response.Redirect (strURL + "frmUpdServices.aspx?"
					+ "&btnAction=" + "Update"
					+ "&ResourceId=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Vis=" + e.Item.Cells[3].Text
					+ "&Type=" + e.Item.Cells[4].Text
					+ "&SupplierOrg=" + e.Item.Cells[5].Text);
			}
			else if (e.CommandName == "Procedures")
			{
				Session["CallerServiceSteps"]="frmServices";
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ResourceId"]=e.Item.Cells[0].Text;
				//Session["StepType"]="";
				Response.Redirect (strURL + "frmServiceSteps.aspx?");
			}
			/*else if (e.CommandName == "Regular")
			{
				Session["CallerServiceSteps"]="frmServices";
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ResourceId"]=e.Item.Cells[0].Text;
				Session["StepType"]="Regular";
				Response.Redirect (strURL + "frmServiceSteps.aspx?");
			}*/
			else if (e.CommandName == "Items")
			{
				Session["CallerActivations"]="frmServices";
				Session["ActivationName"]=e.Item.Cells[9].Text;
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ResourceId"]=e.Item.Cells[0].Text;
				Session["Timetable"]=e.Item.Cells[10].Text;
				Session["OrgIdt"]=e.Item.Cells[5].Text;
				Session["OrgNamet"]=e.Item.Cells[12].Text;
				Session["Mode"]="Actual";
				//Session["Activity"]=38;
				Response.Redirect (strURL + "frmActivations.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				try
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="eps_DeleteOutput";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@Id", SqlDbType.Int);
					cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
					loadData();
				}
				catch(SqlException err)
				{
					if (err.Message.StartsWith ("DELETE statement conflicted with COLUMN REFERENCE constraint 'FK_ServiceSteps_Resources'.")) 
						lblContent1.Text = "This service has procedures linked to it.";  
					else lblContent1.Text = err.Message;
				}
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerServices"].ToString() + ".aspx?");
		}


	}

}
	