<%@ Page language="c#" Inherits="WebApplication2.frmTaskSteps" CodeFile="frmTaskSteps.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 22px; POSITION: absolute; TOP: 188px" runat="server" GridLines="None" ForeColor="Navy" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66">
</SelectedItemStyle>

<AlternatingItemStyle BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle ForeColor="#000099" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal">
</HeaderStyle>

<FooterStyle ForeColor="#330099" BackColor="#FFFFCC">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="Seq" HeaderText="No.">
<HeaderStyle Width="30px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Name">
<HeaderStyle Width="300px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="LocName" HeaderText="Location">
<HeaderStyle Width="300px">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="LocId" ReadOnly="True"></asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="200px">
</HeaderStyle>

<ItemTemplate>
<asp:button id=btnUpdate runat="server" Height="25px" BorderStyle="None" BackColor="Navy" ForeColor="White" CommandName="Update" Font-Bold="True" Text="Update" Font-Size="Smaller" Width="88px"></asp:button>
<asp:button id=Button6 runat="server" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" CommandName="Remove" Font-Bold="True" Text="Remove" Font-Size="Smaller" Width="88px"></asp:button>
<asp:CheckBox id=cbxSel runat="server" Visible="False"></asp:CheckBox>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="StepId" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Vis" ReadOnly="True"></asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC">
</PagerStyle>
			</asp:datagrid>
			<asp:button id="btnPlan" style="Z-INDEX: 109; LEFT: 162px; POSITION: absolute; TOP: 149px" runat="server" Width="99px" Height="34px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Text="Add Steps" Font-Bold="True" CommandName="Draft" onclick="btnPlan_Click"></asp:button>
			<asp:button id="btnExisting" style="Z-INDEX: 107; LEFT: 266px; POSITION: absolute; TOP: 150px" runat="server" Width="154px" Height="34px" BorderStyle="None" BackColor="Navy" ForeColor="White" CommandName="Add" Font-Bold="True" Text="Renumber Steps" Font-Size="Smaller" onclick="btnExisting_Click"></asp:button><asp:label id="lblContents2" style="Z-INDEX: 104; LEFT: 10px; POSITION: absolute; TOP: 77px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label><asp:button id="btnExit" style="Z-INDEX: 103; LEFT: 22px; POSITION: absolute; TOP: 148px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="34px" Width="134" Font-Size="Smaller" Font-Bold="True" Text="Exit" onclick="btnExit_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="32px" Width="962px" Font-Size="Small" Font-Bold="True"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" ForeColor="Navy" Height="24px" Width="861px" Font-Size="Small"></asp:label></form>
	</body>
</HTML>
