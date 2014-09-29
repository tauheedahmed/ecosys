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
	public partial class frmPSEPRes : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (Session["RType"].ToString() == "0")	
			{
				DataGrid1.Columns[1].HeaderText = "Other Resources";
				lblContents1.Text=
					"Identify the various types of "
					+ " other resources"
					+ " that would be needed"
					+ " to carry out process '"
					+ Session["ProcessName"].ToString()+ ".";
                btnAdd.Text = "Add New Goods and Other Resources";
			}
			else
			{
				DataGrid1.Columns[1].HeaderText = "Services";
				lblContents1.Text=
					"Identify the various types of "
					+ " services"
					+ " that would be needed"
					+ " to carry out process '"
					+ Session["ProcessName"].ToString()+ ".";
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
			cmd.Connection=this.epsDbConn;
            if (Session["CPSEPRes"].ToString() == "frmProcs")
            {
                cmd.CommandText = "wms_RetrievePSEPRes";
                cmd.Parameters.Add("@ProcsId", SqlDbType.Int);
                cmd.Parameters["@ProcsId"].Value = Session["ProcsId"].ToString();
            }
            else
            {
                /*cmd.CommandText="wms_RetrievePSEPRes";
                 * cmd.Parameters.Add("@PSEPID", SqlDbType.Int);
                cmd.Parameters["@PSEPID"].Value = Session["PSEPID"].ToString();*/
                //Above part de-activated since frmProfileSEProcs (the other place from where it can be logically called) 
                //has not been provided options to select inputs independant of Procs
            }
			cmd.Parameters.Add ("@RType",SqlDbType.Int);
			cmd.Parameters["@RType"].Value=Session["RType"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"ProfileSEPSRes");
			Session["ds"] = ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();
			assignValues();
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
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "wms_UpdatePSEPResDesc";
                    cmd.Connection = this.epsDbConn;
                    cmd.Parameters.Add("@Desc", SqlDbType.VarChar);
                    cmd.Parameters["@Desc"].Value = tbDesc.Text;
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = Int32.Parse(i.Cells[0].Text);
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
			Response.Redirect (strURL + Session["CPSEPRes"].ToString() + ".aspx?");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Remove")
			{
				updateGrid();
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_DeletePSEPRes";
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
			Session["CallerRTA"]="frmPSEPRes";
			Response.Redirect (strURL + "frmResourceTypesAll.aspx?");
		}

	}

}