<%@ Page language="c#" Inherits="WebApplication2.frmEventsAll" CodeFile="frmEventsAll.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
		<form id="frmResourcesInfo" method="post" runat="server">
		<h1><asp:label id="lblTitle" Text="EcoSys: Service Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfilesName" runat="server" ></asp:label></h2>
		<h3><asp:label id="lblServiceName" runat="server" ></asp:label></h3>
			<p><asp:label id="lblContents" runat="server" ></asp:label>
			</p>
			<asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add Deliverable/Impact" onclick="btnAdd_Click"></asp:button>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Deliverables">
					<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
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
							<asp:button id="btnDelete" runat="server" Text="Delete" BackColor="Maroon" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="HouseholdFlag" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
