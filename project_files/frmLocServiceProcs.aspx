<%@ Page language="c#" Inherits="WebApplication2.frmLocServiceProcs" CodeFile="frmLocServiceProcs.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 166px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Procedures">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selection(s)">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblContents2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 75px" runat="server" ForeColor="Navy" Height="24px" Font-Size="Small" Width="861px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 118px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="OK" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="White" Height="32px" Font-Size="Small" Font-Bold="True" BackColor="Navy"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 102; LEFT: 149px; POSITION: absolute; TOP: 118px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Font-Bold="True" Text="Cancel" CommandName="Add" Width="76px" onclick="btnCancel_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" ForeColor="Navy" Height="24px" Font-Size="Small" Width="861px"></asp:label></form>
	</body>
</HTML>
