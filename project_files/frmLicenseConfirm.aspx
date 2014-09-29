<%@ Page language="c#" Inherits="WebApplication2.frmLicenseConfirm" CodeFile="frmLicenseConfirm.aspx.cs" %>
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
			<asp:button id="btnCancel" style="Z-INDEX: 111; LEFT: 715px; POSITION: absolute; TOP: 544px" runat="server" Width="153" Height="48" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Red" Text="Cancel" Visible="False" onclick="btnCancel_Click"></asp:button><asp:label id="lblThanks" style="Z-INDEX: 110; LEFT: 87px; POSITION: absolute; TOP: 179px" runat="server" Width="700px" Height="153px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label><asp:label id="Label11" style="Z-INDEX: 109; LEFT: 682px; POSITION: absolute; TOP: 374px" runat="server" Width="379px" Height="20px" Font-Size="Small" ForeColor="Red" Visible="False">  User ID and Password</asp:label><asp:textbox id="txtPasswordcheck" style="Z-INDEX: 108; LEFT: 805px; POSITION: absolute; TOP: 501px" runat="server" Width="63px" Height="18px" ForeColor="#000099" BorderStyle="Solid" BackColor="White" TextMode="Password" Visible="False"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 105; LEFT: 616px; POSITION: absolute; TOP: 461px" runat="server" Width="12px" Height="30px" Font-Size="Medium" ForeColor="Navy" BorderStyle="None" Visible="False">Password</asp:label><asp:label id="Label3" style="Z-INDEX: 103; LEFT: 614px; POSITION: absolute; TOP: 421px" runat="server" Width="11px" Height="22px" Font-Size="Medium" ForeColor="Navy" BorderStyle="None" Visible="False">User Id</asp:label><asp:textbox id="txtPassword" style="Z-INDEX: 107; LEFT: 805px; POSITION: absolute; TOP: 461px" runat="server" Width="63px" Height="18px" ForeColor="#000099" BorderStyle="Solid" BackColor="White" TextMode="Password" Visible="False"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 106; LEFT: 613px; POSITION: absolute; TOP: 501px" runat="server" Width="1px" Height="22px" Font-Size="Medium" ForeColor="Navy" BorderStyle="None" Visible="False">Re-Enter Password</asp:label><asp:button id="btnContinue" style="Z-INDEX: 102; LEFT: 541px; POSITION: absolute; TOP: 543px" runat="server" Width="153" Height="48" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Red" Text="Continue" Visible="False" onclick="btnContinue_Click"></asp:button><asp:textbox id="txtUserId" style="Z-INDEX: 100; LEFT: 805px; POSITION: absolute; TOP: 421px" runat="server" Width="63px" Height="18px" ForeColor="#000099" BorderStyle="Solid" BackColor="White" Visible="False"></asp:textbox></form>
	</body>
</HTML>
