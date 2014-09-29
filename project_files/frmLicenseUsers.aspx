<%@ Page language="c#" Inherits="WebApplication2.frmLicenseUsers" CodeFile="frmLicenseUsers.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->

<form id="frmAddProcedure" method="post" runat="server">
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<p><asp:button id="btnExit" runat="server" Text="Exit" onclick="updateForm"></asp:button></p>
			
			
			<p><asp:label id="lblDomain" runat="server" Text="Region"></asp:label>
			<asp:dropdownlist id="lstDomain" runat="server" ></asp:dropdownlist></p>
			
			<p><asp:label id="lblLicDate" runat="server" Text="Effective Date"></asp:label>
			<asp:textbox id="txtLicDate" runat="server" ></asp:textbox></p>
			
			<asp:label id="lblLicStatus" runat="server" Text="Status"></asp:label>
			<asp:dropdownlist id="lstLicStatus" runat="server" >
				<asp:ListItem Value="Inactive" Selected="True">Inactive</asp:ListItem>
				<asp:ListItem Value="Active">Active</asp:ListItem>
			</asp:dropdownlist>
			<p><asp:label id="lblVis" runat="server" Text="Visibility Level"> </asp:label>
			<asp:radiobuttonlist id="rblVis" runat="server" ></asp:radiobuttonlist></p>
			
			<asp:datagrid id="DataGrid1" runat="server" GridLines="None" AllowSorting="True" CellPadding="4" BorderWidth="1px" BorderColor="White" AutoGenerateColumns="False" BackColor="White" BorderStyle="None">
<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>

<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>

<ItemStyle HorizontalAlign="Left" ForeColor="Navy" VerticalAlign="Top" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal">
</HeaderStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Types of User Ids">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="User Id Limit">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
<asp:TextBox id="txtMax" runat="server" BorderStyle="Solid" BorderColor="Navy" BorderWidth="1px" ForeColor="Navy" Height="24px" Width="50px" Font-Size="X-Small"></asp:TextBox>
						
</ItemTemplate>

<EditItemTemplate>
							&nbsp;
						
</EditItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn HeaderText="No. Issued">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
<asp:Button id=btnUpdate runat="server"  Text="Update" CommandName="Update"></asp:Button>
<asp:Button id=btnAdd runat="server"  Text="Add" CommandName="Add"></asp:Button>
</ItemTemplate>
</asp:TemplateColumn>
</Columns>
</asp:datagrid>
			
			
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
