<%@ Page language="c#" Inherits="WebApplication2.frmResources" CodeFile="frmResources.aspx.cs" %>
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
			<asp:label id="lblContents" style="Z-INDEX: 101; LEFT: 7px; POSITION: absolute; TOP: 38px" runat="server" Width="909px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label>
			<asp:button id="btnOwn" style="Z-INDEX: 107; LEFT: 624px; POSITION: absolute; TOP: 108px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="120px" BorderStyle="None" Text="Owned" BackColor="Navy" Font-Bold="True" onclick="btnOwn_Click"></asp:button><asp:button id="btnPublic" style="Z-INDEX: 106; LEFT: 358px; POSITION: absolute; TOP: 106px" runat="server" Width="120px" Height="40px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" Text="Public" BorderStyle="None" onclick="btnPublic_Click"></asp:button><asp:button id="btnInstitution" style="Z-INDEX: 105; LEFT: 494px; POSITION: absolute; TOP: 107px" runat="server" Width="120px" Height="40px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" Text="Institutional" BorderStyle="None" onclick="btnInstitution_Click"></asp:button><asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 9px; POSITION: absolute; TOP: 107px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Red" Text="Exit" BorderStyle="None" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 10px; POSITION: absolute; TOP: 6px" runat="server" Width="914px" Height="24px" ForeColor="Navy" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 151px" runat="server" Width="1100px" Height="30px" ForeColor="Maroon" BorderStyle="Solid" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" Height="30px" ForeColor="#000099" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" BackColor="#000099"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TypeName" HeaderText="Type"></asp:BoundColumn>
					<asp:BoundColumn DataField="Supplier" ReadOnly="True" HeaderText="Supplier">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnRemove" runat="server" ForeColor="White" Font-Bold="True" BackColor="#000099" Text="Remove" BorderStyle="None" CommandName="Remove"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			<asp:TextBox id="txtHeading" style="Z-INDEX: 109; LEFT: 359px; POSITION: absolute; TOP: 71px" runat="server" ForeColor="White" Height="28px" Width="384px" BorderStyle="None" BackColor="Navy" Font-Bold="True">Available Resources</asp:TextBox></form>
	</body>
</HTML>
