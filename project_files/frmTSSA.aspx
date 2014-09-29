<%@ Page language="c#" Inherits="WebApplication2.frmTSSA" CodeFile="frmTSSA.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmOrgResTypes</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmOrgResTypes" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 46px; POSITION: absolute; TOP: 259px" runat="server" AllowSorting="True" GridLines="None" BorderStyle="None" AutoGenerateColumns="False">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ProcName" HeaderText="Procedures"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProjectName" HeaderText="Outputs">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" HeaderText="Task Manager"></asp:BoundColumn>
					<asp:BoundColumn DataField="Hours" ReadOnly="True" HeaderText="Hours"></asp:BoundColumn>
					<asp:BoundColumn DataField="BudName" HeaderText="Budget Charged"></asp:BoundColumn>
					<asp:TemplateColumn Visible="False">
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Smaller" ForeColor="White" Text="Remove" BackColor="Maroon"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			<asp:button id="btnAdd" style="Z-INDEX: 107; LEFT: 190px; POSITION: absolute; TOP: 212px" runat="server" BorderStyle="None" Font-Bold="True" Height="34px" Font-Size="Smaller" Width="134" ForeColor="White" Text="Add" BackColor="Navy" Visible="False" onclick="btnAdd_Click"></asp:button><asp:label id="lblPerson" style="Z-INDEX: 106; LEFT: 46px; POSITION: absolute; TOP: 47px" runat="server" ForeColor="Navy" Width="914px" Font-Size="Small" Height="24px" Font-Bold="True"></asp:label><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 46px; POSITION: absolute; TOP: 9px" runat="server" ForeColor="Navy" Width="914px" Font-Size="Small" Height="24px" Font-Bold="True"></asp:label><asp:label id="lblContents" style="Z-INDEX: 102; LEFT: 46px; POSITION: absolute; TOP: 88px" runat="server" ForeColor="Navy" Width="909px" Font-Size="Small" Height="24px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 210px" runat="server" BorderStyle="None" ForeColor="White" Width="134" Font-Size="Smaller" Height="34px" Font-Bold="True" BackColor="Navy" Text="OK" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
