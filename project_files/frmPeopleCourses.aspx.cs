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
	public partial class frmPeopleCourses : System.Web.UI.Page
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
			this.dgdActs.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.itemCommand);

		}
		#endregion
		private void loadForm()
		{	
			lblOrg.Text=Session["OrgName"].ToString();
			lblContents1.Text=Session["FName"].ToString() + " " + Session["LName"].ToString();
			lblContents2.Text="Class Registration";
			if (!IsPostBack) 
			{	
				loadClasses();
			}
		}
		private void loadClasses ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveActPeopleCourses";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ActPeople");
			Session["ds"] = ds;
			dgdActs.DataSource=ds;
			dgdActs.DataBind();
			refreshClasses();
		}
		private void refreshClasses()
		{
			foreach (DataGridItem i in dgdActs.Items)
			{
				Button bReg = (Button)(i.Cells[9].FindControl("btnDelete"));
				
				if (i.Cells[7].Text == "Course Cancelled")
				{
					i.Cells[5].Text = "Course Cancelled";
					bReg.Visible=true;
					bReg.Text="Delete";
				}
				else if (i.Cells[5].Text == "Cancelled")
				{
					i.Cells[5].Text = "Registration Cancelled";
					bReg.Visible=false;
				}
				else if ((i.Cells[5].Text) == "Awaiting Registration")
				{
					i.Cells[5].Text = "Awaiting Registration";
					bReg.Visible=true;	
					bReg.Text = "Cancel Registration";
				}
				else if ((i.Cells[5].Text == "Passed")
					||(i.Cells[5].Text == "Failed"))
				{
					bReg.Visible=false;
				}
				else if (i.Cells[8].Text == "Cancellation Requested")
				{
					i.Cells[5].Text = "Your Cancellation Request Is Being Processed";
					bReg.Visible=false;
				}
				
				else if (i.Cells[5].Text == "Registered")
				{
					bReg.Visible=true;
					bReg.Text="Request Cancellation";
				}
				else
				{
					bReg.Visible=false;
				}
			}
		}

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["startForm"].ToString() + ".aspx?");
		}

		private void itemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Delete")
			{				
				Button bReg = (Button)(e.Item.Cells[9].FindControl("btnDelete"));
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteActPeople";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Parameters.Add ("@Option", SqlDbType.NVarChar);
					if (bReg.Text == "Cancel Registration")
					{
						cmd.Parameters["@Option"].Value="Delete";
					}
					else if (bReg.Text == "Request Cancellation")
					{
						cmd.Parameters["@Option"].Value="Cancel";
					}
				cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				
				loadClasses();
			}
			else if (e.CommandName == "UnRegister")
			{//lblContents1.Text="hi";
				
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateUnRegister";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadClasses();
			}
			}
		protected void btnAddS_Click(object sender, System.EventArgs e)
		{
		{
			Session["CallerServices"]="frmPeopleCourses";
			Session["OrgIdt"]=Session["OrgId"];
			Session["OrgNamet"]=Session["OrgName"];
			Response.Redirect (strURL + "frmPeopleCoursesAll.aspx?");
		}
		}
	}

}
	