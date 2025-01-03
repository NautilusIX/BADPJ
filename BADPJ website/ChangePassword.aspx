﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="BADPJ_website.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>GetGud - Esports and Gaming Courses Website HTML Template</title>

    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/fontawesome.min.css">
    <link rel="stylesheet" href="assets/css/jquery-ui.css">
    <link rel="stylesheet" href="assets/css/plugin/nice-select.css">
    <link rel="stylesheet" href="assets/css/plugin/magnific-popup.css">
    <link rel="stylesheet" href="assets/css/plugin/slick.css">
    <link rel="stylesheet" href="assets/css/plugin/ion.rangeSlider.min.css">
    <link rel="stylesheet" href="assets/css/plugin/swiper.css">
    <link rel="stylesheet" href="assets/css/arafat-font.css">
    <link rel="stylesheet" href="assets/css/plugin/animate.css">
    <link rel="stylesheet" href="assets/css/style.css">

    
</head>
<body>


    <form id="form3" runat="server">
    <!-- start preloader -->
    <%--<div class="preloader" id="preloader"></div>--%>
    <!-- end preloader -->

    <!-- Scroll To Top Start-->
    <a href="javascript:void(0)" class="scrollToTop"><i class="fas fa-angle-double-up"></i></a>
    <!-- Scroll To Top End -->

    <!-- header-section start -->
    <header class="header-section">
        <div class="overlay">
            <div class="container">
                <div class="row d-flex header-area">
                    <nav class="navbar navbar-expand-lg navbar-light">
                        <a class="navbar-brand" href="index.aspx">
                            <img src="assets/images/GGlogo6.png" class="logo" alt="logo">
                        </a>
                        <button class="navbar-toggler collapsed" type="button" data-bs-toggle="collapse"
                            data-bs-target="#navbar-content">
                            <i class="fas fa-bars"></i>
                        </button>
                        <div class="collapse navbar-collapse justify-content-end" id="navbar-content">
                            <ul class="navbar-nav mr-auto mb-2 mb-lg-0">
                                    <li class="nav-item dropdown main-navbar">
                                        <a class="nav-link " href="index.aspx"
                                            data-bs-auto-close="outside">Home</a>

                                    </li>

                                    <li class="nav-item dropdown main-navbar">
                                        <a class="nav-link dropdown-toggle" href="javascript:void(0)"
                                            data-bs-toggle="dropdown" data-bs-auto-close="outside">Bookings</a>
                                        <ul class="dropdown-menu main-menu shadow">
                                            <li><a class="nav-link" href="BookingView.aspx">Edit Your Bookings</a></li>
                                            <li><a class="nav-link" href="BookingsItemTemplate.aspx">View Your Bookings</a></li>
                                            <li><a class="nav-link" href="BookingPDF.aspx">View Invoice</a></li>
                                        </ul>
                                    </li>
                                    <li class="nav-item dropdown main-navbar">
                                        <a class="nav-link" href="see_Listing.aspx">View Coaches</a>
                                    </li>
                                    <li class="nav-item dropdown main-navbar">
                                        <a class="nav-link " href="Review.aspx"
                                            data-bs-auto-close="outside">Review a Coach</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="contact.aspx">Contact Us</a>
                                    </li>
                                </ul>
                            <div class="right-area header-action d-flex align-items-center max-un">
                                <a href="index.aspx" class="cmn-btn"> 
                                   Back
                                   <i class="fas fa-long-arrow-alt-left"></i>
                                </a>
                            </div>
                        </div>
                    </nav>
                </div>
            </div>
        </div>
    </header>

       <!-- Banner Section start -->
    <section class="banner-section inner-banner coach dashboard">
        <div class="overlay">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-8 col-md-10">
                            <div class="main-content">
                                <h2>User Dashboard</h2>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item"><a href="javascript:void(0)">Pages</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">User Dashboard</li>
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
      <!-- Dashboard start -->
    <section class="dashboard-section">
        <div class="overlay pb-120">
            <div class="container">
                <div class="row">
                    <div class="col-xxl-3 col-lg-4 col-md-8 cus-mar">
                        <div class="sidebar-single">
                            <div class="profile-img">
                                <img src="assets/images/user.png" alt="icon">
                            </div>
                            <asp:Label ID="lbl_UserProfile1" runat="server" Font-Bold="True" Text=""></asp:Label>
                            <a href="UserProfile.aspx" class="cmn-btn alt">Back</a>
                        </div>
                        <div class="sidebar-single">
                            <ul>
                                <li>
                                    <a href="UserProfile.aspx" class="active">
                                        <img src="assets/images/icon/dashboard-menu-3.png" class="max-un" alt="icon">
                                        Personal Information
                                    </a>
                                </li>
                                <li>
                                    <a href="MyPayments.aspx">
                                        <img src="assets/images/icon/dashboard-menu-4.png" class="max-un" alt="icon">
                                        My Payments
                                    </a>
                                </li>
                                
                                <li>
                                    <a href="ChangePassword.aspx">
                                        <img src="assets/images/icon/dashboard-menu-6.png" class="max-un" alt="icon">
                                        Change password
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="sidebar-single">
                            <div class="profile-img">
                                <img src="assets/images/icon/help-icon.png" alt="icon">
                            </div>
                            <h5>Do you need help</h5>
                            <p>Just let us know how we can help you and we will try to find a solution as soon as possible.</p>
                            <a href="contact.aspx" class="cmn-btn mt-4">Chat with Us</a>
                        </div>
                    </div>
                    <div class="col-xxl-9 col-lg-8 cus-mar">
                        <div class="single-content">
                            <div class="head-area d-flex align-items-center justify-content-between">
                                <h5>Change password</h5>
                            </div>
                            <div class="main-content table-area">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="single-input">
                                            <label for="tb_CurrentPassword">Current password</label>
                                            <asp:TextBox ID="tb_CurrentPassword" ForeColor="Black" runat="server" placeholder="Enter your Current Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_CurrentPassword" ControlToValidate="tb_CurrentPassword" runat="server" ForeColor="Red" ErrorMessage="Enter Your Current Password"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="single-input">
                                            <label for="tb_NewPassword">New password</label>
                                            <asp:TextBox ID="tb_NewPassword" ForeColor="Black" runat="server" placeholder="Enter your New Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_NewPassword" ControlToValidate="tb_NewPassword" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-12">
                                        <div class="single-input">
                                            <label for="tb_CfmNewPassword">Confirm New password</label>
                                            <asp:TextBox ID="tb_CfmNewPassword" ForeColor="Black" runat="server" placeholder="Confirm New Password"></asp:TextBox>
                                            <asp:CompareValidator ID="cv_CfmNewPassword" Forecolor="Red" runat="server" ErrorMessage="Not The Same as New Password" ControlToCompare="tb_NewPassword" ControlToValidate="tb_CfmNewPassword"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="col-sm-3 col-5">
                                        
                                        <asp:Button ID="btn_ChangePassword" class="cmn-btn w-100 mt-3" runat="server" Text="Change" OnClick="btn_ChangePassword_Click"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Dashboard end -->

  
          
     
     

    
    </form>
</body>
</html>
