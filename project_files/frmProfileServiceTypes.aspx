<%@ Page language="c#" Inherits="WebApplication2.frmProfileServiceTypes" CodeFile="frmProfileServiceTypes.aspx.cs" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
    <form id="frmEmergencyProcedures" method="post" runat="server">
		
		<div id="headerSection">
		    <h1><asp:label id="lblTitle" runat="server" 
                    meta:resourcekey="Label1Resource1" ></asp:label></h1>
		    <h2><asp:label id="lblBusProfiles" Text="Business Profiles" runat="server" ></asp:label></h2>
		    <p><asp:label id="lblContent1" runat="server"  ></asp:label>
		    <asp:label id="lblContent2" runat="server" ></asp:label>
		    <asp:label id="lblContent3" runat="server"></asp:label>
		    <asp:Label Text="Click on the buttons below to generate reports"
                    + " reflecting the above business model as prepared to date."></asp:Label></p>
		   
		    <asp:button id="btnExit" runat="server" Text="Return to Previous Form" 
                onclick="btnExit_Click" ></asp:button><asp:button id="btnAdd" runat="server" Text="Add Services" CommandName="Add" 
                onclick="btnAdd_Click"></asp:button>
		</div>
		
		
		
		<div id="gridSection1">
		    
			    <asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" >
				    <AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				    <ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				    <HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				    <FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				    <Columns>
					    <asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					    <asp:TemplateColumn >
						    <ItemTemplate>
							    <asp:TextBox id="txtSeq" runat="server" ForeColor="Navy" BackColor="White" 
                                    BorderStyle="Solid" BorderColor="Navy" Height="24px" Width="31px">
                                    </asp:TextBox>
						    </ItemTemplate>
					    </asp:TemplateColumn>
					    <asp:BoundColumn Visible="False" DataField="ServiceTypesId" ReadOnly="True"></asp:BoundColumn>
					    <asp:BoundColumn DataField="Name" HeaderText="Services">
						    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
						    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					    </asp:BoundColumn>
					    <asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
						    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
						    </asp:BoundColumn>
					    <asp:TemplateColumn>
						    <ItemTemplate>
							    <asp:button id="btnDeliver" runat="server" Text="Deliverables" CommandName="Deliver"></asp:button>
							    <asp:button id="btnRemove" runat="server" ForeColor="White" BackColor="Maroon" 
                                   Text="Remove" CommandName="Remove" ></asp:button>
						    </ItemTemplate>
					    </asp:TemplateColumn>
					    <asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
				    </Columns>
			    </asp:datagrid>
			</div>
		</form>
    <p><!--#include file="inc/footer.aspx"--></p>
</HTML>
