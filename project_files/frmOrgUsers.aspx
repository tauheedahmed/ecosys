<%@ Page language="c#" Inherits="WebApplication2.frmOrgUsers" CodeFile="frmOrgUsers.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->

		<form id="frmOrgs" method="post" runat="server">
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<p><asp:label id="lblContents" runat="server" ></asp:label></p>
			<asp:button id="btnallMsg" runat="server" Visible="false" Text="Message All" BackColor="Navy" Font-Bold="True"></asp:button>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" HeaderText="Name">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="email" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Phone" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUserIds" runat="server" Text="User Ids" CommandName="UserIds" ></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
