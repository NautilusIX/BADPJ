<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ReviewInsert.aspx.cs" Inherits="BADPJ_website.ReviewInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 65%;
            margin-bottom: 10px;
        }
        .auto-style7 {
            height: 21px;
            width: 146px;
        }
        .auto-style8 {
            width: 146px;
        }
        .auto-style9 {
            height: 21px;
            width: 130px;
        }
        .auto-style10 {
            width: 130px;
        }
        .auto-style15 {
            width: 146px;
            height: 26px;
        }
        .auto-style16 {
            width: 130px;
            height: 26px;
        }
        td{
            color:aliceblue;
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
                                <h1>Submit a Review</h1>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Reviews</li>
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
    <table class="auto-style6">
        <tr>
            <td class="auto-style7">Email</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_ProductID" ForeColor="Black" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">Customer Name</td>
            <td class="auto-style16">
                <asp:TextBox ID="tb_ProductName" ForeColor="Black" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_name" ForeColor="Red" ControlToValidate="tb_ProductName" runat="server" ErrorMessage="Enter a name"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Description</td>
            <td class="auto-style10">
                <asp:TextBox ID="tb_ProductDesc" ForeColor="Black" runat="server" Height="167px" TextMode="MultiLine" Width="342px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_desc" ForeColor="Red" ControlToValidate="tb_ProductDesc" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Rating</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_UnitPrice" ForeColor="Black" runat="server" placeholder="Rate 1-10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_rate" ForeColor="Red" ControlToValidate="tb_UnitPrice" runat="server" ErrorMessage="Enter a rating"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Date</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_StockLevel" ForeColor="Black" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_date" ForeColor="Red" ControlToValidate="Tb_StockLevel" runat="server" ErrorMessage="Enter a Date"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Your Coach</td>
            <td class="auto-style9">
                <asp:FileUpload ID="FileUpload1" ForeColor="Black" runat="server" />
                <asp:RequiredFieldValidator ID="rfv_upload" ForeColor="Red" ControlToValidate="FileUpload1" runat="server" ErrorMessage="Upload File"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style9">
                <asp:Label ID="lbl_Result" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style9">
                <asp:Button ID="btn_Insert" runat="server" class="cmn-btn" OnClick="Button1_Click" Text="Insert" Width="161px" />
                <asp:Button ID="btn_ProductView" runat="server" class="cmn-btn" Text="View My Reviews" Width="240px" OnClick="btn_ProductView_Click" />

            </td>
        </tr>
    </table>
</asp:Content>
