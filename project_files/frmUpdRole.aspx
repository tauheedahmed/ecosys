<%@ Page language="c#" Inherits="WebApplication2.frmUpdRole" CodeFile="frmUpdRole.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblTitle" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblFunction" runat="server" ></asp:label></h2>
        <asp:label id="lblContents2" runat="server" ></asp:label>
        <p><asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			</p></div>
			<h5><p><asp:label id="lblProcName" runat="server" > Name</asp:label></h5>
			<asp:textbox id="txtName" runat="server" Width="291px" ></asp:textbox></p>
			<p><h5><asp:label id="Label1" runat="server" >List Sequence</asp:label></h5>
			<asp:textbox id="txtSeq" runat="server" Width="38px"></asp:textbox></p>
			
			<p><asp:label id="lblVisibility" runat="server" >Visibility</asp:label>
			<asp:dropdownlist id="lstVisibility" runat="server" Height="16px" Width="150px" ></asp:dropdownlist></p>
			<h5><p><asp:label id="lblRoles" runat="server" > Parent</asp:label></h5>
			<asp:dropdownlist id="lstParentRoles" runat="server" Height="16px" Width="288px" ></asp:dropdownlist></p>
			
			
			</form>	<!--#include file="inc/footer.aspx"-->
</HTML>
