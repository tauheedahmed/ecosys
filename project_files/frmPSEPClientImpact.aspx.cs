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
	public partial class frmProfileSEPSRes : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack) 
			{	
                if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                {
                    lblProfilesName.Text = "Business Profile for: " + Session["ProfilesName"].ToString();
                    lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
                    lblDeliverableName.Text = "Deliverable: " + Session["EventsName"].ToString();
                    lblProfileName.Text = "Clients/Stakeholders: " + Session["ProfileName"].ToString();
                    lblContents1.Text = "You may now identify the various types of impacts for the client/stakeholder"
                       + " indicated above.";
                }
                else
                {
                    lblTitle.Text = "EcoSys:  Service Models";
                    lblContents1.Text = "You may now identify the various types of impacts for the client/stakeholder"
                       + " indicated above.";
                }
                
                lblProcessName.Text = "Process: " + Session["ProcessName"].ToString();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);

		}
		#endregion
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
            if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
            {
                cmd.CommandText = "wms_RetrievePSEPCImpact";
                cmd.Parameters.Add("@PSEPClientsId", SqlDbType.Int);
                cmd.Parameters["@PSEPClientsId"].Value = Session["PSEPClientsId"].ToString();
            }
            else if (Session["CPSEPC"].ToString() == "frmProcs")
            {
                cmd.CommandText = "wms_RetrieveProcCImpact";
                cmd.Parameters.Add("@ProcClientsId", SqlDbType.Int);
                cmd.Parameters["@ProcClientsId"].Value = Session["ProcClientsId"].ToString();
            }
            cmd.Connection = this.epsDbConn;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "PCImpact");
            Session["ds"] = ds;
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            assignValues();
            /*

			cmd.CommandText="eps_RetrieveProfileSEPSRes";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProfileSEPStepTypesId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSEPSRes");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignValues();*/
		}
		private void assignValues()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
				if (i.Cells[4].Text == "&nbsp;")
				{
					tbDesc.Text=null;
				}
				else
				{
					tbDesc.Text = i.Cells[4].Text;
				}
			}
		}
		private void updateGrid()
		{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
                    if (Session["CPSEPC"].ToString() == "frmProfileSEProcs") 
                    { 
                        cmd.CommandText="wms_UpdatePSEPCImpactDesc";
                    }
                    else
                    {
                        cmd.CommandText = "wms_UpdateProcCImpactDesc";
                        //lblContents1.Text = "Heah" + Int32.Parse(i.Cells[0].Text) + "PP" + tbDesc.Text;
                    }
					
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
					cmd.Parameters ["@Desc"].Value=tbDesc.Text;
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			updateGrid();
			Exit();
		}
		private void Exit()
		{
            Response.Redirect(strURL + Session["CPSEPCI"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                if (Session["CPSEPC"].ToString() == "frmProfileSEProcs")
                {
                    cmd.CommandText="wms_DeletePSEPClientImpact";
                }
                else if (Session["CPSEPC"].ToString() == "frmProcs")
                {
                    cmd.CommandText = "wms_DeleteProcClientImpact";
                }
				
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
			updateGrid();
			Session["CallerRTA"]="frmProfileSEPSRes";
			Response.Redirect (strURL + "frmResourceTypesAll.aspx?");
		}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            updateGrid();
            Session["CEventsAll"] = "frmPSEPClientImpact";
            Response.Redirect(strURL + "frmEventsAll.aspx?");

        }
}

}