<%@ Page language="c#" Inherits="WebApplication2.frmContractsS" CodeFile="frmContractsS.aspx.cs" %>
<!--#include file="inc/HeaderProc.aspx"-->
	
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<h3><asp:label id="lblOrg" runat="server" ></asp:label></h3>
			<h3><asp:label id="lblContents" runat="server" ></asp:label></h3>
			<asp:label id="lblContents1" runat="server" ></asp:label>
			<p><asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server" Text="Add" CommandName="Add" onclick="btnAdd_Click"></asp:button></p>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="OrgIdSupplier" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="SupplierName" HeaderText="Suppliers">
						<HeaderStyle VerticalAlign="Top"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Contract Title">
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" HeaderText="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="StatusId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnSelect" runat="server" Text="Select" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn visible="false">
						<ItemTemplate>
							<asp:Button id="btnProcures" runat="server" Text="Procurement Items" CommandName="Procurements" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnDelete" runat="server" Text="Delete" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				    <asp:BoundColumn DataField="CurrName" ReadOnly="True" Visible="False">
                    </asp:BoundColumn>
				</Columns>
			</asp:datagrid>			
			</form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
