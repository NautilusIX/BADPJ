<%@ Page Title="" Language="C#" MasterPageFile="~/Coach.Master" AutoEventWireup="true" CodeBehind="Create_Listing.aspx.cs" Inherits="BADPJ_website.Create_Listing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <style type="text/css">
        td {
            color: White
        }

        .auto-style1 {
            width: 372px;
        }

        .auto-style2 {
            width: 615px;
        }

        .auto-style3 {
            width: 687px;
        }
    </style>
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
                                <h1>Create A Listing</h1>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Create A Lisitng</li>
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
    <br />
    <section class="contact-section">
        <div class="container wow fadeInUp">

            <div class="row justify-content-center">
                <div class="col-lg-6">
                    <form action="#">
                        <h4 class="mb-30">CREATE A LISTING</h4>
                        <div class="single-input">
                            <label for="tb_CoachName">Name</label>
                            <br />
                            <asp:TextBox ID="tb_CoachName" ForeColor="White" runat="server" Width="570px" placeholder="Enter Your Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_CoachName" runat="server" ControlToValidate="tb_CoachName" ErrorMessage="Please enter a name " ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="single-input">
                            <label for="tb_CoachDesc">Coach Description</label>
                            <br />
                            <asp:TextBox TextMode="multiline" ForeColor="White" ID="tb_CoachDesc" runat="server" Height="70px" Width="570px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_CoachDesc" runat="server" ControlToValidate="tb_CoachDesc" ErrorMessage="Please enter a decription " ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="single-input">
                            <label for="tb_CoachPrice">Coach Pricing</label>
                            <br />
                            <asp:TextBox ID="tb_CoachPrice" ForeColor="White" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_CoachPrice" runat="server" ControlToValidate="tb_CoachPrice" ErrorMessage="Please enter a  Price for the session" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:CompareValidator ID="cv_CoachPrice" runat="server" ControlToValidate="tb_CoachPrice" ErrorMessage="Only Numeric value is allowed" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                        </div>
                        <div class="single-input">
                            <label for="tb_CoachEmail">Email</label>
                            <br />
                            <asp:TextBox ID="tb_CoachEmail" ForeColor="White" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_CoachEmail" runat="server" ControlToValidate="tb_CoachEmail" ErrorMessage="Please enter a valid email address" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="Rev_CoachEmail" ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tb_CoachEmail"></asp:RegularExpressionValidator>
                            <br />
                        </div>

                        <div class="single-input">
                            <label for="tb_Game">Game</label>
                            <br />
                            <asp:TextBox ID="tb_Game" ForeColor="White" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_GAME" runat="server" ControlToValidate="tb_Game" ErrorMessage="Please enter a Game" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                        </div>

                        <div class="single-input">
                            <label for="">Coach Image</label>
                            <br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <br />
                            <asp:Image ID="Image1" ForeColor="White" runat="server" alt="No Choose" Width="50" />
                            <asp:Label ID="lbl_Result" runat="server" Text=""><<>></asp:Label>
                            <br />
                            <asp:RequiredFieldValidator ID="rfv_CoachImage" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select a Image" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                        <asp:Button class="cmn-btn" ID="btn_Insert" runat="server" Text="Insert" OnClick="btn_Insert_Click" Width="210px" BackColor="#0ECDB9" BorderColor="Cyan" ForeColor="Black" />
                        <asp:Button class="cmn-btn" ID="btn_ListView" runat="server" Text="View Listings" OnClick="btn_ListView_Click" CausesValidation="False" Width="305px" BackColor="#0ECDB9" BorderColor="Cyan" ForeColor="Black" />
                    </form>
                </div>
            </div>
        </div>
    </section>
    <!--FORMS-->
    
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
