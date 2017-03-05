<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="RecipeDetails.aspx.cs" Inherits="Yummly.RecipeDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CpBody" runat="server">
    <div style="background-color: #ffffb2;">
        <div style="background-color: #cbe8ff;">
            <div style="width: 400px; margin: auto; padding: 25px;">
                <div>
                    <img src="<%:objRecipeDetails.images[0].hostedLargeUrl %>" style="height: 250px; width: 400px;" onerror="NoImageAvailable(this);" />
                </div>
                <div class="center font25" style="font-family: cursive;">
                    <%:objRecipeDetails.name %>
                </div>
            </div>
        </div>


        <div style="width: 100%; background-color: #e95d62;">
            <div style="padding-left: 230px;">
                <div class="recipePointers">
                    <div class="font20">Ingredients</div>
                    <div class="padding10"><%: (objRecipeDetails.ingredientLines) == null? "NA" : objRecipeDetails.ingredientLines.Count.ToString() %></div>
                    <div class="font20">
                        Count
                    </div>
                </div>

                <div class="recipePointers">
                    <div class="font20">Time</div>
                    <div class="padding10"><%: String.IsNullOrEmpty(objRecipeDetails.totalTime) ? "NA":objRecipeDetails.totalTime %></div>
                    <div class="font20">
                        Total
                    </div>
                </div>

                <div class="recipePointers">
                    <div class="font20">Rating</div>
                    <div class="padding10"><%: String.IsNullOrEmpty(objRecipeDetails.rating) ? "NA" :objRecipeDetails.rating  %></div>
                    <div class="font20" onclick="$(window).scrollTop($('#divReviewBlock').offset().top)" style="cursor: pointer; text-decoration: underline;">
                        Review It Now !!
                    </div>
                </div>

                <div class="clear"></div>
            </div>
        </div>

        <div style="margin-left: 70px; font-family: Rockwell" class="margin-top10">
            <div>
                <div class="blueHeading">Ingredients</div>
                <div class="whiteBackground">
                    <ol>

                        <asp:Repeater ID="rptIngredients" runat="server">
                            <ItemTemplate>
                                <li>
                                    <%# Container.DataItem.ToString() %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ol>
                </div>
            </div>

            <div class="margin-top20">
                <div class="blueHeading">Reviews</div>
                <% if (dsRecipeReviews.Tables.Count > 0 && dsRecipeReviews.Tables[0].Rows.Count > 0)
                   { %>

                <div class="divReviews">

                    <asp:Repeater ID="rptUserReviews" runat="server">

                        <ItemTemplate>

                            <div class="reviewItems">
                                <div class="reviewerName">
                                    <%#Eval("FirstName") %> <%#Eval("LastName") %>
                                </div>
                                <div class="reviewContent">
                                    <%#Eval("Review") %>
                                </div>

                            </div>

                        </ItemTemplate>


                    </asp:Repeater>

                </div>
                <%}
                   else
                   { %>
                <div>
                    No reviews available. Be the first one to review
                </div>
                <%} %>
            </div>

            <div class="margin-top20 padding10" id="divReviewBlock">
                <div class="subHeading">Review the Recipe</div>
                <div>
                    <div>
                        <textarea id="txtReviews" rows="10" cols="150"></textarea>
                    </div>
                    <div class="margin-top10">
                        <input type="button" style="background-color: #ff6a00; color: #fff; padding: 10px; border-radius: 3px; border: none; width: 100px;" value="Submit" onclick="SubmitReview();" />
                    </div>
                    <div id="reviewStatus" style="color: red">
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div>
        <input type="hidden" id="hdnRecipeId" runat="server" />
    </div>

    <script type="text/javascript">
        var sucData;
        function SubmitReview() {

            var obj = new Object();
            var review = $("#txtReviews").val();
            obj.Review = review;
            obj.RecipeId = $("#<%=hdnRecipeId.ClientID%>").val();
            if (review != "") {
                $.ajax({
                    url: "RecipeDetails.aspx/SubmitReview",
                    type: "POST",
                    data: JSON.stringify(obj),
                    contentType: "application/json",
                    success: function (successData) {
                        sucData = successData;

                        if (successData.d == true) {
                            //$("#reviewStatus").html("Review Submitted sucessfully.Thank You !");
                            //$("#txtReviews").val("");
                            location.reload();
                        }
                        else
                            $("#reviewStatus").html("Error while submitting the review.Please try again.");
                    },
                    error: function (errorData) { }
                });

            }

        }


    </script>

</asp:Content>

