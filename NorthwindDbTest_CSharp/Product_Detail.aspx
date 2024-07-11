<%@ Page Title="Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Product_Detail.aspx.cs" Inherits="NorthwindDbTest_CSharp.Product_Detail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="./">Home</a></li>
                <li class="breadcrumb-item active" aria-current="page">Product Detail</li>
            </ol>
        </nav>

        <div class="row mt-3">
            <asp:UpdatePanel ID="upResults" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <h2 id="title" class="mb-4"><%: Title %></h2>
                                <div class="row mb-6">
                                    <h5>
                                        <asp:Label runat="server" ID="product_name" /></h5>
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="product_units_in_stock" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="product_unit_price" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="product_total_unit_value" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="product_quantity_per_unit" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="product_reorder_level" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="product_units_on_order" />
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="row mb-1">
                                            <asp:Label runat="server" ID="product_available" Text="Available: " />
                                        </div>
</div>                                    <div class="col">
                                        <div class="row mb-1">
                                            <i class='bi bi-circle-fill <%= isAvailable %> '></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col">
                                <h2 id="cattitle" class="mb-4">Category</h2>
                                <div class="row mb-6">
                                    <h5>
                                        <asp:Label runat="server" ID="category_name" /></h5>
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="category_description" />
                                </div>
                            </div>
                            <div class="col">
                                <h2 id="suptitle" class="mb-4">Supplier</h2>
                                <div class="row mb-6">
                                    <h5>
                                        <asp:Label runat="server" ID="supplier_name" /></h5>
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_title" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_contact" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_address_street" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_address_city" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_address_region" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_address_postalcode" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_address_country" />
                                </div>
                                <div class="row mb-6">
                                    <asp:Label runat="server" ID="supplier_address_phone" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <h2 id="gvtitle">Related Orders</h2>
                    <div class="me-sm-auto py-2">
                        <span class="small">
                            <asp:Literal ID="lblRecordCount" runat="server"></asp:Literal></span>
                    </div>
                    <div class="col-12 mt-2">
                        <div class="table-responsive">
                            <asp:GridView ID="gvOrders" runat="server"
                                AutoGenerateColumns="false"
                                Width="100%"
                                CellPadding="3"
                                CssClass="table table-sm table-striped table-light"
                                EmptyDataText="No orders for this product."
                                OnPreRender="gvOrders_PreRender"
                                OnDataBound="gvOrders_DataBound">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Order Number" />
                                    <asp:TemplateField HeaderText="Date Ordered">
                                        <ItemTemplate>
                                            <%# ReformatDate($"{Eval("orderDate", "{0}")}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer Name">
                                        <ItemTemplate>
                                            <%# getCustomerName($"{Eval("customerId")}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date Shipped">
                                        <ItemTemplate>
                                            <%# ReformatDate($"{Eval("shippedDate", "{0}")}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total">
                                        <ItemTemplate>
                                            <%# $"{Eval("totalCostValue", "$ {0:#,##0.#0}")}" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shippint Total">
                                        <ItemTemplate>
                                            <%# $"{Eval("freight", "$ {0:#,##0.#0}")}" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
