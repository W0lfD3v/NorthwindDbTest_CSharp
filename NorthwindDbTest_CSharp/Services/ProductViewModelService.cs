using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDbTest_CSharp.Services
{
    public class ProductViewModelService : IViewModelService<ProductViewModel, Product>
    {
        public ProductViewModelService()
        {
                
        }

        /// <summary>
        /// Creates a <see cref="ProductViewModel"/> from a provided <see cref="Product"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Product"/> model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public ProductViewModel CreateViewModel(Product source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return new ProductViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                SupplierId = source.SupplierId,
                CategoryId = source.CategoryId,
                UnitsOnOrder = source.UnitsOnOrder,
                ReorderLevel = source.ReorderLevel,
                IsAvailable = !source.Discontinued,
                QuantityPerUnit = source.QuantityPerUnit,
                TotalUnitValue = source.UnitPrice * source.UnitsInStock,
                UnitPrice = source.UnitPrice,
                UnitsInStock = source.UnitsInStock
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="ProductViewModel"/> from a provided collection of <see cref="Product"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Product"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<ProductViewModel> CreateViewModel(IEnumerable<Product> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return source.Select(prod => CreateViewModel(prod));
        }
    }
}