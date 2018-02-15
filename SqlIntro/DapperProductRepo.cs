using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _conn.Query<Product>("SELECT name FROM Product;");

        }
        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            _conn.Execute("Delete FROM Product WHERE ProductID =@id", new { id });
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            _conn.Execute("UPDATE product SET name = @name WHERE ProductId = @id", new { name = prod.Name, id = prod.Id });
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            _conn.Execute("INSERT into product (name) values(@name)", new { name = prod.Name });
        }
    }
}

