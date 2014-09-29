<%@ Page language="c#" Inherits="WebApplication2.frmMainStaff" CodeFile="frmMainStaff.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
            	
		<div id="maindiv" >
		<form id="frmEmergencyProcedures" method="post" runat="server">
			<div id="headerSection" > 
			<h1><asp:label id="lblPerson" runat="server" ></asp:label></h1>
			<h2><asp:label id="lblHead" runat="server" Text="Dashboard"></asp:label></h2>
            
			
			<p><asp:label id="lblContents" runat="server" ></asp:label></p>
			</div>
				<p></p>	
			<div>
			<div class="menutop" >
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			
			<asp:button id="btnProfile" runat="server" Text="Your Profile" 
                    onclick="btnProfile_Click"></asp:button>
                    <asp:button id="btnTS" runat="server" Text="Timesheets" onclick="btnTS_Click"></asp:button>
			<asp:button id="btnHH" runat="server" Text="Household Emergency Plan" onclick="btnHH_Click"></asp:button>
			
                    <asp:button id="btnUProfile" runat="server" Text="Update" Visible="False" onclick="btnUProfile_Click"></asp:button>
			<asp:button id="btnCProfile" runat="server" Text="Cancel" Visible="False" 
                    onclick="btnCProfile_Click"></asp:button>
			</div>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" 
                    Visible="False" CellPadding="1" CellSpacing="1" Font-Bold="False" 
                    Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
                    Font-Underline="False" GridLines="None" HorizontalAlign="Left" 
			 >
				<AlternatingItemStyle  BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" BackColor="Teal"
				 ></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="MgrName"  HeaderText="Organization"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" HeaderText="Location"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ServiceName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="EventName" HeaderText="Deliverable"></asp:BoundColumn>
					<asp:TemplateColumn>
					<ItemTemplate>
							<asp:Button id="Button2" runat="server" HorizontalAlign="Center"  Text="Select" CommandName="Select"></asp:Button>
						</ItemTemplate>
					    <FooterStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                            Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ProfileId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PSEId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PJName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="PJNameS" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			</div>
			
          
		    <h4><asp:label id="lblEmail" runat="server" Text="Email" Visible="False"></asp:label></h4>
			<asp:textbox id="txtEmail" Visible="False" runat="server" Height="24px" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="246px"></asp:textbox>
			<h4><asp:label id="lblCPhone" Visible="False" runat="server" Text="Cell Phone"></asp:label></h4>
			<asp:textbox id="txtCPhone" Visible="False" runat="server" Height="24px" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="246px"></asp:textbox>
			<h4><asp:label id="lblWPhone" Visible="False" runat="server" Text="Work Phone"></asp:label></h4>
			<asp:textbox id="txtWPhone" Visible="False" runat="server" Height="24px" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="246px"></asp:textbox>
			<h4><asp:label id="lblHPhone" Visible="False" runat="server" Text="Home Phone"></asp:label></h4>
			<asp:textbox id="txtHPhone" Visible="False" runat="server" Height="24px" BorderStyle="Solid" BackColor="White" ForeColor="Navy" Width="246px"></asp:textbox>
			
			<p><asp:label id="lblOrg" runat="server" ></asp:label></p>
			</form>
				<!--#include file="inc/footer.aspx"-->
</HTML>
