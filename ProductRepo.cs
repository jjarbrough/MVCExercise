using Dapper;
using MVCDemo.Models;
using System.Data;

namespace MVCDemo
{
    public class ProductRepo : IProductRepo
    {
        private readonly IDbConnection _connection;

        public ProductRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id });
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
             new { name = product.Name, price = product.Price, id = product.ProductID });
        }
    }
}
