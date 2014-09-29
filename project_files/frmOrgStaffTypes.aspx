<%@ Page language="c#" Inherits="WebApplication2.frmOrgStaffTypes" CodeFile="frmOrgStaffTypes.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<asp:label id="lblContents" runat="server" ></asp:label>
		<p><asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server" Text="Add" CommandName="Add" onclick="btnAdd_Click"></asp:button></p>
		
			<asp:datagrid id="DataGrid1" runat="server" GridLines="None" ForeColor="Teal" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="White" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Appointment Types">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnApts" runat="server" Text="Appointments" CommandName="Appointments"></asp:Button>
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn >
						<ItemTemplate>
							<asp:Button id="Button2" runat="server" Text="Details" CommandName="Details"></asp:Button>
						    <asp:Button id="Button1" runat="server" Text="Pay Grades" CommandName="PayGrades"></asp:Button>
							<asp:Button id="btnRemove" runat="server" Text="Remove" CommandName="Remove"></asp:Button>

						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="StaffTypeId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CurrName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="SalaryPeriod" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CurrId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			
			</form>
<!--#include file="inc/footer.aspx"-->
</HTML>
