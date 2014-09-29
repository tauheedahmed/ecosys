<%@ Page language="c#" Inherits="WebApplication2.frmServiceEvents" CodeFile="frmServiceEvents.aspx.cs" %>

<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="frmEmergencyProcedures" method="post" runat="server">
		<h1><asp:label id="lblTitle" Text="EcoSys: Service Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfilesName" runat="server" ></asp:label></h2>
		<h3><asp:label id="lblServiceName" runat="server" ></asp:label></h3>
			<p><asp:label id="lblContent1" runat="server" ></asp:label>
			<asp:label id="lblContent2" runat="server" ></asp:label>
			</p><asp:button id="btnExit" runat="server" Text="Return to Previous Form" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAddE" runat="server" Text="Add Deliverable" onclick="btnAddS_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" VerticalAlign="Top" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
			
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EventsId" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Seq No" >
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Height="24px" BorderColor="Navy" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="31px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Deliverables">
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
							<asp:button id="Button4" runat="server" BackColor="Maroon" ForeColor="White" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="OrgId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selection">
						<ItemTemplate >
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>			
			</form>
    <div id="footer">
    <p><!--#include file="inc/footer.aspx"--></p>
    </div>
</HTML>
