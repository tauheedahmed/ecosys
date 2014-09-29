<%@ Page language="c#" Inherits="WebApplication2.MainSec" CodeFile="frmMainSec.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="Main" method="post" runat="server">
		<h1><asp:label id="lblTitle"  runat="server" ></asp:label></h1>
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<p><asp:label id="lblContent1" runat="server" ></asp:label>
		<asp:label id="lblContent2" runat="server" ></asp:label></p>
		<asp:button id="btnExit" runat="server" Text="Exit"  onclick="btnExit_Click"></asp:button>
			
			<asp:button id="btnUsers" runat="server" Text="Start" onclick="btnUsers_Click"></asp:button>
			<p><asp:label id="lblUser" runat="server" ></asp:label>
			<asp:label id="lblLicense"  runat="server" ></asp:label></p>
            
            
            </form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
