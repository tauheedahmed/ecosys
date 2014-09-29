<%@ Page language="c#" Inherits="WebApplication2.EmergencyPlans1" buffer="False" CodeFile="frmEventOrg.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EmergencyPlans</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="#ffffff">
		<form id="EmergencyPlans" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 14px; POSITION: absolute; TOP: 150px" runat="server" Width="914px" Height="30px" AutoGenerateColumns="False" CellPadding="3" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="#C7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#669999"></SelectedItemStyle>
				<EditItemStyle BackColor="#66CCFF"></EditItemStyle>
				<AlternatingItemStyle ForeColor="Navy" BorderStyle="None" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#000066" BackColor="White"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Events">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description">
						<HeaderStyle Width="500px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EventId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnDelete" runat="server" BackColor="Navy" BorderStyle="None" Height="25px" Width="77px" Text="Remove" Font-Bold="True" ForeColor="White" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<asp:button id="btnExit" style="Z-INDEX: 117; LEFT: 14px; POSITION: absolute; TOP: 98px" runat="server" BackColor="Red" Height="40px" Width="134" ForeColor="White" Font-Size="Smaller" Font-Bold="True" Text="Exit" BorderStyle="None" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 105; LEFT: 14px; POSITION: absolute; TOP: 0px" runat="server" Width="1062px" Height="30px" Font-Bold="True" Font-Size="Small" ForeColor="Navy">Organization Name Here</asp:label><asp:label id="lblTitle" style="Z-INDEX: 102; LEFT: 14px; POSITION: absolute; TOP: 38px" runat="server" Width="834px" Height="24px" Font-Size="Small" ForeColor="Navy">Emergency Events</asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 161px; POSITION: absolute; TOP: 98px" runat="server" Width="174px" Height="40px" BackColor="Red" Font-Bold="True" Font-Size="Smaller" ForeColor="White" Text="Add/Remove Events" BorderStyle="None" onclick="btnAdd_Click"></asp:button>
		</form>
	</body>
</HTML>
