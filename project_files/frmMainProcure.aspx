<%@ Page language="c#" Inherits="WebApplication2.frmMainProcure" CodeFile="frmMainProcure.aspx.cs" %>
<!--#include file="inc/HeaderProc.aspx"-->
	
		<form id="Main" method="post" runat="server">
			<h1><asp:label id="lblTitle" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<asp:label id="lblOrgP" runat="server" ></asp:label>
			<p><asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button></p>
			<p><asp:label id="lblContents2" runat="server" ></asp:label>
			<asp:label id="lblContents3" runat="server" ></asp:label>
			<asp:label id="lblContents4" runat="server" ></asp:label></p>
			
			<asp:button id="btnStart" runat="server" Text="Procurement Contracts" onclick="btnStart_Click"></asp:button>
			
			<asp:button id="btnReports" runat="server" Text="Reports"  visible="false" ></asp:button>
			<p></p>
			<p><asp:label id="lblMsg" runat="server" ForeColor="Red" ></asp:label></p>
			<p><asp:label id="lblUser" runat="server" visible="false" Font-Italic="True"></asp:label></p>
			<p><asp:label id="lblLic" runat="server" Font-Size="XX-Small" visible="false" ></asp:label></p>
			
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
