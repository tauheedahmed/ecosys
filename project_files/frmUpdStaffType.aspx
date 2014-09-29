<%@ Page language="c#" Inherits="WebApplication2.frmUpdStaffType" CodeFile="frmUpdStaffType.aspx.cs" %>
<!--#include file="inc/HeaderSA.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
			 <h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
			 <h2><asp:label id="lblFunction" runat="server" ></asp:label></h2>
			 <asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
             <asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
             
            <h4><asp:label id="lblProcName"  runat="server" Text="Name" ></asp:label></h4>
            <asp:textbox id="txtName" runat="server" ForeColor="Navy" Height="30px" Width="516px" BorderStyle="Solid" ></asp:textbox>
            <h4><asp:label id="Label1" runat="server" >Visibility</asp:label></h4>
            <asp:dropdownlist id="lstVisibility" runat="server" ></asp:dropdownlist>
            
				</FORM>
		</form>
        <!--#include file="inc/footer.aspx"-->
</HTML>
