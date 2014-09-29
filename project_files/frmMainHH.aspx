<%@ Page language="c#" Inherits="WebApplication2.MainOrgs" CodeFile="frmMainHH.aspx.cs" %>

<!--#include file="inc/HeaderEPS.aspx"-->
<div id="maindiv" >
		<form id="Main" method="post" Title="Emergency Preparedness" runat="server"  >
		<h2><asp:label id="lblTitle" runat="server" Text="Household Emergency Preparedness" ></asp:label></h2>
        <h3><asp:label id="lblTitle1" runat="server" ></asp:label></h3>
         <asp:button id="btnOK" runat="server" Text="Done" onclick="btnOK_Click" Visible="False" ></asp:button>
       <asp:button id="btnHome" runat="server" Text="Cancel" Visible="false" onclick="btnHome_Click" ></asp:button>
        <asp:button id="btnPlan" runat="server" Text="Emergency Preparedness Checklist" onclick="btnPlan_Click" ></asp:button>
        <asp:Button ID="btnRes" runat="server" Text="Emergency Services" onclick="btnRes_Click" ></asp:button>
        <asp:Button ID="btnAbout" runat="server" Text="About Us" onclick="btnAbout_Click" ></asp:button>
        <asp:button id="btnOK2" runat="server" Visible="false" Text="Show Services" onclick="btnOK2_Click"  ></asp:button>
        <asp:button id="btnOKPlan1" runat="server" Text="Continue to Step 2" Visible="false" onclick="btnOKPlan1_Click"  ></asp:button>
        <asp:button id="btnOKPlan2" runat="server" Text = "Generate Report" Visible="false" onclick="btnOKPlan2_Click"  ></asp:button>
        <br />
        <br /> 
		<h4><asp:label id="lblIntro1" runat="server" ></asp:label>  </h4>
		<asp:label id="lblIntro2" runat="server" ></asp:label>
		<p><asp:label id="lblIntro3" Text="Emergency Preparedness Checklist:" font-bold="true" runat="server"></asp:label>
		<asp:label id="lblIntro3a" Text="Every household should take certain measures, as 
            needed, to ensure emergency preparedness. The particular measures to be taken 
            depend on the characteristics of the household and the types of risks to which 
            it is exposed. Accordingly, by clicking on this button you are able to generate a convenient checklist that 
            is customized to your household." runat="server" ></asp:label></p>
        <p><asp:label id="lblIntro4" Text="Emergency Services:" font-bold="true" runat="server"></asp:label>
		<asp:label id="lblIntro4a" Text="This button provides a list of community and government resources in your area." 
		runat="server" ></asp:label></p>
       
       <p><asp:label id="lblIntro5" Text="About Us:" font-bold="true" runat="server"></asp:label>
		<asp:label id="lblIntro5a" runat="server" Text="By clicking here, you receive a description about who we are and how you can help us improve this website." ></asp:label>
		
		<h4><asp:label id="lblAbout1" Text="About Us" runat="server" ></asp:label></h4>
		<asp:label id="lblAbout2" Text="This website is part of the EcoSys<sup>&copy;</sup> family of internet based systems that are geared to 
		meet a variety of needs.  
		EcoSys has been developed and is maintained by InfotechCentury LC based in Maryland, USA.  This website is hosted by Software Productivity Strategists LC (SPS) also based in Maryland, USA.
		<p>The system is being made available for now, November 2009 for trial use.  We hope that the system proves to be of immediate use to you in ensuring the safety of yourself and your 
		household members.  At the same time, we plan to keep working towards enriching the database, with the system being designed to promote broad-based participation for this purpose. " 
              runat="server" ></asp:label>
		<h4><asp:label id="lblAbout3" Text="Contact Us" runat="server" ></asp:label></h4>
		<asp:label id="lblAbout4" Text=" We appreciate any feedback you may wish
		 to provide at this early stage. If you have any questions or suggestions, or would like to participate more
		in maintaining this website, please contact us as follows:" runat="server" ></asp:label>
		<asp:label id="lblAbout5" runat="server" ></asp:label>
		<asp:BulletedList ID="bltAbout" runat="server" visible="false" 
            BulletStyle="LowerAlpha" style="margin-left: 10%">
            <asp:ListItem>Questions/Suggestions: Please send email to tauheedahmed@hotmail.com</asp:ListItem>
            <asp:ListItem>Consulting Requests: Please send email to mary.stang@spsnet.com.  Also see www.spsnet.com 
            for more on emergency preparedness support available from SPS LC</asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>
        
		<h4><asp:label id="lblCountry" runat="server" Visible="false" ForeColor="White" BackColor="Black" Text="Country"></asp:label></h4>
			<asp:dropdownlist id="lstCountries" runat="server" Visible="false" 
            Width="379px" Height="30px" ForeColor="Navy" AutoPostBack="True" 
            onselectedindexchanged="lstCountries_SelectedIndexChanged"></asp:dropdownlist>
			<h4><asp:label id="lblState" runat="server" Visible="false" ForeColor="White" BackColor="Black" Text="State/Province"></asp:label></h4>
			<asp:dropdownlist id="lstStates" runat="server" Visible="false" Width="379px" 
                    Height="30px" ForeColor="Navy" AutoPostBack="True" 
                    onselectedindexchanged="lstStates_SelectedIndexChanged"></asp:dropdownlist>
			<h4><asp:label id="lblLoc" runat="server" Visible="false" ForeColor="White" BackColor="Black" Text="Location"></asp:label></h4>
			
			<asp:dropdownlist id="lstLocs" runat="server" Visible="false" Width="379px" Height="30px" ForeColor="Navy"></asp:dropdownlist>
		
		<p></p>
		<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" 
            HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" 
            Font-Overline="False" Font-Strikeout="False" 
            Font-Underline="False">
		<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" 
                BackColor="Black" Font-Bold="False" Font-Italic="False" ForeColor="White" 
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
		<ItemStyle BorderStyle="None" BackColor="White" ForeColor="Navy" Font-Bold="False" 
                Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False"></ItemStyle>
        <HeaderStyle BackColor="Black" Font-Bold="True" Font-Italic="False" 
        Font-Overline="False" Font-Strikeout="False" 
        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
		<Columns>
			<asp:BoundColumn DataField="Id" Visible="false" ReadOnly="True"></asp:BoundColumn>
			<asp:BoundColumn DataField="Name" HeaderText="Step 1:  Type of Household">
				<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description and Contact Information">
				<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
			</asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Select">
        <HeaderStyle BackColor="Black" Font-Bold="True" Font-Italic="False" 
        Font-Overline="False" Font-Strikeout="False" 
        Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:CheckBox id="cbxSel" runat="server" BorderStyle="None"></asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn Visible="False" DataField="AllHH" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:Label ID="lblBlank" runat="server"></asp:Label>
			
		<asp:datagrid id="DataGrid2" runat="server" AutoGenerateColumns="False" 
            HorizontalAlign="Left" Font-Bold="False" Font-Italic="False" 
            Font-Overline="False" Font-Strikeout="False" 
            Font-Underline="False">
		<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" 
                BackColor="Maroon" Font-Bold="False" Font-Italic="False" ForeColor="White"   
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
		<ItemStyle BorderStyle="None" BackColor=LightYellow ForeColor="Navy" Font-Bold="False" 
                Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False"></ItemStyle>
                
		<Columns>
			<asp:BoundColumn  DataField="Id" visible="false" ReadOnly="True"></asp:BoundColumn>
			<asp:BoundColumn DataField="Name" HeaderText="Step 2:  Emergency Events">
				<HeaderStyle BackColor=Maroon Font-Bold="True" Font-Italic="False" 
                    Font-Overline="False" Font-Strikeout="False" 
                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
				<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
			</asp:BoundColumn>
			<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True" HeaderText="Description">
				<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
			</asp:BoundColumn>
			<asp:TemplateColumn HeaderText="Select">
				<HeaderStyle HorizontalAlign="Center" BackColor="Maroon" 
                    Font-Bold="True" Font-Italic="False" Font-Overline="False" 
                    Font-Strikeout="False" Font-Underline="False" ForeColor="White"></HeaderStyle>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				<ItemTemplate>
					<asp:CheckBox id="cbxSel0" runat="server" BorderStyle="None"></asp:CheckBox>
				</ItemTemplate>
			</asp:TemplateColumn>
			<asp:BoundColumn Visible="False" DataField="Type" ReadOnly="True"></asp:BoundColumn>
			
				</Columns>
			</asp:datagrid>
			
			<asp:datagrid id="DataGrid3" runat="server" AutoGenerateColumns="False" 
            HorizontalAlign="Left" Font-Bold="False" >
		<AlternatingItemStyle HorizontalAlign="Left" BorderStyle="None" VerticalAlign="Top" 
                BackColor="Black" Font-Bold="False" Font-Italic="False" ForeColor="White" 
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></AlternatingItemStyle>
		<ItemStyle BorderStyle="None" BackColor="White" ForeColor="Navy" Font-Bold="False" 
                Font-Italic="False" Font-Overline="False" 
                Font-Strikeout="False" Font-Underline="False"></ItemStyle>
        <HeaderStyle BackColor="Black" Font-Bold="True" Font-Italic="False" 
                    Font-Overline="False" Font-Strikeout="False" 
                    Font-Underline="False" ForeColor="White" HorizontalAlign="Center" />
                
		<Columns>
			<asp:BoundColumn DataField="Id" Visible="false" ReadOnly="True"></asp:BoundColumn>
			<asp:BoundColumn DataField="ResName" HeaderText="Type of Service"></asp:BoundColumn>
			<asp:BoundColumn DataField="OrgName" HeaderText="Service Provider"></asp:BoundColumn>
			<asp:BoundColumn DataField="ContractName" HeaderText="Title"></asp:BoundColumn>
			<asp:BoundColumn DataField="ContractDesc" HeaderText="Description"></asp:BoundColumn>
			
			
			</Columns>
			</asp:datagrid>
		</form>
		</div>
<div id="footer"> 
		 <label> <i>Disclaimer: Please note that while effort has been made to ensure that information 
		      provided on this website will be helpful, there is no guarantee that it is complete or accurate for your situation.  By using this website, 
		      you therefore agree that it remains totally your responsibility how you interpret and use this information.  
		      Please proceed further only if the disclaimer above is acceptable to you.</i></label>
	<!--#include file="inc/footer.aspx"-->
</div>--> 
</HTML>
