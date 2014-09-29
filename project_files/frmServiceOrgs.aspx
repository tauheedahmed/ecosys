<%@ Page language="c#" Inherits="WebApplication2.frmServiceOrgs" CodeFile="frmServiceOrgs.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmOrgs</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body rightMargin="0">
		<form id="frmOrgs" method="post" runat="server">
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 27px; POSITION: absolute; TOP: 83px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="904px"></asp:label>
			<asp:button id="Button2" style="Z-INDEX: 108; LEFT: 188px; POSITION: absolute; TOP: 141px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="281px" Font-Bold="True" BorderStyle="None" Text="Add" BackColor="Red"></asp:button>
			<asp:button id="btnAddt" style="Z-INDEX: 107; LEFT: 335px; POSITION: absolute; TOP: 188px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134px" Font-Bold="True" BorderStyle="None" Text="Teacher Group" BackColor="Red" onclick="btnAddt_Click"></asp:button><asp:label id="lblService" style="Z-INDEX: 106; LEFT: 27px; POSITION: absolute; TOP: 41px" runat="server" Font-Size="Small" ForeColor="Navy" Height="36px" Width="904px" Font-Bold="True"></asp:label><asp:button id="btnallMsg" style="Z-INDEX: 105; LEFT: 494px; POSITION: absolute; TOP: 188px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134px" Font-Bold="True" BorderStyle="None" Text="Message All" BackColor="Navy" onclick="btnallMsg_Click"></asp:button><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 27px; POSITION: absolute; TOP: 188px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BorderStyle="None" Text="Exit" BackColor="Red" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 27px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="36px" Width="904px" Font-Bold="True"></asp:label><asp:button id="btnAdds" style="Z-INDEX: 102; LEFT: 187px; POSITION: absolute; TOP: 188px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134px" Font-Bold="True" BorderStyle="None" Text="Student Batch" BackColor="Red" onclick="btnAdd_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 27px; POSITION: absolute; TOP: 232px" runat="server" Height="30px" Width="914px" BorderStyle="None" AutoGenerateColumns="False">
				<SelectedItemStyle BorderStyle="None"></SelectedItemStyle>
				<EditItemStyle BorderWidth="2px" BorderStyle="Solid" BorderColor="#0000C0" BackColor="#00C0C0"></EditItemStyle>
				<AlternatingItemStyle Font-Size="Small" ForeColor="#000099" BorderStyle="None" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#000099" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BorderColor="Navy" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgType">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name">
						<HeaderStyle Font-Size="Small" Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Phone" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Address" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" Width="80px" Height="25px" ForeColor="White" BackColor="Navy" Text="Update" BorderStyle="None" Font-Bold="True" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnStaff" runat="server" Width="88px" Height="25px" ForeColor="White" BackColor="Navy" Text="Individuals" BorderStyle="None" Font-Bold="True" CommandName="Staffing" CausesValidation="false"></asp:Button>
							<asp:Button id="Button8" runat="server" Width="80px" Height="25px" ForeColor="White" BackColor="Navy" Text="Message" BorderStyle="None" Font-Bold="True" CommandName="Msg" CausesValidation="false"></asp:Button>
							<asp:Button id="Button9" runat="server" Width="80px" Height="25px" ForeColor="White" BackColor="Red" Text="Delete" BorderStyle="None" Font-Bold="True" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
