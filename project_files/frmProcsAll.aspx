<%@ Page language="c#" Inherits="WebApplication2.frmProcsAll" CodeFile="frmProcsAll.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
		<<form id="frmResourcesInfo" method="post" runat="server">
		<h1><asp:label id="Label1" Text="EcoSys:  Business Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfilesName" Text="Business Profiles" runat="server" ></asp:label></h2>
		<h3><asp:label id="lblServiceName" Text="Service Name" runat="server" ></asp:label></h3>
		<h4><asp:label id="lblDeliverableName" Text="Deliverable Name" runat="server" ></asp:label></h4>
		<p><asp:label id="lblContent" runat="server" ></asp:label></p>
		<asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
		<asp:button id="btnMoreProcs" runat="server" Text="More Processes..." onclick="btnMoreProcs_Click"></asp:button>
		<asp:button id="btnAddProcs" runat="server" Text="Identify New Process" onclick="btnAddProcs_Click"></asp:button>
		<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Name">
						
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections">
					<HeaderStyle Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></form>
			<!--#include file="inc/footer.aspx"-->
    </div>
</HTML>
