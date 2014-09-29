<%@ Page language="c#" Inherits="WebApplication2.frmBudStaffWorkSheet" CodeFile="frmBudStaffWorkSheet.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 264px" runat="server" Height="30px" BorderColor="White" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Role" HeaderText="Role"></asp:BoundColumn>
					<asp:BoundColumn DataField="StaffName" HeaderText="Staff Assigned">
						<HeaderStyle HorizontalAlign="Left" Width="400px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ReqAmount" HeaderText="Budget Requested">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="BudAmount" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Request Override">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:TextBox id="txtBud" runat="server" Width="61px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents" style="Z-INDEX: 111; LEFT: 8px; POSITION: absolute; TOP: 160px" runat="server" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:label id="lblDel" style="Z-INDEX: 110; LEFT: 8px; POSITION: absolute; TOP: 96px" runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblBd" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 0px" runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 72px" runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblTask" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 120px" runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblRole" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 136px" runat="server" ForeColor="Navy" Height="24px" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblLoc" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 48px" runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 24px" runat="server" ForeColor="Navy" Font-Bold="True" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 216px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Font-Size="Smaller" Text="OK" Width="134" onclick="btnExit_Click"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 103; LEFT: 176px; POSITION: absolute; TOP: 216px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Font-Size="Smaller" Text="Cancel" Width="134px" Visible="False" CommandName="Cancel" onclick="btnCancel_Click"></asp:button></form>
	</body>
</HTML>
