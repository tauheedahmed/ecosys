<%@ Page language="c#" Inherits="WebApplication2.frmProcSReq" CodeFile="frmProcSReq.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
<form id="frmResourcesInfo" method="post" runat="server">
<div id="headerSection" >
<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
<h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
<h2><asp:label id=lblLoc runat="server" ></asp:label></h2>
<h2><asp:label id=lblService runat="server" ></asp:label></h2>
<h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
<h2><asp:label id=lblProject runat="server" ></asp:label></h2>
<h2><asp:label id=lblTask runat="server" ></asp:label></h2>

<h2><asp:label id=lblRole runat="server" ></asp:label></h2>
<asp:label id=lblContents runat="server" ></asp:label>
<asp:label id=lblContents1 runat="server" ></asp:label>
<h3><asp:label id=lblMsg runat="server" ></asp:label></h3>
<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
<asp:button id="btnAddNew" runat="server" Text="Assign Existing Staff" onclick="btnAddNew_Click"></asp:button>
<asp:button id="btnAdd" runat="server" Text="Identify Staffing Need" onclick="btnAdd_Click"></asp:button>
</p>
</div>
<div>
<asp:datagrid id="DataGrid1" runat="server" ForeColor="Navy" BorderStyle="None" Height="30px" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleName" HeaderText="Staffing">
						<ItemStyle HorizontalAlign="Left" ></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Planned Input">
						<ItemTemplate>
							<asp:TextBox id="txtPlan" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
                            <asp:dropdownlist id="lstTimeMeasure" runat="server" >
				                <asp:ListItem Value="0">Year(s)</asp:ListItem>
				                <asp:ListItem Value="1">Month(s)</asp:ListItem>
				                <asp:ListItem Value="2" Selected="True">Week(s)</asp:ListItem>
				                <asp:ListItem Value="3">Day(s)</asp:ListItem>
				                <asp:ListItem Value="4">Hour(s)</asp:ListItem>
			                </asp:dropdownlist></ItemTemplate>        
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Fund Charged">
						<ItemTemplate>
							<asp:dropdownlist id="lstFunds" runat="server" >
                                <asp:ListItem>UnIdentified</asp:ListItem>
                            </asp:dropdownlist>
						</ItemTemplate> 
					</asp:TemplateColumn>
										
					<asp:TemplateColumn Visible="false">
						<ItemTemplate>
							<asp:button id="btnTRS" runat="server" Text="Timesheet Approvals" 
                                BackColor="Teal" CommandName="TRS" ForeColor="White"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnDel" runat="server" Text="Delete" BackColor="Maroon" ForeColor="White" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:BoundColumn Visible="False" DataField="Qty" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="TimeMeasure" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="StaffType" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PayGrade" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Backup" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="FundsId" ReadOnly="True"></asp:BoundColumn>	
					<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>	
									
			
					
				</Columns>
			</asp:datagrid></div>
			
			
			<asp:datagrid id="DataGrid2" runat="server" ForeColor="Navy" BorderStyle="None" Height="30px" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle  ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Role" HeaderText="Roles">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Process" HeaderText="Process">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="PeopleName" HeaderText="Staffing">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Planned Input">
						<ItemTemplate>
							<asp:TextBox id="txtPlan" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
                            <asp:dropdownlist id="lstTimeMeasure" runat="server" >
				                <asp:ListItem Value="0">Year(s)</asp:ListItem>
				                <asp:ListItem Value="1">Month(s)</asp:ListItem>
				                <asp:ListItem Value="2" Selected="True">Week(s)</asp:ListItem>
				                <asp:ListItem Value="3">Day(s)</asp:ListItem>
				                <asp:ListItem Value="4">Hour(s)</asp:ListItem>
			                </asp:dropdownlist>
			                <asp:TextBox id="txtPrice" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
                                <asp:TextBox id="txtBudAmt" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
			            </ItemTemplate>        
					</asp:TemplateColumn>
					
					<asp:TemplateColumn visible="False">
						<ItemTemplate>
							<asp:button id="btnBud" runat="server" Text="Budget" CommandName="Budget"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnDel" runat="server" Text="Delete" BackColor="Maroon" ForeColor="White" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Qty" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="TimeMeasure" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Price" ReadOnly="True"></asp:BoundColumn>	
					<asp:BoundColumn Visible="False" DataField="BudAmt" ReadOnly="True"></asp:BoundColumn>						
				</Columns>
			</asp:datagrid></div>
			<div>
<asp:datagrid id="DataGrid3" runat="server" Visible="False" ForeColor="Navy" BorderStyle="None" 
                    Height="30px" HorizontalAlign="Left" AutoGenerateColumns="False" 
                    onitemcommand="DataGrid3_ItemCommand">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" HeaderText="Appointing Organizations">
						<ItemStyle HorizontalAlign="Left" ></ItemStyle>
					</asp:BoundColumn>
					
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnSelect" runat="server" Text="Select" 
                                CommandName="Select" ></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					</Columns>
			</asp:datagrid></div>
			
			</form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
