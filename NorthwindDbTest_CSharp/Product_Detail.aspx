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
            <h2 id="title"><%: Title %></h2>
            <asp:UpdatePanel ID="upResults" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label runat="server" ID="pd_name" Text="Name:" />
                    <div class="w-100"></div>
                    <asp:Label runat="server" ID="pd_qpu" Text="Qty Per Unit:" />
                    <div class="w-100"></div>
                    <asp:Label runat="server" ID="pd_up" Text="Unit Price:" />
                    <div class="w-100"></div>
                    <asp:Label runat="server" ID="pd_uis" Text="Units In Stock:" />
                    <div class="w-100"></div>
                    <asp:Label runat="server" ID="pd_tuv" Text="Total Unit Value:" />
                    <div class="w-100"></div>
                    <asp:Label runat="server" ID="pd_a" Text="Available:" />
                    <div class="w-100"></div>
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
                                    <asp:BoundField DataField="orderDate" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField DataField="shipName" HeaderText="Name" />
                                    <asp:BoundField DataField="shippedDate" HeaderText="Date Shipped"/>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
