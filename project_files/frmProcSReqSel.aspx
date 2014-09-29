<%@ Page language="c#" Inherits="WebApplication2.frmProcSReqSel" CodeFile="frmProcSReqSel.aspx.cs" %>
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
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Width="920px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 106; LEFT: 152px; POSITION: absolute; TOP: 120px" runat="server" Height="34px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" Text="Add" BorderStyle="None" Width="135px" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 104; LEFT: 7px; POSITION: absolute; TOP: 78px" runat="server" Width="943px" Height="35px" ForeColor="Navy" Font-Size="X-Small"></asp:label><asp:button id="btnOK" style="Z-INDEX: 103; LEFT: 12px; POSITION: absolute; TOP: 121px" runat="server" Width="135" Height="34px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="31px" ForeColor="Navy" Font-Size="Small" Font-Bold="True"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 12px; POSITION: absolute; TOP: 160px" runat="server" Width="914px" Height="30px" ForeColor="Navy" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleName" HeaderText="Team Members">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="StaffType" HeaderText="Type">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description">
						<HeaderStyle Width="200px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="StaffActionsId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="320px"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="Button4" runat="server" Width="102px" Height="26px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Teal" Text="Update" BorderStyle="None" CommandName="Update"></asp:button>
							<asp:button id="Button5" runat="server" Width="102px" Height="26px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Maroon" Text="Delete" BorderStyle="None" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OSTId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
