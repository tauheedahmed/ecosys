<%@ Page language="c#" Inherits="WebApplication2.frmUpdClientAction" CodeFile="frmUpdClientAction.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 43px" runat="server" Width="675px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label><asp:dropdownlist id="lstVisibility" style="Z-INDEX: 121; LEFT: 230px; POSITION: absolute; TOP: 459px" runat="server" Width="506px" Height="201px" ForeColor="Navy" Visible="False"></asp:dropdownlist><asp:label id="lblVisibility" style="Z-INDEX: 113; LEFT: 142px; POSITION: absolute; TOP: 459px" runat="server" Width="43px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None" Visible="False">Visibility</asp:label><asp:label id="lblOrgS" style="Z-INDEX: 120; LEFT: 119px; POSITION: absolute; TOP: 506px" runat="server" Width="245px" Height="21px" Font-Size="Small" ForeColor="Navy" Visible="False">Check to Confirm Appointment</asp:label><asp:label id="Label1" style="Z-INDEX: 119; LEFT: 153px; POSITION: absolute; TOP: 207px" runat="server" Width="55px" Height="21px" Font-Size="Small" ForeColor="Navy"> Status</asp:label><asp:checkbox id="cbxStatusOrg" style="Z-INDEX: 118; LEFT: 382px; POSITION: absolute; TOP: 509px" runat="server" ForeColor="Navy" Visible="False"></asp:checkbox><asp:button id="btnPeople" style="Z-INDEX: 115; LEFT: 742px; POSITION: absolute; TOP: 158px" runat="server" Width="102px" Height="31px" ForeColor="White" BorderStyle="None" Text="People" BackColor="Navy" Font-Bold="True" onclick="btnPeople_Click"></asp:button><asp:label id="lblResType" style="Z-INDEX: 114; LEFT: 74px; POSITION: absolute; TOP: 387px" runat="server" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None" Visible="False"> Appointment Type</asp:label><asp:dropdownlist id="lstStaffTypes" style="Z-INDEX: 110; LEFT: 231px; POSITION: absolute; TOP: 387px" runat="server" Width="512px" Height="30px" ForeColor="Navy" Visible="False"></asp:dropdownlist><asp:dropdownlist id="lstLocations" style="Z-INDEX: 112; LEFT: 231px; POSITION: absolute; TOP: 426px" runat="server" Width="512px" Height="30px" ForeColor="Navy" Visible="False"></asp:dropdownlist><asp:label id="lblLocation" style="Z-INDEX: 108; LEFT: 108px; POSITION: absolute; TOP: 426px" runat="server" Height="29px" Font-Size="Small" ForeColor="Navy" BorderStyle="None" Visible="False">Duty Location</asp:label><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"></asp:label><asp:radiobuttonlist id="rblPayMethods" style="Z-INDEX: 102; LEFT: 542px; POSITION: absolute; TOP: 499px" runat="server" Width="200px" Font-Size="Small" ForeColor="Navy" BorderStyle="Solid" BorderColor="Navy" BorderWidth="2px" Visible="False"></asp:radiobuttonlist><asp:button id="btnCancel" style="Z-INDEX: 103; LEFT: 124px; POSITION: absolute; TOP: 109px" runat="server" Width="107px" Height="31px" ForeColor="White" BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblProcName" style="Z-INDEX: 105; LEFT: 105px; POSITION: absolute; TOP: 155px" runat="server" Width="103px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"> Client Name</asp:label><asp:textbox id="txtName" style="Z-INDEX: 106; LEFT: 221px; POSITION: absolute; TOP: 156px" runat="server" Width="512" Height="30px" ForeColor="Navy" BorderStyle="None" BackColor="White" Enabled="False" Font-Size="Medium" Font-Bold="True"></asp:textbox><asp:label id="Label4" style="Z-INDEX: 109; LEFT: 540px; POSITION: absolute; TOP: 471px" runat="server" Width="176px" Font-Size="Small" ForeColor="Navy" BorderStyle="None" Visible="False">Payment Method</asp:label><asp:button id="btnAction" style="Z-INDEX: 111; LEFT: 4px; POSITION: absolute; TOP: 108px" runat="server" Width="107px" Height="31px" ForeColor="White" BorderStyle="None" Text="Action" BackColor="Navy" Font-Bold="True" onclick="btnAction_Click"></asp:button><asp:checkbox id="cbxStatus" style="Z-INDEX: 117; LEFT: 241px; POSITION: absolute; TOP: 207px" runat="server" ForeColor="Navy"></asp:checkbox></form>
	</body>
</HTML>
