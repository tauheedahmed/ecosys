<%@ Page language="c#" Inherits="WebApplication2.frmOLPProjectsAdd" CodeFile="frmOLPProjectsAdd.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 31px" runat="server" Font-Size="Small" ForeColor="Navy" Height="20px" Width="962px"></asp:label><asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 9px; POSITION: absolute; TOP: 53px" runat="server" Font-Size="Small" ForeColor="Navy" Height="19px" Width="974px"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 105; LEFT: 194px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="Add" BorderStyle="None" onclick="btnAdd_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 9px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="17px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 37px; POSITION: absolute; TOP: 155px" runat="server" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Update" BorderStyle="None" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Maroon" Text="Delete" BorderStyle="None" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Vis" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Inputs">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnStaff" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Staff" BorderStyle="None" CommandName="Staff"></asp:button>
							<asp:button id="btnServices" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Services" BorderStyle="None" CommandName="Services"></asp:button>
							<asp:button id="btnOther" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Other" BorderStyle="None" CommandName="Other"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
