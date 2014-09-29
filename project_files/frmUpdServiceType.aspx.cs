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
	public partial class frmUpdServiceType : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		/*private int GetIndexOfRoles (string s)
		{
			return (lstRoles.Items.IndexOf (lstRoles.Items.FindByValue(s)));
		}
		private int GetIndexOfProjectTypes (string s)
		{
			return (lstProjectTypes.Items.IndexOf (lstProjectTypes.Items.FindByValue(s)));
		}*/
		private int GetIndexFunction (string s)
		{
			return (lstFunction.Items.IndexOf (lstFunction.Items.FindByValue (s)));
		}
		/*private int GetIndexProvider (string s)
		{
			return (lstProvider.Items.IndexOf (lstProvider.Items.FindByValue (s)));
		}*/
		private int GetIndexQty (string s)
		{
			return (lstQtyMeasure.Items.IndexOf (lstQtyMeasure.Items.FindByValue (s)));
		}
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			
			if (!IsPostBack)
			{

				//loadRoles();
				//loadProjectTypes();
				loadQtyMeasures();
				loadFunction();
				btnAction.Text= Request.Params["btnAction"];		
				lblContent.Text=btnAction.Text;	
				txtName.Text=Request.Params["Name"];
				txtDesc.Text=Request.Params["Desc"];
				txtPJName.Text=Request.Params["PJName"];
				txtPJNameS.Text=Request.Params["PJNameS"];
                if (Request.Params["btnAction"].ToString() != "Add")
                {
                    if (Request.Params["HHFlag"].ToString() != "")
                    {
                        cbxHouseholdFlag.Checked = true;
                    }
                }

				if (btnAction.Text == "Update")
				{
					txtSeq.Text=Request.Params["Seq"];	
				}
				else
				{
					txtSeq.Text="0";
				}
				//txtDesc.Text=Request.Params["Desc"];
				lstFunction.SelectedIndex = GetIndexFunction (Request.Params["FunctionId"]);
				//lstProvider.SelectedIndex = GetIndexProvider (Request.Params["Provider"]);
				lstQtyMeasure.SelectedIndex = GetIndexQty (Request.Params["QtyMeasuresId"]);
				//lstProjectTypes.SelectedIndex = GetIndexOfProjectTypes (Request.Params["ProjectTypesId"]);
				//lstRoles.SelectedIndex = GetIndexOfRoles (Request.Params["RolesId"]);
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
		/*private void loadProjectTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveProjectTypes";
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
			da.Fill(ds,"ProjectTypes");
			lstProjectTypes.DataSource = ds;			
			lstProjectTypes.DataMember= "ProjectTypes";
			lstProjectTypes.DataTextField = "Name";
			lstProjectTypes.DataValueField = "Id";
			lstProjectTypes.DataBind();
		}
		private void loadRoles() 
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="wms_RetrieveRoles";
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
			da.Fill(ds,"Roles");
			lstRoles.DataSource = ds;			
			lstRoles.DataMember= "Roles";
			lstRoles.DataTextField = "Name";
			lstRoles.DataValueField = "Id";
			lstRoles.DataBind();
		}*/
		private void loadQtyMeasures()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from QtyMeasuresSer";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"QtyMeasuresSer");
			lstQtyMeasure.DataSource = ds;			
			lstQtyMeasure.DataMember= "QtyMeasuresSer";
			lstQtyMeasure.DataTextField = "Name";
			lstQtyMeasure.DataValueField = "Id";
			lstQtyMeasure.DataBind();
		}
		/*private void loadServiceProviders()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Profiles"
				+ " Where Type='Producer' Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Profiles");
			lstProvider.DataSource = ds;			
			lstProvider.DataMember= "Profiles";
			lstProvider.DataTextField = "Name";
			lstProvider.DataValueField = "Id";
			lstProvider.DataBind();
		}*/
		private void loadFunction()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from Functions"
				+ " Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Functions");
			lstFunction.DataSource = ds;			
			lstFunction.DataMember= "Functions";
			lstFunction.DataTextField = "Name";
			lstFunction.DataValueField = "Id";
			lstFunction.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateServiceType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.VarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;

				cmd.Parameters.Add ("@Desc",SqlDbType.VarChar);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;

				cmd.Parameters.Add ("@PJName",SqlDbType.NVarChar);
				cmd.Parameters["@PJName"].Value=txtPJName.Text;
				cmd.Parameters.Add ("@PJNameS",SqlDbType.VarChar);
				cmd.Parameters["@PJNameS"].Value=txtPJNameS.Text;
				cmd.Parameters.Add ("@FunctionId",SqlDbType.Int);
				cmd.Parameters["@FunctionId"].Value=lstFunction.SelectedItem.Value;
				cmd.Parameters.Add ("@QtyMeasuresId",SqlDbType.Int);
				cmd.Parameters["@QtyMeasuresId"].Value=lstQtyMeasure.SelectedItem.Value;
				cmd.Parameters.Add ("@Seq",SqlDbType.Int);
				if (txtSeq.Text == "")
				{
					cmd.Parameters["@Seq"].Value=99;
				}
				else
				{
					cmd.Parameters["@Seq"].Value=Int32.Parse(txtSeq.Text);
				}
                if (cbxHouseholdFlag.Checked == true)
                {
                    cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                    cmd.Parameters["@HHFlag"].Value = "1";
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
				cmd.CommandText="wms_AddServiceType";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@PJName",SqlDbType.VarChar);
				cmd.Parameters["@PJName"].Value=txtPJName.Text;
				cmd.Parameters.Add ("@PJNameS",SqlDbType.VarChar);
				cmd.Parameters["@PJNameS"].Value=txtPJNameS.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@FunctionId",SqlDbType.Int);
				cmd.Parameters["@FunctionId"].Value=lstFunction.SelectedItem.Value;
				cmd.Parameters.Add ("@Desc",SqlDbType.VarChar);
				cmd.Parameters["@Desc"].Value=txtDesc.Text;
				cmd.Parameters.Add ("@Vis",SqlDbType.Int);
				cmd.Parameters["@Vis"].Value=1;
				cmd.Parameters.Add ("@QtyMeasuresId",SqlDbType.Int);
				cmd.Parameters["@QtyMeasuresId"].Value=lstQtyMeasure.SelectedItem.Value;
				cmd.Parameters.Add ("@Seq",SqlDbType.Int);
				if (txtSeq.Text == "")
				{
					cmd.Parameters["@Seq"].Value=99;
				}
				else
				{
					cmd.Parameters["@Seq"].Value=Int32.Parse(txtSeq.Text);
				}
                if (cbxHouseholdFlag.Checked == true)
                {
                    cmd.Parameters.Add("@HHFlag", SqlDbType.Int);
                    cmd.Parameters["@HHFlag"].Value = "1";
                }
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdServiceTypes"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		/*private void btnAddClientTypes_Click(object sender, System.EventArgs e)
		{
			Session["CallerRolesAll"]="frmUpdServiceType";
			Response.Redirect (strURL + "frmRolesAll.aspx?");
		}*/

	}	


}
