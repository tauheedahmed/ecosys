<%@ Page language="c#" Inherits="WebApplication2.frmOrgServices" CodeFile="frmOrgServices.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 216px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" ForeColor="White" BackColor="Maroon" BorderStyle="None" Height="25px" Font-Size="Smaller" Font-Bold="True" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OSTId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents3" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 112px" runat="server" ForeColor="Navy" Height="32px" Width="969px" Font-Size="Small"></asp:label><asp:label id="lblContents2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 76px" runat="server" Height="32px" ForeColor="Navy" Font-Size="Small" Width="969px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server" Height="33px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="134" Text="Exit" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="32px" ForeColor="Navy" Font-Size="Small" Width="962px" Font-Bold="True"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 102; LEFT: 149px; POSITION: absolute; TOP: 176px" runat="server" Height="33px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="129px" Text="Add" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Width="861px"></asp:label></form>
	</body>
</HTML>
