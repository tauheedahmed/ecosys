<%@ Page language="c#" Inherits="WebApplication2.frmUpdProcPReq" CodeFile="frmUpdProcPReq.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		
		<form id="frmUpdProcSAR" method="post" runat="server">
		<div id="headerSection" >
		<h3><asp:label id=lblOrg runat="server"></asp:label></h3>
        <h3><asp:label id=lblBd runat="server"  ></asp:label></h3>
        <h3><asp:label id=lblLoc runat="server" ></asp:label></h3>
        <h3><asp:label id=lblService runat="server" ></asp:label></h3>
        <h3><asp:label id=lblDel runat="server" ></asp:label></h3>
        <h3><asp:label id=lblProject runat="server" ></asp:label></h3>
        <h3> <asp:label id="lblGS" runat="server" ></asp:label></h3>
        <h3><asp:label id=lblTask runat="server" ></asp:label></h3>
		<h3><asp:label id="lblContent1" runat="server" ></asp:label></h3>
		<p><asp:button id="btnAction" runat="server" onclick="btnAction_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
		</div>
		<div style="font-weight:bold; color:White; ">
		<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:50%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		    
		    <div style=" border-bottom: solid 1px White; Padding:1em 0 1em 0;  text-align:center;">
		    <asp:button id="btnSA" runat="server" Text="Supply Contract/Agreement" onclick="btnSA_Click"></asp:button>
		     </div>
		   <div style=" padding:1em 0 0 0;">
		     <p><asp:label id="lblContractTitle" runat="server" ></asp:label></p>  
	<p><asp:label id="lblSupplier" Text="Supplier not identifed" runat="server"  ></asp:label></p>
		   <asp:label id="lblStatus" runat="server" ></asp:label>
		  
	        <p><asp:label id="lblDesc" runat="server" >Comments</asp:label></p>
	        <asp:textbox id="txtDesc" runat="server" Width="30em" Height="83px" ForeColor="Navy" 
	        BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox>
		</div>
		    <p><asp:label id="lblBackup" runat="server" Visible="False">Check if this is a backup resource:</asp:label>
		    <asp:CheckBox id="cbxBackup" runat="server" Visible="False"></asp:CheckBox></p>
		</div>
		
			<div style="float:left; width:40%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
			<asp:label id="lblBudName" runat="server" Visible="False"></asp:label>
			<p><asp:label id="lblPrice" runat="server" Text="Price:  "></asp:label></p>
			<asp:textbox id="txtPrice" runat="server" Width="104px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" BorderColor="Navy"></asp:textbox>
			<asp:label id="lblPerMeasure" runat="server"></asp:label>
			<p><asp:label id="lblTime"  runat="server" Text="Quantity Required: "></asp:label></p>
			<asp:textbox id="txtQty" runat="server" Width="105px" Height="30px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<asp:label id="lblQtyMeasure" runat="server"  ></asp:label>
			<asp:label id="lblType" runat="server"  ></asp:label>
			</div>
			<div style="float:left; width:40%;  background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; " >
		<asp:label id="lblChargeStatus" runat="server" ></asp:label>
		<asp:label id="lblBudget" runat="server" ></asp:label>
		
			<p><asp:button id="btnBud" runat="server" Text="Recalculate Budget Required" onclick="btnRecomputeBudget"></asp:button></p>
			
			<p><asp:label id="lblBudReq" runat="server"  ></asp:label></p>
			<p><asp:label  id="lblBud" runat="server" > </asp:label></p>
			<asp:textbox id="txtBud" runat="server" ></asp:textbox>
			<asp:button id="btnSOF" runat="server" Text="Identify Budget" Visible="False" onclick="btnSOF_Click"></asp:button>
		</div>
		</div>
					
			</form>
			<div style="clear:both">
		<!--#include file="inc/footer.aspx"-->
		</div>
</HTML>
