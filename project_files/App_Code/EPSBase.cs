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
	/// Summary description for Class1.
	/// </summary>
	public class EPSBase
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);

		public static string headingOrg(int x)
		{
			if (x == 1)
				return "eps_AddTask";
			else
				return "dslkfj";
		}

		/*public static string loadVisibility()
		{
			SqlCommand cmd=new SqlCommand();
			cmd.Connection=this.epsDbConn;
			//error message on rebuild: 
			//"Keyword this is not valid 
			//in a static property, static method, or static field initializer"

			cmd.CommandType=CommandType.StoredProcedure;
			cmd.CommandText="eps_RetrieveVisibility";
			cmd.Parameters.Add ("@Vis",SqlDbType.Int);
			cmd.Parameters["@Vis"].Value=Session["OrgVis"].ToString();
			//error msg:
			//"The name 'Session' does not exist in the class or namespace 
			//'WebApplication2.EPSBase'"

			DataSet ds=new DataSet();
			SqlDataAdapter da=new SqlDataAdapter (cmd);
			da.Fill(ds,"Visibility");
			//lstVisibility.DataSource = ds;			
			//lstVisibility.DataMember= "Visibility";
			//lstVisibility.DataTextField = "Name";
			//lstVisibility.DataValueField = "Id";
			//lstVisibility.DataBind();
		}*/
	}
}
