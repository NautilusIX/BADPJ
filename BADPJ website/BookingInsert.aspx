<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BookingInsert.aspx.cs" Inherits="BADPJ_website.BookingInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 71%;
            margin-bottom: 10px;
            height: 672px;
        }
        .auto-style7 {
             height: 21px;
             width: 920px;
         }
        .auto-style8 {
            width: 920px;
            height: 81px;
        }
        .auto-style9 {
             height: 21px;
             width: 507px;
         }
        .auto-style10 {
            width: 507px;
            height: 81px;
        }
        td{
            color:aliceblue;
        }
        .auto-style11 {
            height: 63px;
            width: 920px;
        }
        .auto-style12 {
            height: 63px;
            width: 507px;
        }
        .auto-style13 {
            height: 54px;
            width: 920px;
        }
        .auto-style14 {
            height: 54px;
            width: 507px;
        }
        .auto-style15 {
            height: 57px;
            width: 920px;
        }
        .auto-style16 {
            height: 57px;
            width: 507px;
        }
        .Header1 {
            margin-left: 50px;
        }
         .auto-style17 {
             height: 21px;
             width: 920px;
             text-align: center;
         }
         .auto-style18 {
             height: 21px;
             width: 1070px;
         }
         .auto-style19 {
             width: 1070px;
             height: 81px;
         }
         .auto-style20 {
             height: 63px;
             width: 1070px;
         }
         .auto-style21 {
             height: 54px;
             width: 1070px;
         }
         .auto-style22 {
             height: 57px;
             width: 1070px;
         }
         .auto-style23 {
             margin-left: 46;
         }
    </style>
    <!-- Banner Section start -->
    <section class="banner-section inner-banner coaching coaching-details">
        <div class="overlay">
            <div class="banner-content">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-md-10">
                            <div class="main-content">
                                <h1>Bookings</h1>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Bookings</li>
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

    <!-- Banner Section end -->

    <h2 class="Header1">Reserve your bookings</h2>
    <table class="auto-style6">
        <tr>
            <td class="auto-style17">Booking ID</td>
            <td class="auto-style18">
                <asp:TextBox Forecolor="Black" ID="tb_BookingID" runat="server" Width="593px"></asp:TextBox>
            </td>
            <td class="auto-style9">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tb_BookingID" ErrorMessage="Required Field" ForeColor="Red" Width="233px"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Booking Time</td>
            <td class="auto-style19">
                <asp:TextBox Forecolor="Black"  ID="tb_BookingTime" runat="server" Height="48px" Width="588px"></asp:TextBox>
            </td>
            <td class="auto-style10">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tb_BookingTime" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Price</td>
            <td class="auto-style20">
                <asp:TextBox Forecolor="Black" ID="tb_Price" ReadOnly="True" runat="server" Width="593px"></asp:TextBox>
            </td>
            <td class="auto-style12">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tb_Price" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date</td>
            <td class="auto-style21">
                <asp:TextBox Forecolor="Black" ID="tb_Date" runat="server" TextMode="Date" Width="592px"></asp:TextBox>
            </td>
            <td class="auto-style14">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tb_Date" CssClass="auto-style23" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
          <tr>
            <td class="auto-style15">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Duration</td>
            <td class="auto-style22">
                <asp:TextBox Forecolor="Black"  ID="tb_Duration" runat="server" Width="594px" ></asp:TextBox>
            </td>
            <td class="auto-style16">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tb_Duration" ErrorMessage="Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style18">
                <asp:Label Forecolor="White"  ID="lbl_Result" runat="server" Text=""></asp:Label>
            </td>
            <td class="auto-style9">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style18">
                <asp:Button ID="btn_Insert" runat="server" OnClick="Button1_Click" Text="Pay" Width="591px" class="cmn-btn" />
            </td>
            <td class="auto-style9">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>
