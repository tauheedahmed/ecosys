<%@ Page language="c#" Inherits="WebApplication2.frmBackupsInfo" CodeFile="frmBackups.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmBackupsInfo</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<asp:label id="Label2" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 44px" runat="server" Height="24px" Width="568px" Font-Size="Small" ForeColor="Navy">System and Data Backups</asp:label><asp:label id="lblOrg" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 4px" runat="server" Height="24px" Width="568px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name</asp:label><asp:button id="btnAdd" style="Z-INDEX: 104; LEFT: 158px; POSITION: absolute; TOP: 84px" runat="server" Height="40px" Width="134px" Font-Size="Smaller" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="Red" Text="Add" onclick="btnAdd_Click"></asp:button><asp:button id="btnExit" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 83px" runat="server" Height="40px" Width="134" Font-Size="Smaller" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="Red" Text="Exit" onclick="btnExit_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 131px" runat="server" Height="25px" Width="914px" ForeColor="#000099" BorderStyle="None" BackColor="White" AutoGenerateColumns="False" CellPadding="4" BorderWidth="1px" BorderColor="#CCFFFF">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Resource" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ResourceName" HeaderText="Original">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="BackupResource" ReadOnly="True">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BackupResourceName" HeaderText="Backup">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Timing" HeaderText="Timing">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RetentionPeriod" ReadOnly="True" HeaderText="Retention Period"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Scope" ReadOnly="True" HeaderText="Scope"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Height="25px" Width="80px" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="#000099" Text="Update" CausesValidation="false" CommandName="Update"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnDelete" runat="server" Height="25px" Width="80px" ForeColor="White" Font-Bold="True" BorderStyle="None" BackColor="Red" Text="Delete" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid></form>
	</body>
</HTML>
