<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="see_Listing.aspx.cs" Inherits="BADPJ_website.see_Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Banner Section start -->
    <style>
        .nice-select .option:hover, .nice-select .option.focus, .nice-select .option.selected.focus {
            color: black !important;
        }

        .nice-select .list {
            background-color: #212472 !important;
        }


        .nice-select {
            background-color: #212472 !important;
        }
    </style>
    <section class="banner-section inner-banner coaching coaches">
        <div class="overlay">
            <div class="shape-area">
                <img src="assets/images/icon/crystal.png" class="obj-1" alt="image">
                <img src="assets/images/icon/ether.png" class="obj-2" alt="image">
            </div>
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-md-10">
                            <div class="main-content">
                                <h1>Coaches</h1>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Coaches</li>
                                        </ol>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Banner Section end -->
    <!-- Filter Section start -->
    <section class="filter-option">
        <div class="container">
            <div class="row gap-4 justify-content-between align-items-center">
                <div class="col-xxl-6 col-xl-7 flex-wrap position-relative d-flex align-items-center gap-4">
                    <p><b>Price Filter:</b></p>
                    <div class="single-item">
                        <div class="filter-area seller-area d-flex align-items-center">

                            <asp:DropDownList ID="ddllh" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddllh_SelectedIndexChanged">
                                <asp:ListItem Text="All" Value="" />
                                <asp:ListItem Text="Low to High" Value="LH" />
                                <asp:ListItem Text="High to Low" Value="HL" />

                            </asp:DropDownList>
                            <%--<button class="cmn-btn alt">Seller Details</button>--%>
                        </div>

                    </div>

                    <p><b>Game Filter:</b></p>
                    <div class="single-item">
                        <div class="filter-area budget-area d-flex align-items-center">
                            <asp:DropDownList ID="ddlgames" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlgames_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="single-item">
                        <div class="top-area d-xxl-flex justify-content-center">
                            <%--<form action="#" class="w-100">--%>
                            <div class="form-group d-flex justify-content-between align-items-center">
                                <div class="input-area d-flex align-items-center flex-auto">
                                    <img src="assets/images/icon/search-icon-2.png" alt="icon">
                                    <input type="text" placeholder="Search Coach" runat="server" id="txtsearch">
                                </div>

                                <%--<button runat="server" class="cmn-btn alt"  >Find Now</button>--%>
                            </div>
                            <%--</form>--%>
                        </div>
                    </div>


                    <div class="single-item">
                        <div class="filter-area budget-area d-flex align-items-center">
                            <asp:Button ID="btnsearch" runat="server" Text="Find Now" CssClass="cmn-btn alt" OnClick="btnsearch_Click" />
                            <asp:Button ID="btnreset" runat="server" Text="Reset Filter" CssClass="cmn-btn alt " OnClick="btnreset_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </section>
    <!-- Filter Section end -->
    <p id="lbnotfound" runat="server" visible="false"><b class="text-danger">Not Found</b></p>
    <asp:DataList ID="DataList1" runat="server" DataKeyField="Listing_ID" Height=" 293px" Width="1030px" RepeatColumns="3" RepeatDirection="Horizontal" Style="margin-right: 243px; margin-top: 17px; margin-left: 284px;" OnSelectedIndexChanged="BtnBook_Click" AutoPostBack="true">
        <ItemTemplate>
            <table>
                <tr>
                    <td style="text-align: center; background-color: #3f3bc3">
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval ("Coach_Name") %>' Font-Bold="true" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Image ID="imageShow" runat="server" Height="279px" Width="278px" BorderColor="#0ECDB9" BorderWidth="1px" ImageUrl='<%# Eval ("Coach_Image") %>' />
                    </td>
                </tr>

                <tr>
                    <td style="text-align: center; background-color: #3f3bc3">
                        <asp:Label ID="emailLabel" runat="server" Text='<%# Eval ("coach_email") %>' Font-Bold="true" ForeColor="White"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td style="text-align: center; background-color: #3f3bc3">
                        <asp:Label ID="gameLabel" runat="server" Text='<%# Eval ("Game") %>' Font-Bold="true" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; background-color: #3f3bc3">
                        <asp:Label ID="descLabel" runat="server" Text='<%# Eval ("Coach_Desc") %>' Font-Bold="true" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; background-color: #3f3bc3">
                        <asp:Label ID="priceLabel" runat="server" Text="Price: $ " Font-Bold="true" ForeColor="White" Style="text-align: center"></asp:Label>
                        <asp:Label ID="priceLabel2" runat="server" Text='<%# Eval ("Coach_Price") %>' Font-Bold="true" ForeColor="White" Style="text-align: center"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="BtnBook" CssClass="cmn-btn alt" runat="server" Text="Book" BackColor="#0ECDB9" BorderColor="Purple" ForeColor="Black" Font-Bold="true" OnClick="BtnBook_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <br />
    <br />
    <!-- Start of ChatBot (www.chatbot.com) code -->
    <script type="text/javascript">
        window.__be = window.__be || {};
        window.__be.id = "63e3639896b27800077f73e3";
        (function () {
            var be = document.createElement('script'); be.type = 'text/javascript'; be.async = true;
            be.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'cdn.chatbot.com/widget/plugin.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(be, s);
        })();
    </script>
    <!-- End of ChatBot code -->
    <script>(function () { var pp = document.createElement('script'), ppr = document.getElementsByTagName('script')[0]; stid = 'YWdWZmR5UHZrN0RwNFkvK1IwTzdTZz09'; pp.type = 'text/javascript'; pp.async = true; pp.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 's01.live2support.com/dashboardv2/chatwindow/'; ppr.parentNode.insertBefore(pp, ppr); })();</script>

</asp:Content>
