using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDbTest_CSharp.Services
{
    public class CustomerViewModelService : IViewModelService<CustomerViewModel, Customer>
    {
        public CustomerViewModelService()
        {
                
        }

        /// <summary>
        /// Creates a <see cref="CustomerViewModel"/> from a provided <see cref="Customer"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Customer"/> model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public CustomerViewModel CreateViewModel(Customer source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return new CustomerViewModel()
            {
                Id = source.id,
                CompanyName = source.companyName,
                ContactName = source.contactName,
                ContactTitle = source.contactTitle,
                Address = source.address
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="CustomerViewModel"/> from a provided collection of <see cref="Customer"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Supplier"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<CustomerViewModel> CreateViewModel(IEnumerable<Customer> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return source.Select(cust => CreateViewModel(cust));
        }
    }
}