<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="WebApplication2.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>AddProduct Page</title>

    <asp:Label ID="Label1" runat="server" Text="新增商品" ForeColor="Black" Font-Size="X-Large"></asp:Label><br />
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
    <asp:Label ID="Label2" runat="server" Text="(如需新增新種類請選最後一項)" Font-Size="Medium"></asp:Label><br />
    <asp:Label ID="Label14" runat="server" Text="請輸入要新增種類的名稱" Font-Size="Medium"></asp:Label><br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="創建" OnClick="Create_Table" /><br />
    <asp:Label ID="Label3" runat="server" Text="商品型號"></asp:Label><br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label4" runat="server" Text="商品名稱"></asp:Label><br />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label5" runat="server" Text="商品規格"></asp:Label><br />
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label6" runat="server" Text="商品尺寸"></asp:Label><br />
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label7" runat="server" Text="商品牌價"></asp:Label><br />
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label8" runat="server" Text="商品售價"></asp:Label><br />
    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label9" runat="server" Text="商品數量"></asp:Label><br />
    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br />
    <asp:Label ID="Label10" runat="server" Text="商品圖片(需上傳兩種)"></asp:Label><br />
    <asp:Label ID="Label11" runat="server" Text="示意圖"></asp:Label><br />
    <asp:Image ID="Image1" runat="server" Height="200px" Width="150px" ImageUrl="~/product_pic/LA-581A_1.jpg"/>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image2" runat="server" Height="200px" Width="150px" ImageUrl="~/product_pic/LA-581A_2.jpg" /><br />
    <asp:Label ID="Label12" runat="server" Text="圖一須含產品型號和名稱"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="圖二"></asp:Label><br />
    <div>
        <asp:Button ID="Upload_1" runat="server" Text="上傳" onclick="btnUpload_Click1"/><asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Upload_2" runat="server" Text="上傳" onclick="btnUpload_Click2"/><asp:FileUpload ID="FileUpload2" runat="server" /><br />
        <asp:Image ID="ShowImage_1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="ShowImage_2" runat="server" />
    </div>
    <asp:Button ID="Button2" runat="server" Text="儲存" OnClick="Button2_Click" /><asp:Button ID="Button3" runat="server" Text="取消" OnClick="Button3_Click" />
</asp:Content>
