<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Semester_Project_BookStore._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Bytewise Store</h1>
    </div>

    <div class="row">
        <asp:DataList ID="DataListProducts" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" >
            <ItemTemplate>
                <div class="col-xs-6 col-md-3">
                    <div class="thumbnail">
                        <div class="card">
                            <img
                                class="card-img-top"
                                src="./Images/<%# Eval("Image") %>"
                                alt="card image"
                                style="width: 100%; height: 250px" />
                            <div class="card-body" style="padding: 10px">
                                <h4 class="card-title">Product: <%# Eval("Name") %></h4>
                                <p class="card-text">Price: Rs. <%# Eval("Price") %></p>
                                <asp:Button
                                    ID="btnAddtoCart"
                                    runat="server"
                                    Text="Add to Cart"
                                    OnCommand="btnAddtoCart_Command"
                                    CommandName="viewdetails"
                                    CommandArgument='<%# Eval("Id") %>'
                                    CssClass="btn btn-danger"/>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
