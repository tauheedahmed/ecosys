<%@ Page language="c#" Inherits="WebApplication2.frmDisplayInventory" CodeFile="frmDisplayInventory.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 10px; POSITION: absolute; TOP: 43px" runat="server" ForeColor="Red" Font-Size="Small" Height="22px" Width="930px"></asp:label><asp:label id="lblAddress" style="Z-INDEX: 115; LEFT: 10px; POSITION: absolute; TOP: 175px" runat="server" ForeColor="Red" Font-Size="Small" Height="22px" Width="971px"></asp:label><asp:label id="lblPhone" style="Z-INDEX: 114; LEFT: 10px; POSITION: absolute; TOP: 139px" runat="server" ForeColor="Red" Font-Size="Small" Height="22px" Width="967px"></asp:label><asp:label id="lblUrl" style="Z-INDEX: 113; LEFT: 529px; POSITION: absolute; TOP: 107px" runat="server" ForeColor="Red" Font-Size="Small" Height="22px" Width="456px"></asp:label><asp:label id="lblEmail" style="Z-INDEX: 112; LEFT: 10px; POSITION: absolute; TOP: 107px" runat="server" ForeColor="Red" Font-Size="Small" Height="22px" Width="486px"></asp:label><asp:label id="lblBackupStatus" style="Z-INDEX: 110; LEFT: 697px; POSITION: absolute; TOP: 258px" runat="server" ForeColor="Navy" Font-Size="Small" ToolTip='The backup status indicates whether the item is normally used for this task ("Primary") or whether it is kept as backup in case the primary resource used for this task is not available.' BorderStyle="None">Backup Status (Update as Needed)</asp:label><asp:radiobuttonlist id="rblBackup" style="Z-INDEX: 109; LEFT: 697px; POSITION: absolute; TOP: 292px" runat="server" ForeColor="Navy" Font-Size="Small" Width="257px" BorderStyle="Solid" BorderWidth="2px" BorderColor="Navy"></asp:radiobuttonlist><asp:label id="lblLocation" style="Z-INDEX: 107; LEFT: 10px; POSITION: absolute; TOP: 275px" runat="server" ForeColor="Navy" Font-Size="Small" Height="29px" Width="634px" BorderStyle="None">Location</asp:label><asp:label id="lblResType" style="Z-INDEX: 108; LEFT: 10px; POSITION: absolute; TOP: 208px" runat="server" ForeColor="Navy" Font-Size="Small" Height="29px" Width="634px" BorderStyle="None"> Resource Type</asp:label><asp:label id="lblStatus" style="Z-INDEX: 105; LEFT: 10px; POSITION: absolute; TOP: 307px" runat="server" ForeColor="Navy" Font-Size="Small" Width="633px" BorderStyle="None"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 106; LEFT: 814px; POSITION: absolute; TOP: 211px" runat="server" ForeColor="White" Height="34px" Width="107px" BorderStyle="None" Text="Cancel" BackColor="Red" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 10px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><asp:label id="lblDesc" style="Z-INDEX: 103; LEFT: 10px; POSITION: absolute; TOP: 342px" runat="server" ForeColor="Navy" Font-Size="Small" Height="29px" Width="634px" BorderStyle="None"></asp:label><asp:label id="lblName" style="Z-INDEX: 102; LEFT: 10px; POSITION: absolute; TOP: 237px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="634px" BorderStyle="None"> Resource Name</asp:label><asp:button id="btnAction" style="Z-INDEX: 101; LEFT: 697px; POSITION: absolute; TOP: 210px" runat="server" ForeColor="White" Height="34px" Width="107px" BorderStyle="None" Text="Action" BackColor="Red" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>