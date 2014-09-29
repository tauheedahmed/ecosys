<%@ Page language="c#" Inherits="WebApplication2.frmProjectsIndT" CodeFile="frmProjectsIndT.aspx.cs" %>
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
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 40px; POSITION: absolute; TOP: 96px" runat="server" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblLocation" style="Z-INDEX: 112; LEFT: 40px; POSITION: absolute; TOP: 64px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Height="24px"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 106; LEFT: 40px; POSITION: absolute; TOP: 16px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Height="24px"></asp:label>
			<asp:label id="lblMgr" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 40px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Height="24px"></asp:label><asp:button id="btnOK" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 208px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 256px" runat="server" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Report">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="Button5" runat="server" Height="25px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BorderStyle="None" BackColor="Teal" Text="Timetable" CommandName="Timetable"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnTasks" runat="server" ForeColor="White" Font-Size="Smaller" Height="25px" Font-Bold="True" BorderStyle="None" BackColor="Teal" Text="Tasks" CommandName="Tasks"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
