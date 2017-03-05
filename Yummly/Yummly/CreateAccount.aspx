<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="Yummly.CreateAccount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="CpBody" runat="server">
    
    <div style="background-color: #ffffb2;" class="padding10 pageBody">
        <div>
            <div style="padding:80px;width:315px;margin:auto;">
                <div id="login_container">
                    <div style="color:#ff6a00;" >Create A Foodie Account</div>
                    <div id="login_form" style="background-color: #FFFFB2">
                        <table>
                            <tr>
                                <td>First Name</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Last Name</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Email Address</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Password</td>
                                <td>:</td>
                                <td>
                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button OnClientClick="javascript: return ValidateCreateAccount()" OnClick="CreateUserAccount" runat="server" Text="Create Account" />
                                </td>
                            </tr>
                        </table>
                        <div id="emailValidStatus" style="color: red" runat="server">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var regExEmail = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;

        function ValidateCreateAccount()
        {
            var firstName = $.trim($("#<%=txtFname.ClientID%>").val());
            var lastName = $.trim($("#<%=txtLname.ClientID%>").val());
            var password = $.trim($("#<%=txtPassword.ClientID%>").val());

            var email = $("#<%=txtEmail.ClientID%>").val();


            if (firstName == null || firstName == "")
            {
                $("#<%=emailValidStatus.ClientID%>").html("Please enter first name");
                return false;
            }
            if (lastName == null || lastName == "")
            {
                $("#<%=emailValidStatus.ClientID%>").html("Please enter Last name");
                return false;
            }
            if (!regExEmail.test(email)) {
                $("#<%=emailValidStatus.ClientID%>").html("Please enter a valid Email");
                return false;
            }
            //alert(password);
            if (password == null || password == "")
            {
                $("#<%=emailValidStatus.ClientID%>").html("Please enter password");
                return false;
            }
            if (password.length < 6)
            {
                $("#<%=emailValidStatus.ClientID%>").html("Please enter password of atlease 6 characters");
                return false;
            }
            return true;
        }

        //function openForm() {
        //    if ($("#login_form").is(":hidden")) {
        //        $("#login_form").slideDown("slow");
        //    }
        //    else {
        //        $("#login_form").slideUp("slow");
        //    }
        //}
    </script>
</asp:Content>
