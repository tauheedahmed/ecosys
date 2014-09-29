<%@ Page language="c#" Inherits="WebApplication2.frmInventory" CodeFile="frmInventory.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
    <div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">        	
		
		<div id="headerSection" >
		<h1><asp:label id=lblTitle runat="server" Text="Inventory" ></asp:label></h1>
		<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLoc runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblDel runat="server" ></asp:label></h2>
        <h2><asp:label id=lblProject runat="server" ></asp:label></h2>
        <h2> <asp:label id="lblGS" runat="server" ></asp:label></h2>
        <h2><asp:label id=lblTask runat="server" ></asp:label></h2>
        </div>
       <asp:label id="lblContents1" runat="server" ></asp:label>
        <p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
        <asp:button id="btnAdd" runat="server" Text="Add" onclick="btnAdd_Click"></asp:button></p>

		
			<div Id="gridSection">
			<asp:datagrid id="DataGrid1" runat="server" HorizontalAlign="Left" AutoGenerateColumns="False" >
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle><Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="ItemName" HeaderText="Item"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" ReadOnly="True" HeaderText="Organization"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" HeaderText="Location"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SubLocation" HeaderText="Room"></asp:BoundColumn>
					
					<asp:BoundColumn DataField="Status" ReadOnly="True" HeaderText="Status">
					</asp:BoundColumn>
					<asp:TemplateColumn  >
						<ItemTemplate>
							<asp:Button id="btnSelect" runat="server" Text="Select" CommandName="Select" CausesValidation="false"></asp:Button>
						
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							
						<asp:Button id="btnUpdate" runat="server" ForeColor="White" BackColor="Teal" BorderStyle="None"  Text="Update" CommandName="Update" CausesValidation="false"></asp:Button>
							<asp:Button id="btnDelete" runat="server" ForeColor="White" BackColor="Maroon" BorderStyle="None"    Text="Delete" CommandName="Delete" CausesValidation="false"></asp:Button>
							
						</ItemTemplate>
						<EditItemTemplate>
							&nbsp;
						</EditItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn visible="false" HeaderText="Check Selections">
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="OrgId" ReadOnly="True">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				</asp:datagrid></div>
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
