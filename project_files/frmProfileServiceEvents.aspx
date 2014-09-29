<%@ Page language="c#" Inherits="WebApplication2.frmProfileServiceEvents" CodeFile="frmProfileServiceEvents.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="frmEmergencyProcedures" method="post" runat="server">
		<h1><asp:label id="lblTitle" Text="Business Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfilesName" runat="server" ></asp:label></h2>
		<h3><asp:label id="lblServiceName" Text="Service Name" runat="server" ></asp:label></h3>
		<p><asp:label id="lblContent1" runat="server" ></asp:label>
			<asp:label id="lblContent2" runat="server" Text = "As next step, for each deliverable, click 
			on the button titled 'Processes' to identify the sequence of processes or 
                procedures that results in that deliverable." ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="Return to Previous Form" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAddE" runat="server" Text="Add Deliverable" onclick="btnAddS_Click"></asp:button>
			<asp:button id="btnAddP" runat="server" Text="Add Events Using Profiles" Visible="False" CommandName="Add" onclick="btnAddP_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle Wrap="False"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EventsId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Seq No">
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Height="24px" BorderColor="Navy" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="31px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Deliverables">
						<HeaderStyle Width="350px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnClients" runat="server" Text="Clients" CommandName="Clients"></asp:button>
		                        <asp:button id="btnProcs" runat="server" Text="Processes" CommandName="Procs"></asp:button>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
							
							<asp:button id="Button4" runat="server" ForeColor="White" BackColor="Maroon" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
    <div id="footer>
    <p><!--#include file="inc/footer.aspx"--></p>
    </div>
</HTML>
