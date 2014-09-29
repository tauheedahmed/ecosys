<%@ Page language="c#" Inherits="WebApplication2.frmBudgets" CodeFile="frmBudgets.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblTitle" runat="server"></asp:label></h1>
		<h2><asp:label id="lblOrg" runat="server"></asp:label></h2>
		<h2><asp:label id="lblBd" runat="server"></asp:label></h2>
		<asp:label id="lblContents" runat="server" ></asp:label>
		<p><asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server"  onclick="btnAdd_Click" > </asp:button>
		<asp:button id="btnReopen" runat="server"  onclick="btnReopen_Click"></asp:button>
			</p>	
		</div>
		
		<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" 
            AutoGenerateColumns="False" onitemcommand="DataGrid1_ItemCommand" >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" >
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnSOFU" runat="server"  Text="Update" CausesValidation="false" CommandName="Update"></asp:Button>
							<asp:Button id="btnDistS" runat="server" Text="Distribution" CausesValidation="false" CommandName="Orgs"></asp:Button>
							<asp:Button id="btnER" Visible="False" runat="server" Text="Exchange Rates" CausesValidation="false" CommandName="ERs"></asp:Button>
							<asp:Button id="btnC" runat="server" Text="Controls" CausesValidation="false" CommandName="Controls"></asp:Button>
							<asp:Button id="btnCloseS" runat="server"  Text="Close" CausesValidation="false" CommandName="Close"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:DataGrid>
			<asp:datagrid id="DataGrid2" runat="server" HorizontalAlign="Left" 
            AutoGenerateColumns="False" onitemcommand="DataGrid2_ItemCommand"  >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn  DataField="SOF" HeaderText="Source of Funds" >
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="FY" HeaderText="FY" >
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Amount"  Visible="False" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Amount">
						<ItemTemplate>
							<asp:TextBox id="txtAmount" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
                                <asp:Button id="btnDist" runat="server" Text="Distribution" CausesValidation="false" CommandName="Orgs"></asp:Button>
								<asp:Button id="btnER" Visible="False" runat="server" Text="Exchange Rates" CausesValidation="false" CommandName="ERs"></asp:Button>
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Stage">
						<ItemTemplate>
						    <asp:dropdownlist id="lstStatus"  runat="server"  >
                            <asp:ListItem  Value="0">Formulation</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1">Open</asp:ListItem></asp:dropdownlist>
                            <asp:Button id="btnClose" runat="server"  Text="Close" CausesValidation="false" CommandName="Close"></asp:Button>
                        </ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="StatusId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgCurrId" Visible="False" ReadOnly="True"></asp:BoundColumn>
				<asp:BoundColumn DataField="CurrCode" Visible="False" ReadOnly="True"></asp:BoundColumn>
			</Columns>
			</asp:DataGrid>
			</form>
	<!--#include file="inc/footer.aspx"-->
</HTML>
