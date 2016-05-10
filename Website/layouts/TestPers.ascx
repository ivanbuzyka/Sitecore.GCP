<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestPers.ascx.cs" Inherits="Website.layouts.TestPers" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
    <sc:Text ID="TitleCtrl" runat="server" Field="Title" />
    <br />
    <sc:Text ID="TextCtrl" runat="server" Field="Text" />
</div>
