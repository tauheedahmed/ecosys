<%@ Page language="c#" Inherits="WebApplication2.frmProjStepStaff" CodeFile="frmProjStepStaff.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 46px; POSITION: absolute; TOP: 179px" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="Teal" GridLines="None">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="RolesName" HeaderText="Roles"></asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Task"></asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleName" HeaderText="Staff Assigned">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="bkupFlag" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn Visible="False" HeaderText="Check if Backup">
						<ItemTemplate>
							<asp:CheckBox id="cbxBackup" runat="server" ForeColor="Navy" AutoPostBack="True"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" BorderStyle="None" ForeColor="White" Width="112px" Font-Size="Smaller" Font-Bold="True" BackColor="Maroon" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle Visible="False"></PagerStyle>
			</asp:datagrid><asp:label id="lblContents1" style="Z-INDEX: 107; LEFT: 46px; POSITION: absolute; TOP: 47px" runat="server" ForeColor="Navy" Width="914px" Font-Size="Small" Height="24px"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 105; LEFT: 193px; POSITION: absolute; TOP: 130px" runat="server" BorderStyle="None" ForeColor="White" Width="134" Font-Size="Smaller" Height="34px" Font-Bold="True" BackColor="Navy" Visible="False" onclick="btnAdd_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 104; LEFT: 46px; POSITION: absolute; TOP: 9px" runat="server" ForeColor="Navy" Width="914px" Font-Size="Small" Height="24px" Font-Bold="True"></asp:label><asp:label id="lblContents" style="Z-INDEX: 103; LEFT: 46px; POSITION: absolute; TOP: 88px" runat="server" ForeColor="Navy" Width="909px" Font-Size="Small" Height="24px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 130px" runat="server" BorderStyle="None" ForeColor="White" Width="134" Font-Size="Smaller" Height="34px" Font-Bold="True" BackColor="Navy" Text="OK" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
