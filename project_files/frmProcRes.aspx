<%@ Page language="c#" Inherits="WebApplication2.frmProcRes" CodeFile="frmProcRes.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLoc runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblDel runat="server" ></asp:label></h2>
        <h2><asp:label id=lblProject runat="server" ></asp:label></h2>
        <h2><asp:label id=lblTask runat="server" ></asp:label></h2>
        <h2><asp:label id=lblType runat="server" ></asp:label></h2>
        <asp:label id=lblContents1 runat="server" ></asp:label>
		<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
		 <asp:button id=btnCancel runat="server" Text="Cancel" onclick="btnCancel_Click" 
        Visible="False"></asp:button></p>
			</div>
			    <asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ResourceName" HeaderText="Resources"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
						 <asp:Button id="btnProcurements" runat="server" Text="Items" CommandName="Items"></asp:Button>
						<asp:button id="btnDesc" runat="server" Text="Description" CommandName="Desc"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ResTypesId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="QtyMeasure" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="QtyMeasurePl" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ResTypesType" ReadOnly="True"></asp:BoundColumn>
					
				</Columns>
			</asp:datagrid>
			<div><p><asp:label id="lblDesc" runat="server" Visible="false" Text="Description" ></asp:label></p>
            <asp:textbox id="txtDesc" runat="server" visible="false" Width="30em" Height="83px" ForeColor="Navy" TextMode="MultiLine"></asp:textbox>
            </div>
            </form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
