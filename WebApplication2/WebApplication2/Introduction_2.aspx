<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Introduction_2.aspx.cs" Inherits="WebApplication2.Introduction_2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language='javascript' type='text/javascript'>
    //function money() {

    //    $.ajax({
    //        type: "POST",
    //        url: "Introduction_2.aspx",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        success: function (data) { alert('success'); }
    //    });
    //}
        
    </script>
    <style>
        .productclass {
            display: none;
        }
    </style>

    <asp:Label ID="Name"  runat="server"></asp:Label><asp:Label ID="producttype"  runat="server"></asp:Label>
    <asp:Image ID="Image" runat="server" />  
    <asp:Label ID="size" runat="server"></asp:Label>
    <asp:RadioButtonList ID="SizeButtonList1" runat="server"></asp:RadioButtonList>
    <asp:Label ID="format" runat="server"></asp:Label>
     <asp:RadioButtonList ID="FormatButtonList1" runat="server"></asp:RadioButtonList>
    <asp:Label ID="productclass" runat="server"  CssClass="productclass"></asp:Label>
    <a>數量</a>
    <asp:TextBox runat="server" ID="number"<%-- onblur="money()"--%> type="number" CausesValidation="True" />

    <a>總價</a>     
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    
    <asp:button text="結帳" class="btn btn-primary" OnClick="SubmitBtn_Click" runat="server"/>


</asp:Content>
