namespace Eterna.Models
{
    public class ProductClient
    {
        public int ProductId { get; set; }  
        public int ClientId { get; set; }   
        public Product Products { get; set;}
        public Client Clients { get; set;} 
    }
}
