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
	public partial class frmMainStaff : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		protected System.Web.UI.WebControls.Button btnAddTemp;
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.processCommand);

		}
		#endregion
		private void Load_Procedures()
		{	
			//lblOrg.Text=Session["OrgName"].ToString();
			//I=I+1;
			if (!IsPostBack) 
			{	
				//I=I+1;
                lblOrg.Text = "Note:  The User Id used to access this webpage has been issued by " 
                    + Session["OrgName"].ToString();

				getPeopleId();
				getTRSFlag();
				getEPSFlag();
				lblPerson.Text=
					Session["FName"].ToString() + " " + Session["LName"].ToString();
				if (Session["TRS"].ToString() != "1")
					{
						btnTS.Visible=false;
					}
				else
					{
						{
							btnTS.Visible=true;
						}
					
					}
				if (Session["EPS"].ToString() != "1")
					{
						btnHH.Visible=false;
					} 
                loadData();
            DataGrid1.Visible = true;
			}
           
		}
        private void loadData ()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveOrgLocationsInd";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@PeopleId",SqlDbType.Int);
			cmd.Parameters["@PeopleId"].Value=Session["PeopleId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Locs");
			if (ds.Tables["Locs"].Rows.Count == 0)
			{
				DataGrid1.Visible=false;
				lblContents.Text="Welcome " 
					+ Session["FName"].ToString() 
					+ ".  To continue, please click on the appropriate button below ";
                btnTS.Visible = false;
			}
			else 
			{
                lblContents.Text = "Welcome "
                    + Session["FName"].ToString()
                    + ".  The various tasks to which you have been assigned are listed below.  To continue, please click on the appropriate button below ";
			}
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
	}
		private void getTRSFlag()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsTRS";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"TRS");
			if (ds.Tables["TRS"].Rows[0][0].ToString() == "0")
			{
				Session["TRS"]= 0;
			}
			else
			{
				Session["TRS"]= 1;
			}
		}
		private void getEPSFlag()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveOrgFlagsEPS";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"EPS");
			if (ds.Tables["EPS"].Rows[0][0].ToString() == "0")
			{
				Session["EPS"]= 0;
			}
			else
			{
				Session["EPS"]= 1;
			}
		}
		private void getPeopleId()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "ams_RetrieveUserIdName";
			cmd.Parameters.Add ("@UserId",SqlDbType.NVarChar);
			cmd.Parameters["@UserId"].Value=Session["UserId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"UserPerson");
			Session["PeopleId"] = ds.Tables["UserPerson"].Rows[0][0];
			Session["LName"] = ds.Tables["UserPerson"].Rows[0][1];
			Session["Fname"] = ds.Tables["UserPerson"].Rows[0][2];
			Session["CellPhone"] = ds.Tables["UserPerson"].Rows[0][3];
			Session["HomePhone"] = ds.Tables["UserPerson"].Rows[0][4];
			Session["WorkPhone"] = ds.Tables["UserPerson"].Rows[0][5];
			Session["Address"] = ds.Tables["UserPerson"].Rows[0][6];
			Session["Email"] = ds.Tables["UserPerson"].Rows[0][7];
			Session["Vis"] = ds.Tables["UserPerson"].Rows[0][8];
			txtCPhone.Text=Session["CellPhone"].ToString();
			txtHPhone.Text=Session["HomePhone"].ToString();
			txtWPhone.Text=Session["WorkPhone"].ToString();
			txtEmail.Text=Session["Email"].ToString();
		}
		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Select")
			{
				try
				{
					Session["CPSEInd"]="frmMainStaff";
					Session["OrgLocId"]=e.Item.Cells[0].Text;
					Session["MgrName"]=e.Item.Cells[1].Text;
					Session["LocationName"]=e.Item.Cells[2].Text;
					Session["ServiceName"]=e.Item.Cells[3].Text;
					Session["EventName"]=e.Item.Cells[4].Text;
					Session["ProfileId"]=e.Item.Cells[6].Text;
					Session["PSEventsId"]=e.Item.Cells[7].Text;
					Session["PJName"]=e.Item.Cells[8].Text;
					Session["PJNameS"]=e.Item.Cells[9].Text;
					
					Response.Redirect (strURL + "frmPSEventsInd.aspx?");
					
				}
				catch (SqlException err)
				{
					if (err.Message.StartsWith ("Object reference not set")) 
						Response.Redirect (strURL + "frmStart.aspx?");
					else lblContents.Text = err.Message;
				}			
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            Response.Redirect(strURL + "frmStart.aspx?");
		}


		protected void btnTS_Click(object sender, System.EventArgs e)
		{
			Session["CSAI"]="frmMainStaff";
			Response.Redirect (strURL + "frmStaffActionsInd.aspx?");
		}

		protected void btnHH_Click(object sender, System.EventArgs e)
		{
            Session["CHH"] = "frmMainStaff";
			Response.Redirect(strURL + "frmMainHH.aspx?");
		}

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            lblHead.Text = "Update Profile";
            lblContents.Visible = false;
            btnExit.Visible = false;
            btnProfile.Visible = false;
            btnHH.Visible = false;
            btnTS.Visible = false;
            btnUProfile.Visible = true;
            btnCProfile.Visible = true;
            DataGrid1.Visible = false;
            txtCPhone.Visible = true;
            txtHPhone.Visible = true;
            txtWPhone.Visible = true;
            txtEmail.Visible = true;
            lblCPhone.Visible = true;
            lblHPhone.Visible = true;
            lblWPhone.Visible = true;
            lblEmail.Visible = true;	
        }
        protected void btnUProfile_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "eps_UpdatePeople";
            cmd.Connection = this.epsDbConn;
            cmd.Parameters.Add("@PeopleId", SqlDbType.Int);
            cmd.Parameters["@PeopleId"].Value = Session["PeopleId"].ToString();
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
            cmd.Parameters["@Email"].Value = txtEmail.Text;
            cmd.Parameters.Add("@HPhone", SqlDbType.NVarChar);
            cmd.Parameters["@Hphone"].Value = txtHPhone.Text;
            cmd.Parameters.Add("@WPhone", SqlDbType.NVarChar);
            cmd.Parameters["@Wphone"].Value = txtWPhone.Text;
            cmd.Parameters.Add("@CPhone", SqlDbType.NVarChar);
            cmd.Parameters["@Cphone"].Value = txtCPhone.Text;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            profileEnd();
        }
        private void profileEnd()
        {
            lblHead.Text = "Dashboard";
            lblContents.Visible = true;
            btnExit.Visible = true;
            btnProfile.Visible = true;
            btnHH.Visible = true;
            btnTS.Visible = true;
            btnUProfile.Visible = false;
            btnCProfile.Visible = false;
            DataGrid1.Visible = true;
            txtCPhone.Visible = false;
            txtHPhone.Visible = false;
            txtWPhone.Visible = false;
            txtEmail.Visible = false;
            lblCPhone.Visible = false;
            lblHPhone.Visible = false;
            lblWPhone.Visible = false;
            lblEmail.Visible = false;
        }
        protected void btnCProfile_Click(object sender, EventArgs e)
        {
            profileEnd();
        }
        protected void btnWP_Click(object sender, EventArgs e)
        {
            loadData();
            DataGrid1.Visible = true;
        }
        
       
}

}
	