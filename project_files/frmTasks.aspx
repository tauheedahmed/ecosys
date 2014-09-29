

<%@ Page language="c#" Inherits="WebApplication2.frmTasks" CodeFile="frmTasks.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmResourcesInfo" method="post" runat="server">
		<div id="headerSection" >
			
		<h1><asp:label id=lblMgr runat="server"></asp:label></h1>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLocation runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
        <h2><asp:label id="lblProj" runat="server" ></asp:label></h2>
        <asp:label id=lblContents1 runat="server" ></asp:label>
			
		<asp:button id="btnBd" runat="server" Text="Change Budget" BackColor="Navy" onclick="btnBd_Click"></asp:button>
			
		<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
		</div>
                <asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" HorizontalAlign="Left" AutoGenerateColumns="False">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn  DataField="Id"  Visible="False" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Tasks"></asp:BoundColumn>
					
					<asp:TemplateColumn HeaderText="Start Date">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:TextBox ID="txtStartDate" runat="server"  ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn> 
					<asp:TemplateColumn HeaderText="Check if Actual">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
                            
						    <asp:CheckBox ID="cbxStartStatus" runat="server" />                            
						</ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:TemplateColumn HeaderText="End Date">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
                            <asp:TextBox ID="txtEndDate" runat="server" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn> 
					<asp:TemplateColumn HeaderText="Check if Actual">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
                            
						    <asp:CheckBox ID="cbxEndStatus" runat="server" />
                            
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
							<asp:button id="btnTS" runat="server" Text="Timesheet" CommandName="TS"></asp:button>
							<asp:button id="btnClients" runat="server" Text="Clients" CommandName="Clients"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn  DataField="ProjOLPSEPFlag" ReadOnly="True" Visible="False" ></asp:BoundColumn>
					
				</Columns>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
