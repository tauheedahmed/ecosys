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
	/// Summary description for People.
	/// </summary>
	public partial class People : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection ("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
			lblOrg.Text=Session["OrgName"].ToString();
			if (!IsPostBack) 
			{	
				/*if (Session["CallerPeople"].ToString() == "frmStaffing")
				{
					DataGrid1.Columns[8].Visible=false;
					
				}
				DataGrid1.Columns[10].Visible=true;*/
                if (Session["CallerPeople"].ToString() == "frmMainControl")
                {
                    lblContents1.Text = "The list of profile managers is provided below";
                }
                else
                {
                    lblContents1.Text = "The list below includes people from your organization"
                        + " and may also include some people already identified by a user in some other"
                        + " organization.  Click on the button 'Select' to identify the appropriate"
                        + " individual.  If the individual you"
                        + " need to add is not in the list below, click on 'Add'.";
                }
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
	
		private void loadData ()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "hrs_RetrievePeople"; 
            cmd.Connection = this.epsDbConn;
            if (Session["CallerPeople"].ToString() != "frmMainControl")

            {
                cmd.Parameters.Add("@OrgId", SqlDbType.Int);
                cmd.Parameters["@OrgId"].Value = Session["OrgId"].ToString();
                cmd.Parameters.Add("@OrgIdP", SqlDbType.Int);
                cmd.Parameters["@OrgIdP"].Value = Session["OrgIdP"].ToString();
                cmd.Parameters.Add("@LicenseId", SqlDbType.Int);
                cmd.Parameters["@LicenseId"].Value = Session["LicenseId"].ToString();
                cmd.Parameters.Add("@DomainId", SqlDbType.Int);
                cmd.Parameters["@DomainId"].Value = Session["DomainId"].ToString();
            }
            else
            {
                cmd.Parameters.Add("@PeopleServiceFlag", SqlDbType.Int);
                cmd.Parameters["@PeopleServiceFlag"].Value = 1;
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "People");
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            refreshGrid();
        }
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button btU = (Button) (i.Cells[2].FindControl("btnUpdate"));
				Button btD = (Button) (i.Cells[2].FindControl("btnDelete"));
				Button btDet= (Button) (i.Cells[2].FindControl("btnDetails"));
				if (Session["CallerPeople"].ToString() == "frmUpdContractS")
				{
					btDet.Visible=false;
				}
				if (i.Cells[11].Text != Session["OrgId"].ToString())
				{
					btU.Visible=false;
					btD.Visible=false;
				}
			}
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Update")
			{
				Session["CallerUpdPeople"]="frmPeople";
				Response.Redirect (strURL + "frmUpdPeople.aspx?"
					+ "&btnAction1=" + "Update"
					+ "&PeopleId=" + e.Item.Cells[0].Text
					+ "&FName=" + e.Item.Cells[1].Text
					+ "&LName=" + e.Item.Cells[2].Text
					+ "&CPhone=" + e.Item.Cells[3].Text
					+ "&HPhone=" + e.Item.Cells[4].Text
					+ "&WPhone=" + e.Item.Cells[5].Text
					+ "&Addr=" + e.Item.Cells[7].Text
					+ "&Email=" + e.Item.Cells[6].Text
					+ "&Vis=" + e.Item.Cells[9].Text
                    + "&UserLevel=" + e.Item.Cells[12].Text
					);
			}
			else if (e.CommandName == "Details")
			{
				Session["CallerPeopleRoles"]="frmPeople";
				Session["PeopleId"]=e.Item.Cells[0].Text;
				Session["PeopleName"]=e.Item.Cells[1].Text + " " + e.Item.Cells[2].Text;
				Response.Redirect (strURL + "frmPeopleRoles.aspx?");
			}
			else if (e.CommandName == "Select")
			{
                if (Session["CallerPeople"].ToString() == "frmStaffActions")
                {
				    Session["PeopleId"]=e.Item.Cells[0].Text;
				    Session["PeopleName"]=e.Item.Cells[1].Text + " " + e.Item.Cells[2].Text;
                    Session["btnAction"]="Add";
				    Response.Redirect (strURL + "frmUpdStaffAction.aspx?");
                } 
                else if (Session["CallerPeople"].ToString() == "frmProcSReq")
                {
                    Session["PeopleId"] = e.Item.Cells[0].Text;
                    Session["PeopleName"] = e.Item.Cells[1].Text + " " + e.Item.Cells[2].Text;
                    Session["btnAction"] = "Add";
                    Response.Redirect(strURL + "frmProcSReq.aspx?");
                }
                else if (Session["CallerPeople"].ToString() == "frmUpdContractS")
                {
                    Session["PeopleId"] = e.Item.Cells[0].Text;
                    Session["PeopleName"] = e.Item.Cells[1].Text + " " + e.Item.Cells[2].Text;
                    Session["SelType"] = "People";
                    Response.Redirect(strURL + "frmUpdContractS.aspx?");
                } 
                else if (Session["CallerPeople"].ToString() == "frmMainControl")
                {
                    Session["CPST"] = "frmPeople";
				    Session["PeopleId"]=e.Item.Cells[0].Text;
				    Session["PeopleName"]=e.Item.Cells[1].Text + " " + e.Item.Cells[2].Text;
				    Response.Redirect (strURL + "frmPeopleServiceTypes.aspx?");
                    Exit();
                }
                else
                {
                    Session["SelType"] = "People";
                    Session["PeopleId"] = e.Item.Cells[0].Text;
                    Session["PeopleName"] = e.Item.Cells[1].Text + " " + e.Item.Cells[2].Text;
			    }
				
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_DeletePeople";
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
			Session["CallerUpdPeople"]="frmPeople";
			Response.Redirect (strURL + "frmUpdPeople.aspx?"
				+ "&btnAction1=Add");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			if (Session["CallerPeople"].ToString() == "frmStaffing")
			{
				updateGrid();
			}
			Exit();
		}
		private void updateGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[10].FindControl("cbxSel"));
				if (cb.Checked)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="hrs_AddStaffing";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@OrgId", SqlDbType.Int);
					cmd.Parameters ["@OrgId"].Value=Session["OrgIdt"].ToString();
					cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
					cmd.Parameters ["@PeopleId"].Value=i.Cells[0].Text;
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CallerPeople"].ToString() + ".aspx?");
		}
	}
}
