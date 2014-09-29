<%@ Page language="c#" Inherits="WebApplication2.frmBudSerWorkSheet" CodeFile="frmBudSerWorkSheet.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 288px" runat="server" AutoGenerateColumns="False" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ResTypeName" HeaderText="Purpose"></asp:BoundColumn>
					<asp:BoundColumn DataField="ContractTitle" HeaderText="Contract (if identified)">
						<HeaderStyle HorizontalAlign="Left" Width="400px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ReqAmount" HeaderText="Budget Requested"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="BudAmount" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Budget Override">
						<ItemTemplate>
							<asp:TextBox id="txtBud" runat="server" Width="61px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents" style="Z-INDEX: 111; LEFT: 8px; POSITION: absolute; TOP: 168px" runat="server" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:label id="lblDel" style="Z-INDEX: 110; LEFT: 8px; POSITION: absolute; TOP: 96px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblBd" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 0px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 72px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblTask" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 119px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblRole" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 142px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblLoc" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 48px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 24px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 240px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="OK" onclick="btnExit_Click"></asp:button><asp:button id="Cancel" style="Z-INDEX: 103; LEFT: 176px; POSITION: absolute; TOP: 240px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134px" Font-Bold="True" Text="Cancel" Visible="False" onclick="Cancel_Click"></asp:button></form>
	</body>
</HTML>
