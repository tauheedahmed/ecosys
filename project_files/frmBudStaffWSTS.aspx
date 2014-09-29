<%@ Page language="c#" Inherits="WebApplication2.frmBudStaffWSTS" CodeFile="frmBudStaffWSTS.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 32px; POSITION: absolute; TOP: 245px" runat="server" AutoGenerateColumns="False" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ProcName" HeaderText="Purpose"></asp:BoundColumn>
					<asp:BoundColumn DataField="StaffName" HeaderText="Person">
						<HeaderStyle HorizontalAlign="Left" Width="400px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Qty" HeaderText="Time Input"></asp:BoundColumn>
					<asp:BoundColumn DataField="QtyMeasure"></asp:BoundColumn>
					<asp:BoundColumn DataField="ReqAmount" HeaderText="Budget Required"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Budget Provided">
						<ItemTemplate>
							<asp:TextBox id="txtBud" runat="server" Width="61px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="BudAmount" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
<asp:label id=lblBudName style="Z-INDEX: 110; LEFT: 32px; POSITION: absolute; TOP: 96px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:label id="lblComment" style="Z-INDEX: 109; LEFT: 33px; POSITION: absolute; TOP: 131px" runat="server" Height="24px" ForeColor="Navy" Width="861px" Font-Size="Small"></asp:label>
			<asp:label id="lblLocation" style="Z-INDEX: 108; LEFT: 30px; POSITION: absolute; TOP: 32px" runat="server" Height="32px" ForeColor="Navy" Width="962px" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblContents" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 66px" runat="server" Height="24px" ForeColor="Navy" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 196px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="OK" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 32px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Height="32px" Font-Size="Small" Width="962px" Font-Bold="True"></asp:label><asp:button id="btnRecalc" style="Z-INDEX: 102; LEFT: 196px; POSITION: absolute; TOP: 196px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134px" Font-Bold="True" Text="Recalculate" CommandName="Add" Visible="False"></asp:button></form>
	</body>
</HTML>
