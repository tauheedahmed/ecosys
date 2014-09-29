<%@ Page language="c#" Inherits="WebApplication2.frmStaffingNeeds" CodeFile="frmStaffingNeeds.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmStaffing</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmStaffing" method="post" runat="server">
			<asp:label id="lblHeading" style="Z-INDEX: 100; LEFT: 30px; POSITION: absolute; TOP: 43px" runat="server" Width="650px" Height="16px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:datagrid id="DataGrid2" style="Z-INDEX: 106; LEFT: 473px; POSITION: absolute; TOP: 125px" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle ForeColor="Navy" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="ResTypeId" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services and Goods Needed">
						<HeaderStyle HorizontalAlign="Left" Width="380px" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:datagrid id="DataGrid1" style="Z-INDEX: 105; LEFT: 39px; POSITION: absolute; TOP: 126px" runat="server" Height="50px" AutoGenerateColumns="False">
				<EditItemStyle ForeColor="#000099"></EditItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" HeaderText="Staff Needed">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 103; LEFT: 36px; POSITION: absolute; TOP: 81px" runat="server" Width="134" Height="35px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BorderStyle="None" BackColor="Red" Text="Exit" onclick="btnExit_Click"></asp:button>
			<asp:Label id="lblOrg1" style="Z-INDEX: 102; LEFT: 29px; POSITION: absolute; TOP: 8px" runat="server" Font-Bold="True" Width="703px" Height="31px" ForeColor="Navy" Font-Size="Small"></asp:Label></form>
	</body>
</HTML>
