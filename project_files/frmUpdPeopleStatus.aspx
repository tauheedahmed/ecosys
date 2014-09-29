<%@ Page language="c#" Inherits="WebApplication2.frmUpdPeopleStatus" CodeFile="frmUpdPeopleStatus.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 49px" runat="server" Width="675px" Height="20px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:DropDownList id="lstAvail" style="Z-INDEX: 111; LEFT: 548px; POSITION: absolute; TOP: 299px" runat="server" Height="201px" Width="281px" Visible="False" ForeColor="Navy">
				<asp:ListItem Value="Owner">Owner</asp:ListItem>
				<asp:ListItem Value="Organization">Organization</asp:ListItem>
				<asp:ListItem Value="Public">Public</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList id="lstStages" style="Z-INDEX: 110; LEFT: 123px; POSITION: absolute; TOP: 286px" runat="server" Height="201px" Width="281px" ForeColor="Navy"></asp:DropDownList>
			<asp:label id="lblStage" style="Z-INDEX: 109; LEFT: 58px; POSITION: absolute; TOP: 279px" runat="server" Width="52px" Height="23px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Stage</asp:label><asp:button id="btnCancel" style="Z-INDEX: 107; LEFT: 282px; POSITION: absolute; TOP: 320px" runat="server" Width="152px" Height="48px" ForeColor="White" Text="Cancel" BackColor="Red" BorderStyle="None" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 106; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label><asp:label id="lblDesc" style="Z-INDEX: 105; LEFT: 141px; POSITION: absolute; TOP: 175px" runat="server" Width="96px" Height="27px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Start Time</asp:label><asp:label id="lblProcName" style="Z-INDEX: 104; LEFT: 96px; POSITION: absolute; TOP: 134px" runat="server" Width="147px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Service Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 259px; POSITION: absolute; TOP: 135px" runat="server" Width="409px" Height="30px" ForeColor="Navy" BackColor="White" BorderStyle="Solid" ontextchanged="txtName_TextChanged"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 103; LEFT: 123px; POSITION: absolute; TOP: 319px" runat="server" Width="152px" Height="48px" ForeColor="White" Text="Action" BackColor="Red" BorderStyle="None" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
