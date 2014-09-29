<%@ Page language="c#" Inherits="WebApplication2.frmProjCPeople" CodeFile="frmProjCPeople.aspx.cs" %>
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
			<asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 38px; POSITION: absolute; TOP: 36px" runat="server" Font-Size="Small" ForeColor="Navy" Height="20px" Width="962px"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 107; LEFT: 185px; POSITION: absolute; TOP: 131px" runat="server" Font-Size="Smaller" ForeColor="White" Height="35px" Width="135" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 38px; POSITION: absolute; TOP: 60px" runat="server" Font-Size="Small" ForeColor="Navy" Height="19px" Width="974px"></asp:label><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 131px" runat="server" Font-Size="Smaller" ForeColor="White" Height="35px" Width="135" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="OK" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 38px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="26px" BackColor="White" Font-Bold="True" DESIGNTIMEDRAGDROP="13"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 39px; POSITION: absolute; TOP: 168px" runat="server" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" BorderStyle="None" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" ReadOnly="True" HeaderText="Individual Clients">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnRemove" runat="server" Font-Size="X-Small" ForeColor="White" Width="115px" BorderStyle="None" BackColor="Maroon" Font-Bold="True" Text="Remove" CommandName="Remove"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
