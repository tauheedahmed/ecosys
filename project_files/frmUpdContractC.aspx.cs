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
	public partial class frmUpdContractC : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int GetIndexOfStatus (string s)
		{
			return (rblStatus.Items.IndexOf (rblStatus.Items.FindByValue(s)));
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
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Session["ContractId"].ToString() == "Update")
			{
				Id=Session["ContractId"].ToString();
			}
			if (!IsPostBack)
			{
				lblOrg.Text=(Session["OrgName"]).ToString();
				loadStatus();
				loadPayTerms();
				loadProcMethods();
				loadVisibility();
				rblStatus.BorderColor=System.Drawing.Color.Navy;
				rblStatus.ForeColor=System.Drawing.Color.Navy;				
				rblPayTerms.BorderColor=System.Drawing.Color.Navy;
				rblPayTerms.ForeColor=System.Drawing.Color.Navy;
				rblProcMethods.BorderColor=System.Drawing.Color.Navy;
				rblProcMethods.ForeColor=System.Drawing.Color.Navy;
				lblContent1.Text=Session["btnAction"].ToString() + " Contract";
				btnAction.Text= Session["btnAction"].ToString();
				lstVisibility.SelectedIndex=GetIndexOfVisibility(Request.Params["Vis"]);
				if (Session["OrgSel"] != null)
				{
					Session["OrgSelId"]=Session["OrgSelId"].ToString();
					lblOrgSelName.Text= Session["OrgSelName"].ToString();
				}
				if (Session["btnAction"].ToString() == "Update")
				{
					loadData();
				}
				else
				{
					rblStatus.SelectedIndex=0;
					rblPayTerms.SelectedIndex=0;
					rblProcMethods.SelectedIndex=0;
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
			cmd.CommandText="fms_RetrieveContractC";		
			cmd.Parameters.Add ("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Session["ContractId"].ToString();			
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Contract");
			txtName.Text=ds.Tables["Contract"].Rows[0][1].ToString();				
			txtDesc.Text=ds.Tables["Contract"].Rows[0][2].ToString();
			rblStatus.SelectedIndex = GetIndexOfStatus (ds.Tables["Contract"].Rows[0][3].ToString());
			rblPayTerms.SelectedIndex = GetIndexOfPayTerms (ds.Tables["Contract"].Rows[0][7].ToString());
			rblProcMethods.SelectedIndex = GetIndexOfProcMethods (ds.Tables["Contract"].Rows[0][8].ToString());
			if (Session["OrgSel"] == null)
			{
				Session["OrgSelId"]=ds.Tables["Contract"].Rows[0][6].ToString();
				lblOrgSelName.Text= ds.Tables["Contract"].Rows[0][9].ToString();
			}
		}
		private void loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="ams_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
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
			rblStatus.DataSource = ds;			
			rblStatus.DataMember= "ContractsStatus";
			rblStatus.DataTextField = "Name";
			rblStatus.DataValueField = "Id";
			rblStatus.DataBind();
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
			if (Session["btnAction"].ToString() == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_UpdateContractC";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Session["ContractId"].ToString();//Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=rblStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PayTerms",SqlDbType.Int);
				cmd.Parameters["@PayTerms"].Value=rblPayTerms.SelectedItem.Value;
				cmd.Parameters.Add ("@ProcureMethodId",SqlDbType.Int);
				cmd.Parameters["@ProcureMethodId"].Value=rblProcMethods.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				if (Session["OrgSelId"] != null)
				{
					cmd.Parameters.Add ("@OrgIdClient",SqlDbType.Int);
					cmd.Parameters["@OrgIdClient"].Value=Session["OrgSelId"].ToString();
				}	

				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (Session["btnAction"].ToString() == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="fms_AddContractC";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@Desc",SqlDbType.NVarChar);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@StatusId",SqlDbType.Int);
				cmd.Parameters["@StatusId"].Value=rblStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PayTerms",SqlDbType.Int);
				cmd.Parameters["@PayTerms"].Value=rblPayTerms.SelectedItem.Value;
				cmd.Parameters.Add ("@ProcMethod",SqlDbType.Int);
				cmd.Parameters["@ProcMethod"].Value=rblProcMethods.SelectedItem.Value;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=lstVisibility.SelectedItem.Value;
				if (Session["OrgSel"] != null)
				{
					cmd.Parameters.Add ("@OrgIdClient",SqlDbType.Int);
					cmd.Parameters["@OrgIdClient"].Value=Session["OrgSelId"].ToString();
				}	
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Session["OrgSel"]=null;
			Session["OrgSelId"]=null;
			Session["OrgSelName"]=null;
			Response.Redirect (strURL + Session["CallerUpdContract"].ToString() + ".aspx?");
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
			Session["CO"]="frmUpdContractC";
			//Session["ProcMethodId"]=rblProcMethods.SelectedItem.Value;
			//Session["ProcMethodName"]=rblProcMethods.SelectedItem.Text;
			Response.Redirect (strURL + "frmOrganizations.aspx?");
		}

		protected void btnProcureItems_Click(object sender, System.EventArgs e)
		{
			Session["CCP"]="frmUpdContractC";
			Response.Redirect (strURL + "frmContractProcures.aspx?");
		}
	}
}

	
