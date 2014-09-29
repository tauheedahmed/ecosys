<%@ Page language="c#" Inherits="WebApplication2.frmRoleSkills" CodeFile="frmRoleSkills.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 197px" runat="server" AutoGenerateColumns="False" Width="400px" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Skills">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SkillId" ReadOnly="True">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="100px"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnCourses" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Width="89px" Font-Size="Smaller" Font-Bold="True" Text="Courses" CommandName="Courses" Visible="False"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents2" style="Z-INDEX: 106; LEFT: 10px; POSITION: absolute; TOP: 77px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 150px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Exit" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="962px" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 161px; POSITION: absolute; TOP: 150px" runat="server" Width="134px" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add/Remove" Font-Size="Smaller" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Width="861px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
