<%@ Page language="c#" Inherits="WebApplication2.frmAddPeople" CodeFile="frmUpdPeople.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
			<div id="headerSection" >
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblAction" runat="server" >Add a Person</asp:label></h2>
			<p><asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" ></asp:button></p>
			</div>
			<div style="font-weight:bold; color:White; ">
			<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
			<asp:label id="Label3" runat="server" >First Name</asp:label><asp:textbox id="txtFName" runat="server" ></asp:textbox>
			<asp:label id="Label2" runat="server" >Last Name</asp:label><asp:textbox id="txtLName" runat="server" ></asp:textbox>
						
			<p><asp:label id="Label8" runat="server" >Address</asp:label>
			<asp:textbox id="txtAddr" runat="server" Width=350px ></asp:textbox></p>
			
			<p><asp:label id="Label6" runat="server" >Email</asp:label><asp:textbox id="txtEmail" runat="server" ></asp:textbox></p>
			
			
			<p><asp:label id="Label10" runat="server" >Work Phone</asp:label>
			<asp:textbox id="txtWPhone" runat="server" ></asp:textbox></p>
			
			<p><asp:label id="Label5" runat="server" >Cell Phone</asp:label>
			<asp:textbox id="txtCPhone" runat="server" ></asp:textbox></p>
			
			<p><asp:label id="Label4" runat="server" >Home Phone</asp:label>
			<asp:textbox id="txtHPhone" runat="server" ></asp:textbox></p>
			
			
			<asp:label id="lblLevel" runat="server" >User Level</asp:label>
			<asp:radiobuttonlist id="rblLevel" runat="server" >
				<asp:ListItem Value="0">Beginner</asp:ListItem>
				<asp:ListItem Value="1" Selected="True">Advanced</asp:ListItem>
			</asp:radiobuttonlist>
			
			<p><asp:label id="lblVisibility" runat="server" >Visibility</asp:label>
			<asp:dropdownlist id="lstVisibility" runat="server" ForeColor="Navy" ></asp:dropdownlist>
			</p>
			</div></div>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
