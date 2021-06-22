<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="WebApplication2.ModifyProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>ModifyProduct Page</title>

    <asp:Label ID="Label1" runat="server" Text="修改商品" ForeColor="Black" Font-Size="X-Large"></asp:Label><br />
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
    <asp:Label ID="Label2" runat="server" Text="(需先選擇種類)" Font-Size="Medium"></asp:Label><br />
    <asp:Label ID="Label14" runat="server" Text="產品ID："></asp:Label>&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="50px"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" /><br />
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div><br />
    <asp:Label ID="Label15" runat="server" Text="請相對應輸入要修改的項目，如不需修改之項目請留白"></asp:Label><br />
    <asp:Label ID="Label3" runat="server" Text="型號："></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="名稱："></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label5" runat="server" Text="規格："></asp:Label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label6" runat="server" Text="尺寸："></asp:Label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label7" runat="server" Text="牌價："></asp:Label><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label8" runat="server" Text="售價："></asp:Label><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label9" runat="server" Text="數量："></asp:Label><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br />
    <asp:Button ID="Button2" runat="server" Text="修改" OnClick="Button2_Click" /><br />
    <asp:Label ID="Label17" runat="server" Text="修改圖片只需上傳便可修改" ForeColor="Black" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="Label10" runat="server" Text="商品圖片(需上傳兩種)"></asp:Label><br />
    <asp:Label ID="Label11" runat="server" Text="示意圖"></asp:Label><br />
    <asp:Image ID="Image1" runat="server" Height="200px" Width="150px" ImageUrl="~/product_pic/LA-581A_1.jpg"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image2" runat="server" Height="200px" Width="150px" ImageUrl="~/product_pic/LA-581A_2.jpg" /><br />
    <asp:Label ID="Label12" runat="server" Text="圖一須含產品型號和名稱"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="圖二"></asp:Label><br />
    <div>
        <asp:Button ID="Upload_1" runat="server" Text="上傳" onclick="btnUpload_Click1"/><asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Upload_2" runat="server" Text="上傳" onclick="btnUpload_Click2"/><asp:FileUpload ID="FileUpload2" runat="server" /><br />
        <asp:Image ID="ShowImage_1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="ShowImage_2" runat="server" />
    </div><br />
    <asp:Button ID="Button3" runat="server" Text="回上一頁" OnClick="Button3_Click" />
</asp:Content>
