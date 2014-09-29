<%@ Page language="c#" Inherits="WebApplication2.frmSEProcs" CodeFile="frmSEProcs.aspx.cs" %>
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
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 7px; POSITION: absolute; TOP: 277px" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True" HeaderText="No">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Seq No">
						<HeaderStyle Width="15px"></HeaderStyle>
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" ForeColor="Navy" BackColor="White" BorderStyle="Solid" BorderColor="Navy" Height="24px" Width="31px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Processes">
						<HeaderStyle Width="400px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="Button3" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Text="Update" Font-Bold="True" Font-Size="Smaller" CommandName="Update"></asp:button>
							<asp:button id="btnClients" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Text="Clients" Font-Bold="True" Font-Size="Smaller" CommandName="Clients"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn Visible="False" HeaderText="Inputs">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnStaff" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Text="Staff" Font-Bold="True" Font-Size="Smaller" CommandName="Staff"></asp:button>
							<asp:button id="btnServices" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Text="Services" Font-Bold="True" Font-Size="Smaller" CommandName="Services"></asp:button>
							<asp:button id="btnOther" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None" Height="25px" Text="Other" Font-Bold="True" Font-Size="Smaller" CommandName="Other"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button6" runat="server" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" Font-Size="Smaller" Font-Bold="True" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Timetables" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:button id="btnSignoff" style="Z-INDEX: 107; LEFT: 306px; POSITION: absolute; TOP: 224px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Sign-Off" onclick="btnSignoff_Click"></asp:button><asp:label id="lblContents3" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 152px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="1051px"></asp:label><asp:label id="lblContents2" style="Z-INDEX: 104; LEFT: 7px; POSITION: absolute; TOP: 81px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="1051px"></asp:label><asp:label id="lblContents1" style="Z-INDEX: 103; LEFT: 7px; POSITION: absolute; TOP: 12px" runat="server" Height="22px" ForeColor="Navy" Font-Size="Small" Width="1051px"></asp:label><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 223px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="134" Font-Bold="True" Text="Back" onclick="btnExit_Click"></asp:button><asp:button id="btnAdd" style="Z-INDEX: 101; LEFT: 161px; POSITION: absolute; TOP: 223px" runat="server" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Font-Size="Smaller" Width="134px" Font-Bold="True" Text="Add" CommandName="Add" onclick="btnAdd_Click"></asp:button></form>
	</body>
</HTML>
