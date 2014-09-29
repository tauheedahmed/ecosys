<%@ Page language="c#" Inherits="WebApplication2.frmActperiods" CodeFile="frmActperiods.aspx.cs" %>
<!--#include file="inc/HeaderF.aspx"-->
		<form id="frmOrgResTypes" method="post" runat="server">
			
			<h1><asp:label id="lblPerson" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<h3><asp:label id="lblFY" runat="server" ></asp:label></h3>
			<asp:label id="lblContents" runat="server" ></asp:label>
			<p><asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button></p>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"> </asp:BoundColumn>
					<asp:BoundColumn DataField="Startdate" ReadOnly="True" HeaderText="From"> </asp:BoundColumn>
					<asp:BoundColumn DataField="Enddate" ReadOnly="True" HeaderText="To"> </asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" Text="Timesheet" CommandName="Timesheet"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
