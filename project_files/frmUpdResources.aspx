<%@ Page language="c#" Inherits="WebApplication2.frmUpdResources" CodeFile="frmUpdResources.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 100; LEFT: 1px; POSITION: absolute; TOP: 45px" runat="server" Width="805px" Height="23px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblVisibility" style="Z-INDEX: 116; LEFT: 91px; POSITION: absolute; TOP: 223px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="69px" BorderStyle="None">Visibility</asp:label>
			<asp:dropdownlist id="lstVisibility" style="Z-INDEX: 115; LEFT: 180px; POSITION: absolute; TOP: 224px" runat="server" ForeColor="Navy" Height="201px" Width="251px"></asp:dropdownlist>
			<asp:DropDownList id="lstLocations" style="Z-INDEX: 114; LEFT: 180px; POSITION: absolute; TOP: 192px" runat="server" ForeColor="Navy" Height="25" Width="232"></asp:DropDownList>
			<asp:label id="Label4" style="Z-INDEX: 113; LEFT: 97px; POSITION: absolute; TOP: 194px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="69px" BorderStyle="None">Location</asp:label>
			<asp:label id="lblType" style="Z-INDEX: 111; LEFT: 296px; POSITION: absolute; TOP: 152px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="43px" BorderStyle="None">Type</asp:label><asp:dropdownlist id="lstType" style="Z-INDEX: 110; LEFT: 353px; POSITION: absolute; TOP: 151px" runat="server" Width="251px" Height="201px" ForeColor="Navy"></asp:dropdownlist><asp:dropdownlist id="lstStatus" style="Z-INDEX: 109; LEFT: 180px; POSITION: absolute; TOP: 150px" runat="server" Width="104px" Height="30px" ForeColor="Navy" Font-Size="X-Small">
				<asp:ListItem Value="Plan">Plan</asp:ListItem>
				<asp:ListItem Value="Actual">Actual</asp:ListItem>
			</asp:dropdownlist><asp:label id="lblStatus" style="Z-INDEX: 108; LEFT: 109px; POSITION: absolute; TOP: 148px" runat="server" Width="57px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Status</asp:label><asp:textbox id="txtDesc" style="Z-INDEX: 107; LEFT: 180px; POSITION: absolute; TOP: 255px" runat="server" Width="535px" Height="100px" ForeColor="#000099" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 103; LEFT: 72px; POSITION: absolute; TOP: 255px" runat="server" Width="94px" Height="27px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Description</asp:label><asp:textbox id="txtName" style="Z-INDEX: 106; LEFT: 180px; POSITION: absolute; TOP: 109px" runat="server" Width="535px" Height="30px" ForeColor="#000099" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="lblOrg" style="Z-INDEX: 105; LEFT: 5px; POSITION: absolute; TOP: 3px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label><INPUT id="htmBtnExit" style="FONT-WEIGHT: bold; Z-INDEX: 104; LEFT: 335px; WIDTH: 144px; COLOR: white; POSITION: absolute; TOP: 362px; HEIGHT: 47px; BACKGROUND-COLOR: red" onclick="history.back()" type="button" value="Cancel" name="htmBtnExit"><asp:label id="lblProcName" style="Z-INDEX: 102; LEFT: 120px; POSITION: absolute; TOP: 105px" runat="server" Width="46px" Height="25px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Name</asp:label><asp:button id="btnAction" style="Z-INDEX: 101; LEFT: 182px; POSITION: absolute; TOP: 362px" runat="server" Width="152px" Height="48px" ForeColor="White" BorderStyle="None" BackColor="Red" Font-Bold="True" Text="Action" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
