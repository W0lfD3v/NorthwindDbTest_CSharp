using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
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
        public Shipaddress shipAddress { get; set; }
        public OrderDetail[] details { get; set; }
    }

    public class Shipaddress
    {
        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
    }

    [Serializable]
    public class OrderDetail
    {
        public int productId { get; set; }
        public decimal unitPrice { get; set; }
        public int quantity { get; set; }
        public decimal discount { get; set; }
    }

}