<%@ Page language="c#" Inherits="WebApplication2.frmRolesAll" CodeFile="frmRolesAll.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
<form id="frmResourcesInfo" method="post" runat="server">
		<div id="headerSection" ><h1><asp:label id="Label1" Text="Service Models" runat="server" ></asp:label></h1>
			<p><asp:label id="lblContent1" runat="server" ></asp:label></p>
			 
			 <asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
			 <asp:button id="btnAdd" runat="server" Text="Add New Staff Roles" onclick="btnAdd_Click"></asp:button>
			 <asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			</div>
			<div id="gridSection">
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Types of Roles">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
							<asp:button id="btnSkills" runat="server" Visible="false" Text="Skills" CommandName="Skills"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnDelete" runat="server" ForeColor="White" BackColor="Maroon" Text="Delete" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ParentId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></div>
			</form>
		<!--#include file="inc/footer.aspx"-->
</HTML>
