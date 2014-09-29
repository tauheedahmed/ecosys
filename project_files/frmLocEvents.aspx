<%@ Page language="c#" Inherits="WebApplication2.frmLocEvents" CodeFile="frmLocEvents.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Emergency Procedures</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 236px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False" ShowFooter="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle Wrap="False"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EventsId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Events">
						<HeaderStyle Width="350px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" CommandName="Staff" Font-Bold="True" Text="Staff Types" Font-Size="Smaller"></asp:button>
							<asp:button id="Button2" runat="server" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" CommandName="Clients" Font-Bold="True" Text="Client Types" Font-Size="Smaller"></asp:button>
							<asp:button id="Button3" runat="server" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" CommandName="Steps" Font-Bold="True" Text="Response Steps" Font-Size="Smaller"></asp:button>
							<asp:button id="btnRemove" runat="server" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" CommandName="Remove" Font-Bold="True" Text="Remove" Font-Size="Smaller"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle VerticalAlign="Top" HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContent2" style="Z-INDEX: 105; LEFT: 7px; POSITION: absolute; TOP: 100px" runat="server" Height="22px" ForeColor="Navy" Width="914px" Font-Size="Small"></asp:label>
			<asp:label id="lblContent1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 15px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="914px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 183px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Back" onclick="btnExit_Click"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 101; LEFT: 149px; POSITION: absolute; TOP: 183px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Font-Bold="True" Text="Add Events" CommandName="Add" onclick="btnAdd_Click"></asp:button></form>
	</body>
</HTML>
