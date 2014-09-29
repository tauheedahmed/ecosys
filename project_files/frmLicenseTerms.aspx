<%@ Page language="c#" Inherits="WebApplication2.frmLicenseTerms" CodeFile="frmLicenseTerms.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmAddProcedure</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmAddProcedure" method="post" runat="server">
			<asp:button id="btnAccept" style="Z-INDEX: 101; LEFT: 866px; POSITION: absolute; TOP: 159px" runat="server" BorderStyle="None" BackColor="Red" Text="I Accept" Width="153" Height="48" ForeColor="White" Font-Bold="True" onclick="btnAccept_Click"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 106; LEFT: 866px; POSITION: absolute; TOP: 219px" runat="server" BorderStyle="None" BackColor="Red" Text="Cancel" Width="153" Height="48" ForeColor="White" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:textbox id="txtEula" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 157px" runat="server" BorderStyle="Solid" BackColor="White" Width="821px" Height="458px" ForeColor="#000099" Font-Size="XX-Small" TextMode="MultiLine"></asp:textbox><asp:label id="lblInstruction" style="Z-INDEX: 103; LEFT: 14px; POSITION: absolute; TOP: 71px" runat="server" Width="914px" Height="16px" ForeColor="Navy" Font-Size="Small">Please read the End User License Agreement below carefully.  Acceptance of these terms is necessary in order to use the system. If you  accept these terms, click on the "I Accept" button. If you  do not accept these terms, click on the "Cancel" button.</asp:label><asp:label id="Label13" style="Z-INDEX: 104; LEFT: 14px; POSITION: absolute; TOP: 13px" runat="server" Width="418px" Height="33px" ForeColor="Navy" Font-Size="Small">  End User License Agreement</asp:label></form>
	</body>
</HTML>
