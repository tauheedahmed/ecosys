<%@ Page language="c#" Inherits="WebApplication2.frmUpdTimetable" CodeFile="frmUpdTimetable.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmAddProcedure" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id=lblMgr runat="server"></asp:label></h1>
        <h2><asp:label id=lblBd runat="server"  ></asp:label></h2>
        <h2><asp:label id=lblLocation runat="server" ></asp:label></h2>
        <h2><asp:label id=lblService runat="server" ></asp:label></h2>
        <h2><asp:label id=lblDel runat="server" ></asp:label></h2>
        <h2><asp:label id="lblProj" runat="server" ></asp:label></h2>
        <h2><asp:label id="lblTask" runat="server"  ></asp:label></h2>
        <h2><asp:label id="Label1" runat="server" Text="Timetable"></asp:label></h2>
        
        <asp:label id=lblContents1 runat="server" ></asp:label>
   
   
		
		<p><asp:button id="btnOK" runat="server" Text="OK" onclick="btnAction_Click"></asp:button>
		<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button>
			</p>
			</div>
		<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
				<asp:BoundColumn Visible="False" runat="server" DataField="Id" ReadOnly="True"></asp:BoundColumn>
				<asp:BoundColumn DataField="Seq" runat="server" Visible="False" HeaderText="Seq"> </asp:BoundColumn>
				<asp:BoundColumn Visible="False" runat="server" DataField="StepId" ReadOnly="True"></asp:BoundColumn>
				<asp:BoundColumn DataField="Name" runat="server" HeaderText="Steps"></asp:BoundColumn>
				<asp:BoundColumn Visible="False" runat="server" DataField="CompletionDate" ReadOnly="True" DataFormatString="{0:d}"></asp:BoundColumn>
				<asp:BoundColumn Visible="False" runat="server" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				<asp:TemplateColumn HeaderText="Completion Date">
					<ItemTemplate>
						<asp:TextBox id="txtCompletionDate" runat="server" ></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="Step Completed?">
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
					<ItemTemplate>
						<asp:CheckBox id="cbxStatus" runat="server" ></asp:CheckBox>
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
			</asp:datagrid>
			</form>
<!--#include file="inc/footer.aspx"-->
</HTML>
