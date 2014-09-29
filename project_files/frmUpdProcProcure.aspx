<%@ Page language="c#" Inherits="WebApplication2.frmUpdProcProcure" CodeFile="frmUpdProcProcure.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 46px; POSITION: absolute; TOP: 44px" runat="server" Width="675px" Height="30px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 121; LEFT: 54px; POSITION: absolute; TOP: 284px" runat="server" ForeColor="#A7D7CC" Height="30px" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#CC9966" AutoGenerateColumns="False" GridLines="None" AllowSorting="True" CellPadding="4">
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
					<asp:TemplateColumn HeaderText="Select One">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="Label3" style="Z-INDEX: 120; LEFT: 54px; POSITION: absolute; TOP: 245px" runat="server" ForeColor="Navy" Font-Size="Small" Height="21px" Width="300px" BorderStyle="None">Budget Charged</asp:label><asp:label id="Label2" style="Z-INDEX: 119; LEFT: 191px; POSITION: absolute; TOP: 200px" runat="server" Width="65px" Height="21px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Quantity</asp:label><asp:label id="lblQtyMeasure" style="Z-INDEX: 118; LEFT: 390px; POSITION: absolute; TOP: 200px" runat="server" Width="241px" Height="28px" Font-Size="Small" ForeColor="Navy" BorderStyle="None"></asp:label><asp:textbox id="txtQty" style="Z-INDEX: 117; LEFT: 272px; POSITION: absolute; TOP: 198px" runat="server" Width="103px" Height="28px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 46px; POSITION: absolute; TOP: 5px" runat="server" Width="914px" Height="30px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnCancel" style="Z-INDEX: 104; LEFT: 166px; POSITION: absolute; TOP: 103px" runat="server" Width="107px" Height="31px" ForeColor="White" BorderStyle="None" BackColor="Navy" Text="Cancel" Font-Bold="True" onclick="btnCancel_Click"></asp:button><asp:label id="lblDesc" style="Z-INDEX: 105; LEFT: 55px; POSITION: absolute; TOP: 158px" runat="server" Width="202px" Height="21px" Font-Size="Small" ForeColor="Navy" BorderStyle="None">Procurement Action Title</asp:label><asp:textbox id="txtDesc" style="Z-INDEX: 106; LEFT: 272px; POSITION: absolute; TOP: 155px" runat="server" Width="476px" Height="29px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 111; LEFT: 46px; POSITION: absolute; TOP: 103px" runat="server" Width="107px" Height="31px" ForeColor="White" BorderStyle="None" BackColor="Navy" Text="Action" Font-Bold="True" onclick="btnAction_Click"></asp:button></form>
	</body>
</HTML>
