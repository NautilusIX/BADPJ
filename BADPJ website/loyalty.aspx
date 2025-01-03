<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="loyalty.aspx.cs" Inherits="BADPJ_website.loyalty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Banner Section start -->
    <section class="banner-section inner-banner loyalty-banner">
        <div class="overlay">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-8 col-md-10">
                            <div class="main-content">
                                <h2>Loyalty Program</h2>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item"><a href="javascript:void(0)">Pages</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Loyalty Program</li>
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

    <!-- Loyalty Program start -->
    <section class="loyalty-program">
        <div class="overlay pt-120 pb-120">
            <div class="container wow fadeInUp">
                <div class="row justify-content-center">
                    <div class="col-lg-8">
                        <div class="section-text text-center">
                            <h5 class="sub-title">GetGud's loyalty system</h5>
                            <h2 class="title">Loyalty Program</h2>
                            <p>Loyalty program consists of four different tiers, offering various cashback amounts</p>
                        </div>
                    </div>
                </div>
                <div class="row cus-mar">
                    <div class="col-xl-3 col-sm-6">
                        <div class="single-program">
                            <div class="icon-area">
                                <img src="assets/images/icon/tier-icon-1.png" alt="image">
                            </div>
                            <h4>Tier 1</h4>
                            <p class="xlr">100 SGD spent</p>
                            <span class="mdr">Life-Time 1% Cashback</span>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6">
                        <div class="single-program">
                            <div class="icon-area">
                                <img src="assets/images/icon/tier-icon-2.png" alt="image">
                            </div>
                            <h4>Tier 2</h4>
                            <p class="xlr">200 SGD spent</p>
                            <span class="mdr">Life-Time 2% Cashback</span>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6">
                        <div class="single-program">
                            <div class="icon-area">
                                <img src="assets/images/icon/tier-icon-3.png" alt="image">
                            </div>
                            <h4>Tier 3</h4>
                            <p class="xlr">300 SGD spent</p>
                            <span class="mdr">Life-Time 3% Cashback</span>
                        </div>
                    </div>
                    <div class="col-xl-3 col-sm-6">
                        <div class="single-program">
                            <div class="icon-area">
                                <img src="assets/images/icon/tier-icon-4.png" alt="image">
                            </div>
                            <h4>Tier 4</h4>
                            <p class="xlr">400 SGD spent</p>
                            <span class="mdr">Life-Time 5% Cashback</span>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <!-- Loyalty Program end -->
</asp:Content>
