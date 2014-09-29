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
	public partial class frmProcs : System.Web.UI.Page
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
            lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
            
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                if (Session["Section"].ToString() == "I")
                {
                lblContents2.Text = 
                    "The various processes normally associated with"
                    + " the service above that are authored by you are listed below"
                + "Click on the appropriate"
                    + " button to update a given process or to add/remove processes.";
                }
                else
                {
                    lblContents2.Text = 
                    "The various business processes normally associated with"
                        + " the service above"
                        + " are listed below.  Click on the appropriate"
                        + " button to update a given process or to add/remove processes.";
                }
            }
            Session["TableFlag"] = 1;
			if (!IsPostBack) 
			{	
				loadData();
			}
		}
		private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProcs";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@ServiceTypesId",SqlDbType.Int);
			cmd.Parameters["@ServiceTypesId"].Value=Session["ServicesId"].ToString();
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {
                cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
                cmd.Parameters["@PeopleId"].Value = Session["PeopleId"].ToString();
            }
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procs");
            if (ds.Tables["Procs"].Rows.Count == 0)
            {
                lblContents2.Text =
                        "You may now author procedures related to the service '"
                        + Session["ServiceName"].ToString()
                        + "'. Click on the "
                        + " button titled 'Add a Process' to create your first process related to this service.";
            }
            else
            {

                Session["ds"] = ds;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
                updateProcs();
            }
         
		}
        private void updateProcs()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "wms_UpdateProcFlags";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = i.Cells[0].Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
		protected void btnAdd_Click(object sender, System.EventArgs e)
		{
			Session["btnAction"]="Add";
			Session["CUPSEP"]="frmProcs";
			Response.Redirect (strURL + "frmUpdProcs.aspx?");
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
		private void Exit()
		{
			Response.Redirect (strURL + Session["CProcs"].ToString() + ".aspx?");
		}
		
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            Session["ProcessName"] = e.Item.Cells[1].Text;
            Session["ProcsId"] = e.Item.Cells[0].Text;
			if (e.CommandName == "Update")
			{
				Session["CUPSEP"]="frmProcs";
				Session["btnAction"]="Update";
				Session["Id"]=e.Item.Cells[0].Text;
				Response.Redirect (strURL + "frmUpdProcs.aspx?");
	
			}
            
			else if (e.CommandName == "Staff")
			{
				Session["CPSEPStaff"]="frmProcs";
				Response.Redirect (strURL + "frmPSEPStaff.aspx?");	
			}

			else if (e.CommandName == "Services")
			{
				Session["CPSEPRes"]="frmProcs";
				Session["RType"]=1;
				Response.Redirect (strURL + "frmPSEPRes.aspx?");
				//Response.Redirect (strURL + "frmPSEPSer.aspx?");
	
			}
			else if (e.CommandName == "Other")
			{
				Session["CPSEPRes"]="frmProcs";
				Session["RType"]=0;
				Response.Redirect (strURL + "frmPSEPRes.aspx?");
	
			}
            else if (e.CommandName == "OServices")
            {
                Session["CPSEPO"] = "frmProcs";
                Session["RType"] = 1;
                Response.Redirect(strURL + "frmPSEPO.aspx?");

            }
            else if (e.CommandName == "OOther")
            {
                Session["CPSEPO"] = "frmProcs";
                Session["RType"] = 0;
                Response.Redirect(strURL + "frmPSEPO.aspx?");

            }
            else if (e.CommandName == "Clients")
            {
                Session["CPSEPC"] = "frmProcs";
                Response.Redirect(strURL + "frmPSEPClient.aspx?");

            }
			else if (e.CommandName == "Steps")
			{
				Session["CPSEPSteps"]="frmProcs";
				Response.Redirect (strURL + "frmPSEPSteps.aspx?");
			}
			else if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeleteProcs";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=e.Item.Cells[0].Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}

		private void btnSignoff_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmEnd.aspx?");
		}
		
	}

}
	