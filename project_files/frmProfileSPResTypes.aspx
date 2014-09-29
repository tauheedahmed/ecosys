<%@ Page language="c#" Inherits="WebApplication2.frmProfileSPResTypes" CodeFile="frmProfileSPResTypes.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 258px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ResTypeId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ResTypeName" HeaderText="Resource Types Needed">
						<HeaderStyle Width="600px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Description (Type inside box to update)">
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" BorderWidth="1px" BorderStyle="Solid" BorderColor="Navy" Height="27px" Width="500px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" ForeColor="White" BackColor="Maroon" BorderStyle="None" Height="25px" Font-Size="Smaller" CommandName="Remove" Text="Remove" Font-Bold="True"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents4" style="Z-INDEX: 108; LEFT: 12px; POSITION: absolute; TOP: 137px" runat="server" ForeColor="Red" Height="24px" Font-Size="X-Small" Width="1010px"></asp:label>
			<asp:label id="lblContents3" style="Z-INDEX: 107; LEFT: 10px; POSITION: absolute; TOP: 106px" runat="server" ForeColor="Navy" Height="24px" Font-Size="Small" Width="861px"></asp:label>
			<asp:button id="btnAllTypes" style="Z-INDEX: 106; LEFT: 295px; POSITION: absolute; TOP: 204px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Width="238px" Font-Size="Smaller" Font-Bold="True" Text="Show All Resource Types" CommandName="AllTypes" onclick="btnAllTypes_Click"></asp:button>
			<asp:label id="lblContents2" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 74px" runat="server" ForeColor="Navy" Height="24px" Font-Size="Small" Width="861px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 204px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="OK" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="32px" ForeColor="White" Font-Size="Small" Font-Bold="True" BackColor="Navy"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 102; LEFT: 149px; POSITION: absolute; TOP: 204px" runat="server" Width="134px" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add" Font-Size="Smaller" Font-Bold="True" CommandName="Add" onclick="btnAdd_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Width="861px" Height="24px" ForeColor="Navy" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
