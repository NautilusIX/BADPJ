<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="BADPJ_website.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Banner Section start -->
    <section class="banner-section inner-banner coach contact">
        <div class="overlay">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-8 col-md-10">
                            <div class="main-content">
                                <h2>Contact Us</h2>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item"><a href="javascript:void(0)">Pages</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Contact Us</li>
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

    <!-- Contact Info start -->
    <section class="contact-info">
        <div class="overlay pb-120">
            <div class="container">
                <div class="row cus-mar">
                    <div class="col-lg-4 col-md-6">
                        <div class="single-info">
                            <div class="icon-area">
                                <img src="assets/images/icon/headphones.png" alt="icon">
                            </div>
                            <h5>Help & Support</h5>
                            <p>support@egamlio.com</p>
                            <span>(219) 555-0114</span>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="single-info">
                            <div class="icon-area">
                                <img src="assets/images/icon/sales.png" alt="icon">
                            </div>
                            <h5>sales</h5>
                            <p>support@egamlio.com</p>
                            <span>(480) 555-0103</span>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="single-info">
                            <div class="icon-area">
                                <img src="assets/images/icon/press.png" alt="icon">
                            </div>
                            <h5>press</h5>
                            <p>support@egamlio.com</p>
                            <span>(219) 555-0114</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Contact Info end -->

    <!-- Contact start -->
    <section class="contact-section">
        <div class="overlay pb-120">
            <div class="container wow fadeInUp">
                <div class="row justify-content-center">
                    <div class="col-lg-6">
                        <div class="section-text">
                            <h5 class="sub-title">Contact</h5>
                            <h2 class="title">Get in touch  today!</h2>
                            <p>We'd love to hear from you. Leave us a message using the form.Our team of experts welcome the chance to answer your questions</p>
                        </div>
                        <div class="social">
                            <p class="mdr mb-3">Follow us on social media</p>
                            <ul class="footer-link d-flex align-items-center">
                                <li><a href="javascript:void(0)"><i class="fab fa-facebook-f"></i></a></li>
                                <li><a href="javascript:void(0)"><i class="fab fa-twitter"></i></a></li>
                                <li><a href="javascript:void(0)"><i class="fab fa-twitch"></i></a></li>
                                <li><a href="javascript:void(0)"><i class="fab fa-youtube"></i></a></li>
                                <li><a href="javascript:void(0)"><i class="fab fa-linkedin"></i></a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <form action="#">
                            <h4 class="mb-30">Drop Us a Line</h4>
                            <div class="single-input">
                                <label for="reviewName">Name</label>
                                <input type="text" id="reviewName" placeholder="Enter Your Name">
                            </div>
                            <div class="single-input">
                                <label for="reviewEmail">Email</label>
                                <input type="text" id="reviewEmail" placeholder="Enter Your Email">
                            </div>
                            <div class="single-input">
                                <label for="reviewEmail">My query is about</label>
                                <select>
                                    <option value="1">Select a Support Category</option>
                                    <option value="2">Category 1</option>
                                    <option value="3">Category 2</option>
                                    <option value="4">Category 3</option>
                                </select>
                            </div>
                            <div class="single-input">
                                <label for="reviewMessage">Message</label>
                                <textarea id="reviewMessage" cols="30" rows="5" placeholder="Hi there! I would like to get in touch because..."></textarea>
                            </div>
                            <button class="cmn-btn">Send Message</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Contact end -->

</asp:Content>
