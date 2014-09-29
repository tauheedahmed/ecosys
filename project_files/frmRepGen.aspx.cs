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
	public partial class frmUpdAssess : System.Web.UI.Page
	{
		/*public SqlConnection epsDbConn=new SqlConnection("Server=cp2693-a\\eps1;database=eps1;"+
			"uid=tauheed;pwd=tauheed;");*/
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);
	
		private int SelectIC (string s)
		{
			return (pblCStatus.Items.IndexOf (pblCStatus.Items.FindByValue(s)));
		}
		private int SelectIP (string s)
		{
			return (pblPStatus.Items.IndexOf (pblPStatus.Items.FindByValue(s)));
		}

		protected void Page_Load(object sender, System.EventArgs e)
		{	
		    if (!IsPostBack)
			{
					 //
					lblOrg.Text=Session["OrgName"].ToString();
					lblAction.Text="Emergency Preparedness Item:";
					lblAssess.Text=Request.Params["Name"];
					 txtDesc.Text=Session["Desc"].ToString();
					 pblCStatus.SelectedIndex=SelectIC (Request.Params["CStatus"]);				 
					 pblPStatus.SelectedIndex=SelectIP (Request.Params["PStatus"]);
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
			this.btnCancel.Command += new System.Web.UI.WebControls.CommandEventHandler(this.Done);

		}
		#endregion

		private void Done(object sender, System.Web.UI.WebControls.CommandEventArgs e)
		{
			Session["Id"]=null;
			Done();
		}
	
		protected void btnAction_Click(object sender, System.EventArgs e)
		{
				SqlCommand cmd=new SqlCommand();
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_UpdateAssessOrg";
				cmd.Connection=this.epsDbConn;
				cmd.Parameters.Add ("@Id", SqlDbType.Int);
				cmd.Parameters["@Id"].Value=Request.Params["Id"];
				cmd.Parameters.Add ("@CStatus",SqlDbType.NVarChar);
				cmd.Parameters["@CStatus"].Value=pblCStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@PStatus",SqlDbType.NVarChar);
				cmd.Parameters["@PStatus"].Value=pblPStatus.SelectedItem.Value;
				cmd.Parameters.Add ("@Desc",SqlDbType.NText);
				cmd.Parameters["@Desc"].Value= txtDesc.Text;
				cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Connection.Close();
				Done();
			}

		private void Done()
		{
			Response.Redirect (strURL + "frmAssessOrg.aspx?");
		}

	}
}
