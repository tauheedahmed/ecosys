<%@ Page language="c#" Inherits="WebApplication2.MainFController" CodeFile="frmMainFController.aspx.cs" %>
<!--#include file="inc/HeaderF.aspx"-->
	<div id="maindiv" >
		<form id="Form1" method="post" runat="server">
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblTitle" runat="server" ></asp:label></h2>
			<p><asp:label id="lblContent1" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			
			<asp:button id="btnFunds" runat="server" Text="Funds" onclick="btnFunds_Click"></asp:button>
			<asp:button id="btnProcurements" runat="server" Text="Procurements" Visible="False" onclick="btnProcurements_Click"></asp:button>
			<asp:button id="bnInventory" runat="server" Text="Inventory" Visible="False" onclick="bnInventory_Click"></asp:button>
			
			<asp:button id="btnFiscalYears" runat="server" ForeColor="Navy" Font-Size="X-Small" Text="Fiscal Years" Width="108px" Height="32px" BackColor="White" BorderStyle="Solid" BorderWidth="2px" BorderColor="Navy" Visible="False" onclick="btnFiscalYears_Click"></asp:button>
			<asp:label id="lblUser" runat="server" ForeColor="Navy" Font-Size="X-Small" Width="842px" Height="18px" Font-Italic="True"></asp:label>
			
			</form>

	<!--#include file="inc/footer.aspx"-->
</HTML>
