<%@ Page language="c#" Inherits="WebApplication2.frmUpdPayment" CodeFile="frmUpdPayment.aspx.cs" %>
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
			<asp:label id="lblContents1" style="Z-INDEX: 117; LEFT: 16px; POSITION: absolute; TOP: 216px" runat="server" Font-Size="Small" ForeColor="Navy" BorderStyle="None"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 118; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:label id="lblLoc" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server" Height="24px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 64px" runat="server" Height="24px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:label id="lblBd" style="Z-INDEX: 110; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:label id="lblDel" style="Z-INDEX: 113; LEFT: 8px; POSITION: absolute; TOP: 112px" runat="server" Height="24px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:label id="lblTask" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 136px" runat="server" Height="24px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label>
			<asp:label id="lblRole" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 160px" runat="server" Height="24px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label><asp:label id="Label3" style="Z-INDEX: 116; LEFT: 48px; POSITION: absolute; TOP: 504px" runat="server" Width="114px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Payment Date</asp:label><asp:textbox id="txtPayDate" style="Z-INDEX: 114; LEFT: 168px; POSITION: absolute; TOP: 496px" runat="server" Width="176px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BorderColor="Navy" BackColor="White"></asp:textbox><asp:label id="Label2" style="Z-INDEX: 112; LEFT: 104px; POSITION: absolute; TOP: 448px" runat="server" Width="51px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Status</asp:label><asp:dropdownlist id="lstStatus" style="Z-INDEX: 111; LEFT: 168px; POSITION: absolute; TOP: 448px" runat="server" Width="180px" Height="30px" ForeColor="Navy">
				<asp:ListItem Value="0">Plan</asp:ListItem>
				<asp:ListItem Value="1">Actual</asp:ListItem>
				<asp:ListItem Value="2">Cancel</asp:ListItem>
			</asp:dropdownlist><asp:label id="lblDesc" style="Z-INDEX: 107; LEFT: 16px; POSITION: absolute; TOP: 344px" runat="server" Font-Size="Small" ForeColor="Navy" BorderStyle="None"></asp:label><asp:label id="Label1" style="Z-INDEX: 105; LEFT: 24px; POSITION: absolute; TOP: 560px" runat="server" Width="137px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Payment Amount</asp:label><asp:textbox id="txtPayAmt" style="Z-INDEX: 104; LEFT: 168px; POSITION: absolute; TOP: 552px" runat="server" Width="176px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BorderColor="Navy" BackColor="White"></asp:textbox><asp:label id="lblCurrency" style="Z-INDEX: 102; LEFT: 360px; POSITION: absolute; TOP: 560px" runat="server" Font-Size="Small" ForeColor="Navy" BorderStyle="None"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 103; LEFT: 136px; POSITION: absolute; TOP: 280px" runat="server" Width="107px" Height="34px" ForeColor="White" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnAction" style="Z-INDEX: 100; LEFT: 16px; POSITION: absolute; TOP: 280px" runat="server" Width="107px" Height="34px" ForeColor="White" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
