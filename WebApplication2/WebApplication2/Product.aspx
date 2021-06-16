<%@ Page Title="Product" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WebApplication2.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <title>Product</title>

    <div class="main-menu side-menu">

        <%for(int i=0; i< datanames.Count; i++) 
            {%>
        <a href="Product.aspx?pageclass=<%=(i+1) %>"><%=datanames[i] %></a>
        <% }%>

    </div>
    <!-- our product -->
    <div class="product">
    </div>
    <div class="product-bg">
        <div class="product-bg-white">
            <div class="container">
                <div class="row">
                    <div ID="product_div1" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label1.Text.Split(' ')[0]%>'"> <!--給細項頁面產品資訊 -->
                            <i>
                                <asp:Image ID="Image1" runat="server" Height="200px" Width="150px" />
                            </i>
                            <h3>                                
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </h3>
                        </div>
                    </div>
                    <div ID="product_div2" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label2.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image2" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div3" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label3.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image3" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div4" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label3.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image4" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div5" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label5.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image5" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div6" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label6.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image6" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label6" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div7" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label7.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image7" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label7" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div8" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label8.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image8" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label8" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div9" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label9.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image9" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label9" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div10" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label10.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image10" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label10" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div11" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label11.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image11" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label11" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                    <div ID="product_div12" class="col-xl-3 col-lg-3 col-md-6 col-sm-12" runat="server">
                        <div class="product-box select-area" onclick="location.href='TestPage.aspx?productclass=<%=PageClass%>&producttype=<%=Label12.Text.Split(' ')[0]%>'">
                            <i>
                                <asp:Image ID="Image12" runat="server" Height="200px" Width="150px" /></i>
                            <h3>
                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label></h3>
                        </div>
                    </div>
                </div>
            </div>
    </div>
    </div>
            <!-- 分頁 -->
            <div class="main-menu side-menu">
                <!-- 前一頁 -->
                <%if (NowPage == 1)
                    {%>
                <a href="Product.aspx?pageclass=<%=PageClass %>&pageIndex=<%=1 %>"><<</a>
                <% }
                  else
                    {%>
                <a href="Product.aspx?pageclass=<%=PageClass %>&pageIndex=<%=(NowPage-1) %>"><<</a>
                <% }%>
                <!-- 各頁 -->
                <%for (int i = 1; i <= PageCount; i++) 
                    {%> 
                <a href="Product.aspx?pageclass=<%=PageClass %>&pageIndex=<%=i %>"><%= i %></a>
                <% } %>
                <!-- 後一頁 -->
                <%if (NowPage == PageCount)
                    {%>
                <a href="Product.aspx?pageclass=<%=PageClass %>&pageIndex=<%=PageCount %>">>></a>
                <% }
                  else
                    {%>
                <a href="Product.aspx?pageclass=<%=PageClass %>&pageIndex=<%=(NowPage+1) %>">>></a>
                <% }%>
            </div>
    <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
</asp:Content>
