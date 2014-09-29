<%@ Page language="c#" Inherits="WebApplication2.frmUpdBOJournals" CodeFile="frmUpdBOJournals.aspx.cs" %>
<!--#include file="inc/HeaderBud.aspx"-->
<div id="maindiv" >
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblBud" runat="server" ></asp:label></h2>
			<h5><asp:label id="lblReq" runat="server" ></asp:label></h5>
			<h5><asp:label id="lblBudget" runat="server" ></asp:label></h5>
			
			<h5><asp:label id="lblUpdates" runat="server" Text="Increase By:"></asp:label></h5>
			<h5><asp:label id="lblDate" runat="server" ></asp:label></h5>
			<asp:label id="lblContents" runat="server" ></asp:label>
			<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnOK_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
				</div>
				
			
			<div><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle  BorderStyle="None" ></AlternatingItemStyle>
				
				<ItemStyle HorizontalAlign="Left"  VerticalAlign="Top" ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BorderColor="Navy" BackColor="Teal"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="BDOrgName" HeaderText="Organizations">
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="BDAmount" HeaderText="Amount Changed"></asp:BoundColumn>
				</Columns>
			</asp:datagrid></div>
			<div><h3><asp:label id="Label4" runat="server" Text="Description"></asp:label></h3>
			<asp:TextBox id="txtDesc" runat="server" Height="56px" Width="480px" BorderStyle="Solid" BorderColor="Navy" TextMode="MultiLine"></asp:TextBox>
			</div>
		
			</form>
			<!--#include file="inc/footer.aspx"-->
</HTML>
