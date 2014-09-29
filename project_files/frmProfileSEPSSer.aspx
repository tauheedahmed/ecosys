<%@ Page language="c#" Inherits="WebApplication2.frmProfileSEPSSer" CodeFile="frmProfileSEPSSer.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Emergency Procedures</title>
		<META content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY bgColor="white">
		<FORM id="frmEmergencyProcedures" method="post" runat="server">
			<asp:datagrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 8px; POSITION: absolute; TOP: 230px" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="10000px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services Needed">
						<HeaderStyle Width="600px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Description (Type inside box to update)">
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" Height="27px" BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px" Width="500px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" Font-Size="Smaller" Text="Remove" Font-Bold="True" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblContents2" style="Z-INDEX: 106; LEFT: 7px; POSITION: absolute; TOP: 91px" runat="server" ForeColor="Navy" Height="22px" Width="914px" Font-Size="Small"></asp:label>
			<asp:label id="lblContents1" style="Z-INDEX: 105; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" ForeColor="Navy" Height="22px" Width="914px" Font-Size="Small"></asp:label>
			<asp:button id="btnAdd" style="Z-INDEX: 103; LEFT: 164px; POSITION: absolute; TOP: 176px" runat="server" ForeColor="White" BackColor="Navy" BorderStyle="None" Height="40px" Width="104px" Font-Size="Smaller" Font-Bold="True" Text="Add" onclick="btnAllTypes_Click"></asp:button><asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 176px" runat="server" Width="134" Height="40px" BorderStyle="None" BackColor="Navy" ForeColor="White" Text="OK" Font-Size="Smaller" Font-Bold="True" onclick="btnExit_Click"></asp:button></FORM>
	</BODY>
</HTML>
