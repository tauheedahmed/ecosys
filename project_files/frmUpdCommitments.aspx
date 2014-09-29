<%@ Page language="c#" Inherits="WebApplication2.frmUpdDeadlines" CodeFile="frmUpdCommitments.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Service Commitments</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmAddProcedure" method="post" runat="server">
			<asp:label id="lblAction" style="Z-INDEX: 100; LEFT: 57px; POSITION: absolute; TOP: 138px" runat="server" Width="842px" Height="22px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="Label5" style="Z-INDEX: 120; LEFT: 79px; POSITION: absolute; TOP: 307px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="69px" BorderStyle="None">Location</asp:label>
			<asp:DropDownList id="lstLoc" style="Z-INDEX: 119; LEFT: 162px; POSITION: absolute; TOP: 308px" runat="server" ForeColor="Navy" Height="30px" Width="265px"></asp:DropDownList>
			<asp:label id="Label4" style="Z-INDEX: 118; LEFT: 452px; POSITION: absolute; TOP: 270px" runat="server" ForeColor="Navy" Font-Size="Small" Height="23px" Width="401px" BorderStyle="None" Font-Underline="True">Impact of Delay Beyond Acceptable Level</asp:label>
			<asp:label id="Label3" style="Z-INDEX: 117; LEFT: 548px; POSITION: absolute; TOP: 355px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="83px" BorderStyle="None">Magnitude</asp:label>
			<asp:DropDownList id="lstMagnitude" style="Z-INDEX: 116; LEFT: 643px; POSITION: absolute; TOP: 353px" runat="server" ForeColor="Navy" Height="30px" Width="210px">
				<asp:ListItem Value="Major" Selected="True">Major Impact</asp:ListItem>
				<asp:ListItem Value="Minor">Minor Impact</asp:ListItem>
			</asp:DropDownList>
			<asp:label id="Label2" style="Z-INDEX: 113; LEFT: 588px; POSITION: absolute; TOP: 311px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="42px" BorderStyle="None">Type</asp:label><asp:label id="lblOutput" style="Z-INDEX: 112; LEFT: 57px; POSITION: absolute; TOP: 104px" runat="server" Width="841px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:textbox id="txtValue" style="Z-INDEX: 111; LEFT: 644px; POSITION: absolute; TOP: 392px" runat="server" ForeColor="#000099" Height="30px" Width="209px" BackColor="White" BorderStyle="Solid"></asp:textbox>
			<asp:label id="Label1" style="Z-INDEX: 109; LEFT: 529px; POSITION: absolute; TOP: 398px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="103px" BorderStyle="None">Dollar Value</asp:label><asp:label id="lblAccDelay" style="Z-INDEX: 110; LEFT: 483px; POSITION: absolute; TOP: 211px" runat="server" Width="143px" Height="23px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Acceptable Delay</asp:label><asp:textbox id="txtDeadline" style="Z-INDEX: 108; LEFT: 161px; POSITION: absolute; TOP: 260px" runat="server" Width="270px" Height="30px" ForeColor="#000099" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtAccDelay" style="Z-INDEX: 107; LEFT: 640px; POSITION: absolute; TOP: 208px" runat="server" Width="214px" Height="30px" ForeColor="#000099" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="lblOrg" style="Z-INDEX: 106; LEFT: 57px; POSITION: absolute; TOP: 66px" runat="server" Font-Bold="True" Height="30px" Font-Size="Small" ForeColor="White" BackColor="Navy"></asp:label><INPUT id="htmBtnExit" style="FONT-WEIGHT: bold; Z-INDEX: 105; LEFT: 489px; WIDTH: 144px; COLOR: white; POSITION: absolute; TOP: 449px; HEIGHT: 47px; BACKGROUND-COLOR: maroon" onclick="history.back()" type="button" value="Cancel" name="htmBtnExit">
			<asp:label id="lblDeadline" style="Z-INDEX: 104; LEFT: 79px; POSITION: absolute; TOP: 265px" runat="server" Width="74px" Height="24px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Deadline</asp:label><asp:label id="lblClient" style="Z-INDEX: 103; LEFT: 101px; POSITION: absolute; TOP: 215px" runat="server" Width="51px" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Client</asp:label><asp:textbox id="txtClient" style="Z-INDEX: 101; LEFT: 160px; POSITION: absolute; TOP: 207px" runat="server" Width="270px" Height="30px" ForeColor="#000099" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 102; LEFT: 327px; POSITION: absolute; TOP: 449px" runat="server" Font-Bold="True" Width="152px" Height="48px" ForeColor="White" BorderStyle="None" BackColor="Maroon" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:DropDownList id="lstImpact" style="Z-INDEX: 115; LEFT: 643px; POSITION: absolute; TOP: 311px" runat="server" ForeColor="Navy" Height="30px" Width="210px">
				<asp:ListItem Value="Client" Selected="True">Client Service</asp:ListItem>
				<asp:ListItem Value="Legal">Legal Requirement</asp:ListItem>
				<asp:ListItem Value="Financial">Financial Cost</asp:ListItem>
				<asp:ListItem Value="Other">Other</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
