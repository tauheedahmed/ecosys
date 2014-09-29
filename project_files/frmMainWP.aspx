<%@ Page language="c#" Inherits="WebApplication2.frmMainWP" CodeFile="frmMainWP.aspx.cs" %>

	<!--#include file="inc/HeaderWP.aspx"-->
		<form id="Main" method="post" runat="server" defaultbutton="btnLocServices" >
		<h1>EcoSys<sup>&copy;</sup></h1>
			<h2><asp:label id="lblOrg" runat="server"  ></asp:label></h2>
			<h3><asp:label id="lblTitle" runat="server" ></asp:label></h3>
			<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnHH" runat="server" Text="Household Checklist" 
            onclick="btnHH_Click" visible="false" ></asp:button>
			<p><asp:label id="lblContent" runat="server" ></asp:label>
			<p><asp:label id="lblContent1a" runat="server" ></asp:label>
			
			<h2><asp:label id="lblContent1" runat="server"  Text="Step I. Review Business Model Reports" ></asp:label></h2>
			<p><asp:label ID="lblBMReports" runat="server" ></asp:label></p>
			<asp:button id="btnBIA" runat="server" Text="Service Standards" 
            onclick="btnBIA_Click"></asp:button>  
			<asp:button id="btnEProcs" runat="server" Text="Service Procedures"  
            onclick="btnEProcs_Click"></asp:button>
			<asp:button id="btnSP" runat="server"  Text="Procedure Details" 
            onclick="btnSP_Click"></asp:button>
			<asp:button id="btnStfTOR" runat="server"  Text="Job Descriptions" onclick="btnStfTOR_Click"></asp:button>
			
			<h2><asp:label id="lblContent2" runat="server"  Text="Step II. Update Plans" ></asp:label></h2>
		    <h5><asp:button id="btnLocServices" runat="server" Text="Click Here to Update" onclick="btnLocServices_Click" ></asp:button></h5>
		    <asp:label id="lblContent3" runat="server" ></asp:label>
		    
			<h2><asp:label id="lblWP1" runat="server"  Text="Step III. Review Work Planning and Budget Reports" ></asp:label></h2>
			<p><asp:label ID="lblWPReports" runat="server" ></asp:label></p>
			
            <asp:button id="btnBud" runat="server" Text="Staff and Resource Assignments" onclick="btnBud_Click"></asp:button>   
            <asp:button id="btnBudGS" runat="server"  Text="Budget Summary Report" onclick="btnBudGS_Click"></asp:button> 
            <asp:button id="btnTT" runat="server"  Text="Timetables" 
            onclick="btnTT_Click"></asp:button>              
                </form>
                <!--#include file="inc/footer.aspx"-->
</HTML>
