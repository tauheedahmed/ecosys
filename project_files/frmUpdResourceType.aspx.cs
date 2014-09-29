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
	public partial class frmUpdResourceType : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		private int GetIndexParent (string s)
		{
			return (lstParent.Items.IndexOf (lstParent.Items.FindByValue (s)));
		}
		private int GetIndexQty (string s)
		{
			return (lstQtyMeasure.Items.IndexOf (lstQtyMeasure.Items.FindByValue (s)));
		}
		private int GetIndexOfVisibility (string s)
		{
			return (lstVisibility.Items.IndexOf (lstVisibility.Items.FindByValue(s)));
		}	
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
           
			
			if (!IsPostBack)
			{

				loadQtyMeasures();
				loadVisibility();
				loadParentResourceTypes();
				btnAction.Text= Request.Params["btnAction"];
                if (Session["RType"] == null)
                {
                    lblContent.Text = btnAction.Text + " Resource";
                }
                else
                {
                    if (Session["RType"].ToString() == "0")
                    {
                        lblContent.Text = btnAction.Text + " Resource";
                    }
                    else
                    {
                        lblContent.Text = btnAction.Text + " Service";
                    }
                }
				txtName.Text=Request.Params["Name"]; 
                txtDesc.Text = Request.Params["Desc"];
				lstParent.SelectedIndex = GetIndexParent (Request.Params["ParentId"]);
				lstQtyMeasure.SelectedIndex = GetIndexQty (Request.Params["Qty"]);
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
		private void loadQtyMeasures()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from QtyMeasures";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"QtyMeasures");
			lstQtyMeasure.DataSource = ds;			
			lstQtyMeasure.DataMember= "QtyMeasures";
			lstQtyMeasure.DataTextField = "Name";
			lstQtyMeasure.DataValueField = "Id";
			lstQtyMeasure.DataBind();
		}
		private void loadParentResourceTypes()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			cmd.CommandType=CommandType.Text;
			cmd.CommandText="Select Id, Name from ResourceTypes"
				+ " Where Visibility=1 Order by Name";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"ResourceTypes");
			lstParent.DataSource = ds;			
			lstParent.DataMember= "ResourceTypes";
			lstParent.DataTextField = "Name";
			lstParent.DataValueField = "Id";
			lstParent.DataBind();
		}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_UpdateResourceTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                cmd.Parameters["@Desc"].Value = txtDesc.Text;
				
				cmd.Parameters.Add ("@Visibility",SqlDbType.Int);
				cmd.Parameters["@Visibility"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@ParentId",SqlDbType.Int);
				cmd.Parameters["@ParentId"].Value=lstParent.SelectedItem.Value;
				cmd.Parameters.Add ("@QtyMeasure",SqlDbType.Int);
				cmd.Parameters["@QtyMeasure"].Value=lstQtyMeasure.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="wms_AddResourceTypes";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
                cmd.Parameters.Add("@Desc", SqlDbType.NVarChar);
                cmd.Parameters["@Desc"].Value = txtDesc.Text;
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgId"].ToString();
				cmd.Parameters.Add ("@ParentId",SqlDbType.Int);
				cmd.Parameters["@ParentId"].Value=lstParent.SelectedItem.Value;
				cmd.Parameters.Add ("@Visibility",SqlDbType.Int);
				cmd.Parameters["@Visibility"].Value=lstVisibility.SelectedItem.Value;
				cmd.Parameters.Add ("@QtyMeasure",SqlDbType.Int);
				cmd.Parameters["@QtyMeasure"].Value=lstQtyMeasure.SelectedItem.Value;
				cmd.Parameters.Add ("@RType",SqlDbType.Int);
				cmd.Parameters["@RType"].Value=Session["RType"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}
		}
		private void Done()
		{
			Response.Redirect (strURL + Session["CUpdResType"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

	}	


}
