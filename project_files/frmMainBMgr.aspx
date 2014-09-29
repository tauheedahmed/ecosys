<%@ Page language="c#" Inherits="WebApplication2.MainBMgr" CodeFile="frmMainBMgr.aspx.cs" %>
<!--<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Main</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body >
	-->
	<!--#include file="inc/HeaderBud.aspx"-->
	<div id="maindiv" >
		<form id="Main" method="post" runat="server">
		<div id="headerSection" >
		<h1><asp:label id="lblOrg" runat="server" ></asp:label></h1>
		<h2><asp:label id="lblTitle" Text="Budget Management" runat="server"></asp:label></h2>	
		<asp:label id="Label1" runat="server" ></asp:label>
		<asp:button id="btnExit" runat="server" Text="Exit" onclick="btnExit_Click"></asp:button>
		<asp:button id="btnFYBudgets" runat="server" Text="Start" onclick="btnFYBudgets_Click"></asp:button>
		<p><asp:label id="lblContent1" runat="server" ></asp:label></p>
	</div>
	</form>

	<!--#include file="inc/footer.aspx"-->

