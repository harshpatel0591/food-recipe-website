<%@ Page Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="Recipes.aspx.cs" Inherits="Yummly.Recipes" %>

<%@ Register Src="~/Controls/SearchRecipe.ascx" TagPrefix="uc1" TagName="SearchRecipe" %>


<asp:Content runat="server" ContentPlaceHolderID="CpBody">
    <div style="background-color: #ffffb2;" class="padding10">


        <div style="font-size: 24px; font-weight: bold; margin: 4px; border-bottom: 1px solid grey;">
            Recipe Results
        </div>
        <div>
            <asp:Repeater ID="rptRecipiesList" runat="server">
                <ItemTemplate>



                    <div class="recipeItem">
                        <div class="left">
                            <img src="<%#Eval("smallImageUrl") %>" style="width: 150px; height: 150px;" onerror="NoImageAvailable(this);" />
                        </div>
                        <div class="recipeInfo">
                            <div class="left">
                                <div style="width: 580px;">
                                    <%#Eval("recipeName") %>
                                </div>
                                <div class="margin-top5 infoText">
                                    <%#Eval("sourceDisplayName") %>
                                </div>
                                <div class="margin-top5">
                                    <div class="left">
                                        <img src="Images/Samples/ratingStar.png" width="20" height="20" />
                                    </div>
                                    <div class="left">
                                        &nbsp; <%#Eval("rating") %>
                                    </div>
                                </div>
                            </div>
                            <div class="left margin-left60" style="width: 110px;">
                                <div class="left">
                                    <img src="Images/Samples/2.png" width="30" height="30" />
                                </div>
                                <div class="left margin-top5">
                                    <%# Common.CommonCompute.ConvertTime(Convert.ToInt32(Eval("totalTimeInSeconds"))) %>
                                </div>
                                <div class="clear"></div>
                            </div>
                            <div class="left margin-left60 margin-top40">
                                <input recipeid="<%#Eval("Id") %>" type="button" onclick="ViewRecipeDetails(this)" style="background-color: #ff6a00; color: #fff; padding: 10px; border-radius: 3px; border: none; width: 100px;" value="View Details" class="btnViewDetails" />
                            </div>
                            <div class="clear"></div>
                        </div>
                        <div class="clear"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>




        </div>

        <div>
            <div class="margin-top10">
                <div style="width: 300px; margin: auto;">
                    <div class="infoText">
                        Find more Recipes...
                    </div>
                    <div>
                        <uc1:SearchRecipe runat="server" ID="SearchRecipe" />
                    </div>
                </div>
            </div>
        </div>

    </div>


    <script type="text/javascript">

        function ViewRecipeDetails(btn) {

            location.href = "/RecipeDetails.aspx?id=" + $(btn).attr("RecipeId");

        }


    </script>

</asp:Content>
