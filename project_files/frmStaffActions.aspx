<%@ Page language="c#" Inherits="WebApplication2.frmStaffActions" CodeFile="frmStaffActions.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<h2><asp:label id="lblAptType" runat="server" ></asp:label></h2>
		<asp:label id="lblContents1" runat="server"></asp:label>
			<p><asp:button id="btnCancel" runat="server" Text="OK" onclick="btnCancel_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnOK_Click"></asp:button></p>
			
			
			<asp:datagrid id="DataGrid1" runat="server" GridLines="None" ForeColor="Teal" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="People">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status" Visible="False"></asp:BoundColumn>
					<asp:TemplateColumn >
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnApt" runat="server" Text="Update" CommandName="Update"></asp:button>
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnDuties" visible="false" runat="server" ForeColor="White" Font-Bold="True" BackColor="Teal" Text="Duties" CommandName="Duties"></asp:button>
							<asp:button id="btnDelete" runat="server" ForeColor="White" BackColor="Maroon" Text="Delete" BorderStyle="None" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgIdSA" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
	
<!--#include file="inc/footer.aspx"-->
</HTML>
