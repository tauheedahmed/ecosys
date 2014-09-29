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
	public partial class frmProfiles : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
            // Put user code to initialize the page here
			Load_Profiles();
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
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Delete);

		}
		#endregion
		private void Load_Profiles()
		{
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                DataGrid1.Columns[8].Visible = false;
                if (Session["ProfileType"].ToString() == "Producer")
                {
                    lblContent2.Text = "Click on the button 'Update' to appoint a manager for the given profile.";
                }
                else if (Session["ProfileType"].ToString() == "Consumer")
                {
                    DataGrid1.Columns[5].Visible = false;
                    DataGrid1.Columns[6].Visible = false;
                }
            }
            else if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {  
                btnAdd.Visible = false;
                btnStartS.Visible = false;
                DataGrid1.Columns[4].Visible = false;
                DataGrid1.Columns[8].Visible = false;
                DataGrid1.Columns[11].Visible = false;
                

                if (Session["ProfileType"].ToString() == "Producer")
                {
                    lblTitle.Text = "Business Models";
                    lblTitle1.Text = "Model Designer: " + Session["FName"].ToString() 
                        + " " + Session["Lname"].ToString();
                    lblContent1.Text = "Listed below are the business models for which you are the designated author."
                    + " Click on the button 'Services Provided' to the right of the appropriate business profile"
                    + " to review and edit the profile as needed.";
                    DataGrid1.Columns[1].HeaderText = "Business Models";
                }
                else if (Session["ProfileType"].ToString() == "Consumer")
                {
                    lblTitle1.Text = "Household Characteristics";
                    DataGrid1.Columns[8].Visible = false;
                    DataGrid1.Columns[1].HeaderText = "Characteristics";
                    lblContent1.Text = "Click on 'Select' for the appropriate characteristic to continue";
                }
            }
            

			if (!IsPostBack) 
			{
				loadData();
			}
		}
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.Text;
            if (Session["CProfiles"].ToString() == "frmMainControl")
            {
               cmd.CommandText = "Select Id, Name, Description, Visibility,"
                    + " PeopleId, Status, Seq From Profiles"
                    + " Where Type=" + "'" + Session["ProfileType"].ToString() + "'"
                    + " Order by Seq, Name";
            }
            else if (Session["CProfiles"].ToString() == "frmMainProfileMgr")
            {
                {
                    cmd.CommandText = "Select Id, Name, Description, Visibility,"
                         + " PeopleId, Status, Seq From Profiles"
                         + " Where Type=" + "'" + Session["ProfileType"].ToString() + "'"
                         + " and PeopleId =" + "'" + Session["PeopleId"].ToString() + "'"
                         + " Order by Seq, Name";
                }
            }
            else
            {
                cmd.CommandText = "Select Id, Name, Description, Visibility,"
                        + " PeopleId, Status, Seq From Profiles"
                        + " Where Type = " + "'Consumer'"
                        + " Order by Seq, Name";
            }
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Profiles");
            if (ds.Tables["Profiles"].Rows.Count == 0)
            {
                if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                    DataGrid1.Visible = false;
                    lblContent1.Text = "Sorry.  You have not been designated to author any "
                    + Session["ProfileType"].ToString()
                    + " Profiles.  Please contact your system administrator.";
                }
            }

			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			refreshGrid();
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				Button bt = (Button) (i.Cells[5].FindControl ("btnServices"));
                TextBox tb = (TextBox)(i.Cells[10].FindControl("txtSeq"));
                
				if (Session["ProfileType"].ToString() == "Producer")
				{
					bt.Text="Services Provided";
				}
				else
				{
					bt.Text="Select";
				}

                if (Session["startForm"].ToString() == "frmMainControl")
                {
                    if (i.Cells[9].Text == "&nbsp;")
                    {
                        tb.Text = "99";
                    }
                    else tb.Text = i.Cells[9].Text;
                }
            }
        }
        private void updateGrid1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tb = (TextBox)(i.Cells[10].FindControl("txtSeq"));
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdateProfileSeqNo";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = i.Cells[0].Text;
                    cmd.Parameters.Add("@Seq", SqlDbType.Int);
                    cmd.Parameters["@Seq"].Value = Int32.Parse(tb.Text);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                updateGrid1();
            }
			Response.Redirect (strURL + "frmUpdProfiles.aspx?"
				+ "&btnAction=" + "Add");
		}
		private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Response.Redirect (strURL + "frmUpdProfiles.aspx?"
				+ "&btnAction=" + "Update"
				+ "&Id=" + e.Item.Cells[0].Text
				+ "&Name=" + e.Item.Cells[1].Text
				+ "&Desc=" + e.Item.Cells[2].Text
				+ "&Vis=" + e.Item.Cells[3].Text
				+ "&PeopleId=" + e.Item.Cells[6].Text
				+ "&Households=" + e.Item.Cells[7].Text
                + "&Status=" + e.Item.Cells[8].Text);
		}

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/*if (e.CommandName == "Events")
			{
				Session["CallerEvents"]="frmProfiles";
				Response.Redirect(strURL + "frmEvents.aspx?");
			}
			else */
			if (e.CommandName == "Services")
			{
                if (Session["ProfileType"] == "Consumer")
                {
                    Session["ProfilesId"] = e.Item.Cells[0].Text;
                    Session["ProfilesName"] = e.Item.Cells[1].Text;
                    Session["CServiceTypes"] = "frmProfiles";
                    Response.Redirect(strURL + "frmServiceTypes.aspx?");
                }
                else
                {
                    Session["CPSTypes"] = "frmProfiles";
                    Session["ProfilesId"] = e.Item.Cells[0].Text;
                    Session["ProfilesName"] = e.Item.Cells[1].Text;
                    Response.Redirect(strURL + "frmProfileServiceTypes.aspx?");
                }
			}

            else if (e.CommandName == "PRT")
            {
                Session["CPPTypes"] = "frmProfiles";
                Session["ProfilesId"] = e.Item.Cells[0].Text;
                Session["ProfilesName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmProfProjectTypes.aspx?");
            }
            else if (e.CommandName == "ProjTypes")
            {
                Session["CPPTypes"] = "frmProfiles";
                Session["ProfilesId"] = e.Item.Cells[0].Text;
                Session["ProfilesName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmProfProjectTypes.aspx?");
            }
            else if (e.CommandName == "Deliverables")
            {
                Session["CSEvents"] = "frmProfiles";
                Session["ProfilesId"] = e.Item.Cells[0].Text;
                Session["ProfileName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmServiceEvents.aspx?");
            }
            else if (e.CommandName == "Processes")
            {
                Session["CProcs"] = "frmProfiles";
                Session["ProfilesId"] = e.Item.Cells[0].Text;
                Session["ProfileName"] = e.Item.Cells[1].Text;
                Response.Redirect(strURL + "frmProcs.aspx?");
            }


		}		
		private void Delete(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_DeleteProfile";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id", SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			loadData();
		}
        private void rpts()
        {
            Session["cRG"] = "frmProfiles";
            Response.Redirect(strURL + "frmReportGen.aspx?");
        }

		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            if (Session["startForm"].ToString() == "frmMainControl")
            {
                updateGrid1();
            }
			Response.Redirect (strURL + Session["CProfiles"].ToString() + ".aspx?");
		}

		protected void btnSignoff_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmEnd.aspx?");
		}
        protected void btnRpt1_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfileId";
            discreteval.Value = Session["ProfilesId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProfileServiceProcs.rpt";
            rpts();

        }
        protected void btnRpt2_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Session["ProfilesId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProfileProcs.rpt";
            rpts();	
        }
        protected void btnRpt3_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Session["ProfilesId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptTORs.rpt";
            rpts();	
        }
        protected void btnRpt4_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Session["ProfilesId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProfResources.rpt";
            rpts();	
        }
        /*protected void btnRpt5_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();

            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Session["ProfilesId"].ToString();
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);

            ParameterField paramField1 = new ParameterField();
            ParameterDiscreteValue discreteval1 = new ParameterDiscreteValue();
            paramField1.ParameterFieldName = "CallerOpt";
            discreteval1.Value = Session["CallerOpt"].ToString();
            paramField1.CurrentValues.Add(discreteval1);
            paramFields.Add(paramField1);

            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptProfClients.rpt";
            rpts();	
        }*/

        protected void btnExit1_Click(object sender, EventArgs e)
        {
            Session["CallerOpt"] = null;
                lblContent1.Text = "Listed below are the business models for which you are the designated author."
                    + " Click on the button 'Services Provided' to the right of the appropriate business profile"
                    + " to review and edit the profile as needed.";
                DataGrid1.Visible = true;
                btnExit.Visible = true;
                btnExit1.Visible = false;
                lblProfileName.Text = "";
                lblReports1.Text = "";
                btnRpt1.Visible = false;
                btnRpt2.Visible = false;
                btnRpt3.Visible = false;
                btnRpt4.Visible = false;
                btnRpt6.Visible = false;
        }
        protected void btnRpt6_Click(object sender, EventArgs e)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField = new ParameterField();
            ParameterDiscreteValue discreteval = new ParameterDiscreteValue();
            paramField.ParameterFieldName = "ProfilesId";
            discreteval.Value = Int32.Parse(Session["ProfilesId"].ToString());
            paramField.CurrentValues.Add(discreteval);
            paramFields.Add(paramField);
            Session["ReportParameters"] = paramFields;
            Session["ReportName"] = "rptBIA.rpt";
            rpts();
        }
}

}
	