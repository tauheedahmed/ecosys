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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace WebApplication2
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class WebForm1 : System.Web.UI.Page
	{
		private static string strURL = 
			System.Configuration.ConfigurationSettings.AppSettings["local_url"];
		private static string strDB =
			System.Configuration.ConfigurationSettings.AppSettings["local_db"];
		private static string strPATH =
			System.Configuration.ConfigurationSettings.AppSettings["local_path"];
        ReportDocument oRpt = new ReportDocument();
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			ReportDocument oRpt=new ReportDocument();
			oRpt.Load (strPATH + Session["ReportName"].ToString());
			oRpt.SetDatabaseLogon("tauheed","tauheed");
			
			CrystalReportViewer1.ParameterFieldInfo = (ParameterFields)Session["ReportParameters"];
			CrystalReportViewer1.ReportSource=oRpt;
            base.OnInit(e);
            //oRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, strPATH + Session["ReportName"].ToString());
         
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void Button1_Click(object sender, System.EventArgs e)
		{

            Response.Redirect (strURL + Session["cRG"].ToString() + ".aspx?");
		}
        protected void btnPDF_Click(object sender, EventArgs e)
        {
            //exportReport();  Needs selectedReport, export Format parameters 
        }
        protected void exportReport(CrystalDecisions.CrystalReports.Engine.ReportClass selectedReport, CrystalDecisions.Shared.ExportFormatType eft)
        {
            selectedReport.ExportOptions.ExportFormatType = eft;

            string contentType = "";
            // Make sure asp.net has create and delete permissions in the directory
            string tempDir = System.Configuration.ConfigurationSettings.AppSettings["TempDir"];
            string tempFileName = Session.SessionID.ToString() + ".";
            switch (eft)
            {
                case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat:
                    tempFileName += "pdf";
                    contentType = "application/pdf";
                    break;
                case CrystalDecisions.Shared.ExportFormatType.WordForWindows:
                    tempFileName += "doc";
                    contentType = "application/msword";
                    break;
                case CrystalDecisions.Shared.ExportFormatType.Excel:
                    tempFileName += "xls";
                    contentType = "application/vnd.ms-excel";
                    break;
                case CrystalDecisions.Shared.ExportFormatType.HTML32:
                case CrystalDecisions.Shared.ExportFormatType.HTML40:
                    tempFileName += "htm";
                    contentType = "text/html";
                    CrystalDecisions.Shared.HTMLFormatOptions hop = new CrystalDecisions.Shared.HTMLFormatOptions();
                    hop.HTMLBaseFolderName = tempDir;
                    hop.HTMLFileName = tempFileName;
                    selectedReport.ExportOptions.FormatOptions = hop;
                    break;
            }

            CrystalDecisions.Shared.DiskFileDestinationOptions dfo = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            dfo.DiskFileName = tempDir + tempFileName;
            selectedReport.ExportOptions.DestinationOptions = dfo;
            selectedReport.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;

            selectedReport.Export();
            selectedReport.Close();

            string tempFileNameUsed;
            if (eft == CrystalDecisions.Shared.ExportFormatType.HTML32 || eft == CrystalDecisions.Shared.ExportFormatType.HTML40)
            {
                string[] fp = selectedReport.FilePath.Split("\\".ToCharArray());
                string leafDir = fp[fp.Length - 1];
                // strip .rpt extension
                leafDir = leafDir.Substring(0, leafDir.Length - 4);
                tempFileNameUsed = string.Format("{0}{1}\\{2}", tempDir, leafDir, tempFileName);
            }
            else
                tempFileNameUsed = tempDir + tempFileName;

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = contentType;

            Response.WriteFile(tempFileNameUsed);
            Response.Flush();
            Response.Close();

            System.IO.File.Delete(tempFileNameUsed);
        }
        // Returns a ReportDocument object with the report and data loaded
         /*private ReportDocument getReportDocument()
            {
               
                // File Path for Crystal Report

           
                // Declare a new Crystal Report Document object
                // and the report file into the report document
                ReportDocument repDoc = new ReportDocument();
                repDoc.Load(repFilePath);
                // Set the datasource by getting the dataset from business
                // layer and
                // In our case business layer is getCustomerData function
                repDoc.SetDataSource(getCustomerData());
                 
            }*/

        // Business layer class to get the data from database
        /*private DataSet getCustomerData()
        {
            
             * string customerFilePath = Server.MapPath("App_Data\\Customers.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(customerFilePath);

        }*/

}
}
