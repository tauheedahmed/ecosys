<%@ Page language="c#" Inherits="WebApplication2.frmUpdProcSReq" CodeFile="frmUpdProcSReq.aspx.cs" %>
<!--#include file="inc/HeaderWP.aspx"-->
		<form id="frmUpdProcSAR" method="post" runat="server">
		<div id="headerSection" >
			<h3><asp:label id=lblOrg runat="server"></asp:label></h3>
            <h3><asp:label id=lblBd runat="server"  ></asp:label></h3>
            <h3><asp:label id=lblLoc runat="server" ></asp:label></h3>
            <h3><asp:label id=lblService runat="server" ></asp:label></h3>
            <h3><asp:label id=lblProject runat="server" ></asp:label></h3>
            <h3><asp:label id=lblTask runat="server" ></asp:label></h3>
            <h3><asp:label id=lblEventName runat="server" ></asp:label></h3>
            <h3><asp:label id=lblRole runat="server" ></asp:label></h3>
            <h3><asp:label id="lblName" runat="server" ></asp:label></h3>
            <h3><asp:label id="lblAptType" runat="server" Text="Appointment Type" ></asp:label></h3>
            <asp:label id="lblContent1" runat="server"  ></asp:label>
			<p><asp:button id="btnAction"  runat="server" Text="Action" onclick="btnAction_Click"></asp:button>
			<asp:button id="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click"></asp:button></p>
			</div>
			<div style="font-weight:bold; color:White; ">
		         
                <asp:dropdownlist id="lstAptTypes" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="lstAptTypes_SelectedIndexChanged" ></asp:dropdownlist>
			</div>
            
            <div style="float:left; width:40%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
           <p><asp:label id="lblTime" runat="server" Text="Time Input Required"> </asp:label></p> 
           <asp:textbox id="txtTime"  runat="server" ></asp:textbox>
           <asp:dropdownlist id="lstTimeMeasure" runat="server" >
				<asp:ListItem Value="0">Year(s)</asp:ListItem>
				<asp:ListItem Value="1">Month(s)</asp:ListItem>
				<asp:ListItem Value="2" Selected="True">Week(s)</asp:ListItem>
				<asp:ListItem Value="3">Day(s)</asp:ListItem>
				<asp:ListItem Value="4">Hour(s)</asp:ListItem>
			</asp:dropdownlist>
           <p> <asp:label id="lblSalaryPeriod"  runat="server"  ></asp:label></p>
               <asp:label id="lblAptStatus" runat="server" ></asp:label>
            
           
            </div>
            
            <div style="float:left; width:40%; background-color:Gray; border:solid 1px White; margin:.25em .25em .25em .25em;
			Padding:.25em .25em .25em 1em; ">
			 <asp:button id="btnBud" runat="server"  Text="Recalculate Budget Required"  onclick="btnBud_Click"></asp:button>
			
               <p> <asp:label id="lblBud" runat="server" ></asp:label></p>
            <ol>
                <li>&nbsp;
			</li>
            </ol>
            </div>
			<asp:label id="lblBackup" runat="server" Visible="False">Check if this is a backup staff</asp:label>
			<asp:CheckBox id="cbxBackup" runat="server" Visible="False"></asp:CheckBox>
                <asp:CheckBox id="CheckBox1" runat="server" Visible="False"></asp:CheckBox>
               <asp:label id="lblBudName" runat="server" Visible="False"></asp:label>
			<asp:label id="lblBudget" runat="server"></asp:label>
			</div>
	    </form>
            <asp:datagrid id="DataGrid1" runat="server" Visible="false" AutoGenerateColumns="False">
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Bottom" BackColor="Teal"></HeaderStyle>
				<Columns>
				<asp:BoundColumn Visible="False" runat="server" DataField="Id" ReadOnly="True"></asp:BoundColumn>
				<asp:TemplateColumn HeaderText="Start Date">
					<ItemTemplate>
						<asp:TextBox id="txtStartDate" runat="server" ></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn HeaderText="End Date">
					<ItemTemplate>
						<asp:TextBox id="txtEndDate" runat="server" ></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:BoundColumn Visible="False" runat="server" DataField="StartDate" ReadOnly="True" DataFormatString="{0:d}"></asp:BoundColumn>
				<asp:BoundColumn Visible="False" runat="server" DataField="EndDate" ReadOnly="True" DataFormatString="{0:d}"></asp:BoundColumn>
				
			</Columns>
			</asp:datagrid>  
			<asp:button id="btnSA" runat="server" Text="Assign Staff" Visible="false" onclick="btnSA_Click"></asp:button>         
        <!--#include file="inc/footer.aspx"-->
</HTML>
