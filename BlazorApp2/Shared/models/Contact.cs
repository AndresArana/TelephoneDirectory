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
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Por favor ingrese numeros validos")]
        public string telephone { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Por favor ingrese numeros validos")]
        public string phone { get; set; }
    }
}