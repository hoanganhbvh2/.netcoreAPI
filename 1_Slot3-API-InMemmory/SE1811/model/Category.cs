using System.ComponentModel.DataAnnotations;

namespace SE1811.model
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        // Quan hệ 1-N: Một Category có nhiều Product
        public ICollection<Product> Products { get; set; }
    }
}
