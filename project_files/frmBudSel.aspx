<%@ Page language="c#" Inherits="WebApplication2.frmBudSel" CodeFile="frmBudSel.aspx.cs" %>
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
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="920px"></asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 107; LEFT: 13px; POSITION: absolute; TOP: 179px" runat="server" ForeColor="#A7D7CC" Height="30px" BorderStyle="None" BackColor="White" AutoGenerateColumns="False" GridLines="None" AllowSorting="True" CellPadding="4" BorderWidth="1px" BorderColor="#CC9966">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="BorgName" HeaderText="Budget Provider"></asp:BoundColumn>
					<asp:BoundColumn DataField="BudName" ReadOnly="True" HeaderText="Budgets"></asp:BoundColumn>
					<asp:BoundColumn DataField="CurrCode" HeaderText="Currency"></asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" ForeColor="White" Font-Size="Smaller" BackColor="Teal" BorderStyle="None" Font-Bold="True" Text="Select" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnAdd" style="Z-INDEX: 106; LEFT: 168px; POSITION: absolute; TOP: 122px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 105; LEFT: 7px; POSITION: absolute; TOP: 73px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="920px"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 16px; POSITION: absolute; TOP: 122px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="31px" Width="914px" Font-Bold="True" Visible="False"></asp:label></form>
	</body>
</HTML>
