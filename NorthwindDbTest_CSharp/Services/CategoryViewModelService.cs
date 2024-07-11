using NorthwindDbTest_CSharp.Models;
using NorthwindDbTest_CSharp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindDbTest_CSharp.Services
{
    public class CategoryViewModelService : IViewModelService<CategoryViewModel, Category>
    {
        public CategoryViewModelService()
        {
                
        }

        /// <summary>
        /// Creates a <see cref="CategoryViewModel"/> from a provided <see cref="Category"/> model.
        /// </summary>
        /// <param name="source">The <see cref="Category"/> model.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public CategoryViewModel CreateViewModel(Category source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return new CategoryViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description            
            };
        }

        /// <summary>
        /// Creates a collection of <see cref="CategoryViewModel"/> from a provided collection of <see cref="Category"/> models.
        /// </summary>
        /// <param name="source">The collection of <see cref="Category"/> models.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<CategoryViewModel> CreateViewModel(IEnumerable<Category> source)
        {
            if (source == null) { throw new ArgumentNullException(nameof(source)); }

            return source.Select(cat => CreateViewModel(cat));
        }
    }
}