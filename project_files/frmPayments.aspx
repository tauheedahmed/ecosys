<%@ Page language="c#" Inherits="WebApplication2.frmPayments" CodeFile="frmPayments.aspx.cs" %>
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
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 248px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 111; LEFT: 8px; POSITION: absolute; TOP: 16px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblLoc" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 40px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 64px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblBd" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 88px" runat="server" Height="30px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblDel" style="Z-INDEX: 110; LEFT: 8px; POSITION: absolute; TOP: 112px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblTask" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 136px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:label id="lblRole" style="Z-INDEX: 108; LEFT: 8px; POSITION: absolute; TOP: 160px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 105; LEFT: 13px; POSITION: absolute; TOP: 384px" runat="server" ForeColor="#A7D7CC" Height="30px" BorderStyle="None" BackColor="White" AutoGenerateColumns="False" GridLines="None" AllowSorting="True" CellPadding="4" BorderWidth="1px" BorderColor="#CC9966">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ReqDate" HeaderText="Date Paid"></asp:BoundColumn>
					<asp:BoundColumn DataField="PaymentAmt" HeaderText="Amount Paid"></asp:BoundColumn>
					<asp:BoundColumn DataField="CurName" HeaderText="Currency"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Height="25px" ForeColor="White" BackColor="Teal" BorderStyle="None" Font-Bold="True" Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnAdd" style="Z-INDEX: 104; LEFT: 152px; POSITION: absolute; TOP: 328px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" onclick="btnAdd_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 102; LEFT: 12px; POSITION: absolute; TOP: 328px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" BorderStyle="None" Text="Exit" BackColor="Navy" Font-Bold="True" onclick="btnOK_Click"></asp:button></form>
	</body>
</HTML>
