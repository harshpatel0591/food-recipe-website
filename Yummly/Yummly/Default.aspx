<%@ Page Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Yummly.Default" %>

<%@ Register Src="~/Controls/SubscribeNewsletter.ascx" TagPrefix="uc1" TagName="SubscribeNewsletter" %>
<%@ Register Src="~/Controls/SearchRecipe.ascx" TagPrefix="uc1" TagName="SearchRecipe" %>



<asp:Content ID="Body" ContentPlaceHolderID="CpBody" runat="server">

    <div class="pageBody clear">
        <div style="background-image: url('/Images/home-wallpaper.jpg'); background-repeat: no-repeat; width: auto; height: 412px;">
            <div style="padding: 150px 0px 50px 0px;">


                <uc1:SearchRecipe runat="server" ID="SearchRecipe" />


            </div>

        </div>
        <div style="padding: 20px; background-color: #D8BFD8;" id="divTopCuisines">
            <div style="color: #2B3856; font-weight: bold; font-size: 20px; text-align: center; padding: 20px;">
                Top World Cuisine Categories
            </div>
            <div>

                <asp:Repeater ID="rptPopularCuisines" runat="server">

                    <ItemTemplate>

                        <div class="cuisinesTypes" onclick="ShowRecipes('<%#Eval("Query") %>')">
                            <img src='<%#Eval("ImageUrl") %>' style="width: 120px; height: 120px; border-radius: 50%;" />
                            <div>
                                <%#Eval("CuisineName")%>
                            </div>
                        </div>

                    </ItemTemplate>

                </asp:Repeater>



                <div class="clear"></div>
            </div>
        </div>


        <div style="padding: 50px; background-color: #40E0D0;">
            <div>
                <uc1:SubscribeNewsletter runat="server" ID="SubscribeNewsletter" />
            </div>


        </div>

    </div>
    <script type="text/javascript">

        function SearchRecipe() {
            location.href = "/Recipes.aspx?q=" + $("#txtRecipeName").val();
        }

        function ShowRecipes(q)
        {
            location.href = "/Recipes.aspx?q=" + q;
        }

    </script>

</asp:Content>


