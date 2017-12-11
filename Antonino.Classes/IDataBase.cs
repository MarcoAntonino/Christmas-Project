using System.Collections.Generic;

namespace Antonino.Classes
{
    public interface IDataBase
    {
        bool InsertProduct(Product product);

        Product GetProduct(string id);

        IEnumerable<Product> GetAllProducts();

        bool UpdateProduct(Product product);

        bool RemoveProduct(string id);

    }
}
