<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="shopping_cart.aspx.cs" Inherits="WebApplication2.shopping_cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="購物車" Font-Size="X-Large"></asp:Label>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label><br />
    <INPUT type="button" value="繼續購物" onclick='history.go(-<%= (int)ViewState["submittimes"] %>)'>-<asp:Button ID="Button2" runat="server" Text="提交訂單" OnClick="Button2_Click" />
</asp:Content>
