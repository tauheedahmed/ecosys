<%@ Page language="c#" Inherits="WebApplication2.frmUpdSkill" CodeFile="frmUpdSkill.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 46px" runat="server" Width="675px" Height="23px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblVisibility" style="Z-INDEX: 122; LEFT: 60px; POSITION: absolute; TOP: 168px" runat="server" ForeColor="Navy" Font-Size="Small" Height="20px" Width="43px" BorderStyle="None">Visibility</asp:label>
			<asp:dropdownlist id="lstVisibility" style="Z-INDEX: 121; LEFT: 155px; POSITION: absolute; TOP: 164px" runat="server" ForeColor="Navy" Height="10px" Width="496px"></asp:dropdownlist>
			<asp:button id="btnCancel" style="Z-INDEX: 108; LEFT: 269px; POSITION: absolute; TOP: 210px" runat="server" ForeColor="White" Height="48px" Width="107px" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 107; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:label id="lblProcName" style="Z-INDEX: 104; LEFT: 98px; POSITION: absolute; TOP: 111px" runat="server" Width="33px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 153px; POSITION: absolute; TOP: 113px" runat="server" Width="350px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 153px; POSITION: absolute; TOP: 209px" runat="server" Width="107px" Height="48px" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Navy" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
