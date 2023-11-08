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

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductID });
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
            _connection.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _connection.Query<Category>("SELECT * FROM categories;");
        }

        public Product GetProduct(int id)
        {
            return _connection.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id });
        }

        public void InsertProduct(Product productToInsert)
        {
            _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
        new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
        }

        public void UpdateProduct(Product product)
        {
            _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
             new { name = product.Name, price = product.Price, id = product.ProductID });
        }


    }
}
