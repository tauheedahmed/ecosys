<%@ Page language="c#" Inherits="WebApplication2.frmAssessSelect" CodeFile="frmPSEPO.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
		<form id="frmInput" method="post" runat="server">
		<div id="headerSection" >
			<h1><asp:label id="Label1" Text="Business Models" runat="server" ></asp:label></h1>
		    <h2><asp:label id="lblProcessName" Text="Process Name" runat="server" ></asp:label></h2>
			<h3><asp:label id="lblOrg" Text="Organization Name" runat="server" ></asp:label></h3>
            <p><asp:label id="lblContents1" runat="server"></asp:label>
			<asp:label id="lblContents2" runat="server" ></asp:label>
			<asp:label id="lblContents3" runat="server" ></asp:label>
			<p>
			<asp:button id="btnExit" runat="server" Text="Return to Previous Form" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add Outputs" CommandName="Add" onclick="btnAdd_Click"></asp:button></p></div>
			
			<div id="gridSection"><asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False" onitemcommand="DataGrid1_ItemCommand">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" ></asp:BoundColumn>				
					<asp:TemplateColumn HeaderText="Description">
						<ItemTemplate>
						<asp:TextBox id="txtDesc" runat="server" Width="20em" ></asp:TextBox>
					    </ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Quantity" >
						<ItemTemplate>
							<asp:TextBox id="txtQty" runat="server" Width="5em" ></asp:TextBox>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn HeaderText="Unit of Measure" DataField="QtyMeasure" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Qty" Visible="false" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="QtyId" Visible="false" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Desc" Visible="false" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" Text="Remove" BackColor="Maroon" ForeColor="White" runat="server" CommandName="Remove" ></asp:button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
			</div>
		</form>
		<!--#include file="inc/footer.aspx"-->
</HTML>
