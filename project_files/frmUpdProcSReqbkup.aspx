<%@ Page language="c#" Inherits="WebApplication2.frmUpdProcSReqbkup" CodeFile="frmUpdProcSReqbkup.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Staff Assignment Form (frmUpDProcSReq)</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bgColor="white">
		<form id="frmUpdProcSAR" method="post" runat="server">
			<asp:label id="lblContent1" style="Z-INDEX: 100; LEFT: 2px; POSITION: absolute; TOP: 43px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="675px"></asp:label><asp:dropdownlist id="lstTimeMeasure" style="Z-INDEX: 122; LEFT: 335px; POSITION: absolute; TOP: 401px" runat="server" ForeColor="Navy" Height="30px" Width="216px" AutoPostBack="True">
				<asp:ListItem Value="0">Year(s)</asp:ListItem>
				<asp:ListItem Value="1">Month(s)</asp:ListItem>
				<asp:ListItem Value="2" Selected="True">Week(s)</asp:ListItem>
				<asp:ListItem Value="3">Day(s)</asp:ListItem>
				<asp:ListItem Value="4">Hour(s)</asp:ListItem>
			</asp:dropdownlist><asp:button id="btnBud" style="Z-INDEX: 121; LEFT: 41px; POSITION: absolute; TOP: 439px" runat="server" ForeColor="White" Height="31px" Font-Bold="True" Text="Recompute Budget Required" BackColor="Navy" BorderStyle="None" onclick="btnRecomputeBudget"></asp:button><asp:label id="lblSal" style="Z-INDEX: 120; LEFT: 40px; POSITION: absolute; TOP: 268px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="133px" BorderStyle="None">Proposed Salary</asp:label><asp:textbox id="txtSalaryRate" style="Z-INDEX: 119; LEFT: 213px; POSITION: absolute; TOP: 264px" runat="server" ForeColor="Navy" Height="30px" Width="212px" BackColor="White" BorderStyle="Solid" BorderColor="Navy"></asp:textbox><asp:label id="lblAptType" style="Z-INDEX: 117; LEFT: 40px; POSITION: absolute; TOP: 197px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" Width="148px" BorderStyle="None">Appointment Type</asp:label><asp:dropdownlist id="lstAptTypes" style="Z-INDEX: 116; LEFT: 213px; POSITION: absolute; TOP: 196px" runat="server" ForeColor="Navy" Height="30px" Width="216px" AutoPostBack="True" onselectedindexchanged="lstAptTypes_SelectedIndexChanged"></asp:dropdownlist><asp:label id="lblBud" style="Z-INDEX: 114; LEFT: 40px; POSITION: absolute; TOP: 478px" runat="server" ForeColor="Maroon" Font-Size="Small" Height="21px" BorderStyle="None"></asp:label><asp:label id="lblTime" style="Z-INDEX: 113; LEFT: 40px; POSITION: absolute; TOP: 404px" runat="server" ForeColor="Navy" Font-Size="Small" Height="21px" Width="164px" BorderStyle="None">Time Input Required</asp:label><asp:label id="lblAptStatus" style="Z-INDEX: 112; LEFT: 41px; POSITION: absolute; TOP: 233px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" BorderStyle="None"></asp:label><asp:datagrid id="DataGrid1" style="Z-INDEX: 111; LEFT: 40px; POSITION: absolute; TOP: 539px" runat="server" ForeColor="#A7D7CC" Height="30px" BackColor="White" BorderStyle="None" BorderColor="#CC9966" BorderWidth="1px" AutoGenerateColumns="False" GridLines="None" AllowSorting="True" CellPadding="4">
				<SelectedItemStyle Font-Bold="True" ForeColor="#663399" BackColor="#FFCC66"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="#C7D7CC"></AlternatingItemStyle>
				<ItemStyle ForeColor="#000099" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" BackColor="Teal"></HeaderStyle>
				<FooterStyle ForeColor="#330099" BackColor="#FFFFCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn Visible="False" DataField="Id" ReadOnly="True"></asp:BoundColumn>
					<asp:BoundColumn DataField="FYName" HeaderText="FY"></asp:BoundColumn>
					<asp:BoundColumn DataField="VersionName" HeaderText="Version"></asp:BoundColumn>
					<asp:BoundColumn DataField="SOFName" HeaderText="Budgets">
						<HeaderStyle HorizontalAlign="Left" Width="300px"></HeaderStyle>
						<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="CurrCode" HeaderText="Currency"></asp:BoundColumn>
					<asp:BoundColumn DataField="StatusName" HeaderText="Status"></asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Selection One">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
						<ItemTemplate>
							<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn Visible="False" DataField="Status" ReadOnly="True"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="#000099" BackColor="#FFFFCC"></PagerStyle>
			</asp:datagrid><asp:label id="Label3" style="Z-INDEX: 110; LEFT: 40px; POSITION: absolute; TOP: 509px" runat="server" ForeColor="Navy" Font-Size="Small" Height="21px" Width="243px" BorderStyle="None">Budget Charged (Select One)</asp:label><asp:label id="lblName" style="Z-INDEX: 106; LEFT: 40px; POSITION: absolute; TOP: 164px" runat="server" ForeColor="Navy" Font-Size="Small" Height="28px" BorderStyle="None"></asp:label><asp:button id="btnSA" style="Z-INDEX: 109; LEFT: 243px; POSITION: absolute; TOP: 108px" runat="server" ForeColor="White" Height="31px" Width="193px" Font-Bold="True" Text="Identify Existing Staff" BackColor="Navy" BorderStyle="None" onclick="btnSA_Click"></asp:button><asp:textbox id="txtTime" style="Z-INDEX: 108; LEFT: 213px; POSITION: absolute; TOP: 400px" runat="server" ForeColor="Navy" Height="28px" Width="103px" BackColor="White" BorderStyle="Solid"></asp:textbox><asp:label id="lblSalaryPeriod" style="Z-INDEX: 107; LEFT: 446px; POSITION: absolute; TOP: 274px" runat="server" ForeColor="Navy" Font-Size="Small" Height="21px" Width="149px" BorderStyle="None"></asp:label><asp:label id="lblOrg" style="Z-INDEX: 101; LEFT: 2px; POSITION: absolute; TOP: 4px" runat="server" ForeColor="Navy" Font-Size="Small" Height="30px" Width="914px" Font-Bold="True">Organization Name Here</asp:label><asp:button id="btnCancel" style="Z-INDEX: 102; LEFT: 124px; POSITION: absolute; TOP: 108px" runat="server" ForeColor="White" Height="31px" Width="107px" Font-Bold="True" Text="Cancel" BackColor="Navy" BorderStyle="None" onclick="btnCancel_Click"></asp:button><asp:label id="lblDesc" style="Z-INDEX: 103; LEFT: 40px; POSITION: absolute; TOP: 302px" runat="server" ForeColor="Navy" Font-Size="Small" Height="21px" Width="95px" BorderStyle="None">Description</asp:label><asp:textbox id="txtDesc" style="Z-INDEX: 104; LEFT: 213px; POSITION: absolute; TOP: 305px" runat="server" ForeColor="Navy" Height="83px" Width="512px" BackColor="White" BorderStyle="Solid" TextMode="MultiLine"></asp:textbox><asp:button id="btnAction" style="Z-INDEX: 105; LEFT: 4px; POSITION: absolute; TOP: 108px" runat="server" ForeColor="White" Height="31px" Width="107px" Font-Bold="True" Text="Action" BackColor="Navy" BorderStyle="None" onclick="btnAction_Click"></asp:button>&nbsp;</form>
		</FORM>
	</body>
</HTML>
