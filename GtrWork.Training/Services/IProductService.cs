
using GtrWork.Training.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.Services
{
    public interface IProductService
    {
        IList<Product> GetAllProducts();

        (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex,
            int pageSize, string searchText, string sortText);

        Product GetProduct(int id);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        void CreateProduct(Product product);
        
    }
}
