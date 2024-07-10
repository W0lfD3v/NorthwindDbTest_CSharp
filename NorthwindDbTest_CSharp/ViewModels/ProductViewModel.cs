using NorthwindDbTest_CSharp.Models;
using System.ComponentModel;

namespace NorthwindDbTest_CSharp.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [DisplayName(nameof(Name))]
        public string Name { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public decimal TotalUnitValue { get; set; }
        public bool IsAvailable { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
    }
}