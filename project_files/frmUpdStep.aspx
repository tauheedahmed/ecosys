<%@ Page language="c#" Inherits="WebApplication2.frmUpdStep" CodeFile="frmUpdStep.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
		
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1>		<asp:label id="Label2" runat="server" >EcoSys: Service Models</asp:label>
		</h1>
			<p><asp:label id="lblContent" runat="server" > Function Title</asp:label></p>
			<asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			
			<div style="font-weight:bold; color:White; ">
		<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:50%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; ">
			<p><asp:label id="lblProcName" runat="server" > Step Name</asp:label>
			<asp:textbox id="txtProcessName" runat="server" Width="374px" ></asp:textbox>
			</p><asp:label id="Label1" runat="server" >Description</asp:label>
			<asp:textbox id="txtDesc" runat="server" Height="96px" Width="380px" ></asp:textbox>
			<p><asp:label id="Label9" runat="server" Visible="False">Location Type</asp:label>
			<asp:dropdownlist id="DropDownList1" runat="server" Visible="False"></asp:dropdownlist></p>
			</div></div>
			</form>
			</div>
			<!--#include file="inc/footer.aspx"-->
</HTML>
