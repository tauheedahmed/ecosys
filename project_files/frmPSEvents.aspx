<%@ Page language="c#" Inherits="WebApplication2.frmPSEvents" CodeFile="frmPSEvents.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmOrgResTypes" method="post" runat="server">
			<div id="headerSection" >
		<h2><asp:label id=lblOrg runat="server"></asp:label></h2>
        <h2><asp:label id=lblBud runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLocation runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
         <asp:label id="lblContents1" runat="server"  ></asp:label>
         <p> <asp:button id="btnExit"  runat="server" Text="OK" onclick="btnExit_Click"></asp:button></p>
			</div>
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnProjects" runat="server" Text="Select" CommandName="Projects"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
		</asp:DataGrid>
              
        </form>
        <!--#include file="inc/footer.aspx"-->
        </HTML>
</HTML>
