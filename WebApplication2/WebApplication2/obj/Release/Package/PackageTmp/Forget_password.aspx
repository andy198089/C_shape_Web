<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Forget_password.aspx.cs" Inherits="WebApplication2.Forget_password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="brand_color">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="titlepage">
                        <h2>忘記密碼嗎?</h2>
                        <h3>資料輸入正確即可重設密碼</h3>
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
                        <div class="col-xl-8 col-lg-6 col-md-6 col-sm-10" >
                            <input class="form-control" id="Text1" type="text" name ="account" placeholder="帳號"/><asp:Label ID="Label1" runat="server" Text="" ForeColor="Black"></asp:Label>
                            <input class="form-control" id="Text2" type="text" name ="userName" placeholder="使用者名稱"/><asp:Label ID="Label2" runat="server" Text="" ForeColor="Black"></asp:Label>
                            <input class="form-control" id="Text3" type="text" name ="email" placeholder="電子信箱"/><asp:Label ID="Label3" runat="server" Text="" ForeColor="Black"></asp:Label>
                        </div>   
                        <div class=" col-md-12">                                
                            <asp:Button ID="Button1" runat="server" Text="確認" class="send" Width="1200px" OnClick="Button1_Click" /><br />                   
                        </div>                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
