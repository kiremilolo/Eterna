namespace Eterna.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; set; }  
        public string Image { get; set; }   
        public string ProjectUrl { get; set; }  
        public string DetailTitle { get; set; } 
        public string DetailDesc { get; set; }  
        public string Icon1 { get; set; }   
        public string Icon2 { get; set; }   
        public DateTime CreaatedDate { get; set; }  
        public DateTime EditDate { get; set; }  
        public Category Category { get; set; } 
        public ICollection<ProductClient> ProductClient { get; set; }

    }
}
