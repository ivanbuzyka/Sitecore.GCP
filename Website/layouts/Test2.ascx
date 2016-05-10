<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Test2.ascx.cs" Inherits="Website.layouts.Test2" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h2>Another sublayout</h2>
<div>
    Test: <sc:Text ID="TitleCtrl" runat="server" Field="Title" />
    <br />
    Test: <sc:Text ID="TextCtrl" runat="server" Field="Text" />
</div>