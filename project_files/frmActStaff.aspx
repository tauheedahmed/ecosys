<%@ Page language="c#" Inherits="WebApplication2.frmActStaff" CodeFile="frmActStaff.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 38px; POSITION: absolute; TOP: 34px" runat="server" Width="962px" Height="20px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:label id="lblContent3" style="Z-INDEX: 109; LEFT: 39px; POSITION: absolute; TOP: 88px" runat="server" Width="962px" Height="20px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnMsgAll" style="Z-INDEX: 107; LEFT: 362px; POSITION: absolute; TOP: 122px" runat="server" Width="140px" Height="40px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" BorderStyle="None" Text="Message All" onclick="btnMsgAll_Click"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 106; LEFT: 183px; POSITION: absolute; TOP: 122px" runat="server" Width="171px" Height="40px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" BorderStyle="None" onclick="btnAdd_Click"></asp:button><asp:label id="lblContent2" style="Z-INDEX: 105; LEFT: 38px; POSITION: absolute; TOP: 60px" runat="server" Width="974px" Height="19px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 122px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" BorderStyle="None" Text="Exit" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 38px; POSITION: absolute; TOP: 11px" runat="server" Width="914px" Height="17px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 39px; POSITION: absolute; TOP: 165px" runat="server" Width="914px" Height="30px" ForeColor="White" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" BorderStyle="None" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleName" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RoleName" ReadOnly="True" HeaderText="Role"></asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleStatus" HeaderText="Status (Person)"></asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleStatusTime" HeaderText="Update (Person)">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="OrgStatus" ReadOnly="True" HeaderText="Status">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CallerId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="200px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnConfirm" runat="server" Font-Size="X-Small" ForeColor="White" Height="25px" Width="88px" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Confirm" CommandName="Confirm"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="btnUpd" runat="server" ForeColor="White" Font-Size="X-Small" Font-Bold="True" BackColor="Navy" Text="Update" BorderStyle="None" CommandName="Update"></asp:Button>
							<asp:Button id="btnRemove" runat="server" ForeColor="White" Font-Size="X-Small" Font-Bold="True" BackColor="Red" Text="Remove" BorderStyle="None" CommandName="Remove"></asp:Button>
							<asp:Button id="btnMessage" runat="server" ForeColor="White" Font-Size="X-Small" Font-Bold="True" BackColor="Navy" Text="Message" BorderStyle="None" CommandName="Message"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
