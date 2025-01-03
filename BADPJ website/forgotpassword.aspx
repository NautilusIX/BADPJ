<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="BADPJ_website.forgotpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

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

    <script>
        function myFunction() {
            var x = document.getElementById("Tb_ForgotPassword");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }
        function myFunction1() {
            var x = document.getElementById("Tb_CfmForgotPassword");
            if (x.type === "password") {
                x.type = "text";
            } else {
                x.type = "password";
            }
        }
    </script>
</head>

<body>
    <!-- start preloader -->
    <div class="preloader" id="preloader"></div>
    <!-- end preloader -->

    <!-- Scroll To Top Start-->
    <a href="javascript:void(0)" class="scrollToTop"><i class="fas fa-angle-double-up"></i></a>
    <!-- Scroll To Top End -->
    
    <!-- Login Reg In start -->
    <section class="login-reg">
        <div class="overlay pb-120">
            <div class="container">
                <div class="top-area pt-4 mb-30">
                    <div class="row d-flex align-items-center">
                        <div class="col-sm-5 col">
                            <a class="back-home" href="index.aspx">
                                <img src="assets/images/icon/left-icon.png" alt="image">
                                Back To GetGud
                            </a>
                        </div>
                        <div class="col-sm-2 text-center col">
                            <a href="index-3.aspx">
                                <img src="assets/images/GGlogo6.png" alt="image">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row pt-120 d-flex justify-content-center">
                    <div class="col-lg-6">
                        <div class="login-reg-main text-center">
                            <div class="form-area">
                                <div class="section-text">
                                    <h4>Forgot Password?</h4>
                                    <p>Enter your new password</p>
                                </div>
                                <form action="#" runat="server">
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Label ID="lbl_ErrorMessage1" runat="server" Text="" ForeColor="Red"></asp:Label>

                                            <div class="single-input">
                                                <label for="email">Email Address</label>
                                                <div class="input-box">
                                                    <asp:TextBox ID="Tb_ForgotEmail" placeholder="Enter Your Email" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="single-input">
                                                <label for="passInput">Password</label>
                                                <div class="input-box">
                                                    <asp:TextBox ID="Tb_ForgotPassword" placeholder="Enter New Password" runat="server" type="password"></asp:TextBox>
                                                    <img class="showPass" onclick="myFunction()" src="assets/images/icon/show-hide.png" alt="icon">
                                                    <%--<input type="checkbox" onclick="myFunction()">--%>
                                                </div>
                                                <asp:RequiredFieldValidator ID="rfv_ForgotPassword" ForeColor="Red" ControlToValidate="Tb_ForgotPassword" runat="server" ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="single-input">
                                                <label for="passInput">Confirm Password</label>
                                                <div class="input-box">
                                                    <asp:TextBox ID="Tb_CfmForgotPassword" placeholder="Confirm New Password" runat="server" type="password"></asp:TextBox>
                                                    <img class="showPass" onclick="myFunction1()" src="assets/images/icon/show-hide.png" alt="icon">
                                                    <%--<input type="checkbox" onclick="myFunction()">--%>
                                                </div>
                                                <asp:CompareValidator ID="cv_CfmForgotPassword" ForeColor="Red"  runat="server" ErrorMessage="Enter Same Password" ControlToCompare="Tb_ForgotPassword" ControlToValidate="Tb_CfmForgotPassword"></asp:CompareValidator>

                                            </div>

                                            <div class="single-input">
                                                <label for="Tb_OTP_Forgot">Enter OTP</label>
                                                <div class="input-box">
                                                    <%--<input type="text" id="phoneInput" placeholder="Enter Your Phone Number">--%>
                                                    <asp:TextBox type="text" ID="Tb_OTPForgot" placeholder="Enter OTP" runat="server"></asp:TextBox>
                                                    <asp:Button ID="Btn_GetOTPForgot" runat="server" class="cmn-btn alt" Text="Get OTP" OnClick="Btn_GetOTPForgot_Click" />
                                                    <%--<asp:Button ID="Btn_VerifyOTP" runat="server" class="cmn-btn" Text="Verify OTP" OnClick="Btn_VerifyOTP_Click" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button ID="Btn_NewPassword" class="cmn-btn mt-40 w-100" runat="server" Text="Update" OnClick="Btn_NewPassword_Click" />
                                    

                                </form>

                                <div class="reg-with">
                                    <div class="or">
                                        <p>OR</p>
                                    </div>
                                    <div class="social">
                                        <ul class="footer-link d-flex justify-content-center align-items-center">
                                            <li><a href="javascript:void(0)"><i class="fab fa-facebook-f"></i></a></li>
                                            <li><a href="javascript:void(0)"><i class="fab fa-google"></i></a></li>
                                            <li><a href="javascript:void(0)"><i class="fab fa-twitch"></i></a></li>
                                            <li><a href="javascript:void(0)"><i class="fab fa-apple"></i></a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                            <div class="account mt-30">
                                <p>Back to Login?<a href="login.aspx">Here</a></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Login Reg In end -->

    <!--==================================================================-->
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/js/jquery-ui.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/fontawesome.js"></script>
    <script src="assets/js/plugin/slick.js"></script>
    <script src="assets/js/plugin/ion.rangeSlider.min.js"></script>
    <script src="assets/js/plugin/swiper.js"></script>
    <script src="assets/js/plugin/jquery.nice-select.min.js"></script>
    <script src="assets/js/plugin/counter.js"></script>
    <script src="assets/js/plugin/jquery.downCount.js"></script>
    <script src="assets/js/plugin/waypoint.min.js"></script>
    <script src="assets/js/plugin/jquery.magnific-popup.min.js"></script>
    <script src="assets/js/plugin/wow.min.js"></script>
    <script src="assets/js/plugin/plugin.js"></script>
    <script src="assets/js/main.js"></script>
</body>
</html>
