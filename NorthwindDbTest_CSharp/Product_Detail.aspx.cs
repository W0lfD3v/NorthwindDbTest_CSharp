using Microsoft.Ajax.Utilities;
using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindDbTest_CSharp
{
    public partial class Product_Detail : System.Web.UI.Page
    {
        private int prod_id;
        private int cat_id;
        private int sup_id;
        public string isAvailable;

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Product Detail";
            string qstring;
            if (!Page.IsPostBack)
            {
                qstring = Request.QueryString["ID"];
                qstring = qstring ?? "0";

                if (qstring == "0")
                {
                    //if it's null or 0, send back to the products page
                    Response.Redirect("~/Products.aspx");
                }

                try
                {
                    prod_id = Int32.Parse(qstring);
                }
                catch (FormatException)
                {
                   //todo: add logging and a user friendly error page. For now, send back to products page
                   Response.Redirect("~/Products.aspx");
                }

                LoadProductDetail();
                LoadCategory();
                LoadSuppliers();
                LoadOrders();
            }
        }

        /// <summary>
        /// Load all Product Detail into labels and Orders into gridview.
        /// </summary>
        private void LoadProductDetail()
        {
            using (ProductsRepository productRepo = new ProductsRepository())
            {
                ProductViewModelService productViewModelService = new ProductViewModelService();
                var products = productRepo.GetById(prod_id);

                if (products != null)
                {
                    cat_id = products.CategoryId;
                    sup_id = products.SupplierId;

                    var prodSource = productViewModelService.CreateViewModel(products);
                    product_name.Text = prodSource.Name;
                    product_quantity_per_unit.Text = string.Format("Quantity Per Unit: {0}", prodSource.QuantityPerUnit);
                    product_unit_price.Text = string.Format("Unit Price: ${0:#.00}", prodSource.UnitPrice);
                    product_total_unit_value.Text = string.Format("Total Unit Value: ${0:#.00}", prodSource.TotalUnitValue);
                    product_units_in_stock.Text = string.Format("Units In Stock: {0}", prodSource.UnitsInStock);
                    if (prodSource.IsAvailable)
                    {
                        isAvailable = "text-success";
                    }
                    else
                    {
                        isAvailable = "text-danger";
                    }
                    //product_available.Text = string.Format("Available: {0}", prodSource.IsAvailable);
                    product_units_on_order.Text = string.Format("Units On Order: {0}", prodSource.UnitsOnOrder);
                    product_reorder_level.Text = string.Format("Reorder Level: {0}", prodSource.ReorderLevel);
                }
                else
                {
                    //if for whatever reason we get this far and there is no product found, send back to the products page.
                    Response.Redirect("~/Products.aspx");
                }
            }
        }

        private void LoadOrders()
        {
            using (OrdersRepository ordertRepo = new OrdersRepository())
            {
                OrderViewModelService orderViewModelService = new OrderViewModelService();
                var orders = ordertRepo.GetAll();

                if (orders != null)
                {
                    gvOrders.DataSource = orderViewModelService.CreateViewModel(orders).Where(x => x.details.Any(y => y.productId == prod_id));
                    gvOrders.DataBind();
                }
            }
        }

        private void LoadSuppliers()
        {
            using (SuppliersRepository supplierRepo = new SuppliersRepository())
            {
                SupplierViewModelService supplierViewModelService = new SupplierViewModelService();
                var suppliers = supplierRepo.GetById(sup_id);

                if (suppliers != null)
                {
                    var supSource = supplierViewModelService.CreateViewModel(suppliers);
                    supplier_name.Text = supSource.CompanyName;
                    supplier_title.Text = string.Format("{0}: {1}", supSource.ContactTitle, supSource.ContactName);
                    //supplier_contact.Text = string.Format("Contact: {0}", supSource.ContactName);
                    supplier_address_street.Text = supSource.Address.Street;
                    supplier_address_city.Text = string.Format("{0}, {1} {2}", supSource.Address.City, supSource.Address.Region.Replace("NULL", null), supSource.Address.PostalCode);
                    supplier_address_country.Text = supSource.Address.Country;
                    supplier_address_phone.Text = string.Format("Phone: {0}", supSource.Address.Phone);
                }
            }
        }

        private void LoadCategory()
        {
            using (CategoriesRepository categoryRepo = new CategoriesRepository())
            {
                CategoryViewModelService categoryViewModelService = new CategoryViewModelService();
                var categories = categoryRepo.GetById(cat_id);

                if (categories != null)
                {
                    var catSource = categoryViewModelService.CreateViewModel(categories);
                    category_name.Text = catSource.Name;
                    category_description.Text = string.Format("Description: {0}", catSource.Description);
                }
            }
        }

        protected void gvOrders_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
            {
                // Force GridView to use <thead> instead of <tbody>
                // This allows the Bootstrap styles to be applied appropriately
                gv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            if (gv.ShowFooter == true && gv.Rows.Count > 0)
            {
                // Force GridView to use <tfoot> instead of <tbody>
                // This allows the Bootstrap styles to be applied appropriately
                gv.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

        protected void gvOrders_DataBound(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            lblRecordCount.Text = $"Showing 1 to {gv.Rows.Count} of {gv.Rows.Count} entries";
        }
        protected string ReformatDate(string valueFromDatabase)
        {
            DateTime value;
            if (!DateTime.TryParseExact(valueFromDatabase, "yyyy-MM-dd hh:mm:ss.fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
            {
                return string.Empty;
            }

            return value.ToString("M/d/yyyy", CultureInfo.CurrentCulture);
        }
        protected string getCustomerName(string customerId)
        {
            string customerName = string.Empty;
            if (!string.IsNullOrEmpty(customerId))
            {
                using (CustomerRepository customerRepo = new CustomerRepository())
                {
                    CustomerViewModelService orderViewModelService = new CustomerViewModelService();
                    var customer = customerRepo.GetById(customerId);

                    if (customer != null)
                    {
                        customerName = customer.contactName;
                    }
                }
            }
            return customerName;
        }
    }
}