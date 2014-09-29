<%@ Page language="c#" Inherits="WebApplication2.frmUpdOSTPayGrade" CodeFile="frmUpdOSTPayGrade.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblContent" runat="server"  ></asp:label></h2>
			
			<p><asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
			
			<h4><asp:label id="lblProcName" runat="server" >Name</asp:label></h4>
			<asp:textbox id="txtName" runat="server" ForeColor="Navy" Height="26px" Width="496px" BorderStyle="Solid" ></asp:textbox>
			
			<p><asp:label id="Label2" runat="server"> Check if Inactive</asp:label>
			<asp:CheckBox id="ckbStatus" runat="server" ForeColor="Navy" BorderColor="Navy"></asp:CheckBox></p>
			<asp:label id="lblSal" runat="server" ></asp:label>
			
			<h4><asp:label id="Label5" runat="server" >Average Salary</asp:label></h4>
			<asp:textbox id="txtSalAve" runat="server" Width="184px" Height="26px" ForeColor="Navy" BorderStyle="Solid"></asp:textbox>
			
			<h4><asp:label id="Label3" runat="server" >Minimum Salary</asp:label></h4>
			<asp:textbox id="txtSalMin" runat="server" Width="184px" Height="26px" ForeColor="Navy" BorderStyle="Solid" ></asp:textbox>
			
			<h4><asp:label id="Label1" runat="server" >Maximum Salary</asp:label></h4>
			<asp:textbox id="txtSalMax" runat="server" Width="184px" Height="26px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			
			<h4><asp:label id="Label6" runat="server" >Overtime Rate</asp:label></h4>
			<asp:textbox id="txtOvt" runat="server" ToolTip="0=no overtime paid, 1=same as regular, 1.5=1.5 times regular, etc."></asp:textbox>
			
			
			
			
			
			</form>
</HTML>
