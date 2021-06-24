<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="item_overview.aspx.cs" Inherits="WebApplication2.item_overview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="訂單細項"></asp:Label>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:Button ID="Button1" runat="server" Text="完成訂單" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="取消" OnClick="Button2_Click" />
</asp:Content>
