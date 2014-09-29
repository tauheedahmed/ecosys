using System;
using System.Collections;
using System.Globalization;
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
	public partial class frmUpdOrgStaffTypes : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int Seq;
		private int Curr;
		private int SalPeriod;
		private int GetIndexOfCurr (string s)
		{
			return (lstCurr.Items.IndexOf (lstCurr.Items.FindByValue(s)));
		}
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgName"]).ToString();
			lblContent1.Text=Request.Params["btnAction"] + " Staff Type";			
			if (!IsPostBack)
			{
				loadCurr();
				btnAction.Text= Request.Params["btnAction"];
				if (Request.Params["btnAction"] == "Update")
				{
					loadData();
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
			cmd.CommandText="hrs_RetrieveOrgStaffType";
			cmd.Parameters.Add("@Id",SqlDbType.Int);
			cmd.Parameters["@Id"].Value=Request.Params["Id"].ToString();
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"OST");
			if (ds.Tables["OST"].Rows.Count == 1)
			{

				if (ds.Tables["OST"].Rows[0][0].ToString() == "")
				{
					lblStaffTypeName.Text="";
				}
				else
				{
					lblStaffTypeName.Text=ds.Tables["OST"].Rows[0][0].ToString();
				}
				if (ds.Tables["OST"].Rows[0][1].ToString() == "1")
				{
					ckbStatus.Checked=true;
				}
				else
				{
					ckbStatus.Checked=false;
				}
				if (ds.Tables["OST"].Rows[0][2].ToString() != "")
				{
					Curr=Int32.Parse(ds.Tables["OST"].Rows[0][2].ToString());
				}
				else
				{
					Curr=0;
				}
				if (ds.Tables["OST"].Rows[0][3].ToString() != "")
				{
					SalPeriod=Int32.Parse(ds.Tables["OST"].Rows[0][3].ToString());
				}
				else
				{
					SalPeriod=0;
				}

				if (ds.Tables["OST"].Rows[0][4].ToString() == "")
				{
					Seq=0;
				}
				else
				{
					Seq=int.Parse(ds.Tables["OST"].Rows[0][4].ToString());
				}
				if (ds.Tables["OST"].Rows[0][1].ToString() == "1")
				{
					ckbTimesheet.Checked=true;
				}
				else
				{
					ckbTimesheet.Checked=false;
				}
				
				lstCurr.SelectedIndex = GetIndexOfCurr(Curr.ToString());
				lstSalPeriod.SelectedIndex = SalPeriod;
				txtSeq.Text=Seq.ToString();
			}
			else 
			{
				lblContent1.Text="Error.  Please Contact System Administrator.";
			}
		}
		private void loadCurr()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="fms_RetrieveCurrencies";
			/*cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
			cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
			cmd.Parameters.Add ("@OrgIdP",SqlDbType.Int);
			cmd.Parameters["@OrgIdP"].Value=Session["OrgIdP"].ToString();
			cmd.Parameters.Add ("@LicenseId",SqlDbType.Int);
			cmd.Parameters["@LicenseId"].Value=Session["LicenseId"].ToString();
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();*/
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Currencies");
			lstCurr.DataSource = ds;			
			lstCurr.DataMember= "Currencies";
			lstCurr.DataTextField = "Name";
			lstCurr.DataValueField = "Id";
			lstCurr.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_UpdateOrgStaffType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@CurrenciesId",SqlDbType.Int);
				cmd.Parameters["@CurrenciesId"].Value=lstCurr.SelectedItem.Value;
				cmd.Parameters.Add ("@SalPeriod",SqlDbType.Int);
				cmd.Parameters["@SalPeriod"].Value=lstSalPeriod.SelectedItem.Value;
				cmd.Parameters.Add ("@Seq",SqlDbType.Int);
				if (txtSeq.Text != "")
				{
					cmd.Parameters["@Seq"].Value=int.Parse(txtSeq.Text);
				}
	
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (ckbStatus.Checked)
				{
					cmd.Parameters["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters["@Status"].Value=null;
				}
				cmd.Parameters.Add ("@PaymentBasis",SqlDbType.Int);
				if (ckbTimesheet.Checked)
				{
					cmd.Parameters["@PaymentBasis"].Value=1;
				}
				else
				{
					cmd.Parameters["@PaymentBasis"].Value=null;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}
			/*else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="hrs_AddOrgStaffType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= lblStaffTypeName.Text;
				cmd.Parameters.Add ("@OrgStaffTypesId",SqlDbType.Int);
				cmd.Parameters["@OrgStaffTypesId"].Value=Session["OrgSTId"].ToString();
				cmd.Parameters.Add ("@CurrenciesId",SqlDbType.Int);
				cmd.Parameters["@CurrenciesId"].Value=lstCurr.SelectedItem.Value;
				cmd.Parameters.Add ("@SalPeriod",SqlDbType.Int);
				cmd.Parameters["@SalPeriod"].Value=lstSalPeriod.SelectedItem.Value;
				cmd.Parameters.Add ("@SalMax",SqlDbType.Decimal);
				if (txtSalMax.Text != "")
				{
					cmd.Parameters["@SalMax"].Value=decimal.Parse(txtSalMax.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@SalMin",SqlDbType.Decimal);
				if (txtSalMin.Text != "")
				{
					cmd.Parameters["@SalMin"].Value=decimal.Parse(txtSalMin.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@SalAve",SqlDbType.Decimal);
				if (txtSalAve.Text != "")
				{
					cmd.Parameters["@SalAve"].Value=decimal.Parse(txtSalAve.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Ovt",SqlDbType.Decimal);
				if (txtOvt.Text != "")
				{
					cmd.Parameters["@Ovt"].Value=decimal.Parse(txtOvt.Text,
						NumberStyles.Any);
				}
				cmd.Parameters.Add ("@Status",SqlDbType.Int);
				if (ckbStatus.Checked)
				{
					cmd.Parameters["@Status"].Value=1;
				}
				else
				{
					cmd.Parameters["@Status"].Value=null;
				}
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
			}*/
			Done();
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdOST"].ToString() + ".aspx?");
		}
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}
		}
	}	

