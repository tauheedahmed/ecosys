<%@ Page language="c#" Inherits="WebApplication2.frmOrganizations" CodeFile="frmOrganizations.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
		<form id="frmEmergencyProcedures" method="post" runat="server">
		    <h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		    <h2><asp:label id="lblTitle" Text="Organizations" runat="server" ></asp:label></h2>
		    <asp:label id="lblContents1" runat="server" ></asp:label><asp:label id="lblContents2" runat="server" ></asp:label>
		    <asp:button id="btnNoDelete" runat="server" CommandName="Add" Visible="False" onclick="btnNoDelete_Click"></asp:button>
			<asp:button id="btnDeleteOrg" runat="server" CommandName="Add" Visible="False" onclick="btnDeleteOrg_Click"></asp:button>
			<p><asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button></p>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
			BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Organizations">
						<HeaderStyle Width="600px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button2" runat="server" Text="Select" CommandName="Select"></asp:button>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" ForeColor="White" BackColor="Maroon" Text="Delete" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="CreatorOrg" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
	</form>		
	<!--#include file="inc/footer.aspx"-->
	
</HTML>
