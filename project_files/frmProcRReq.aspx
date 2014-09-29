<%@ Page language="c#" Inherits="WebApplication2.frmProcRReq" CodeFile="frmProcRReq.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
<FORM id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLoc runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblDel runat="server" ></asp:label></h2>
        <h2><asp:label id=lblProject runat="server" ></asp:label></h2>
        <h2> <asp:label id="lblGS" runat="server" ></asp:label></h2>
        <h2><asp:label id=lblTask runat="server" ></asp:label></h2>
        </div>
        
       <asp:label id="lblContents1" runat="server" ></asp:label>
        <p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click" 
                style="height: 26px"></asp:button>
        <asp:button id="btnAddExisting" runat="server"  onclick="btnAddExisting_Click1"></asp:button>
        <asp:button id="btnAddNew" runat="server"  onclick="btnAdd_Click"></asp:button></p>

			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ItemName" HeaderText="Item"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Qty">
						<ItemTemplate>
							<asp:TextBox id="txtQty" runat="server" BorderStyle="Solid" Width="103px" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Price">
						<ItemTemplate>
							<asp:TextBox id="txtPrice" runat="server" BorderStyle="Solid" Width="103px" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Cost"></asp:TemplateColumn>
					<asp:BoundColumn DataField="Qty" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Price" ReadOnly="True"></asp:BoundColumn>
					
					<asp:BoundColumn DataField="OrgName" ReadOnly="True" HeaderText="Organization">
						
					</asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" HeaderText="Location"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SubLocation" HeaderText="Room"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Backup?">
						<ItemTemplate >
							<asp:CheckBox id="cbxBackup" runat="server" ></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Budget Charged">
						<ItemTemplate>
							<asp:dropdownlist id="lstBudgets" runat="server" >
                                <asp:ListItem>UnIdentified</asp:ListItem>
                            </asp:dropdownlist>
						</ItemTemplate> 
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnPay" runat="server" Text="Payment Approvals" CommandName="Pay"></asp:button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn >
						<ItemTemplate>
							<asp:Button id="btnDelete" runat="server" Text="Delete" CausesValidation="false" CommandName="Delete"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="BackupFlag" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="BudgetsId" ></asp:BoundColumn>					
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			</FORM>
			<!--#include file="inc/footer.aspx"-->
</HTML>
