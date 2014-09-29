<%@ Page language="c#" Inherits="WebApplication2.frmOrgLocServices" CodeFile="frmOrgLocServices.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
			<h3><asp:label id="lblOrg"  runat="server" ></asp:label></h3>
			<h3><asp:label id="lblBd"  runat="server" ></asp:label></h3>
			           
			<h3><asp:label id="lblLoc"  runat="server" ></asp:label></h3>
			<asp:button id="btnLoc"  runat="server" onclick="btnLoc_Click" 
                text="Change Location"></asp:button>
            <h3><asp:label id="lblLocC" visible="false" runat="server">Change Location</asp:label></h3>
       
			<asp:dropdownlist id="lstLoc" Visible="false" runat="server" 
                AutoPostBack="True" onselectedindexchanged="lstLoc_SelectedIndexChanged" ></asp:dropdownlist>
			
			<p><asp:label id="lblContents1" runat="server"  ></asp:label>
			</p>
			<p><asp:button id="btnBack" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
			
			<asp:button id="btnAdd" runat="server" Text="Show All Services" Visible="False" onclick="btnAdd_Click"></asp:button> </p>
            <asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False" >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Budget" >
						<ItemTemplate>
							<asp:TextBox id="txtBud" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:TemplateColumn >
						<HeaderStyle HorizontalAlign="Center"  ></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnProjects" runat="server" Text="Timetables" CommandName="Projects"></asp:button>
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn >
						<HeaderStyle HorizontalAlign="Center"  ></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnProcess" runat="server" Text="Resources" CommandName="Procs"></asp:button>
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn Visible="False">
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" ForeColor="White" Text="Remove" BackColor="Maroon" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Name" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False"  DataField="PSTId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PJName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PJNameS" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn  Visible="False"  DataField="BudAmt" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn  Visible="False" DataField="BudOLServicesId" ReadOnly="True"></asp:BoundColumn>
					</Columns>
			</asp:datagrid>
			<asp:datagrid id="DataGrid2" runat="server" HorizontalAlign="Left" 
                AutoGenerateColumns="False" onitemcommand="DataGrid2_ItemCommand">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:TemplateColumn >
						<HeaderStyle HorizontalAlign="Center"  ></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnProjects" runat="server"  CommandName="Projects"></asp:button></ItemTemplate>
						
					</asp:TemplateColumn>
					<asp:TemplateColumn Visible="false" >
						<HeaderStyle HorizontalAlign="Center"  ></HeaderStyle>
						<ItemTemplate>
						    <asp:button id="btnProcess" runat="server" CommandName="Procs"></asp:button>
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn Visible="False">
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" ForeColor="White" Text="Remove" BackColor="Maroon" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="PSTId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProjName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProjNameS" ReadOnly="True"></asp:BoundColumn></Columns>
			</asp:datagrid></form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
