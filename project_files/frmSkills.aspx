<%@ Page language="c#" Inherits="WebApplication2.frmSkills" CodeFile="frmSkills.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 148px" runat="server" AutoGenerateColumns="False" Width="700px" Height="30px" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True" HeaderText="Visibility">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" Width="190px" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Width="88px" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Text="Update" Font-Bold="True" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnCourses" runat="server" Width="88px" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Text="Courses" Font-Bold="True" CommandName="Courses" CausesValidation="false"></asp:Button>
							<asp:Button id="Button5" runat="server" Width="88px" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" Text="Delete" Font-Bold="True" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 32px; POSITION: absolute; TOP: 99px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Exit" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 25px" runat="server" Width="962px" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 196px; POSITION: absolute; TOP: 99px" runat="server" Width="134px" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add" Font-Size="Smaller" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 62px" runat="server" Width="861px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
