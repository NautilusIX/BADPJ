<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="BADPJ_website.Payment1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <!-- Banner Section start -->
    <section class="banner-section inner-banner coach dashboard">
        <div class="overlay">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-8 col-md-10">
                            <div class="main-content">
                                <h2>Payment</h2>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.asx">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Payment</li>
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

    <!-- Coaching Details start -->
<%--    <section class="coaching-details-second">
        <div class="overlay pb-120">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">--%>
                       <%-- <div class="head-items">
                            <div class="left-profile">
                                <div class="profile-img d-flex justify-content-between">
                                    <img src="assets/images/author-profile-2.png" class="max-un" alt="image">
                                </div>
                               <h3>Payment Details</h3>
                                <div class="text-area">
                                    <p>Participant <span>-</span> 10 hours Pack With</p>
                                    <h4>Jaydon Curtis</h4>
                                    <ul>
                                        <li>
                                            <img src="assets/images/icon/check-3.png" alt="icon">
                                            <span>Booking Time & Date</span>
                                        </li>
                                        <li>
                                            <span class="dot">......</span>
                                        </li>
                                        <li>
                                            <img src="assets/images/icon/check-3.png" alt="icon">
                                            <span>Payment</span>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="right-profile">
                                <a href="booking-details-2.html" class="cmn-btn">Change</a>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="content-area mt-60">
                    <div class="section-text">
                        <h5 class="mb-2">Payment details</h5>
                        <p>Double check your details before paying</p>
                        
                    </div>--%>
    <section class="privacy-content terms">
        <div class="overlay pt-120 pb-120">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-10">
                        <div class="top-wrapper">
                    <div class="row card-items">
                        <div class="col-xl-9 col-lg-8">
                              
                                <%--<divclass="col-12">
                                                <%--<div class="single-input">
                                                    <label for="cardname">Payments ID</label>
                                                    <asp:TextBox ID="tb_Payment_ID" runat="server"></asp:TextBox>
                                                </div>--%>
                            <h3>Payment Details</h3>

                                            <div class="col-12">
                                                <div class="single-input">
                                                    <label for="cardname">Customer Email:</label>
                                                    <asp:Label ID="lbl_customer_email" runat="server" Text=""></asp:Label>
                                                    </div>
                                                 </div>
                                            <div class="col-6">
                                                <div class="single-input">
                                                    <label for="carddate">Coach Email:</label>
                                                    <asp:Label ID="lbl_coach_email" runat="server" Text=""></asp:Label>
                                                    <%--<asp:TextBox ID="tb_coach_email" runat="server" ForeColor="Black" CausesValidation="True"></asp:TextBox>--%>
                                                </div>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Field required" ControlToValidate="tb_coach_email" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                            </div>

                                   <div class="col-6">
                                                <div class="single-input">
                                                    <label for="cvc">Payment Amount:</label>
                                                    <asp:Label ID="lbl_payment_amount" runat="server" Text=""></asp:Label>
                                                </div>
                                                </div>
                            <div class="col-6">
                                                <div class="single-input">
                                                    <label for="cvc">Payment Date:</label>
                                                    <asp:Label ID="lbl_payment_date" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                 </div>
      <div class="col-6">
                                                <div class="single-input">
                                                    <label for="cvc">Discount Given:</label>
                                                    <asp:Label ID="lbl_discount_given" runat="server" Text=""></asp:Label>
                                                    </div>
                                                 </div>     
                            <div class="col-6">
                                                <div class="single-input">
                                                    <label for="cvc">Platform Fee(10%):</label>
                                                    <asp:Label ID="lbl_platform_fee" runat="server" Text=""></asp:Label>
                                                    </div>
                                                 </div>     


    


                                <div class="btn-area mt-30">

                                    <asp:Button ID="Payment" runat="server"  class="cmn-btn mt-40 w-100" Text="Confirm" OnClick="btn_Payment" ForeColor="Black"/>
                                    

                                </div>
                        
                            <div class="protection d-flex align-items-start">
                                

                                <img src="assets/images/icon/protection.png" class="max-un" alt="icon">
                                <p class="mdr">For your own protection and for GetGud to assist in any potential
                                    disputes, it's important that you never make any payments outside of the platform.
                                </p>
                            </div>
                        </div>
                    </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
