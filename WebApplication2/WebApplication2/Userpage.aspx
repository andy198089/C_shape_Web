<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Userpage.aspx.cs" Inherits="WebApplication2.Userpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Userpage</title>

     <div class="contact">
        <div class="container">            
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-xl-8 col-lg-6 col-md-6 col-sm-10" >
                            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Black" Font-Size="X-Large"></asp:Label><br /><br />
                            <asp:Label ID="Label2" runat="server" Text="個人資料" ForeColor="Black" Font-Size="XX-Large"></asp:Label><br /><br />                            
                            <asp:Label ID="Label3" runat="server" Text="會員名稱" ForeColor="Black"></asp:Label><asp:Label ID="Label6" class="form-control" runat="server" ForeColor="Black"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="帳號" ForeColor="Black"></asp:Label><asp:Label ID="Label7" class="form-control" runat="server" ForeColor="Black"></asp:Label>
                            <asp:Label ID="Label5" runat="server" Text="密碼" ForeColor="Black"></asp:Label><asp:Label ID="Label8" class="form-control" runat="server" ForeColor="Black"></asp:Label>
                            </div>   
                        <div class=" col-md-12">                                
                            <asp:Button ID="Button1" runat="server" Text="修改密碼" class="send" Width="1200px" OnClick="Button1_Click"  /><br />                   
                        </div>                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
