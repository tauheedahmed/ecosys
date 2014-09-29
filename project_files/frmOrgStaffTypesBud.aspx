<%@ Page language="c#" Inherits="WebApplication2.frmOrgStaffTypesBudBud" CodeFile="frmOrgStaffTypesBud.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 32px; POSITION: absolute; TOP: 187px" runat="server" GridLines="None" ForeColor="Teal" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Appointment Types">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnBud" runat="server" Height="25px" BorderColor="Navy" BorderStyle="None" BorderWidth="0px" BackColor="Teal" ForeColor="White" Text="Budget" Font-Bold="True" CommandName="Budget"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" Height="25px" BorderColor="Navy" BorderStyle="None" BorderWidth="0px" BackColor="Teal" ForeColor="White" Text="Position Control" Font-Bold="True" CommandName="ControlPos"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="StaffTypeId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 138px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Exit" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 25px" runat="server" ForeColor="Navy" Height="32px" Font-Size="Small" Width="962px" Font-Bold="True"></asp:label><asp:label id="lblContents" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 62px" runat="server" ForeColor="Navy" Height="24px" Font-Size="Small" Width="861px"></asp:label></form>
	</body>
</HTML>
