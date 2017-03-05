<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubscribeNewsletter.ascx.cs" Inherits="Yummly.Controls.SubscribeNewsletter" %>

<div style="color: #2B3856; font-weight: bold; font-size: 20px; text-align: center; padding: 5px;">
    Subscribe to our Newsletter
</div>

<div style="width: 510px; margin: auto;">
    <div class="infoText padding5">
        Please provide the email address you want to subscribe to foodie.com monthly newsletter.
    </div>
    <div>
       <%-- <input type="text" style="padding: 10px; width: 300px; margin: auto; border-radius: 3px; border: 1px solid #2bb6c4;" placeholder="Type Email Address here.." />
        <input type="button" style="background-color: #ff6a00; color: #fff; padding: 10px; border-radius: 3px; border: none; width: 100px;" value="Subscribe" />--%>
         
        <asp:TextBox ID="txtEmail" Style="padding: 10px; width: 300px; margin: auto; border-radius: 3px; border: 1px solid #2bb6c4;" runat="server" placeholder="Type Email Address here.."></asp:TextBox>
        <asp:Button runat="server" Style="background-color: #ff6a00; color: #fff; padding: 10px; border-radius: 3px; border: none; width: 100px;" Text="Subscribe" OnClick="SubscribeEmail" OnClientClick="javascript: return ValidateEmail();" />

    </div>
    <div id="emailValidStatus" style="color:red">

    </div>

</div>

<script type="text/javascript">
    var regExEmail = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
    function ValidateEmail()
    {
        var email = $("#<%=txtEmail.ClientID%>").val();
        //alert(email);
        if (regExEmail.test(email))
        {
            return true;
        }
        else
        {
            $("#emailValidStatus").html("Please enter a valid Email");
            return false;
        }
    }

</script>

