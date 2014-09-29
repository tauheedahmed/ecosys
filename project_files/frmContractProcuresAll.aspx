<%@ Page language="c#" Inherits="WebApplication2.frmContractProcuresAll" CodeFile="frmContractProcuresAll.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
            	
		<div id="maindiv" >
		
			
			<form id="frmEmergencyProcedures" method="post" runat="server">
			<div id="headerSection" >
			<h3><asp:label id="lblOrg" runat="server" ></asp:label></h3>
			
			<h3><asp:label id="lblTitle" runat="server" ></asp:label></h3>
			<p><asp:label id="lblContents" runat="server" ></asp:label>
			<asp:label id="lblContents1" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			
			</div>
			<asp:datagrid id="DataGrid1"  runat="server" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ResTypeName" HeaderText="Type of Resource"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" ReadOnly="True" HeaderText="Requesting Units"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" ReadOnly="True" HeaderText="Locations">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnSelect" runat="server" Text="Select" CommandName="Select" ></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
