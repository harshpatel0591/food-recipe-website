<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchRecipe.ascx.cs" Inherits="Yummly.Controls.SearchRecipe" %>




<div style="width: 300px; margin: auto;">
    <div>
        <input type="text" id="txtRecipeName" placeholder="Search Recipes.." style="padding: 10px; width: 300px; margin: auto; border-radius: 3px; border: 1px solid #2bb6c4;" />
    </div>
    <div style="margin: 10px 0px 0px 100px;">
        <input type="button" value="Search" style="background-color: #ff6a00; color: #fff; padding: 10px; border-radius: 3px; border: none; width: 100px;" onclick="SearchRecipe();" />
    </div>
</div>
