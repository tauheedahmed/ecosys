<%@ Page language="c#" Inherits="WebApplication2.frmProcessInputs" CodeFile="frmProcessInputs.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmProcessInputs</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form method="post" runat="server">
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 152px" runat="server" Width="914px" Height="50px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AutoGenerateColumns="False" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle ForeColor="#000099" BackColor="#CCFFFF"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="ProcessId"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Id"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ResourceId"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Resource Name">
						<HeaderStyle Width="300px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Unit of Measure">
						<ItemTemplate>
							<asp:Label id=Label2 runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.QuantityMeasure") %>'>
							</asp:Label>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:DropDownList id="DropDownList1" runat="server" Width="216px"></asp:DropDownList>
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="QuantityNeeded" HeaderText="Qty Needed"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnEdit" runat="server" BackColor="#000099" Width="80px" Font-Bold="True" Text="Edit" ForeColor="White" CommandName="Edit" CausesValidation="false"></asp:Button>
							<asp:Button id="btnDelete" runat="server" BackColor="Red" Width="80px" Font-Bold="True" Text="Delete" ForeColor="White" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							<asp:Button id="Button3" runat="server" BackColor="#000099" Font-Bold="True" Text="Update" ForeColor="White" CommandName="Update"></asp:Button>&nbsp;
							<asp:Button id="btnCancel" runat="server" BackColor="#000099" Font-Bold="True" Text="Cancel" ForeColor="White" CommandName="Cancel" CausesValidation="false"></asp:Button>
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC"></PagerStyle>
			</asp:DataGrid>
			<asp:button id="btnExit" style="Z-INDEX: 107; LEFT: 9px; POSITION: absolute; TOP: 99px" runat="server" BackColor="Red" BorderStyle="None" Height="40px" Width="134" ForeColor="White" Font-Size="Smaller" Font-Bold="True" Text="Exit"></asp:button>
			<asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 156px; POSITION: absolute; TOP: 102px" runat="server" BackColor="Red" BorderStyle="None" Height="40px" Width="133px" ForeColor="White" Font-Bold="True" Text="Add"></asp:button>
			<asp:Label id="lblOrg" style="Z-INDEX: 106; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Height="25px" Width="859px" Font-Bold="True" Font-Size="Small" ForeColor="Navy">Organization Name Here</asp:Label>
			<asp:Label id="lblContent1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 44px" runat="server" Width="782px" Height="32px" Font-Size="Small" ForeColor="Navy" BackColor="White"></asp:Label>
		</form>
	</body>
</HTML>
