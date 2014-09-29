<%@ Page language="c#" Inherits="WebApplication2.WebForm1" CodeFile="frmReportGen.aspx.cs" %>
<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<CR:CRYSTALREPORTVIEWER id="CrystalReportViewer1" 
			runat="server" SeparatePages="False" DisplayGroupTree="False" DisplayToolbar="False" HasZoomFactorList="False" 
			HasSearchButton="False" EnableDrillDown="False" HasDrillUpButton="False" 
			HasGotoPageButton="False" HasPageNavigationButtons="False" Height="50px" Width="350px">
			</CR:CRYSTALREPORTVIEWER>
			<asp:button id="Button1" style="Z-INDEX: 102; LEFT: 744px; POSITION: absolute; TOP: 16px" 
			runat="server" Text="Exit" BorderStyle="None" Visible="false" onclick="Button1_Click"></asp:button>
	        <asp:button id="btnPDF" 
            style="Z-INDEX: 102; LEFT: 744px; POSITION: absolute; TOP: 40px" runat="server" 
            Text="PDF" BorderStyle="None" Visible="false" onclick="btnPDF_Click"></asp:button>
            </form>
	
	</body>
</HTML>
