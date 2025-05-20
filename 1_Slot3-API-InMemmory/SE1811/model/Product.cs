using System.ComponentModel.DataAnnotations;

namespace SE1811.model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }

    }
}
