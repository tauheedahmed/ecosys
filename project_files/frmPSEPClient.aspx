<%@ Page language="c#" Inherits="WebApplication2.frmPSEPClient" CodeFile="frmPSEPClient.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
    <form id="frmEmergencyProcedures" method="post" runat="server">
    
    <div id="headerSection" >
		<h1><asp:label id="lblTitle" Text="" runat="server" ></asp:label></h1>
		<h2><b><asp:label id="lblProfilesName" Text="" runat="server" ></asp:label></b></h2>
		<h2><b><asp:label id="lblServiceName" Text="" runat="server" ></asp:label></b></h2>
		<h2><b><asp:label id="lblDeliverableName" Text="" runat="server" ></asp:label></b></h2>
		<h2><b><asp:label id="lblProcessName" Text="" runat="server" ></asp:label></b></h2>
		<h1><asp:Label id="lblOrg" runat="server" ></asp:Label ></h1>
		<h2><asp:Label id="lblBd" runat="server" ></asp:Label></h2>
		<h2><asp:Label id="lblLoc" runat="server" ></asp:Label></h2>
		<h2><asp:Label id="lblService" runat="server" ></asp:Label></h2>
		<h2><asp:Label id="lblProject" runat="server" ></asp:Label></h2>
		<p><asp:label id="lblContents1" runat="server" ></asp:label>
		<asp:label id="lblContents2" runat="server" ></asp:label></p>
		<asp:button id="btnExit" runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAddO" runat="server" CommandName="AddO" 
        Text="Add" onclick="btnAddO_Click1" ></asp:button>
        <asp:button id="btnAddO1" runat="server" CommandName="AddO1"
        Text="Identify New Client Type" onclick="btnAddO1_Click" Visible="False" ></asp:button>
        
		
    </div>
    <div id="gridSection">        
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ClientsName" HeaderText="Client Types">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Impact">
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" BorderStyle="Solid" BorderColor="Navy" 
                                Height="22px" TextMode="MultiLine" Width="300px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnStandards" runat="server" Text="Business Impact"  CommandName="Standards"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnDeliverables"  Visible="false" runat="server" Text="Deliverables" CommandName="Deliverables"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" ForeColor="White" BackColor="Maroon" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>

				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<asp:datagrid id="DataGrid2" Visible="false" runat="server" AutoGenerateColumns="False" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" AllowSorting="True" ForeColor="#A7D7CC" GridLines="None">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle ></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Client Types">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select" >
						<ItemTemplate>
						<asp:CheckBox id="cbxSel" runat="server" ></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				</asp:datagrid>		

		<div><asp:label id="lblnewClient" Text="Enter name of this client type"  runat="server" ></asp:label>
		<asp:TextBox id="txtnewClient" runat="server" visible="false" ></asp:TextBox>
		<asp:button id="btnAdd" runat="server" 
        Text="Add" onclick="btnAdd_Click" visible="false" ></asp:button>
        <asp:button id="btnAddProjectClient" runat="server" 
        Text="Add Project Client" onclick="btnAddProjectClient_Click" visible="false" ></asp:button>
        
        </div>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
