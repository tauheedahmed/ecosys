<%@ Page language="c#" Inherits="WebApplication2.frmProcStaff" CodeFile="frmProcStaff.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->


<form id=frmEmergencyProcedures method=post runat="server">
<div id="headerSection" >
<h1><asp:label id=lblOrg runat="server"></asp:label></h1>
<h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
<h2><asp:label id=lblLoc runat="server" ></asp:label></h2>
<h2><asp:label id=lblService runat="server" ></asp:label></h2>
<h2><asp:label id=lblProject runat="server" ></asp:label></h2>
<h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
<h2><asp:label id=lblTask runat="server" ></asp:label></h2>

<h2><asp:label id=lblRole runat="server" ></asp:label></h2>

<asp:label id=lblContents1 runat="server" ></asp:label>
<p><asp:button id=btnExit runat="server" Text="OK" onclick="btnExit_Click"></asp:button>
    <asp:button id=btnCancel runat="server" Text="Cancel" onclick="btnCancel_Click" 
        Visible="False"></asp:button></p>
</div>
<asp:datagrid id=DataGrid1 runat="server" 
GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" 
BorderColor="#CC9966" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="RoleName" HeaderText="Staff Roles">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					
					<asp:TemplateColumn>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnStaff" runat="server" Text="Staffing" CommandName="Staff"></asp:button>
						    <asp:button id="btnDesc" runat="server" Text="Description" CommandName="Desc"></asp:button>
							</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			<div><p><asp:label id="lblDesc" runat="server" Visible="false" Text="Description" ></asp:label></p>
            <asp:textbox id="txtDesc" runat="server" visible="false" Width="30em" Height="83px" ForeColor="Navy" TextMode="MultiLine"></asp:textbox>
            </div>
			
			
			</FORM>
        <!--#include file="inc/footer.aspx"-->
</HTML>
