using NorthwindDbTest_CSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NorthwindDbTest_CSharp.ViewModels
{
    public class OrderViewModel
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
        public decimal totalCostValue { get; set; }

        public IEnumerable<Detail> details { get; set; }
    }
}