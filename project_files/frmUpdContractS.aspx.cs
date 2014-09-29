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
	public partial class frmUpdContractS : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int GetIndexOfStatus (string s)
		{
			return (lstStatus.Items.IndexOf (lstStatus.Items.FindByValue(s)));
		}
		private int GetIndexOfType (string s)
		{
			if (s == "1")
			{
				return 1;
			}
			else
			{
				return 0;
			}

		}

		private int GetIndexOfProcMethods (string s)
		{
			return (rblProcMethods.Items.IndexOf (rblProcMethods.Items.FindByValue(s)));
		}
		private int GetIndexOfPayTerms (string s)
		{
			return (rblPayTerms.Items.IndexOf (rblPayTerms.Items.FindByValue(s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}
        private int GetIndexOfCurr(string s)
        {
            return (lstCurr.Items.IndexOf(lstCurr.Items.FindByValue(s)));
        }
		protected void Page_Load(object sender, System.EventArgs e)
		{
            
            if (Session["ContractId"].ToString() == "Update")
			{
				Id=Session["ContractId"].ToString();
			}
			if (Session["PRC"].ToString() == "1")
			{
                if (Session["MgrOption"].ToString() == "Supply")
                {
                lblPMethod.Visible=true;
				rblProcMethods.Visible=true;
				lblPTerms.Visible=true;
                lblCurr.Visible = true;
                lstCurr.Visible = true;
				rblPayTerms.Visible=true;
                }
			}
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				lblSupplier1.Visible=false;
				lblStep2.Visible=false;
				rblType.Visible=false;
				lblType.Visible=false;
				btnSupplierList.Visible=false;
				loadStatus();
				loadPayTerms();
				loadProcMethods();
				loadVisibility();
				
				lblContent1.Text=Session["Contract"].ToString() + " Contract/Commitment";
				btnAction.Text= Session["Contract"].ToString();
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);
                if (Session["MgrOption"].ToString() != "Supply")
                {
                    loadCurr();
                    if (Session["SelType"] != null)//i.e. is Org or People
                    {
                        btnSuppliers.Text = "Change Supplier";

                        if (Session["SelType"].ToString() == "Org")
                        {
                            lblSupplier.Text = "Supplier (Organization, Identified This Session): " + Session["SelOrgName"].ToString();
                            rblType.SelectedIndex = GetIndexOfType("0");
                            Session["SelId"] = Session["SelOrgId"];
                        }
                        else if (Session["SelType"].ToString() == "People")
                        {
                            lblSupplier.Text = "Supplier (Individual, Identified This Session): " + Session["PeopleName"].ToString();
                            rblType.SelectedIndex = GetIndexOfType("1");
                            Session["SelId"] = Session["PeopleId"];
                        }
                        else
                        {
                            lblSupplier.Text = "System Error. Please Contact System Administrator";
                        }
                    }
                }
                else if (Session["MgrOption"].ToString() == "Supply")
                {
                   btnSuppliers.Visible = false;
                   lblVisibility.Visible = false;
                   lstVisibility.Visible = false;
                   Session["SelType"] = "Org";
                   Session["SelId"] = Session["OrgId"];
                   lblSupplier.Text = Session["OrgName"].ToString();
                }
				if (Session["Contract"].ToString() == "Update")
				{
					loadData();
				}
				else
				{
					lstStatus.SelectedIndex=0;
					rblProcMethods.SelectedIndex=0;
					rblPayTerms.SelectedIndex=0;
					
					if (Session["SelType"] == null)
					{
						lblSupplier.Text="Supplier To Be Identified";
					}
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
	
		private void Done()
		{
			Session["SelType"]=null;
			Session["SelId"]=null;
            Session["SelOrgId"] = null;
			Session["SelOrgName"]=null;
			Session["PeopleId"]=null;
            Session["Contract"] = null;
			Response.Redirect (strURL + Session["CallerUpdContract"].ToString() + ".aspx?");
		}
        private void loadCurr()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.epsDbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "fms_RetrieveCurrencies";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "Currencies");
            lstCurr.DataSource = ds;
            lstCurr.DataMember = "Currencies";
            lstCurr.DataTextField = "Name";
            lstCurr.DataValueField = "Id";
            lstCurr.DataBind();
        }
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.Connection=this.epsDbConn;
			cmd.CommandText="fms_RetrieveContract";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ContractId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Contract");
			txtName.Text=ds.Tables["Contract"].Rows[0][1].ToString();				
			txtDesc.Text=ds.Tables["Contract"].Rows[0][2].ToString();
			lstStatus.SelectedIndex = GetIndexOfStatus (ds.Tables["Contract"].Rows[0][3].ToString());
			rblPayTerms.SelectedIndex = GetIndexOfPayTerms (ds.Tables["Contract"].Rows[0][7].ToString());
			rblProcMethods.SelectedIndex = GetIndexOfProcMethods (ds.Tables["Contract"].Rows[0][8].ToString());
            txtCommitmentDate.Text = ds.Tables["Contract"].Rows[0][12].ToString();
            lstCurr.SelectedIndex = GetIndexOfCurr(ds.Tables["Contract"].Rows[0][13].ToString());
        
			if (Session["SelType"] == null)
			{
				if (ds.Tables["Contract"].Rows[0][6].ToString() == "")
				{
					Session["SelId"]=ds.Tables["Contract"].Rows[0][6].ToString();
					//lblOrg.Text="Table"+ds.Tables["Contract"].Rows[0][6].ToString()+"Selid"+Session["SelId"].ToString();
				}
				rblType.SelectedIndex = GetIndexOfType (ds.Tables["Contract"].Rows[0][11].ToString());
				if (ds.Tables["Contract"].Rows[0][11].ToString().StartsWith("&") == true)
				{
					lblSupplier.Text="Supplier To Be Identified";
				}
				else
				{
					if (ds.Tables["Contract"].Rows[0][11].ToString() == "0")
					{
						lblSupplier.Text= "Supplier (Organization): " + ds.Tables["Contract"].Rows[0][9].ToString();
					}
					else 
					{
						lblSupplier.Text="Supplier (Individual): " + ds.Tables["Contract"].Rows[0][9].ToString();
					}
				}
				if (ds.Tables["Contract"].Rows[0][6].ToString() != "")
					btnSuppliers.Text="Change Supplier";
			}
		}
		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=3;
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			lstVisibility.DataSource = ds;			
			lstVisibility.DataMember= "Visibility";
			lstVisibility.DataTextField = "Name";
			lstVisibility.DataValueField = "Id";
			lstVisibility.DataBind();
		}
		private void loadStatus()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveContractsStatus";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ContractsStatus");
			lstStatus.DataSource = ds;			
			lstStatus.DataMember= "ContractsStatus";
			lstStatus.DataTextField = "Name";
			lstStatus.DataValueField = "Id";
			lstStatus.DataBind();
		}
		private void loadPayTerms()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrievePayTerms";
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
			cmd.CommandText="fms_RetrieveProcMethods";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ProcurementMethods");
			rblProcMethods.DataSource = ds;			
			rblProcMethods.DataMember= "ProcurementMethods";
			rblProcMethods.DataTextField = "Name";
			rblProcMethods.DataValueField = "Id";
			rblProcMethods.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (Session["Contract"].ToString() == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateContractS";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ContractId"].ToString();//Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PayTerms",SqlDbType.Int);
				cmd.Parameters["@PayTerms"].Value=rblPayTerms.SelectedItem.Value;
				if (Session["SelType"] != null)
				{
					cmd.Parameters.Add ("@Type",SqlDbType.Int);
					if (Session["SelType"].ToString() == "Org")
					{
						cmd.Parameters["@Type"].Value=0;
					}
					else if (Session["SelType"].ToString() == "People")
					{
						cmd.Parameters["@Type"].Value=1;
					}
				}
				cmd.Parameters.Add ("@ProcureMethodId",SqlDbType.Int);
				cmd.Parameters["@ProcureMethodId"].Value=rblProcMethods.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
                if (Session["SelId"] != null)
                {
                    cmd.Parameters.Add ("@OrgIdSupplier",SqlDbType.Int);
                    cmd.Parameters["@OrgIdSupplier"].Value=Int32.Parse(Session["SelId"].ToString());
                
                }
                if (txtCommitmentDate.Text != "")
                {
                    cmd.Parameters.Add("@ComDate", SqlDbType.SmallDateTime);
                    cmd.Parameters["@ComDate"].Value = txtCommitmentDate.Text;
                }
                cmd.Parameters.Add("@CurrId", SqlDbType.Int);
                cmd.Parameters["@CurrId"].Value = lstCurr.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
				
			}
			else if (Session["Contract"].ToString() == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddContractS";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=lstStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PayTerms",SqlDbType.Int);
				cmd.Parameters["@PayTerms"].Value=rblPayTerms.SelectedItem.Value;
				if (Session["SelType"] != null)
				{
					cmd.Parameters.Add ("@Type",SqlDbType.Int);
					if (Session["SelType"].ToString() == "Org")
					{
						cmd.Parameters["@Type"].Value=0;
					}
					else if (Session["SelType"].ToString() == "People")
					{
						cmd.Parameters["@Type"].Value=1;
					}
				}
                if (Session["MgrOption"].ToString() == "Supply")
                {
                   cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                   cmd.Parameters["@HHFlag"].Value = 1;
                }
				cmd.Parameters.Add ("@ProcMethod",SqlDbType.Int);
				cmd.Parameters["@ProcMethod"].Value=rblProcMethods.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				if (Session["SelId"] !=null)
				{
                    cmd.Parameters.Add ("@OrgIdSupplier",SqlDbType.Int);
					cmd.Parameters["@OrgIdSupplier"].Value=Int32.Parse(Session["SelId"].ToString());
				}
                if (txtCommitmentDate.Text != "")
                {
                    cmd.Parameters.Add("@ComDate", SqlDbType.SmallDateTime);
                    cmd.Parameters["@ComDate"].Value = txtCommitmentDate.Text;
                }
                cmd.Parameters.Add("@CurrId", SqlDbType.Int);
                cmd.Parameters["@CurrId"].Value = lstCurr.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void updContractor()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_AddOrgSelId";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@OrgSelId",SqlDbType.Int);
			cmd.Parameters["@OrgSelId"].Value=Session["OrgSelId"].ToString();
			cmd.Parameters.Add ("@ContractId",SqlDbType.Int);
			cmd.Parameters["@ContractId"].Value=Session["ContractId"].ToString();
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		protected void btnSuppliers_Click(object sender, System.EventArgs e)
		{
			lblSupplier1.Visible=true;
			rblType.Visible=true;
			lblType.Visible=true;
			btnSupplierList.Visible=true;
			lblStep2.Visible=true;
		}

		protected void btnSupplierList_Click(object sender, System.EventArgs e)
		{
			Session["SelId"]=null;
			Session["SelType"]=null;
			Session["SelOrgName"]=null;
			Session["PeopleId"]=null;
			if (rblType.SelectedItem.Value == "0")
			{
				Session["CO"]="frmUpdContractS";
				Response.Redirect (strURL + "frmOrganizations.aspx?");
			}
			else
			{
				Session["CallerPeople"]="frmUpdContractS";
				Response.Redirect (strURL + "frmPeople.aspx?");
			}
		}

	}
}

	
