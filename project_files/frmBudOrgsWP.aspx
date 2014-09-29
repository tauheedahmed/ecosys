<%@ Page language="c#" Inherits="WebApplication2.frmBudOrgsWP" CodeFile="frmBudOrgsWP.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
<div id="maindiv" >
		
		<form id="Form1" method="post" runat="server">
			<div id="headerSection" >
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<p><asp:label id="lblContents" runat="server" ></asp:label></p>
		<asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
			</div>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<SelectedItemStyle ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#000099" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="BOrgName" HeaderText="Budget Provider">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BudName" HeaderText="Budgets">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CurrCode" HeaderText="Currency">
						<HeaderStyle HorizontalAlign="Left" > </HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" Text="Select" CommandName="Select"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="BudgetsId"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
<!--#include file="inc/footer.aspx"-->
</HTML>
