using MVCDemo.Models;

namespace MVCDemo
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int id);
    }
}
