<%@ Page language="c#" Inherits="WebApplication2.frmTaskResources" CodeFile="frmTaskResources.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body>
		<form id="frmResourcesInfo" method="post" runat="server">
			<asp:label id="lblContents1" style="Z-INDEX: 100; LEFT: 38px; POSITION: absolute; TOP: 36px" runat="server" Font-Size="Small" ForeColor="Navy" Height="20px" Width="962px"></asp:label>
			<asp:button id="btnCancel" style="Z-INDEX: 107; LEFT: 180px; POSITION: absolute; TOP: 94px" runat="server" Width="135" Height="35px" ForeColor="White" Font-Size="Smaller" BorderStyle="None" BackColor="Navy" Font-Bold="True" Text="Cancel" onclick="btnCancel_Click"></asp:button><asp:button id="btnAddTemp" style="Z-INDEX: 106; LEFT: 323px; POSITION: absolute; TOP: 94px" runat="server" ForeColor="White" Height="35" Width="200px" Text="Add Resource Types" ToolTip="Recommended" Font-Bold="True" BackColor="Navy" BorderStyle="None" Visible="False" onclick="btnAddTemp_Click"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 38px; POSITION: absolute; TOP: 60px" runat="server" Font-Size="Small" ForeColor="Navy" Height="19px" Width="974px"></asp:label><asp:button id="btnOK" style="Z-INDEX: 104; LEFT: 38px; POSITION: absolute; TOP: 93px" runat="server" Font-Size="Smaller" ForeColor="White" Height="35px" Width="135" Text="Exit" Font-Bold="True" BackColor="Navy" BorderStyle="None" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 38px; POSITION: absolute; TOP: 11px" runat="server" Font-Size="Small" ForeColor="White" Height="17px" Font-Bold="True" BackColor="Navy"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 39px; POSITION: absolute; TOP: 132px" runat="server" ForeColor="Maroon" Height="30px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" ForeColor="Navy" BorderStyle="None" VerticalAlign="Top" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
<HeaderStyle Width="20px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ResTypesId" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="BackupsId" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="ResTypeName" HeaderText="Resource Type">
<HeaderStyle Width="300px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="BackupsName" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="ProcurementsId" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="InventoryId" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Resource Item">
<HeaderStyle Width="400px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Qty" ReadOnly="True"></asp:BoundColumn>
<asp:TemplateColumn Visible="False" HeaderText="Qty Required">
<HeaderStyle Width="150px">
</HeaderStyle>

<ItemTemplate>
<asp:TextBox id=Textbox1 runat="server" Width="72px" ForeColor="Teal" BorderStyle="Solid" BorderColor="Teal"></asp:TextBox>
<asp:label id=Label1 runat="server" Width="181px" Height="19px" ForeColor="Navy" Font-Size="Small"></asp:label>
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<ItemTemplate>
<asp:button id=btnBudgets runat="server" ForeColor="White" Font-Size="Smaller" Text="Budgets" Font-Bold="True" BackColor="Teal" BorderStyle="None" CommandName="Budgets"></asp:button>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="QtyMeasure" ReadOnly="True"></asp:BoundColumn>
</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
