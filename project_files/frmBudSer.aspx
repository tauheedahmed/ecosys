<%@ Page language="c#" Inherits="WebApplication2.frmBudSer" CodeFile="frmBudSer.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 208px" runat="server" AutoGenerateColumns="False" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="STName" HeaderText="Services Required"></asp:BoundColumn>
					<asp:BoundColumn DataField="Qty" HeaderText="Qty"></asp:BoundColumn>
					<asp:BoundColumn DataField="QtyMeasure" HeaderText="Unit of Measure"></asp:BoundColumn>
					<asp:BoundColumn DataField="Price" HeaderText="Price"></asp:BoundColumn>
					<asp:BoundColumn DataField="ReqAmount" HeaderText="Budget Needed"></asp:BoundColumn>
					<asp:BoundColumn DataField="BudAmt" HeaderText="Budget Provided">
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" Height="28px" BorderStyle="None" BackColor="Teal" ForeColor="White" Font-Size="Smaller" Text="WorkSheet" Font-Bold="True" CommandName="WorkSheet"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 96px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblBudName" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblLocation" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 64px" runat="server" Height="32px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 160px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Back" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
