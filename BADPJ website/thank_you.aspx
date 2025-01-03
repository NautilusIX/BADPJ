<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="thank_you.aspx.cs" Inherits="BADPJ_website.thank_you" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Banner Section start -->
    <section class="banner-section inner-banner coach cart">
        <div class="overlay">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-8 col-md-10">
                            <div class="main-content">
                                <h2>Thank You For Your Purchase!</h2>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.aspx">Home</a></li>
                                            <li class="breadcrumb-item"><a href="javascript:void(0)">Payment</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Payment Complete</li>
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

  <section class="privacy-content terms">
        <div class="overlay pt-120 pb-120">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-10">
                        <div class="top-wrapper">
                            <h3>Payment Details:</h3>
     <div class="col-12">
         <div class="single-input">
                                                    <label for="cardname">Payment ID:</label>
                                                        <asp:Label runat="server" id="lbl_payment_id_success" Text=""></asp:Label>
                                                </div>
                                                <div class="single-input">
                                                    <label for="cardname">Customer Email:</label>
                                                     <asp:Label runat="server" id="lbl_customer_email_success" Text=""></asp:Label>

                                                </div>
                                                 </div>
                                            <div class="col-6">
                                                <div class="single-input">
                                                    <label for="carddate">Coach Email:</label>
                                                <asp:Label runat="server" id="lbl_coach_email_success" Text=""></asp:Label>    
                                                </div>
                                                 </div>
    <div class="col-6">
                                                

                                   <div class="col-6">
                                                <div class="single-input">
                                                    <label for="cvc">Payment Amount:</label>
                                                   <asp:Label runat="server" id="lbl_payment_amount_success" Text=""></asp:Label>
                                                    </div>
                                                </div>
                            <div class="col-6">
                                                <div class="single-input">
                                                    <label for="cvc">Payment Date:</label>
                                                    <asp:Label ID="lbl_payment_date_success" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                 </div>
                                               <div class="col-6">
                                                <div class="single-input">
                                                    <label for="carddate">Discount Given:</label>
                                                <asp:Label runat="server" id="lbl_discount_given_success" Text=""></asp:Label>    
                                                </div>
                                                 </div>
                                                   <div class="col-6">
                                                <div class="single-input">
                                                    <label for="carddate">Platform Fee:</label>
                                                <asp:Label runat="server" id="lbl_platform_fee_success" Text=""></asp:Label>    
                                                </div>
                                                 </div>
                                                       <div class="col-6">
                                                <div class="single-input">
                                                    <label for="carddate">Payment Status:</label>
                                                <asp:Label runat="server" id="lbl_status_success" Text=""></asp:Label>    
                                                </div>
                                                 </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
