<%@ Page language="c#" Inherits="WebApplication2.frmUpdBudget" CodeFile="frmUpdBudget.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblFunction" runat="server" ></asp:label></h2>
			<asp:button id="btnAction"  runat="server"  Text="Action"  onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server"  Text="Cancel"  onclick="btnCancel_Click"></asp:button>
			</div>
			<div style="font-weight:bold; color:White; ">
		<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:75%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em;  ">
			<h5><asp:label id="lblFunds"  runat="server" Text="Source of Funds" ></asp:label></h5>
			<asp:dropdownlist id="lstFunds"  runat="server"   ></asp:dropdownlist>
			<h5><asp:label id="lblName" runat="server" Text="Budget Name"></asp:label></h5>
			<asp:textbox id="txtName" runat="server" ></asp:textbox>
			<h5><asp:label id="lblFY" Text="Fiscal Year" runat="server" ></asp:label></h5>
			<asp:dropdownlist id="lstFY"  runat="server"  ></asp:dropdownlist>
			<h5><asp:label id="lblStatus" runat="server" Text="Stage"></asp:label></h5>
			<asp:dropdownlist id="lstStatus"  runat="server"  >
                <asp:ListItem  Value="0">Formulation</asp:ListItem>
                <asp:ListItem Selected="True" Value="1">Open</asp:ListItem>
            </asp:dropdownlist>
			<h5><asp:label id="lblAmt" runat="server" Text="Amount"></asp:label></h5>
			<asp:textbox id="txtAmt" runat="server" ></asp:textbox>
			<h5><asp:label id="lblCurr"  runat="server" Visible="False"></asp:label></h5>
			<asp:dropdownlist id="lstCurr" runat="server"  Visible="False" ></asp:dropdownlist>
            <asp:dropdownlist id="lstVisibility" runat="server" Visible="False"></asp:dropdownlist>
			<asp:label id="Label5" runat="server" Visible="False" Text="Visibility"></asp:label>
			
			<p><asp:label id="lblStartDate" runat="server" Visible="False" >Start Date</asp:label></p>
						<asp:textbox id="txtStartDate" runat="server" Visible="False"></asp:textbox>
						<asp:Label id="lblStart" runat="server" Visible="False"></asp:Label>
			
				<p><asp:label id="lblEndDate" runat="server" Visible="False">End Date</asp:label></p>
			<asp:textbox id="txtEndDate" runat="server" Visible="False"></asp:textbox>
			<asp:Label id="lblEnd" runat="server" Visible="False"></asp:Label>
			
			
			</div>
			</form>
	    <!--#include file="inc/footer.aspx"--></div>
</HTML>
