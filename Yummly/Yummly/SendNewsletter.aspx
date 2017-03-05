<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="SendNewsletter.aspx.cs" Inherits="Yummly.SendNewsletter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CpBody" runat="server">
    <div>
        <div style="padding: 80px 0px 80px 500px; background-color: #ffffb2;">
            <div style="color: #2B3856; font-weight: bold; font-size: 20px; padding-left: 120px" class="padding10">
                Send Newsletters
            </div>
            <div class="padding10">
                Subject
            <asp:TextBox runat="server" ID="txtSubject" Style="width: 255px" />
                
            </div>


            <div class="padding10">Content:</div>

            <div class="padding10">
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtContent" Rows="12" Columns="50"></asp:TextBox>
            </div>
            <div class="padding10" style="padding-left: 150px">
                <asp:Button runat="server" Text="Send Mail" OnClick="SendLetter" />
            </div>
            <div class="margin-top10">
                <asp:Label ID="txtStatus" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
