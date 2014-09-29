<%@ Page language="c#" Inherits="WebApplication2.frmBudFlags" CodeFile="frmBudFlags.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
    		<form id="frmEmergencyProcedures" method="post" runat="server">
    		<div id="headerSection" >
    		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
    		<h2><asp:label id="lblBd" runat="server"  ></asp:label></h2>
			<asp:label id="lblContents" runat="server"  ></asp:label>
			<p><asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
	        <asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p></div>
		
			<asp:datagrid id="DataGrid1" runat="server" CellPadding="4" 
                AutoGenerateColumns="False" >
				<SelectedItemStyle ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle  ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Budget Controls">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description" visible="false" >
						
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<!--#include file="inc/footer.aspx"-->
			</form>
</HTML>
