<%@ Page language="c#" Inherits="WebApplication2.frmTSApprove" CodeFile="frmTSApprove.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 46px; POSITION: absolute; TOP: 296px" runat="server" AllowSorting="True" GridLines="None" BorderStyle="None" AutoGenerateColumns="False">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="StartDate" HeaderText="Start Date">
						<HeaderStyle Width="250px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="EndDate" HeaderText="End Date">
						<HeaderStyle Width="250px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Hours" HeaderText="Hours Charged">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Approve">
						<HeaderStyle HorizontalAlign="Center" Width="250px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:label id="lblOrg" style="Z-INDEX: 112; LEFT: 40px; POSITION: absolute; TOP: 8px" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblRole" style="Z-INDEX: 109; LEFT: 40px; POSITION: absolute; TOP: 176px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblLoc" style="Z-INDEX: 107; LEFT: 40px; POSITION: absolute; TOP: 32px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 108; LEFT: 40px; POSITION: absolute; TOP: 56px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblBd" style="Z-INDEX: 110; LEFT: 40px; POSITION: absolute; TOP: 80px" runat="server" Font-Bold="True" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblDel" style="Z-INDEX: 111; LEFT: 40px; POSITION: absolute; TOP: 104px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblTask" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 128px" runat="server" Font-Bold="True" Height="24px" Font-Size="Small" ForeColor="Navy"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 193px; POSITION: absolute; TOP: 248px" runat="server" BorderStyle="None" ForeColor="White" Width="134" Font-Size="Smaller" Height="34px" Font-Bold="True" BackColor="Navy" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:label id="lblContents" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 200px" runat="server" ForeColor="Navy" Font-Size="Small" Height="24px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 248px" runat="server" BorderStyle="None" ForeColor="White" Width="134" Font-Size="Smaller" Height="34px" Font-Bold="True" BackColor="Navy" Text="OK" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
