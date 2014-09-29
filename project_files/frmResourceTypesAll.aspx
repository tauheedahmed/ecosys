<%@ Page language="c#" Inherits="WebApplication2.frmResourceTypesAll" CodeFile="frmResourceTypesAll.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		<div id="headerSection">
		<h1><asp:label id="lblTitle1" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProcessName" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
		<p><asp:label id="lblContents1" runat="server" ></asp:label></p>
		<asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
		<asp:button id="btnAddAll" runat="server" Text="Add" onclick="btnAddAll_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
		</div>
		<div id="gridSection">
		<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Resource Types">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn >
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
							<asp:button id="btnDelete" runat="server" Text="Delete" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ParentId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="QtyMeasuresId" ReadOnly="True"></asp:BoundColumn>
				
				</Columns>
			</asp:datagrid></div>
			
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
