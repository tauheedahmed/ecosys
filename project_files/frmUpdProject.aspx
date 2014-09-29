<%@ Page language="c#" Inherits="WebApplication2.frmUpdProject" CodeFile="frmUpdProject.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h2><asp:label id=lblMgr runat="server"></asp:label></h2>
        <h2><asp:label id=lblBud runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLocation runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblEventName runat="server" ></asp:label></h2>
        <asp:label id="lblProj" runat="server" ></asp:label>
        <h2><asp:label id="lblContents1" runat="server"  ></asp:label></h2>
        <p><asp:button id="btnAction" runat="server" onclick="btnAction_Click"></asp:button>
        <asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
		
		</div>
		<div style="font-weight:bold; color:White; ">
		<div style="clear:left; float:left;  background-color:Gray;  border:solid 1px White; width:50%;Padding:.25em .25em .25em 1em;    
		    margin:.25em .25em .25em .25em; 
		    ">
		    
		<p><asp:label id="lblProcName" runat="server" Text="Name"></asp:label></p>
        <asp:textbox id="txtName" runat="server" Width="300px" ForeColor="Navy" BackColor="White"></asp:textbox>
           
		<p><asp:label id="Label4" runat="server" Text="Description"></asp:label></p>
		<asp:TextBox id="txtDesc" runat="server" Height="50px" Width="300px" BorderStyle="Solid" ></asp:TextBox>
		
            <p><asp:label id="Label3" runat="server" Text="Visibility"> </asp:label></p>
            <asp:dropdownlist id="lstVisibility" runat="server" ></asp:dropdownlist>
			</div>
		<div style="float:left; width:40%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
			<p><asp:label id="lblStatus" runat="server" Text="Status" ></asp:label></p>	
        <p><asp:radiobuttonlist id="rblStatus" runat="server" font-weight="bold">
			<asp:ListItem Value="Planned" Selected="True">Planned</asp:ListItem>
			<asp:ListItem Value="Started">Started</asp:ListItem>
			<asp:ListItem Value="Completed">Completed</asp:ListItem>
			<asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
		</asp:radiobuttonlist></p>
		
			<p><asp:label id="Label1" runat="server" Text="Date Started" ></asp:label></p>
			<asp:textbox id="txtStartTime" runat="server" Width="168px" Height="26px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<p><asp:label id="Label2" runat="server" Text="Date Completed" ></asp:label></p>
			<asp:textbox id="txtEndTime" runat="server" Width="168px" Height="26px" ForeColor="Navy" BorderStyle="Solid" BackColor="White"></asp:textbox>
			<p><asp:label id="lblDate" runat="server" Text="Enter dates in form mm/dd/yyyy"></asp:label>`</p>
			<p><asp:label id="lblType" runat="server" Visible="False">Type</asp:label></p>
            <asp:dropdownlist id="lstType" runat="server" Visible="False"></asp:dropdownlist>
            
            </div>
            </div>
        </form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
