<%@ Page language="c#" Inherits="WebApplication2.frmOrgLocations" CodeFile="frmOrgLocations.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmEmergencyProcedures" method="post" runat="server">
		
		<h1><asp:label id="lblOrg" runat="server"  ></asp:label></h1>
		<h2><asp:label id="lblBd" runat="server" ></asp:label></h2>
		<asp:label id="lblContents" runat="server" ></asp:label>
		<p><asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server" Text="Add Locations" Visible="False" onclick="btnAdd_Click"></asp:button></p>
			<asp:datagrid id="DataGrid1" runat="server" 
                AutoGenerateColumns="False" BorderColor="#CC9966" 
                BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" 
                AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Locations">
						<HeaderStyle HorizontalAlign="Left" ></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" Text="Services" CausesValidation="false" CommandName="Services"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnMgr" visible="false" runat="server" Text="Managers" CommandName="Mgrs"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ProfileId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Reports">
						<HeaderStyle BackColor="Navy"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnStaff" runat="server" Text="Staff Inputs" CommandName="rptWP3"></asp:button>
							<asp:button id="btnNStaff" runat="server" Text="NonStaff Inputs" CommandName="NonStaff"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="LocationsId" ReadOnly="True"></asp:BoundColumn>
					
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			
                </form>
<!--#include file="inc/footer.aspx"-->
</HTML>
