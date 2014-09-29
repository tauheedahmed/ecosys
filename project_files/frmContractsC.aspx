<%@ Page language="c#" Inherits="WebApplication2.frmContractsC" CodeFile="frmContractsC.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 32px; POSITION: absolute; TOP: 170px" runat="server" Height="30px" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="OrgIdClient" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ClientName" HeaderText="Clients"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Contract Title">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="StatusId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnSelect" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Font-Size="Smaller" Font-Bold="True" Text="Select" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Font-Bold="True" Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnDelete" runat="server" ForeColor="White" BackColor="Maroon" BorderStyle="None" Height="25px" Font-Bold="True" Text="Delete" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblContents1" style="Z-INDEX: 106; LEFT: 33px; POSITION: absolute; TOP: 87px" runat="server" Height="32px" ForeColor="Navy" Width="962px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 32px; POSITION: absolute; TOP: 121px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Width="134" Font-Size="Smaller" Text="Exit" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 25px" runat="server" Height="32px" ForeColor="Navy" Width="962px" Font-Size="Small" Font-Bold="True"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 102; LEFT: 196px; POSITION: absolute; TOP: 121px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Width="134px" Font-Size="Smaller" Text="Add" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 62px" runat="server" Height="24px" ForeColor="Navy" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
