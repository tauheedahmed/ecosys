<%@ Page language="c#" Inherits="WebApplication2.frmConsumerPlan" CodeFile="frmConsumerPlan.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 46px; POSITION: absolute; TOP: 221px" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Locations">
						<HeaderStyle HorizontalAlign="Left" Width="380px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="60px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="btnResources" runat="server" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Resources Needed" BorderStyle="None" CommandName="Resources"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 46px; POSITION: absolute; TOP: 50px" runat="server" Height="24px" Font-Size="Small" Width="914px" Font-Bold="True" ForeColor="Navy">Organization Name Here</asp:label><asp:label id="lblContents" style="Z-INDEX: 103; LEFT: 46px; POSITION: absolute; TOP: 139px" runat="server" Height="24px" Font-Size="Small" Width="909px" ForeColor="Navy"></asp:label><asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 81px" runat="server" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" ForeColor="White" BorderStyle="None" Text="Exit" BackColor="Red" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
