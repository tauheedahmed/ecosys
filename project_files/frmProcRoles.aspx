<%@ Page language="c#" Inherits="WebApplication2.frmProcRoles" CodeFile="frmProcRoles.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmResourcesInfo" method="post" runat="server">
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 38px; POSITION: absolute; TOP: 36px" runat="server" Width="962px" Height="20px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:button id="btnHome" style="Z-INDEX: 107; LEFT: 180px; POSITION: absolute; TOP: 130px" runat="server" Font-Size="Smaller" ForeColor="White" Height="35px" Width="135" Text="Home" Font-Bold="True" BackColor="Navy" BorderStyle="None"></asp:button><asp:button id="btnMsgAll" style="Z-INDEX: 106; LEFT: 351px; POSITION: absolute; TOP: 130px" runat="server" Width="135px" Height="35px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Message All" Visible="False"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 38px; POSITION: absolute; TOP: 60px" runat="server" Width="974px" Height="19px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 129px" runat="server" Width="135" Height="35px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Back" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 38px; POSITION: absolute; TOP: 8px" runat="server" Height="26px" ForeColor="White" Font-Size="Small" BackColor="Navy" Font-Bold="True" DESIGNTIMEDRAGDROP="13"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 39px; POSITION: absolute; TOP: 168px" runat="server" Height="30px" ForeColor="Maroon" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" BorderStyle="None" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RolesId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" ReadOnly="True" HeaderText="Roles">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" ReadOnly="True" HeaderText="Task Description">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnStaff" runat="server" Font-Size="X-Small" ForeColor="White" Width="115px" BorderStyle="None" BackColor="Teal" Font-Bold="True" Text="Staff" CommandName="Staff"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
