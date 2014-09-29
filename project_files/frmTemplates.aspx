<%@ Page language="c#" Inherits="WebApplication2.Templates" CodeFile="frmTemplates.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Templates</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 22px; POSITION: absolute; TOP: 97px" runat="server" GridLines="None" ForeColor="Blue" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#000099" Height="30px" Width="797px">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BorderStyle="None" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle ForeColor="#000099" BorderStyle="None" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#330099" BorderStyle="None" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" BorderStyle="None" VerticalAlign="Middle" BackColor="#000099"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id">
						<HeaderStyle Width="0px"></HeaderStyle>
						<ItemStyle Font-Size="Smaller"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description">
						<HeaderStyle Width="500px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" BorderColor="White" Font-Bold="True" Text="Select" CausesValidation="false" CommandName="Select"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle BorderStyle="None" HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 608px; POSITION: absolute; TOP: 59px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="35px" Width="85px" Visible="False" Text="Exit" Font-Bold="True" Font-Names="white" onclick="btnExit_Click"></asp:button><asp:button id="btnNoTemplates" style="Z-INDEX: 104; LEFT: 700px; POSITION: absolute; TOP: 59px" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Height="35px" Width="119px" Text="No Templates" Font-Bold="True" Font-Names="white" onclick="btnNoTemplates_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 15px; POSITION: absolute; TOP: -1px" runat="server" ForeColor="#000099" Height="30px" Width="848px" Font-Bold="True" Font-Size="Large">OrgName</asp:label><asp:label id="lblOK" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 67px" runat="server" ForeColor="#000099" Height="17px" Width="531px" Font-Size="Small">Select an appropriate template from the ones listed below.</asp:label></form>
	</body>
</HTML>
