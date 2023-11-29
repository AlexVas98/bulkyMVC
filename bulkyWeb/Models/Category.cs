using System.ComponentModel;
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
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; }
       
        [DisplayName("Display Order")]
        [Range(0, 100, ErrorMessage ="Πρέπει να είναι από 0 εως 100")]
        public int DisplayOrder { get; set; }
        
    }
}
