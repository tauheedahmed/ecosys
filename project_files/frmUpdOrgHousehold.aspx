<%@ Page language="c#" Inherits="WebApplication2.frmUpdOrgHousehold" CodeFile="frmUpdOrgHousehold.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Update Organization</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmAddProcedure" method="post" runat="server">
			<asp:label id="lblContent" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 43px" runat="server" Width="675px" Height="25px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 114; LEFT: 310px; POSITION: absolute; TOP: 351px" runat="server" ForeColor="White" Height="48px" Width="152px" Font-Bold="True" BackColor="Red" BorderStyle="None" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:textbox id="txtDesc" style="Z-INDEX: 113; LEFT: 148px; POSITION: absolute; TOP: 134px" runat="server" Width="402px" Height="91px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 105; LEFT: 49px; POSITION: absolute; TOP: 142px" runat="server" Width="93px" Height="40px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Description</asp:label><asp:label id="Label2" style="Z-INDEX: 111; LEFT: 87px; POSITION: absolute; TOP: 262px" runat="server" Width="51px" Height="17px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Email</asp:label><asp:label id="Label1" style="Z-INDEX: 110; LEFT: 53px; POSITION: absolute; TOP: 230px" runat="server" Width="86px" Height="23px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Telephone</asp:label><asp:textbox id="txtEmail" style="Z-INDEX: 109; LEFT: 148px; POSITION: absolute; TOP: 262px" runat="server" Width="402px" Height="25px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtPhone" style="Z-INDEX: 108; LEFT: 148px; POSITION: absolute; TOP: 229px" runat="server" Width="402px" Height="29px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtName" style="Z-INDEX: 107; LEFT: 148px; POSITION: absolute; TOP: 98px" runat="server" Width="402px" Height="32px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="lblOrg" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 6px" runat="server" Font-Bold="True" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblAdd" style="Z-INDEX: 104; LEFT: 69px; POSITION: absolute; TOP: 295px" runat="server" Width="71px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Address</asp:label><asp:label id="lblProcName" style="Z-INDEX: 103; LEFT: 95px; POSITION: absolute; TOP: 104px" runat="server" Width="49px" Height="27px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:textbox id="txtAddr" style="Z-INDEX: 101; LEFT: 148px; POSITION: absolute; TOP: 291px" runat="server" Width="402" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 102; LEFT: 148px; POSITION: absolute; TOP: 350px" runat="server" Font-Bold="True" Width="152px" Height="48px" ForeColor="White" BorderStyle="None" BackColor="Red" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>