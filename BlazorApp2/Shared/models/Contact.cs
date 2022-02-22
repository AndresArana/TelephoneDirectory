using System.ComponentModel.DataAnnotations;
namespace BlazorApp2.Shared
{
    public class Contact
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string telephone { get; set; }
        [Required]
        public string phone { get; set; }
    }
}