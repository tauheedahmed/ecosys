<%@ Page language="c#" Inherits="WebApplication2.frmUpdLicOrg" CodeFile="frmUpdLicOrg.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h1><asp:label id="lblContent" runat="server" ></asp:label></h1>			
			<asp:button id="btnAction" runat="server" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			</div>
            <div style="font-weight:bold; color:White; ">
            <div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:30%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		    <h4><asp:label id="lblName" runat="server" Text="Name"></asp:label></h4>
			<asp:textbox id="txtName" runat="server" ></asp:textbox>
			<h4><asp:label id="Label3" runat="server" Text="Description" ></asp:label></h4>
			<asp:textbox id="txtDesc" runat="server" TextMode="MultiLine"></asp:textbox>
			<h4><asp:label id="Label2" runat="server" Text="Email"> </asp:label></h4>
			<asp:textbox id="txtEmail" runat="server" ></asp:textbox>
			<h4><asp:label id="Label1" runat="server" Text="Telephone" ></asp:label></h4>
			<asp:textbox id="txtPhone" runat="server" ></asp:textbox>
			<h4><asp:label id="lblAdd" runat="server" Text="Address" > </asp:label></h4>
			<asp:textbox id="txtAddr" runat="server" ></asp:textbox>
			</div>
			<div style="float:left;  background-color:Gray;  border:solid 1px White; width:30%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		    <h4><asp:label id="Label5" runat="server" Text="Profile" ></asp:label></h4>
			<asp:dropdownlist id="lstProfile" runat="server" ></asp:dropdownlist>
			
		    <h4><asp:label id="lblBud" runat="server" Text="Default Budget" ></asp:label></h4>
			<asp:dropdownlist id="lstCurrencies" runat="server" ></asp:dropdownlist>
			
			<h4><asp:label id="lblVis" runat="server" Text="Visibility Level"></asp:label></h4>
			<asp:radiobuttonlist id="rblVis" runat="server" ></asp:radiobuttonlist>
			</div>
			
			</form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
