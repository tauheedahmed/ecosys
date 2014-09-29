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
	public partial class frmUpdPeopleStatus : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
		private String Id;
		public Object NewId = new object();
		public Object NewSeq = new object();
		public Decimal I;
		private int GetIndexStage (string s)
		{
				return (lstStages.Items.IndexOf (lstStages.Items.FindByValue (s)));
		}
		private int GetIndexAvail (string item)
		{
			if ((btnAction.Text == "Update") && (item != null))
			{
				if (item.Trim() == "Organization")
				{
					return 1;
				}
				else if (item.Trim() == "Public")
				{
					return 2;
				}
				else
				{
					return 0;
				}
			}

			else
			{
				return 0;

			}
		}
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			Id=Request.Params["Id"];
			lblOrg.Text=(Session["OrgNamet"]).ToString();
			
		{
			lstStages.SelectedIndex = GetIndexStage (Request.Params["StageId"]);
		}
		if (!IsPostBack)
			{
				loadStages();
				btnAction.Text= Request.Params["btnAction"];		
				lblContent.Text=btnAction.Text + " Step";	
				txtName.Text=Request.Params["Name"];				
			//	txtDesc.Text=Request.Params["Desc"];
				if (Request.Params["btnAction"] == "Update")
				{
				
				}
				//lstAvail.SelectedIndex = GetIndexAvail(Request.Params["Availability"]);
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

		private void loadStages()
			{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.Text;
				cmd.CommandText="Select Id, Name from Stages"
					+ " Order by Seq";
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter (cmd);
				da.Fill(ds,"Stages");
				lstStages.DataSource = ds;			
				lstStages.DataMember= "Stages";
				lstStages.DataTextField = "Name";
				lstStages.DataValueField = "Id";
				lstStages.DataBind();
			}
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
			if (btnAction.Text == "Update") 
			{
				SqlCommand cmd = new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateStep";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id",SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Int32.Parse(Id);
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value=txtName.Text;
				cmd.Parameters.Add ("@StageId",SqlDbType.Int);
				cmd.Parameters["@StageId"].Value=lstStages.SelectedItem.Value;
				cmd.Parameters.Add ("@Availability",SqlDbType.NVarChar);
				cmd.Parameters["@Availability"].Value=lstAvail.SelectedItem.Value;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close(); 
				Done();
			}
			else if (btnAction.Text == "Add")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_AddStep";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Name",SqlDbType.NVarChar);
				cmd.Parameters["@Name"].Value= txtName.Text;
				cmd.Parameters.Add ("@StageId",SqlDbType.Int);
				cmd.Parameters["@StageId"].Value=2;
				cmd.Parameters.Add ("@Availability",SqlDbType.NVarChar);
				cmd.Parameters["@Availability"].Value="Own";
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value=Session["OrgIdt"].ToString();
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				if (Session["CallerServiceSteps"].ToString() == "frmActivations")
				{
					RetrieveStepId();
					RetrieveSeq();
					UpdateActivationSteps();					
				}
				else
				{
					RetrieveStepId();
					RetrieveSeq();
					UpdateServiceSteps();						
				}
				Done();
			}
		}
		private void RetrieveStepId()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "Select Max(Id) From Steps"
				+ " Where OrgId=" + "'" + Session["OrgId"].ToString() + "'";
			cmd.Connection.Open();
			NewId = cmd.ExecuteScalar();
			cmd.Connection.Close();
		}
		private void RetrieveSeq()
		{
			SqlCommand cmd = new SqlCommand();
			cmd.Connection = this.epsDbConn;
			cmd.CommandType = CommandType.Text;
			if (Session["CallerServiceSteps"].ToString() == "frmActivations")
			{
				cmd.CommandText = "Select Max(Seq) From ActivationSteps"
					+ " Where Activation=" + Session["ActivationId"].ToString();
			}
			else
			{
				cmd.CommandText = "Select Max(Seq) From ServiceSteps"
					+ " Where ResourceId=" + "'" + Session["ResourceId"].ToString() + "'"
					+ " and Type=" + "'" + Session["StepType"].ToString() + "'";
			}
			cmd.Connection.Open();
			
			NewSeq = cmd.ExecuteScalar();
			I=Int32.Parse((NewSeq).ToString()) + 1;
			cmd.Connection.Close();
		}
		private void UpdateServiceSteps()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateServiceSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@ResourceId",SqlDbType.Int);
			cmd.Parameters["@ResourceId"].Value=Session["ResourceId"].ToString();
			cmd.Parameters.Add ("@StepId",SqlDbType.Int);
			cmd.Parameters["@StepId"].Value=NewId.ToString();
			cmd.Parameters.Add ("@StepType",SqlDbType.NVarChar);
			cmd.Parameters["@StepType"].Value=Session["StepType"].ToString();
			cmd.Parameters.Add ("@Seq",SqlDbType.Int);
			cmd.Parameters["@Seq"].Value=I;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			
		}
		private void UpdateActivationSteps()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_UpdateActivationSteps";
			cmd.Connection=this.epsDbConn;
			cmd.Parameters.Add ("@Activation",SqlDbType.Int);
			cmd.Parameters["@Activation"].Value=Session["ActivationId"].ToString();
			cmd.Parameters.Add ("@StepId",SqlDbType.Int);
			cmd.Parameters["@StepId"].Value=NewId.ToString();
			cmd.Parameters.Add ("@Seq",SqlDbType.Int);
			cmd.Parameters["@Seq"].Value=I;
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
			
		}

		private void Done()
		{
			Response.Redirect (strURL + Session["CallerUpdStep"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Done();
		}

		protected void txtName_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}	


}
