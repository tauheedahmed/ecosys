<%@ Page language="c#" Inherits="WebApplication2.frmOwnStaffSkillsAll" CodeFile="frmStaffSkillsAll.aspx.cs" %>
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
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 29px; POSITION: absolute; TOP: 43px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="649px"></asp:label><asp:button id="btnDomain" style="Z-INDEX: 111; LEFT: 624px; POSITION: absolute; TOP: 203px" runat="server" Font-Size="Smaller" ForeColor="White" Height="35px" Width="159px" BorderStyle="None" Text="Within Local Area" Font-Bold="True" BackColor="Navy" onclick="btnDomain_Click"></asp:button><asp:label id="lblStep2" style="Z-INDEX: 110; LEFT: 439px; POSITION: absolute; TOP: 164px" runat="server" Font-Size="Small" ForeColor="Navy" Height="23px" Width="380px" BackColor="White"></asp:label><asp:dropdownlist id="lstRoles" style="Z-INDEX: 109; LEFT: 28px; POSITION: absolute; TOP: 211px" runat="server" ForeColor="Navy" Height="201px" Width="362px"></asp:dropdownlist><asp:label id="lblStep1" style="Z-INDEX: 108; LEFT: 29px; POSITION: absolute; TOP: 167px" runat="server" Font-Size="Small" ForeColor="Navy" Height="26px" Width="349px" BackColor="White"></asp:label><asp:label id="lblContent2" style="Z-INDEX: 107; LEFT: 29px; POSITION: absolute; TOP: 75px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="649px"></asp:label><asp:button id="btnOrg" style="Z-INDEX: 105; LEFT: 441px; POSITION: absolute; TOP: 203px" runat="server" Font-Size="Smaller" ForeColor="White" Height="35px" Width="170px" BorderStyle="None" Text="Within Organization" Font-Bold="True" BackColor="Navy" onclick="btnOwn_Click"></asp:button><asp:datagrid id="DataGrid1" style="Z-INDEX: 104; LEFT: 29px; POSITION: absolute; TOP: 270px" runat="server" ForeColor="Maroon" Height="30px" Width="650px" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="WorkPhone">
						<HeaderStyle Width="150px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Email"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle Width="150px"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="Button2" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Width="60px" BackColor="Navy" Font-Bold="True" Text="Select" BorderStyle="None" CommandName="Select"></asp:button>
							<asp:button id="btnMsg" runat="server" Font-Size="Smaller" ForeColor="White" Height="25px" Width="120px" BackColor="Navy" Font-Bold="True" Text="Send Message" BorderStyle="None" CommandName="Msg"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid><asp:button id="btnCancel" style="Z-INDEX: 103; LEFT: 168px; POSITION: absolute; TOP: 109px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" BorderStyle="None" Text="Cancel" Font-Bold="True" BackColor="Red" onclick="btnCancel_Click"></asp:button><asp:button id="btnOK" style="Z-INDEX: 102; LEFT: 19px; POSITION: absolute; TOP: 109px" runat="server" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" BorderStyle="None" Text="OK" Font-Bold="True" BackColor="Red" onclick="btnOK_Click"></asp:button><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 29px; POSITION: absolute; TOP: 8px" runat="server" Font-Size="Small" ForeColor="Navy" Height="31px" Width="914px" Font-Bold="True">Organization Name Here</asp:label></form>
	</body>
</HTML>
