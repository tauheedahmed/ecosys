<%@ Page language="c#" Inherits="WebApplication2.frmProcClient" CodeFile="frmProcClient.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 173px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle ForeColor="Navy" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal">
</HeaderStyle>

<FooterStyle ForeColor="#330099" BackColor="#FFFFCC">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
<HeaderStyle Width="10000px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RoleName" HeaderText="Client Types">
<HeaderStyle Width="300px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Description" ReadOnly="True" HeaderText="Service Description"></asp:BoundColumn>
<asp:TemplateColumn>
<ItemTemplate>
<asp:button id=btnClient runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Width="140px" Font-Size="Smaller" Text="Individuals" Font-Bold="True" CommandName="People"></asp:button>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC">
</PagerStyle>
			</asp:datagrid><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 127px" runat="server" Height="37px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Bold="True" Text="OK" Font-Size="Smaller" Width="134" onclick="btnExit_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 7px; POSITION: absolute; TOP: 18px" runat="server" Height="24px" ForeColor="Navy" Font-Size="Small" Width="861px"></asp:label></form>
	</body>
</HTML>
