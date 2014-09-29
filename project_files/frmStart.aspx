<%@ Page language="c#" Inherits="WebApplication2.frmStart" CodeFile="frmStart.aspx.cs" %>
<!--<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>frmStart</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">comment to the right:  background="Benji1.JPG" decomment to show benji, ta1/22/09-->
		<!--#include file="inc/Header.aspx"-->
		<div id="maindiv" >
		<form method="post" runat="server" defaultbutton="btnChange" >
		<div id="headerSection">
			<h2>Welcome to EcoSys<sup>&copy;</sup></h2>
			
			<asp:Button id="btnIntro" runat="server" Text="About This Website" 
                    onclick="btnIntro_Click" TabIndex="2" Width="200px" ></asp:button>
             <p><asp:button id="btnHH" runat="server" text="Households Click Here"
            onclick="btnHH_Click" Width="200px"></asp:button></p></div>
			<p><asp:button id="btnBB" runat="server" text="Organizations Sign In Below" 
                    Width="200px"></asp:button></p>
            <div id="logon">
            <asp:label id="lblUserId" runat="server" >User Id</asp:label>
			<p><asp:textbox id="txtUserName" runat="server" TabIndex="1" ></asp:textbox></p>
			<asp:label id="lblPassword" runat="server" >Password</asp:label>
			<p><asp:textbox id="txtPassword" runat="server" TextMode="Password" TabIndex="2" ></asp:textbox></p>
			<p><asp:button id="btnChange" runat="server" Text="OK" onclick="btnContinue_Click" 
                    TabIndex="3"></asp:button></p>
			<asp:label id="lblError" Forecolor= "White" runat="server" ></asp:label>
			<p><asp:button id="btnContinue" runat="server" 
                Text="Change PW" onclick="btnChange_Click" TabIndex="7"></asp:button></p>
			<asp:button id="btnNewUsers" runat="server" Visible="False" 
                Text="Request License" onclick="btnNewUsers_Click" TabIndex="3"></asp:button>
			<asp:label id="lblMsg" runat="server" ></asp:label></div>
			<div Id="comment" >
			<asp:button id="btnClose" runat="server" Visible="False" 
                Text="Close Description" onclick="btnClose_Click" TabIndex="3"></asp:button>
			<p><asp:label id="lblIntro1" runat="server" Visible="False" Text="There are two things you can do on this website.  First, you can prepare a customized checklist of emergency preparedness measures you 
			can take to protect yourself and your household from a variety of natural and man made disasters.  To do this, simply click on the
			button to your left titled <b>Household Emergency Plan</b> and follow directions.  Second, you can access Ecosys.  To access EcoSys, you will need to be a licensed user with
			a valid User Id and Password that you will enter as indicated on the left." >
			</asp:label>  <p><h5><asp:Label ID="lblIntroh1" runat="server"  Visible="False" Text="Ecosys"></asp:Label></h5>
			
			<p><asp:label id="lblIntro1a" runat="server" Visible="False" Text="Ecosys is a suite of mutually compatible systems designed
			to facilitate the adoption of best practices across organizations.  Its core focus at this stage relates to various types of tasks related directly or indirectly to 
			the basic function of planning, budgeting, and monitoring.</p>
			Planning and budgeting in organizations have become increasingly demanding tasks.  
			There are increasing standards of transparency and control that are expected by stakeholders.  
			There may be more than one organization involved in financing and/or execution. These demands go hand in hand, however, with 
			increasing opportunities for meeting them.  
			These possibilities are the result of improved standards and of better tools which include most 
			notably the emergence of the world wide web." >
			</asp:label>  
			
			<asp:Label ID="lblIntro1b" runat="server"   Visible="False" Text="EcoSys is designed from scratch with the above issues and opportunities in view.  
			It provides an integrated environment for defining procedures, preparing work 
			plans of various kinds, distributing budgets to fund these work plans, and for tracking progress versus plan.  "></asp:Label>
			</p>
			<h5><asp:Label ID="lblIntroh2" runat="server"  Visible="False" Text="Ecosys:  Service and Business Models"></asp:Label></h5>
			<asp:label id="lblIntro2" runat="server"  Visible="False" Text="In defining procedures, EcoSys provides a set of ‘service models’. 
			These ‘service models’ reflect published service standards and guidelines and have been prepared for their respective 
			service areas by expert practitioners.  Examples of standards thus incorporated in EcoSys include the ‘Logframe Method’ 
			that is widely used in international economic development work. Another example is the ‘National Incident Management System’, or NIMS, 
			issued by the US government which provides the means for emergency preparedness planning in a various types of organizations across the nation.  " ></asp:label>
			<p><asp:label id="lblIntro2a" runat="server"  Visible="False" Text="‘Service models’ may apply to more than one type of organization.  
			Ecosys takes these published service models the next step forward by customizing service models for specific types of organizations.  
			The result is a ‘business model'." ></asp:label></p>
			<h5><asp:Label ID="lblIntroh3" runat="server"  Visible="False" Text="Ecosys:  Work Programming, Budgeting and Monitoring"></asp:Label></h5>
			<asp:label id="lblIntro3a" runat="server"  Visible="False" Text="‘Business models’ provide the ‘scaffolding’ within which work programs 
			and budgets may then be prepared within one or more organization and at various geographical locations.   
			Thus, every time a user signs in to prepare work programs, EcoSys automatically identifies the business model that applies.  
			It then presents the user with forms that are customized for that specific user, and thus helps minimize training requirements and  
			while at the same time streamlining and controlling these ‘downstream processes’ of work programming, 
			budget formulation 
			and distribution, and reporting on progress vs. plan. " ></asp:label>
			</div>
			
			</form>
            <div id="footer"> 
                copyright &copy; 2009 InfotechCentury LC
                <p><asp:label id="lblLic" runat="server" 
                    Text="Important Note:  Please note that by using this system by entering a User Id above and proceeding further,
			 you agree that you are proceeding totally at your own risk; that you hold any and all individuals and/or corporations involved in providing you this access harmless from any claim, liability, loss, or demand, including reasonable attorneys' fees due to or arising out of your use of this system."
                    BorderColor="Black" Font-Italic="True" Font-Size="X-Small" ></asp:label></p>
            </div>
        </div>
    </div>
    </body>
</html>    