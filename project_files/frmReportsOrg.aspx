<%@ Page language="c#" Inherits="WebApplication2.ReportsOrg" CodeFile="frmReportsOrg.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body text="maroon" bgColor="#ffffff">
		<form id="Main" method="post" runat="server">
			<asp:button id="btnExit" style="Z-INDEX: 102; LEFT: 34px; POSITION: absolute; TOP: 112px" runat="server" BorderStyle="None" BackColor="Red" Height="42px" Width="237px" Text="Exit" Font-Size="Small" ForeColor="White" Font-Bold="True" onclick="btnExit_Click"></asp:button>
			<asp:button id="Button7" style="Z-INDEX: 123; LEFT: 321px; POSITION: absolute; TOP: 401px" runat="server" ForeColor="Navy" Font-Size="Small" Text="Training Program" Width="238px" Height="42px" BackColor="White" BorderStyle="Solid" BorderWidth="1px"></asp:button>
			<asp:button id="Button6" style="Z-INDEX: 122; LEFT: 325px; POSITION: absolute; TOP: 219px" runat="server" ForeColor="Navy" Font-Size="Small" Text="Units and Teams" Width="238px" Height="42px" BackColor="White" BorderStyle="Solid" BorderWidth="1px"></asp:button>
			<asp:button id="Button5" style="Z-INDEX: 121; LEFT: 320px; POSITION: absolute; TOP: 492px" runat="server" ForeColor="Navy" Font-Size="Small" Text="Resource Management" Width="238px" Height="42px" BackColor="White" BorderStyle="Solid" BorderWidth="1px" onclick="Button5_Click"></asp:button>
			<asp:button id="Button3" style="Z-INDEX: 120; LEFT: 583px; POSITION: absolute; TOP: 267px" runat="server" ForeColor="Navy" Font-Size="Small" Text="Services Status" Width="238px" Height="42px" BackColor="White" BorderStyle="Solid" BorderWidth="1px"></asp:button>
			<asp:button id="Button2" style="Z-INDEX: 119; LEFT: 583px; POSITION: absolute; TOP: 167px" runat="server" ForeColor="White" Font-Size="Small" Text="Activation" Width="238px" Height="42px" BackColor="Red" BorderStyle="Solid" BorderWidth="1px" BorderColor="#A7D7CC"></asp:button>
			<asp:button id="Button1" style="Z-INDEX: 118; LEFT: 323px; POSITION: absolute; TOP: 168px" runat="server" ForeColor="White" Font-Size="Small" Text="Implementation" Width="238px" Height="42px" BackColor="Navy" BorderStyle="Solid" BorderWidth="1px" BorderColor="#A7D7CC"></asp:button>
			<asp:button id="Button4" style="Z-INDEX: 117; LEFT: 34px; POSITION: absolute; TOP: 171px" runat="server" ForeColor="White" Font-Size="Small" Text="Planning" Width="238px" Height="42px" BackColor="Navy" BorderStyle="Solid" BorderWidth="1px" BorderColor="#A7D7CC"></asp:button><asp:button id="btnPrep" style="Z-INDEX: 116; LEFT: 613px; POSITION: absolute; TOP: 381px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Preparation Checklist" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" Visible="False" onclick="btnPrep_Click"></asp:button><asp:button id="btnRisks" style="Z-INDEX: 115; LEFT: 34px; POSITION: absolute; TOP: 219px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Hazard Protection" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnRisks_Click"></asp:button><asp:button id="btnServinput" style="Z-INDEX: 114; LEFT: 640px; POSITION: absolute; TOP: 436px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Resources Inputs" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" Visible="False" onclick="btnServInputs_Click"></asp:button><asp:label id="lblMsg" style="Z-INDEX: 113; LEFT: 290px; POSITION: absolute; TOP: 117px" runat="server" BackColor="White" Height="25px" Width="709px" Font-Size="Small" ForeColor="Red"></asp:label><asp:button id="btnServices" style="Z-INDEX: 112; LEFT: 33px; POSITION: absolute; TOP: 265px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Business Continuity" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnServices_Click"></asp:button><asp:button id="btnAssess" style="Z-INDEX: 111; LEFT: 320px; POSITION: absolute; TOP: 591px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Assessments" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" Visible="False" onclick="btnAssess_Click"></asp:button><asp:button id="btnProcedureSteps" style="Z-INDEX: 110; LEFT: 320px; POSITION: absolute; TOP: 539px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Procedure Steps" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnProcedureSteps_Click"></asp:button><asp:label id="lblTitle" style="Z-INDEX: 100; LEFT: 35px; POSITION: absolute; TOP: 73px" runat="server" BackColor="White" Height="24px" Width="803px" Font-Size="Small" ForeColor="#000099"> Reports Menu</asp:label><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 35px; POSITION: absolute; TOP: 31px" runat="server" Height="30px" Width="803px" Font-Size="Small" ForeColor="Navy" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnEmergencyProcedures" style="Z-INDEX: 103; LEFT: 33px; POSITION: absolute; TOP: 313px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Emergency Procedures" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnEmergencyProcedures_Click"></asp:button><asp:button id="btnPhoneTree" style="Z-INDEX: 105; LEFT: 321px; POSITION: absolute; TOP: 355px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Phone Tree" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnPhoneTree_Click"></asp:button><asp:button id="btnGroupMembers" style="Z-INDEX: 106; LEFT: 321px; POSITION: absolute; TOP: 308px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Group Members" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnEmergencyTeams_Click"></asp:button><asp:button id="btnEmergencyGroups" style="Z-INDEX: 107; LEFT: 322px; POSITION: absolute; TOP: 264px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Contact Groups" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnEmergencyGroups_Click"></asp:button><asp:button id="btnEmergencyResources" style="Z-INDEX: 108; LEFT: 583px; POSITION: absolute; TOP: 220px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Action Plan" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnEmergencyResources_Click"></asp:button><asp:button id="btnOwnResources" style="Z-INDEX: 109; LEFT: 320px; POSITION: absolute; TOP: 445px" runat="server" BorderStyle="Solid" BackColor="White" Height="42px" Width="238px" Text="Resource Needs" Font-Size="Small" ForeColor="Navy" BorderWidth="1px" onclick="btnOwnResources_Click"></asp:button></form>
	</body>
</HTML>
