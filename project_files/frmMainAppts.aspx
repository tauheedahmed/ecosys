<%@ Page language="c#" Inherits="WebApplication2.frmMainAppts" CodeFile="frmMainAppts.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
	
		<form id="Main" method="post" runat="server">
		<h1><asp:label id="lblTitle" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
		<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnStart" runat="server" Text="Start" onclick="btnStart_Click">
			</asp:button>
		<p><asp:label id="lblContents2" runat="server" ></asp:label>
		<asp:label id="lblContents4" runat="server" Visible="False"></asp:label>
			</p>
			<asp:label id="lblAppts" runat="server" ></asp:label>
			
			
			
			
			<asp:button id="btnReports" runat="server" Text="Reports" Visible="False" ></asp:button>
			<asp:label id="lblMsg" runat="server" Visible="False"></asp:label>
			
			<asp:label id="lblUser" runat="server"  Visible="False"></asp:label>
			<asp:label id="lblLic" runat="server" Visible="False"></asp:label>
			<asp:label id="lblOrgP" runat="server" Visible="False"></asp:label>
			
			</form>

	<!--#include file="inc/footer.aspx"-->
</HTML>
