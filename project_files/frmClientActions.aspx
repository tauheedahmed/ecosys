<%@ Page language="c#" Inherits="WebApplication2.frmClientActions" CodeFile="frmClientActions.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 35px" runat="server" Width="962px" Height="20px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 9px; POSITION: absolute; TOP: 61px" runat="server" Width="974px" Height="19px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnOk" style="Z-INDEX: 105; LEFT: 38px; POSITION: absolute; TOP: 112px" runat="server" Width="134" Height="36px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Back" BackColor="Navy" Font-Bold="True" onclick="btnBack_Click"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 104; LEFT: 178px; POSITION: absolute; TOP: 112px" runat="server" Width="134" Height="36px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" onclick="btnAdd_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 9px; POSITION: absolute; TOP: 8px" runat="server" Height="17px" ForeColor="White" Font-Size="Small" BackColor="Navy" Font-Bold="True"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 36px; POSITION: absolute; TOP: 155px" runat="server" Height="30px" ForeColor="White" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Client Actions">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnSelect" runat="server" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Select" BackColor="Teal" Font-Bold="True" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Update" BackColor="Teal" Font-Bold="True" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Delete" BackColor="Maroon" Font-Bold="True" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
