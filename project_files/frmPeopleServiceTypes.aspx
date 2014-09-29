<%@ Page language="c#" Inherits="WebApplication2.frmAssesOrg" CodeFile="frmPeopleServiceTypes.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmAsses</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="frmAsses" method="post" runat="server">
			<h1><asp:label id="Label1" Text="Emergency Preparedness System" runat="server" ></asp:label></h1>
			<p><asp:label id="lblContent1" runat="server" ></asp:label>	</p>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAddDel" runat="server" Text="Add" onclick="btnAddDel_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" 
                ForeColor="Maroon" Height="30px" AutoGenerateColumns="False" 
                HorizontalAlign="Left" onitemcommand="DataGrid1_ItemCommand1" >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceTypesId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="Services" DataField="Name"></asp:BoundColumn>
					
					<asp:TemplateColumn>
					    <ItemTemplate>
							<asp:Button id="btnRemove" runat="server" Height="30px" Width="80px" ForeColor="White" Font-Bold="True" BorderStyle="None" Text="Remove" BackColor=Maroon CommandName="Remove" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
