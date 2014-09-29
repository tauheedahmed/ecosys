<%@ Page language="c#" Inherits="WebApplication2.frmOLPProjects" CodeFile="frmOLPProjects.aspx.cs" %>
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
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 9px; POSITION: absolute; TOP: 34px" runat="server" Width="962px" Height="20px" ForeColor="Navy" Font-Size="Small"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 105; LEFT: 173px; POSITION: absolute; TOP: 128px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Add" BackColor="Navy" Font-Bold="True" onclick="btnAdd_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 17px; POSITION: absolute; TOP: 128px" runat="server" Width="134" Height="40px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" Text="Back" BackColor="Navy" Font-Bold="True" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 9px; POSITION: absolute; TOP: 8px" runat="server" Width="914px" Height="17px" ForeColor="Navy" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 102; LEFT: 16px; POSITION: absolute; TOP: 175px" runat="server" Height="30px" ForeColor="Maroon" BorderStyle="None" AutoGenerateColumns="False" HorizontalAlign="Left">
<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
<HeaderStyle Width="0px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Name">
<HeaderStyle Width="300px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
<asp:button id=Button3 runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Report" BorderStyle="None" CommandName="Report"></asp:button>
<asp:button id=Button2 runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Update" BorderStyle="None" CommandName="Update"></asp:button>
<asp:button id=Button4 runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Clients" BorderStyle="None" CommandName="Clients"></asp:button>
<asp:button id=Button6 runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Timetable" BorderStyle="None" CommandName="Timetable" Visible="False"></asp:button>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Inputs">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</HeaderStyle>

<ItemTemplate>
							<asp:button id="btnStaff" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Staff" BorderStyle="None" CommandName="Staff"></asp:button>
							<asp:button id="btnServices" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Services" BorderStyle="None" CommandName="Services"></asp:button>
							<asp:button id="btnOther" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Teal" Text="Other" BorderStyle="None" CommandName="Other"></asp:button>
						
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<ItemTemplate>
							<asp:button id="btnRemove" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Font-Bold="True" BackColor="Maroon" Text="Remove" BorderStyle="None" CommandName="Remove"></asp:button>
						
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Vis" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="OLPProjectsId" ReadOnly="True"></asp:BoundColumn>
</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
