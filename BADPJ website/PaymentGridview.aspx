<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentGridview.aspx.cs" Inherits="BADPJ_website.PaymentGridview" %>


<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
        <meta name="description" content="" />
        <meta name="author" content="" />
        <title>Dashboard - SB Admin</title>
        <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
        <link href="css/styles.css" rel="stylesheet" />
        <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
    </head>
    <body class="sb-nav-fixed">
        <form id="form1" runat="server">
        <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <!-- Navbar Brand-->
            <a class="navbar-brand ps-3" href="admintesting.aspx">GetGud Admin</a>
            <!-- Sidebar Toggle-->
            <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" href="#!"><i class="fas fa-bars"></i></button>
            <!-- Navbar Search-->
                <div class="input-group">
                    <input class="form-control" type="text" placeholder="Search for..." aria-label="Search for..." aria-describedby="btnNavbarSearch" />
                    <button class="btn btn-primary" id="btnNavbarSearch" type="button"><i class="fas fa-search"></i></button>
                </div>
            <!-- Navbar-->
            <ul class="navbar-nav ms-auto ms-md-0 me-3 me-lg-4">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false"><i class="fas fa-user fa-fw"></i></a>
                    <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                        <li><a class="dropdown-item" href="#!">Settings</a></li>
                        <li><a class="dropdown-item" href="#!">Activity Log</a></li>
                        <li><a class="dropdown-item" href="adminregister.aspx">Create New Account</a></li>
                        <li><hr class="dropdown-divider" /></li>
                        <li><a class="dropdown-item" href="login.aspx">Logout</a></li>
                    </ul>
                </li>
            </ul>
        </nav>
        <div id="layoutSidenav">
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                            <div class="sb-sidenav-menu-heading">Core</div>
                            <a class="nav-link" href="admin.aspx">
                                <div class="sb-nav-link-icon"><i class="fas fa-tachometer-alt"></i></div>
                                Dashboard
                            </a>
                            <div class="sb-sidenav-menu-heading">Data</div>
                            <a class="nav-link collapsed" href="#" data-bs-toggle="collapse" data-bs-target="#collapseLayouts" aria-expanded="false" aria-controls="collapseLayouts">
                                <div class="sb-nav-link-icon"><i class="fas fa-columns"></i></div>
                                Gridview
                                <div class="sb-sidenav-collapse-arrow"><i class="fas fa-angle-down"></i></div>
                            </a>
                            <div class="collapse" id="collapseLayouts" aria-labelledby="headingOne" data-bs-parent="#sidenavAccordion">
                                <nav class="sb-sidenav-menu-nested nav">
                                    <a class="nav-link" href="AdminGridview.aspx">Admin Gridview</a>
                                    <a class="nav-link" href="CustomerGridview.aspx">Customer Gridview</a>
                                    <a class="nav-link" href="PaymentGridview.aspx">Payment Gridview</a>

                                </nav>
                            </div>
                            
                            <div class="sb-sidenav-menu-heading">Addons</div>
                            <a class="nav-link" href="charts.html">
                                <div class="sb-nav-link-icon"><i class="fas fa-chart-area"></i></div>
                                Partners
                            </a>
                            <a class="nav-link" href="tables.html">
                                <div class="sb-nav-link-icon"><i class="fas fa-table"></i></div>
                                Coach Notificiation
                            </a>
                        </div>
                    </div>
                    <div class="sb-sidenav-footer">
                        <div class="small">Logged in as:</div>
                        Admin
                    </div>
                </nav>
            </div>
            <div id="layoutSidenav_content">
                <main>
                    <div class="container-fluid px-4">
                        <h1 class="mt-4">Gridview</h1>
                        <ol class="breadcrumb mb-4">
                            <li class="breadcrumb-item active">Customer Gridview</li>
                        </ol>
                        
                        
                        <div class="card mb-4">
                            <div class="card-header">
                                <i class="fas fa-table me-1"></i>
                                List of Payments
                            </div>
                            <div>
        
        <asp:GridView ID="payment_view" class ="sub-title" OnPageIndexChanging="payment_view_PageIndexChanging" runat="server" ApplyFormatInEditMode="true" AutoGenerateColumns="False" Width="100%" DataKeyNames="Payment_ID" DataSourceID="SqlDataSource2" AllowPaging="True" ForeColor="Black" OnRowDeleting="gv_paymentDelete" OnRowCancelingEdit="payment_view_RowCancelingEdit" OnRowEditing="payment_view_RowEditing" OnRowUpdating="payment_view_RowUpdating" OnSelectedIndexChanged="payment_view_SelectedIndexChanged"  EditRowStyle-BackColor="White" EditRowStyle-ForeColor="Black" BorderColor="Black" EditRowStyle-Width="100%" EditRowStyle-HorizontalAlign="Justify">
  <RowStyle CssClass="gridview-row"/>
  <AlternatingRowStyle CssClass="gridview-alternating-row"/>
            <EditRowStyle CssClass="gridview-edit-row" Width="500px"/>
            <HeaderStyle CssClass="gridview-header"/>
            
            <Columns>
                <asp:BoundField DataField="Payment_ID" ReadOnly="true" HeaderText="Payment_ID"  SortExpression="Payment_ID" />
                <asp:BoundField DataField="customer_email" HeaderText="Customer Email" SortExpression="customer_email" />
                <asp:BoundField DataField="coach_email" HeaderText="Coach Email" SortExpression="coach_email" />
                <asp:BoundField DataField="payment_amount" HeaderText="Payment Amount" SortExpression="payment_amount" />
                <asp:BoundField DataField="payment_date" HeaderText="Payment Date" SortExpression="payment_date" />
                <asp:BoundField DataField="discount_given" HeaderText="Discount given" SortExpression="discount_given" />
                <asp:BoundField DataField="platform_fee" HeaderText="Platform fee" SortExpression="platform_fee" />
                <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:CommandField ShowEditButton="True" />
                

            </Columns>


        </asp:GridView>
                                <style type="text/css">
  .gridview-table {
    width: 100%;
    table-layout: fixed;
  }
  .gridview-edit-row {
   width: auto !important;
}
  .gridview-row {
    background-color: #DCDCDC;
  }
  .gridview-alternating-row {
    background-color: #F2F2F2;
  }
  .gridview-header {
    background-color: #808080;
    color: #FFFFFF;
  }
</style>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:GetGudDB %>" SelectCommand="SELECT * FROM [Payment]"></asp:SqlDataSource>
    </div>
                        </div>
                    </div>
                </main>
                <footer class="py-4 bg-light mt-auto">
                    <div class="container-fluid px-4">
                        <div class="d-flex align-items-center justify-content-between small">
                            <div class="text-muted">Copyright &copy; Your Website 2022</div>
                            <div>
                                <a href="#">Privacy Policy</a>
                                &middot;
                                <a href="#">Terms &amp; Conditions</a>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
        <script src="js/scripts.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
        <script src="assets/demo/chart-area-demo.js"></script>
        <script src="assets/demo/chart-bar-demo.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
        <script src="js/datatables-simple-demo.js"></script>
        </form>
    </body>
</html>

