using System.ComponentModel.DataAnnotations;

namespace FirstMVCApplication1.Models
{
    public class AddAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
