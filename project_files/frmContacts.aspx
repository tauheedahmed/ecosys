<%@ Page language="c#" Inherits="WebApplication2.frmContacts" CodeFile="frmContacts.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>frmOrgResTypes</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body>
<form id=frmOrgResTypes method=post runat="server"><asp:datagrid id=DataGrid1 style="Z-INDEX: 100; LEFT: 46px; POSITION: absolute; TOP: 179px" runat="server" AllowSorting="True" GridLines="None" BorderStyle="None" AutoGenerateColumns="False">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Contact">
						<ItemTemplate>
							<asp:TextBox id="txtName" runat="server" BorderStyle="Solid" Width="400px" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Regular Phone">
						<ItemTemplate>
							<asp:TextBox id="txtPhone" runat="server" BorderStyle="Solid" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Cell Phone">
						<ItemTemplate>
							<asp:TextBox id="txtCell" runat="server" BorderStyle="Solid" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" BorderStyle="None" Text="Details" BackColor="Navy" Font-Bold="True" ForeColor="White" CommandName="Details"></asp:Button>
							<asp:Button id="btnDelete" runat="server" BorderStyle="None" Text="Delete" BackColor="DarkCyan" Font-Bold="True" ForeColor="White" CommandName="Delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Name" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RegularPhone" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CellPhone" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Address" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProfileId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:button id=btnAdd style="Z-INDEX: 105; LEFT: 193px; POSITION: absolute; TOP: 124px" runat="server" BorderStyle="None" Text="Add" BackColor="Navy" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" ForeColor="White" onclick="btnAdd_Click"></asp:button><asp:label id=lblOrg style="Z-INDEX: 103; LEFT: 46px; POSITION: absolute; TOP: 50px" runat="server" Height="24px" Font-Size="Small" Width="914px" Font-Bold="True" ForeColor="Navy"></asp:label><asp:label id=lblContents style="Z-INDEX: 102; LEFT: 46px; POSITION: absolute; TOP: 88px" runat="server" Height="24px" Font-Size="Small" Width="909px" ForeColor="Navy"></asp:label><asp:button id=btnExit style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 124px" runat="server" BorderStyle="None" Text="Exit" BackColor="Navy" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" ForeColor="White" onclick="btnExit_Click"></asp:button></FORM>
	</body>
</HTML>
