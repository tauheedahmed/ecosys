<%@ Page language="c#" Inherits="WebApplication2.frmUpdProcs" CodeFile="frmUpdProcs.aspx.cs" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="Label2" Text="Service Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblService" runat="server" Text="Service Normally Delivered"></asp:label></h2>
		<h2><asp:label id="lblProfileMgr" runat="server" Text="Profile Manager"></asp:label></h2>
		<p><asp:label id="lblComment" runat="server"></asp:label></p>
		<asp:button id="btnAction" runat="server" Text="Action"  Font-Bold="True" 
            onclick="btnAction_Click" meta:resourcekey="btnActionResource1"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" Font-Bold="True" 
            onclick="btnCancel_Click" meta:resourcekey="btnCancelResource1"></asp:button>
			</div>
			
			<asp:dropdownlist id="lstServices" runat="server" 
            meta:resourcekey="lstServicesResource1"></asp:dropdownlist>
			
			<p><asp:dropdownlist id="lstPeople" runat="server"></asp:dropdownlist>
			</p>
			<p>
			<h5><asp:label id="Label1" runat="server" Text="Process Name" ></asp:label></h5>			
			<asp:textbox id="txtName" runat="server" Width="346px" ></asp:textbox>
			</p>
			<p>
			<h5><asp:label id="lblDesc" runat="server" Text="Description"></asp:label></h5>
			<asp:textbox id="txtDesc" runat="server" Height="91px" Width="371px" ></asp:textbox>
			</p>
			
			<asp:label id="lblVis" runat="server" meta:resourcekey="lblVisResource1" >Visibility Level</asp:label>
			<asp:radiobuttonlist id="rblVis" runat="server" 
            meta:resourcekey="rblVisResource1" ></asp:radiobuttonlist>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
