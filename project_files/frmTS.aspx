<%@ Page language="c#" Inherits="WebApplication2.frmTS" CodeFile="frmTS.aspx.cs" %>
<!--#include file="inc/HeaderF.aspx"-->
		<form id="frmOrgResTypes" method="post" runat="server">
		<div id="headerSection">
		<h1><asp:label id="lblPerson" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
		<asp:label id="lblContents" runat="server" ></asp:label>
		<p><asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
		</p>
		<label>Select Month  </label><asp:dropdownlist id="lstMonth" runat="server" 
                AutoPostBack="True" onselectedindexchanged="lstMonth_SelectedIndexChanged"></asp:dropdownlist></p>
			
	</div>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"> </asp:BoundColumn>
					<asp:BoundColumn DataField="ProcName" HeaderText="Procedures"></asp:BoundColumn>
					<asp:BoundColumn DataField="ProjectName" HeaderText="Projects"> </asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" HeaderText="Roles"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Hours" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Hours">
						<ItemTemplate>
							<asp:TextBox id="txtHours" runat="server" BorderStyle="Solid" Width="103px" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="BudName" HeaderText="Budget Charged"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProcProcuresId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
