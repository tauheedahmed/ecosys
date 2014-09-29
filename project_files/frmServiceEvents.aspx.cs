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
	public partial class frmServiceEvents: System.Web.UI.Page
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
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["Section"].ToString() == "I")
                {
                    lblTitle.Text = "Service Models";
                    lblProfilesName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                    DataGrid1.Columns[9].Visible = true;
                    DataGrid1.Columns[2].Visible = false;
                    DataGrid1.Columns[4].Visible = false;
                    lblContent2.Text = "Listed below are various deliverables that may possibly result"
                        + " from the service indicated above";
                    lblContent1.Text = "";
                }
                else
                {
                    DataGrid1.Columns[2].Visible = false;
                    DataGrid1.Columns[4].Visible = false;
                    if (Session["ProfileType"] == "Consumer")
                    {
                        lblTitle.Text = "Individual/Household Characteristics";
                        lblProfilesName.Text = "Type of Characteristic: " + Session["ProfilesName"].ToString();
                        lblServiceName.Text = "Stage: " + Session["ServiceName"].ToString();
                        DataGrid1.Columns[3].HeaderText = "Events";
                        lblContent2.Text = "Listed below are various Events that are"
                            + " that are provided for the above stage.";
                        lblContent1.Text = "";
                        btnAddE.Visible = false;
                    }
                    else if (Session["ProfileType"] == "Producer")
                    {
                        lblTitle.Text = "Business Models";
                        lblProfilesName.Text = "Business: " + Session["ProfilesName"].ToString();
                        lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                        lblContent2.Text = "Listed below are various deliverables that form"
                            + " part of the service indicated above"
                            + " in various types of organizations."
                            + " If this list does not include all deliverables resulting from this service, use the 'Add Deliverables' button to add to the list as needed.";
                        lblContent1.Text = "";
                    }
                }

                /*else if (Session["startForm"].ToString() == "frmMainControl")
                {
                    if (Session["CSEvents"].ToString() == "frmProfileServiceEvents")
                    {
                        DataGrid1.Columns[9].Visible=true;
                        DataGrid1.Columns[2].Visible=false;
                        DataGrid1.Columns[4].Visible=false;
                        btnAddE.Visible=false;
                        lblContent1.Text="Listed below are various deliverables that may result"
                            + " as part of the service titled '"
                            + Session["ServiceName"].ToString()
                            + "' in similar organizations as yours."
                            + " Select all such deliverables for your organization.";
    			
                        lblContent2.Visible=false;
                    }
                    else if (Session["CSEvents"].ToString() == "frmServiceTypes")
                    {
                        DataGrid1.Columns[9].Visible=false;
                        DataGrid1.Columns[2].Visible=true;
                        DataGrid1.Columns[4].Visible=true;
                        btnAddE.Visible=true;
                        lblContent1.Text="Listed below are various events that trigger"
                            + " delivery of the service titled '"
                            + Session["ServiceName"].ToString()
                            + "' in various types of organizations."
                            + " Review the list below to ensure that it includes all such events."
                            + " Use the 'Add Events' button to add to the list as needed.";
    			
                        lblContent2.Text="There may be more than process involved in delivering"
                            +  " a given service in response to a given event."
                            + " Thus, e.g. a service may require a 'Preparation Process'"
                            + " that is undertaken in anticipation of a given type of event, followed by a 'Response Stage'"
                            + " that is undertaken when an event actually occurs."
                            + " Click on the button titled 'Procedures' to identify the Procedures"
                            + " related to each event.";
                    }
                }*/
            }
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
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveSEvents";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ServicesId",SqlDbType.Int);
			cmd.Parameters["@ServicesId"].Value=Session["ServicesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"SEvents");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			if (Session["CSEvents"].ToString() == "frmProfileServiceEvents")
			{
				refreshGrid1();
			}
			else if (Session["CSEvents"].ToString() == "frmServiceTypes")
			{
				refreshGrid2();
			}
		}
		private void refreshGrid1()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[9].FindControl("cbxSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id from ProfileServiceEvents"
					+  " Where EventsId = " + i.Cells[1].Text
					+ " and ProfileServicesId = " + Session["ProfileServicesId"].ToString();
				cmd.Connection.Open();
			
				if (cmd.ExecuteScalar() != null) 
				{
					cb.Checked = true;
					cb.Enabled=false;
				}
				cmd.Connection.Close();
			}
		}
		private void refreshGrid2()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bt = (Button) (i.Cells[4].FindControl ("btnUpdate"));
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtSeq"));
				if (i.Cells[8].Text == "&nbsp;")
				{
					tb.Text="99";
				}
				else tb.Text=i.Cells[8].Text;
				if (Session["OrgId"].ToString() == i.Cells[5].Text)
				{
					bt.Visible=true;
				}
				else
				{
					bt.Visible=false;
					i.Cells[5].Text = "Externally Mainained";
				}
			}
		}	
		private void updateGrid2()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtSeq"));
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateSESeqNo";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add("@Id", SqlDbType.Int);
				cmd.Parameters ["@Id"].Value=i.Cells[0].Text;
                cmd.Parameters.Add("@Seq", SqlDbType.Int);
                if (tb.Text != "")
                {
                    cmd.Parameters["@Seq"].Value = Int32.Parse(tb.Text);
                }
                else
                {
                    cmd.Parameters["@Seq"].Value = 0;
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			}
		}
		private void updateGrid1()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[9].FindControl("cbxSel"));
				if ((cb.Checked) & (cb.Enabled))
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.Connection=this.epsDbConn;
					cmd.CommandText="wms_AddPSEvents";
					cmd.Parameters.Add("@ProfileServicesId", SqlDbType.Int);
					cmd.Parameters ["@ProfileServicesId"].Value=Session["ProfileServicesId"].ToString();				
					cmd.Parameters.Add("@EventsId", SqlDbType.Int);
					cmd.Parameters ["@EventsId"].Value=i.Cells[1].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (Session["CSEvents"].ToString() == "frmProfileServiceEvents")
			{
				updateGrid1();
			}
			else if (Session["CSEvents"].ToString() == "frmServiceTypes")
			{
				updateGrid2();
			}
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CSEvents"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Procs")
			{
			Session["ServiceEventsId"]=e.Item.Cells[0].Text;
			Session["EventsName"]=e.Item.Cells[3].Text;
			Session["CSEProcs"]="frmServiceEvents";
			Response.Redirect (strURL + "frmSEProcs.aspx?");
			}
			else if (e.CommandName == "Update")
			{
				Session["CUpdEvent"]="frmServiceEvents";
				Response.Redirect (strURL + "frmUpdEvent.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[1].Text
					+ "&Name=" + e.Item.Cells[3].Text
					+ "&OrgId=" + e.Item.Cells[5].Text
					+ "&Desc=" + e.Item.Cells[6].Text					
					+ "&Vis=" + e.Item.Cells[7].Text
					);
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteServiceEvents";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		protected void btnAddS_Click(object sender, System.EventArgs e)
		{
			updateGrid2();
			Session["CEventsAll"]="frmServiceEvents";
			Response.Redirect (strURL + "frmEventsAll.aspx?");	
		}

	}

}