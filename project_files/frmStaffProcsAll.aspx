<%@ Page language="c#" Inherits="WebApplication2.frmStaffProcsAll" CodeFile="frmStaffProcsAll.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmResourcesInfo</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmResourcesInfo" method="post" runat="server">
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Width="920px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 73px" runat="server" Width="920px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 105; LEFT: 168px; POSITION: absolute; TOP: 122px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 12px; POSITION: absolute; TOP: 122px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="OK" BackColor="Navy" Font-Bold="True" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="31px" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Visible="False"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 12px; POSITION: absolute; TOP: 177px" runat="server" Height="30px" ForeColor="Navy" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="RolesName" HeaderText="Staff Types"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProcName" HeaderText="Processes">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProjName" ReadOnly="True" HeaderText="Outputs">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" HeaderText="Task Manager"></asp:BoundColumn>
					<asp:BoundColumn DataField="Hours" HeaderText="Hours"></asp:BoundColumn>
					<asp:BoundColumn DataField="BudName" HeaderText="Budget Charged"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
