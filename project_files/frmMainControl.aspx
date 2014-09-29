<%@ Page language="c#" Inherits="WebApplication2.MainControl" CodeFile="frmMainControl.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body text="maroon" bgColor="#ffffff">
		<form id="Main" method="post" runat="server">
		<p><asp:label id="lblOrg" runat="server"></asp:label></p> 
		<p> <asp:label id="lblUser" runat="server"></asp:label></p>
            <p><asp:label id="lblTitle" runat="server"> </asp:label></p>
            <p><asp:button id="btnBack" runat="server" Text="OK" onclick="btnSignOff_Click"></asp:button></p>
			<p><asp:button id="btnSer" runat="server" Text="Service Models" onclick="btnSer_Click"></asp:button></p>
            <p><asp:button id="btnProfile" runat="server" Text="Business Models" onclick="btnProfile_Click"></asp:button></p>
            <p><asp:button id="btnCurr" runat="server" Text="Currencies" onclick="btnCurr_Click"></asp:button></p>
            <p><asp:button id="btnHouseholds" runat="server" Text="Household Characteristics" onclick="btnHouseholds_Click"></asp:button></p>
            <p><asp:button id="btnHHSuppliers" runat="server" 
                    Text="Household Resource Providers" onclick="btnHHSuppliers_Click" ></asp:button></p>
            
        <p>
            <asp:button id="btnProfileMgrs" runat="server" Text="Profile Managers" onclick="btnProfileMgrs_Click"></asp:button>
        </p>
        </form>
	</body>
</HTML>
