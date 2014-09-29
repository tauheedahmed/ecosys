<%@ Page language="c#" Inherits="WebApplication2.frmOrgLocSEProcs" CodeFile="frmOrgLocSEProcs.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->

<form id=frmResourcesInfo method=post runat="server">
<div id="headerSection" >
<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
<h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
<h2><asp:label id=lblLoc runat="server" ></asp:label></h2>
<h2><asp:label id=lblService runat="server" ></asp:label></h2>
<h2><asp:label id=lblProject runat="server" ></asp:label></h2>
<h2><asp:label id=lblTask runat="server" ></asp:label></h2>
<asp:label id=lblContents1 runat="server" ></asp:label>
<p><asp:button id=btnBack runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
<asp:button id="btnCancel" runat="server" Visible="False" Text="Cancel" onclick="btnAdd_Click"></asp:button></p>
</div>
<asp:datagrid id=DataGrid1 runat="server" ForeColor="Navy" BorderStyle="None" 
    HorizontalAlign="Left" AutoGenerateColumns="False" 
    onitemcommand="DataGrid1_ItemCommand" >
<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White">
</ItemStyle>

<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal">
</HeaderStyle>

<Columns>
<asp:BoundColumn  DataField="Id" Visible="false" ReadOnly="True">

</asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Procedures">

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>

<asp:TemplateColumn HeaderText="Inputs">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</HeaderStyle>

<ItemTemplate>
		<asp:button id="btnStaff" runat="server" Enabled="False" Text="Staff" CommandName="Staff"></asp:button>
		<asp:button id="btnOther" runat="server" Enabled="False" Text="Goods and Services" CommandName="Other"></asp:button>
						
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="StaffFlag" Visible="false" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="ResFlag" Visible="false" ReadOnly="True"></asp:BoundColumn>
<asp:TemplateColumn HeaderText="Performance" visible="false">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</HeaderStyle>

<ItemTemplate>
<asp:button id="btnOutputs" runat="server" Text="Outputs" CommandName="Outputs"></asp:button>
<asp:button id="btnClients" runat="server" Text="Clients" CommandName="Clients"></asp:button>
	
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="ResOutputsFlag" Visible="false" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="ClientsFlag" Visible="false" ReadOnly="True"></asp:BoundColumn>
</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
</asp:datagrid>
<asp:datagrid id="DataGrid2" runat="server" BorderStyle="None" 
            HorizontalAlign="Left" AutoGenerateColumns="False" 
            onitemcommand="DataGrid2_ItemCommand">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					
					<asp:BoundColumn DataField="Name" HeaderText="Process">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Budget" >
						<ItemTemplate>
							<asp:TextBox id="txtBud" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn visible="false" >
						<ItemTemplate>
                             <asp:Button ID="btnCl" runat="server" Text="Clients" CommandName="Clients" ></asp:button>
                        </ItemTemplate>
					</asp:TemplateColumn>
					 <asp:BoundColumn Visible="False" DataField="BudFlag" ReadOnly="True"></asp:BoundColumn>	
                    	
				</Columns>
			</asp:datagrid>
</form>
<!--#include file="inc/footer.aspx"-->
</HTML>
