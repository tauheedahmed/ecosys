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
	/// Summary description for frmResourcesInfo.
	/// </summary>
	public partial class frmOLPSEPSSPeople: System.Web.UI.Page
	{
		/*SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
            lblTitle.Text = "EcoSys:  Individual/Household Models";
            lblBusProfiles.Text = "Individual/Household:  " + Session["ProfilesName"].ToString();
           lblServiceName.Text = "Service Delivered: " + Session["ServiceName"].ToString();
           lblEventName.Text = "Type of Event: " + Session["EventsName"].ToString();
            if (!IsPostBack)
            {
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
        private void loadData()
        {
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
            cmd.CommandText = "wms_RetrievePSEResDesc";
            cmd.Parameters.Add("@ProfilesId", SqlDbType.Int);
            cmd.Parameters["@ProfilesId"].Value = Session["ProfilesId"].ToString();
            cmd.Parameters.Add("@EventsId", SqlDbType.Int);
            cmd.Parameters["@EventsId"].Value = Session["EventsId"].ToString();
            cmd.Parameters.Add("@ServiceTypesId", SqlDbType.Int);
            cmd.Parameters["@ServiceTypesId"].Value = Session["ServicesId"].ToString();
            cmd.Parameters.Add("@RType", SqlDbType.Int);
            cmd.Parameters["@RType"].Value = Session["RType"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"PSR");
            if (ds.Tables["PSR"].Rows.Count == 0)
            {
                DataGrid1.Visible = false;
            }
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignValuesDesc();
            assignValuesLoc();
		}
        private void assignValuesDesc()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbDesc = (TextBox)(i.Cells[3].FindControl("txtDesc"));
                if (i.Cells[5].Text == "&nbsp;")
                {
                    tbDesc.Text = null;
                }
                else
                {
                    tbDesc.Text = i.Cells[5].Text;
                }
            }
        }
        private void assignValuesLoc()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                DropDownList lsLoc = (DropDownList)(i.Cells[1].FindControl("lstLoc"));
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = this.epsDbConn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Id, Name from LocTypes";
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "LocTypes");
                    lsLoc.DataSource = ds;
                    lsLoc.DataMember = "LocTypes";
                    lsLoc.DataTextField = "Name";
                    lsLoc.DataValueField = "Id";
                    lsLoc.DataBind();
                if (i.Cells[6].Text == "&nbsp;")
                {
                    lsLoc.SelectedIndex = 0;
                }
                else
                {
                    
                    lsLoc.SelectedIndex = lsLoc.Items.IndexOf (lsLoc.Items.FindByValue(i.Cells[6].Text));
                }
            }
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            updateGrid();
            Exit();
        }
        private void updateGrid()
        {
           foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbDesc = (TextBox)(i.Cells[3].FindControl("txtDesc"));
                DropDownList lsLoc = (DropDownList)(i.Cells[3].FindControl("lstLoc"));
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "wms_UpdatePSEResourcesDesc";
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@LocTypesId", SqlDbType.Int);
                cmd.Parameters["@LocTypesId"].Value = Int32.Parse(lsLoc.SelectedItem.Value);
                cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
                cmd.Parameters["@Desc"].Value = tbDesc.Text;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }
        private void Exit()
        {
            Response.Redirect(strURL + Session["CPSEResources"].ToString() + ".aspx?");
        }
        
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            updateGrid();
            Session["TableFlag"] = "1";
            Session["CallerRTA"] = "frmPSEResources";
            Response.Redirect(strURL + "frmResourceTypesAll.aspx?");
        }
        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "wms_DeletePSEResources";//eps_DeleteSkillCourses
                cmd.Connection = this.epsDbConn;
                cmd.Parameters.Add("@Id", SqlDbType.Int);
                cmd.Parameters["@Id"].Value = e.Item.Cells[0].Text;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                loadData();
            }
        }
}

}

