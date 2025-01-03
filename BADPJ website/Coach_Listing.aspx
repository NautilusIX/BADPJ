<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="Coach_Listing.aspx.cs" Inherits="BADPJ_website.Coach_Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Banner Section start -->
    <section class="banner-section inner-banner coaching">
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
                                <h1>Coach Listings</h1>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Coach Listings</li>
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
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" DataKeyNames="listing_id" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" CssClass="auto-style3" Width="1327px" OnRowDeleting="GridView2_RowDeleting" OnRowUpdating="GridView2_RowUpdating" RowStyle-ForeColor="White" HeaderStyle-ForeColor="White" Height="408px" style="margin-left: 116px; margin-top: 0px">
        <Columns>
           <asp:BoundField DataField="listing_id" HeaderText="listing_id" SortExpression="listing_id" InsertVisible="False" ReadOnly="False" ControlStyle-ForeColor="Black" />
            <asp:ImageField DataImageUrlField="Coach_Image" HeaderText="Coach_Image" SortExpression="Coach_Image" ControlStyle-Width="80" ControlStyle-ForeColor="Black">
                <ControlStyle Width="80px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="Coach_Desc" HeaderText="Coach_Desc" SortExpression="Coach_Desc" ControlStyle-ForeColor="Black" />
            <asp:BoundField DataField="Coach_Price" HeaderText="Coach_Price" SortExpression="Coach_Price"  ControlStyle-ForeColor="Black" />
            <asp:BoundField DataField="Coach_Name" HeaderText="Coach_Name" SortExpression="Coach_Name" ControlStyle-ForeColor="Black"  />
            <asp:BoundField DataField="Game" HeaderText="Game" SortExpression="Game" ControlStyle-ForeColor="Black" />

     
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />

     
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:GetGudDB %>" DeleteCommand="DELETE FROM Listing WHERE listing_id = @listing_id" SelectCommand="SELECT [Listing_ID], [Coach_Desc], [Coach_Image], [Coach_Price], [Coach_Name], [Game] FROM [Listing]"></asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <!-- Banner Section end -->
    <!--==================================================================-->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery-ui.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/fontawesome.js"></script>
    <script src="assets/js/plugin/slick.js"></script>
    <script src="assets/js/plugin/swiper.js"></script>
    <script src="assets/js/plugin/jquery.nice-select.min.js"></script>
    <script src="assets/js/plugin/counter.js"></script>
    <script src="assets/js/plugin/waypoint.min.js"></script>
    <script src="assets/js/plugin/jquery.magnific-popup.min.js"></script>
    <script src="assets/js/plugin/wow.min.js"></script>
    <script src="assets/js/plugin/plugin.js"></script>
    <script src="assets/js/main.js"></script>
</asp:Content>
