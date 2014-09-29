<%@ Page language="c#" Inherits="WebApplication2.frmPSEPAll" CodeFile="frmPSEPAll.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 277px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Seq" HeaderText="No">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Processes">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select">
						<HeaderStyle Width="15px"></HeaderStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblContents3" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 152px" runat="server" ForeColor="Navy" Height="22px" Width="1051px" Font-Size="Small"></asp:label><asp:label id="lblContents2" style="Z-INDEX: 104; LEFT: 7px; POSITION: absolute; TOP: 81px" runat="server" ForeColor="Navy" Height="22px" Width="1051px" Font-Size="Small"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 103; LEFT: 7px; POSITION: absolute; TOP: 12px" runat="server" ForeColor="Navy" Height="22px" Width="1051px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 223px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Width="134" Font-Size="Smaller" Text="OK" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 101; LEFT: 161px; POSITION: absolute; TOP: 223px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Width="134px" Font-Size="Smaller" Text="Cancel" Font-Bold="True" CommandName="Add" onclick="btnCancel_Click"></asp:button></form>
	</body>
</HTML>
