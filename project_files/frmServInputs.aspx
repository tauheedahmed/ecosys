<%@ Page language="c#" Inherits="WebApplication2.ServInputs" CodeFile="frmServInputs.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Priorities</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmDeadlines" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 11px; POSITION: absolute; TOP: 167px" runat="server" GridLines="None" Width="914px" Height="50px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle ForeColor="#000099" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id"></asp:BoundColumn>
					<asp:BoundColumn DataField="InputName" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ResourceDescription" HeaderText="Description">
						<HeaderStyle Width="500px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Supplier" ReadOnly="True" HeaderText="Supplier">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ResourceInput" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnDelete" runat="server" BackColor="Navy" BorderStyle="None" Height="30px" Width="83px" ForeColor="White" Font-Bold="True" Text="Remove" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:button id="btnOwn" style="Z-INDEX: 109; LEFT: 677px; POSITION: absolute; TOP: 123px" runat="server" BackColor="Navy" BorderStyle="None" Height="40px" Width="120px" Font-Size="Smaller" ForeColor="White" Font-Bold="True" Text="Owned" onclick="btnOwn_Click"></asp:button>
			<asp:button id="btnInstitution" style="Z-INDEX: 108; LEFT: 540px; POSITION: absolute; TOP: 123px" runat="server" BackColor="Navy" BorderStyle="None" Height="40px" Width="120px" Font-Size="Smaller" ForeColor="White" Font-Bold="True" Text="Institutional" onclick="btnInstitution_Click"></asp:button>
			<asp:button id="btnPublic" style="Z-INDEX: 106; LEFT: 407px; POSITION: absolute; TOP: 122px" runat="server" BackColor="Navy" BorderStyle="None" Height="40px" Width="120px" Font-Size="Smaller" ForeColor="White" Font-Bold="True" Text="Public" onclick="btnPublic_Click"></asp:button>
			<asp:TextBox id="txtHeading" style="Z-INDEX: 105; LEFT: 409px; POSITION: absolute; TOP: 85px" runat="server" BackColor="Navy" BorderStyle="None" Height="28px" Width="388px" ForeColor="White" Font-Bold="True">Available Resources</asp:TextBox><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 11px; POSITION: absolute; TOP: 120px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Red" Text="Exit" Font-Bold="True" ForeColor="White" Font-Size="Smaller" onclick="btnExit_Click"></asp:button><asp:label id="lblPriorities" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 46px" runat="server" Width="992px" Height="28px" ForeColor="#000099" Font-Size="Medium">Output Name Here</asp:label><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 5px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="4px" Font-Bold="True" ForeColor="#000099" Font-Size="Medium">Organization Name Here</asp:label></form>
	</body>
</HTML>
