using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDbTest_CSharp.Services
{
    public class SupplierViewModelService : IViewModelService<SupplierViewModel, Supplier>
    {
        public SupplierViewModelService()
        {
                
        }

        /// <summary>
        /// Creates a <see cref="SupplierViewModel"/> from a provided <see cref="Supplier"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Supplier"/> model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public SupplierViewModel CreateViewModel(Supplier source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return new SupplierViewModel()
            {
                Id = source.Id,
                CompanyName = source.CompanyName,
                ContactName = source.ContactName,
                ContactTitle = source.ContactTitle,
                Address = source.Address
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="SupplierViewModel"/> from a provided collection of <see cref="Supplier"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Supplier"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<SupplierViewModel> CreateViewModel(IEnumerable<Supplier> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return source.Select(sup => CreateViewModel(sup));
        }
    }
}