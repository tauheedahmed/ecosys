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
	/// Summary description for frmOrgResTypes1.
	/// </summary>
	public partial class frmTS : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);

        private int GetIndexOfMonth(string s)
        {
            return (lstMonth.Items.IndexOf(lstMonth.Items.FindByValue(s)));
        }	
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

		}
		#endregion
		private void loadForm()
		{			
			if (!IsPostBack)
			{
                lblOrg.Text  = Session["AptOrgName"].ToString();
                lblPerson.Text =Session["FName"].ToString() + " " + Session["LName"].ToString()
				+ " (Appointment Type: " + Session["StaffType"].ToString() + ")";
                GetMyMonthList(lstMonth, true);
				loadData();
				//loadContents();
			}
		}
        
		/*private void loadContents()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveTSProjects";
			cmd.Parameters.Add ("@StaffActionsId",SqlDbType.Int);
			cmd.Parameters["@StaffActionsId"].Value=Session["StaffActionsId"].ToString();
			cmd.Parameters.Add ("@ActPeriodsId",SqlDbType.Int);
			cmd.Parameters["@ActPeriodsId"].Value=Session["ActPeriodsId"].ToString();
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Connection=this.epsDbConn;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"updTSH");
			lblContents.Text=
			"Timesheet for the period starting " + ds.Tables["updTSH"].Rows[0][0].ToString()
				+ " and ending " + ds.Tables["updTSH"].Rows[0][0].ToString();
		}*/
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveTS";
				cmd.Connection=this.epsDbConn;				
				cmd.Parameters.Add ("@StaffActionsId",SqlDbType.Int);
				cmd.Parameters["@StaffActionsId"].Value=Int32.Parse(Session["StaffActionsId"].ToString());
                cmd.Parameters.Add("@YrMth", SqlDbType.Int);
                cmd.Parameters["@YrMth"].Value = Int32.Parse(lstMonth.SelectedItem.Value);
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"updTS");
				Session["ds"] = ds;
			if (ds.Tables["updTS"].Rows.Count ==0)
			{
				DataGrid1.Visible=false;
				//loadDataAll();
				lblContents.Text="Sorry.  Timesheet could not be generated.  Contact"
					+ " your system administrator.";
			}
			else
			{
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				assignValues();
			}

		}
		private void assignValues()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbHours = (TextBox)(i.Cells[5].FindControl("txtHours"));
				if (i.Cells[4].Text == "&nbsp;")
				{
					tbHours.Text = "";
				}
				else
				{
					tbHours.Text = i.Cells[4].Text;
				}
			}
		}
		protected void btnExit_Click(object sender, System.EventArgs e)
		{
            setMonth();
            updateGrid();
			Exit();
		}
        public void GetMyMonthList(DropDownList lstMonth, bool SetCurruntMonth)
        {
            DateTime month = Convert.ToDateTime(DateTime.Now.ToString());
            for (int i = 0; i < 3; i++)
            {
                DateTime NextMont = month.AddMonths(-i);

                ListItem list = new ListItem();
                list.Text = NextMont.ToString("Y");
                list.Value = NextMont.Year.ToString() + NextMont.Month.ToString();
                lstMonth.Items.Add(list);
            }
            if (SetCurruntMonth == true)
            {
                lstMonth.Items.FindByValue((DateTime.Now.Year.ToString()+DateTime.Now.Month.ToString())).Selected = true;
            }
        }
        private void setMonth()
        {
            Session["Munth"] = lstMonth.SelectedItem.Value;
        }
		private void updateGrid()
		{
            
			foreach (DataGridItem i in DataGrid1.Items)
			{
				TextBox tbHours = (TextBox)(i.Cells[5].FindControl("txtHours"));
				if (i.Cells[0].Text.StartsWith("&") == true)
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_UpdateTS";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add ("@StaffActionsId",SqlDbType.Int);
					cmd.Parameters["@StaffActionsId"].Value=Int32.Parse(Session["StaffActionsId"].ToString());
					cmd.Parameters.Add ("@ProcProcuresId",SqlDbType.Int);
					cmd.Parameters["@ProcProcuresId"].Value=Int32.Parse(i.Cells[7].Text);
					cmd.Parameters.Add ("@YrMth",SqlDbType.Int);
                    cmd.Parameters["@YrMth"].Value = Int32.Parse(lstMonth.SelectedItem.Value);
					cmd.Parameters.Add("@Hours", SqlDbType.Decimal);
					if (tbHours.Text != "")
					{
						cmd.Parameters ["@Hours"].Value=decimal.Parse(tbHours.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
					}
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
				else
				{
					SqlCommand cmd=new SqlCommand();
					cmd.CommandType=CommandType.StoredProcedure;
					cmd.CommandText="fms_UpdateTS";
					cmd.Connection=this.epsDbConn;
					cmd.Parameters.Add("@Hours", SqlDbType.Decimal);
					if (tbHours.Text != "")
					{
						cmd.Parameters ["@Hours"].Value=decimal.Parse(tbHours.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
					}
					cmd.Parameters.Add("@Id", SqlDbType.Int);
					cmd.Parameters ["@Id"].Value=Int32.Parse(i.Cells[0].Text);
					cmd.Connection.Open();
					cmd.ExecuteNonQuery();
					cmd.Connection.Close();
				}
			}
		}
		private void Exit()
		{		
			Response.Redirect (strURL + Session["CTS"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Exit();
		}
        protected void lstMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
}
}
