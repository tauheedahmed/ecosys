<%@ Page language="c#" Inherits="WebApplication2.frmServInputs" CodeFile="frmCommitments.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Priorities</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="frmDeadlines" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 33px; POSITION: absolute; TOP: 196px" runat="server" AutoGenerateColumns="False" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="50px" Width="914px" GridLines="None">
<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66">
</SelectedItemStyle>

<AlternatingItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" ForeColor="#000099" BorderStyle="None" VerticalAlign="Top" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal">
</HeaderStyle>

<FooterStyle ForeColor="#330099" BackColor="#FFFFCC">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id"></asp:BoundColumn>
<asp:BoundColumn DataField="Client" HeaderText="Clients">
<HeaderStyle Width="200px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Deadline" HeaderText="Deadlines">
<HeaderStyle Width="200px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="AcceptableDelay" HeaderText="Acceptable Delay">
<HeaderStyle Width="200px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="TypeOfImpact" ReadOnly="True" HeaderText="Type of Impact"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ImpactMagnitude" ReadOnly="True" HeaderText="Magnitude of Impact"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ImpactValue" ReadOnly="True" HeaderText="Cost of Delay ($)"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="LocationId" ReadOnly="True"></asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="200px">
</HeaderStyle>

<ItemTemplate>
<asp:Button id=btnUpdate runat="server" Width="83px" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Update" Font-Bold="True" CausesValidation="false" CommandName="Update"></asp:Button>
<asp:Button id=btnDelete runat="server" Width="83px" Height="25px" BorderStyle="None" BackColor="Teal" ForeColor="White" Text="Delete" Font-Bold="True" CausesValidation="false" CommandName="Delete"></asp:Button>
</ItemTemplate>

<EditItemTemplate>
&nbsp; 
</EditItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
</PagerStyle>
			</asp:datagrid>
			<asp:label id="Label1" style="Z-INDEX: 106; LEFT: 37px; POSITION: absolute; TOP: 77px" runat="server" Width="992px" Height="27px" ForeColor="Navy" Font-Size="Small">Business Impact Analysis</asp:label><asp:button id="btnExit" style="Z-INDEX: 105; LEFT: 33px; POSITION: absolute; TOP: 142px" runat="server" BackColor="Teal" BorderStyle="None" Height="40px" Width="134" Font-Size="Smaller" ForeColor="White" Font-Bold="True" Text="Exit" onclick="btnExit_Click"></asp:button><asp:label id="lblOutputName" style="Z-INDEX: 104; LEFT: 34px; POSITION: absolute; TOP: 108px" runat="server" Height="27px" Width="992px" Font-Size="Small" ForeColor="Navy"></asp:label><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 34px; POSITION: absolute; TOP: 42px" runat="server" Height="4px" Font-Size="Small" ForeColor="White" Font-Bold="True" BackColor="Navy"></asp:label><asp:button id="btnAdd" style="Z-INDEX: 101; LEFT: 187px; POSITION: absolute; TOP: 144px" runat="server" BackColor="Teal" BorderStyle="None" Height="40px" Width="133px" ForeColor="White" Font-Bold="True" Text="Add" onclick="btnAdd_Click"></asp:button></form>
	</body>
</HTML>
