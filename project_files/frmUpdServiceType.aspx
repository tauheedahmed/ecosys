<%@ Page language="c#" Inherits="WebApplication2.frmUpdServiceType" CodeFile="frmUpdServiceType.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 49px" runat="server" Width="675px" Height="30px" Font-Size="Small" > Content</asp:label>
			<asp:label id="Label6" style="Z-INDEX: 122; LEFT: 104px; POSITION: absolute; TOP: 168px" runat="server"  Font-Size="Small" Height="40px" Width="119px" BorderStyle="None">Description</asp:label>
			<asp:textbox id="txtDesc" style="Z-INDEX: 121; LEFT: 232px; POSITION: absolute; TOP: 160px" runat="server"  Height="72px" Width="514px" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:textbox id="txtPJNameS" style="Z-INDEX: 120; LEFT: 232px; POSITION: absolute; TOP: 288px" runat="server"  Height="36px" Width="514px" BackColor="White" BorderStyle="Solid"></asp:textbox>
			<asp:label id="Label5" style="Z-INDEX: 105; LEFT: 16px; POSITION: absolute; TOP: 296px" runat="server"  Font-Size="Small" Height="40px" Width="201px" BorderStyle="None">Project Name (Singular)</asp:label>
			<asp:textbox id="txtPJName" style="Z-INDEX: 119; LEFT: 232px; POSITION: absolute; TOP: 240px" runat="server"  Height="36px" Width="514px" BackColor="White" BorderStyle="Solid"></asp:textbox>
			<asp:label id="Label4" style="Z-INDEX: 104; LEFT: 99px; POSITION: absolute; TOP: 106px" runat="server"  Font-Size="Small" Height="40px" Width="119px" BorderStyle="None"> Service Name</asp:label>
			<asp:label id="lblError" style="Z-INDEX: 114; LEFT: 231px; POSITION: absolute; TOP: 686px" runat="server" Width="614px" Height="34px" Font-Size="Small" ForeColor="Red"></asp:label>
            <asp:textbox id="txtSeq" 
                style="Z-INDEX: 113; LEFT: 230px; POSITION: absolute; TOP: 424px; width: 137px; bottom: 117px;" 
                runat="server" Height="33px"  BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="Label3" style="Z-INDEX: 112; LEFT: 136px; POSITION: absolute; TOP: 432px" runat="server"  Font-Size="Small"  BorderStyle="None"> Sequence</asp:label>
			<asp:label id="Label2" style="Z-INDEX: 111; LEFT: 52px; POSITION: absolute; TOP: 392px" runat="server" BorderStyle="None">Measure of Quantity</asp:label>
			<asp:dropdownlist id="lstQtyMeasure" style="Z-INDEX: 110; LEFT: 230px; POSITION: absolute; TOP: 392px" runat="server" ></asp:dropdownlist><asp:dropdownlist id="lstFunction" style="Z-INDEX: 109; LEFT: 230px; POSITION: absolute; TOP: 344px" runat="server" ></asp:dropdownlist>
			<asp:label id="lblFunction" style="Z-INDEX: 108; LEFT: 140px; POSITION: absolute; TOP: 344px" runat="server" BorderStyle="None"> Function</asp:label><asp:label id="lblProcName" style="Z-INDEX: 106; LEFT: 35px; POSITION: absolute; TOP: 248px" runat="server" Width="184px" Height="40px" Font-Size="Small"  BorderStyle="None"> Project Name (Plural)</asp:label><asp:textbox id="txtName" style="Z-INDEX: 101; LEFT: 230px; POSITION: absolute; TOP: 107px" runat="server" Width="514px" Height="36px"  BorderStyle="Solid" BackColor="White"></asp:textbox>
            <asp:button id="btnAction" 
                style="Z-INDEX: 102; LEFT: 229px; POSITION: absolute; TOP: 529px" 
                runat="server" Width="152px" Height="48px" ForeColor="White" Font-Bold="True" 
                Text="Action" BorderStyle="None" BackColor="Navy" onclick="btnAction_Click"></asp:button>
            <asp:label id="Label8" 
                style="Z-INDEX: 115; LEFT: 61px; POSITION: absolute; TOP: 468px; width: 147px;" 
                runat="server" Height="26px" Font-Size="Small"
                BorderStyle="None" > Household Service Flag</asp:label>
			<asp:CheckBox id="cbxHouseholdFlag" 
                style="Z-INDEX: 118; LEFT: 225px; POSITION: absolute; TOP: 475px; height: 25px;" 
                runat="server" Width="129px"  >
            </asp:CheckBox>
            <p>
                &nbsp;</p>
            <asp:button id="btnCancel" 
                style="Z-INDEX: 107; LEFT: 395px; POSITION: absolute; TOP: 527px" 
                runat="server" Width="152px" Height="48px" ForeColor="White" Font-Bold="True" 
                Text="Cancel" BorderStyle="None" BackColor="Navy" onclick="btnCancel_Click"></asp:button></form>
	</body>
</HTML>
