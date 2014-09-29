<%@ Page language="c#" Inherits="WebApplication2.frmUpdOutputs" CodeFile="frmUpdServices.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 69px" runat="server" Width="543px" Height="23px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblOrg1" style="Z-INDEX: 115; LEFT: 0px; POSITION: absolute; TOP: 35px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="831px" Font-Bold="True"></asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 114; LEFT: 314px; POSITION: absolute; TOP: 443px" runat="server" ForeColor="White" Height="48px" Width="152px" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:label id="Label3" style="Z-INDEX: 113; LEFT: 18px; POSITION: absolute; TOP: 362px" runat="server" ForeColor="Navy" Width="122px" BorderStyle="None" Font-Size="Small" Height="17px">Responsible Unit/Team</asp:label>
			<asp:dropdownlist id="lstOrgs" style="Z-INDEX: 112; LEFT: 150px; POSITION: absolute; TOP: 369px" runat="server" ForeColor="Navy" Height="201px" Width="387px"></asp:dropdownlist>
			<asp:label id="lblService" style="Z-INDEX: 111; LEFT: 12px; POSITION: absolute; TOP: 279px" runat="server" ForeColor="Navy" Width="131px" BorderStyle="None" Font-Size="Small">Type of Service</asp:label>
			<asp:dropdownlist id="lstType" style="Z-INDEX: 110; LEFT: 153px; POSITION: absolute; TOP: 280px" runat="server" ForeColor="Navy" Height="201px" Width="387px"></asp:dropdownlist><asp:label id="Label1" style="Z-INDEX: 109; LEFT: 54px; POSITION: absolute; TOP: 320px" runat="server" Width="79px" ForeColor="Navy" BorderStyle="None" Font-Size="Small">Visibility</asp:label><asp:dropdownlist id="lstVisibility" style="Z-INDEX: 108; LEFT: 154px; POSITION: absolute; TOP: 319px" runat="server" Width="387px" Height="30px" ForeColor="Navy"></asp:dropdownlist>
			<asp:label id="lblDesc" style="Z-INDEX: 105; LEFT: 48px; POSITION: absolute; TOP: 165px" runat="server" Width="94px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Description</asp:label><asp:label id="lblProcName" style="Z-INDEX: 104; LEFT: 84px; POSITION: absolute; TOP: 113px" runat="server" Width="57px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 151px; POSITION: absolute; TOP: 113px" runat="server" Width="387" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtDesc" style="Z-INDEX: 102; LEFT: 151px; POSITION: absolute; TOP: 161px" runat="server" Width="387" Height="106px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 148px; POSITION: absolute; TOP: 443px" runat="server" Width="152px" Height="48px" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
