<%@ Page Language="c#" Inherits="WebApplication2.MainMgr" CodeFile="frmMainMgr.aspx.cs" %>

<!--#include file="inc/Header.aspx"-->
<form id="frmEmergencyProcedures" method="post" runat="server">
<div id="maindiv" style="float:none">
    <div id="headerSection">
        <h1><asp:label id="lblOrg" runat="server"></asp:label> </h1>
        <h2><asp:label id="lblPerson" runat="server"></asp:label></h2>
        <h2><asp:label id="lblMode" runat="server"></asp:label></h2>
        <asp:button id="btnExit" runat="server" text="Exit" onclick="btnExit_Click" ></asp:button>
        <p><asp:label id="lblContents" runat="server"></asp:label></p>
    </div>
    <div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:46%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em;  "><h3><asp:label runat="server" text="Organizational Profile (Start Here)"></asp:label></h3>
            <div><h4><asp:label runat="server" text="Review the Business Model"></asp:label></h4>
            The business model is defined in terms of services provided by your organizations, and
             related information.  The business model for your type of organization has already been entered to
              the system. To review the model, select each report below in turn and click on the 'Generate Report' 
              button.
              <b><asp:label runat="server" text="What You Will Need"></asp:label></b> 
              An overall understanding of the organization.  Specifically, knowledge of the overall services provided by this organization, its basic procedures and staff and other resources needed. 
            <p><asp:dropdownlist id="lstRep" runat="server">
                    <asp:ListItem Value="Services" Selected="True">Services</asp:ListItem>
				    <asp:ListItem Value="Procedures">Procedures</asp:ListItem>
				    <asp:ListItem Value="Roles">Staff Roles</asp:ListItem>
				    <asp:ListItem Value="Business">Business Continuity</asp:ListItem>
				    </asp:dropdownlist>
            <asp:button id="btnRep" runat="server" onclick="btnRep_Click" 
                text="Generate Report"></asp:button></p></div>
            <div><h4><asp:label runat="server" text="Identify Resources"></asp:label></h4>
             Identify various staff, goods and services that you expect to call upon in your plans.  Click on the appropriate button below and follow instructions:  
             <b><asp:label runat="server" text="What You Will Need"></asp:label></b> 
             List of staff in the organization, contracts, inventory of goods used, sources of funds.
            <p><asp:button id="btnAptStruct" runat="server" text="Staffing Structure" onclick="btnAptStr_Click">
             </asp:button><asp:button id="btnStaff" runat="server" text="Staffing" onclick="btnStaff_Click">
             </asp:button><asp:button id="btnGS" runat="server" text="Inventory" onclick="btnGS_Click"></asp:button>
             <asp:button id="btnProc" runat="server" text="Contracts/Agreements" onclick="btnProc_Click"></asp:button> 
             <asp:button id="btnSOF" runat="server" text="Special Funds" onclick="btnFunds_Click"></asp:button> 
              <asp:button id="btnExRs" runat="server" Visible="False" text="Exchange Rates" 
                     onclick="btnERs_Click"></asp:button>  </p>
                     
                    <asp:label runat="server" text=""></asp:label>
                   <h4><asp:label runat="server" text="Review Resource Reports"></asp:label></h4>
            <asp:dropdownlist id="lstRepOth" runat="server">
                    <asp:ListItem Value="rptStaffActions" >Staff Actions</asp:ListItem>
				    <asp:ListItem Value="rptProcurements" >Procurements</asp:ListItem>
				    <asp:ListItem Value="Inventory" >Inventory</asp:ListItem>  </asp:dropdownlist>
				    <asp:button id="btnRepOth" runat="server" onclick="btnRepOth_Click" text="Generate Report"></asp:button>
                    </div></div>
                    <div style="float:right;  background-color:Gray;  border:solid 1px White; width:46%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em;  ">
                    <h3><asp:label runat="server" text="Work Planning and Budgeting"></asp:label></h3>
             Once you have completed your organizational profile to the left, you are ready to develop your work plans.  The system will use this information to streamline the process of planning and
              costing.  To proceed, click on the appropriate button below <p><asp:button id="btnPlan" runat="server" text="Planning" onclick="btnPlan_Click">
                        </asp:button><asp:button id="btnBud" runat="server" text="Budgeting" onclick="btnBud_Click"></asp:button></p>
              
            <h4><asp:label runat="server" text="Review Planning and Budgeting Reports"></asp:label></h4>
            <asp:dropdownlist id="lstRepPB" runat="server" autopostback="True" onselectedindexchanged="lstRepPB_SelectedIndexChanged">
                    <asp:ListItem Value="Timetables" >Timetables</asp:ListItem>
				    <asp:ListItem Value="Teams" >Teams</asp:ListItem>
				    <asp:ListItem Value="Goods">Goods and Services</asp:ListItem>
				    <asp:ListItem Value="rptBudgetR1" >Budget Distribution</asp:ListItem>
				    <asp:ListItem Value="rptBudgetR3" >Expenditure Commitments</asp:ListItem>
				    <asp:ListItem Value="rptBudgetR3S" >Expenditure Commitments - Staff</asp:ListItem>
				    <asp:ListItem Value="rptBudgetR3O" >Expenditure Commitments - Non-Staff</asp:ListItem>
				    <asp:ListItem Value="rptBudOrgOutputs" >Performance Indicators:  Outputs</asp:ListItem>
				    <asp:ListItem Value="rptBudOrgClients" >Performance Indicators:  Client Impact</asp:ListItem>
				    </asp:dropdownlist>
            <asp:button id="btnRepPB" runat="server" onclick="btnRepPB_Click" text="Generate Report"></asp:button>
            <b><asp:label id="lblAsOf" runat="server" text="You may change date below to generate actual or planned expenditures for a different date"
                    visible="false"></asp:label></b>
            <asp:textbox id="txtAsOfDate" runat="server" visible="false"></asp:textbox>
            <asp:button id="btnRepPB1" runat="server" visible="false" onclick="btnRepPB_Click"
                text="Generate Report"></asp:button></div>
                
				    <div style="float:right;  background-color:Gray;  border:solid 1px White; width:46%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em;  ">
            <h3><asp:label runat="server" text="Other Options"></asp:label></h3>
            These are to provide you greater flexibility in using the system.  Take the cursor over the various buttons below to see their function.
				    
				    <p><asp:button id="btnEM" runat="server" onclick="btnEM_Click" 
                            text="Switch to Emergency Management" 
                            ToolTip="Click to toggle between using the system for emergency planning vs planning for regular services"></asp:button></p>
				     <p>    <asp:button id="btnOrgC" runat="server" onclick="btnOrgC_Click"  text="Change Organization" 
                            ToolTip="Allows you to prepare organizational profiles and perform work planning and budgeting for more than one organization "></asp:button>
        <h4><asp:label id="lblOrgC" visible="false" runat="server">Change Organization</asp:label></h4>
        <asp:dropdownlist id="lstOrg" visible="false" runat="server" height="16px" width="150px"
            autopostback="True" onselectedindexchanged="lstOrg_SelectedIndexChanged"></asp:dropdownlist>
        <asp:button id="btnOrgCExit" runat="server" visible="false" onclick="btnOrgCExit_Click"
            text="Cancel"></asp:button> </p>
            <p><asp:button id="btnBM" runat="server" onclick="btnBM_Click" 
                text="Switch to Business Management"></asp:button></p> 
                <p><asp:button id="btnSec" 
                            runat="server" text="System Access" onclick="btnSec_Click" 
                            ToolTip="Permits you to create additional user id with access limited to performing a sub-set of the functions available on this user id. Useful in particular for larger organizations."></asp:button>
            <asp:button id="btnCS" runat="server" text="Provide Community Service During Emergencies" 
                            onclick="btnCS_Click" 
                            ToolTip="Services identified here will be made visible for purposes of household emergency planning to which access is provided to all on the home page."></asp:button>
          </p>
				<asp:button id="btnProfile" runat="server" text="Your Profile"
            onclick="btnProfile_Click"></asp:button>    
            
        <asp:button id="btnUProfile" backcolor="Khaki" runat="server" text="Update" visible="False"
            onclick="btnUProfile_Click"></asp:button>
        <asp:button id="btnCProfile" backcolor="Khaki" runat="server" text="Cancel" visible="False"
            onclick="btnCProfile_Click"></asp:button> </div>   
            <div style="clear: left; float:left;  background-color:Gray;  border:solid 1px White; width:46%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em;  ">
            <h3><asp:label runat="server" text="Utilities"></asp:label></h3>   
            <h4><asp:label id="lblPrt" runat="server">Print Format</asp:label></h4>
        <asp:radiobuttonlist id="rblRep" runat="server" >
                <asp:ListItem Value="HTML" Selected="True">HTML</asp:ListItem>
				    <asp:ListItem Value="PDF">PDF</asp:ListItem>
				    <asp:ListItem Value="Word">Word</asp:ListItem>
				    <asp:ListItem Value="Excel">Excel</asp:ListItem>
				    </asp:radiobuttonlist></div> 
   <asp:datagrid id="DataGrid1" runat="server" autogeneratecolumns="False" visible="False"
                cellpadding="1" cellspacing="1" font-bold="False" font-italic="False" font-overline="False"
                font-strikeout="False" font-underline="False" gridlines="None" horizontalalign="Left"
                onitemcommand="DataGrid1_ItemCommand">
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
            <h4>
                <asp:label id="lblEmail" runat="server" text="Email" visible="False"></asp:label>
            </h4>
            <asp:textbox id="txtEmail" visible="False" runat="server" height="24px" borderstyle="Solid"
                backcolor="White" forecolor="Navy" width="246px"></asp:textbox>
            <h4>
                <asp:label id="lblCPhone" visible="False" runat="server" text="Cell Phone"></asp:label>
            </h4>
            <asp:textbox id="txtCPhone" visible="False" runat="server" height="24px" borderstyle="Solid"
                backcolor="White" forecolor="Navy" width="246px"></asp:textbox>
            <h4>
                <asp:label id="lblWPhone" visible="False" runat="server" text="Work Phone"></asp:label>
            </h4>
            <asp:textbox id="txtWPhone" visible="False" runat="server" height="24px" borderstyle="Solid"
                backcolor="White" forecolor="Navy" width="246px"></asp:textbox>
            <h4>
                <asp:label id="lblHPhone" visible="False" runat="server" text="Home Phone"></asp:label>
            </h4>
            <asp:textbox id="txtHPhone" visible="False" runat="server" height="24px" borderstyle="Solid"
                backcolor="White" forecolor="Navy" width="246px"></asp:textbox>

   
    <!--#include file="inc/footer.aspx"-->
    <asp:label id="lblLicense" runat="server" font-italic="True"></asp:label>
</div>
<p>
</p>
</form>
</HTML> 