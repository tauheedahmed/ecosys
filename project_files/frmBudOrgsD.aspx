u<%@ Page language="c#" Inherits="WebApplication2.frmBudOrgsD" CodeFile="frmBudOrgsD.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblTitle" runat="server"></asp:label></h1>
		<h2><asp:label id="lblOrg" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblBud" runat="server" ></asp:label></h2>
		<h3><asp:label id="lblBudDist" runat="server" ></asp:label></h3>
		<h3><asp:label id="lblBudAmt" runat="server" ></asp:label></h3>
		<h3><asp:label id="lblReq" runat="server" ></asp:label></h3>
		<h3><asp:label id="lblDiff" runat="server" ></asp:label></h3>
		<p><asp:label id="lblContents" runat="server"></asp:label></p>
		<asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
		<asp:textbox id="txtDesc" runat="server" BorderStyle="Solid" BorderColor="Navy" Height="48px"  TextMode="MultiLine" Visible="False"></asp:textbox></div>
			<asp:datagrid id="DataGrid1" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False" DESIGNTIMEDRAGDROP="7">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" HeaderText="Organization">
						<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Original Budget" >
						<ItemTemplate>
							<asp:TextBox id="txtOrig" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" Width="87px" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="OrigAmt" ReadOnly="True" HeaderText="Original Budget" Visible="false">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CurrAmt" ReadOnly="True" HeaderText="Current Budget">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="+/- Budget">
						<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center"></ItemStyle>
						<ItemTemplate>
							<asp:TextBox id="txtCurr" runat="server" Width="50px" BorderStyle="Solid" BorderColor="Navy" ></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Req" visible="false" HeaderText="Budget Request">
						<HeaderStyle HorizontalAlign="Right"></HeaderStyle>
						<ItemStyle HorizontalAlign="Right"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnRevs" runat="server" Text="Audit Trail" CommandName="Revs" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="btnOverride" runat="server"  Text="Service Distribution" CommandName="Tasks" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn HeaderText="Performance Targets">
						<ItemTemplate>
							<asp:Button id="btnOutputs" runat="server" Text="Outputs" CausesValidation="false" CommandName="Outputs"></asp:Button>
						<asp:Button id="btnClients" runat="server" Text="Clients" CausesValidation="false" CommandName="Clients"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:Button id="Button1" runat="server" Text="Remove" CausesValidation="false" CommandName="Remove"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="BDOrgId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
