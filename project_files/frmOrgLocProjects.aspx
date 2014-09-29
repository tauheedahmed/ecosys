<%@ Page language="c#" Inherits="WebApplication2.frmOrgLocProjects" CodeFile="frmOrgLocProjects.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 184px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="EventName" HeaderText="Deliverable">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Font-Bold="True" Text="Select" CausesValidation="false" CommandName="Select"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ProfileId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PSEId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PJName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PJNameS" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblOrg" style="Z-INDEX: 125; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" BackColor="White" Height="17px" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblLoc" style="Z-INDEX: 107; LEFT: 8px; POSITION: absolute; TOP: 32px" runat="server" ForeColor="Navy" Height="24px" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblBd" style="Z-INDEX: 124; LEFT: 8px; POSITION: absolute; TOP: 56px" runat="server" ForeColor="Navy" Height="30px" Font-Bold="True" Font-Size="Small"></asp:label>
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 88px" runat="server" ForeColor="Navy" Height="20px" Font-Size="Small"></asp:label>
			<asp:button id="btnBack" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 144px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="33px" Font-Bold="True" Font-Size="Smaller" Text="OK" Width="108px"></asp:button></form>
	</body>
</HTML>
