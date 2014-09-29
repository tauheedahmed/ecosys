<%@ Page language="c#" Inherits="WebApplication2.frmLocTypesAll" CodeFile="frmLocTypesAll.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="649px"></asp:label>
			<asp:button id="btnAddLocTypes" style="Z-INDEX: 107; LEFT: 336px; POSITION: absolute; TOP: 110px" runat="server" Width="120px" Height="40px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" onclick="btnAddLocTypes_Click"></asp:button>
			<asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 9px; POSITION: absolute; TOP: 76px" runat="server" Width="649px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 194px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="Cancel" BorderStyle="None" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 103; LEFT: 38px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="31px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 37px; POSITION: absolute; TOP: 155px" runat="server" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Location Types">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<HeaderStyle Width="150px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnSelect" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Teal" Text="Select" BorderStyle="None" CausesValidation="false" CommandName="Select"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Teal" Text="Update" BorderStyle="None" CausesValidation="false" CommandName="Update"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Maroon" Text="Delete" BorderStyle="None" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn></asp:BoundColumn>
					<asp:BoundColumn HeaderImageUrl="desc" DataField="vis"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
