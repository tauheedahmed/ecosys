<%@ Page language="c#" Inherits="WebApplication2.frmProjectsSel" CodeFile="frmProjectsSel.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		
		<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
        <h2><asp:label id=lblBud runat="server"  ></asp:label></h2>
        <h3><asp:label id=lblLoc runat="server" ></asp:label></h3>
        <h4><asp:label id=lblService runat="server" ></asp:label></h4>
        <h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
		
			<asp:label id="lblContent1" runat="server" ></asp:label>
			
			<asp:button id="btnCancel" runat="server" Text="OK" onclick="btnCancel_Click"></asp:button>
			
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ProjName" HeaderText="Projects"></asp:BoundColumn>
					<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="Button1" runat="server" Text="Update" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			</form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
