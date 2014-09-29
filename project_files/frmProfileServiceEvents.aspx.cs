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
	public partial class frmProfileServiceEvents : System.Web.UI.Page
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
                if (Session["ProfileType"] == "Consumer")
                {
                    lblTitle.Text = "EcoSys:  Individual/Household Characteristics";
                    btnAddE.Text = "Add Event";
                    lblProfilesName.Text = "Type of Characteristic: " + Session["ProfilesName"].ToString();
                    lblServiceName.Text = "Stage: " + Session["ServiceName"].ToString();
                    lblContent1.Text = "Listed below are various events related to the above stage."
                   + " Review the list below to ensure that it includes all events for this stage."
                   + " Use the 'Add Events' button to add to the list as needed.";
                    DataGrid1.Columns[3].HeaderText = "Events";
                    DataGrid1.Columns[4].HeaderText = "Checklist Items";
                }
                else
                {
                    lblProfilesName.Text = "Business: " + Session["ProfilesName"].ToString();
                    lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                    lblContent1.Text="Listed below are various deliverables for the above service."  
		            + " Review the list below to ensure that it includes all deliverables for this service. Use the 'Add Deliverable'" 
		            + " button to add to the list as needed.";
                }
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
			cmd.CommandText="wms_RetrieveProfileSEvents";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ProfileServicesId",SqlDbType.Int);
			cmd.Parameters["@ProfileServicesId"].Value=Session["ProfileServicesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSProcs");
            if (ds.Tables["ProfileSProcs"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContent1.Text = "There are no deliverables for the above service"
                    + " that have been identified.";
            }
            else
            {
                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                refreshGrid();
            }
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bt = (Button) (i.Cells[4].FindControl ("btnUpdate"));
                Button btP = (Button) (i.Cells[4].FindControl ("btnProcs"));
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
                if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    if (Session["ProfileType"].ToString() == "Consumer")
                    {
                        btP.Text = "Services";
                        btP.CommandName = "Services";
                        bt.Text = "Other";
                        bt.CommandName = "Other";
                    }
                }
			}
		}	
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tb = (TextBox) (i.Cells[2].FindControl("txtSeq"));
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateProfileSESeqNo";
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
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSEvents"].ToString() + ".aspx?");
		}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Procs")
			{
			Session["ProfileSEventsId"]=e.Item.Cells[0].Text;
			Session["EventsName"]=e.Item.Cells[3].Text;
			Session["CPSEProcs"]="frmProfileServiceEvents";
			Response.Redirect (strURL + "frmProfileSEProcs.aspx?");
			}

			else if (e.CommandName == "Update")
			{
				Session["CUpdEvent"]="frmProfileserviceEvents";
				Response.Redirect (strURL + "frmUpdEvent.aspx?"
					+ "&btnAction=" + "Update"
					+ "&Id=" + e.Item.Cells[1].Text
					+ "&Name=" + e.Item.Cells[3].Text
					+ "&OrgId=" + e.Item.Cells[5].Text
					+ "&Desc=" + e.Item.Cells[6].Text					
					+ "&Vis=" + e.Item.Cells[7].Text
					);
			}
            else if (e.CommandName == "Clients")
            {
                Session["CPSEPC"] = "frmProfileserviceEvents";
                Session["ProfileSEventsId"] = e.Item.Cells[0].Text;
                Session["EventsName"] = e.Item.Cells[3].Text;
                Response.Redirect(strURL + "frmPSEPClient.aspx?");

            }
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileServiceEvents";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
            else if (e.CommandName == "Services")
            {
                Session["CPSEResources"] = "frmProfileServiceEvents";
                Session["PSEId"] = e.Item.Cells[0].Text;
                Session["RType"] = "0";
                Response.Redirect(strURL + "frmPSEResources.aspx?");
            }
            else if (e.CommandName == "Other")
            {
                Session["CPSEResources"] = "frmProfileServiceEvents";
                Session["PSEId"] = e.Item.Cells[0].Text;
                Session["RType"] = "1";
                Response.Redirect(strURL + "frmPSEResources.aspx?");
            }
		}

		protected void btnAddS_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Session["CSEvents"]="frmProfileServiceEvents";
			Response.Redirect (strURL + "frmServiceEvents.aspx?");	
		}

		protected void btnAddP_Click(object sender, System.EventArgs e)
		{
			Session["CEventsAll"]="frmProfileserviceEvents";
			Response.Redirect (strURL + "frmProfileModels.aspx?");	
		}

	}

}