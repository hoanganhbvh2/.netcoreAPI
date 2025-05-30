using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

//using System.Text.Json.Serialization;
using System.Xml.Serialization;
//using Newtonsoft.Json;


namespace SE1811.model
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string NameProduct { get; set; }
        public string DescriptionProduct { get; set; }
        //[IgnoreDataMember]
        public int Price {  get; set; }
        // Foreign key
        //[XmlIgnore]
        //[IgnoreDataMember]
        public int CategoryID { get; set; }

        // Navigation property
        [JsonIgnore]
        public Category? Category { get; set; }


    }
}
