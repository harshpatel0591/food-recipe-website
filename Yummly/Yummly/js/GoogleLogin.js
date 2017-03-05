/// <reference path="Scripts/jquery-2.1.4.js" />
/// <reference path="Scripts/jquery-2.1.4.intellisense.js" />
var objGoogleLogin = new Object();

function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    var id = googleUser.getAuthResponse();
    var fullName = profile.getName();

    var nameArray = fullName.split(" ");
    firstName = nameArray[0];
    lastName = nameArray[1];

    objGoogleLogin.first_name = firstName;
    objGoogleLogin.last_name = lastName;
    objGoogleLogin.email = profile.getEmail();
    objGoogleLogin.type = "3";
    SetSession(objGoogleLogin);
    //alert('ID: ' + profile.getId());
    console.log('ID: ' + profile.getId()); //Not safe when Interacting with the Backend server.
    console.log('ID_Token: ' + id.id_token); //Hence, always use ID_Token instead of an ID.
    console.log('First Name: ' + firstName);
    console.log('Last Name: ' + lastName);
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail());
    //alert(profile.getEmail());
}

function GoogleSignOut() {
    //alert("googleeee");
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut();
    //objGoogleLogin = new Object();
    //auth2.disconnect();
}