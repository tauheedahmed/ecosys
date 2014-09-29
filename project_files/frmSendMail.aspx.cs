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
using System.Web.Mail;
using System.Xml;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for frmSendMail.
	/// </summary>
	public partial class frmSendMail : System.Web.UI.Page
	{
		private string emailAddresses = "";
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		private static string strSMTP = 
			System.Configuration.ConfigurationSettings.AppSettings["local_smtp"];
		public SqlConnection epsDbConn=new SqlConnection(strDB);

	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.Params["MailType"] == "Single")
			{
				lblSenderName.Text=Request.Params["SenderName"];
				lblSenderEmail.Text=Request.Params["SenderEmail"];
				lblRecipientName.Text=Request.Params["RecipientName"];
				lblRecipientEmail.Text=Request.Params["RecipientEmail"];
			}
			else if ((Request.Params["MailType"] == "Multiple")
				& (Session["CallerSendMail"].ToString() == "frmOrgs"))
			{
				lblSenderName.Text=Request.Params["SenderName"];
				lblSenderEmail.Text=Request.Params["SenderEmail"];
				lblRecipientName.Text="All " + Session["OrgType"].ToString();
				lblRecipientEmail.Visible=false;
				lblEmailR.Visible=false;
			}
			else if ((Request.Params["MailType"] == "Multiple")
				&(Session["CallerSendMail"].ToString() == "frmStaffing"))
			{
				lblSenderName.Text=Request.Params["SenderName"];
				lblSenderEmail.Text=Request.Params["SenderEmail"];
				lblRecipientName.Text="All Individuals in " + Session["OrgType"].ToString();
				lblRecipientEmail.Visible=false;
				lblEmailR.Visible=false;
			}
			else if ((Request.Params["MailType"] == "Multiple")
				&((Session["CallerSendMail"].ToString() == "frmActPeople")
				|| (Session["CallerSendMail"].ToString() == "frmActClients")))
			{
				lblSenderName.Text=Request.Params["SenderName"];
				lblSenderEmail.Text=Request.Params["SenderEmail"];
				lblRecipientName.Text="All Members: " + Session["ServiceName"].ToString();
				lblRecipientEmail.Visible=false;
				lblEmailR.Visible=false;
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


		protected void btnSend_Click(object sender, System.EventArgs e)
		{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.StoredProcedure;
			
				if (Request.Params["MailType"] == "Single")
				{
					MailMessage msg = new MailMessage();
					msg.From = Request.Params["SenderEmail"];//"tauheedahmed@hotmail.com";
					msg.To = Request.Params["RecipientEmail"];//"tauheedahmed@hotmail.com";
					msg.Cc = Request.Params["SenderEmail"];//emailAddresses;
					msg.Subject = txtSubject.Text;
					msg.Body = txtBody.Text;
					SmtpMail.SmtpServer.Insert (0, strSMTP);
					SmtpMail.Send(msg);
				}
				else if ((Request.Params["MailType"] == "Multiple") 
					&(Request.Params["CallerSendMail"].ToString() == "frmOrgs"))
				{
					cmd.CommandText="eps_RetrieveEmailOrg";
					cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
					cmd.Parameters["@OrgId"].Value= Request.Params["OrgId"];
					cmd.Parameters.Add ("@OrgType",SqlDbType.NVarChar);
					cmd.Parameters["@OrgType"].Value=Session["OrgType"].ToString();
					DataSet ds=new DataSet();
					SqlDataAdapter da=new SqlDataAdapter (cmd);
					da.Fill(ds,"Emails");
					foreach (DataRow dr in ds.Tables["Emails"].Rows)
						emailAddresses = emailAddresses + dr[0].ToString() + ";";
					MailMessage msg = new MailMessage();
					msg.From = Request.Params["Sender"];//"tauheedahmed@hotmail.com";
					msg.To = Request.Params["Sender"];//"tauheedahmed@hotmail.com";
					msg.Cc = emailAddresses;//emailAddresses;
					msg.Subject = txtSubject.Text;
					msg.Body = txtBody.Text;
					SmtpMail.SmtpServer = "mail.spsnet.com";//172.27.10.2"; 
					SmtpMail.Send(msg);
				}
				else if ((Request.Params["MailType"] == "Multiple") 
					&(Request.Params["CallerSendMail"].ToString() == "frmStaffing"))
				{
					cmd.CommandText="eps_RetrieveEmailPeople";
					cmd.Parameters.Add ("@OrgIdt",SqlDbType.Int);
					cmd.Parameters["@OrgIdt"].Value=Session["OrgIdt"].ToString();
					DataSet ds=new DataSet();
					SqlDataAdapter da=new SqlDataAdapter (cmd);
					da.Fill(ds,"Emails");
					foreach (DataRow dr in ds.Tables["Emails"].Rows)
						emailAddresses = emailAddresses + dr[0].ToString() + ";";
					MailMessage msg = new MailMessage();
					msg.From = Request.Params["Sender"];
					msg.To = Request.Params["Sender"];
					msg.Cc = emailAddresses;
					msg.Subject = txtSubject.Text;
					msg.Body = txtBody.Text;
					SmtpMail.SmtpServer = "mail.spsnet.com";//172.27.10.2"; 
					SmtpMail.Send(msg);
				}
				else if ((Request.Params["MailType"] == "Multiple") 
					&(Request.Params["CallerSendMail"].ToString() == "frmActPeople"))
				{
					cmd.CommandText="eps_RetrieveEmailPeopleAct";
					cmd.Parameters.Add ("@ActId",SqlDbType.Int);
					cmd.Parameters["@ActId"].Value=Session["ActivationId"].ToString();
					DataSet ds=new DataSet();
					SqlDataAdapter da=new SqlDataAdapter (cmd);
					da.Fill(ds,"Emails");
					foreach (DataRow dr in ds.Tables["Emails"].Rows)
						emailAddresses = emailAddresses + dr[0].ToString() + ";";
					MailMessage msg = new MailMessage();
					msg.From = Request.Params["Sender"];
					msg.To = Request.Params["Sender"];
					msg.Cc = emailAddresses;
					msg.Subject = txtSubject.Text;
					msg.Body = txtBody.Text;
					SmtpMail.SmtpServer = "mail.spsnet.com";//172.27.10.2"; 
					SmtpMail.Send(msg);
				}
				Response.Redirect (strURL + Session["CallerSendMail"].ToString() + ".aspx?");
		}

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect (strURL + Session["CallerSendMail"].ToString() + ".aspx?");
		}

		protected void btnXML_Click(object sender, System.EventArgs e)
		{
			if (Request.Params["MailType"] == "MultipleOrg")
			{
				SqlCommand cmd=new SqlCommand();
				cmd.Connection=this.epsDbConn;
				cmd.CommandType=CommandType.StoredProcedure;
				cmd.CommandText="eps_RetrieveEmailMOrg";
				cmd.Parameters.Add ("@OrgId",SqlDbType.Int);
				cmd.Parameters["@OrgId"].Value= Request.Params["OrgId"];
				DataSet ds=new DataSet();
				SqlDataAdapter da=new SqlDataAdapter (cmd);
				da.Fill(ds,"Emails");
				ds.WriteXml ("C:\\eps_emailExchange.xml");
			}
			else if (Request.Params["MailType"] == "Single")
			{
				XmlTextWriter w = new XmlTextWriter("c:\\eps_data.xml", System.Text.Encoding.Default);
				w.WriteStartDocument();
				w.WriteStartElement ("ROOT");
				w.WriteStartElement ("FROM");
				w.WriteElementString ("FROM_NAME", lblSenderName.Text);
				w.WriteElementString ("FROM_EMAIL", lblSenderEmail.Text);
				w.WriteEndElement();
				w.WriteStartElement ("TO");
				w.WriteElementString ("TO_NAME", lblRecipientName.Text);
				w.WriteElementString ("TO_EMAIL", lblRecipientEmail.Text);
				w.WriteEndElement();
				w.WriteEndDocument();
				w.Close();
			}
			Response.Redirect (strURL + Session["CallerSendMail"].ToString() + ".aspx?");
		}

	}
}
