<%@ Page language="c#" Inherits="WebApplication2.frmTesting" CodeFile="frmTesting.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmProcedureSteps</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="frmProcedureSteps" method="post" runat="server">
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 0px; POSITION: absolute; TOP: 200px" runat="server" Width="736px" Height="144px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle ForeColor="#000099" BackColor="#CCFFFF"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000099"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" HeaderText="Id"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProcessId" HeaderText="ProcessId"></asp:BoundColumn>
					<asp:BoundColumn DataField="StartDate" HeaderText="Start Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="EndDate" HeaderText="End Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
					<asp:BoundColumn DataField="Results" HeaderText="Results"></asp:BoundColumn>
					<asp:BoundColumn DataField="Comments" HeaderText="Comments"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnEdit" runat="server" BackColor="#000099" Width="88px" Text="Edit" ForeColor="White" Font-Bold="True"></asp:Button>
							<asp:Button id="btnDelete" runat="server" BackColor="Red" Width="80px" Text="Delete" ForeColor="White" Font-Bold="True"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
							<asp:Button id="Button1" runat="server" BackColor="#000099" Width="80px" Text="Edit" ForeColor="White" Font-Bold="True"></asp:Button>
							<asp:Button id="Button2" runat="server" BackColor="#000099" Width="80px" Text="Cancel" ForeColor="White" Font-Bold="True"></asp:Button>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="lblOrg" style="Z-INDEX: 114; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="48px" Width="568px" Font-Size="X-Large" ForeColor="#000099" Font-Bold="True">Organization Name Here</asp:Label>
			<INPUT id="htmBtnExit" style="FONT-WEIGHT: bold; Z-INDEX: 113; LEFT: -8px; WIDTH: 134px; COLOR: white; POSITION: absolute; TOP: 160px; HEIGHT: 32px; BACKGROUND-COLOR: red" onclick="history.back()" type="button" value="Exit" name="htmBtnExit">
			<asp:Label id="lblPN" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 112px" runat="server" Height="27px" Width="960px" ForeColor="Red" Font-Size="Large">(ProcessName from calling form)</asp:Label>
			<asp:Button id="btnAdd" style="Z-INDEX: 105; LEFT: 152px; POSITION: absolute; TOP: 160px" runat="server" BackColor="Red" Height="32px" Width="133px" Text="Add" ForeColor="White" Font-Bold="True"></asp:Button>
			<asp:Label id="lblMN" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 56px" runat="server" Height="24px" Width="808px" ForeColor="#000099" Font-Size="X-Large"> Testing or Actual</asp:Label>
		</form>
	</body>
</HTML>
