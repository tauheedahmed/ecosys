<%@ Page language="c#" Inherits="WebApplication2.frmUpdAssess" CodeFile="frmRepGen.aspx.cs" %>
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
			<asp:label id="lblAction" style="Z-INDEX: 100; LEFT: 4px; POSITION: absolute; TOP: 40px" runat="server" BorderStyle="None" Width="895px" Height="16px" Font-Size="Medium" ForeColor="#000099" Font-Bold="True"> Update</asp:label>
			<asp:label id="lblAssess" style="Z-INDEX: 111; LEFT: 7px; POSITION: absolute; TOP: 74px" runat="server" ForeColor="#000099" Font-Size="Medium" Height="16px" Width="895px" BorderStyle="None">Assessment</asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 110; LEFT: 4px; POSITION: absolute; TOP: 4px" runat="server" Font-Bold="True" ForeColor="#000099" Font-Size="Medium" Height="16px" Width="893px" BorderStyle="None">Organization</asp:label>
			<asp:RadioButtonList id="pblPStatus" style="Z-INDEX: 109; LEFT: 374px; POSITION: absolute; TOP: 148px" runat="server" ForeColor="Navy" Width="117px">
				<asp:ListItem Value="No Plans">No Plans</asp:ListItem>
				<asp:ListItem Value="Planned">Planned</asp:ListItem>
			</asp:RadioButtonList>
			<asp:label id="Label1" style="Z-INDEX: 105; LEFT: 374px; POSITION: absolute; TOP: 118px" runat="server" ForeColor="#000099" Font-Size="Medium" Height="32px" Width="139px" BorderStyle="None" Font-Underline="True">Planned Status</asp:label><asp:button id="btnAction" style="Z-INDEX: 107; LEFT: 15px; POSITION: absolute; TOP: 407px" runat="server" BorderStyle="None" Width="152px" Height="48px" ForeColor="White" Font-Bold="True" Text="Update" BackColor="Red" onclick="btnAction_Click"></asp:button><asp:label id="Label3" style="Z-INDEX: 104; LEFT: 177px; POSITION: absolute; TOP: 118px" runat="server" BorderStyle="None" Width="136px" Height="32px" Font-Size="Medium" ForeColor="#000099" Font-Underline="True">Current Status</asp:label><asp:label id="Label8" style="Z-INDEX: 106; LEFT: 15px; POSITION: absolute; TOP: 188px" runat="server" BorderStyle="None" Width="110px" Height="40px" Font-Size="Medium" ForeColor="#000099">Description</asp:label><asp:button id="btnCancel" style="Z-INDEX: 103; LEFT: 191px; POSITION: absolute; TOP: 407px" runat="server" BorderStyle="None" Width="153" Height="48" ForeColor="White" Font-Bold="True" Text="Cancel" BackColor="Red"></asp:button><asp:textbox id="txtDesc" style="Z-INDEX: 102; LEFT: 14px; POSITION: absolute; TOP: 227px" runat="server" BorderStyle="Solid" Width="695px" Height="158px" ForeColor="#000099" BackColor="White" TextMode="MultiLine"></asp:textbox>
			<asp:RadioButtonList id="pblCStatus" style="Z-INDEX: 108; LEFT: 177px; POSITION: absolute; TOP: 152px" runat="server" ForeColor="Navy">
				<asp:ListItem Value="Not In Place">Not In Place</asp:ListItem>
				<asp:ListItem Value="In Place">In Place</asp:ListItem>
			</asp:RadioButtonList></form>
	</body>
</HTML>
