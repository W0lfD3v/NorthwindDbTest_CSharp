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
                            <asp:GridView ID="gvProduct" runat="server"
                                AutoGenerateColumns="false"
                                Width="100%"
                                CellPadding="3"
                                CssClass="table table-sm table-striped table-light"
                                EmptyDataText="No products available."
                                OnPreRender="gvProduct_PreRender"
                                OnDataBound="gvProduct_DataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:HyperLink runat="server" Target="_self" NavigateUrl='<%# Eval("id","~/Product_Detail.aspx?id={0}")%>'><%# $"{Eval("Name")}" %></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty Per Unit" />
                                    <asp:TemplateField HeaderText="Unit Price">
                                        <ItemTemplate>
                                            <%# $"${Eval("UnitPrice")}" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="UnitsInStock" HeaderText="Units In Stock" />
                                    <asp:TemplateField HeaderText="Total Unit Value">
                                        <ItemTemplate>
                                            <%# $"${Eval("TotalUnitValue")}" %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available">
                                        <ItemTemplate>
                                            <i class='bi bi-circle-fill <%# Convert.ToBoolean(Eval("IsAvailable")) ? "text-success" : "text-danger" %>'></i>
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
