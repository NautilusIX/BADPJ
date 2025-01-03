<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="BADPJ_website.Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 378px;
            margin-right: 206px;
        }
        .auto-style2 {
            margin-left: 380px;
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
                                <h1>View all Reviews</h1>
                                <div class="breadcrumb-area">
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb d-flex align-items-center">
                                            <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                                            <li class="breadcrumb-item active" aria-current="page">Review</li>
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
    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" 
        DataKeyNames="Product_ID" OnRowCancelingEdit="gvProduct_RowCancelingEdit" OnRowDeleting="gvProduct_RowDeleting" 
        OnRowEditing="gvProduct_RowEditing" OnRowUpdating="gvProduct_RowUpdating" RowStyle-ForeColor="White" HeaderStyle-ForeColor="White" CssClass="auto-style1" Width="941px">
    <Columns>
        <asp:BoundField DataField="Product_ID" ReadOnly="True" HeaderText="Email"  ControlStyle-BackColor="White"/>
        <asp:BoundField DataField="Product_Name" HeaderText="Customer Name" ControlStyle-ForeColor="Black"/>
        <asp:BoundField DataField="Product_Desc" HeaderText="Description" ControlStyle-ForeColor="Black" />
        <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" />
    </Columns>

</asp:GridView>
    
        <asp:Button ID="btn_AddProduct" runat="server" Text="Submit A Review" OnClick="btn_AddProduct_Click" CssClass="cmn-btn auto-style2" Width="313px" />
</asp:Content>
