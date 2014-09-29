<%@ Page language="c#" Inherits="WebApplication2.frmBudgetsClosed" CodeFile="frmBudgetsClosed.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmResourcesInfo" method="post" runat="server">
		<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<h2><asp:label id="lblStatus" runat="server" ></asp:label></h2>
			<asp:label id="lblContents" runat="server" ></asp:label>
			
			<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button></p>
		
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False" >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Source of Funds"></asp:BoundColumn>
					<asp:BoundColumn DataField="FY" HeaderText="FY" >
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" ForeColor="White" Height="25px" BorderStyle="None" BackColor="Teal" Text="Re-Open" Font-Bold="True" CausesValidation="false" CommandName="ReOpen"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
						</Columns>
				</asp:datagrid>
			
			</form>
	<!--#include file="inc/footer.aspx"-->
	</body>
</HTML>
