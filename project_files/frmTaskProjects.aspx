<%@ Page language="c#" Inherits="WebApplication2.frmTaskProjects" CodeFile="frmTaskProjects.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmResourcesInfo" method="post" runat="server">
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 38px; POSITION: absolute; TOP: 36px" runat="server" Width="962px" Height="20px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnCancel" style="Z-INDEX: 107; LEFT: 180px; POSITION: absolute; TOP: 120px" runat="server" Width="135" Height="35px" ForeColor="White" Font-Size="Smaller" Text="Cancel" Font-Bold="True" BackColor="Navy" BorderStyle="None" onclick="btnCancel_Click"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 106; LEFT: 323px; POSITION: absolute; TOP: 120px" runat="server" Width="100px" Height="35" ForeColor="White" Text="Add" Font-Bold="True" BackColor="Navy" BorderStyle="None" ToolTip="Recommended" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 38px; POSITION: absolute; TOP: 60px" runat="server" Width="974px" Height="19px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 119px" runat="server" Width="135" Height="35px" ForeColor="White" Font-Size="Smaller" Text="Exit" Font-Bold="True" BackColor="Navy" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 38px; POSITION: absolute; TOP: 11px" runat="server" Height="17px" ForeColor="Navy" Font-Size="Small" Font-Bold="True" BackColor="White"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 39px; POSITION: absolute; TOP: 158px" runat="server" Height="30px" ForeColor="Maroon" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" BorderStyle="None" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="20px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Projects">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Font-Size="X-Small" ForeColor="White" BorderStyle="None" BackColor="Teal" Font-Bold="True" Text="Update" CommandName="Update"></asp:Button>
							<asp:Button id="Button5" runat="server" ForeColor="White" Height="25px" Width="80px" BorderStyle="None" BackColor="Teal" Font-Bold="True" Text="Staff" CommandName="Staff" Visible="False" BorderWidth="0px" BorderColor="Navy"></asp:Button>
							<asp:Button id="Button6" runat="server" ForeColor="White" Height="25px" Width="95px" BorderStyle="None" BackColor="Teal" Font-Bold="True" Text="Services" CommandName="Services" Visible="False" BorderWidth="0px" BorderColor="Navy"></asp:Button>
							<asp:Button id="Button7" runat="server" ForeColor="White" Height="25px" Width="95px" BorderStyle="None" BackColor="Teal" Font-Bold="True" Text="Goods" CommandName="Goods" Visible="False" BorderWidth="0px" BorderColor="Navy"></asp:Button>
							<asp:Button id="Button3" runat="server" Font-Size="X-Small" ForeColor="White" BorderStyle="None" BackColor="Maroon" Font-Bold="True" Text="Remove" CommandName="Remove"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
