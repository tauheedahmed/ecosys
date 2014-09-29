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
	public partial class frmUpdProcProcure : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int BOLocsId;
		int a, b;
		/*private int GetIndexOfStatus (string s)
		{
			return (rblStatus.Items.IndexOf (rblStatus.Items.FindByValue(s)));
		}
		private int GetIndexOflstResourceTypes (string s)
		{
			return (lstResourceTypes.Items.IndexOf (lstResourceTypes.Items.FindByValue(s)));
		}*/
		/*private int GetIndexOflstResourceTypes (string s)GetIndexOflstResourceTypes
		{
			return (lstResourceTypes.Items.IndexOf (lstResourceTypes.Items.FindByValue(s)));
		}*/
		/*private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
		private int GetIndexOfProcMethods (string s)
		{
			return (rblProcMethods.Items.IndexOf (rblProcMethods.Items.FindByValue(s)));
		}
		private int GetIndexOfPayTerms (string s)
		{
			return (rblPayTerms.Items.IndexOf (rblPayTerms.Items.FindByValue(s)));
		}*/
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["btnAction"].ToString() == "Update")
			{
				Id=Session["ProcProcureId"].ToString();
			}
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				getQtyMeasure();
				btnAction.Text= Session["btnAction"].ToString();
				if (Session["btnAction"].ToString() == "Update")
				{
					loadData();
					loadGrid();
				}
				else
				{
					BOLocsId=0;
					loadGrid();
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
			cmd.CommandText="fms_RetrieveProcProcure";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ProcProcureId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Procure");
			//txtName.Text=ds.Tables["Procure"].Rows[0][1].ToString();				
			txtDesc.Text=ds.Tables["Procure"].Rows[0][0].ToString();
			/*lstLocations.SelectedIndex=
				GetIndexOfLocs(ds.Tables["Procure"].Rows[0][3].ToString());
			lstResourceTypes.SelectedIndex = 
				GetIndexOflstResourceTypes(ds.Tables["Procure"].Rows[0][4].ToString());
			rblStatus.SelectedIndex = GetIndexOfStatus (ds.Tables["Procure"].Rows[0][5].ToString());
			rblPayTerms.SelectedIndex = GetIndexOfPayTerms (ds.Tables["Procure"].Rows[0][8].ToString());
			rblProcMethods.SelectedIndex = GetIndexOfProcMethods (ds.Tables["Procure"].Rows[0][9].ToString());*/
			txtQty.Text=ds.Tables["Procure"].Rows[0][1].ToString();
			BOLocsId=Int32.Parse(ds.Tables["Procure"].Rows[0][2].ToString());

		}
		private void loadGrid()
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
		/*private void loadResTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveResourceTypes";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ResourceTypes");
			lstResourceTypes.DataSource = ds;			
			lstResourceTypes.DataMember= "ResourceTypes";
			lstResourceTypes.DataTextField = "ResTypeName";
			lstResourceTypes.DataValueField = "ResTypeId";
			lstResourceTypes.DataBind();
		}
		private void loadLocs()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveLocations";
			cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Locations");
			lstLocations.DataSource = ds;			
			lstLocations.DataMember= "Locations";
			lstLocations.DataTextField = "Name";
			lstLocations.DataValueField = "Id";
			lstLocations.DataBind();
		}
		private void loadStatus()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveProcurementStatus";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ProcurementStatus");
			rblStatus.DataSource = ds;			
			rblStatus.DataMember= "ProcurementStatus";
			rblStatus.DataTextField = "Name";
			rblStatus.DataValueField = "Id";
			rblStatus.DataBind();
		}

		private void loadPayTerms()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrievePayTerms";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"PaymentTerms");
			rblPayTerms.DataSource = ds;			
			rblPayTerms.DataMember= "PaymentTerms";
			rblPayTerms.DataTextField = "Name";
			rblPayTerms.DataValueField = "Id";
			rblPayTerms.DataBind();
		}
		private void loadProcMethods()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProcMethods";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ProcurementMethods");
			rblProcMethods.DataSource = ds;			
			rblProcMethods.DataMember= "ProcurementMethods";
			rblProcMethods.DataTextField = "Name";
			rblProcMethods.DataValueField = "Id";
			rblProcMethods.DataBind();
		}*/
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
				lblContent1.Text="Please Select only one budget to be charged.";
					//+ " a=" + a.ToString() + " b=" + b.ToString();
			}
			else updateGrid();//lblContent1.Text="Please Selected only One budget to be charged."
						//+ " a=" + a.ToString() + " b=" + b.ToString();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			
			a=0;
			b=0;
			checkGrid();
		}
		private void updateGrid()
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateProcProcure";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ProcProcureId"].ToString();//Int32.Parse(Id);
				/*cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;*/
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@BOLocsId",SqlDbType.Int);
				cmd.Parameters["@BOLocsId"].Value=b;
				/*cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=rblStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PayTerms",SqlDbType.Int);
				cmd.Parameters["@PayTerms"].Value=rblPayTerms.SelectedItem.Value;
				cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
				cmd.Parameters["@ResTypeId"].Value=lstResourceTypes.SelectedItem.Value;
				cmd.Parameters.Add ("@ProcureMethodId",SqlDbType.Int);
				cmd.Parameters["@ProcureMethodId"].Value=rblProcMethods.SelectedItem.Value;
				cmd.Parameters.Add ("@LocId",SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;*/
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
				cmd.CommandText="fms_AddProcProcure";
				cmd.Connection=this.epsDbConn;
				/*cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;*/
				cmd.Parameters.Add("@OrgLocId",SqlDbType.Int);
				cmd.Parameters["@OrgLocId"].Value=Session["OrgLocId"].ToString();
				cmd.Parameters.Add ("@BOLocsId",SqlDbType.Int);
				cmd.Parameters["@BOLocsId"].Value=b;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@PSEPSerId",SqlDbType.Int);
				cmd.Parameters["@PSEPSerId"].Value=Session["PSEPSerId"].ToString();
				/*cmd.Parameters.Add ("@LocId",SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
				cmd.Parameters["@ResTypeId"].Value=lstResourceTypes.SelectedItem.Value;
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=rblStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PayTerms",SqlDbType.Int);
				cmd.Parameters["@PayTerms"].Value=rblPayTerms.SelectedItem.Value;
				cmd.Parameters.Add ("@ProcMethod",SqlDbType.Int);
				cmd.Parameters["@ProcMethod"].Value=rblProcMethods.SelectedItem.Value;*/
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
				/*if (Session["CallerUpdProcure"].ToString() == "frmTaskResources")
				{
					getProcurementId();
					updateTaskResources();
				}*/
				Done();
			}
		}
		/*private void getProcurementId()
		{

			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveProcurementsId";
			cmd.Parameters.Add("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ProcureId");
			I=Int32.Parse(ds.Tables["ProcureId"].Rows[0][0].ToString());

		}*/
		private void getQtyMeasure()
		{
			//if (Session["CallerUpdProcure"].ToString() == "frmResourcesAll")
		
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
/*		private void updateTaskResources()
		{


			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateTaskResource";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add("@TaskResId", SqlDbType.Int);
			cmd.Parameters ["@TaskResId"].Value=Session["TaskResId"].ToString();
			cmd.Parameters.Add("@Id", SqlDbType.Int);
			cmd.Parameters ["@Id"].Value=I;
			cmd.Parameters.Add("@Type", SqlDbType.NVarChar);
			cmd.Parameters ["@Type"].Value="Procurement";
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();

		}*/
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdProcure"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		/*private void btnSuppliers_Click(object sender, System.EventArgs e)
		{
			Session["CProviders"]="frmUpdProcurement";
			Session["ProvidersMode"]="Read";
			Session["ResTypeId"]=lstResourceTypes.SelectedItem.Value;
			Session["ResTypeName"]=lstResourceTypes.SelectedItem.Text;
			Response.Redirect (strURL + "frmServiceProviders.aspx?");
		}*/
	}
}

	
