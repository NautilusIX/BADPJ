<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BookingView.aspx.cs" Inherits="BADPJ_website.BookingView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 300px;
            margin-right: 206px;
            margin-top: 0px;
        }
        .Header2{
            margin-left:450px;
        }
        .auto-style2 {
            margin-left: 299px;
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
    <h2 class="Header2">VIEW YOUR BOOKINGS</h2>
    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" 
        DataKeyNames="Booking_ID" OnRowCancelingEdit="gvProduct_RowCancelingEdit" OnRowDeleting="gvProduct_RowDeleting" 
        OnRowEditing="gvProduct_RowEditing" OnRowUpdating="gvProduct_RowUpdating" RowStyle-ForeColor="White" HeaderStyle-ForeColor="White" CssClass="auto-style1" Width="1014px" Height="328px">
    <Columns>
        <asp:BoundField DataField="Booking_ID" HeaderText="Booking ID" ReadOnly="True" ControlStyle-ForeColor="Black" HeaderStyle-BackColor="#0ECDB9" >
<ControlStyle ForeColor="Black"></ControlStyle>

<HeaderStyle BackColor="#0ECDB9"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Booking_date" HeaderText="Booking Date" ControlStyle-ForeColor="Black"  HeaderStyle-BackColor="#0ECDB9" >
<ControlStyle ForeColor="Black"></ControlStyle>

<HeaderStyle BackColor="#0ECDB9"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Price" HeaderText="Price" ReadOnly="True" ControlStyle-ForeColor="Black" HeaderStyle-BackColor="#0ECDB9" >
<ControlStyle ForeColor="Black"></ControlStyle>

<HeaderStyle BackColor="#0ECDB9"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Booking_time" HeaderText="Time" ControlStyle-ForeColor="Black" HeaderStyle-BackColor="#0ECDB9" >
<ControlStyle ForeColor="Black"></ControlStyle>

<HeaderStyle BackColor="#0ECDB9"></HeaderStyle>
        </asp:BoundField>
        <asp:BoundField DataField="Duration" HeaderText="Duration" ControlStyle-ForeColor="Black" HeaderStyle-BackColor="#0ECDB9" >
<ControlStyle ForeColor="Black"></ControlStyle>

<HeaderStyle BackColor="#0ECDB9"></HeaderStyle>
        </asp:BoundField>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ControlStyle-ForeColor="White" HeaderStyle-BackColor="#0ECDB9" >
<ControlStyle ForeColor="White"></ControlStyle>

<HeaderStyle BackColor="#0ECDB9"></HeaderStyle>
        </asp:CommandField>
    </Columns>

<HeaderStyle ForeColor="White"></HeaderStyle>

<RowStyle ForeColor="White" BackColor="#3F3BC3"></RowStyle>
</asp:GridView>
    <br />
    <br />
    <asp:Button ID="btn_AddProduct" runat="server" Text="Add Bookings" OnClick="btn_AddProduct_Click" CssClass="cmn-btn auto-style2" Width="1022px"  />
    <br />
    <br />
</asp:Content>
