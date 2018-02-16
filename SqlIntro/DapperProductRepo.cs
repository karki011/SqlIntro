using System.Collections.Generic;
using System.Data;
using Dapper;

namespace SqlIntro
{
    class DapperProductRepo : IProductRepository
    {
        private readonly IDbConnection _conn;

        public DapperProductRepo(IDbConnection conn)
        {
            _conn = conn;
        }
        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<Product>("SELECT name FROM Product;");
            }
        }
        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = _conn)
            {
                conn.Open();
                conn.Execute("Delete FROM Product WHERE ProductID =@id", new { id });
            }
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            using (var conn = _conn)
            {
                conn.Open();
                conn.Execute("UPDATE product SET name = @name WHERE ProductId = @id", new { name = prod.Name, id = prod.Id });
            }
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = _conn)
            {
                conn.Open();
                conn.Execute("INSERT into product (name) values(@name)", new { name = prod.Name });
            }
        }

        public IEnumerable<Product> GetProductsWithReviewLeft()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<Product>(
                    "SELECT product.Name, productreview.Rating FROM Product LEFT JOIN productreview ON productreview.productID = product.productID");
            }
        }

        public IEnumerable<Product> GetProductsWithReviewInner()
        {
            using (var conn = _conn)
            {
                conn.Open();
                return conn.Query<Product>("SELECT product.Name, productreview.Rating FROM Product INNER JOIN productreview ON productreview.productID = product.productID");
            }
        }
    }
}

