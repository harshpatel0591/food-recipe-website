<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Test1.aspx.cs" Inherits="Yummly.Test1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CpBody" runat="server">

    <div style="padding:20px;">
        <input type="button" value="SUBMIT" onclick="CallAjaxFunction();" />
    </div>

    <div style="padding: 20px;">


        <asp:Repeater ID="rptCuisines" runat="server">
            <ItemTemplate>
                <div style="padding:5px;">
                    <div>
                        <%#Eval("CuisineName") %> ----- <%#Eval("Query") %> ------- <%#Eval("Id") %> --- <%# Eval("ImageUrl") %>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>
    <script type="text/javascript">
        var obj;
        $(document).ready(function () {


            CallAjaxFunction();

        });

        function CallAjaxFunction()
        {
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                //url: "yourpagename.aspx/yourmethodnamewithoutbracesandparameters"
                url: "Test1.aspx/AddUserEmail",
                //Be carefull about single quotation marks while parsing parameters
                //If function have no parameters, parse blank "data" for eg, data: "{ }",
                data: '{emailId:"harsh.patel"}',
                success: function (data) {
                    //called on ajax call success
                    obj = data;
                    //alert(data.d);
                },
                //call on ajax call failure
                error: function (xhr, textStatus, error) {
                    //called on ajax call error
                    alert("Error: " + error);
                }
            });

        }
        

    </script>

</asp:Content>
