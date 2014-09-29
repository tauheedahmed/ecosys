<%@ Page language="c#" Inherits="WebApplication2.frmUserIds" CodeFile="frmUserIds.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->

		<form id="frmOrgs" method="post" runat="server">
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<h2><asp:label id="lblContents" runat="server" ></asp:label></h2>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button>
				<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="UserId" HeaderText="UserId">
						<HeaderStyle Width="80px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="PersonName" HeaderText="Assigned to">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Password" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status">
						<HeaderStyle Width="40px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="270px"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnMsg" runat="server" Text="Message" Visible="false" CommandName="Msg" CausesValidation="false"></asp:Button>
							<asp:Button id="Button3" runat="server" Text="Delete" ForeColor="White" BackColor="Maroon" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="UserTypeId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
		<!--#include file="inc/footer.aspx"-->
</HTML>
