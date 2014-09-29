<%@ Page language="c#" Inherits="WebApplication2.People" CodeFile="frmPeople.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
	
		<form method="post" runat="server">
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblPeople" Text="People" runat="server" ></asp:label></h2>
			<asp:label id="lblContents1" runat="server" ></asp:label></p>
			<p><asp:button id="btnExit" runat="server" Text="Exit" CommandName="Exit" onclick="btnExit_Click"></asp:button>
            <asp:button id="btnAdd" runat="server" Text="Add" CommandName="Add" onclick="btnAdd_Click"></asp:button>
            
            <asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="false" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" 
			BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="FName" HeaderText="First Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="LName" HeaderText="Last Name"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CellPhone" ReadOnly="True" HeaderText="Cell Phone"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="HomePhone" ReadOnly="True" HeaderText="Home Phone"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="WorkPhone" ReadOnly="True" HeaderText="Work Phone"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email" ReadOnly="True" HeaderText="Email"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Address" ReadOnly="True" HeaderText="Address"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnSelect" runat="server" CommandName="Select" Text="Select" ></asp:Button>
							<asp:Button id="btnUpdate" runat="server" CommandName="Update" Text="Update" ></asp:Button>
							<asp:Button id="btnDetails" runat="server" CommandName="Details" Visible="False" Text="Details" ></asp:Button>
							<asp:Button id="btnDelete" runat="server" CommandName="Delete" ForeColor="White" BackColor="Maroon" Text="Delete"  ></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn Visible="False" HeaderText="Select">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="UserLevel" ReadOnly="True" ></asp:BoundColumn>
					
				</Columns>
			</asp:datagrid>
			</form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
