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

using System.Globalization;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmAddProcedure.
	/// </summary>
	public partial class frmUpdInventory : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int GetIndexOfStatus (string s)
		{
            return (rblStatus.Items.IndexOf(rblStatus.Items.FindByValue(s)));
		}
        private int GetIndexOflstResourceTypes (string s)
		{
			return (lstResourceTypes.Items.IndexOf (lstResourceTypes.Items.FindByValue(s)));
		}
		private int GetIndexOfLocs (string s)
		{
			return (lstLocations.Items.IndexOf (lstLocations.Items.FindByValue(s)));
		}
        private int GetIndexOfVisibility(string s)
        {
            return (lstVisibility.Items.IndexOf(lstVisibility.Items.FindByValue(s)));
        }
       
        int ResTypeFlag = 0;
				
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
                lblAction.Text = Request.Params["btnAction"] + " Inventory";
                loadResTypes();
				loadLocs();
                loadVisibility();
                loadStatus();
                

				/*rblStatus.BorderColor=System.Drawing.Color.Navy;
				rblStatus.ForeColor=System.Drawing.Color.Navy;
				lstLocations.BorderColor=System.Drawing.Color.Navy;
				lstLocations.ForeColor=System.Drawing.Color.Navy;*/
				if (Session["CallerUpdInv"].ToString() == "frmInventory")
				{
					//lblContent1.Text="Add Inventory Item of type: " + Session["ResTypeName"].ToString();	
				}
				else
				{
					
				}
				btnAction.Text= Request.Params["btnAction"];
                if (Request.Params["btnAction"] == "Update")
                {
                    loadData();
                }
                else
                {
                    rblStatus.SelectedIndex =
                GetIndexOfStatus("1");
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
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveInventory";
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Request.Params["Id"];
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"InventoryT");
			txtDesc.Text=ds.Tables["InventoryT"].Rows[0][2].ToString();
            txtSubLoc.Text = ds.Tables["InventoryT"].Rows[0][9].ToString();
            lstLocations.SelectedIndex=
				GetIndexOfLocs(ds.Tables["InventoryT"].Rows[0][3].ToString());
			rblStatus.SelectedIndex = 
				GetIndexOfStatus(ds.Tables["InventoryT"].Rows[0][5].ToString());
            if (ResTypeFlag == 0)
            {
                lstResourceTypes.SelectedIndex =
                        GetIndexOflstResourceTypes(ds.Tables["InventoryT"].Rows[0][4].ToString());
            }
            lblQty.Text = "Quantity (In " + ds.Tables["InventoryT"].Rows[0][8].ToString() + ")";
            txtQty.Text = ds.Tables["InventoryT"].Rows[0][10].ToString();
            lstVisibility.SelectedIndex=
                GetIndexOfVisibility(ds.Tables["InventoryT"].Rows[0][6].ToString());
			}
               
        private void loadVisibility()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ams_RetrieveVisibility";
            cmd.Parameters.Add("@Vis", SqlDbType.Int);
            cmd.Parameters["@Vis"].Value = Session["OrgVis"].ToString();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Visibility");
            lstVisibility.DataSource = ds;
            lstVisibility.DataMember = "Visibility";
            lstVisibility.DataTextField = "Name";
            lstVisibility.DataValueField = "Id";
            lstVisibility.DataBind();
        }
		private void loadResTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveResourceTypes";
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
			lstResourceTypes.DataTextField = "Name";
			lstResourceTypes.DataValueField = "Id";
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
			cmd.CommandText="eps_RetrieveInventoryStatus";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"InventoryStatus");
			rblStatus.DataSource = ds;			
			rblStatus.DataMember= "InventoryStatus";
			rblStatus.DataTextField = "Name";
			rblStatus.DataValueField = "Id";
			rblStatus.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateInventory";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
                cmd.Parameters.Add("@SubLoc", SqlDbType.NVarChar);
                cmd.Parameters["@SubLoc"].Value = txtSubLoc.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                cmd.Parameters["@Desc"].Value = txtDesc.Text;
                if (txtQty.Text != "")
                {
                    cmd.Parameters.Add("@Qty", SqlDbType.Float);
                    cmd.Parameters["@Qty"].Value = float.Parse(txtQty.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign);
                }
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=rblStatus.SelectedItem.Value;
                cmd.Parameters.Add("@ResTypeId", SqlDbType.Int);
                if (Session["CallerUpdInv"].ToString() == "frmInventory")
                {
                    cmd.Parameters["@ResTypeId"].Value = lstResourceTypes.SelectedItem.Value; 
                }
                cmd.Parameters.Add("@VisId", SqlDbType.Int);
                cmd.Parameters["@VisId"].Value = lstVisibility.SelectedItem.Value;
                cmd.Parameters.Add("@LocId", SqlDbType.Int);
                cmd.Parameters["@LocId"].Value = lstLocations.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddInventory";
				cmd.Connection=this.epsDbConn;
                cmd.Parameters.Add("@SubLoc", SqlDbType.NVarChar);
                cmd.Parameters["@SubLoc"].Value = txtSubLoc.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"];
                if (txtQty.Text != "")
                {
                    cmd.Parameters.Add("@Qty", SqlDbType.Float);
                    cmd.Parameters["@Qty"].Value = float.Parse(txtQty.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign);
                }
                cmd.Parameters.Add("@LocId", SqlDbType.Int);
				cmd.Parameters["@LocId"].Value=lstLocations.SelectedItem.Value;
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=rblStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@ResTypeId",SqlDbType.Int);
				if (Session["CallerUpdInv"].ToString() == "frmInventory")
				{
                    cmd.Parameters["@ResTypeId"].Value = lstResourceTypes.SelectedItem.Value; ;
				}
				else
				{
					//cmd.Parameters["@ResTypeId"].Value=lstResourceTypes.SelectedItem.Value;
				}
                cmd.Parameters.Add("@VisId", SqlDbType.Int);
                cmd.Parameters["@VisId"].Value = lstVisibility.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdInv"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		/*private void btnAddLoc_Click(object sender, System.EventArgs e)
		{
			Session["CUpdLocs"]="frmUpdInventory";
			Response.Redirect (strURL + "frmUpdLoc.aspx?"
				+ "&btnAction=" + "Add");
		}*/


        protected void lstResourceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Desc"] = txtDesc.Text;
            ResTypeFlag = 1;
            if (Request.Params["btnAction"] == "Update")
            {
                loadData();
            }
            txtDesc.Text = Session["Desc"].ToString();
            Session["Desc"] = null;
            ResTypeFlag = 0;

        }
}	

}
