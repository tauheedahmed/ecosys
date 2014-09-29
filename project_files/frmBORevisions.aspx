<%@ Page language="c#" Inherits="WebApplication2.frmBORevisions" CodeFile="frmBORevisions.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblMgr1" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblBud" runat="server" ></asp:label></h2>
			<h3><asp:label id="lblBudget" runat="server" ></asp:label></h3>
			<asp:label id="lblReq" runat="server" ></asp:label>
			<p><asp:label id="lblContents" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
			
			</div>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
	
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Date" HeaderText="Date" DataFormatString="{0:d}">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Amount" HeaderText="Amount"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Text="Update" CommandName="Update" ></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="BOJournalsId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
                </asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
