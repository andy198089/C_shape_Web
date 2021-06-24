<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Introduction.aspx.cs" Inherits="WebApplication2.Introduction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Introduction Page</title>

    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Black" Font-Size="X-Large"></asp:Label><br />
    <div class="row inf_area">
        <asp:Image ID="Image1" runat="server" Height="400px" Width="350px" BorderColor="White" BorderWidth="10px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div class="main-menu inf_area">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true"></asp:RadioButtonList><br />
            <asp:Label ID="Label5" runat="server" Text="售價："></asp:Label><asp:Label ID="Label6" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server" Text="庫存："></asp:Label><asp:Label ID="Label8" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="Label2" runat="server" Text="購買數量："></asp:Label><asp:TextBox ID="TextBox1" runat="server" Width="60px" TextMode="Number" min="0" step="1"></asp:TextBox><br />
            <asp:Button ID="Button1" runat="server" Text="加入購物車" OnClick="Button1_Click" />&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="前往購物車" OnClick="Button2_Click"/><br />
        </div>
    </div>
</asp:Content>
