<%@ Page language="c#" Inherits="WebApplication2.frmUpdProfileSEProcs" CodeFile="frmUpdProfileSEProcs.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
<form id="frmAddProcedure" method="post" runat="server">
		<h1><asp:label id="Label1" Text="EcoSys: Business Model" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfilesName" Text="Business Profiles" runat="server" ></asp:label></h2>
		<h3><asp:label id="lblServiceName" Text="Service Name" runat="server" ></asp:label></h3>
		<h4><b><asp:label id="lblDeliverableName" Text="Deliverable Name" runat="server" ></asp:label></h4>
		<p><asp:label id="lblAction" runat="server" ></asp:label></p>
          <asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
		    <asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<p><asp:label id="lblName"  runat="server" Text="Process Name"> </asp:label>
			</p>
			<asp:textbox id="txtName"  runat="server" Width="323px" Height="32" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<h5><asp:label id="Label7" runat="server" > Generic Procedure Underlying Above Process</asp:label>
			</h5>
			<p><asp:dropdownlist id="lstProcs" runat="server" ></asp:dropdownlist></p>
			<p><asp:label id="Label2" runat="server" >Service Associated with Above Generic Procedure</asp:label>
			</p><p><asp:dropdownlist id="lstService" runat="server" AutoPostBack="True" onselectedindexchanged="lstService_SelectedIndexChanged"></asp:dropdownlist>
			</p>
			<p>
			<asp:label id="Label12" runat="server" Visible="false" Width="465" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Check if the cost of responding to this event needs to be monitored separately each time the  event occurs</asp:label>
			<asp:label id="Label9" runat="server" Visible="false" Width="465" Height="26px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Check if the steps involved in responding to this event need to be monitored each time the event occurs</asp:label>
			<asp:CheckBox id="cbxCosts" runat="server" visible="false" ForeColor="Navy" oncheckedchanged="cbxCosts_CheckedChanged"></asp:CheckBox>
			<p><asp:label id="lblProject" style="Z-INDEX: 109; LEFT: 56px; POSITION: absolute; TOP: 384px" runat="server" ForeColor="Navy" Font-Size="Small" Height="26px" Width="465px" BorderStyle="None" Visible="False"> Select the task name commonly used for this process</asp:label></p>
			<p><asp:dropdownlist id="lstProjects" runat="server" Visible="False"></asp:dropdownlist></p>
			<asp:CheckBox id="cbxTTs" runat="server" Visible="false" oncheckedchanged="cbxTTs_CheckedChanged"></asp:CheckBox>
			</form>
    <!--#include file="inc/footer.aspx"-->
</HTML>
