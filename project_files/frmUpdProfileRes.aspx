<%@ Page language="c#" Inherits="WebApplication2.frmUpdProfileRes" CodeFile="frmUpdProfileRes.aspx.cs" %>
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
			<asp:label id="lblMeasure" style="Z-INDEX: 114; LEFT: 336px; POSITION: absolute; TOP: 150px" runat="server" Width="303px" Height="30px" Font-Size="Medium" ForeColor="#000099">Unit of Measure</asp:label>
			<asp:label id="lblHead2" style="Z-INDEX: 113; LEFT: 3px; POSITION: absolute; TOP: 46px" runat="server" Width="805px" Height="30px" Font-Size="Medium" ForeColor="#000099">Resource Name</asp:label><asp:label id="lblLocation" style="Z-INDEX: 103; LEFT: 76px; POSITION: absolute; TOP: 101px" runat="server" ForeColor="#000099" Font-Size="Medium" Height="27px" Width="80px" BorderStyle="None">Location</asp:label><asp:textbox id="txtQtyNeeded" style="Z-INDEX: 106; LEFT: 184px; POSITION: absolute; TOP: 145px" runat="server" ForeColor="#000099" Height="30px" Width="125px" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="lblOrg" style="Z-INDEX: 105; LEFT: 5px; POSITION: absolute; TOP: 3px" runat="server" ForeColor="#000099" Font-Size="Medium" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><INPUT id="htmBtnExit" style="FONT-WEIGHT: bold; Z-INDEX: 104; LEFT: 334px; WIDTH: 144px; COLOR: white; POSITION: absolute; TOP: 256px; HEIGHT: 47px; BACKGROUND-COLOR: red" onclick="history.back()" type="button" value="Cancel" name="htmBtnExit"><asp:label id="lblQtyNeed" style="Z-INDEX: 102; LEFT: 17px; POSITION: absolute; TOP: 154px" runat="server" ForeColor="#000099" Font-Size="Medium" Height="25px" Width="161px" BorderStyle="None"> Quantity Needed</asp:label><asp:button id="btnAction" style="Z-INDEX: 101; LEFT: 181px; POSITION: absolute; TOP: 256px" runat="server" ForeColor="White" Height="48px" Width="152px" BorderStyle="None" BackColor="Red" Font-Bold="True" Text="Action" onclick="btnAction_Click"></asp:button><asp:dropdownlist id="lstLoc" style="Z-INDEX: 109; LEFT: 182px; POSITION: absolute; TOP: 105px" runat="server" ForeColor="Navy" Height="30px" Width="225px"></asp:dropdownlist></form>
	</body>
</HTML>
