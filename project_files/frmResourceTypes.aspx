<%@ Page language="c#" Inherits="WebApplication2.frmResourceTypes" CodeFile="frmResourceTypes.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 134px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Resource/Service Types">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="VisId" ReadOnly="True" HeaderText="Visibility"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ParentId" ReadOnly="True">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceProvider"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="Button4" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="25px" Font-Bold="True" Text="Update" Width="80px" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnProviders" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="25px" Font-Bold="True" Text="Service Providers" CommandName="Providers" CausesValidation="false"></asp:Button>
							<asp:Button id="Button5" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="25px" Font-Bold="True" Text="Delete" Width="80px" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="QtyMeasuresId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Price" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 85px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="40px" Font-Bold="True" Font-Size="Smaller" Text="Exit" Width="134" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="32px" Font-Bold="True" Font-Size="Small" Width="962px">Organization Name Here</asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 172px; POSITION: absolute; TOP: 87px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="40px" Font-Bold="True" Font-Size="Smaller" Text="Add" Width="134px" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" ForeColor="Navy" Height="24px" Font-Size="Small" Width="861px"></asp:label></form>
	</body>
</HTML>
