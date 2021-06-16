<%@ Page Title="ManagerPage" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ManagerPage.aspx.cs" Inherits="WebApplication2.ManagerPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>ManagerPage</title>

    <asp:Label ID="Label1" runat="server" Text="Manager Page" ForeColor="Black" Font-Size="X-Large"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="商品總覽" ForeColor="Black" Font-Size="Large"></asp:Label><br />
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList><br />
    <asp:Label ID="Label3" runat="server" Text=" " Font-Size="Larger"></asp:Label><br />
    <div>
        <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="true" PageSize="15" PagerSettings-Mode="Numeric">
            <PagerTemplate>
                <table>
                    <tr>
                        <td style="text-align: right">第&nbsp;<asp:Label ID="lblPageIndex" runat="server" Text="<%#((GridView)Container.Parent.Parent).PageIndex + 1 %>" ForeColor="Blue"></asp:Label>&nbsp;頁，
                        共&nbsp;<asp:Label ID="lblPageCount" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageCount %>" ForeColor="Blue"></asp:Label>&nbsp;頁，
                        <asp:LinkButton ID="btnFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" Text="第一頁" CssClass="btn btn-primary btn-xs"></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton ID="btnPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" Text="上一頁" CssClass="btn btn-primary btn-xs"></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton ID="btnNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" Text="下一頁" CssClass="btn btn-primary btn-xs"></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton ID="btnLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" Text="最後一頁" CssClass="btn btn-primary btn-xs"></asp:LinkButton>&nbsp;&nbsp;
                        跳到第<asp:TextBox ID="txtNewPageIndex" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageIndex + 1%>" Width="100px"></asp:TextBox>頁&nbsp;
                        每頁顯示<asp:TextBox ID="TextBox_PageSize" runat="server" Text="<%# ((GridView)Container.Parent.Parent).PageSize %>" Width="100px"></asp:TextBox>筆&nbsp;
                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-1" CommandName="Page" Text="GO" CssClass="btn btn-primary btn-xs"></asp:LinkButton>&nbsp;
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
        </asp:GridView>
    </div>
    <br />
    <asp:Button ID="Button1" runat="server" Text="新增商品" OnClick="Button1_Click" /><asp:Button ID="Button2" runat="server" Text="更新商品" OnClick="Button2_Click" /><br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
</asp:Content>
