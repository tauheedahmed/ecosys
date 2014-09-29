<%@ Page language="c#" Inherits="WebApplication2.frmServicesPeople" CodeFile="frmServicesPeople.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 31px; POSITION: absolute; TOP: 137px" runat="server" AutoGenerateColumns="False" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" Height="50px" Width="1022px" HorizontalAlign="Left" ToolTip="All information, service and material outputs produced by this entity are listed here.">
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
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SupplierOrganization" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" Width="280px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="btnItems" runat="server" Width="111px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Text="Items" CausesValidation="false" CommandName="Items"></asp:Button>
							<asp:Button id="btnUpdate" runat="server" Width="80px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Text="Update" CausesValidation="false" CommandName="Update"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Width="80px" Height="25px" BorderStyle="None" BackColor="Red" ForeColor="White" Font-Bold="True" Text="Delete" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" Width="88px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="btnBIA" runat="server" Width="110px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Text="Analysis" CommandName="BIA" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" Width="88px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="btnRegular" runat="server" Width="80px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Text="Regular" Visible="False" CausesValidation="false" CommandName="Regular"></asp:Button>
							<asp:Button id="btnProcedures" runat="server" Width="100px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Text="Procedures" CausesValidation="false" CommandName="Procedures"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="EventTypeName" ReadOnly="True" HeaderText="EventTypeName"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EventTypeId" ReadOnly="True" HeaderText="EventTypeId"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Timetable" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="OrgNamet" ReadOnly="True" HeaderText="SupplierOrgName"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 33px; POSITION: absolute; TOP: 93px" runat="server" BackColor="Red" BorderStyle="None" Height="35px" Width="134" Text="Exit" Font-Bold="True" ForeColor="White" Font-Size="Smaller" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg1" style="Z-INDEX: 104; LEFT: 33px; POSITION: absolute; TOP: 27px" runat="server" Height="31px" Width="914px" Font-Bold="True" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 102; LEFT: 180px; POSITION: absolute; TOP: 94px" runat="server" BackColor="Red" BorderStyle="None" Height="35px" Width="133px" Text="Add" Font-Bold="True" ForeColor="White" onclick="btnAdd_Click"></asp:button><asp:label id="lblContent1" style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 64px" runat="server" Height="22px" Width="914px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
