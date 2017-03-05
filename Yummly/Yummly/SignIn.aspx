<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Yummly.SignIn" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CpBody" runat="server">



    <div style="background-color: #ffffb2;" class="padding10">
        <div style="margin: 155px 0px 155px 400px">

            <div style="height: 200px;">
                <div style="margin-left: 200px">
                    <div class="fb-login-button" data-max-rows="1" data-size="xlarge" data-show-faces="false" data-auto-logout-link="false" onlogin="checkLoginState();"></div>
                </div>


                <div class="padding10">
                    <div class="g-signin2" data-onsuccess="onSignIn" data-width="500px" data-height="76px" data-longtitle="true"></div>
                </div>
            </div>

            <div class="padding10">
                <div>Already have a Foodie Account ? Sign In here..</div>
                <div class="margin-top10">

                    <div class="padding10">
                        <div>
                            Email Id &nbsp;&nbsp;&nbsp;: 
                            <span class="margin-left5">
                                <asp:TextBox ID="txtEmailId" runat="server"></asp:TextBox>
                            </span>
                        </div>
                        <div class="margin-top5">
                            Password : 
                            <span class="margin-left5">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </span>
                        </div>
                        <div class="margin-top10">
                            <asp:Button Text="Login" runat="server" OnClientClick="javascript: return ValidateFoodieLogin()" OnClick="FoodieLogin" />
                        </div>

                        <div>
                            <span id="spnFoodieLoginStatus" runat="server" style="color: red"></span>
                        </div>
                    </div>

                </div>
            </div>


            <script type="text/javascript">

                $(document).ready(function () {

                });


                function ValidateFoodieLogin() {
                    var regExEmail = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
                    var password = $("#<%=txtPassword.ClientID%>").val();
            var emailId = $.trim($("#<%= txtEmailId.ClientID%>").val());
            if (!regExEmail.test(emailId)) {
                $("#<%=spnFoodieLoginStatus.ClientID%>").html("Please enter valid Email Id");
                return false;
            }
            if (password == null || password == "") {
                $("#<%=spnFoodieLoginStatus.ClientID%>").html("Please enter password");
                return false;
            }
            return true;
        }


        function SetSession(dataVal) {
            var obj = new Object();
            obj.FirstName = dataVal.first_name;
            obj.LastName = dataVal.last_name;
            obj.EmailId = dataVal.email;
            obj.Type = dataVal.type;


            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                //url: "yourpagename.aspx/yourmethodnamewithoutbracesandparameters"
                url: "SignIn.aspx/SetSessionabc",
                //Be carefull about single quotation marks while parsing parameters
                //If function have no parameters, parse blank "data" for eg, data: "{ }",
                data: JSON.stringify(obj),
                success: function (data) {
                    //called on ajax call success
                    location.href = "/";
                },
                //call on ajax call failure
                error: function (xhr, textStatus, error) {
                    //called on ajax call error
                    alert("Error: " + error);
                }
            });

        }

    </script>


        </div>
    </div>

</asp:Content>
