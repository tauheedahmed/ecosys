<%@ Page language="c#" Inherits="WebApplication2.TaskStepsNum" CodeFile="frmTaskStepsNum.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ServiceStepsNum</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="ServiceStepsNum" method="post" runat="server">
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 100; LEFT: 12px; POSITION: absolute; TOP: 184px" runat="server" Width="600px" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Navy"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="No.">
						<HeaderStyle Width="30px"></HeaderStyle>
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Width="26px" BorderStyle="Solid" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<asp:label id="lblContent2" style="Z-INDEX: 106; LEFT: 10px; POSITION: absolute; TOP: 84px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="649px"></asp:label>
			<asp:label id="lblContent1" style="Z-INDEX: 105; LEFT: 7px; POSITION: absolute; TOP: 48px" runat="server" Font-Size="Small" ForeColor="Navy" Height="24px" Width="931px"></asp:label>
			<asp:label id="lblOrg" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Navy" Height="31px" Width="914px">Organization Name Here</asp:label>
			<asp:button id="btnReseq" style="Z-INDEX: 102; LEFT: 161px; POSITION: absolute; TOP: 127px" runat="server" Font-Bold="True" BackColor="Red" Text="Cancel" BorderStyle="None" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" CommandName="btnCancel" onclick="btnReseq_Click"></asp:button>
			<asp:button id="btnOK" style="Z-INDEX: 101; LEFT: 10px; POSITION: absolute; TOP: 128px" runat="server" Font-Bold="True" BackColor="Red" Text="OK" BorderStyle="None" Font-Size="Smaller" ForeColor="White" Height="40px" Width="134" onclick="btnOK_Click"></asp:button></form>
	</body>
</HTML>
