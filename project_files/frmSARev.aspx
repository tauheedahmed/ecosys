<%@ Page language="c#" Inherits="WebApplication2.frmSARev" CodeFile="frmSARev.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblName" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblAptType" runat="server"></asp:label></h2>            
		<h2><asp:label id="lblContent1" runat="server" ></asp:label></h2> 
            <p><asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
            <asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button></p>
            <p></p>
		
		</div>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" >
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="StartDate" HeaderText="Start Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="EndDate" HeaderText="End Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="PayGradeTitle" HeaderText="Level"></asp:BoundColumn>
					<asp:BoundColumn DataField="Salary" HeaderText="Salary"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="StartDate" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EndDate" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="OrgSTPayGradesId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
					</asp:datagrid>
					
					</form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
