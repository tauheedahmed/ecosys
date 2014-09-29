<%@ Page language="c#" Inherits="WebApplication2.frmServicesSel" CodeFile="frmServicesSel.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Outputs</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 34px; POSITION: absolute; TOP: 134px" runat="server" ToolTip="All information, service and material outputs produced by this entity are listed here." HorizontalAlign="Left" Width="1040px" Height="50px" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<EditItemStyle Height="60px"></EditItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name">
						<HeaderStyle HorizontalAlign="Left" Width="300px" VerticalAlign="Bottom"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Availability" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SupplierOrganization" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" Width="170px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="btnDetails" runat="server" Width="80px" Height="25px" BorderStyle="None" BackColor="Navy" Font-Bold="True" ForeColor="White" Text="Update" CausesValidation="false" CommandName="Update"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Width="80px" Height="25px" BorderStyle="None" BackColor="Red" Font-Bold="True" ForeColor="White" Text="Delete" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblOrgt" style="Z-INDEX: 106; LEFT: 35px; POSITION: absolute; TOP: 37px" runat="server" Width="914px" Height="22px" Font-Bold="True" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 33px; POSITION: absolute; TOP: 93px" runat="server" Width="134" Height="35px" BorderStyle="None" BackColor="Red" Font-Bold="True" ForeColor="White" Font-Size="Smaller" Text="Exit"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 34px; POSITION: absolute; TOP: 7px" runat="server" Width="914px" Height="31px" Font-Bold="True" ForeColor="Navy" Font-Size="Small">Organization Name Here</asp:label><asp:button id="btnAdd" style="Z-INDEX: 102; LEFT: 180px; POSITION: absolute; TOP: 94px" runat="server" Width="133px" Height="35px" BorderStyle="None" BackColor="Red" Font-Bold="True" ForeColor="White" Text="Add"></asp:button><asp:label id="lblContent1" style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 64px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
