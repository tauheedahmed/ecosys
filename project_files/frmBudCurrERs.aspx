<%@ Page language="c#" Inherits="WebApplication2.frmBudCurERs" CodeFile="frmBudCurrERs.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
			<h1><asp:label id="lblOrg" runat="server"  ></asp:label></h1>
			<h2><asp:label id="lblBudName" runat="server"  ></asp:label></h2>
			<asp:label id="lblContent1" runat="server" ></asp:label>
			<p>	<asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			</p>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle  ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Currencies">
						<HeaderStyle ></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Exchange Rate">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:TextBox id="txtER" runat="server" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="CurrId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ExchangeRate" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<p></p>
			<!--#include file="inc/footer.aspx"-->
			</form>
</HTML>
