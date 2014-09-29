<%@ Page language="c#" Inherits="WebApplication2.frmUpdBackups" CodeFile="frmUpdBackups.aspx.cs" %>
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
			<asp:label id="lblAction" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 76px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="842px"> Action</asp:label>
			<asp:RadioButtonList id="rblScope" style="Z-INDEX: 114; LEFT: 274px; POSITION: absolute; TOP: 325px" runat="server" Width="276px" Height="46px" ForeColor="Navy" BorderStyle="None" BorderColor="Navy" BorderWidth="2px">
<asp:ListItem Value="Full" Selected="True">Full Backup</asp:ListItem>
<asp:ListItem Value="Incremental">Incremental</asp:ListItem>
			</asp:RadioButtonList>
			<asp:label id="lblScope" style="Z-INDEX: 113; LEFT: 201px; POSITION: absolute; TOP: 328px" runat="server" Width="53px" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Scope</asp:label>
			<asp:label id="lblRet" style="Z-INDEX: 112; LEFT: 126px; POSITION: absolute; TOP: 279px" runat="server" Width="137px" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Retention Period</asp:label>
			<asp:textbox id="txtTiming" style="Z-INDEX: 105; LEFT: 274px; POSITION: absolute; TOP: 217px" runat="server" Width="280px" Height="30px" ForeColor="#000099" BorderStyle="Solid" BackColor="White" BorderColor="Navy"></asp:textbox>
			<asp:label id="lblBackup" style="Z-INDEX: 111; LEFT: 581px; POSITION: absolute; TOP: 143px" runat="server" Width="212px" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Backup Copy</asp:label>
			<asp:DropDownList id="lstBackup" style="Z-INDEX: 110; LEFT: 580px; POSITION: absolute; TOP: 173px" runat="server" Width="281px" Height="201px" ForeColor="Navy"></asp:DropDownList><asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 439px; POSITION: absolute; TOP: 405px" runat="server" ForeColor="White" Height="48px" Width="152px" BorderStyle="None" BackColor="Red" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblTiming" style="Z-INDEX: 107; LEFT: 196px; POSITION: absolute; TOP: 220px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="75px" BorderStyle="None">Timing</asp:label><asp:textbox id="txtRetention" style="Z-INDEX: 106; LEFT: 274px; POSITION: absolute; TOP: 270px" runat="server" ForeColor="#000099" Height="30px" Width="284px" BorderStyle="Solid" BackColor="White" BorderColor="Navy"></asp:textbox><asp:label id="lblOriginal" style="Z-INDEX: 104; LEFT: 274px; POSITION: absolute; TOP: 146px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="248px" BorderStyle="None">Original Resource</asp:label><asp:label id="lblBackups" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 42px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="841px">Backups</asp:label><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 2px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnAction" style="Z-INDEX: 101; LEFT: 272px; POSITION: absolute; TOP: 404px" runat="server" ForeColor="White" Height="48px" Width="152px" BorderStyle="None" BackColor="Red" Font-Bold="True" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:DropDownList id="lstOriginal" style="Z-INDEX: 109; LEFT: 274px; POSITION: absolute; TOP: 175px" runat="server" Width="281px" Height="201px" ForeColor="Navy"></asp:DropDownList></form>
	</body>
</HTML>
