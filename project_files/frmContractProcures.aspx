<%@ Page language="c#" Inherits="WebApplication2.frmContractProcures" CodeFile="frmContractProcures.aspx.cs" %>
<!--#include file="inc/HeaderProc.aspx"-->
		<form id="frmEmergencyProcedures" method="post" runat="server">
		<h3><asp:label id="lblOrg" runat="server"></asp:label></h3>
		<h3><asp:label id="lblContract" runat="server" ></asp:label></h3>
		<h3><asp:Label ID="lblContractItem" runat="server" ></asp:Label></h3>
		<h3><asp:Label ID="lblCountryName" runat="server"></asp:Label></h3>
		<h3><asp:Label ID="lblStateName" runat="server" ></asp:Label></h3>
		<asp:label id="lblContents1" runat="server" ></asp:label>
		<asp:label id="lblContents2" visible="false" runat="server" ></asp:label>
		<p>
        <asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnAdd" runat="server" Text="Add" CommandName="Add" onclick="btnAdd_Click"></asp:button>
           
           
			<asp:datagrid id="GridProcureS" runat="server" AutoGenerateColumns="False" >
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal" 
				 ></HeaderStyle>
				<Columns> 
				
					<asp:BoundColumn DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" ReadOnly="True" HeaderText="Requesting Units">
                        <HeaderStyle  />
                    </asp:BoundColumn>
					<asp:BoundColumn DataField="Items" HeaderText="Services"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" ReadOnly="True" HeaderText="Delivery Location"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Quantity" Visible="False"></asp:TemplateColumn>
					<asp:BoundColumn DataField="Measure" HeaderText="Unit of Measure" Visible="False" ></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:TextBox id="txtCost" runat="server" BorderStyle="Solid" Width="103px" BorderColor="Navy"></asp:TextBox>
						   </ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:BoundColumn DataField="Cost" HeaderText="Cost" ></asp:BoundColumn>
					<asp:BoundColumn DataField="Qty" HeaderText="Quantity"></asp:BoundColumn>
					<asp:BoundColumn DataField="Price" HeaderText="Price"></asp:BoundColumn>
					
				</Columns>
			</asp:datagrid>
			<asp:datagrid id="GridProcure" runat="server" AutoGenerateColumns="False" 
                >
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" ReadOnly="True" HeaderText="Requesting Units"></asp:BoundColumn>
					<asp:BoundColumn DataField="Items" HeaderText="Goods and Other Resources"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" ReadOnly="True" HeaderText="Delivery Location"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Quantity">
						<ItemTemplate>
							<asp:TextBox id="txtQty" runat="server" BorderStyle="Solid" Width="103px" BorderColor="Navy"></asp:TextBox>
						   </ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Measure"  HeaderText="Unit of Measure"></asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:TextBox id="txtPrice" runat="server" BorderStyle="Solid" Width="103px" BorderColor="Navy"></asp:TextBox>
						   </ItemTemplate>
					</asp:TemplateColumn>
					
					<asp:BoundColumn DataField="Cost" HeaderText="Cost" ></asp:BoundColumn>
					<asp:BoundColumn DataField="Qty" HeaderText="Quantity"></asp:BoundColumn>
					<asp:BoundColumn DataField="Price" HeaderText="Price"></asp:BoundColumn>
					
				</Columns>
			</asp:datagrid>
			
			<asp:datagrid id="GridDeliver" runat="server" AutoGenerateColumns="False" 
                onitemcommand="GridDeliver_ItemCommand">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="OrgName" ReadOnly="True" HeaderText="Requesting Units"></asp:BoundColumn>
					<asp:BoundColumn DataField="LocName" ReadOnly="True" HeaderText="Availability"></asp:BoundColumn>
					<asp:BoundColumn DataField="Items" HeaderText="Type"></asp:BoundColumn>
					
					<asp:BoundColumn DataField="Qty" HeaderText="Quantity"></asp:BoundColumn>
					<asp:BoundColumn DataField="Measure" HeaderText="Unit of Measure"></asp:BoundColumn>
					<asp:BoundColumn DataField="Price" HeaderText="Price"></asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Comments"></asp:BoundColumn>
					
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnDetails" runat="server" Text="Details" CommandName="Details"  ></asp:Button>
							<asp:Button id="btnLocations" runat="server" Text="Countries" CommandName="CSCountries" CausesValidation="false"></asp:Button>
						
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:Button id="btnRemove" runat="server" ForeColor="White" BackColor="Maroon" Text="Remove" CommandName="Remove" CausesValidation="false"></asp:Button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="LocationsFlag" ReadOnly="True" Visible="false" ></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			
			
			<p><asp:Label ID="lblURL" runat="server" Visible="false"></asp:Label> </p> 
			<asp:TextBox ID="txtURL" runat="server" Visible="false" Width="244px"></asp:TextBox>
			
			<p><asp:Label ID="lblDesc" runat="server" Visible="false" Text="Please describe the nature of 
			the service or goods you are making available in the text box below"></asp:Label> </p> 
			<asp:TextBox ID="txtDesc" runat="server" visible="false" 
            TextMode="MultiLine" Width="573px" Height="62px" ></asp:TextBox>
			<p><asp:Label ID="lblLocs" runat="server" 
			Text="Please indicate if the above service is available at:" 
			Visible="False"></asp:Label> 
			<asp:RadioButtonList ID="rblLocs" runat="server" Visible="false">
                <asp:ListItem Value="Any">Anywhere</asp:ListItem>
                <asp:ListItem Value="Specified">Specified Places</asp:ListItem>
                </asp:RadioButtonList>   </p>
			
			<asp:datagrid id="DataGrid2" runat="server" AutoGenerateColumns="False" onitemcommand="DataGrid2_ItemCommand">
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle> 
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Countries">
                        <HeaderStyle BackColor="Teal" Font-Bold="true" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="White" />
                    </asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Entire Country" >
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" AutoPostBack="True" 
                                oncheckedchanged="cbxSel_CheckedChanged" />
							</ItemTemplate>
					</asp:TemplateColumn>	
					<asp:TemplateColumn>
					<HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
							<asp:Button ID="btnStates" runat="server" CommandName="States" />
							<asp:Button ID="btnLocs" Text="Locations" runat="server" CommandName="Locations" />
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
					<HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
							<asp:Button ID="btnRemove" CommandName="Remove" runat="server" 
                                BackColor="Maroon" ForeColor="White" Text="Remove" />
							</ItemTemplate>
					</asp:TemplateColumn>	
					<asp:BoundColumn Visible="False" DataField="StatesFlag" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="StateType" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CSCId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="LocsFlag" ReadOnly="True" ></asp:BoundColumn>		
						
				</Columns>
			</asp:datagrid>
			
			<asp:datagrid id="DataGrid3" runat="server" AutoGenerateColumns="False" >
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle> 
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Countries">
                        <HeaderStyle BackColor="Teal" Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="White" />
                    </asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select" >
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" />
							</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			
			<asp:datagrid id="DataGrid4" runat="server" AutoGenerateColumns="False" 
            onitemcommand="DataGrid4_ItemCommand">
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle> 
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="States">
                        <HeaderStyle BackColor="Teal" Font-Bold="true" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="White" />
                    </asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Entire State" >
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSelStates" runat="server" AutoPostBack="True" 
                                oncheckedchanged="cbxSelStates_CheckedChanged" />
							</ItemTemplate>
					</asp:TemplateColumn>	
					<asp:TemplateColumn>
					<HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
							<asp:Button ID="btnLocs" runat="server" CommandName="Locs" 
                                 />
							</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
					<HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
					<ItemTemplate>
							<asp:Button ID="btnRemove" CommandName="Remove" runat="server" 
                                BackColor="Maroon" ForeColor="White" Text="Remove" />
							</ItemTemplate>
					</asp:TemplateColumn>	
					<asp:BoundColumn Visible="False" DataField="LocsFlag" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="CSSId" ReadOnly="True"></asp:BoundColumn>		
				</Columns>
			</asp:datagrid>
			
			<asp:datagrid id="DataGrid5" runat="server" AutoGenerateColumns="False" >
            <SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle> 
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="States">
                        <HeaderStyle BackColor="Teal" Font-Bold="False" Font-Italic="False" 
                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                            ForeColor="White" />
                    </asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Select" >
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" />
							</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			
			</form>	
			<!--#include file="inc/footer.aspx"-->
</HTML>
