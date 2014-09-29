<%@ Page language="c#" Inherits="WebApplication2.frmUpdContactType" CodeFile="frmUpdContactType.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 49px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="675px"></asp:label>
			<asp:dropdownlist id="lstVisibility" style="Z-INDEX: 114; LEFT: 231px; POSITION: absolute; TOP: 283px" runat="server" Width="501px" Height="201px" ForeColor="Navy"></asp:dropdownlist>
			<asp:label id="lblVisibility" style="Z-INDEX: 113; LEFT: 144px; POSITION: absolute; TOP: 285px" runat="server" Width="43px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Visibility</asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 396px; POSITION: absolute; TOP: 325px" runat="server" Width="141px" Height="40px" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="Red" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:label id="lblOrg" style="Z-INDEX: 107; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label>
			<asp:label id="lblDesc" style="Z-INDEX: 106; LEFT: 126px; POSITION: absolute; TOP: 152px" runat="server" ForeColor="Navy" Font-Size="Small" Height="27px" Width="12px" BorderStyle="None">Description</asp:label><asp:label id="lblProcName" style="Z-INDEX: 104; LEFT: 165px; POSITION: absolute; TOP: 113px" runat="server" ForeColor="Navy" Font-Size="Medium" Height="26px" Width="38px" BorderStyle="None"> Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 230px; POSITION: absolute; TOP: 114px" runat="server" ForeColor="Navy" Height="26px" Width="496px" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtDesc" style="Z-INDEX: 102; LEFT: 230px; POSITION: absolute; TOP: 148px" runat="server" ForeColor="Navy" Height="126px" Width="497px" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 230px; POSITION: absolute; TOP: 324px" runat="server" ForeColor="White" Height="40px" Width="141px" BorderStyle="None" BackColor="Red" Text="Action" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
