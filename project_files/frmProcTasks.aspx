<%@ Page language="c#" Inherits="WebApplication2.frmProcTasks" CodeFile="frmProcTasks.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 136px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#000099" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProcName" HeaderText="Type of Task">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
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
					<asp:BoundColumn Visible="False" DataField="StartTime" ReadOnly="True" HeaderText="Start" DataFormatString="{0:d}">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EndTime" ReadOnly="True" HeaderText="End" DataFormatString="{0:d}"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ResourceName" ReadOnly="True" HeaderText="Service"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="25px" Font-Bold="True" Text="Update" Width="80px" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:button id="btnDetails" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="25px" Font-Bold="True" Font-Size="Smaller" Text="Details" Width="88px" CommandName="Details"></asp:button>
							<asp:Button id="btnDelete" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="25px" Font-Bold="True" Text="Delete" Width="80px" CommandName="Delete" CausesValidation="false"></asp:Button>
							<asp:Button id="btnPlan" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Font-Bold="True" Text="Plan" Width="80px" CommandName="Plan"></asp:Button>
							<asp:Button id="btnStaff" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Font-Bold="True" Text="Staff" Width="80px" CommandName="Staff"></asp:Button>
							<asp:Button id="btnClients" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Font-Bold="True" Text="Clients" Width="80px" CommandName="Clients"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Location" ReadOnly="True" HeaderText="LocId"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnRegister" runat="server" ForeColor="White" BackColor="Navy" BorderWidth="0px" BorderStyle="None" BorderColor="Navy" Height="25px" Font-Bold="True" Text="Register" Width="99px" CommandName="Register"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ResourceId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceTypeP" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProcId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 9px; POSITION: absolute; TOP: 87px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Red" ForeColor="White" Text="Exit" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="962px" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 173px; POSITION: absolute; TOP: 89px" runat="server" Width="134px" Height="40px" BorderStyle="None" BackColor="Red" ForeColor="White" Text="Add" Font-Size="Smaller" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents" style="Z-INDEX: 101; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Width="861px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
