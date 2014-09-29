<%@ Page language="c#" Inherits="WebApplication2.frmPeopleRoles" CodeFile="frmPeopleRoles.aspx.cs" %>
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
			<asp:label id="lblOrg" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="11px" Width="814px" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnAddR" style="Z-INDEX: 107; LEFT: 152px; POSITION: absolute; TOP: 112px" runat="server" Font-Size="Smaller" Width="168px" Height="36" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Add/Remove Roles" Font-Bold="True" CommandName="Add" onclick="btnAddRole_Click"></asp:button><asp:datagrid id="dgdRoles" style="Z-INDEX: 106; LEFT: 10px; POSITION: absolute; TOP: 152px" runat="server" AutoGenerateColumns="False" Height="50px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66">
</SelectedItemStyle>

<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal">
</HeaderStyle>

<FooterStyle ForeColor="#330099" BackColor="#FFFFCC">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
<HeaderStyle Width="10000px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="RoleOrgName" ReadOnly="True" HeaderText="Organization">
<HeaderStyle Width="300px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Roles">
<HeaderStyle Width="300px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="RoleId" ReadOnly="True"></asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="100px">
</HeaderStyle>

<ItemTemplate>
							<asp:button id="btnRskills" runat="server" Font-Bold="True" Font-Size="Smaller" Width="122px" Height="25px" ForeColor="White" CommandName="Skills" Text="Relevant Skills" BackColor="Teal" BorderStyle="None"></asp:button>
						
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC">
</PagerStyle>
			</asp:datagrid><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 10px; POSITION: absolute; TOP: 77px" runat="server" Font-Size="Small" Width="861px" Height="24px" ForeColor="Navy"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 11px; POSITION: absolute; TOP: 110px" runat="server" Font-Size="Smaller" Width="134" Height="36px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Exit" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Font-Size="Small" Width="861px" Height="24px" ForeColor="Navy"></asp:label></form>
	</body>
</HTML>
