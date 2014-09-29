<%@ Page language="c#" Inherits="WebApplication2.frmPeopleCourses" CodeFile="frmPeopleCourses.aspx.cs" %>
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
			<asp:datagrid id="dgdActs" style="Z-INDEX: 100; LEFT: 13px; POSITION: absolute; TOP: 151px" runat="server" Font-Size="Small" AutoGenerateColumns="False" Width="924px" Height="30px" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None" HorizontalAlign="Left">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<EditItemStyle HorizontalAlign="Left" VerticalAlign="Top"></EditItemStyle>
				<AlternatingItemStyle HorizontalAlign="Left" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Course Name">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="StartTime" HeaderText="Start Time" DataFormatString="{0:d}">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" HeaderText="Location">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="OrgStatus" HeaderText="Status">
						<HeaderStyle Width="200px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EndTime" ReadOnly="True" HeaderText="End Time" DataFormatString="{0:d}"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ActStatus" ReadOnly="True">
						<HeaderStyle Width="100px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleStatus" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnDelete" runat="server" ForeColor="White" BackColor="Red" BorderStyle="None" Width="200px" Font-Bold="True" CommandName="Delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblOrg" style="Z-INDEX: 109; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="11px" Width="814px" Font-Size="Small" Font-Bold="True">Organization Name Here</asp:label><asp:label id="lblContents2" style="Z-INDEX: 105; LEFT: 10px; POSITION: absolute; TOP: 77px" runat="server" Font-Size="Small" Width="861px" Height="24px" ForeColor="Navy"></asp:label><asp:button id="btnExit" style="Z-INDEX: 104; LEFT: 11px; POSITION: absolute; TOP: 107px" runat="server" Font-Size="Smaller" Width="134" Height="40px" BorderStyle="None" BackColor="Red" ForeColor="White" Text="Exit" Font-Bold="True" onclick="btnExit_Click"></asp:button><asp:button id="btnAddS" style="Z-INDEX: 102; LEFT: 153px; POSITION: absolute; TOP: 110px" runat="server" Font-Size="Smaller" Width="172px" Height="37px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="Register for Class" Font-Bold="True" CommandName="Add" onclick="btnAddS_Click"></asp:button><asp:label id="lblContents1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 45px" runat="server" Font-Size="Small" Width="861px" Height="24px" ForeColor="Navy"></asp:label></form>
	</body>
</HTML>
