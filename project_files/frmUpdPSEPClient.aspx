<%@ Page language="c#" Inherits="WebApplication2.frmUpdPSEPClient" CodeFile="frmUpdPSEPClient.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="Label7" Text="Business Impact Analysis" runat="server" ></asp:label></h1>
		<h2><b><asp:label id="lblProfilesName" Text="Business Profiles" runat="server" ></asp:label></b></h2>
		<h2><b><asp:label id="lblServiceName" Text="Service Name" runat="server" ></asp:label></b></h2>
		<h2><b><asp:label id="lblDeliverableName" Text="Deliverable Name" runat="server" ></asp:label></b></h2>
		<h2><b><asp:label id="lblClientName" runat="server" ></asp:label></b></h2>
			<p><asp:label id="lblAction" runat="server" ></asp:label></p>
			<asp:button id="btnAction" runat="server" Text="Return to Previous Form" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
</div>
<div style="font-weight:bold; color:White; ">
		<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:50%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		    
			<p><b><asp:label id="Label2" runat="server" >I.  This type of a client is an:</asp:label></b></p>
			<asp:RadioButtonList id="btnClientType" runat="server" >
				<asp:ListItem Value="Individual">Individual</asp:ListItem>
				<asp:ListItem Value="Organization">Organization or Group</asp:ListItem>
			</asp:RadioButtonList>
			<p><b><asp:label id="lblSS" runat="server" >II.  Service Standards for this type of a client:</asp:label></b></p>
			<asp:label id="Label1" runat="server" >Deadline</asp:label>
			<asp:dropdownlist id="lstTypesOfDeadlines" runat="server" ForeColor="Navy" Height="201px" Width="343px"></asp:dropdownlist>
			<p><asp:label id="Label6" runat="server" >Dollar Cost of Slippage</asp:label>
			<asp:textbox id="txtDollarCostSlip" runat="server"></asp:textbox></p>
			<asp:label id="Label5" runat="server" >Type of Impact</asp:label>
			<asp:dropdownlist id="lstTypesOfImpact" runat="server" ></asp:dropdownlist>
			
			<p><asp:label id="Label4" runat="server" >Impact if Slippage Beyond Acceptable Limit</asp:label>
			<asp:dropdownlist id="lstTypesOfImpactMagnitude" runat="server" Width="343px" Height="201px" ForeColor="Navy"></asp:dropdownlist>
			</p><asp:label id="Label3" runat="server" >Acceptable Slippage</asp:label>
			<asp:textbox id="txtAcceptableSlip" runat="server" Width="343px" Height="31px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" ontextchanged="txtAcceptableSlip_TextChanged"></asp:textbox>
			</div></div>
			</form>
   <!--#include file="inc/footer.aspx"-->
</HTML>
