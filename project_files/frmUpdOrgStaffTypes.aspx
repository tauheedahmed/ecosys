<%@ Page language="c#" Inherits="WebApplication2.frmUpdOrgStaffTypes" CodeFile="frmUpdOrgStaffTypes.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->

		<form id="frmAddProcedure" method="post" runat="server">
			<div id="headerSection" >
		<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblStaffTypeName" runat="server"  ></asp:label></h2>
			
		<h2><asp:label id="lblContent1" runat="server" ></asp:label></h2> 
           <p><asp:label id="lblContent2" runat="server" ></asp:label></p> 
           <asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			
           </div>
           <div style="font-weight:bold; color:White; ">
            <div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		
			<p><asp:label id="Label4" runat="server" Text="Salary Currency" > </asp:label>
			<asp:dropdownlist id="lstCurr" runat="server" ></asp:dropdownlist></p>
			<p><asp:label id="Label1" runat="server" Text="Salary Period" ></asp:label>
			<asp:dropdownlist id="lstSalPeriod"  runat="server"  >
				<asp:ListItem Value="0" Selected="True">Year</asp:ListItem>
				<asp:ListItem Value="1">Month</asp:ListItem>
				<asp:ListItem Value="2">Fortnight</asp:ListItem>
				<asp:ListItem Value="3">Week</asp:ListItem>
				<asp:ListItem Value="4">Day</asp:ListItem>
				<asp:ListItem Value="5">Hour</asp:ListItem>
			</asp:dropdownlist></p>
			
			<p><asp:label id="Label3"  runat="server"  Text="Check if TimeSheets Required" > </asp:label>
			<asp:CheckBox id="ckbTimesheet" runat="server" ></asp:CheckBox></p>
			<p><asp:label id="Label6" runat="server" Text="Sequence Order"  > </asp:label></p>
			<asp:textbox id="txtSeq"  runat="server" ToolTip="This is the order in which this staff type will be printed in reports"></asp:textbox>
			
			<p><asp:label id="Label2" runat="server" Text="Check if Inactive"> </asp:label>
			<asp:CheckBox id="ckbStatus" runat="server" ForeColor="White" BorderColor="Navy"></asp:CheckBox></p>
			
			
			</div>
			</form>
	
<!--#include file="inc/footer.aspx"-->
</HTML>
