using NorthwindDbTest_CSharp.DataAccess;
using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDbTest_CSharp.Services
{
    public class OrderViewModelService : IViewModelService<OrderViewModel, Order>
    {
        public OrderViewModelService()
        {
                
        }

        /// <summary>
        /// Creates a <see cref="OrderViewModel"/> from a provided <see cref="Order"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Order"/> model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public OrderViewModel CreateViewModel(Order source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return new OrderViewModel()
            {
                id = source.id,
                customerId = source.customerId,
                orderDate = source.orderDate,
                shipName = source.shipName,
                shippedDate = source.shippedDate,
                shipVia = source.shipVia,
                freight = source.freight,
                details = source.details,
                totalCostValue = source.details.Sum(x => (x.unitPrice * x.quantity) - x.discount)
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="OrderViewModel"/> from a provided collection of <see cref="Order"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Order"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<OrderViewModel> CreateViewModel(IEnumerable<Order> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return source.Select(ord => CreateViewModel(ord));
        }
    }
}