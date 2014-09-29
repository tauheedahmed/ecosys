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
	/// Summary description for frmEmergencyProcedures.
	/// </summary>
	public partial class frmProfileServiceTypes : System.Web.UI.Page
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
            if (Session["ProfileType"].ToString() == "Producer")
            {
                lblTitle.Text = "Business Models";
                lblBusProfiles.Text = "Business:  " + Session["ProfilesName"].ToString();
                lblContent3.Text = "As indicated earlier, a business model"
                + " identifies the various services that are delivered for a given industry or function and,"
                + " For each service, it then identifies key service"
                + " deliverables, as well as related delivery procedures, staffing and other resource requirements, clients and service standards.";
			    lblContent1.Text="Thus, the list of services below provides a first look at the business"
                + " indicated above."
				    + "  Use the 'Add Services' button to add to this list as needed.";			
			    lblContent2.Text="Once the list of services is complete, proceed to add details for each service listed below"
				    + " by clicking on the"
				    + " pushbutton titled 'Deliverables' to the right of each given service.";
            }
            /*else
            {
                lblTitle.Text = "EcoSys:  Individual/Household Characteristics";
                lblBusProfiles.Text = "Type of Characteristic:  " + Session["ProfilesName"].ToString();
                lblContent3.Text = "To continue, click on 'Events' for the appropriate stage in the list below.";
                lblContent1.Visible = false;
                lblContent2.Visible = false;
                
                DataGrid1.Columns[3].HeaderText = "Stages";
                DataGrid1.Columns[5].HeaderText = "";
                lblOverview.Visible = false;
                btnRpt1.Visible = false;
                btnRpt2.Visible = false;
                btnRpt3.Visible = false;
                btnRpt4.Visible = false;
                btnRpt5.Visible = false;
                if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    btnAdd.Visible = false;
                }
            }*/
			if (!IsPostBack)
			{
				Load_Procedures();
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
		private void Load_Procedures()
		{
            
            /*lblProfilesName.Text = "Business Profile for: " + Session["ProfilesName"].ToString();
            lblProcs.Text = "To review key procedures involved in generating one of more of the various service"
                    + " deliverables, ";
            lblStaff.Text = "To review various staff roles involved in executing key processes above, ";
            lblOther.Text = "To review various types of goods and services involved in executing key processes above, ";*/
           loadData();
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProfileServiceTypes";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProfilesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileServices");
            if (ds.Tables["ProfileServices"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
                lblContent3.Text = "There are no services identified as yet for this business.";
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
				TextBox tb = (TextBox) (i.Cells[1].FindControl("txtSeq"));
                Button btnD = (Button)(i.Cells[5].FindControl("btnDeliver"));
                
                Button btnR = (Button)(i.Cells[5].FindControl("btnRemove"));
				if (i.Cells[6].Text == "&nbsp;")
				{
					tb.Text="99";
				}
				else tb.Text=i.Cells[6].Text;
                /*if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    if (Session["ProfileType"].ToString() == "Consumer")
                    {
                        btnD.Text = "Events";
                        btnR.Visible = false;
                    }
                }*/
			}
		}	

		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
            updateGrid();
			Session["CServiceTypes"] = "frmProfileServiceTypes";
			Response.Redirect (strURL + "frmServiceTypes.aspx?");
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
				TextBox tb = (TextBox) (i.Cells[1].FindControl("txtSeq"));
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdatePSSeqNo";
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
		private void Exit()
		{
			Response.Redirect (strURL + Session["CPSTypes"].ToString() + ".aspx?");
		}
        protected void btnRpt1_Click(object sender, System.EventArgs e)
        {
            

        }
        

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Deliver")
			{
				Session["CPSEvents"]="frmProfileServiceTypes";
				Session["ProfileServicesId"]=e.Item.Cells[0].Text;
				Session["ServicesId"]=e.Item.Cells[2].Text;
				Session["ServiceName"]=e.Item.Cells[3].Text;
				Response.Redirect(strURL + "frmProfileServiceEvents.aspx?");
			}
            else if (e.CommandName == "Clients")
            {
                Session["CPSEPC"] = "frmProfileServiceTypes";
                Session["ProfileServicesId"] = e.Item.Cells[0].Text;
                Session["ServicesId"] = e.Item.Cells[2].Text;
                Session["ServiceName"] = e.Item.Cells[3].Text;
                Response.Redirect(strURL + "frmPSEPClient.aspx?");

            }
            /*else if (e.CommandName == "Services")
            {
                Session["CPSResources"] = "frmProfileServiceTypes";
                Session["ProfileServicesId"] = e.Item.Cells[0].Text;
                Session["RType"] = "0";
                Response.Redirect(strURL + "frmProfileServiceResources.aspx?");
            }
            else if (e.CommandName == "Other")
            {
                Session["CPSResources"] = "frmProfileServiceTypes";
                Session["ProfileServicesId"] = e.Item.Cells[0].Text;
                Session["RType"] = "1";
                Response.Redirect(strURL + "frmProfileServiceResources.aspx?");
            }*/
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteProfileService";//eps_DeleteSkillCourses
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Load_Procedures();
			}
		}
        protected void btnRpt2_Click(object sender, EventArgs e)
        {
            

        }
        protected void btnRpt3_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnRpt4_Click(object sender, EventArgs e)
        {
            
        }
        protected void btnRpt5_Click(object sender, EventArgs e)
        {
            

        }
        /*protected void btnRpt6_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Session["ProfilesId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProfOutputs.rpt";
            rpts();	
        }*/
}

}