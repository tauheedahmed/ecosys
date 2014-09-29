<%@ Page language="c#" Inherits="WebApplication2.frmUpdStage" CodeFile="frmUpdstage.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 50px" runat="server" Width="675px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:dropdownlist id="lstVisibility" style="Z-INDEX: 109; LEFT: 151px; POSITION: absolute; TOP: 172px" runat="server" ForeColor="Navy" Height="30px" Width="517px"></asp:dropdownlist>
			<asp:label id="Label1" style="Z-INDEX: 107; LEFT: 66px; POSITION: absolute; TOP: 171px" runat="server" ForeColor="Navy" Font-Size="Small" Width="77px" BorderStyle="None">Visibility</asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 268px; POSITION: absolute; TOP: 205px" runat="server" ForeColor="White" Height="48px" Width="107px" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 106; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:label id="lblProcName" style="Z-INDEX: 104; LEFT: 94px; POSITION: absolute; TOP: 109px" runat="server" Width="40px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 151px; POSITION: absolute; TOP: 113px" runat="server" Width="516px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 151px; POSITION: absolute; TOP: 204px" runat="server" Width="107px" Height="48px" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
