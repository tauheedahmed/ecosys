<%@ Page language="c#" Inherits="WebApplication2.frmProcs" CodeFile="frmProcs.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="frmEmergencyProcedures" method="post" runat="server">
		<h1><asp:label id="Label1" Text="Service Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblServiceName" Text="Service Name" runat="server" ></asp:label></h2>
		<p><asp:label id="lblContents2" runat="server" ></asp:label></p>
        <asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
        <asp:button id="btnAdd" runat="server" Text="Add a Process" CommandName="Add" onclick="btnAdd_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn   DataField="Id" Visible="False" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Processes">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="Button3" runat="server" Text="Update" CommandName="Update"></asp:button>
							<asp:button id="Button4" runat="server" Text="Process Steps" CommandName="Steps"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Inputs">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnStaff" runat="server" Text="Staff" CommandName="Staff"></asp:button>
							<asp:button id="btnServices" runat="server" Text="Services" CommandName="Services"></asp:button>
							<asp:button id="btnOther" runat="server" Text="Goods" CommandName="Other"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Outputs" Visible="False">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnServicesO" runat="server" Text="Services" CommandName="OServices"></asp:button>
							<asp:button id="btnOtherO" runat="server" Text="Goods" CommandName="OOther"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button6" runat="server" ForeColor="White" BackColor="Maroon" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid></form>
			
			<!--#include file="inc/footer.aspx"-->
    </div>
</HTML>
