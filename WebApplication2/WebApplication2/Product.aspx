<%@ Page Title="product" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebApplication2.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Product</title>

    <div class="main-menu side-menu">
        <a href="Product.aspx">SPA淋浴柱</a>
        <a href="Product2.aspx">SPA花灑龍頭</a>
        <a href="Product3.aspx">崁牆式系列</a>
        <a href="Product4.aspx">47H龍頭系列</a>
        <a href="Product5.aspx">台久龍頭系列</a>
        <a href="Product6.aspx">RO龍頭系列</a>
        <a href="Product7.aspx">水塔進水器系列</a>
        <a href="Product8.aspx">銅.不銹鋼球塞.逆止系列</a>
        <a href="Product9.aspx">塑膠另件系列</a>
    </div>
    <!-- our product -->
    <div class="product">
    </div>
    <div class="product-bg">
        <div class="product-bg-white">
            <div class="container">
                <div class="row">
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area" onclick="window.location='http://google.com';">
                            <i>
                                <asp:Image ID="Image1" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image2" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image3" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image4" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image5" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image6" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image7" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image8" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image9" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image10" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image11" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-6 col-sm-12">
                        <div class="product-box select-area">
                            <i>
                                <asp:Image ID="Image12" runat="server" Height="200px" Width="100px" /></i>
                            <h3>
                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>
            <!-- 分頁 -->
            <div class="main-menu side-menu">
                <!-- 前一頁 -->
                <%if (NowPage == 1)
                    {%>
                <a href="Product.aspx?pageIndex=<%=1 %>"><<</a>
                <% }
                  else
                    {%>
                <a href="Product.aspx?pageIndex=<%=(NowPage-1) %>"><<</a>
                <% }%>
                <!-- 各頁 -->
                <%for (int i = 1; i <= PageCount; i++) 
                    {%> 
                <a href="Product.aspx?pageIndex=<%=i %>"><%= i %></a>
                <% } %>
                <!-- 後一頁 -->
                <%if (NowPage == PageCount)
                    {%>
                <a href="Product.aspx?pageIndex=<%=PageCount %>">>></a>
                <% }
                  else
                    {%>
                <a href="Product.aspx?pageIndex=<%=(NowPage+1) %>">>></a>
                <% }%>
            </div>
</asp:Content>
