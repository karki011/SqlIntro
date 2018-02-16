using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;
            var connection = new MySqlConnection(connectionString);
            var repo = new DapperProductRepo(connection);

            Product product = null;
            foreach (var prod in repo.GetProducts())
            {
                if(product == null) { product = prod; };
                Console.WriteLine("Product Name:" + prod.Name);
            }

            repo.DeleteProduct(1001);

            var newProduct = new Product
            {
                Name = "new product"
            };
            repo.InsertProduct(newProduct);

            repo.UpdateProduct(new Product
            {
                Id =3,
                Name = "Subash karki"
            });


            Console.WriteLine("Start.");

             foreach (var prod in repo.GetProductsWithReviewLeft())

             {
                 if (product == null) { product = prod; };

                Console.WriteLine(prod.Name );
             }
             
            //repo.GetProductsWithReviewLeft();



            //repo.GetProductsWithReviewInner();

            Console.ReadLine();
        } 
    }
}
