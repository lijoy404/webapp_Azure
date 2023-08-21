using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using webapp_Azure.Models;
using webapp_Azure.Services;

namespace webapp_Azure.Pages
{
    public class IndexModel : PageModel
    {
        //this will disaly the list of products
        public List<Products> Produts;

        public List<Products> Products { get; private set; }


        //whenever the projects run, it get invoke to Index page
        public void OnGet()
        {
            //Creating Object of ProductService
            ProductServices productService = new ProductServices();

            //Calling productService cz we have the method
            // to return all the Products that is available as a table in the SQLDB
            Products = productService.GetProducts();
        }
    }
}