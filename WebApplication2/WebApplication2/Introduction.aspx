<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Introduction.aspx.cs" Inherits="WebApplication2.Introduction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script language='javascript' type='text/javascript'>
        function aa() {
            var pp = $.param({
            });
            $.ajax({
                type: "POST",
                url: "Introduction.aspx/GetData",
                data: JSON.stringify({ 'postData': pp }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) { alert('success'); }
            });
        }
        
    </script>
   
    <div class="container">
        <div class="row">
            <div class="col-12 col-md-3 col-lg-3">
            </div>
            <asp:Panel ID="DivAll" runat="server"/> 
        </div>
    </div>

    <a>數量</a>
    <asp:TextBox runat="server" id="number" onblur="aa()" type="number" />

    <a>總價</a>           
    <asp:button text="結帳" class="btn btn-primary" OnClick="SubmitBtn_Click" runat="server"/>
</asp:Content>
