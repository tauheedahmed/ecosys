<%@ Page language="c#" Inherits="WebApplication2.frmPSEPRes" CodeFile="frmPSEPRes.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
<FORM id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="Label1" Text="Service Models" runat="server" ></asp:label></h1>
		<p><asp:label id="lblContents1" runat="server" ></asp:label></p>
		<p>
            <asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click">
            </asp:button>
            <asp:button id="btnAdd" runat="server" Text="Add New Services" onclick="btnAllTypes_Click">
            </asp:button>
        </p></div>
		
		<div id="gridSection"><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Height="30px" BorderColor="#CC9966" BorderStyle="None" 
		BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ResourceName" HeaderText="Resource Types Needed">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Description (Type inside box to update)">
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" Height="27px" BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px" Width="500px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" BackColor="Maroon" ForeColor="White" Text="Remove" Font-Bold="True" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid></div>
			
			</FORM>
		<!--#include file="inc/footer.aspx"-->
</HTML>
