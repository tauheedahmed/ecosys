<%@ Page language="c#" Inherits="WebApplication2.frmUpdProjProcure" CodeFile="frmUpdProjProcure.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmAddProcedure</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmAddProcedure" method="post" runat="server">
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 43px" runat="server" Width="675px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 121; LEFT: 56px; POSITION: absolute; TOP: 361px" runat="server" ForeColor="#A7D7CC" Height="30px" BorderStyle="None" BackColor="White" CellPadding="4" AllowSorting="True" GridLines="None" AutoGenerateColumns="False" BorderColor="#CC9966" BorderWidth="1px" Visible="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="BOLocsId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="FYName" HeaderText="FY"></asp:BoundColumn>
					<asp:BoundColumn DataField="VersionName" HeaderText="Version"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Budgets">
						<HeaderStyle HorizontalAlign="Left" Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="SOFName" HeaderText="Source of Funds"></asp:BoundColumn>
					<asp:BoundColumn DataField="CurrCode" HeaderText="Currency"></asp:BoundColumn>
					<asp:BoundColumn HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Selection One">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="Label2" style="Z-INDEX: 119; LEFT: 64px; POSITION: absolute; TOP: 161px" runat="server" Width="71px" Height="21px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Quantity</asp:label><asp:label id="lblQtyMeasure" style="Z-INDEX: 118; LEFT: 283px; POSITION: absolute; TOP: 163px" runat="server" Width="151px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"></asp:label><asp:textbox id="txtQty" style="Z-INDEX: 117; LEFT: 161px; POSITION: absolute; TOP: 159px" runat="server" Width="103px" Height="28px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 124px; POSITION: absolute; TOP: 108px" runat="server" Width="107px" Height="31px" ForeColor="White" BorderStyle="None" BackColor="Navy" Text="Cancel" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblDesc" style="Z-INDEX: 105; LEFT: 57px; POSITION: absolute; TOP: 201px" runat="server" Width="419px" Height="21px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Comments</asp:label><asp:textbox id="txtDesc" style="Z-INDEX: 106; LEFT: 56px; POSITION: absolute; TOP: 230px" runat="server" Width="512px" Height="83px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 110; LEFT: 4px; POSITION: absolute; TOP: 108px" runat="server" Width="107px" Height="31px" ForeColor="White" BorderStyle="None" BackColor="Navy" Text="Action" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
