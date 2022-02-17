
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data
{
public class Contact
{
    [Required]
    [Key]
    public string? name { get; set; }
    [Required]
    public string? telephone { get; set; }
    [Required]
    public string? phone { get; set; }

}
}