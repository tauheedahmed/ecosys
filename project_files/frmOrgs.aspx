<%@ Page language="c#" Inherits="WebApplication2.frmOrgs" CodeFile="frmOrgs.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmOrgs</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body rightMargin="0">
		<form method="post" runat="server">
			<asp:label id="lblContents" style="Z-INDEX: 100; LEFT: 28px; POSITION: absolute; TOP: 83px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="904px"></asp:label>
			<asp:button id="btnAddTemp" style="Z-INDEX: 107; LEFT: 170px; POSITION: absolute; TOP: 146px" runat="server" Width="285px" Height="36px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Add Services Using Template" BorderStyle="None" ToolTip="Recommended" onclick="btnAddTemp_Click"></asp:button><asp:button id="btnallMsg" style="Z-INDEX: 106; LEFT: 620px; POSITION: absolute; TOP: 146px" runat="server" Font-Size="Smaller" ForeColor="White" Height="36px" Width="134px" BorderStyle="None" Text="Message All" BackColor="Navy" Font-Bold="True" onclick="btnallMsg_Click"></asp:button><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 28px; POSITION: absolute; TOP: 146px" runat="server" Font-Size="Smaller" ForeColor="White" Height="36px" Width="134" BorderStyle="None" Text="Exit" BackColor="Red" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 27px; POSITION: absolute; TOP: 42px" runat="server" Font-Size="Small" ForeColor="Navy" Height="36px" Width="904px" Font-Bold="True"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 102; LEFT: 467px; POSITION: absolute; TOP: 146px" runat="server" Font-Size="Smaller" ForeColor="White" Height="36px" Width="134px" BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" onclick="btnAdd_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 27px; POSITION: absolute; TOP: 186px" runat="server" Height="30px" BorderStyle="None" AutoGenerateColumns="False">
				<SelectedItemStyle BorderStyle="None"></SelectedItemStyle>
				<EditItemStyle BorderWidth="2px" BorderStyle="Solid" BorderColor="#0000C0" BackColor="#00C0C0"></EditItemStyle>
				<AlternatingItemStyle Font-Size="Small" ForeColor="#000099" BorderStyle="None" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="#000099" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BorderColor="Navy" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="email" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Phone" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Address" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Update" BorderStyle="None" CausesValidation="false" CommandName="Update"></asp:Button>
							<asp:Button id="btnServices" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Services" BorderStyle="None" CausesValidation="false" CommandName="Services"></asp:Button>
							<asp:Button id="btnStaff" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="People" BorderStyle="None" CausesValidation="false" CommandName="Staffing"></asp:Button>
							<asp:Button id="Button6" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="Message" BorderStyle="None" CausesValidation="false" CommandName="Msg"></asp:Button>
							<asp:Button id="btnUserIds" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Navy" Text="User Ids" BorderStyle="None" CausesValidation="false" CommandName="UserIds"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Width="80px" Height="25px" ForeColor="White" Font-Bold="True" BackColor="Red" Text="Delete" BorderStyle="None" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ParentOrg" ReadOnly="True" HeaderText="Parent Id"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LicenseId" ReadOnly="True" HeaderText="LicenseId"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="Button3" runat="server" Width="129px" Height="25px" ForeColor="White" BorderStyle="None" Text="Issue License" BackColor="Navy" Font-Bold="True" CommandName="License" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
