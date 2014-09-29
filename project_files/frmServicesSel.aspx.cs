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
	public partial class frmServicesSel : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Load_Plans();
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
		private void Load_Plans()
		{
			if (!IsPostBack) 
			{
				loadData();
			
				lblOrg.Text=Session["OrgName"].ToString();
			}
		}
			private void gridSet1()
			{
				foreach (DataGridItem i in DataGrid1.Items)
				{
					Button bItem = (Button)(i.Cells[8].FindControl("btnItems"));
					bItem.Visible=true;
					bItem.Text="Classes";
					Button bEm = (Button)(i.Cells[8].FindControl("btnEmergency"));
					bEm.Visible=false;
					Button bRg = (Button)(i.Cells[8].FindControl("btnRegular"));
					bRg.Visible=false;
					Button bIt = (Button)(i.Cells[8].FindControl("btnItems"));
					bIt.Visible=true;
					bIt.Text="Classes";				
				}
			}
		private void gridSet2()
			   {
				   foreach (DataGridItem i in DataGrid1.Items)
				   {
					   Button bItem = (Button)(i.Cells[8].FindControl("btnItems"));
					   bItem.Visible=false;
					   Button bIt = (Button)(i.Cells[8].FindControl("btnItems"));
					   bIt.Visible=false;
				   }
			   }
		private void loadData()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveServices";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@DomainId",SqlDbType.Int);
			cmd.Parameters["@DomainId"].Value=Session["DomainId"].ToString();
			cmd.Parameters.Add ("@Caller",SqlDbType.NVarChar);
			cmd.Parameters["@Caller"].Value="ServSel";
			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter(cmd);
			da.Fill(ds,"Outputs");
			Session["ds"]=ds;
			DataGrid1.DataSource=ds;
			DataGrid1.DataBind();

		}
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + "frmUpdServices.aspx?"
				+ "&btnAction=" + "Add"
				+ "&SupplierOrg=" + Session["OrgId"].ToString());
		}
		/*private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
				
		}*/

		private void processCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "BIA")
			{
				Response.Redirect (strURL + "frmCommitments.aspx?"
					+ "&ResourceId=" + e.Item.Cells[0].Text
					+ "&OutputName=" + e.Item.Cells[1].Text );
			}
			else if (e.CommandName == "Update")
			{
				Response.Redirect (strURL + "frmUpdServices.aspx?"
					+ "&btnAction=" + "Update"
					+ "&ResourceId=" + e.Item.Cells[0].Text
					+ "&Name=" + e.Item.Cells[1].Text
					+ "&Desc=" + e.Item.Cells[2].Text
					+ "&Avail=" + e.Item.Cells[3].Text
					+ "&Type=" + e.Item.Cells[4].Text
					+ "&SupplierOrg=" + e.Item.Cells[5].Text);
			}
			else if (e.CommandName == "Emergency")
			{
				Session["CallerServiceSteps"]="frmServices";
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ResourceId"]=e.Item.Cells[0].Text;
				Session["StepType"]="Emergency";
				Response.Redirect (strURL + "frmServiceSteps.aspx?");
			}
			else if (e.CommandName == "Regular")
			{
				Session["CallerServiceSteps"]="frmServices";
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ResourceId"]=e.Item.Cells[0].Text;
				Session["StepType"]="Regular";
				Response.Redirect (strURL + "frmServiceSteps.aspx?");
			}
			else if (e.CommandName == "People")
			{

			}
			else if (e.CommandName == "Items")
			{
				Session["CallerActivations"]="frmServices";
				Session["ServiceName"]=e.Item.Cells[1].Text;
				Session["ResourceId"]=e.Item.Cells[0].Text;
				Session["Mode"]="Actual";
				Session["Activity"]=38;
				Response.Redirect (strURL + "frmActivations.aspx?");
			}
			else if (e.CommandName == "Delete")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_DeleteOutput";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse (e.Item.Cells[0].Text);
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				loadData();
			}
		}
		/*private void Delete(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}*/

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerServicesSel"].ToString() + ".aspx?");
		}

	}

}
	