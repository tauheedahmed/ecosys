<%@ Page language="c#" Inherits="WebApplication2.frmServiceProcs" CodeFile="frmServiceProcs.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Emergency Procedures</title>
<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
  </HEAD>
<body bgColor=white>
<form id=frmEmergencyProcedures method=post runat="server"><asp:datagrid id=DataGrid1 style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 142px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="31px" Width="658px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="800px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Comments" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnComments" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="25px" Width="98px" Font-Size="Smaller" Font-Bold="True" Text="Comments" CommandArgument="Comments"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id=btnExit style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="40px" Width="134" Font-Size="Smaller" Font-Bold="True" Text="Exit" onclick="btnExit_Click"></asp:button><asp:label id=lblOrg style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="32px" Width="962px" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:button id=btnAdd style="Z-INDEX: 103; LEFT: 161px; POSITION: absolute; TOP: 88px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="40px" Width="134px" Font-Size="Smaller" Font-Bold="True" Text="Add/Remove" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id=lblContents1 style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
