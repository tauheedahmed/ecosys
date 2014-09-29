<%@ Page language="c#" Inherits="WebApplication2.frmOrgLocMgrs" CodeFile="frmOrgLocMgrs.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h1><asp:label id="lblLoc"  runat="server"  ></asp:label></h1>
			<asp:label id="lblContents1" runat="server"  ></asp:label>
			<p>	<asp:button id="btnBack" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button></p>
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Managers"></asp:BoundColumn>
					<asp:BoundColumn DataField="Type" HeaderText="Appointment Type"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" HeaderText="Organization"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" ForeColor="White" Text="Remove" Font-Bold="True" BackColor="Maroon" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
