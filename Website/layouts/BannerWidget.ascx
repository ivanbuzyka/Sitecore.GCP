<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerWidget.ascx.cs" Inherits="Website.layouts.BannerWidget" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div>
    <sc:Image ID="BannerCtrl" runat="server" MaxWidth="200" MaxHeight="300" Field="Banner image"/>
</div>
