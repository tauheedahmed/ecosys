<%@ Page language="c#" Inherits="WebApplication2.MainPers" CodeFile="frmMainPers.aspx.cs" %>
<!--#include file="inc/HeaderEPS.aspx"-->
		<form id="Main" method="post" runat="server">
			<asp:button id="btnExit" style="Z-INDEX: 101; LEFT: 78px; POSITION: absolute; TOP: 117px" runat="server" ForeColor="White" Font-Size="X-Small" Text="Exit" Width="118px" Height="34" BackColor="Navy" BorderStyle="None" Font-Bold="True" onclick="btnExit_Click"></asp:button>
			<asp:label id="Label3" style="Z-INDEX: 119; LEFT: 97px; POSITION: absolute; TOP: 380px" runat="server" Font-Bold="True" BackColor="White" Height="23px" Width="796px" Font-Size="Small" ForeColor="Navy">Part II:  Prepare a List of Emergency Contacts</asp:label>
			<asp:label id="lblStep1b" style="Z-INDEX: 118; LEFT: 155px; POSITION: absolute; TOP: 323px" runat="server" BackColor="White" Height="23px" Width="353px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblStep1a" style="Z-INDEX: 117; LEFT: 155px; POSITION: absolute; TOP: 275px" runat="server" BackColor="White" Height="23px" Width="353px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="Label6" style="Z-INDEX: 116; LEFT: 298px; POSITION: absolute; TOP: 646px" runat="server" BackColor="White" Height="20px" Width="121px" Font-Size="Smaller" ForeColor="Navy" Visible="False">b.  Service Needs</asp:label>
			<asp:button id="Button1" style="Z-INDEX: 115; LEFT: 491px; POSITION: absolute; TOP: 649px" runat="server" BorderStyle="Solid" BackColor="White" Height="22px" Width="96" Text="Click Here" Font-Size="Smaller" ForeColor="Navy" BorderWidth="1px" BorderColor="Navy" Visible="False" onclick="btnHHSer"></asp:button>
			<asp:button id="btnContactsReport" style="Z-INDEX: 114; LEFT: 542px; POSITION: absolute; TOP: 469px" runat="server" BorderStyle="Solid" BackColor="White" Height="22px" Width="96" Text="Click Here" Font-Size="Smaller" ForeColor="Navy" BorderColor="Navy" BorderWidth="1px" onclick="btnContactsReport_Click"></asp:button>
			<asp:button id="btnHHRes" style="Z-INDEX: 113; LEFT: 542px; POSITION: absolute; TOP: 325px" runat="server" BorderStyle="Solid" BackColor="White" Height="22px" Width="96" Text="Click Here" Font-Size="Smaller" ForeColor="Navy" BorderColor="Navy" BorderWidth="1px" onclick="btnHHRes_Click"></asp:button>
			<asp:button id="btnEvents" style="Z-INDEX: 112; LEFT: 218px; POSITION: absolute; TOP: 117px" runat="server" BorderStyle="Solid" BackColor="White" Height="34px" Width="300px" Text="In Case of an Emergency, Click Here" Font-Size="X-Small" ForeColor="Crimson" BorderWidth="1px" BorderColor="Red" Font-Bold="True" Visible="False" onclick="btnEvents_Click"></asp:button>
			<asp:label id="lblContent3" style="Z-INDEX: 111; LEFT: 78px; POSITION: absolute; TOP: 174px" runat="server" BackColor="White" Height="26px" Width="782px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblStep2a" style="Z-INDEX: 110; LEFT: 155px; POSITION: absolute; TOP: 426px" runat="server" BackColor="White" Height="20px" Width="368px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="lblStep2b" style="Z-INDEX: 109; LEFT: 153px; POSITION: absolute; TOP: 470px" runat="server" BackColor="White" Height="30" Width="370px" Font-Size="Small" ForeColor="Navy"></asp:label>
			<asp:label id="Label1" style="Z-INDEX: 107; LEFT: 97px; POSITION: absolute; TOP: 230px" runat="server" BackColor="White" Height="23px" Width="796px" Font-Size="Small" ForeColor="Navy" Font-Bold="True"> Part I:  Prepare a Customized List of Emergency Preparedness Measures Required</asp:label>
			<asp:button id="btnContacts" style="Z-INDEX: 106; LEFT: 542px; POSITION: absolute; TOP: 431px" runat="server" BorderStyle="Solid" BackColor="White" Height="25" Width="96" Text="Click Here" Font-Size="X-Small" ForeColor="Navy" BorderColor="Navy" BorderWidth="1px" onclick="btnContacts_Click"></asp:button><asp:label id="lblUser" style="Z-INDEX: 105; LEFT: 53px; POSITION: absolute; TOP: 541px" runat="server" ForeColor="Navy" Font-Size="XX-Small" Width="842px" Height="18px" Font-Italic="True"></asp:label><asp:label id="lblTitle" style="Z-INDEX: 100; LEFT: 75px; POSITION: absolute; TOP: 11px" runat="server" ForeColor="Navy" Font-Size="Medium" Width="941px" Height="30px" BackColor="White"></asp:label><asp:label id="lblOrg" style="Z-INDEX: 102; LEFT: 78px; POSITION: absolute; TOP: 51px" runat="server" ForeColor="Navy" Font-Size="Small" Width="814px" Height="11px" Font-Bold="True"></asp:label><asp:label id="lblMsg" style="Z-INDEX: 104; LEFT: 786px; POSITION: absolute; TOP: 736px" runat="server" ForeColor="Crimson" Font-Size="Small" Width="157px" Height="24px" BackColor="White"></asp:label><asp:button id="btnHsehold" style="Z-INDEX: 103; LEFT: 542px; POSITION: absolute; TOP: 276px" runat="server" ForeColor="Navy" Font-Size="X-Small" Text="Click Here" Width="96" Height="25" BackColor="White" BorderStyle="Solid" BorderWidth="1px" BorderColor="Navy" onclick="btnHseHold_Click"></asp:button></form>
	</body>
	<!--#include file="inc/footer.aspx"-->
</HTML>
