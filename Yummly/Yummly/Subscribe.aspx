<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Subscribe.aspx.cs" Inherits="Yummly.Subscribe" %>

<%@ Register Src="~/Controls/SubscribeNewsletter.ascx" TagPrefix="uc1" TagName="SubscribeNewsletter" %>

<asp:Content ContentPlaceHolderID="CpBody" runat="server">
    <div class="padding30 pageBody" style="background-color:#ffffb2;">
        <uc1:SubscribeNewsletter runat="server" ID="SubscribeNewsletter" />
    </div>
    


</asp:Content>
