<%@ Page language="c#" Inherits="WebApplication2.frmUpdResourceType" CodeFile="frmUpdResourceType.aspx.cs" %>
<!--#include file="inc/HeaderProc.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		<h1><asp:label id="Label3" Text="EcoSys: Service Models" runat="server" ></asp:label></h1>
		<p><asp:label id="lblContent" runat="server" >Content</asp:label></p>
		<asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
		<asp:button id="btnCancel" runat="server"  Text="Cancel" onclick="btnCancel_Click"></asp:button>
		<p><asp:label id="lblProcName" runat="server" >Name</asp:label></p>
		
		<p><asp:textbox id="txtName" Width="407px"  runat="server" ></asp:textbox></p>
		</p><asp:label id="Label4" runat="server" >Description</asp:label>
		<p><asp:textbox id="txtDesc" runat="server" Height="96px" Width="380px" ></asp:textbox></p>
		<p><asp:label id="Label2" runat="server" >Measure of Quantity</asp:label>
		<asp:dropdownlist id="lstQtyMeasure" runat="server" Width="100px" ></asp:dropdownlist>
		<p><asp:label id="Label1" runat="server" Width="137px" Height="23px" Font-Size="Small" BorderStyle="None"> Visibility</asp:label>
		<asp:dropdownlist id="lstVisibility" runat="server" ></asp:dropdownlist>
		</p><asp:label id="lblParentResource" runat="server" >Parent Resource Type</asp:label>
		<asp:dropdownlist id="lstParent" runat="server"></asp:dropdownlist>
		<p><asp:label id="lblError" runat="server"></asp:label></p>
		
		</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>

