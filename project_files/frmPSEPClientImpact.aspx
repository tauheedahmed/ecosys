<%@ Page language="c#" Inherits="WebApplication2.frmProfileSEPSRes" CodeFile="frmPSEPClientImpact.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Emergency Procedures</title>
		<META content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	    <style type="text/css">
            #frmEmergencyProcedures {
                
            }
        </style>
	</HEAD>
	<BODY bgColor="white">
		<FORM id="frmEmergencyProcedures" method="post" runat="server">
		<h1><asp:label id="lblTitle" Text="EcoSys: Business Models" runat="server" ></asp:label></h1>
		<p><b><asp:label id="lblProfilesName" Text="" runat="server" ></asp:label></b></p>
		<p><b><asp:label id="lblServiceName" Text="" runat="server" ></asp:label></b></p>
		<p><b><asp:label id="lblDeliverableName" Text="" runat="server" ></asp:label></b></p>
		<p><b><asp:label id="lblProcessName" Text="" runat="server" ></asp:label></b></p>
		<p><b><asp:label id="lblProfileName" Text="" runat="server" ></asp:label></b></p>
		
		<p><asp:label id="lblContents1" runat="server" ></asp:label>
			<asp:label id="lblContents2" runat="server" ></asp:label></p>
			<asp:button id="btnExit" runat="server" Text="Return to Previous Form" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" CommandName="Add" Text="Add Impacts" onclick="btnAdd_Click"></asp:button>
			<asp:datagrid id="DataGrid1" runat="server" GridLines="None" ForeColor="#A7D7CC" AllowSorting="True" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#CC9966" Height="30px" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn  DataField="Id" Visible="false" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Impact">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Description (Type inside box to update)">
						<ItemTemplate>
							<asp:TextBox id="txtDesc" runat="server" Height="27px" BorderColor="Navy" BorderStyle="Solid" BorderWidth="1px" Width="500px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="btnRemove" runat="server" Height="25px" BorderStyle="None" BackColor="Maroon" ForeColor="White" Font-Size="Smaller" Text="Remove" Font-Bold="True" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Description" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="EventsId" ReadOnly="True"></asp:BoundColumn>
					
					
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid>
			</FORM>
	</BODY>
</HTML>
