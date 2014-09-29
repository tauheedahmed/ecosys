<%@ Page language="c#" Inherits="WebApplication2.frmOLProjTypes" CodeFile="frmOLProjTypes.aspx.cs" %>
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
			<asp:label id="lblContent3" style="Z-INDEX: 107; LEFT: 9px; POSITION: absolute; TOP: 102px" runat="server" Visible="False" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 65px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:label id="lblContent1" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 11px; POSITION: absolute; TOP: 150px" runat="server" Width="134" Height="37px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" Text="Back" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 10px; POSITION: absolute; TOP: 194px" runat="server" Height="30px" ForeColor="Maroon" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Product Types">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnProjects" runat="server" Font-Size="Smaller" ForeColor="White" BorderStyle="None" Text="Projects" BackColor="Teal" Font-Bold="True" CommandName="Projects"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
