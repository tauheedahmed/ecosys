<%@ Page language="c#" Inherits="WebApplication2.frmUpdProjectType" CodeFile="frmUpdProjectType.aspx.cs" %>
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
			<asp:label id="lblComment" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 96px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="675px"></asp:label>
			<asp:label id="Label3" style="Z-INDEX: 115; LEFT: 64px; POSITION: absolute; TOP: 296px" runat="server" Width="77px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Service</asp:label>
			<asp:dropdownlist id="lstService" style="Z-INDEX: 114; LEFT: 152px; POSITION: absolute; TOP: 296px" runat="server" Width="515px" Height="30px" ForeColor="Navy"></asp:dropdownlist>
			<asp:label id="lblTitle" style="Z-INDEX: 113; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="775px" Height="18px" Font-Size="Medium" ForeColor="Navy" BackColor="White"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 56px" runat="server" Width="693px" Height="18px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:textbox id="txtSeq" style="Z-INDEX: 112; LEFT: 152px; POSITION: absolute; TOP: 336px" runat="server" Width="64px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:label id="Label2" style="Z-INDEX: 107; LEFT: 63px; POSITION: absolute; TOP: 256px" runat="server" Width="77px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Visibility</asp:label><asp:button id="btnCancel" style="Z-INDEX: 111; LEFT: 320px; POSITION: absolute; TOP: 376px" runat="server" ForeColor="White" Height="48px" Width="152px" Text="Cancel" BackColor="Navy" Font-Bold="True" BorderStyle="None" onclick="btnCancel_Click"></asp:button><asp:dropdownlist id="lstVisibility" style="Z-INDEX: 110; LEFT: 152px; POSITION: absolute; TOP: 256px" runat="server" ForeColor="Navy" Height="30px" Width="515px"></asp:dropdownlist><asp:label id="Label1" style="Z-INDEX: 109; LEFT: 63px; POSITION: absolute; TOP: 336px" runat="server" ForeColor="Navy" Font-Size="Small" Width="77px" BorderStyle="None">Sequence</asp:label><asp:label id="lblNameShort" style="Z-INDEX: 106; LEFT: 27px; POSITION: absolute; TOP: 216px" runat="server" Font-Names="navy" ForeColor="Navy" Font-Size="Small" Height="20px" Width="121px" BorderStyle="None">Singular Name</asp:label><asp:label id="lblProcName" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 176px" runat="server" Font-Names="navy" ForeColor="Navy" Font-Size="Small" Height="28px" Width="105px" BorderStyle="None"> Plural Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 102; LEFT: 151px; POSITION: absolute; TOP: 176px" runat="server" ForeColor="Navy" Height="30px" Width="513px" BackColor="White" BorderStyle="Solid"></asp:textbox><asp:textbox id="txtNameshort" style="Z-INDEX: 103; LEFT: 151px; POSITION: absolute; TOP: 216px" runat="server" ForeColor="Navy" Height="32px" Width="513px" BackColor="White" BorderStyle="Solid"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 104; LEFT: 157px; POSITION: absolute; TOP: 376px" runat="server" ForeColor="White" Height="48px" Width="152px" Text="Action" BackColor="Navy" Font-Bold="True" BorderStyle="None" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
