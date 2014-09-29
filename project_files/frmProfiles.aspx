<%@ Page language="c#" Inherits="WebApplication2.frmProfiles" CodeFile="frmProfiles.aspx.cs" %>
<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="frmEmergencyProcedures" method="post" runat="server">
		<h1><asp:label id="lblTitle" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfileName" runat="server"></asp:label></h2>
		<h2><asp:label id="lblTitle1" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblReports1" runat="server"></asp:label></h2>
		<p><asp:label id="lblContent1" runat="server" ></asp:label>
		<asp:label id="lblContent2" runat="server" ></asp:label>
		<asp:label id="lblContent3" runat="server" ></asp:label></p>
		<asp:button id="btnExit" runat="server" Text="Return to Previous Page" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnExit1" runat="server" visible="false" Text="OK" 
            onclick="btnExit1_Click"></asp:button>
		
		<asp:button id="btnAdd" runat="server" Text="Add Profiles" onclick="btnAdd_Click"></asp:button>
		<asp:button id="btnStartS" runat="server" Text="Emergency Resources for Households" ></asp:button>
	
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
<AlternatingItemStyle BackColor="#C7D7CC">
</AlternatingItemStyle>

<ItemStyle ForeColor="Navy" BackColor="White">
</ItemStyle>

<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal">
</HeaderStyle>

<FooterStyle ForeColor="#330099" BackColor="#FFFFCC">
</FooterStyle>

<Columns>
<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
<asp:BoundColumn DataField="Name" HeaderText="Profiles">

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn Visible="False" DataField="Visibility" ReadOnly="True"></asp:BoundColumn>
<asp:TemplateColumn >
<ItemStyle HorizontalAlign="Right" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
							<asp:Button id="Button1" runat="server" Text="Update" CommandName="Edit" CausesValidation="false" CommandArgument="Update"></asp:Button>
							
						
</ItemTemplate>

<EditItemTemplate>
							&nbsp;
						
</EditItemTemplate>
</asp:TemplateColumn>
    <asp:TemplateColumn>
    <ItemTemplate>
    <asp:Button id="btnServices" runat="server" Text="Select" CausesValidation="false" CommandName="Services"></asp:Button>
</ItemTemplate></asp:TemplateColumn>
<asp:TemplateColumn HeaderText="ResourceTypes">
<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Font-Bold="False" 
        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" 
        Font-Underline="False">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Top">
</ItemStyle>

<ItemTemplate>
<asp:Button id="btnParentRes" runat="server" Text="Parent Resource Types" CommandName="PRT" ></asp:Button>
						
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn Visible="False" DataField="PeopleId" ReadOnly="True"></asp:BoundColumn>
    <asp:TemplateColumn>
   <ItemTemplate>
   <asp:Button id="btnDeliverables" runat="server" Text="Deliverables" CausesValidation="false" CommandName="Deliverables"></asp:Button>
   <asp:Button id="btnProcesses" runat="server" Text="Processes" CausesValidation="false" CommandName="Processes"></asp:Button>  
   </ItemTemplate>
    </asp:TemplateColumn>
    <asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
    <asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True"></asp:BoundColumn>
    <asp:TemplateColumn HeaderText="Seq">
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" Width="31px" Height="24px" ForeColor="Navy" BorderStyle="Solid" BackColor="White" BorderColor="Navy"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
 
</Columns>
<PagerStyle HorizontalAlign="Center" ForeColor="#330099" BackColor="#FFFFCC">
</PagerStyle>
			</asp:datagrid>
			<div>
	        <asp:label id="lblRpt1" visible="false" runat="server"  ></asp:label>
		    <asp:button id="btnRpt1" visible="false" runat="server" Text="Service Deliverables" onclick="btnRpt1_Click" ></asp:button>
		    <asp:label id="lblProcs" visible="false" runat="server" ></asp:label>	
		    <asp:button id="btnRpt2" visible="false" runat="server" Text="Processing Steps" 
            onclick="btnRpt2_Click" ></asp:button>
		    <asp:label id="lblStaff" visible="false" runat="server"  ></asp:label>	
		    <asp:button id="btnRpt3" visible="false" runat="server" Text="Job Descriptions" 
            onclick="btnRpt3_Click" ></asp:button>
		    <asp:label id="lblOther" visible="false" runat="server"  ></asp:label>	
		    <asp:button id="btnRpt4" visible="false" runat="server" Text="Resource Requirements" 
            onclick="btnRpt4_Click" ></asp:button>
            <asp:button id="btnRpt6" visible="false" runat="server" 
            Text="Business Impact Analysis" onclick="btnRpt6_Click" ></asp:button>
		</div>
			</form>
			
    <p><!--#include file="inc/footer.aspx"--></p>
</HTML>
