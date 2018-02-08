using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace SqlIntro
{
    class DapperProductRepo
    {
        private readonly string _connectionString;
        public DapperProductRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        //SELECT all products 
        /*public IEnumerable<Product> GetProducts()
        {
            return
        }*/

        // DELETE a product with a particular ProductId
        // UPDATE a product's name with a particular ProductId
        //INSERT a new product
    }

}
}
