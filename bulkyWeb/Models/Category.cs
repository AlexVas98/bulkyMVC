using System.ComponentModel.DataAnnotations;

namespace bulkyWeb.Models
{
    public class Category
    {
        //pata prop +tab gia get set

        //δεν χρειαζεται να δηλωσω primary key διοτι εχω βαλει id 
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
