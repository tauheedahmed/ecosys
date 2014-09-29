<%@ Page language="c#" Inherits="WebApplication2.frmOrgResourcesAll" CodeFile="frmOwnResources.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 10px; POSITION: absolute; TOP: 122px" runat="server" AutoGenerateColumns="False" onselectedindexchanged="DataGrid1_SelectedIndexChanged">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name">
						<HeaderStyle HorizontalAlign="Left" Width="400px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocationId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button2" runat="server" Width="89px" Height="25px" Font-Size="Smaller" ForeColor="White" BackColor="Navy" Text="Update" BorderStyle="None" Font-Bold="True" CommandName="Update"></asp:button>
							<asp:button id="btnDetails" runat="server" Width="89px" Height="25px" Font-Size="Smaller" ForeColor="White" BackColor="Navy" Text="Details" BorderStyle="None" Font-Bold="True" CommandName="Details"></asp:button>
							<asp:button id="Button4" runat="server" Width="89px" Height="25px" Font-Size="Smaller" ForeColor="White" BackColor="Red" Text="Delete" BorderStyle="None" Font-Bold="True" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			<asp:button id="btnAdd" style="Z-INDEX: 107; LEFT: 163px; POSITION: absolute; TOP: 83px" runat="server" Height="30px" Font-Size="Smaller" Width="134" Font-Bold="True" ForeColor="White" BorderStyle="None" Text="Add" BackColor="Navy" onclick="btnAdd_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Font-Bold="True" Width="914px" Font-Size="Small" Height="24px">Organization Name Here</asp:label><asp:label id="lblContent1" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 43px" runat="server" ForeColor="Navy" Width="909px" Font-Size="Small" Height="23px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 12px; POSITION: absolute; TOP: 83px" runat="server" BackColor="Navy" ForeColor="White" Font-Bold="True" Width="134" Text="Exit" BorderStyle="None" Font-Size="Smaller" Height="30px" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
