<%@ Page language="c#" Inherits="WebApplication2.frmServiceTypes" CodeFile="frmServiceTypes.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" >
<form id="frmResourcesInfo" method="post" runat="server">

	<div id="headerSection" >
	
	    <h1><asp:label id="lblTitle" Text="Service Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblTitle1" runat="server" ></asp:label></h2>
		<p><asp:label id="lblContents" runat="server" ></asp:label></p>
		<asp:button id="btnExit" runat="server" Text="OK" 
            onclick="btnCancel_Click"></asp:button><asp:button id="btnAddAll" Visible="false" runat="server" Text="Add a Service" onclick="btnAddAll_Click"></asp:button>
        </div>
           
		<div id="gridSection" >
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" 
                onitemcommand="DataGrid1_ItemCommand1" 
                onselectedindexchanged="DataGrid1_SelectedIndexChanged">
				<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BorderStyle="None" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True">
						<HeaderStyle Width="0px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Seq">
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Width="31px" Height="24px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Services">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:button id="btnProfile" runat="server" Text="Select" CommandName="Select"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnUpdate" runat="server" Text="Update" CommandName="Update"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnProcess" runat="server" Text="Processes" CommandName="Processes"></asp:button>
						    <asp:Button ID="btnDeliver" runat="server" CommandName="Supply" Text="Deliverables" />
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="ParentId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="QtyMeasuresId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProjName" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="ProjNameS" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="FunctionId" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Check Selections" Visible="false">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="HHFlag" ReadOnly="True"></asp:BoundColumn>
					
				</Columns>
			</asp:datagrid></div>
			<div id="reportSection" >
			<label Text="Reports" style="text-align:center;"
			<p><asp:Label id="lblSAction" runat="server" Text="Reports" 
                    style="text-align: center;" Font-Bold="True" Font-Size="Larger" ></asp:Label></p> 
			 <p><hr />
			<asp:button id="btnRpt1" runat="server" Text="Service Deliverables" 
            onclick="btnRpt1_Click"></asp:button>
			<asp:label id="lblProcs" runat="server" ></asp:label>	
			<asp:button id="btnRpt2" runat="server" Text="Business Processes by Service" onclick="btnRpt2_Click"></asp:button>
			<asp:label id="lblStaff" runat="server" ></asp:label>	
			<asp:button id="btnRpt3" runat="server" Text="Staffing Requirements" onclick="btnRpt3_Click"></asp:button>
			<asp:button id="btnRpt4" runat="server" Text="Good and Service Requirements" onclick="btnRpt4_Click"></asp:button>
			<asp:label id="blContent2" runat="server" ></asp:label>
            <asp:button id="btnRpt5" runat="server" Text="Outputs by Process" onclick="btnRpt5_Click" ></asp:button>
            <asp:button id="btnRpt6" runat="server" Text="Client Types" onclick="btnRpt6_Click" ></asp:button>
    </div>
			
			
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
