<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeaserText.ascx.cs" Inherits="Website.layouts.TeaserText" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<h2>Teaser text component</h2>
<div style="border: 2px solid">
    <sc:Text ID="TitleCtrl" runat="server" Field="Title" />
    <br />
    <sc:Text ID="TextCtrl" runat="server" Field="Text" />
</div>