<%@ Page language="c#" Inherits="WebApplication2.frmStaffActionsInd" CodeFile="frmStaffActionsInd.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmOrgResTypes" method="post" runat="server">
		<h1><asp:label id="lblPerson" runat="server" ></asp:label></h1>
		<asp:label id="lblOrg" runat="server" ></asp:label>
			
			<asp:button id="btnAdd" runat="server" Visible="False" onclick="btnAdd_Click"></asp:button>
			<p><asp:label id="lblContents" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="AptOrgName" HeaderText="Organization"></asp:BoundColumn>
					<asp:BoundColumn DataField="STName" HeaderText="Type of Appointment"></asp:BoundColumn>
					<asp:BoundColumn DataField="StatusName" ReadOnly="True" HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnTimesheets" runat="server" Text="Timesheets" CommandName="Timesheets"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="AptOrgId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle Visible="False"></PagerStyle>
			</asp:datagrid>
			
			
			
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
