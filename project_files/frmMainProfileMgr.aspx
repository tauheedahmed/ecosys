<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmMainProfileMgr.aspx.cs" Inherits="frmMainProfileMgr" %>

<!--#include file="inc/HeaderProf.aspx"-->
<div id="maindiv" ><form id="form1" runat="server">
    <h1>EcoSys<sup>&copy;</sup>: Business and Service Models</h1>
     <p><asp:Button ID="btnExit" runat="server" Text="Exit" onclick="btnExit_Click" style="text-align: left" />
        <asp:Label ID="Label3" runat="server" ></asp:Label></p>
    <asp:Label ID="lblGreetAdv" runat="server"></asp:Label>
     <asp:Label ID="lblIntrop1" Text=""  runat="server" ></asp:Label>
   <p><asp:Label ID="lblIntrop2" runat="server"></asp:Label> 
   <asp:Label ID="Label1" Text="Here you will prepare models for given types of services.  The term 'services' is broadly used to include any kind of service, e.g. budget management, lending, medical services, or emergency preparedness.  
     A service model thus describes the inputs and outputs involved in any service.  Service models come in a variety of forms.  Examples of service models include the 'logframe method' that is widely used by development agencies, the 'NIMS framework' for crisis management used in the US government,
     as well as the various models of business analysis.  This website provides the tools to develop any of these kinds of service models.  You may either develop a model that complies with an existing set of standards or guidelines, or put together one based on 'best practices' that
     you understand as a practitioner in this field. "
       runat="server" ></asp:Label></p> 
         <h2> <asp:Button ID="btnStep1" runat="server" Text="Section I.  Service Models" 
        onclick="btnStep2_Click" /><asp:Label ID="lblHead2"  runat="server"></asp:Label></h2>
         <asp:Label ID="lblText2" Text="Service can cut across industries and functions.  This is particularly true for many 'internal services'
        including finance, general services, human resources, and emergency preparedness.  This commonality of services and related processes across industries and functions
        provides an opportunity to streamline the task of customizing broad-based service models to a given industry, profession or economic sector.  EcoSys provides you the means to also customize existing service models
        that you or someone else may have developed to a given industry." runat="server"></asp:Label>>
         
        
    <h2> <asp:Button ID="btnStep2" runat="server" Text="Section II.  Business Models"
        onclick="btnStep1_Click" /><asp:Label ID="lblHead1"  runat="server"></asp:Label></h2>
        <asp:Label ID="lblAll" Text="Here you will prepare models for given industries and/or services. These models will be subsequently
     used to ease the task of planning, programming, budgeting and monitoring within diverse types of organizations and for various kinds of
     services.  A business model
      identifies the various services that are delivered for a given industry or function.  For each service, it then identifies key service 
      deliverables, as well as related procedures, staffing and other resource requirements. The section titled 'I.  Business Models' below provides the means
       to develop such models." runat="server" ></asp:Label>            
       <p><asp:Label ID="lblAdvanced" runat="server" ></asp:Label> </p>
       
       <h2><asp:Button ID="btnHH" runat="server" Text="Section III.  Households Database"
     onclick="btnHH_Click" 
         />
         <asp:Label ID="Label2"  runat="server"></asp:Label></h2>
        <asp:Label ID="Label5" Text="Click here to maintain information on risk control measures that are 
         specific to specified household characteristics."
         
            runat="server" ></asp:Label>          
       <asp:Label ID="Label6" runat="server" ></asp:Label> 
       
       
    </form>
    <!--#include file="inc/footer.aspx"-->
    </div>
</html>
