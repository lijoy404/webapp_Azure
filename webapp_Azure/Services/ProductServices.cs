using System.Data.SqlClient;
using webapp_Azure.Models;

namespace webapp_Azure.Services
{
    public class ProductServices
    {
        private static string db_source = "usualdatabase.database.windows.net";
        private static string db_user = "database";
        private static string db_password = "Password@123";
        private static string db_database = "usualdb";

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public string Quantity { get; private set; }



        //This will connect the database
        private SqlConnection GetConnection()     
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;    
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }



        //This will Retrieve the List of products from the Table
        public List<Products> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Products> _product_lst = new List<Products>();
            string statement = "Select ProductId, ProductName, Quantity from Products";
            // This string statement will create empty list


            // conn.Open wil open the connection and
            // ExecuteReader will read the data from the database
            conn.Open();

            SqlCommand cmd = new SqlCommand (statement, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read()) 
                {

                    //Creating object of the products
                    Products product = new Products()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2),
                    };

                    //Adding the products in the list of the Product
                    _product_lst.Add(product);
                }
            }
            conn.Close();
            return _product_lst;
        }
            
    }
}
