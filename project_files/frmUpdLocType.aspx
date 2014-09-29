<%@ Page language="c#" Inherits="WebApplication2.frmUpdLocType" CodeFile="frmUpdLocType.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 49px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="675px"> Function Title</asp:label>
			<asp:dropdownlist id="lstVisibility" style="Z-INDEX: 121; LEFT: 150px; POSITION: absolute; TOP: 293px" runat="server" Width="496px" Height="10px" ForeColor="Navy"></asp:dropdownlist>
			<asp:label id="lblVisibility" style="Z-INDEX: 120; LEFT: 57px; POSITION: absolute; TOP: 290px" runat="server" Width="43px" Height="20px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Visibility</asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 314px; POSITION: absolute; TOP: 326px" runat="server" Width="152px" Height="48px" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:label id="lblOrg" style="Z-INDEX: 107; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label>
			<asp:label id="lblDesc" style="Z-INDEX: 106; LEFT: 42px; POSITION: absolute; TOP: 155px" runat="server" ForeColor="Navy" Font-Size="Small" Height="40px" Width="99px" BorderStyle="None">Description</asp:label><asp:label id="lblProcName" style="Z-INDEX: 105; LEFT: 90px; POSITION: absolute; TOP: 97px" runat="server" ForeColor="Navy" Font-Size="Small" Height="40px" Width="48px" BorderStyle="None"> Name</asp:label><asp:textbox id="txtLocTypeName" style="Z-INDEX: 101; LEFT: 149px; POSITION: absolute; TOP: 98px" runat="server" ForeColor="Navy" Height="36px" Width="545px" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtDesc" style="Z-INDEX: 102; LEFT: 149px; POSITION: absolute; TOP: 149px" runat="server" ForeColor="Navy" Height="133px" Width="545px" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 104; LEFT: 148px; POSITION: absolute; TOP: 325px" runat="server" ForeColor="White" Height="48px" Width="152px" BorderStyle="None" BackColor="Navy" Text="Action" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
