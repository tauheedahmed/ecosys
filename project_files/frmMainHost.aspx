<%@ Page language="c#" Inherits="WebApplication2.MainHost" CodeFile="frmMainHost.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body text="maroon" bgColor="#ffffff">
		<form id="Main" method="post" runat="server">
			<asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 155px; POSITION: absolute; TOP: 149px" runat="server" BorderStyle="None" BackColor="Navy" Height="36px" Width="242" Text="Exit" Font-Size="X-Small" ForeColor="White" Font-Bold="True" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnControlReport" style="Z-INDEX: 110; LEFT: 155px; POSITION: absolute; TOP: 312px" runat="server" ForeColor="Navy" Font-Size="X-Small" Text="Generate Control Report" Width="242px" Height="31" BackColor="White" BorderStyle="Solid" BorderColor="Navy" BorderWidth="1px" onclick="btnControlReport_Click"></asp:button>
			<asp:button id="btnMsg" style="Z-INDEX: 109; LEFT: 155px; POSITION: absolute; TOP: 272px" runat="server" ForeColor="Navy" Font-Size="X-Small" Text="Update Menu Message" Width="242px" Height="31" BackColor="White" BorderStyle="Solid" BorderWidth="1px" BorderColor="Navy" onclick="btnMsg_Click"></asp:button><asp:label id="lblUser" style="Z-INDEX: 107; LEFT: 155px; POSITION: absolute; TOP: 592px" runat="server" Height="21px" Width="797px" Font-Size="X-Small" ForeColor="Navy" Font-Italic="True"></asp:label><asp:label id="lblLic" style="Z-INDEX: 106; LEFT: 162px; POSITION: absolute; TOP: 560px" runat="server" Height="11px" Width="849px" Font-Size="XX-Small" ForeColor="Navy"></asp:label><asp:button id="lblNew" style="Z-INDEX: 105; LEFT: 155px; POSITION: absolute; TOP: 194px" runat="server" BorderStyle="Solid" BackColor="White" Height="31" Width="242px" Text="Issue New Licenses" Font-Size="X-Small" ForeColor="Navy" BorderColor="Navy" BorderWidth="1px" onclick="lblNew_Click"></asp:button><asp:button id="btnLicenses" style="Z-INDEX: 104; LEFT: 155px; POSITION: absolute; TOP: 233px" runat="server" BorderStyle="Solid" BackColor="White" Height="31" Width="242px" Text="Manage Existing Licenses" Font-Size="X-Small" ForeColor="Navy" BorderColor="Navy" BorderWidth="1px" onclick="btnLicenses_Click"></asp:button><asp:label id="lblTitle" style="Z-INDEX: 103; LEFT: 155px; POSITION: absolute; TOP: 37px" runat="server" BackColor="White" Height="18px" Width="775px" Font-Size="Medium" ForeColor="Navy"></asp:label><asp:label id="lblMsg" style="Z-INDEX: 102; LEFT: 155px; POSITION: absolute; TOP: 456px" runat="server" BackColor="White" Height="25px" Width="542px" Font-Size="Small" ForeColor="Crimson"></asp:label><asp:label id="lblOrg" style="Z-INDEX: 100; LEFT: 155px; POSITION: absolute; TOP: 76px" runat="server" Height="18px" Width="693px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label></form>
	</body>
</HTML>
