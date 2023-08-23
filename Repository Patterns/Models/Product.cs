using System.ComponentModel.DataAnnotations;

namespace Repository_Patterns.Models
{
    public class Product
    {
        [Key]
        public int prodId { get; set; }

        public string prodName { get; set; }

        public string prodDescription { get; set; }
    }
}
