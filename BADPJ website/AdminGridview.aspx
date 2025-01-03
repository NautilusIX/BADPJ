<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGridview.aspx.cs" Inherits="BADPJ_website.AdminGridview" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Admin Gridview - GetGud Admin</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />

    <!-- Core CSS (DataTables + Custom Styles) -->
    <link href="https://cdn.jsdelivr.net/npm/simple-datatables@latest/dist/style.css" rel="stylesheet" />
    <link href="css/styles.css" rel="stylesheet" />

    <!-- FontAwesome Icons -->
    <script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>
</head>
<body class="sb-nav-fixed">
    <form id="form1" runat="server">
        <!-- ======================= TOP NAVBAR ======================= -->
        <nav class="sb-topnav navbar navbar-expand navbar-dark bg-dark">
            <!-- Brand -->
            <a class="navbar-brand ps-3" href="admintesting.aspx">GetGud Admin</a>
            <!-- Sidebar Toggle -->
            <button class="btn btn-link btn-sm order-1 order-lg-0 me-4 me-lg-0" id="sidebarToggle" type="button">
                <i class="fas fa-bars"></i>
            </button>
            <!-- Search Bar -->
            <div class="input-group">
                <input class="form-control" type="text" placeholder="Search..." aria-label="Search bar" />
                <button class="btn btn-primary" type="button" id="btnNavbarSearch">
                    <i class="fas fa-search"></i>
                </button>
            </div>
            <!-- Right-Side Navbar -->
            <ul class="navbar-nav ms-auto ms-md-0 me-3 me-lg-4">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" id="navbarDropdown" href="#" role="button"
                       data-bs-toggle="dropdown" aria-expanded="false">
                       <i class="fas fa-user fa-fw"></i>
                    </a>
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

        <!-- ======================= MAIN SIDEBAR LAYOUT ======================= -->
        <div id="layoutSidenav">
            <!-- Left Sidebar Navigation -->
            <div id="layoutSidenav_nav">
                <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">
                    <!-- Sidebar Menu Items -->
                    <div class="sb-sidenav-menu">
                        <div class="nav">
                            <div class="sb-sidenav-menu-heading">Core</div>
                            <a class="nav-link" href="admin.aspx">
                                <div class="sb-nav-link-icon"><i class="fas fa-tachometer-alt"></i></div>
                                Dashboard
                            </a>
                            <div class="sb-sidenav-menu-heading">Data</div>
                            <a class="nav-link collapsed" href="#" data-bs-toggle="collapse" data-bs-target="#collapseLayouts"
                               aria-expanded="false" aria-controls="collapseLayouts">
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
                                Coach Notification
                            </a>
                        </div>
                    </div>
                    <!-- Sidebar Footer -->
                    <div class="sb-sidenav-footer">
                        <div class="small">Logged in as:</div>
                        Admin
                    </div>
                </nav>
            </div>

            <!-- ======================= MAIN CONTENT AREA ======================= -->
            <div id="layoutSidenav_content">
                <main class="container-fluid px-4">
                    <h1 class="mt-4">Gridview</h1>
                    <ol class="breadcrumb mb-4">
                        <li class="breadcrumb-item active">Admin Gridview</li>
                    </ol>

                    <!-- Data Table Card -->
                    <div class="card mb-4">
                        <div class="card-header">
                            <i class="fas fa-table me-1"></i>
                            Administrators Table
                        </div>
                        <div class="card-body">
                            <!-- ====== Admin GridView ====== -->
                            <asp:GridView
                                ID="GridView1"
                                runat="server"
                                AllowPaging="True"
                                AllowSorting="True"
                                AutoGenerateColumns="False"
                                DataKeyNames="Email_Admin"
                                DataSourceID="SqlDataSource5"
                                BackColor="White"
                                BorderColor="#999999"
                                BorderStyle="Solid"
                                BorderWidth="1px"
                                CellPadding="3"
                                ForeColor="Black"
                                GridLines="Vertical"
                                PageSize="10"
                                EmptyDataText="No admin records found.">
                                
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />

                                <Columns>
                                    <!-- Admin ID (Read-Only) -->
                                    <asp:BoundField 
                                        DataField="Admin_ID"
                                        HeaderText="Admin ID"
                                        InsertVisible="False"
                                        ReadOnly="True"
                                        SortExpression="Admin_ID" />

                                    <!-- Username -->
                                    <asp:BoundField
                                        DataField="Username_Admin"
                                        HeaderText="Username"
                                        SortExpression="Username_Admin" />

                                    <!-- Email (Key) -->
                                    <asp:BoundField
                                        DataField="Email_Admin"
                                        HeaderText="Email"
                                        ReadOnly="True"
                                        SortExpression="Email_Admin" />

                                    <!-- Password Masked/Hidden -->
                                    <asp:TemplateField HeaderText="Password (masked)">
                                        <ItemTemplate>
                                            <!-- Option 1: Completely hide password -->
                                            <!-- Option 2: Show a placeholder -->
                                            *****
                                            <!--
                                            // Or partial mask example:
                                            // string pass = Eval("Password_Admin").ToString();
                                            // string masked = new string('*', pass.Length);
                                            // Response.Write(masked);
                                            -->
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <!-- Phone Number -->
                                    <asp:BoundField
                                        DataField="Phone_No_Admin"
                                        HeaderText="Phone"
                                        SortExpression="Phone_No_Admin" />
                                </Columns>
                            </asp:GridView>

                            <!-- ====== SqlDataSource ====== -->
                            <asp:SqlDataSource
                                ID="SqlDataSource5"
                                runat="server"
                                ConnectionString="<%$ ConnectionStrings:GetGudDB %>"
                                SelectCommand="SELECT [Admin_ID], [Username_Admin], [Email_Admin], [Password_Admin], [Phone_No_Admin] FROM [Admin]">
                            </asp:SqlDataSource>
                        </div>
                    </div>
                </main>

                <!-- FOOTER -->
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
            </div> <!-- /layoutSidenav_content -->
        </div> <!-- /layoutSidenav -->
    </form>

    <!-- Core scripts -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" crossorigin="anonymous"></script>
    <script src="js/scripts.js"></script>

    <!-- Chart.js + Additional Demo scripts -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.8.0/Chart.min.js" crossorigin="anonymous"></script>
    <script src="assets/demo/chart-area-demo.js"></script>
    <script src="assets/demo/chart-bar-demo.js"></script>

    <!-- Simple-DataTables -->
    <script src="https://cdn.jsdelivr.net/npm/simple-datatables@latest" crossorigin="anonymous"></script>
    <script src="js/datatables-simple-demo.js"></script>
</body>
</html>

