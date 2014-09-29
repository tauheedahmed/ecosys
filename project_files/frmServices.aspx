<%@ Page language="c#" Inherits="WebApplication2.frmServices" CodeFile="frmServices.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Outputs</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 31px; POSITION: absolute; TOP: 164px" runat="server" AutoGenerateColumns="False" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" Height="50px" HorizontalAlign="Left" ToolTip="All information, service and material outputs produced by this entity are listed here." ForeColor="Teal">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<EditItemStyle Height="60px"></EditItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services">
						<HeaderStyle HorizontalAlign="Left" Width="400px" VerticalAlign="Bottom"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents2" style="Z-INDEX: 106; LEFT: 35px; POSITION: absolute; TOP: 98px" runat="server" ForeColor="Navy" Height="22px" Font-Size="XX-Small" Width="734px"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 104; LEFT: 33px; POSITION: absolute; TOP: 67px" runat="server" Height="22px" ForeColor="Navy" Font-Size="XX-Small" Width="732px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 31px; POSITION: absolute; TOP: 123px" runat="server" BackColor="Navy" BorderStyle="None" Height="35px" ForeColor="White" Text="Exit" Font-Bold="True" Width="134" Font-Size="Smaller" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 27px" runat="server" BackColor="Navy" Height="31px" ForeColor="White" Font-Bold="True" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
