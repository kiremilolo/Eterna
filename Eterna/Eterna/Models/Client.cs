    namespace Eterna.Models
{
    public class Client
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public ICollection<ProductClient> ProductClient { get; set; }
    }
}
