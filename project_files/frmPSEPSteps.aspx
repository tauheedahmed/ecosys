<%@ Page language="c#" Inherits="WebApplication2.frmPSEPSteps" CodeFile="frmPSEPSteps.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		    <h1><asp:Label ID="lblBM" runat="server" >EcoSys: Service Models</asp:Label></h1>
			<p><asp:label id="lblContents2" runat="server" ></asp:label></p>
			<p><asp:label id="lblContents1" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="OK" onclick="btnBack_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add a Step" CommandName="Add" onclick="btnAdd_Click"></asp:button>
			<asp:button id="btnSignoff" runat="server"  Text="Save and Logoff" Visible="false" onclick="btnSignoff_Click"></asp:button>
			<asp:button id="Cancel" runat="server"  Text="Cancel" Visible="false" onclick="btnCancel_Click"></asp:button>
				</div>
				
			<asp:datagrid id="DataGrid1" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True" HeaderText="No">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Step No">
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Height="24px" BorderColor="Navy" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="31px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Processing Steps">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnUpdate" runat="server" Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:button id="Button1" runat="server" BackColor="Maroon" ForeColor="White" Text="Delete" CommandName="Delete"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			
			</form>
			</div>
			<!--#include file="inc/footer.aspx"-->
</HTML>
