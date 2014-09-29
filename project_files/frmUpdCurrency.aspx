<%@ Page language="c#" Inherits="WebApplication2.frmUpdCurrency" CodeFile="frmUpdCurrency.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 49px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px"></asp:label>
			<asp:textbox id="txtCurrCode" style="Z-INDEX: 110; LEFT: 232px; POSITION: absolute; TOP: 184px" runat="server" Width="185px" Height="28px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:label id="Label1" style="Z-INDEX: 109; LEFT: 96px; POSITION: absolute; TOP: 184px" runat="server" Width="122px" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Currency Code</asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 280px; POSITION: absolute; TOP: 240px" runat="server" Width="141px" Height="40px" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:label id="lblOrg" style="Z-INDEX: 107; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Font-Bold="True"></asp:label>
			<asp:label id="lblDesc" style="Z-INDEX: 106; LEFT: 118px; POSITION: absolute; TOP: 152px" runat="server" ForeColor="Navy" Font-Size="Small" Height="27px" Width="103px" BorderStyle="None">Plural Name</asp:label><asp:label id="lblNameS" style="Z-INDEX: 105; LEFT: 93px; POSITION: absolute; TOP: 113px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="122px" BorderStyle="None"> Singular Name</asp:label><asp:textbox id="txtNameS" style="Z-INDEX: 102; LEFT: 232px; POSITION: absolute; TOP: 114px" runat="server" ForeColor="Navy" Height="28" Width="185" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtNameP" style="Z-INDEX: 103; LEFT: 232px; POSITION: absolute; TOP: 148px" runat="server" ForeColor="Navy" Height="28px" Width="185px" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 104; LEFT: 112px; POSITION: absolute; TOP: 240px" runat="server" ForeColor="White" Height="40px" Width="141px" BorderStyle="None" BackColor="Navy" Text="Action" Font-Bold="True" onclick="btnAction_Click"></asp:button>
			<asp:CheckBox id="cbxStatus" style="Z-INDEX: 111; LEFT: 504px; POSITION: absolute; TOP: 120px" runat="server" ForeColor="Navy" Text="Check if InActive"></asp:CheckBox></form>
	</body>
</HTML>
