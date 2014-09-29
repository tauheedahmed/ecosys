<%@ Page language="c#" Inherits="WebApplication2.frmProjectsInd" CodeFile="frmProjectsInd.aspx.cs" %>
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
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 24px; POSITION: absolute; TOP: 96px" runat="server" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblLocation" style="Z-INDEX: 112; LEFT: 24px; POSITION: absolute; TOP: 64px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Height="24px"></asp:label>
			<asp:label id="lblService" style="Z-INDEX: 106; LEFT: 24px; POSITION: absolute; TOP: 16px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Height="24px"></asp:label>
			<asp:label id="lblMgr" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 40px" runat="server" ForeColor="Navy" Font-Size="Small" Font-Bold="True" Height="24px"></asp:label>
			<asp:label id="lblAddNew" style="Z-INDEX: 111; LEFT: 760px; POSITION: absolute; TOP: 568px" runat="server" ForeColor="Navy" Font-Size="Small" Visible="False" Width="56px"></asp:label>
			<asp:button id="btnAddNew" style="Z-INDEX: 105; LEFT: 112px; POSITION: absolute; TOP: 208px" runat="server" ForeColor="White" Font-Size="Smaller" Text="Add" BackColor="Navy" BorderStyle="None" Font-Bold="True" Height="32px" Width="96px" onclick="btnAddNew_Click"></asp:button>
			<asp:label id="lblAddOwn" style="Z-INDEX: 110; LEFT: 560px; POSITION: absolute; TOP: 552px" runat="server" ForeColor="Navy" Font-Size="Small" Width="56px"></asp:label>
			<asp:label id="lblAddOth" style="Z-INDEX: 109; LEFT: 728px; POSITION: absolute; TOP: 472px" runat="server" ForeColor="Navy" Font-Size="Small" Visible="False" Width="48px"></asp:label>
			<asp:button id="btnAddOth" style="Z-INDEX: 108; LEFT: 632px; POSITION: absolute; TOP: 496px" runat="server" ForeColor="Navy" Font-Size="Smaller" Font-Bold="True" BorderStyle="Solid" BackColor="White" BorderColor="Navy" Text="Click Here" Visible="False" Width="72px" onclick="btnAddOth_Click"></asp:button>
			<asp:button id="btnDeAct" style="Z-INDEX: 104; LEFT: 216px; POSITION: absolute; TOP: 208px" runat="server" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BorderStyle="None" BackColor="Navy" BorderColor="Navy" Text="De-Activated" Height="32px" onclick="btnAdd_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 102; LEFT: 24px; POSITION: absolute; TOP: 208px" runat="server" Font-Size="Smaller" ForeColor="White" Height="32px" Width="80px" Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 24px; POSITION: absolute; TOP: 248px" runat="server" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
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
							<asp:button id="btnDeActivate" runat="server" ForeColor="White" Font-Size="Smaller" Height="25px" Font-Bold="True" BorderStyle="None" BackColor="Maroon" Text="De-Activate" CommandName="DeActivate"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Update">
						<ItemTemplate>
							<asp:button id="btnProj" runat="server" ForeColor="White" Font-Size="Smaller" Height="25px" Font-Bold="True" BorderStyle="None" BackColor="Teal" Text="Status" CommandName="Status"></asp:button>
							<asp:button id="btnTasks" runat="server" ForeColor="White" Font-Size="Smaller" Height="25px" Font-Bold="True" BorderStyle="None" BackColor="Teal" Text="Tasks" CommandName="Tasks"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ProjectsPeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
