
<%@ Page language="c#" Inherits="WebApplication2.frmUpdStaffAction" CodeFile="frmUpdStaffAction.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblContent1" runat="server" ></asp:label></h2> 
           <p><asp:label id="lblContent2" runat="server" ></asp:label></p> 
        
            <p><asp:button id="btnAction" runat="server" Text="OK" onclick="btnAction_Click"></asp:button>
            <asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
</div>
            <div style="font-weight:bold; color:White; ">
            <div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:30%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		    <div style="  text-align:center;">
		    <p><asp:Label id="lblSAction" runat="server" Text="Appointment Data" 
                    style="text-align: center;" Font-Bold="True" Font-Size="Larger" ></asp:Label></p> 
			 <p><hr />
		     <asp:button id="btnPeople" runat="server" Text="Identify Person Appointed" visible="false" 
             onclick="btnPeople_Click"></asp:button></div>
                
            <p><asp:label id="lblName" runat="server" ></asp:label></p>
            <p><asp:label id="lblRoles" runat="server" >Position Title</asp:label></p>
            <asp:dropdownlist id="lstRoles" runat="server" ></asp:dropdownlist>
            <p><asp:label id="lblAptType" runat="server"></asp:label></p>
            <p><asp:label id="lblAptStatus" runat="server" 
            ToolTip='Status "Closed" means no more work can be planned against this appointment; "Terminated" means in addition that the staff user Id for the staff member is no longer valid.'>Appointment Status</asp:label>
			<asp:dropdownlist id="lstAptStatus" runat="server" >
			<asp:ListItem Value="0">Planned</asp:ListItem>
			<asp:ListItem Value="1">Active</asp:ListItem>
			<asp:ListItem Value="2">Closed</asp:ListItem>
			<asp:ListItem Value="3">Terminated</asp:ListItem>
			</asp:dropdownlist></p>
			<p><asp:label id="lblStartDate" runat="server" Text="Appointment Start Date (mm/dd/yyyy)"></asp:label></p>
			 <asp:TextBox id="txtStartDate" runat="server" ></asp:TextBox>
            <p><asp:label id="lblEndDate" runat="server" Text="Appointment End Date (mm/dd/yyyy)"></asp:label></p>
			 <asp:TextBox id="txtEndDate" runat="server" ></asp:TextBox>
			<p><asp:label id="lblLocation" runat="server" >Duty Location</asp:label></p>
			<asp:dropdownlist id="lstLocations" runat="server" ></asp:dropdownlist>
			<p><asp:label id="lblPay" runat="server" >Payment Method</asp:label></p> 
            <asp:dropdownlist id="lstPayMethods" runat="server" ></asp:dropdownlist>   
			<p><asp:label id="lblVisibility" runat="server" >Visibility</asp:label></p>
            <asp:dropdownlist id="lstVisibility" tooltip="By selecting an appropriate level of visibility for this appointment action, you can extend or restrict to other units or organizations the ability to assign tasks to the incumbent of this position in their work plans." runat="server" ></asp:dropdownlist>
            <p><asp:label id="lblFunds" runat="server" >Source of Funds</asp:label></p>
            <asp:dropdownlist id="lstFunds" runat="server" ></asp:dropdownlist>
            </div>
			
			<div style="width:65%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
			<div style="float:none; text-align:center;">
			<p><asp:Label id="lblSARevision" runat="server" Text="Salary and Grade Data" 
                    Font-Bold="True" Font-Size="Larger"  ></asp:Label></p> 
		<hr /></div>
		<div style="float:left;">
			 <p><asp:Label id="lblCurr" runat="server" Text="Current" Font-Bold="True" Font-Size="Larger" style="text-align: center;" ></asp:Label></p> 
		<asp:Label id="lblCurrStartDate" runat="server"  ></asp:Label>
			 <p><asp:Label id="lblCurrSal" runat="server"  ></asp:Label>
			 <asp:label id="lblSalaryPeriod1" runat="server" ></asp:label></p> 
			 <p><asp:Label id="lblCurrGrade" runat="server"  ></asp:Label></p>
			 <p>
			 <hr />
			 
			 </div>
			  <p><asp:Label id="lblRev" runat="server" Text="Revisions (if any)" Font-Bold="True" 
                      Font-Size="Larger"  style="float:none; text-align: center;" ></asp:Label></p> 
		
			 <asp:label id="lblStartDateS" runat="server" Text="Start Date (mm/dd/yyyy)"></asp:label>
			<asp:TextBox id="txtStartDateS" runat="server" ></asp:TextBox>
			 </p>
	
		
			
            
            <p><asp:label id="lblSalary" runat="server" >Salary</asp:label></p>     
            <asp:textbox id="txtSalary" style="text-align: center" runat="server" ForeColor="Navy" BorderStyle="Solid" 
                BorderColor="Navy" BackColor="White"></asp:textbox>
                 <asp:label id="lblSalaryPeriod" runat="server" ></asp:label>
           
            <p></p>
            <asp:label id="lblSalMax" runat="server" ></asp:label>
            <p></p>
            <asp:label id="lblSalMin" runat="server"  ></asp:label> 
            <p><asp:label id="lblPayGrades" runat="server" >Grade</asp:label>
            <asp:dropdownlist id="lstPayGrades" runat="server" AutoPostBack="True" 
                onselectedindexchanged="Dropdownlist1_SelectedIndexChanged"></asp:dropdownlist></p>
			            
	</div>

            <div style="border-bottom: solid 1px White; Padding:1em 0 1em 0; >
            
            <div style=" float:left;">
            </div>
            </div>
        </form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
