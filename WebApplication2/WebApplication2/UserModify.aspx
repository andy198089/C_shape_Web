<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="UserModify.aspx.cs" Inherits="WebApplication2.UserModify" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>UserModify</title>

    <div class="contact">
        <div class="container">            
            <div class="row">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-xl-8 col-lg-6 col-md-6 col-sm-10" >
                            <asp:Label ID="Label1" runat="server" Text="修改密碼" ForeColor="Black" Font-Size="XX-Large"></asp:Label><br /><br />
                            <asp:Label ID="Label2" runat="server" Text="" ForeColor="Black" Font-Size="X-Large"></asp:Label><br /><br /> 
                            <asp:Label ID="Label4" runat="server" Text="新的密碼" ForeColor="Black"></asp:Label>
                            <input id="Text1" class="form-control" name ="password" type="text" /><asp:Label ID="Label6" runat="server" Text="" ForeColor="Black"></asp:Label>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="確認密碼" ForeColor="Black"></asp:Label>
                            <input id="Text1" class="form-control" name ="password2" type="text" /><asp:Label ID="Label7" runat="server" Text="" ForeColor="Black"></asp:Label>
                            
                        </div>   
                        <div class=" col-md-12">                                
                            <asp:Button ID="Button1" runat="server" Text="儲存" class="send" Width="1200px" OnClick="Button1_Click" /><br />                   
                        </div>                            
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
