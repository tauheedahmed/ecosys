<%@ Page language="c#" Inherits="WebApplication2.frmUpdCourses" CodeFile="frmUpdCourse.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 50px" runat="server" Width="675px" Height="30px" Font-Size="Small" ForeColor="Navy"> Function Title</asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 114; LEFT: 315px; POSITION: absolute; TOP: 415px" runat="server" ForeColor="White" Height="48px" Width="152px" BorderStyle="None" Font-Bold="True" BackColor="Red" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:label id="Label3" style="Z-INDEX: 113; LEFT: 399px; POSITION: absolute; TOP: 341px" runat="server" ForeColor="Navy" Width="193px" BorderStyle="None" Font-Size="Small">Responsible Unit/Team</asp:label>
			<asp:dropdownlist id="lstOrgs" style="Z-INDEX: 112; LEFT: 591px; POSITION: absolute; TOP: 337px" runat="server" ForeColor="Navy" Height="201px" Width="257px"></asp:dropdownlist>
			<asp:label id="Label2" style="Z-INDEX: 111; LEFT: 10px; POSITION: absolute; TOP: 297px" runat="server" ForeColor="Navy" Width="131px" BorderStyle="None" Font-Size="Small">Type of Service</asp:label>
			<asp:dropdownlist id="lstType" style="Z-INDEX: 110; LEFT: 151px; POSITION: absolute; TOP: 294px" runat="server" ForeColor="Navy" Height="201px" Width="245px"></asp:dropdownlist><asp:label id="Label1" style="Z-INDEX: 109; LEFT: 487px; POSITION: absolute; TOP: 297px" runat="server" Width="97px" ForeColor="Navy" BorderStyle="None" Font-Size="Small">Availability</asp:label><asp:dropdownlist id="lstAvail" style="Z-INDEX: 108; LEFT: 590px; POSITION: absolute; TOP: 294px" runat="server" Width="257px" Height="30px" ForeColor="Navy">
				<asp:ListItem Value="Public">Public Use</asp:ListItem>
				<asp:ListItem Value="Institution">Institutional Use</asp:ListItem>
			</asp:dropdownlist><asp:label id="lblOrg" style="Z-INDEX: 107; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label>
			<asp:label id="lblDesc" style="Z-INDEX: 106; LEFT: 33px; POSITION: absolute; TOP: 165px" runat="server" Width="108px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Description</asp:label><asp:label id="lblProcName" style="Z-INDEX: 105; LEFT: 84px; POSITION: absolute; TOP: 113px" runat="server" Width="57px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 151px; POSITION: absolute; TOP: 113px" runat="server" Width="696px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtDesc" style="Z-INDEX: 102; LEFT: 151px; POSITION: absolute; TOP: 161px" runat="server" Width="696px" Height="116px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 149px; POSITION: absolute; TOP: 415px" runat="server" Width="152px" Height="48px" ForeColor="White" BorderStyle="None" Font-Bold="True" BackColor="Red" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
