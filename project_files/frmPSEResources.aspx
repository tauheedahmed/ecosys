<%@ Page language="c#" Inherits="WebApplication2.frmOLPSEPSSPeople" CodeFile="frmPSEResources.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		<div id="headerSection" ><h1><asp:label id="lblTitle" Text="EcoSys:  Indiv" runat="server" 
                meta:resourcekey="Label1Resource1" ></asp:label></h1>
		<h2><asp:label id="lblBusProfiles" Text="Business Profiles" runat="server" 
                meta:resourcekey="lblBusProfilesResource1" ></asp:label></h2>
		<h2><asp:label id="lblServiceName" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblEventName" runat="server" ></asp:label></h2>
			<p><asp:label id="lblContents1" runat="server" Font-Size="Small" ></asp:label>
			<asp:label id="lblContents2" runat="server" Font-Size="Small"></asp:label></p>
			<asp:button id="btnOK" runat="server"  Text="OK" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button></div>
            <asp:datagrid id="DataGrid1" 
                runat="server" ForeColor="Navy" Height="30px" BorderStyle="None" HorizontalAlign="Left" 
                AutoGenerateColumns="False" onitemcommand="DataGrid1_ItemCommand">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Left" ForeColor="Navy" BorderStyle="None" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
							<ItemTemplate>
							<asp:DropDownList ID="lstLoc" runat="server" ForeColor="Navy">
                                </asp:DropDownList>
						</ItemTemplate>
						</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" ForeColor="Navy" Width="600px" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnRemove" runat="server" Text="Remove" ForeColor="White" CommandName="Remove"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Desc" Visible="false" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocTypesId" Visible="false" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></form>
	</body>
</HTML>
