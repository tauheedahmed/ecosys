<%@ Page language="c#" Inherits="WebApplication2.frmOrgFlags" CodeFile="frmOrgFlags.aspx.cs" %>
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
					<asp:BoundColumn DataField="Name" HeaderText="Type of Flags">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Code" HeaderText="Flag Codes"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:button id="btnCancel" style="Z-INDEX: 107; LEFT: 152px; POSITION: absolute; TOP: 176px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="33px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:label id="lblContents3" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 112px" runat="server" ForeColor="Navy" Height="32px" Width="969px" Font-Size="Small"></asp:label><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 76px" runat="server" Height="32px" ForeColor="Navy" Font-Size="Small" Width="969px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server" Height="33px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="134" Text="OK" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="32px" ForeColor="Navy" Font-Size="Small" Width="962px" Font-Bold="True"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Width="861px"></asp:label></form>
	</body>
</HTML>
