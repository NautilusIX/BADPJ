<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="BADPJ_website.register" %>

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

    <style>
        .gray-button {
            background-color: white;
        }

        .gray-button:hover {
            background-color: gray;
        }
    </style>

    <script>
        function myFunction() {
            var x = document.getElementById("Tb_Password");
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
                            <a href="index.aspx">
                                <img src="assets/images/GGlogo6.png" alt="image">
                            </a>
                        </div>
                    </div>
                </div>
                <div class="row pt-120 d-flex justify-content-center">
                    <div class="col-xxl-6 col-xl-7">
                        <div class="login-reg-main text-center">
                            <div class="form-area">
                                <div class="section-text">
                                    <h4>Create Account</h4>
                                    <p>Sign Up to GetGud and Start Learning!</p>
                                </div>
                                <form action="#" runat="server">
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="single-input">
                                                <label for="Tb_Username">User Name</label>
                                                <div class="input-box">
                                                    <%--<input type="text" id="name" placeholder="Enter User Name">--%>
                                                    <asp:TextBox type="text" ID="Tb_Username" runat="server" placeholder="Enter User Name"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="Rfv_Username" runat="server" ErrorMessage="Please Enter a Username" ControlToValidate="Tb_Username" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="single-input">
                                                <label for="Tb_Email">Email Address</label>
                                                <div class="input-box">
                                                    <%--<input type="text" id="email" placeholder="Enter Your Email">--%>
                                                    <asp:TextBox type="text" ID="Tb_Email" placeholder="Enter Your Email" runat="server"></asp:TextBox>
                                                </div>
                                                <asp:RequiredFieldValidator ID="Rfv_Email" ForeColor="Red" runat="server" ErrorMessage="Please Enter an Email" ControlToValidate="Tb_Email"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="Rev_Email" ForeColor="Red" runat="server" ErrorMessage="Please Enter Valid Email" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="Tb_Email"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="single-input">
                                                <label for="Tb_Password">Password</label>
                                                <div class="input-box">
                                                    <%--<input type="text" id="passInput" placeholder="Enter Your Password">--%>
                                                    <asp:TextBox type="password" ID="Tb_Password" placeholder="Enter Your Password" runat="server"></asp:TextBox>
                                                    <img class="showPass" onclick="myFunction()" src="assets/images/icon/show-hide.png" alt="icon" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="Rfv_Password" ForeColor="Red" runat="server" ErrorMessage="Please Enter a Password" ControlToValidate="Tb_Password"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="single-input">
                                                <label for="Tb_PhoneNo">Phone Number</label>
                                                <div class="input-box">
                                                    <%--<input type="text" id="phoneInput" placeholder="Enter Your Phone Number">--%>
                                                    <asp:TextBox type="text" ID="Tb_PhoneNo" placeholder="Enter Your Phone Number" runat="server"></asp:TextBox>

                                                </div>
                                                <asp:RequiredFieldValidator ID="Rfv_PhoneNo" ForeColor="Red" runat="server" ErrorMessage="Enter a phone number" ControlToValidate="Tb_PhoneNo"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="Rev_PhoneNo" ForeColor="Red" ValidationExpression="^([0-9]{8})$" runat="server" ControlToValidate="Tb_PhoneNo" ErrorMessage="Input Valid Phone Number"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="single-input">
                                                <label for="Tb_OTP">Enter OTP</label>
                                                <div class="input-box">
                                                    <%--<input type="text" id="phoneInput" placeholder="Enter Your Phone Number">--%>
                                                    <asp:TextBox type="text" ID="Tb_OTP" placeholder="Enter OTP" runat="server"></asp:TextBox>
                                                    <asp:Button ID="Btn_GetOTP" runat="server" class="cmn-btn alt" Text="Send OTP" OnClick="Btn_GetOTP_Click" />
                                                    <%--<asp:Button ID="Btn_VerifyOTP" runat="server" class="cmn-btn" Text="Verify OTP" OnClick="Btn_VerifyOTP_Click" />--%>
                                                </div>
                                            </div>

                                            <asp:Label ID="lbl_Message" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </div>
                                        <div class="remember-me">
                                            <label class="checkbox-single d-flex align-items-center">
                                                <span class="left-area">
                                                    <span class="checkbox-area d-flex">
                                                        <input type="checkbox">
                                                        <span class="checkmark"></span>
                                                    </span>
                                                    <span class="item-title d-flex align-items-center">
                                                        <span>You agree with our</span>
                                                        <a href="forgotpassword.aspx">Forgot Password</a>
                                                        <span>And </span>
                                                        <a href="privacy-policy.aspx">privacy policy</a>
                                                    </span>
                                                </span>
                                            </label>
                                        </div>
                                    </div>
                                    <%--<button class="cmn-btn mt-40 w-100">Sign Up</button>--%>
                                    <asp:Button class="cmn-btn mt-40 w-100" ID="Btn_SignUp" runat="server" Text="Sign Up" OnClick="Btn_SignUp_Click" />
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
                                <p>Have an account? <a href="login.aspx">login</a></p>
                                <p>Want to become a Coach? <a href="coachregister.aspx">Click here</a></p>
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
