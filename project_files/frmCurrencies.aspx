<%@ Page language="c#" Inherits="WebApplication2.frmCurrencies" CodeFile="frmCurrencies.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmResourcesInfo</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmResourcesInfo" method="post" runat="server">
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Width="1019px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:button id="btnAdd" style="Z-INDEX: 107; LEFT: 160px; POSITION: absolute; TOP: 139px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="Add" BorderStyle="None" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 90px" runat="server" Width="1019px" Height="24px" ForeColor="Navy" Font-Size="Small" Visible="False"></asp:label><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 12px; POSITION: absolute; TOP: 139px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="OK" BackColor="Navy" Font-Bold="True" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="1013px" Height="31px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 12px; POSITION: absolute; TOP: 194px" runat="server" Height="30px" ForeColor="Navy" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Currencies">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Code" ReadOnly="True" HeaderText="Code">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Font-Size="Smaller" ForeColor="White" BorderStyle="None" Text="Update" BackColor="Teal" Font-Bold="True" CommandName="Update"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="NamePlural" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
