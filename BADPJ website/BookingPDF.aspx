<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BookingPDF.aspx.cs" Inherits="BADPJ_website.BookingPDF" EnableEventValidation = "false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 55%;
            height: 181px;
            margin-left: 315px;
        }
        .auto-style2 {
            width: 41%;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 241px;
            text-align: center;
            height: 61px;
        }
        .auto-style7 {
            text-align: center;
            height: 61px;
            width: 244px;
        }
        .auto-style8 {
            width: 241px;
            text-align: center;
            height: 60px;
        }
        .auto-style9 {
            text-align: center;
            height: 60px;
            width: 244px;
        }
        .auto-style10 {
            width: 241px;
            text-align: center;
            height: 65px;
        }
        .auto-style11 {
            text-align: center;
            height: 65px;
            width: 244px;
        }
        .auto-style12 {
            margin-right: 204px;
        }
        .auto-style13 {
            margin-left: 316px;
        }
        .auto-style14 {
            text-align: center;
            font-weight: bold;
            font-size: x-large;
        }
        .auto-style15 {
            text-align: center;
            width: 325px;
        }
        .auto-style17 {
            width: 121px;
        }
        .auto-style20 {
            text-align: center;
            height: 162px;
        }
        .auto-style21 {
            margin-bottom: 19;
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


        <div class="auto-style5">
        <div class="auto-style14">
            <h3 style="color:white;">Search Your Invoice</h3><br />
            <br />
        </div>
        <table class="auto-style1" align="center">
            <tr>
                <td class="auto-style20" style="color:white;" colspan="2">Enter Your Booking ID:&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Height="39px" ForeColor="Black" Width="188px" CssClass="offset-sm-0"></asp:TextBox>&nbsp;<br /><br />
                    <asp:Button ID="Button1" runat="server"  Text="Get Invoice" Width="154px" OnClick="Button1_Click" Height="55px" class="cmn-btn" />
                </td>
            </tr>
            <tr>
                <td class="auto-style17">&nbsp;</td>
                <td class="auto-style15">
                    <br />
                    <asp:Label ID="Label9" runat="server" ForeColor="White"></asp:Label>
                </td>
            </tr>
        </table>
            <strong>
        <asp:Label ID="Label3" runat="server" Text="Your Generated Invoice is Given Below:" ForeColor="White"></asp:Label>
            </strong>
        <asp:Panel ID="Panel1" runat="server" Height="762px" Width="1478px" Visible="False" CssClass="auto-style12">
            <div class="auto-style5">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="20px" Text="Invoice Reciept" ForeColor="#FF6600"></asp:Label>
                <br />
            </div>
            <table border="1" class="auto-style2" align="center" style="background:white;">
                <tr>
                    <td class="auto-style6" style="background:#0ECDB9;color:#FF6600;"><b>Booking ID</b></td>
                    <td class="auto-style7">
                        <asp:Label ID="Label5" runat="server" Text="Label" ForeColor="Black" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8" style="background:#0ECDB9;color:#FF6600;" ><b>Booking Date</b></td>
                    <td class="auto-style9">
                        <asp:Label ID="Label6" runat="server" Text="Label" ForeColor="Black" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10" style="background:#0ECDB9;color:#FF6600;" ><b>Price</b></td>
                    <td class="auto-style11">
                        <asp:Label ID="Label7" runat="server" Text="Label" ForeColor="Black"></asp:Label>
                    </td>
                </tr>
            </table>
        <br /><br />
            
            <div class="auto-style5">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="auto-style13" Height="212px" Width="868px" BackColor="White" ForeColor="Black" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="Booking_ID" HeaderText="Booking Id" HeaderStyle-ForeColor="#FF6600" />
                        <asp:BoundField DataField="Booking_date" HeaderText="Date" HeaderStyle-ForeColor="#FF6600" />
                        <asp:BoundField DataField="Booking_time" HeaderText="Booking Time" HeaderStyle-ForeColor="#FF6600" />
                        <asp:BoundField DataField="Duration" HeaderText="Duration" HeaderStyle-ForeColor="#FF6600" />
                        <asp:BoundField DataField="Price" HeaderText="Price" HeaderStyle-ForeColor="#FF6600" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#0ECDB9" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BorderColor="White" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
        <p class="auto-style5">
            <strong>This is Computer Generated Invoice </strong>
        </p>
        <p class="auto-style5">
            <strong><em>GetGud</em></strong></p>
        <p>
            &nbsp;</p>
        <p class="auto-style5">
            <asp:Button ID="Button2" runat="server" Text="Download" Height="54px" OnClick="Button2_Click" Width="184px" CssClass="auto-style21 cmn-btn" BackColor="#0ECDB9" />
        </p>
            </asp:Panel>
            
        </div>
</asp:Content>
