<%@ Page language="c#" Inherits="WebApplication2.frmUpdInventory" CodeFile="frmUpdInventory.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
			<div id="headerSection" >
			<h2><asp:label id=lblOrg runat="server"></asp:label></h2>
            <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
            <h5><asp:label id=lblLoc runat="server" ></asp:label></h5>
            <h5><asp:label id=lblAction runat="server"  ></asp:label></h5>
            
            <h5><asp:label id=lblService runat="server" ></asp:label></h5>
            <h5><asp:label id=lblProject runat="server" ></asp:label></h5>
            <h5><asp:label id=lblTask runat="server" ></asp:label></h5>
            <h5><asp:label id=lblEventName runat="server" ></asp:label></h5>
            <h5><asp:label id=lblRole runat="server" ></asp:label></h5>
            <asp:label id="lblContent1" runat="server"  ></asp:label>
			<p><asp:button id="btnAction"  runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnProc"  runat="server" Text = "Request Procurement" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
			
			</div>
			<div style="font-weight:bold; color:White; ">
			<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
			<h5><asp:label id="lblLocations" runat="server" >Location</asp:label></h5>
			<asp:dropdownlist id="lstLocations" runat="server" ForeColor="Navy" 
                Height="16px" ></asp:dropdownlist>
			<h5><asp:label id="lblSubLoc" runat="server" >Room No</asp:label></h5>
			<asp:textbox id="txtSubLoc" runat="server" 
                ></asp:textbox>
			<h5><asp:label id="lblResourceTypes" runat="server" >Resource Type</asp:label></h5>
			<asp:dropdownlist id="lstResourceTypes" runat="server" ForeColor="Navy" 
                AutoPostBack="True" 
                onselectedindexchanged="lstResourceTypes_SelectedIndexChanged" ></asp:dropdownlist>
               <h5><asp:label id="lblQty" runat="server" >Quantity</asp:label></h5>
			<asp:textbox id="txtQty" runat="server" 
                ></asp:textbox>                
                <h5><asp:label id="Label2" runat="server" >Description</asp:label></h5>
			<asp:textbox id="txtDesc" runat="server" Height="63px" TextMode="MultiLine" 
                Width="357px" ></asp:textbox>
                </div>
                <div style="clear:right; float:left;  background-color:Gray;  border:solid 1px White; Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
                <h5><asp:label id="lblStatus" runat="server" >Item Status</asp:label></h5>
			<asp:radiobuttonlist id="rblStatus" runat="server" ></asp:radiobuttonlist>
			
			<h5><asp:label id="lblVisibility" runat="server" >Visibility</asp:label></h5>
			<asp:dropdownlist id="lstVisibility" runat="server" ForeColor="Navy" ></asp:dropdownlist>
			
			</div></div>
			
			<!--#include file="inc/footer.aspx"-->
			</div>
			</form>
			
</HTML>
