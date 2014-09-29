<%@ Page language="c#" Inherits="WebApplication2.frmPayGrades" CodeFile="frmPayGrades.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		
			<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblFunction" runat="server" ></asp:label></h2>
			
			<asp:button id="btnOK" runat="server" Text="Exit" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server"  AutoGenerateColumns="False" HorizontalAlign="Left">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="Small" Font-Bold="True" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"> </asp:BoundColumn>
					<asp:TemplateColumn HeaderText="No.">
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Width="31px" Height="24px" ForeColor="Navy" BackColor="White" BorderStyle="Solid" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Pay Grades">
						<HeaderStyle Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnDelete" runat="server" Text="Delete" ForeColor="White" BackColor="Maroon" CommandName="Delete" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
