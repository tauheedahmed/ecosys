<%@ Page language="c#" Inherits="WebApplication2.frmPSEventsInd" CodeFile="frmPSEventsInd.aspx.cs" %>
<!--#include file="inc/HeaderI.aspx"-->
		<form id="frmOrgResTypes" method="post" runat="server">
		
		<h1><asp:label id=lblMgr runat="server"></asp:label></h1>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        <h3><asp:label id=lblLocation runat="server" ></asp:label></h3>
        <h4><asp:label id=lblService runat="server" ></asp:label></h4>
        <h5><asp:label id=lblDel runat="server" ></asp:label></h5>
        <h2><asp:label id=lblProject runat="server" ></asp:label></h2>
        <h3><asp:label id=lblTask runat="server" ></asp:label></h3>
        <asp:label id=lblContents1 runat="server" ></asp:label>
        <asp:label id="lblContents2" runat="server" ></asp:label>
        
        <p><asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button>
		<asp:button id="btnStaff" runat="server" Text="Staff" onclick="btnStaff_Click"></asp:button><asp:button id="btnProcs" runat="server" Text="Procedures" onclick="btnProcs_Click"></asp:button>
		
		</p><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" Visible="False" >
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Reports">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="Button2" runat="server" Text="Timetable" CommandName="Timetable"></asp:button>
							<asp:button id="btnStaffP" runat="server" Text="Staff" CommandName="Staff"></asp:button>
							<asp:button id="Button1" runat="server" Text="Non-Staff Resources" CommandName="Res"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Update">
						<ItemTemplate>
							<asp:button id="btnUpd" runat="server" ForeColor="White" Height="25px" BorderStyle="None" BackColor="Teal" Text="Update" Font-Bold="True" Font-Size="Smaller" CommandName="Update"></asp:button>
							<asp:button id="btnTasks" runat="server" ForeColor="White" Height="25px" BorderStyle="None" BackColor="Teal" Text="Tasks" Font-Bold="True" Font-Size="Smaller" CommandName="Tasks"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			
			</form>
<!--#include file="inc/footer.aspx"-->
</HTML>
