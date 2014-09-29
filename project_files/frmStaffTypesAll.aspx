<%@ Page language="c#" Inherits="WebApplication2.frmStaffTypesAll" CodeFile="frmStaffTypesAll.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		    <h1><asp:label id="lblOrg" runat="server" Visible="False"></asp:label></h1>
			<asp:label id="lblContents" runat="server" ></asp:label>
			<asp:label id="lblContents1" runat="server"  ></asp:label>
			
			<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button></p>
						
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Appointment Types">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" BackColor="Maroon" Text="Delete" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
