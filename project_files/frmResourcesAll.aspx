<%@ Page language="c#" Inherits="WebApplication2.frmOwnResourcesAll" CodeFile="frmResourcesAll.aspx.cs" %>
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
			<asp:label id="lblContent" style="Z-INDEX: 104; LEFT: 11px; POSITION: absolute; TOP: 44px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="1007px"></asp:label>
			<asp:button id="btnProcurementReq" style="Z-INDEX: 107; LEFT: 256px; POSITION: absolute; TOP: 117px" runat="server" Width="208px" Height="34px" ForeColor="White" Font-Size="X-Small" BorderStyle="None" Text="Request Procurement" BackColor="Navy" Font-Bold="True" onclick="btnProcurementReq_Click"></asp:button><asp:button id="btnResAll" style="Z-INDEX: 106; LEFT: 472px; POSITION: absolute; TOP: 117px" runat="server" Font-Size="X-Small" ForeColor="White" Height="34px" Width="261px" Font-Bold="True" BackColor="Navy" Text="Display All Available Resources" BorderStyle="None" onclick="btnResAll_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 103; LEFT: 11px; POSITION: absolute; TOP: 159px" runat="server" Font-Size="Small" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SupplierName" ReadOnly="True" HeaderText="Supplier">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<HeaderStyle Width="50px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid><asp:button id="btnCancel" style="Z-INDEX: 102; LEFT: 153px; POSITION: absolute; TOP: 117px" runat="server" Font-Size="Smaller" ForeColor="White" Height="34px" Width="97px" Font-Bold="True" BackColor="Red" Text="Cancel" BorderStyle="None" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 11px; POSITION: absolute; TOP: 117px" runat="server" Width="134" Height="34px" ForeColor="White" Font-Size="X-Small" BorderStyle="None" Text="OK" BackColor="Red" Font-Bold="True" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 100; LEFT: 11px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="31px" ForeColor="Navy" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label></form>
	</body>
</HTML>
