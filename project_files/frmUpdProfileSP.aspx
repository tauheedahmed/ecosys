<%@ Page language="c#" Inherits="WebApplication2.frmUpdProfileSp" CodeFile="frmUpdProfileSP.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 39px; POSITION: absolute; TOP: 52px" runat="server" Width="675px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblContent3" style="Z-INDEX: 108; LEFT: 39px; POSITION: absolute; TOP: 120px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="675px"></asp:label>
			<asp:label id="lblContent2" style="Z-INDEX: 107; LEFT: 39px; POSITION: absolute; TOP: 89px" runat="server" ForeColor="Navy" Font-Size="Small" Height="25px" Width="675px"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 106; LEFT: 201px; POSITION: absolute; TOP: 376px" runat="server" Width="152px" Height="48px" ForeColor="White" Text="Cancel" BackColor="Red" BorderStyle="None" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 105; LEFT: 39px; POSITION: absolute; TOP: 12px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:label id="lblDesc" style="Z-INDEX: 104; LEFT: 39px; POSITION: absolute; TOP: 160px" runat="server" Width="76px" Height="27px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Description</asp:label><asp:textbox id="txtDescription" style="Z-INDEX: 102; LEFT: 38px; POSITION: absolute; TOP: 187px" runat="server" Width="689px" Height="165px" ForeColor="Navy" BackColor="White" BorderStyle="Solid" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 39px; POSITION: absolute; TOP: 375px" runat="server" Width="152px" Height="48px" ForeColor="White" Text="Action" BackColor="Red" BorderStyle="None" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
