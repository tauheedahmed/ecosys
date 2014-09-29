<%@ Page language="c#" Inherits="WebApplication2.frmUserIdChange" CodeFile="frmUserIdChange.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
<div id="maindiv" >

		<form id="frmAddProcedure" method="post" runat="server">
			<h1><asp:label id="lblTitle" runat="server" Text="Change User Id and/or Password" ></asp:label></h1>
			<asp:button id="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<h4><asp:label id="Label3" runat="server" Text="Enter New User Id"></asp:label></h4>
			<asp:textbox id="txtUser" runat="server" Width="236px" Height="31px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" ></asp:textbox>
			<h4><asp:label id="Label5" runat="server" Text="Enter New Password" ></asp:label></h4>
			<h4><asp:label id="Label1" runat="server" >(6-12 characters)</asp:label></h4>
			<asp:textbox id="txtPassword" runat="server" Width="236px" Height="31px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="Password" Font-Size="Small"></asp:textbox>
			
			<h4><asp:label id="Label2" runat="server" Text="Re-Enter New Password"></asp:label></h4>
			<asp:textbox id="txtPasswordcheck" runat="server" Width="236px" Height="31px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="Password"></asp:textbox>
			<p><asp:label id="lblError" runat="server" ForeColor="Maroon"></asp:label></p>
			
			
			</form>
    <p><!--#include file="inc/footer.aspx"--></p>
</HTML>
