using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NorthwindDbTest_CSharp
{
    public partial class Product_Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Product Detail";
            if (!Page.IsPostBack)
            {
                string product_id = Request.QueryString["ID"];
                product_id = product_id ?? "0";

                if (product_id == "0")
                {
                    Response.Redirect("~/Products.aspx");
                }

                int result = 0;

                try
                {
                    result = Int32.Parse(product_id);
                    Console.WriteLine(result);
                }
                catch (FormatException)
                {
                   Response.Redirect("~/Products.aspx");
                }

                LoadProduct(result);
            }
        }

        /// <summary>
        /// Load all Product Detail into labels.
        /// </summary>
        private void LoadProduct(int product_id)
        {
            using (ProductsRepository productRepo = new ProductsRepository())
            {
                ProductViewModelService productViewModelService = new ProductViewModelService();
                var products = productRepo.GetById(product_id);

                if (products != null)
                {
                    pd_name.Text = products.Name;
                    pd_qpu.Text = products.QuantityPerUnit.ToString();
                    pd_up.Text = products.UnitPrice.ToString();
                    pd_uis.Text = products.UnitsInStock.ToString();
                }
                else
                {
                    Response.Redirect("~/Products.aspx");
                }
            }

            using (OrdersRepository ordertRepo = new OrdersRepository())
            {
                OrderViewModelService orderViewModelService = new OrderViewModelService();
                var orders = ordertRepo.GetAll();

                if (orders != null)
                {
                    gvOrders.DataSource = orderViewModelService.CreateViewModel(orders);
                    gvOrders.DataBind();
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

    }
}