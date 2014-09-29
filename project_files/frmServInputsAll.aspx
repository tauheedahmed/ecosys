<%@ Page language="c#" Inherits="WebApplication2.frmServInputsAll" CodeFile="frmServInputsAll.aspx.cs" %>
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
			<asp:label id="lblAvail" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Width="649px" Height="24px" ForeColor="Navy" Font-Size="Small">Available External Resources</asp:label>
			<asp:button id="btnAdd" style="Z-INDEX: 106; LEFT: 318px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="31px" Width="134" Font-Bold="True" BackColor="Navy" Text="Add" BorderStyle="None"></asp:button>
			<asp:button id="btnCancel" style="Z-INDEX: 105; LEFT: 168px; POSITION: absolute; TOP: 107px" runat="server" Font-Size="Smaller" ForeColor="White" Height="31px" Width="134" BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 12px; POSITION: absolute; TOP: 107px" runat="server" Width="134" Height="31px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Red" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="31px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 13px; POSITION: absolute; TOP: 148px" runat="server" Width="914px" Height="30px" ForeColor="Maroon" AutoGenerateColumns="False" BorderStyle="None" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="#000099"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Supplier" HeaderText="Supplier">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Availability" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="QuantityMeasure" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Width="100px" BorderStyle="None" Text="Update" BackColor="Navy" Font-Bold="True" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Width="100px" BorderStyle="None" Text="Delete" BackColor="Red" Font-Bold="True" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
