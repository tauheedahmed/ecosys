<%@ Page language="c#" Inherits="WebApplication2.frmProfilesCon" CodeFile="frmProfilesCon.aspx.cs" %>
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
			<asp:label id="lblFunction" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 43px" runat="server" Width="748px" Height="30px" ForeColor="Navy" Font-Size="Small"></asp:label>
            <asp:button id="btnCancel" 
                style="Z-INDEX: 105; LEFT: 18px; POSITION: absolute; TOP: 89px" runat="server" 
                Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" 
                BorderStyle="None" Text="Cancel" BackColor="Navy" Font-Bold="True" 
                onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" 
                style="Z-INDEX: 104; LEFT: -224px; POSITION: absolute; TOP: 119px" 
                runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" 
                BorderStyle="None" Text="OK" BackColor="Navy" Font-Bold="True" 
                onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="31px" ForeColor="White" Font-Size="Small" BackColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 12px; POSITION: absolute; TOP: 137px" runat="server" Width="550px" Height="30px" ForeColor="Maroon" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Profiles">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
