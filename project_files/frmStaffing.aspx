<%@ Page language="c#" Inherits="WebApplication2.frmStaffing" CodeFile="frmStaffing.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmStaffing</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<asp:Label id="lblHeading" style="Z-INDEX: 100; LEFT: 30px; POSITION: absolute; TOP: 50px" runat="server" Font-Size="Small" ForeColor="Navy" Height="16px" Width="403px"></asp:Label>
			<asp:Button id="btnLabel" style="Z-INDEX: 111; LEFT: 380px; POSITION: absolute; TOP: 79px" runat="server" Width="285px" Height="26px" ForeColor="Navy" Font-Size="Small" BorderStyle="None" Text="Add Staff" BackColor="White" Font-Bold="True"></asp:Button>
			<asp:button id="btnallMsg" style="Z-INDEX: 110; LEFT: 181px; POSITION: absolute; TOP: 110px" runat="server" Width="134" Height="35px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" Text="Message All" BorderStyle="None" onclick="btnallMsg_Click"></asp:button>
			<asp:Button id="btnAddS" style="Z-INDEX: 109; LEFT: 379px; POSITION: absolute; TOP: 111px" runat="server" Width="134px" Height="34px" ForeColor="White" BorderStyle="None" Text="With Search" BackColor="Navy" Font-Bold="True" onclick="btnAddS_Click"></asp:Button>
			<asp:Label id="lblAnswer" style="Z-INDEX: 107; LEFT: 789px; POSITION: absolute; TOP: 74px" runat="server" Width="306px" Height="81px" ForeColor="Red" Font-Size="X-Small" BorderStyle="None" Visible="False"></asp:Label>
			<asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 110px" runat="server" Width="134" Height="35px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" Text="Exit" BackColor="Red" BorderStyle="None" onclick="btnExit_Click"></asp:button>
			<asp:Label id="lblOrg1" style="Z-INDEX: 103; LEFT: 29px; POSITION: absolute; TOP: 8px" runat="server" Font-Bold="True" Width="703px" Height="31px" ForeColor="Navy" Font-Size="Small"></asp:Label>
			<asp:Button id="btnAdd" style="Z-INDEX: 102; LEFT: 531px; POSITION: absolute; TOP: 111px" runat="server" Font-Bold="True" Width="133px" Height="34px" ForeColor="White" BackColor="Navy" Text="Without Search" BorderStyle="None" onclick="btnAdd_Click"></asp:Button>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 30px; POSITION: absolute; TOP: 155px" runat="server" Height="50px" Width="750px" AutoGenerateColumns="False">
				<EditItemStyle ForeColor="#000099"></EditItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" HeaderText="Role">
						<HeaderStyle Width="200px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="200px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CallerId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RoleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="160px"></HeaderStyle>
						<ItemTemplate>
							<asp:Button id="Button4" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Update" BorderStyle="None" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnMsg" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Message" BorderStyle="None" CommandName="Msg" CausesValidation="false"></asp:Button>
							<asp:Button id="Button5" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Red" Text="Delete" BorderStyle="None" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
