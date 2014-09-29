<%@ Page language="c#" Inherits="WebApplication2.frmLocsAll" CodeFile="frmLocsAll.aspx.cs" %>
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
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 43px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="920px"></asp:label>
			<asp:button id="btnAdd" 
                style="Z-INDEX: 107; LEFT: 292px; POSITION: absolute; TOP: 88px" runat="server" 
                Width="134" Height="34px" ForeColor="White" Font-Size="Smaller" 
                BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" 
                onclick="btnAdd_Click"></asp:button><asp:button id="btnCancel" 
                style="Z-INDEX: 105; LEFT: 152px; POSITION: absolute; TOP: 90px" runat="server" 
                Font-Size="Smaller" ForeColor="White" Height="34px" Width="134" 
                Font-Bold="True" BackColor="Navy" Text="Cancel" BorderStyle="None" 
                onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" 
                style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 92px" runat="server" 
                Font-Size="Smaller" ForeColor="White" Height="34px" Width="134" 
                Font-Bold="True" BackColor="Navy" Text="OK" BorderStyle="None" 
                onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="31px" Font-Bold="True"></asp:label>
            <asp:datagrid id="DataGrid1" 
                style="Z-INDEX: 101; LEFT: 9px; POSITION: absolute; TOP: 135px" runat="server" 
                ForeColor="Navy" Height="30px" BorderStyle="None" HorizontalAlign="Left" 
                AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Locations">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Width="102px" Height="26px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Teal" Text="Update" BorderStyle="None" CommandName="Update"></asp:button>
							<asp:Button ID="btnRemove" runat="server" BackColor="Teal" BorderStyle="None" 
                                CommandName="Remove" Font-Bold="True" Font-Size="Smaller" ForeColor="White" 
                                Height="26px" Text="Remove" Width="102px" />
							<asp:button id="btnDelete" runat="server" Width="102px" Height="26px" ForeColor="White" Font-Size="Smaller" Font-Bold="True" BackColor="Maroon" Text="Delete" BorderStyle="None" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
