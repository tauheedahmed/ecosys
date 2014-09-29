<%@ Page language="c#" Inherits="WebApplication2.frmTaskList" CodeFile="frmTaskList.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 171px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#000099" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Tasks">
						<HeaderStyle Width="100px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True" HeaderText="Status">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceName" ReadOnly="True" HeaderText="Service"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="25px" Width="80px" Text="Update" Font-Bold="True" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnDelete" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="25px" Width="80px" Text="Delete" Font-Bold="True" CommandName="Delete" CausesValidation="false"></asp:Button>
							<asp:Button id="btnPlan" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Width="80px" Text="Plan" Font-Bold="True" CommandName="Plan"></asp:Button>
							<asp:Button id="btnClients" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Width="80px" Text="Clients" Font-Bold="True" CommandName="Clients"></asp:Button>
							<asp:Button id="btnStaff" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Width="80px" Text="Staff" Font-Bold="True" CommandName="Staff"></asp:Button>
							<asp:Button id="btnResources" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Width="95px" Text="Resources" Font-Bold="True" CommandName="Resources"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Location" ReadOnly="True" HeaderText="LocId"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnRegister" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Width="99px" Text="Register" Font-Bold="True" CommandName="Register"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ClientName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="StaffName" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents1" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label>
			<asp:button id="btnAddTemp" style="Z-INDEX: 106; LEFT: 151px; POSITION: absolute; TOP: 125px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="35" Font-Bold="True" Text="Add Tasks Using Template" Width="285px" ToolTip="Recommended" onclick="btnAddTemp_Click"></asp:button><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 9px; POSITION: absolute; TOP: 124px" runat="server" Width="134" Height="35px" BorderStyle="None" BackColor="Red" ForeColor="White" Text="Exit" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="962px" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 444px; POSITION: absolute; TOP: 125px" runat="server" Width="134px" Height="35px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add Tasks" Font-Size="Smaller" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 102; LEFT: 7px; POSITION: absolute; TOP: 78px" runat="server" Width="861px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
