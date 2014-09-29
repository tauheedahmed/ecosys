<%@ Page language="c#" Inherits="WebApplication2.frmProjectTypes" CodeFile="frmProjectTypes.aspx.cs" %>
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
			<asp:button id="btnAddAll" style="Z-INDEX: 103; LEFT: 312px; POSITION: absolute; TOP: 150px" runat="server" Width="226px" Height="37px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Add a Project Type" BackColor="Navy" Font-Bold="True" onclick="btnAddAll_Click"></asp:button>
			<asp:label id="lblContent3" style="Z-INDEX: 107; LEFT: 9px; POSITION: absolute; TOP: 102px" runat="server" Font-Size="Small" ForeColor="Navy" Height="22px" Width="914px" Visible="False"></asp:label><asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 65px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:label id="lblContent1" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="22px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 102; LEFT: 167px; POSITION: absolute; TOP: 150px" runat="server" Width="134" Height="37px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 11px; POSITION: absolute; TOP: 150px" runat="server" Width="134" Height="37px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="OK" BackColor="Navy" Font-Bold="True" onclick="btnOK_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 10px; POSITION: absolute; TOP: 194px" runat="server" Height="30px" ForeColor="Maroon" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Project Types">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="NameShort" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Vis" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select">
						<HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Font-Bold="True" BackColor="Teal" Text="Update" BorderStyle="None" Font-Size="Smaller" ForeColor="White" Height="25px" CommandName="Update"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btndelete" runat="server" Font-Bold="True" BackColor="Maroon" Text="Delete" BorderStyle="None" Font-Size="Smaller" ForeColor="White" Height="25px" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Ser" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
