<%@ Page language="c#" Inherits="WebApplication2.frmMainOEPS" CodeFile="frmMainBusProfile.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
    <form id="form1" runat="server">
    <h1>EcoSys: Business Models</h1>
    <asp:Label ID="lblGreetAdv" runat="server"></asp:Label>
     <asp:Label ID="lblIntrop1" Text="Here you will prepare models for a given set of services. These models will be subsequently
     used to ease the task of planning, programming, budgeting and monitoring within diverse types of organizations and for various kinds of
     services.  A business model
      identifies the various services that are delivered for a given industry or function.  For each service, it then identifies key service 
      deliverables, as well as related procedures, staffing and other resource requirements. The section titled 'I.  Business Models' below provides the means
       to develop such models." 
       runat="server" ></asp:Label>
   <p><asp:Label ID="lblIntrop2" runat="server" 
        Text="Service deliverables and processes can cut across industries and functions.  This is particularly true for many 'internal services'
        including finance, general services, human resources, and emergency preparedness.  This commonality of services and related processes across industries and functions
        provides an opportunity to streamline the task of preparing the business models in Section I for many such services, and for extending
        best practices across industries for a given service.  In EcoSys, this is done by incorporation (or 're-use') of service models, or relevant parts thereof, 
        across industry models.  The section titled
        'II.  Service Models' further below provides the means
       to develop such models." 
         ></asp:Label> </p> 
    <h2> <asp:Label ID="lblHead1" Text="Section I.  Business Models" runat="server"></asp:Label></h2>
        <asp:Label ID="lblGreetBeg" runat="server"></asp:Label>
            <p><asp:Label ID="lblAll" Text="Here you will prepare models for given industries and/or services. These models will be subsequently
     used to ease the task of planning, programming, budgeting and monitoring within diverse types of organizations and for various kinds of
     services.  A business model
      identifies the various services that are delivered for a given industry or function.  For each service, it then identifies key service 
      deliverables, as well as related procedures, staffing and other resource requirements. The section titled 'I.  Business Models' below provides the means
       to develop such models." runat="server" ></asp:Label></p>
            <asp:Button ID="btnStep2" runat="server" Text="Click Here to Begin Business Models" 
        onclick="btnStep1_Click" />
        <h2> <asp:Label ID="lblHead2" Text="Section II.  Service Models" runat="server"></asp:Label></h2>
    
       <p><asp:Label ID="lblAdvanced" runat="server" ></asp:Label> 
   <asp:Button ID="btnStep1" runat="server" Text="Click Here to Begin Service Models" 
        onclick="btnStep2_Click" /></p>
        
        
        <h2><asp:Label ID="Label3" runat="server" Text="Exit "> </asp:Label></h2>
   <asp:Button ID="btnExit" runat="server" Text="Click Here to Exit" 
        onclick="btnExit_Click" style="text-align: left" />
        
    </form>
</body>
</HTML>
