<%@ Page language="c#" Inherits="WebApplication2.frmLicenseRequest" CodeFile="frmLicenseRequest.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 111; LEFT: 24px; POSITION: absolute; TOP: 53px" runat="server" ForeColor="Navy" Font-Size="Small" Height="16px" Width="824px" Font-Bold="True"></asp:label>
			<asp:label id="Label5" style="Z-INDEX: 117; LEFT: 430px; POSITION: absolute; TOP: 182px" runat="server" Width="88px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Last Name</asp:label>
			<asp:label id="Label4" style="Z-INDEX: 116; LEFT: 77px; POSITION: absolute; TOP: 182px" runat="server" Width="88px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">First Name</asp:label>
			<asp:textbox id="txtLNamePerson" style="Z-INDEX: 115; LEFT: 525px; POSITION: absolute; TOP: 175px" runat="server" Width="238px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:label id="Label3" style="Z-INDEX: 114; LEFT: 24px; POSITION: absolute; TOP: 109px" runat="server" Width="152px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Organization  Name</asp:label>
			<asp:textbox id="txtFNamePerson" style="Z-INDEX: 105; LEFT: 174px; POSITION: absolute; TOP: 175px" runat="server" Width="211px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:button id="btnPrevious" style="Z-INDEX: 113; LEFT: 519px; POSITION: absolute; TOP: 407px" runat="server" ForeColor="White" Height="48px" Width="152px" Font-Bold="True" BackColor="Red" BorderStyle="None" Text="Previous" Visible="False" onclick="btnPrevious_Click"></asp:button>
			<asp:button id="btnCancel" style="Z-INDEX: 112; LEFT: 353px; POSITION: absolute; TOP: 407px" runat="server" ForeColor="White" Height="48" Width="153" Font-Bold="True" BackColor="Red" BorderStyle="None" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="Label2" style="Z-INDEX: 110; LEFT: 471px; POSITION: absolute; TOP: 236px" runat="server" Width="48px" Height="25px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Email</asp:label><asp:label id="Label1" style="Z-INDEX: 109; LEFT: 92px; POSITION: absolute; TOP: 239px" runat="server" Width="57px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Telephone</asp:label><asp:textbox id="txtEmail" style="Z-INDEX: 108; LEFT: 525px; POSITION: absolute; TOP: 226px" runat="server" Width="239px" Height="30px" ForeColor="#000099" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtPhone" style="Z-INDEX: 107; LEFT: 185px; POSITION: absolute; TOP: 233px" runat="server" Width="270px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:textbox id="txtName" style="Z-INDEX: 106; LEFT: 188px; POSITION: absolute; TOP: 106px" runat="server" Width="404px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:label id="lblAdd" style="Z-INDEX: 104; LEFT: 107px; POSITION: absolute; TOP: 289px" runat="server" Width="67px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Address</asp:label><asp:label id="lblProcName" style="Z-INDEX: 103; LEFT: 34px; POSITION: absolute; TOP: 146px" runat="server" Width="161px" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Contact Person:</asp:label><asp:textbox id="txtAddr" style="Z-INDEX: 100; LEFT: 183px; POSITION: absolute; TOP: 286px" runat="server" Width="583px" Height="91px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnContinue" style="Z-INDEX: 101; LEFT: 183px; POSITION: absolute; TOP: 407px" runat="server" Font-Bold="True" Width="152px" Height="48px" ForeColor="White" BorderStyle="None" BackColor="Red" Text="Submit Request" onclick="btnContinue_Click"></asp:button></form>
	</body>
</HTML>
