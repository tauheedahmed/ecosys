<%@ Page language="c#" Inherits="WebApplication2.frmUpdOrganization" CodeFile="frmUpdOrganization.aspx.cs" %>
<!--#include file="inc/HeaderProc.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
			<div id="headerSection" >
			<h1><asp:label id="lblTitle" runat="server" ></asp:label></h1>
		    <h2><asp:label id="lblContent" runat="server" ></asp:label></h2> 
         <p><asp:button id="btnAction" runat="server" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
			<h5><asp:label id="lblName" runat="server" >Name</asp:label></h5>
			<asp:textbox id="txtName" runat="server" ></asp:textbox>
			<h5><asp:label id="Label3" runat="server" >Description</asp:label></h5>
			<asp:textbox id="txtDesc" runat="server" TextMode="MultiLine"></asp:textbox>
			<h5><asp:label id="Label2" runat="server" >Email</asp:label></h5>
			<asp:textbox id="txtEmail" runat="server" ></asp:textbox>
			<h5><asp:label id="Label1" runat="server" >Telephone</asp:label></h5>
			<asp:textbox id="txtPhone" runat="server" ></asp:textbox>
			<h5><asp:label id="lblAdd" runat="server" > Address</asp:label></h5>
			<asp:textbox id="txtAddr" runat="server" ></asp:textbox>
			<h5><asp:label id="lblVis" runat="server" >Visibility Level</asp:label></h5>
			<asp:dropdownlist id="lstVis" runat="server" ></asp:dropdownlist>
			</form>
	</body>
</HTML>
