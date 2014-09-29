<%@ Page language="c#" Inherits="WebApplication2.frmProjects" CodeFile="frmProjects.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		<div id="headerSection" >	
		<h2><asp:label id=lblMgr runat="server"></asp:label></h2>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        
        <h3><asp:label id="lblLoc"  runat="server" ></asp:label></h3>
		<h3><asp:label id="lblTask"  runat="server" ></asp:label></h3>
		<asp:button id="btnTask"  runat="server" onclick="btnTask_Click" 
                text="Change Task"></asp:button>
        <h3><asp:label id="lblTaskC" visible="false" runat="server">Change Task</asp:label></h3>
        <asp:dropdownlist id="lstTasks" Visible="false" runat="server" 
                AutoPostBack="True" onselectedindexchanged="lstTask_SelectedIndexChanged" ></asp:dropdownlist>
			
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
       <p> <asp:label id=lblContents1 runat="server" ></asp:label></p>
			<asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
            <asp:button id="btnAddNew" runat="server" onclick="btnAddNew_Click"></asp:button>
			<asp:button id="btnAddOth" runat="server" onclick="btnAddOth_Click"></asp:button>
			<asp:button id="btnDeAct" runat="server" onclick="btnAdd_Click"></asp:button>
			<p></div>
                <asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="PName" HeaderText="Name">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnProjects" runat="server"  Text="Status" CommandName="Status"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnSteps" runat="server" Text="Steps" CommandName="Steps"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn> 
					<asp:TemplateColumn HeaderText="Inputs">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnStaff" runat="server" Enabled="True" Text="Staff" CommandName="Staff"></asp:button>
							<asp:button id="btnOther" runat="server" Enabled="True" Text="Other" CommandName="Other"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
                            <asp:Button ID="btnCl" runat="server" Text="Clients" CommandName="Clients" ></asp:button>
                            <asp:Button ID="btnTT" runat="server" Text="Tasks" CommandName="Tasks" ></asp:button>
                            
                        </ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnDeActivate" runat="server" BackColor="Maroon" ForeColor="White" Text="De-Activate" CommandName="DeActivate"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ExtFlag" ReadOnly="True"></asp:BoundColumn>					
					
				</Columns>
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
					<asp:BoundColumn DataField="PName" HeaderText="Name">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="PSEPName" HeaderText="Process">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Budget" >
						<ItemTemplate>
							<asp:TextBox id="txtBud" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn visible="false">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnProjects" runat="server"  Text="Status" CommandName="Status"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn visible="false" >
						<ItemTemplate>
                            <asp:Button ID="btnTT" runat="server" Text="Sub-Tasks" CommandName="Tasks" ></asp:button>
                            <asp:Button ID="btnCl" runat="server" Text="Clients" CommandName="Clients" ></asp:button>
                        </ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn visible="false">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnDeActivate" runat="server" BackColor="Maroon" ForeColor="White" Text="De-Activate" CommandName="DeActivate"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ProjectsPeopleId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn Visible="False" DataField="PSEPId" ReadOnly="True"></asp:BoundColumn>
                    <asp:BoundColumn Visible="False" DataField="BudFlag" ReadOnly="True"></asp:BoundColumn>		
				</Columns>
			</asp:datagrid>
            </p>
            
        </form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
