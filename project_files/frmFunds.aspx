<%@ Page language="c#" Inherits="WebApplication2.frmFunds" CodeFile="frmFunds.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 225px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Funds">
						<HeaderStyle HorizontalAlign="Left" Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Font-Bold="True" Text="Update" CausesValidation="false" CommandName="Update"></asp:Button>
							<asp:Button id="btnAmts" runat="server" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Font-Bold="True" Text="Accounts" CausesValidation="false" CommandName="Acts"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" Font-Bold="True" Text="Delete" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblFY" style="Z-INDEX: 108; LEFT: 11px; POSITION: absolute; TOP: 111px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 104; LEFT: 153px; POSITION: absolute; TOP: 182px" runat="server" Height="35" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add" Font-Bold="True" Width="135px" onclick="btnAdd_Click"></asp:button><asp:button id="btnExit" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 182px" runat="server" Height="35px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Back" Font-Bold="True" Width="135" Font-Size="Smaller" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="32px" BackColor="White" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label><asp:label id="lblContents" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 46px" runat="server" Height="24px" ForeColor="Navy" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
