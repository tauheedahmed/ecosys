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
	/// Summary description for frmAsses.
	/// </summary>
	public partial class frmAssessSelect : System.Web.UI.Page
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
			Load_Form();
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
		private void Load_Form()
		{
            if (Session["CPSEPO"].ToString() == "frmBudOrgsD")
            {
                lblProcessName.Text = "Budget: " + Session["BudName"].ToString();
                lblOrg.Text = Session["BDOrgName"].ToString();
            }
            else
            {
                lblProcessName.Text = "Process: " + Session["ProcessName"].ToString();
            }
            if (Session["startForm"].ToString() == "frmMainProfileMgr")
            {  
                if (Session["Section"].ToString() == "I")
                {
                    DataGrid1.Columns[2].Visible = false;//Desc
                    DataGrid1.Columns[3].Visible = false;//Qty
                    DataGrid1.Columns[4].Visible = false;//Unit of Measure
                    if (Session["RType"].ToString() == "0")
                    {
                        DataGrid1.Columns[1].HeaderText = "Goods and Other Resources";
                        lblContents1.Text = "Listed below are goods and other types are resources that are outputs of the above process.";
                    }
                    else
                    {
                        DataGrid1.Columns[1].HeaderText = "Services";
                        lblContents1.Text = "Listed below are the services that are outputs of the above process.";
                    }
                }
                else
                    {
                        if (Session["RType"].ToString() == "0")
                        {
                            DataGrid1.Columns[1].HeaderText = "Goods and Other Resources";
                            lblContents1.Text = "Listed below are goods and other types are resources that are outputs of the above process.";
                        }
                   else
                        {
                            DataGrid1.Columns[1].HeaderText = "Services";
                            lblContents1.Text = "Listed below are the services that are outputs of the above process.";
                        }
                        DataGrid1.Columns[3].Visible = false;
                        DataGrid1.Columns[4].Visible = false;
                    }
            }
            else if (Session["startForm"].ToString() == "frmMainWP")
            {
                lblContents1.Text = "Listed below are goods and services that are outputs of the above process.";
                btnAdd.Visible = false;
                DataGrid1.Columns[2].Visible = false;
            }
            else if ((Session["startForm"].ToString() == "frmMainBMgr") ||
                    (Session["startForm"].ToString() == "frmMainMgr"))
            {
                lblContents1.Text = "Listed below are goods and services that are outputs of the above budget.";
                btnAdd.Visible = true;
                //DataGrid1.Columns[2].Visible = false;
            }
            lblContents2.Text = "";
            lblContents3.Text = "";

			if (!IsPostBack)
			{
				loadData();
			}	
		}
		private void loadData()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                cmd.Connection=this.epsDbConn;
                if (Session["CPSEPO"].ToString() == "frmBudOrgsD")
                {
                    cmd.CommandText = "wms_RetrieveBOOutputs";
                    cmd.Parameters.Add("@BudOrgsId", SqlDbType.Int);
                    cmd.Parameters["@BudOrgsId"].Value = Int32.Parse(Session["BDOId"].ToString());
                }
                else
                {
                    if (Session["CPSEPO"].ToString() == "frmProcs")
                    {
                        cmd.CommandText = "wms_RetrieveProcResTypesO";
                        cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                        cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
                    }
                    else if (Session["CPSEPO"].ToString() == "frmOrgLocSEProcs")
                    {
                        cmd.CommandText = "[wms_RetrievePSEPO]";
                        cmd.Parameters.Add("@PSEPID", SqlDbType.Int);
                        cmd.Parameters["@PSEPID"].Value = Session["PSEPID"].ToString();
                    }
                }
                if (Session["startForm"].ToString() == "frmMainProfileMgr")
                {
                   // cmd.CommandText = "wms_RetrieveProcResTypesO";
                        
                    cmd.Parameters.Add("@RType", SqlDbType.Int);
                    cmd.Parameters["@RType"].Value = Session["RType"].ToString();
                }
                DataSet ds = new DataSet();
				SqlDataAdapter da=new SqlDataAdapter(cmd);
				da.Fill(ds,"PSEPO");
                if (ds.Tables["PSEPO"].Rows.Count == 0)
                { 
                    DataGrid1.Visible = false;
                    lblContents1.Text = "No outputs for this process have been identified as yet.";
                }
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
                if ((Session["startForm"].ToString() == "frmMainBMgr")||
                    (Session["startForm"].ToString() == "frmMainMgr"))
                {
                    assignValues1();
                }
                else if (Session["startForm"].ToString() == "frmMainWP")
                {
                    assignValues1();
                }
                else if (Session["CPSEPO"].ToString() == "frmProcs")
                {
                    assignValues3();
                }
		}
        private void assignValues1()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbQty = (TextBox)(i.Cells[3].FindControl("txtQty"));
                TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
                if (i.Cells[5].Text == "&nbsp;")
                {
                    tbQty.Text = "";
                }
                else
                {
                    tbQty.Text = i.Cells[5].Text;
                }
                if (i.Cells[7].Text == "&nbsp;")
                {
                    tbDesc.Text = "";
                }
                else
                {
                    tbDesc.Text = i.Cells[7].Text;
                }
            }
        }
        private void assignValues3()
        {
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbQty = (TextBox)(i.Cells[3].FindControl("txtQty"));
                if (i.Cells[5].Text == "&nbsp;")
                {
                    tbQty.Text = "";
                }
                else
                {
                    tbQty.Text = i.Cells[5].Text;
                }
                
            }
        }
       

		/*private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[2].FindControl("ckbSel"));
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select * from AssessOrg Where AssessId = " + i.Cells[0].Text
					+ " and OrgId = " + Session["OrgId"].ToString();
				cmd.Connection.Open();
				if (cmd.ExecuteScalar() != null) cb.Checked = true;
				cmd.Connection.Close(); 
				
			}
		}*/
		
        private void updateGrid1()
        {
            
            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbQty = (TextBox)(i.Cells[8].FindControl("txtQty"));
                if (i.Cells[5].Text.StartsWith("&") == true)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_updateOLSEPOutputQty";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@PSEPResOutputsId", SqlDbType.Int);
                    cmd.Parameters["@PSEPResOutputsId"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal);
                    if (tbQty.Text != "")
                    {
                        cmd.Parameters["@Qty"].Value = decimal.Parse(tbQty.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    }

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_updateOLSEPOutputQty";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Qty", SqlDbType.Decimal);
                    if (tbQty.Text != "")
                    {
                        cmd.Parameters["@Qty"].Value = decimal.Parse(tbQty.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                    }
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[5].Text);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
        private void updateGrid2()
        {

            foreach (DataGridItem i in DataGrid1.Items)
            {
                TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdateProcOutputDesc";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                    cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                    if (tbDesc.Text != "")
                    {
                        cmd.Parameters["@Desc"].Value = tbDesc.Text;
                    }

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }
        private void updateGrid3()
        {


            {
                foreach (DataGridItem i in DataGrid1.Items)
                {
                    TextBox tbDesc = (TextBox)(i.Cells[2].FindControl("txtDesc"));
                    TextBox tbQty = (TextBox)(i.Cells[4].FindControl("txtQty"));
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "wms_UpdateBudOrgsOutputsDesc";
                        cmd.Connection = this.epsDbConn;
                        cmd.Parameters.Add("@Id", SqlDbType.Int);
                        cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
                        cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                        if (tbDesc.Text != "")
                        {
                            cmd.Parameters["@Desc"].Value = tbDesc.Text;
                        }
                        cmd.Parameters.Add("@Qty", SqlDbType.Decimal);
                        if (tbQty.Text != "")
                        {
                            cmd.Parameters["@Qty"].Value = decimal.Parse(tbQty.Text, System.Globalization.NumberStyles.AllowDecimalPoint | System.Globalization.NumberStyles.AllowThousands);
                        }

                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }
                /*}
                catch
                {
                    lblContents1.Text = "Please enter Quantity as numbers only.";
                }*/
            }
        }
		protected void Exit(object sender, System.EventArgs e)
		{
            Response.Redirect(strURL + Session["CPSEPO"].ToString() + ".aspx?");
		
		}

		protected void Exit()
		{
            Response.Redirect(strURL + Session["CPSEPO"].ToString() + ".aspx?");
		}
        protected void btnExit_Click(object sender, EventArgs e)
        {
            if ((Session["startForm"].ToString() == "frmMainBMgr") ||
                    (Session["startForm"].ToString() == "frmMainMgr"))
            {
                updateGrid3();
            }
            if (Session["startForm"].ToString() == "frmMainWP")
            {
                updateGrid1();
            }
            else if (Session["CPSEPO"].ToString() == "frmProcs")
            {
                updateGrid2();
            }
            Response.Redirect(strURL + Session["CPSEPO"].ToString() + ".aspx?");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Session["CallerRTA"] = "frmPSEPO";
            Response.Redirect(strURL + "frmResourceTypesAll.aspx?");
        }
        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
                if (Session["CPSEPO"].ToString() == "frmBudOrgsD")
                {
                    cmd.CommandText = "wms_DeleteBOOutputs";
                }
                else if (Session["CPSEPO"].ToString() == "frmProcs")
                {
                    cmd.CommandText = "wms_DeleteProcResOutputs";
                }
                else
                {
                    cmd.CommandText = "wms_DeletePSEPResOutputs";
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
}
}
