<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Login</title>

    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>會員登入</h2>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="contact">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6">
                            <input class="form-control" id="Text1" type="text" name ="account" placeholder="帳號"/>
                        </div>
                        <div class="col-xl-6 col-lg-6 col-md-6 col-sm-6">
                            <input class="form-control" id="Text2" type="text" name ="password" placeholder="密碼"/>                                
                        </div>
                        <div class=" col-md-12">                                
                            <asp:Button ID="Button1" runat="server" Text="登入" class="send" Width="1200px" OnClick="Button1_Click" /><br />                        
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </asp:Content>
