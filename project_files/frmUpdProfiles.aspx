<%@ Page language="c#" Inherits="WebApplication2.frmUpdProfiles" CodeFile="frmUpdProfiles.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>frmAddProcedure</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
  </HEAD>
	<body bgColor="white">
		<form id="frmAddProcedure" method="post" runat="server">
		<h1><asp:label id="Label3" Text="EcoSys:  Business Models" runat="server" ></asp:label></h1>
		
			<h2><asp:label id="lblFunction"  runat="server" > Function Title</asp:label></h2>
			<asp:button id="btnAction" runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			<p>
			<asp:CheckBox id="cbxHouseholds" runat="server" visible="false"></asp:CheckBox>`
			</p>
			<p>
			<asp:label id="lblStatus" runat="server" >Take Offline?</asp:label>
			<asp:CheckBox id="cbxStatus" runat="server" ></asp:CheckBox>
			</p>
			<asp:label id="lblProcName" runat="server"> Name</asp:label>
			<asp:textbox id="txtName" runat="server" Width="212px" ></asp:textbox>
			<p>
			<asp:label id="lblDesc" style="Z-INDEX: 115; LEFT: 383px;  " runat="server" >Description</asp:label>
			<asp:textbox id="txtDesc" style="Z-INDEX: 116; LEFT: 583px; " runat="server" Width="526px" ></asp:textbox>
			</p>
			<p>
			<asp:label id="Label5" runat="server" >Business Modeller</asp:label>
			<asp:dropdownlist id="lstPerson" runat="server" ></asp:dropdownlist>
			</p>
			<p>
			<asp:label id="Label1" runat="server" >Visibility</asp:label>
			<asp:dropdownlist id="lstVisibility" runat="server" ></asp:dropdownlist>
			</p>
			</form>
	</body>
</HTML>
