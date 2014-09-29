<%@ Page language="c#" Inherits="WebApplication2.frmStaffActionsProc" CodeFile="frmStaffActionsProc.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<asp:label id="lblContents1" runat="server" ></asp:label>
			<p><asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
			
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Person Appointed">
						<ItemStyle HorizontalAlign="Left" ></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" HeaderText="Appointing Organizations"></asp:BoundColumn>
					<asp:BoundColumn DataField="StaffType" HeaderText="Appointment Type"></asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnSelect" runat="server" ForeColor="White" BackColor="Teal" Text="Select" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn Visible="False">
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" ForeColor="White" BackColor="Teal" Text="Update" BorderStyle="None" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" ForeColor="White" BackColor="Maroon" Text="Delete" BorderStyle="None" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgIdSA" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgSTId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
