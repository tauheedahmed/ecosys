<%@ Page language="c#" Inherits="WebApplication2.frmUpdEventsD" CodeFile="frmUpdEvent.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="frmAddProcedure" method="post" runat="server">
		<h1>Service Models</h1>
			<h2><asp:label id="lblFunction" runat="server" ></asp:label></h2>
			<asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			
			<h4><asp:label id="lblDelName" runat="server" > Name</asp:label></h4>
			<asp:textbox id="txtName" runat="server" Width="395px" ></asp:textbox>
			<h4><asp:label id="lblDesc" runat="server" >Description</asp:label></h4>
			<asp:textbox id="txtDesc" runat="server" TextMode="MultiLine" Height="79px" 
                    Width="368px"></asp:textbox></p>
			<p><asp:label id="lblHouseholdFlag" runat="server" >Please check here if this is a household event</asp:label>
			<asp:CheckBox id="cbxEvent" runat="server" /></p>
			<p><asp:label id="lblVis" runat="server" >Visibility</asp:label>
			</p>
			<asp:dropdownlist id="lstVisibility" runat="server" Width="379px" Height="30px" ForeColor="Navy"></asp:dropdownlist>
		</form><div id="footer">
    <p><!--#include file="inc/footer.aspx"--></p>
    </div>
</HTML>
