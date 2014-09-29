<%@ Page language="c#" Inherits="WebApplication2.frmSCLocs" CodeFile="frmSCLocs.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmOrgResTypes</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmOrgResTypes" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 237px" runat="server" GridLines="None" BorderColor="Teal" AutoGenerateColumns="False" BorderStyle="None" AllowSorting="True">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Locations"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Charge Time">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="Button2" runat="server" BorderStyle="None" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Teal" Text="Task-Related" CommandName="Task"></asp:button>
							<asp:button id="Button1" runat="server" BorderStyle="None" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Teal" Text="Process-Related" CommandName="Process"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Visible="False"></PagerStyle>
			</asp:datagrid><asp:label id="lblPerson" style="Z-INDEX: 105; LEFT: 46px; POSITION: absolute; TOP: 47px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" Width="914px" ForeColor="Navy"></asp:label><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 46px; POSITION: absolute; TOP: 9px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" Width="914px" ForeColor="Navy"></asp:label><asp:label id="lblContents" style="Z-INDEX: 103; LEFT: 46px; POSITION: absolute; TOP: 88px" runat="server" Height="24px" Font-Size="Small" Width="909px" ForeColor="Navy"></asp:label><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 46px; POSITION: absolute; TOP: 188px" runat="server" BorderStyle="None" Font-Bold="True" Height="34px" Font-Size="Smaller" Width="134" ForeColor="White" Text="Exit" BackColor="Navy" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
