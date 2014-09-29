<%@ Page language="c#" Inherits="WebApplication2.frmUpdActsJ" CodeFile="frmUpdActsJ.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 50px" runat="server" Width="919px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="Label12" style="Z-INDEX: 113; LEFT: 94px; POSITION: absolute; TOP: 238px" runat="server" Width="100px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Increase By:</asp:label>
			<asp:label id="Label10" style="Z-INDEX: 112; LEFT: 30px; POSITION: absolute; TOP: 280px" runat="server" Width="158px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Reason for Change:</asp:label>
			<asp:TextBox id="txtDesc" style="Z-INDEX: 111; LEFT: 204px; POSITION: absolute; TOP: 281px" runat="server" Width="477px" Height="70px"></asp:TextBox>
			<asp:label id="Label7" style="Z-INDEX: 110; LEFT: 409px; POSITION: absolute; TOP: 235px" runat="server" Width="34px" Font-Size="Small" ForeColor="Navy" BorderStyle="None" Height="18px">OR</asp:label>
			<asp:label id="Label4" style="Z-INDEX: 105; LEFT: 472px; POSITION: absolute; TOP: 235px" runat="server" Width="110px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Decrease By:</asp:label>
			<asp:TextBox id="txtAmtInc" style="Z-INDEX: 103; LEFT: 203px; POSITION: absolute; TOP: 237px" runat="server" Width="172px" Height="25px"></asp:TextBox><asp:button id="btnAction" style="Z-INDEX: 108; LEFT: 33px; POSITION: absolute; TOP: 91px" runat="server" Height="34px" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="OK" Width="96px" onclick="btnAct_Click"></asp:button><asp:label id="lblFundAmt" style="Z-INDEX: 107; LEFT: 275px; POSITION: absolute; TOP: 187px" runat="server" Width="345px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"></asp:label><asp:label id="Label3" style="Z-INDEX: 106; LEFT: 88px; POSITION: absolute; TOP: 185px" runat="server" Width="172px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Current Fund Amount</asp:label><asp:button id="btnCancel" style="Z-INDEX: 102; LEFT: 145px; POSITION: absolute; TOP: 92px" runat="server" ForeColor="White" Height="34px" Width="107px" BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label>
			<asp:TextBox id="txtAmtDec" style="Z-INDEX: 104; LEFT: 593px; POSITION: absolute; TOP: 236px" runat="server" Width="172px" Height="24px"></asp:TextBox></form>
	</body>
</HTML>
