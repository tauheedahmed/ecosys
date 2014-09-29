<%@ Page language="c#" Inherits="WebApplication2.frmUpdContact" CodeFile="frmUpdContact.aspx.cs" %>
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
			<asp:label id="Label4" style="Z-INDEX: 115; LEFT: 104px; POSITION: absolute; TOP: 233px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="40px" BorderStyle="None">Email</asp:label>
			<asp:label id="Label3" style="Z-INDEX: 114; LEFT: 59px; POSITION: absolute; TOP: 185px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="92px" BorderStyle="None">Cell Phone</asp:label>
			<asp:label id="Label2" style="Z-INDEX: 113; LEFT: 12px; POSITION: absolute; TOP: 146px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="139px" BorderStyle="None">Regular Phone(s)</asp:label>
			<asp:textbox id="txtEmail" style="Z-INDEX: 111; LEFT: 163px; POSITION: absolute; TOP: 231px" runat="server" ForeColor="Navy" Height="32" Width="219" BorderStyle="Solid" BackColor="White" ontextchanged="Textbox3_TextChanged"></asp:textbox>
			<asp:textbox id="txtCellPhone" style="Z-INDEX: 110; LEFT: 163px; POSITION: absolute; TOP: 183px" runat="server" ForeColor="Navy" Height="32px" Width="219px" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:textbox id="txtRegularPhone" style="Z-INDEX: 109; LEFT: 163px; POSITION: absolute; TOP: 141px" runat="server" ForeColor="Navy" Height="32px" Width="219px" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 280px; POSITION: absolute; TOP: 414px" runat="server" ForeColor="White" Height="40px" Width="107px" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 107; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label>
			<asp:label id="lblDesc" style="Z-INDEX: 106; LEFT: 83px; POSITION: absolute; TOP: 284px" runat="server" Width="68px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Address</asp:label><asp:label id="lblProcName" style="Z-INDEX: 104; LEFT: 105px; POSITION: absolute; TOP: 109px" runat="server" Width="40px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 163px; POSITION: absolute; TOP: 102px" runat="server" Width="333px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtAddress" style="Z-INDEX: 102; LEFT: 163px; POSITION: absolute; TOP: 277px" runat="server" Width="516px" Height="116px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 163px; POSITION: absolute; TOP: 413px" runat="server" Width="107px" Height="40px" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
