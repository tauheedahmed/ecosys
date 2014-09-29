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
using CrystalDecisions.Shared;

public partial class frmMainProfileMgr : System.Web.UI.Page
{
    private static string strURL =
            System.Configuration.ConfigurationSettings.AppSettings["local_url"];
    private static string strDB =
        System.Configuration.ConfigurationSettings.AppSettings["local_db"];
    public SqlConnection epsDbConn = new SqlConnection(strDB);
    protected void Page_Load(object sender, EventArgs e)
    {
        getPeopleId();
        if (Session["UserLevel"].ToString() == "0")
        {
            lblGreetAdv.Visible = false;
            lblIntrop1.Visible = false;
            lblIntrop2.Visible = false;
            lblHead1.Visible = false;
            //lblGreetBeg.Visible = true;
            lblAll.Visible = true;
            lblHead2.Visible = false;
            lblAdvanced.Visible = false;
            //lblGreetBeg.Text = "Greetings " + Session["FName"].ToString() + ".";
            btnStep2.Text = "Click Here to Begin";
            btnStep1.Visible = false;
        }
        else
        {
            //lblGreetBeg.Visible = false;
            //lblAll.Visible = false;
            lblGreetAdv.Text = "Greetings " + Session["FName"].ToString() + ".";
        }
        
    }

    private void getPeopleId()
    {
        Object tmp = new object();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = this.epsDbConn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "ams_RetrieveUserIdName";
        cmd.Parameters.Add("@UserId", SqlDbType.NVarChar);
        cmd.Parameters["@UserId"].Value = Session["UserId"].ToString();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds, "UserPerson");
        /*tmp = cmd.ExecuteScalar();*/
        Session["PeopleId"] = ds.Tables["UserPerson"].Rows[0][0];
        Session["LName"] = ds.Tables["UserPerson"].Rows[0][1];
        Session["Fname"] = ds.Tables["UserPerson"].Rows[0][2];
        Session["CellPhone"] = ds.Tables["UserPerson"].Rows[0][3];
        Session["HomePhone"] = ds.Tables["UserPerson"].Rows[0][4];
        Session["WorkPhone"] = ds.Tables["UserPerson"].Rows[0][5];
        Session["Address"] = ds.Tables["UserPerson"].Rows[0][6];
        Session["Email"] = ds.Tables["UserPerson"].Rows[0][7];
    }
  protected void btnStep2_Click(object sender, EventArgs e)
    {
        Session["Section"] = "I";
        Session["CServiceTypes"]="frmMainProfileMgr";
			Response.Redirect (strURL + "frmServiceTypes.aspx?");
       
    } 
    protected void btnStep1_Click(object sender, EventArgs e)
    {
        Session["Section"] = "II";
        Session["CProfiles"] = "frmMainProfileMgr";
        Session["ProfileType"] = "Producer";
        Session["Mode"] = "Profiles";
        Response.Redirect(strURL + "frmProfiles.aspx?");
    } 
    
    protected void btnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect(strURL + "frmStart.aspx?");
    }
    protected void btnHH_Click(object sender, EventArgs e)
    {
        Session["Section"] = "II";
        Session["CProfiles"] = "frmMainProfileMgr";
        Session["ProfileType"] = "Consumer";
        Session["Mode"] = "Profiles";
        Response.Redirect(strURL + "frmProfiles.aspx?");
    }
}
