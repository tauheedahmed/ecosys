<%@ Page language="c#" Inherits="WebApplication2.frmPSEPStaff" CodeFile="frmPSEPStaff.aspx.cs" %>
<<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="Label1" Text="Service Models" runat="server" ></asp:label></h1>
		    <asp:label id="lblContents2" runat="server" ></asp:label>
		    <p><asp:label id="lblContents1" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" CommandName="Exit" Text="OK" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add Staff Roles" CommandName="Add" onclick="btnAdd_Click"></asp:button>
			</div>
			
			<div id="gridSection"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" HeaderText="Staff Types">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Description">
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" ForeColor="Teal" BorderStyle="Solid" BorderColor="Teal" Height="27px" Width="500px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" ForeColor="White" BackColor="Maroon" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></div>
		</form>
		<!--#include file="inc/footer.aspx"-->
</HTML>
