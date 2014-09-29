<%@ Page language="c#" Inherits="WebApplication2.frmSkillResources" CodeFile="frmSkillCourses.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 204px" runat="server" AutoGenerateColumns="False" Width="914px" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SkillId" ReadOnly="True">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProjectId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProviderName" HeaderText="Course Providers"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Courses">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SupplierLicId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProviderLicName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProviderName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProviderId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnClasses" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Width="88px" Font-Size="Smaller" Font-Bold="True" Text="Classes" CommandName="Classes"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents2" style="Z-INDEX: 106; LEFT: 10px; POSITION: absolute; TOP: 77px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 150px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Exit" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="962px" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 161px; POSITION: absolute; TOP: 150px" runat="server" Width="134px" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add/Remove" Font-Size="Smaller" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Width="861px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
