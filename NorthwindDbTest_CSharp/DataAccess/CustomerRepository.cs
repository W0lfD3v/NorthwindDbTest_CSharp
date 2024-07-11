using NorthwindDbTest_CSharp.Models;

namespace NorthwindDbTest_CSharp.DataAccess
{
    internal class CustomerRepository : BaseRepository<Customer>
    {
        /// <summary>
        /// Gets or sets the Northwind API endpoint used by this repository.
        /// </summary>
        public override string Endpoint { get => NorthwindApiEndpoints.Customers; }
    }
}