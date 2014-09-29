using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmUpdProjProcure : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int BOLocsId;
		private int b=0;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update")
			{
				Id=Session["ProjProcureId"].ToString();
			}
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				getQtyMeasure();
				btnAction.Text= Session["btnAction"].ToString();
				if (Session["btnAction"].ToString() == "Update")
				{
					loadData();
					//loadGrid();
				}
				else
				{
					//BOLocsId=0;
					//loadGrid();
				}
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

		}
		#endregion
	
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveProjProcure";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProjProcureId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procure");			
			txtDesc.Text=ds.Tables["Procure"].Rows[0][0].ToString();
			txtQty.Text=ds.Tables["Procure"].Rows[0][1].ToString();
			BOLocsId=Int32.Parse(ds.Tables["Procure"].Rows[0][2].ToString());
		}
		/*private void loadGrid()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveBOLocDetails";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@LocId",SqlDbType.Int);
			cmd.Parameters["@LocId"].Value=Session["LocId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"BudOrgs");
			if (ds.Tables["BudOrgs"].Rows.Count == 0)
			{
				lblContent1.Text="Warning.  There is no budget available for this location.";
				DataGrid1.Visible=false;
			}
			else
			{
				Session["ds"] = ds;
				DataGrid1.DataSource=ds;
				DataGrid1.DataBind();
				refreshGrid();
			}
		}
		private void refreshGrid()
		{
			foreach (DataGridItem i in DataGrid1.Items)
			{
				CheckBox cb = (CheckBox)(i.Cells[7].FindControl("cbxSel"));
				if (i.Cells[8].Text == "1")
				{
					i.Cells[6].Text="Open";
				}
				else
				{
					i.Cells[6].Text="Close";
				}
				if (i.Cells[0].Text==BOLocsId.ToString())
				{
					cb.Checked=true;
				}
			}
		}
			private void checkGrid()
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					CheckBox cb = (CheckBox)(i.Cells[7].FindControl("cbxSel"));
					if (cb.Checked)
					{
						a=++a;
						b=Int32.Parse(i.Cells[0].Text);
					}
				}
				if (a>1)
				{
					lblContent1.Text="Please Select only One budget to be charged.";
				}
				else updateGrid();
			}*/
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			//a=0;
			//b=0;
			//checkGrid();
			updateGrid();
		}
		private void updateGrid()
		{
			if (btnAction.Text == "Update") 
			{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_UpdateProjProcure";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProjProcureId"].ToString();
			cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
			cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@BOLocsId",SqlDbType.Int);
				cmd.Parameters["@BOLocsId"].Value=b;
			if (txtQty.Text != "")
			{
				cmd.Parameters.Add ("@Qty",SqlDbType.Decimal);
				cmd.Parameters["@Qty"].Value=Decimal.Parse(txtQty.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
			}
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			Done();
		}
		else if (btnAction.Text == "Add")
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_AddProjProcure";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
			cmd.Parameters["@Desc"].Value= txtDesc.Text;
			cmd.Parameters.Add ("@PSEPSerId",SqlDbType.Int);
			cmd.Parameters["@PSEPSerId"].Value=Session["PSEPSerId"].ToString();
			cmd.Parameters.Add ("@BOLocsId",SqlDbType.Int);
			cmd.Parameters["@BOLocsId"].Value=b;
			cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
			cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
			cmd.Parameters.Add ("@ProjectId",SqlDbType.Int);
			cmd.Parameters["@ProjectId"].Value=Session["ProjectId"].ToString();
			if (txtQty.Text != "")
			{
				cmd.Parameters.Add ("@Qty",SqlDbType.Decimal);
				cmd.Parameters["@Qty"].Value=Decimal.Parse(txtQty.Text, System.Globalization.NumberStyles.AllowDecimalPoint|System.Globalization.NumberStyles.AllowThousands);
			}
			cmd.Parameters.Add("@SGFlag",SqlDbType.Int);
			cmd.Parameters["@SGFlag"].Value=Session["SGFlag"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			Done();
		}
	}

		private void getQtyMeasure()
		{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_RetrieveQtyMName";
			cmd.Parameters.Add("@Id",SqlDbType.Int);
				if (Session["SGFlag"].ToString() == "0")
				{
					cmd.Parameters["@Id"].Value=Session["ServiceTypesId"].ToString();	
				}
				else
				{
					cmd.Parameters["@Id"].Value=Session["ResTypesId"].ToString();
				}
				cmd.Parameters.Add("@SGFlag",SqlDbType.Int);
				cmd.Parameters["@SGFlag"].Value=Session["SGFlag"].ToString();
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter (cmd);
				da.Fill(ds,"QtyMeasure");
				lblQtyMeasure.Text=ds.Tables["QtyMeasure"].Rows[0][0].ToString();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdProjProcure"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}
}

	
