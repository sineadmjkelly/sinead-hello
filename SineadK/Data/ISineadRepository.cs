using System.Collections.Generic;
using SineadK.Data.Entities;

namespace SineadK.Data
{
    public interface ISineadRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}