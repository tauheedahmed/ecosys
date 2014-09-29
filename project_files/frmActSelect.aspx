<%@ Page language="c#" Inherits="WebApplication2.frmActSelect" CodeFile="frmActSelect.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmAsses</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="frmAsses" method="post" runat="server">
			<asp:label id="Label1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 40px" runat="server" ForeColor="#000099" Font-Size="Medium" Width="816px" Height="24px">Emergency Preparedness Assessments</asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 105; LEFT: 11px; POSITION: absolute; TOP: 6px" runat="server" Font-Bold="True" Height="24px" Width="816px" Font-Size="Medium" ForeColor="#000099">Organization Name here</asp:label>
			<asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 10px; POSITION: absolute; TOP: 80px" runat="server" Font-Bold="True" Height="40px" Width="134" Font-Size="Smaller" ForeColor="White" BackColor="Navy" Text="OK" BorderStyle="None" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnCancel" style="Z-INDEX: 103; LEFT: 152px; POSITION: absolute; TOP: 79px" runat="server" Height="41px" Width="134px" Font-Size="Smaller" ForeColor="White" Font-Bold="True" Text="Cancel" BackColor="Navy" BorderStyle="None" onclick="Exit"></asp:button>
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 3px; POSITION: absolute; TOP: 129px" runat="server" ForeColor="#000099" Width="914px" Height="50px" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle Height="30px"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" BackColor="#000099"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Activity">
						<HeaderStyle Width="700px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="100px"></HeaderStyle>
						<HeaderTemplate>
							Click to Select
						</HeaderTemplate>
						<ItemTemplate>
							<asp:CheckBox id="ckbSel" runat="server" Height="30px" ForeColor="Navy" BorderStyle="None" BorderColor="#000099"></asp:CheckBox>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
		</form>
	</body>
</HTML>
