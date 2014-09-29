<%@ Page language="c#" Inherits="WebApplication2.frmBudOrgsSel" CodeFile="frmBudOrgsSel.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmOrgs" method="post" runat="server">
		<div id="headerSection" >
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<p><asp:label id="lblContents" runat="server" ></asp:label>
			<asp:label id="lblContents1" runat="server"></asp:label> </p>
			<asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:button id="btnOrgTypes" runat="server" Text="Show External Organizations" onclick="btnOrgTypes_Click"></asp:button>
			</div>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
			
			<!--#include file="inc/footer.aspx"-->
</HTML>
