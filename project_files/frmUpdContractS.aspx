<%@ Page language="c#" Inherits="WebApplication2.frmUpdContractS" CodeFile="frmUpdContractS.aspx.cs" %>
<!--#include file="inc/HeaderProc.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
			<h3><asp:label id="lblOrg" runat="server" ></asp:label></h3>
			<h3><asp:label id="lblContent1" runat="server" ></asp:label></h3>
			<asp:label id="lblContent2" runat="server" ></asp:label>
			<p><asp:button id="btnAction" runat="server" Text="OK" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
       </div>
       
       <div style="font-weight:bold; color:White; ">
		
		<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:50%;Padding:.25em .25em .25em 1em;    
		         margin:.25em .25em .25em .25em; ">
		    
		            <div style=" border-bottom: solid 1px White; Padding:1em 0 1em 0;  text-align:left;">
		            <p><asp:label id="lblSupplier" runat="server" ></asp:label></p>
			<asp:button id="btnSuppliers" runat="server" Text="Select Supplier" onclick="btnSuppliers_Click"></asp:button> 
			<p><asp:label id="lblSupplier1" runat="server" >To change supplier:</asp:label></p>
			<p><asp:label id="lblType" runat="server" >Step  1. Identify Type of Supplier Below</asp:label></[>    
			<asp:radiobuttonlist id="rblType"  runat="server" >
				<asp:ListItem Value="0" Selected="True">Organization</asp:ListItem>
				<asp:ListItem Value="1">Individual</asp:ListItem>
			</asp:radiobuttonlist>
			<p><asp:label id="lblStep2"  runat="server" Text="Step 2.  Click Below" ></asp:label></p>
			<asp:button id="btnSupplierList" runat="server" Text="Supplier List" onclick="btnSupplierList_Click"></asp:button>
			</div>
			        
            <p><asp:label id="lblContractTitle" runat="server" Text="Title" ></asp:label></p>
            <asp:textbox id="txtName" runat="server"  Width="30em" ></asp:textbox></p>
            <p><asp:label id="lblCommitmentDate" runat="server" Text="Commitment Date (please enter in form mm/dd/yy)" ></asp:label></p>
			<asp:TextBox id="txtCommitmentDate" runat="server" ></asp:TextBox>
            <p><asp:label id="lblContractStatus" runat="server" Text="Contract Status" ></asp:label>
			<p><asp:dropdownlist id="lstStatus" runat="server" ></asp:dropdownlist></p></p>
            
			</div>
			
			<div style="float:left; width:40%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
			<p><asp:label id="lblDesc" runat="server" >Description</asp:label></p>
             <p><asp:textbox id="txtDesc" runat="server" Width="30em" Height="83px" TextMode="MultiLine"></asp:textbox></p>
              </div>
             
			<div style="float:left; width:40%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
			
			<p><asp:label id="lblPMethod" runat="server" Visible="False">Procurement Method</asp:label>
			<asp:radiobuttonlist id="rblProcMethods" runat="server" Visible="False"></asp:radiobuttonlist></p>
			<p><asp:label id="lblCurr" runat="server" >Payment Currency</asp:label>
			<asp:dropdownlist id="lstCurr" runat="server"  ></asp:dropdownlist>

			<p><asp:label id="lblPTerms" runat="server" Visible="False">Payment Terms</asp:label>
            <asp:radiobuttonlist id="rblPayTerms" runat="server" Visible="False"></asp:radiobuttonlist></p>     
            <p><asp:label id="lblVisibility" runat="server" Height="20px" Width="152px" >Visibility</asp:label></p>
            <asp:dropdownlist id="lstVisibility" runat="server"></asp:dropdownlist>
            </div>
			
			
			 </div>
           </form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
