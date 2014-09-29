<%@ Page language="c#" Inherits="WebApplication2.frmUpdUsers" CodeFile="frmUpdUsers.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
			<div id="headerSection" >
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<h2><asp:label id="lblUserTypeName" runat="server"></asp:label></h2>
			<h2><asp:label id="lblAction" runat="server" ></asp:label></h2>
			
			<asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></div>
			<div style="font-weight:bold; color:White; ">
			<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
			<p><asp:label id="Label2" runat="server" Text="User Id"></asp:label>
			<asp:textbox id="txtUser" runat="server" ></asp:textbox></p>
			<p><asp:label id="Label1" runat="server" Text="Password"></asp:label>
            <asp:textbox id="txtPd" runat="server" ></asp:textbox></p>
            <p><asp:label id="Label5" runat="server" Text="Contact Person"> </asp:label>
			<asp:dropdownlist id="lstPerson" runat="server" ></asp:dropdownlist></p>
			
			<asp:button id="btnOrgs" runat="server" Text="Add Organization" Visible="False" onclick="btnOrgs_Click"></asp:button>
			<asp:button id="btnPerson" runat="server" Text="Add Person" onclick="btnPerson_Click"></asp:button>
			
			<p><asp:label id="Label4" runat="server" Text="Organization Unit"></asp:label>
			<asp:dropdownlist id="lstOrganization" runat="server" ></asp:dropdownlist></p>
			
			<p><asp:label id="lblStatus" runat="server" Text="Status"> </asp:label>
			<asp:radiobuttonlist id="rblStatus" runat="server" >
				<asp:ListItem Value="Active" Selected="True">Active</asp:ListItem>
				<asp:ListItem Value="Inactive">Inactive</asp:ListItem>
			</asp:radiobuttonlist></p>
			
			<asp:dropdownlist id="lstType" runat="server" Visible="False">
				<asp:ListItem Value="Organization" Selected="True">Organization</asp:ListItem>
				<asp:ListItem Value="Staff">Staff</asp:ListItem>
				<asp:ListItem Value="Household">Household</asp:ListItem>
				<asp:ListItem Value="Administrator">Administrator</asp:ListItem>
				<asp:ListItem Value="Security">Security</asp:ListItem>
				<asp:ListItem Value="Training">Training</asp:ListItem>
			</asp:dropdownlist>
			</div>
			</div>
			
			</form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
