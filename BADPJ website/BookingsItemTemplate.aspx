<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BookingsItemTemplate.aspx.cs" Inherits="BADPJ_website.BookingsItemTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <h3 style="text-align:center;">YOUR BOOKINGS</h3>
    <p style="text-align:center;"><em><strong>AT A GLANCE</strong></em></p>
    <table>
    </table>
        <div class="text-center">
    <asp:DataList ID="DataList1" runat="server" DataKeyField="Booking_ID" DataSourceID="SqlDataSource1" Height="293px" Width="932px" RepeatColumns="4" RepeatDirection="Horizontal" FooterStyle-HorizontalAlign="Center" style="margin-left: 283px">
<FooterStyle HorizontalAlign="Center"></FooterStyle>
        <ItemTemplate>
            <table>
                <tr>
                    <td style="text-align:center; background-color:#3f3bc3;">
                        <asp:Label ID="Label7" runat="server" Text="Booking ID:" Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Booking_ID") %>' ForeColor="White"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:center; background-color:#3f3bc3;">
                        <asp:Label ID="Label8" runat="server" Text="Booking Date:" Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Booking_date") %>' ForeColor="White"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:center; background-color:#3f3bc3;">
                        <asp:Label ID="Label9" runat="server" Text="Time:" Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Booking_time") %>'  ForeColor="White"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:center; background-color:#3f3bc3;">
                        <asp:Label ID="Label10" runat="server" Text="Duraton:" Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("Duration") %>'  ForeColor="White"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="text-align:center; background-color:#3f3bc3;">
                        <asp:Label ID="Label6" runat="server" Text="Price: SGD" Font-Bold="True" ForeColor="White"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Price") %>' ForeColor="White"></asp:Label>
                    </td>
                </tr>
            </table>
            <br /><br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#3399FF" />
    </asp:DataList>
        </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GetGudDB %>" SelectCommand="SELECT * FROM [Bookings]"></asp:SqlDataSource>
</asp:Content>
