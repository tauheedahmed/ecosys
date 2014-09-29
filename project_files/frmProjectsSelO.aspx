<%@ Page language="c#" Inherits="WebApplication2.frmProjectsSelO" CodeFile="frmProjectsSelO.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<!--#include file="inc/HeaderWP.aspx"-->
<form id="frmResourcesInfo" method="post" runat="server">
<div id="headerSection" >
			<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
			<h2><asp:label id="lblLoc" runat="server" ></asp:label></h2>
			<p><asp:label id="lblContent1" runat="server" ></asp:label></p>
			<asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
			</div>
			
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
			<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ProjName" HeaderText="Projects"></asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
					<asp:BoundColumn DataField="MgrName" HeaderText="Organization"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" HeaderText="Location"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnSel" runat="server" ForeColor="White" Text="Select" BackColor="Teal" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
