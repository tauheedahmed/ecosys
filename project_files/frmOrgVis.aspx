<%@ Page language="c#" Inherits="WebApplication2.frmOrgVis" CodeFile="frmOrgVis.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 277px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="EntityName" HeaderText="Entities">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Vis" ReadOnly="True">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Visibility Level">
						<HeaderStyle Width="15px"></HeaderStyle>
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" ForeColor="Navy" BackColor="White" BorderStyle="Solid" BorderColor="Navy" Height="24px" Width="31px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button4" runat="server" ForeColor="White" BackColor="Maroon" BorderStyle="None" Height="25px" Text="Remove" Font-Bold="True" Font-Size="Smaller" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="lblContents3" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 152px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="1051px"></asp:label><asp:label id="lblContents2" style="Z-INDEX: 104; LEFT: 7px; POSITION: absolute; TOP: 81px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="1051px"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 103; LEFT: 7px; POSITION: absolute; TOP: 12px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="1051px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 223px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Back" onclick="btnExit_Click"></asp:button></form>
	</body>
</HTML>
