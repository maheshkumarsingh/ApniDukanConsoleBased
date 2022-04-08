<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="UserInterface.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <%--  <meta name="viewport" content="width=device-width, initial-scale=1">--%>

<style>

* {

  box-sizing: border-box;

}

 

input[type=text], select, textarea {

  width: 100%;

  padding: 12px;

  border: 1px solid #ccc;

  border-radius: 4px;

  resize: vertical;

}

 

label {

  padding: 12px 12px 12px 0;

  display: inline-block;

}

 

input[type=submit] {

  background-color: #04AA6D;

  color: white;

  padding: 12px 20px;

  border: none;

  border-radius: 4px;

  cursor: pointer;

  float: right;

}

 

input[type=submit]:hover {

  background-color: #45a049;

}

 

.container {

  border-radius: 5px;

  background-color: #f2f2f2;

  padding: 20px;

}

 

.col-25 {

  float: left;

  width: 25%;

  margin-top: 6px;

}

 

.col-75 {

  float: left;

  width: 75%;

  margin-top: 6px;

}

 

/* Clear floats after the columns */

.row:after {

  content: "";

  display: table;

  clear: both;

}

 

/* Responsive layout - when the screen is less than 600px wide, make the two columns stack on top of each other instead of next to each other */

@media screen and (max-width: 600px) {

  .col-25, .col-75, input[type=submit] {

    width: 100%;

    margin-top: 0;

  }

}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2 style="text-align:center; margin-top:70px;color:lightcoral">Hello New User Please Register Yourself😊</h2>
    <div class="container">

    </div>
</asp:Content>
