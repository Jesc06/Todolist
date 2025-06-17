using System.ComponentModel.DataAnnotations;

namespace Todo_List_App.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Task { get; set; } 
    }
}
