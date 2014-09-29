<%@ Page language="c#" Inherits="WebApplication2.frmPeopleStatus" CodeFile="frmPeopleStatus.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Emergency Procedures</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 6px; POSITION: absolute; TOP: 197px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False" Font-Size="Small">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle Font-Size="X-Small" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle Font-Size="X-Small" HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ServiceName" HeaderText="Assignments">
						<HeaderStyle HorizontalAlign="Left" Width="200px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="StartTime" HeaderText="Start" DataFormatString="{0:d}">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EndTime" ReadOnly="True" HeaderText="End" DataFormatString="{0:d}">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="OrgStatus" ReadOnly="True" HeaderText="Status"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleStatus" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="RoleName" ReadOnly="True" HeaderText="Role">
						<HeaderStyle HorizontalAlign="Left" Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Task Description">
						<HeaderStyle HorizontalAlign="Left" Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="200px"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnDetails" runat="server" Font-Size="Smaller" Width="61px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Details" Font-Bold="True" CommandName="Details"></asp:button>
							<asp:button id="btnStaff" runat="server" Font-Size="Smaller" Width="61px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Staff" Font-Bold="True" CommandName="Staff"></asp:button>
							<asp:button id="btnClients" runat="server" Font-Size="Smaller" Width="61px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Clients" Font-Bold="True" CommandName="Clients"></asp:button>
							<asp:button id="Button7" runat="server" Font-Size="Smaller" Width="88px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Charge Time" Font-Bold="True" Visible="False" CommandName="Time"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="TaskName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LicOrg" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="MgrOrg" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LicId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Loc" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocAddress" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Comment" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="TaskId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceType" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblOrg" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="11px" Width="814px" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:label id="Label1" style="Z-INDEX: 105; LEFT: 13px; POSITION: absolute; TOP: 160px" runat="server" ForeColor="Navy" Height="27px" Width="861px" Font-Size="Smaller"></asp:label><asp:label id="lblContents2" style="Z-INDEX: 104; LEFT: 10px; POSITION: absolute; TOP: 77px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 103; LEFT: 11px; POSITION: absolute; TOP: 107px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="40px" Width="134" Font-Size="Smaller" Text="Exit" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
