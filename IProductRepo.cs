using MVCDemo.Models;

namespace MVCDemo
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
