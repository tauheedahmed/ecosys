<%@ Page language="c#" Inherits="WebApplication2.frmRoles" CodeFile="frmRoles.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 148px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px" Width="700px" AutoGenerateColumns="False">
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
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" Width="190px" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Width="88px" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Text="Update" Font-Bold="True" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnSkills" runat="server" Width="88px" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Text="Skills" Font-Bold="True" CommandName="Skills" CausesValidation="false"></asp:Button>
							<asp:Button id="Button5" runat="server" Width="88px" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" Text="Delete" Font-Bold="True" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ParentId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 32px; POSITION: absolute; TOP: 99px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Width="134" Font-Bold="True" Font-Size="Smaller" Text="Exit" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 25px" runat="server" ForeColor="Navy" Height="32px" Width="962px" Font-Bold="True" Font-Size="Small">Organization Name Here</asp:label><asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 196px; POSITION: absolute; TOP: 99px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Width="134px" Font-Bold="True" Font-Size="Smaller" Text="Add" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents" style="Z-INDEX: 102; LEFT: 32px; POSITION: absolute; TOP: 62px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
