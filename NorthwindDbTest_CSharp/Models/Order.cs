using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.Models
{
    [Serializable]
    public class Order
    {
        public int id { get; set; }
        public string customerId { get; set; }
        public int employeeId { get; set; }

        public string orderDate { get; set; }
        public string requiredDate { get; set; }
        public string shippedDate { get; set; }
        public int shipVia { get; set; }
        public float freight { get; set; }
        public string shipName { get; set; }
        public Address shipAddress { get; set; }
        public IEnumerable<Detail> details { get; set; }
    }

    [Serializable]
    public class Detail
    {
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
    }

}