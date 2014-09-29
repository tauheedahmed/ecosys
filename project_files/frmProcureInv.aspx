<%@ Page language="c#" Inherits="WebApplication2.frmProcureInv" CodeFile="frmProcureInv.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 171px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#000099" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="InventoryId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Goods" HeaderText="Goods">
						<HeaderStyle Width="100px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" HeaderText="Location"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnRemove" runat="server" ForeColor="White" BackColor="Maroon" BorderStyle="None" Height="25px" Width="80px" Font-Bold="True" Text="Remove" CommandName="Remove" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblContents1" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server" Height="24px" ForeColor="Navy" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 9px; POSITION: absolute; TOP: 128px" runat="server" Height="35px" BorderStyle="None" BackColor="Navy" ForeColor="White" Width="134" Font-Size="Smaller" Text="Exit" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="32px" ForeColor="Navy" Width="962px" Font-Size="Small" Font-Bold="True"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 153px; POSITION: absolute; TOP: 129px" runat="server" Height="35px" BorderStyle="None" BackColor="Navy" ForeColor="White" Width="134px" Font-Size="Smaller" Text="Add" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 102; LEFT: 7px; POSITION: absolute; TOP: 78px" runat="server" Height="24px" ForeColor="Navy" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
