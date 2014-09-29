<%@ Page language="c#" Inherits="WebApplication2.frmResTypesAll" CodeFile="frmResTypesAll.aspx.cs" %>
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
			<asp:button id="btnAddAll" style="Z-INDEX: 103; LEFT: 312px; POSITION: absolute; TOP: 133px" runat="server" Width="226px" Height="37px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Add a Service Type" BackColor="Navy" Font-Bold="True" onclick="btnAddAll_Click"></asp:button>
			<asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 74px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:label id="lblContent1" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 102; LEFT: 167px; POSITION: absolute; TOP: 133px" runat="server" Font-Size="Smaller" ForeColor="White" Height="37px" Width="134" Font-Bold="True" BackColor="Navy" Text="Cancel" BorderStyle="None" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 11px; POSITION: absolute; TOP: 133px" runat="server" Font-Size="Smaller" ForeColor="White" Height="37px" Width="134" Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 10px; POSITION: absolute; TOP: 177px" runat="server" ForeColor="Maroon" Height="30px" Width="800px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="ResTypeId" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ResTypeName" HeaderText="Service Types">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select">
						<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
