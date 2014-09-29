<%@ Page language="c#" Inherits="WebApplication2.frmContactTypesAll" CodeFile="frmContactTypesAll.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="962px"></asp:label>
			<asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 9px; POSITION: absolute; TOP: 76px" runat="server" Width="974px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 105; LEFT: 165px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="Add" BorderStyle="None" onclick="btnAdd_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 9px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Red" Text="Exit" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="31px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 9px; POSITION: absolute; TOP: 155px" runat="server" ForeColor="White" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Width="88px" Height="25px" ForeColor="White" BorderStyle="None" Text="Update" BackColor="Navy" Font-Bold="True" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Width="88px" Height="25px" ForeColor="White" BorderStyle="None" Text="Delete" BackColor="Red" Font-Bold="True" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
