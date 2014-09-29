<%@ Page language="c#" Inherits="WebApplication2.frmProfileSEProcs" CodeFile="frmProfileSEProcs.aspx.cs" %>
<!--#include file="inc/Header.aspx"-->
<div id="maindiv" >
<form id="frmEmergencyProcedures" method="post" runat="server">

		<div id="headerSection" >
		<h1><asp:label id="Label1" Text="Business Models" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblProfilesName" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblServiceName" Text="Service Name" runat="server" ></asp:label></h2>
		<h2><asp:label id="lblDeliverableName" Text="Deliverable Name" runat="server" ></asp:label></h2>
		<p><asp:label id="lblContents1" runat="server"></asp:label>
			<asp:label id="lblContents2" runat="server" ></asp:label>
			<asp:label id="lblContents3" runat="server" ></asp:label>
			</p><asp:button id="btnExit" runat="server" Text="Return to Previous Form" onclick="btnExit_Click"></asp:button>
			<asp:button id="btnAdd" runat="server" Text="Add Processes" CommandName="Add" onclick="btnAdd_Click"></asp:button>
			</div>
			
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" GridLines="None">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn  DataField="Id"  Visible="False" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="Seq" ReadOnly="True" ></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Seq No">
						<ItemTemplate>
							<asp:TextBox id="txtSeq" runat="server" ForeColor="Navy" BackColor="White" BorderStyle="Solid" BorderColor="Navy" Height="24px" Width="31px"></asp:TextBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="Name" HeaderText="Processes">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn>
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="Button3" runat="server" Text="Update" CommandName="Update"></asp:button>
							
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn Visible="False">
						<HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom"></HeaderStyle>
						<ItemTemplate>
							<asp:button id="btnPSEPO1" runat="server" Text="Services" CommandName="Services"></asp:button>
						<asp:button id="btnPSEPO2" runat="server" Text="Other" CommandName="Other"></asp:button>
							
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:TemplateColumn>
						<ItemTemplate>
							<asp:button id="Button6" runat="server" BackColor="Maroon" ForeColor="White" Text="Remove" CommandName="Remove"></asp:button>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Timetables" ReadOnly="True"></asp:BoundColumn>
				<asp:BoundColumn Visible="False" DataField="ProcsId" ReadOnly="True"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>		
			</form>
   <!--#include file="inc/footer.aspx"-->
</HTML>
